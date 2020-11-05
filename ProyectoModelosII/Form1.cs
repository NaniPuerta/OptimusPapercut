using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Linker;
using OptimizationCore;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Reflection;
using System.Windows.Markup;

namespace ProyectoModelosII
{
    public partial class Form1 : Form
    {
        #region Parameters

        Color cutColor;
        Color wasteFillColor;
        Color wasteBorderColor;
        Color pieceBorderColor;
        Color pieceNameColor;

        Pen cutPen;
        Pen wastePen;
        Pen piecePen;

        Brush wasteBrush;

        bool show_each_pattern_count;

        bool screen_locked;

        bool paint_cuts;
        bool paint_waste;
        bool paint_pieces;
        bool paint_piece_name;

        Brush pieceNameBrush;

        #endregion

        #region Fields

        int stockLength;
        int stockWidth;
        int stockCost;

        List<int> pieceLengths;
        List<int> pieceWidths;
        List<int> pieceDemands;

        List<List<int>> pieceCount;
        List<int> pieceCountTotal;

        CutPattern[] solution;

        List<int>[] Pieces;

        int actual_solution_index;


        List<PieceDrawing> pieceDrawings;
        List<WasteDrawing> wasteDrawings;
        List<CutDrawing> cutDrawings;

        bool all_ok;

        int initial_pb_Width;
        int initial_pb_Height;
        Point initial_pb_pos;
        double pbAspectRatio;


        PieceColors pieceColors;

        #endregion

        #region Constructors

        public Form1()
        {
            show_each_pattern_count = true;
            pieceDrawings = new List<PieceDrawing>();
            wasteDrawings = new List<WasteDrawing>();
            cutDrawings = new List<CutDrawing>();
            pieceLengths = new List<int>();
            pieceWidths = new List<int>();
            pieceDemands = new List<int>();
            pieceCount = new List<List<int>>();
            pieceCountTotal = new List<int>();
            Pieces = new List<int>[] { pieceLengths, pieceWidths, pieceDemands };
            all_ok = false;

            InitializeComponent();

            initial_pb_Width = pictureBox_sol.Width;
            initial_pb_Height = pictureBox_sol.Height;
            initial_pb_pos = pictureBox_sol.Location;
            pbAspectRatio = (double)initial_pb_Width / initial_pb_Height;
            stockLength = (int)numericUpDown_LengthStock.Value;
            stockWidth = (int)numericUpDown_WidthStock.Value;
            stockCost = (int)numericUpDown_CostStock.Value;
            pieceColors = new PieceColors();
            screen_locked = false;
            dataGridView_Pieces.EnableHeadersVisualStyles = true;
            solution = null;

            paint_cuts = true;
            paint_pieces = true;
            paint_waste = true;
            paint_piece_name = true;

            cutColor = Color.Black;
            wasteBorderColor = Color.DarkGray;
            wasteFillColor = Color.DarkGray;
            pieceBorderColor = Color.Black;
            pieceNameColor = Color.Black;

            UpdateColors();
        }

        #endregion

        #region Methods

        private void UpdateButtonState()
        {
            button_start.Enabled = button_saveData.Enabled = all_ok && !screen_locked;
        }

        private void CheckValidRows()
        {
            all_ok = true;

            if (dataGridView_Pieces.Rows[0].IsNewRow)
            {
                all_ok = false;
                return;
            }

            foreach (List<int> list in Pieces)
            {
                list.Clear();
            }

            foreach (DataGridViewRow row in dataGridView_Pieces.Rows)
            {
                if (row.IsNewRow) 
                    continue;

                DataGridViewCellCollection line = row.Cells;

                for (int i = 0; i < Pieces.Length; i++)
                {
                    if (int.TryParse((string)line[i].Value, out int value))
                    {
                        Pieces[i].Add(value);
                    }
                    else
                    {
                        all_ok = false;
                        break;
                    }
                }

                if (!all_ok) return;
            }
        }

        private void SetRowIDs()
        {
            int rowNumber = 1;
            foreach (DataGridViewRow row in dataGridView_Pieces.Rows)
            {
                if (!row.IsNewRow)
                {
                    DataGridViewCellCollection line = row.Cells;
                    line["ObtainedColumn"].Style.BackColor = pieceColors[rowNumber - 1];

                    //foreach (DataGridViewCell cell in line)
                    //{
                    //    cell.Style.BackColor = pieceColors[rowNumber - 1];
                    //}

                    row.HeaderCell.Value = rowNumber++.ToString();
                }
            }
        }

        private void Solve()
        {

            button_start.Text = "Calculando...";
            button_start.Refresh();
            solution = Linker.Linker.FindSolution(pieceLengths, pieceWidths, pieceDemands, stockLength, stockWidth, stockCost);

            CleanSolution();

            button_start.Text = "Contando...";
            button_start.Refresh();
            CalculatePieceCount();

            actual_solution_index = 0;
            label_pattern.Visible = true;
            label_PatternRep.Visible = true;
            label_TotalMat.Visible = true;
            
            textBox_totalMaterial.Text = solution.Sum(elem => elem.timesRepeated).ToString();

            button_start.Text = "Dibujando...";
            button_start.Refresh();
            ShowSolution();

            button_start.Text = "Solución calculada";
            button_start.Refresh();
        }

        private void ResizePB()
        {
            initial_pb_pos = panel_pb.Location;
            initial_pb_Height = panel_pb.Size.Height;
            initial_pb_Width = panel_pb.Size.Width;
            pbAspectRatio = (double)panel_pb.Size.Width / panel_pb.Size.Height;
            UpdateAspectRatio();
        }

        private void CleanSolution()
        {
            solution = solution.ToList().FindAll(cp => cp.timesRepeated > 0).ToArray();
        }

        private void ShowSolution()
        {
            if (solution != null)
            {
                pieceDrawings.Clear();
                wasteDrawings.Clear();
                cutDrawings.Clear();

                textBox_PatternRep.Text = solution[actual_solution_index].timesRepeated.ToString();
                textBox_cur_pattern.Text = (actual_solution_index + 1).ToString() + "/" + solution.Length;
                button_prevPattern.Enabled = actual_solution_index > 0;
                button_nextPattern.Enabled = actual_solution_index < solution.Length - 1;
                CutTree tree = solution[actual_solution_index].cuts;
                CheckRootSize(tree);
                PaintCutPattern((0, 0), tree);
                pictureBox_sol.Refresh();
                ShowPieceCount();
            }
        }

        private void ShowPieceCount()
        {
            for (int i = 0; i < pieceLengths.Count; i++)
            {
                DataGridViewCellCollection line = dataGridView_Pieces.Rows[i].Cells;
                line["ObtainedColumn"].Value = pieceCountTotal[i].ToString() + (show_each_pattern_count ? " (" + pieceCount[actual_solution_index][i].ToString() + ")": "");
            }
        }

        private float GetRelativeLength(float length)
        {
            return (float)pictureBox_sol.Width * (float)length / (float)stockLength;
        }

        private float GetRelativeWidth(float width)
        {
            return (float)pictureBox_sol.Height * (float)width / (float)stockWidth;
        }

        private void CheckRootSize(CutTree tree)
        {
            float verticalLength = 0;

            if (tree.Length < stockLength)
            {
                float verticalWidth = pictureBox_sol.Height;
                verticalLength = GetRelativeLength(stockLength - tree.Length);
                (float, float) verticalPoint = (GetRelativeLength(tree.Length), 0);

                wasteDrawings.Add(new WasteDrawing(verticalPoint, verticalLength, verticalWidth));
            }

            if (tree.Width < stockWidth)
            {
                float horizontalWidth = GetRelativeWidth(stockWidth - tree.Width);
                float horizontalLength = pictureBox_sol.Width - verticalLength;
                (float, float) horizontalPoint = (0, GetRelativeWidth(tree.Width));

                wasteDrawings.Add(new WasteDrawing(horizontalPoint, horizontalLength, horizontalWidth));
            }
        }

        private void PaintCutPattern((float x, float y) coord, CutTree tree)
        {
            if (tree == null)
                return;

            switch (tree.Kind)
            {
                case TypeOfCell.Cut:
                    (float x, float y) initCoord = (0, 0);
                    (float x, float y) finalCoord = (0, 0);

                    switch (tree.CutDirection)
                    {
                        case DirectionOfCut.Vertical:
                            initCoord = (coord.x + GetRelativeLength(tree.IndexOfPieceOrValueOfCut), coord.y);
                            finalCoord = (initCoord.x, initCoord.y + GetRelativeWidth(tree.Width));

                            break;

                        case DirectionOfCut.Horizontal:
                            initCoord = (coord.x, coord.y + GetRelativeWidth(tree.IndexOfPieceOrValueOfCut));
                            finalCoord = (initCoord.x + GetRelativeLength(tree.Length), initCoord.y);

                            break;

                        case DirectionOfCut.None:
                            throw new Exception("Cut Direction: None");
                    }

                    cutDrawings.Add(new CutDrawing(initCoord, finalCoord));

                    PaintCutPattern(coord, tree.Left);
                    PaintCutPattern(initCoord, tree.Right);

                    break;

                case TypeOfCell.Piece:
                    int piecelen = pieceLengths[tree.IndexOfPieceOrValueOfCut];
                    int piecewid = pieceWidths[tree.IndexOfPieceOrValueOfCut];
                    pieceDrawings.Add(new PieceDrawing(coord, GetRelativeLength(piecelen), GetRelativeWidth(piecewid), tree.IndexOfPieceOrValueOfCut));
                    CheckForPieceWaste(tree, coord);
                    break;

                case TypeOfCell.Waste:
                    wasteDrawings.Add(new WasteDrawing(coord, GetRelativeLength(tree.Length), GetRelativeWidth(tree.Width)));
                    break;

                case TypeOfCell.None:
                    throw new Exception("Tree Kind: None");
            }
        }

        private void CalculatePieceCount()
        {
            pieceCount.Clear();
            pieceCountTotal.Clear();

            for (int j = 0; j < solution.Length; j++)
            {
                pieceCount.Add(new List<int>());
                for (int i = 0; i < pieceLengths.Count; i++)
                {
                    pieceCount[j].Add(0);
                    pieceCountTotal.Add(0);
                }
            }

            for (int i = 0; i < solution.Length; i++)
            {
                int[] values = (from value in (solution[i].variant_vector) select (int)value).ToArray();

                for (int j = 0; j < values.Length; j++)
                {
                    pieceCount[i][j] += values[j];
                    pieceCountTotal[j] += values[j] * solution[i].timesRepeated;
                }
            }
        }

        private void CheckForPieceWaste(CutTree tree, (float x, float y) coord)
        {
            float piecelen = pieceLengths[tree.IndexOfPieceOrValueOfCut];
            float piecewid = pieceWidths[tree.IndexOfPieceOrValueOfCut];
            float verticalLength = 0;

            if (tree.Length > piecelen)
            {
                float verticalWidth = GetRelativeWidth(tree.Width);
                verticalLength = GetRelativeLength(tree.Length - piecelen);
                (float, float) verticalPoint = (coord.x + GetRelativeLength(piecelen), coord.y);

                wasteDrawings.Add(new WasteDrawing(verticalPoint, verticalLength, verticalWidth));
            }

            if (tree.Width > piecewid)
            {
                float horizontalWidth = GetRelativeWidth(tree.Width - piecewid);
                float horizontalLength = GetRelativeLength(tree.Length) - verticalLength;
                (float, float) horizontalPoint = (coord.x, coord.y + GetRelativeWidth(piecewid));

                wasteDrawings.Add(new WasteDrawing(horizontalPoint, horizontalLength, horizontalWidth));
            }
        }

        private void UpdateAspectRatio()
        {
            int pbHeight = initial_pb_Height;
            int pbWidth = initial_pb_Width;
            Point initPos;

            double stockAspectRatio = (double)stockLength / stockWidth;

            if (stockAspectRatio < pbAspectRatio)
            {
                pbWidth = (int)((double)pbHeight * (double)stockLength / (double)stockWidth);
                initPos = new Point(initial_pb_pos.X + ((initial_pb_Width - pbWidth) / 2), initial_pb_pos.Y);
            }
            else if (stockAspectRatio > pbAspectRatio)
            {
                pbHeight = (int)((double)pbWidth * (double)stockWidth / (double)stockLength);
                initPos = new Point(initial_pb_pos.X, initial_pb_pos.Y + ((initial_pb_Height - pbHeight) / 2));
            }
            else
            {
                initPos = initial_pb_pos;
            }

            pictureBox_sol.Height = pbHeight;
            pictureBox_sol.Width = pbWidth;
            pictureBox_sol.Location = initPos;

            ShowSolution();
        }

        private void PaintPiece(PieceDrawing piece, Graphics graphics)
        {
            RectangleF rect = new RectangleF(piece.InitCoordinates, piece.Size);
            graphics.FillRectangle(new SolidBrush(pieceColors[piece.Index]), rect);

            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            if (paint_piece_name)
            {
                float minSize = Math.Min(Math.Min(piece.Size.Height, piece.Size.Width) - 7, 30);
                if (minSize > 7)
                {
                    Font font = new Font("Arial", minSize, FontStyle.Bold, GraphicsUnit.Pixel);
                    graphics.DrawString(piece.Name, font, pieceNameBrush, rect, stringFormat);
                }
            }

            graphics.DrawRectangles(piecePen, new RectangleF[] { rect });
        }

        private void PaintCut(CutDrawing piece, Graphics graphics)
        {
            graphics.DrawLine(cutPen, piece.InitCoordinates, piece.FinalCoordinates);
        }

        private void PaintWaste(WasteDrawing piece, Graphics graphics)
        {
            RectangleF rect = new RectangleF(piece.InitCoordinates, piece.Size);
            graphics.FillRectangle(wasteBrush, rect);
            graphics.DrawRectangles(wastePen, new RectangleF[] { rect });
        }

        private void SaveData()
        {
            List<PieceRecord> pieces = new List<PieceRecord>();
            for (int i = 0; i < pieceLengths.Count; i++)
            {
                PieceRecord pr = new PieceRecord();
                pr.Length = pieceLengths[i];
                pr.Width = pieceWidths[i];
                pr.Demand = pieceDemands[i];
                pieces.Add(pr);
            }
            DataRecord dr = new DataRecord();
            dr.StockLength = stockLength;
            dr.StockWidth = stockWidth;
            dr.StockCost = stockCost;
            dr.Pieces = pieces;
            string jsonObject = JsonSerializer.Serialize(dr);

            if(saveFileDialog_data.ShowDialog() == DialogResult.OK)
            {
                string file = saveFileDialog_data.FileName;
                File.WriteAllText(file, jsonObject);
            }
        }

        private void ClearDataViewGrid(DataGridView grid)
        {
            while (!grid.Rows[0].IsNewRow)
                dataGridView_Pieces.Rows.RemoveAt(0);
        }

        private void LoadData()
        {
            if(openFileDialog_data.ShowDialog() == DialogResult.OK)
            {
                string file = openFileDialog_data.FileName;
                string jsonString = File.ReadAllText(file);
                DataRecord dr = JsonSerializer.Deserialize<DataRecord>(jsonString);

                numericUpDown_LengthStock.Value = dr.StockLength;
                numericUpDown_WidthStock.Value = dr.StockWidth;
                numericUpDown_CostStock.Value = dr.StockCost;

                List<PieceRecord> pieces = dr.Pieces;

                ClearDataViewGrid(dataGridView_Pieces);

                foreach (PieceRecord piece in pieces)
                {
                    AddPieceToGrid(piece.Length, piece.Width, piece.Demand);
                }
            }
        }

        private void AddPieceToGrid(int length, int width, int demand)
        {
            dataGridView_Pieces.Rows.Add(length.ToString(), width.ToString(), demand.ToString());
        }

        private void EmptyObtainedColumn()
        {
            foreach (DataGridViewRow row in dataGridView_Pieces.Rows)
            {
                DataGridViewCellCollection line = row.Cells;
                line["ObtainedColumn"].Value = "";
            }
        }

        private void SetDefaultDimensions()
        {
            numericUpDown_CostStock.Value = 1;
            numericUpDown_LengthStock.Value = 16;
            numericUpDown_WidthStock.Value = 10;
        }

        private void ClearPieces()
        {
            ClearDataViewGrid(dataGridView_Pieces);
        }

        private void ClearPB()
        {
            pieceDrawings.Clear();
            wasteDrawings.Clear();
            cutDrawings.Clear();
            pictureBox_sol.Refresh();
        }

        private void UnlockScreen()
        {
            solution = null;
            screen_locked = false;

            numericUpDown_CostStock.ReadOnly =
                numericUpDown_LengthStock.ReadOnly =
                numericUpDown_WidthStock.ReadOnly =
                dataGridView_Pieces.ReadOnly =
                false;

            button_defaultDimensions.Enabled =
                numericUpDown_WidthStock.Enabled =
                numericUpDown_LengthStock.Enabled =
                numericUpDown_CostStock.Enabled =
                button_emptyPieces.Enabled =
                button_loadData.Enabled =
                button_start.Enabled =
                dataGridView_Pieces.Columns["ObtainedColumn"].ReadOnly =
                true;

            label_pattern.Visible =
                label_PatternRep.Visible =
                label_TotalMat.Visible =
                button_prevPattern.Enabled =
                button_nextPattern.Enabled =
                button_changeData.Enabled =
                false;

            textBox_totalMaterial.Text = "";
            textBox_PatternRep.Text = "";
            textBox_cur_pattern.Text = "";

            button_start.Text = "Calcular Solución";

            ClearPB();
            EmptyObtainedColumn();
        }

        private void LockScreen()
        {
            screen_locked = true;
            dataGridView_Pieces.ReadOnly = true;

            button_defaultDimensions.Enabled =
                numericUpDown_WidthStock.Enabled =
                numericUpDown_LengthStock.Enabled =
                numericUpDown_CostStock.Enabled =
                button_emptyPieces.Enabled =
                button_loadData.Enabled =
                button_start.Enabled =
                false;

            button_changeData.Enabled = true;
        }

        private void UpdateColors()
        {
            cutPen = new Pen(cutColor);
            wastePen = new Pen(wasteBorderColor);
            wasteBrush = new SolidBrush(wasteFillColor);
            piecePen = new Pen(pieceBorderColor);
            pieceNameBrush = new SolidBrush(pieceNameColor);
        }

        private void ShowDrawingOptions()
        {
            groupBox_Drawing.Visible = false;
            groupBox_stock.Width += groupBox_Drawing.Width + 7;
        }

        private void HideDrawingOptions()
        {
            groupBox_Drawing.Visible = true;
            groupBox_stock.Width -= groupBox_Drawing.Width + 7;
        }

        #endregion

        #region Events

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            SetRowIDs();
            CheckValidRows();
            UpdateButtonState();
        }

        private void dataGridView_Pieces_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            CheckValidRows();
            UpdateButtonState();
        }

        private void dataGridView_Pieces_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            SetRowIDs();
            CheckValidRows();
            UpdateButtonState();
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            LockScreen();
            Solve();
        }

        private void button_changeData_Click(object sender, EventArgs e)
        {
            UnlockScreen();
        }

        private void numericUpDown_WidthStock_ValueChanged(object sender, EventArgs e)
        {
            stockWidth = (int)numericUpDown_WidthStock.Value;
            UpdateAspectRatio();
        }

        private void numericUpDown_LengthStock_ValueChanged(object sender, EventArgs e)
        {
            stockLength = (int)numericUpDown_LengthStock.Value;
            UpdateAspectRatio();
        }

        private void numericUpDown_CostStock_ValueChanged(object sender, EventArgs e)
        {
            stockCost = (int)numericUpDown_CostStock.Value;
        }

        private void button_nextPattern_Click(object sender, EventArgs e)
        {
            actual_solution_index++;
            ShowSolution();
        }

        private void button_prevPattern_Click(object sender, EventArgs e)
        {
            actual_solution_index--;
            ShowSolution();
        }

        private void pictureBox_sol_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            if (paint_cuts)
                foreach (CutDrawing cut in cutDrawings)
                    PaintCut(cut, graphics);

            if (paint_waste)
                foreach (WasteDrawing waste in wasteDrawings)
                    PaintWaste(waste, graphics);

            if (paint_pieces)
                foreach (PieceDrawing piece in pieceDrawings)
                    PaintPiece(piece, graphics);
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            
        }

        private void panel_pb_SizeChanged(object sender, EventArgs e)
        {
            ResizePB();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string name = e.ClickedItem.Name;

            if(name == "button_Clear")
            {
                UnlockScreen();
                ClearPieces();
                SetDefaultDimensions();
            }
            else if(name == "button_loadData")
            {
                LoadData();
            }
            else if (name == "button_saveData")
            {
                SaveData();
            }
            else if (name == "button_defaultDimensions")
            {
                SetDefaultDimensions();
            }
            else if (name == "button_emptyPieces")
            {
                ClearPieces();
            }
            else if (name == "toolStripButton_drawingOptions")
            {
                bool check = toolStripButton_drawingOptions.Checked = !toolStripButton_drawingOptions.Checked;
                if (!check)
                    ShowDrawingOptions();
                else
                    HideDrawingOptions();
            }
        }

        private void panel_cutColor_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color color = colorDialog1.Color;
                panel_cutColor.BackColor = color;
                cutColor = color;
                UpdateColors();
                ShowSolution();
            }
        }

        private void panel_WasteBorderColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color color = colorDialog1.Color;
                panel_WasteBorderColor.BackColor = color;
                wasteBorderColor = color;
                UpdateColors();
                ShowSolution();
            }
        }

        private void panel_WasteFillColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color color = colorDialog1.Color;
                panel_WasteFillColor.BackColor = color;
                wasteFillColor = color;
                UpdateColors();
                ShowSolution();
            }
        }

        private void panel_PieceBorderColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color color = colorDialog1.Color;
                panel_PieceBorderColor.BackColor = color;
                pieceBorderColor = color;
                UpdateColors();
                ShowSolution();
            }
        }

        private void panel_NumberColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color color = colorDialog1.Color;
                panel_NumberColor.BackColor = color;
                pieceNameColor = color;
                UpdateColors();
                ShowSolution();
            }
        }

        private void checkBox_cuts_CheckedChanged(object sender, EventArgs e)
        {
            paint_cuts = checkBox_cuts.Checked;
            ShowSolution();
        }

        private void checkBox_wastes_CheckedChanged(object sender, EventArgs e)
        {
            paint_waste = checkBox_wastes.Checked;
            ShowSolution();
        }

        private void checkBox_pieces_CheckedChanged(object sender, EventArgs e)
        {
            checkBox_pieceNumber.Enabled = paint_pieces = checkBox_pieces.Checked;
            ShowSolution();
        }

        private void checkBox_pieceNumber_CheckedChanged(object sender, EventArgs e)
        {
            paint_piece_name = checkBox_pieceNumber.Checked;
            ShowSolution();
        }

        #endregion
    }

    #region Classes

    class PatternDrawing
    {
        public PointF InitCoordinates { get; }

        public PatternDrawing((float x, float y) coor)
        {
            InitCoordinates = new PointF(coor.x, coor.y);
        }
    }

    class WasteDrawing : PatternDrawing
    {
        public SizeF Size { get; }

        public WasteDrawing((float, float) coord, float length, float width) : base(coord)
        {
            Size = new SizeF(length, width);
        }
    }

    class PieceDrawing : WasteDrawing
    {
        public string Name { get; }

        public int Index { get; }

        public PieceDrawing((float, float) coord, float length, float width, int index) : base(coord, length, width)
        {
            Name = (index + 1).ToString();
            Index = index;
        }
    }

    class CutDrawing : PatternDrawing
    {
        public PointF FinalCoordinates { get; }

        public CutDrawing((float, float) initCoord, (float x, float y) finalCoord) : base(initCoord)
        {
            FinalCoordinates = new PointF(finalCoord.x, finalCoord.y);
        }
    }

    class DataRecord
    {
        public int StockLength { get; set; }
        public int StockWidth { get; set; }
        public int StockCost { get; set; }
        public List<PieceRecord> Pieces { get; set; }
    }

    class PieceRecord
    {
        public int Length { get; set; }
        public int Width { get; set; }
        public int Demand { get; set; }
    }

    class PieceColors
    {
        List<Color> presetColors;

        List<Color> allColors;

        public PieceColors()
        {
            presetColors = new List<Color>();

            presetColors.Add(Color.PowderBlue);
            presetColors.Add(Color.SteelBlue);
            presetColors.Add(Color.DarkSalmon);
            presetColors.Add(Color.DarkKhaki);
            presetColors.Add(Color.Goldenrod);
            presetColors.Add(Color.IndianRed);
            presetColors.Add(Color.LightGoldenrodYellow);
            presetColors.Add(Color.MediumSeaGreen);
            presetColors.Add(Color.Plum);
            presetColors.Add(Color.Teal);
            presetColors.Add(Color.LimeGreen);
            presetColors.Add(Color.Purple);
            presetColors.Add(Color.NavajoWhite);

            allColors = new List<Color>();

            foreach (PropertyInfo prop in typeof(Color).GetProperties())
            {
                if (prop.PropertyType.FullName == "System.Drawing.Color" && prop.Name != "Transparent")
                {
                    Color color = Color.FromName(prop.Name);
                    if (!presetColors.Contains(color))
                        allColors.Add(color);
                }
            }
        }

        public Color this[int index]
        {
            get
            {
                while(index >= presetColors.Count)
                    AddRandomColor();
                return presetColors[index];
            }
        }

        void AddRandomColor()
        {
            if (allColors.Count == 0)
                presetColors.Add(Color.White);
            else
            {
                Random a = new Random();
                int index = a.Next(allColors.Count);
                presetColors.Add(allColors[index]);
                allColors.RemoveAt(index);
            }
        }
    }

    #endregion
}
