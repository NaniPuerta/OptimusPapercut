namespace ProyectoModelosII
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox_dataEntry = new System.Windows.Forms.GroupBox();
            this.groupBox_Drawing = new System.Windows.Forms.GroupBox();
            this.label_wasteFill = new System.Windows.Forms.Label();
            this.panel_NumberColor = new System.Windows.Forms.Panel();
            this.panel_PieceBorderColor = new System.Windows.Forms.Panel();
            this.panel_WasteFillColor = new System.Windows.Forms.Panel();
            this.panel_WasteBorderColor = new System.Windows.Forms.Panel();
            this.panel_cutColor = new System.Windows.Forms.Panel();
            this.checkBox_pieces = new System.Windows.Forms.CheckBox();
            this.checkBox_wastes = new System.Windows.Forms.CheckBox();
            this.checkBox_cuts = new System.Windows.Forms.CheckBox();
            this.checkBox_pieceNumber = new System.Windows.Forms.CheckBox();
            this.button_start = new System.Windows.Forms.Button();
            this.groupBox_Pieces = new System.Windows.Forms.GroupBox();
            this.dataGridView_Pieces = new System.Windows.Forms.DataGridView();
            this.LengthColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WidthColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DemandColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ObtainedColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox_stock = new System.Windows.Forms.GroupBox();
            this.groupBox_Dimensions = new System.Windows.Forms.GroupBox();
            this.panel_image = new System.Windows.Forms.Panel();
            this.label_Width = new System.Windows.Forms.Label();
            this.label_Length = new System.Windows.Forms.Label();
            this.numericUpDown_LengthStock = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_WidthStock = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown_CostStock = new System.Windows.Forms.NumericUpDown();
            this.button_changeData = new System.Windows.Forms.Button();
            this.Length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Width = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Demand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox_sol = new System.Windows.Forms.PictureBox();
            this.label_pattern = new System.Windows.Forms.Label();
            this.button_prevPattern = new System.Windows.Forms.Button();
            this.button_nextPattern = new System.Windows.Forms.Button();
            this.groupBox_Solution = new System.Windows.Forms.GroupBox();
            this.progressBar_calculating = new System.Windows.Forms.ProgressBar();
            this.textBox_totalMaterial = new System.Windows.Forms.Label();
            this.textBox_PatternRep = new System.Windows.Forms.Label();
            this.label_TotalMat = new System.Windows.Forms.Label();
            this.label_PatternRep = new System.Windows.Forms.Label();
            this.panel_pb = new System.Windows.Forms.Panel();
            this.textBox_cur_pattern = new System.Windows.Forms.Label();
            this.openFileDialog_data = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog_data = new System.Windows.Forms.SaveFileDialog();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.button_Clear = new System.Windows.Forms.ToolStripButton();
            this.button_loadData = new System.Windows.Forms.ToolStripButton();
            this.button_saveData = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_drawingOptions = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.button_defaultDimensions = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.button_emptyPieces = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.groupBox_dataEntry.SuspendLayout();
            this.groupBox_Drawing.SuspendLayout();
            this.groupBox_Pieces.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Pieces)).BeginInit();
            this.groupBox_stock.SuspendLayout();
            this.groupBox_Dimensions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_LengthStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_WidthStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_CostStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_sol)).BeginInit();
            this.groupBox_Solution.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_dataEntry
            // 
            this.groupBox_dataEntry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox_dataEntry.Controls.Add(this.groupBox_Drawing);
            this.groupBox_dataEntry.Controls.Add(this.button_start);
            this.groupBox_dataEntry.Controls.Add(this.groupBox_Pieces);
            this.groupBox_dataEntry.Controls.Add(this.groupBox_stock);
            this.groupBox_dataEntry.Controls.Add(this.button_changeData);
            this.groupBox_dataEntry.Location = new System.Drawing.Point(3, 26);
            this.groupBox_dataEntry.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox_dataEntry.Name = "groupBox_dataEntry";
            this.groupBox_dataEntry.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox_dataEntry.Size = new System.Drawing.Size(371, 748);
            this.groupBox_dataEntry.TabIndex = 0;
            this.groupBox_dataEntry.TabStop = false;
            this.groupBox_dataEntry.Text = "Entrada de datos";
            // 
            // groupBox_Drawing
            // 
            this.groupBox_Drawing.Controls.Add(this.label_wasteFill);
            this.groupBox_Drawing.Controls.Add(this.panel_NumberColor);
            this.groupBox_Drawing.Controls.Add(this.panel_PieceBorderColor);
            this.groupBox_Drawing.Controls.Add(this.panel_WasteFillColor);
            this.groupBox_Drawing.Controls.Add(this.panel_WasteBorderColor);
            this.groupBox_Drawing.Controls.Add(this.panel_cutColor);
            this.groupBox_Drawing.Controls.Add(this.checkBox_pieces);
            this.groupBox_Drawing.Controls.Add(this.checkBox_wastes);
            this.groupBox_Drawing.Controls.Add(this.checkBox_cuts);
            this.groupBox_Drawing.Controls.Add(this.checkBox_pieceNumber);
            this.groupBox_Drawing.Location = new System.Drawing.Point(228, 18);
            this.groupBox_Drawing.Name = "groupBox_Drawing";
            this.groupBox_Drawing.Size = new System.Drawing.Size(136, 196);
            this.groupBox_Drawing.TabIndex = 4;
            this.groupBox_Drawing.TabStop = false;
            this.groupBox_Drawing.Text = "Dibujo";
            // 
            // label_wasteFill
            // 
            this.label_wasteFill.AutoSize = true;
            this.label_wasteFill.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_wasteFill.Location = new System.Drawing.Point(29, 99);
            this.label_wasteFill.Name = "label_wasteFill";
            this.label_wasteFill.Size = new System.Drawing.Size(54, 15);
            this.label_wasteFill.TabIndex = 1;
            this.label_wasteFill.Text = "- Relleno";
            // 
            // panel_NumberColor
            // 
            this.panel_NumberColor.BackColor = System.Drawing.Color.Black;
            this.panel_NumberColor.Location = new System.Drawing.Point(96, 159);
            this.panel_NumberColor.Name = "panel_NumberColor";
            this.panel_NumberColor.Size = new System.Drawing.Size(19, 19);
            this.panel_NumberColor.TabIndex = 1;
            this.panel_NumberColor.Click += new System.EventHandler(this.panel_NumberColor_Click);
            // 
            // panel_PieceBorderColor
            // 
            this.panel_PieceBorderColor.BackColor = System.Drawing.Color.Black;
            this.panel_PieceBorderColor.Location = new System.Drawing.Point(74, 134);
            this.panel_PieceBorderColor.Name = "panel_PieceBorderColor";
            this.panel_PieceBorderColor.Size = new System.Drawing.Size(19, 19);
            this.panel_PieceBorderColor.TabIndex = 1;
            this.panel_PieceBorderColor.Click += new System.EventHandler(this.panel_PieceBorderColor_Click);
            // 
            // panel_WasteFillColor
            // 
            this.panel_WasteFillColor.BackColor = System.Drawing.Color.DarkGray;
            this.panel_WasteFillColor.Location = new System.Drawing.Point(84, 97);
            this.panel_WasteFillColor.Name = "panel_WasteFillColor";
            this.panel_WasteFillColor.Size = new System.Drawing.Size(19, 19);
            this.panel_WasteFillColor.TabIndex = 1;
            this.panel_WasteFillColor.Click += new System.EventHandler(this.panel_WasteFillColor_Click);
            // 
            // panel_WasteBorderColor
            // 
            this.panel_WasteBorderColor.BackColor = System.Drawing.Color.DarkGray;
            this.panel_WasteBorderColor.Location = new System.Drawing.Point(107, 71);
            this.panel_WasteBorderColor.Name = "panel_WasteBorderColor";
            this.panel_WasteBorderColor.Size = new System.Drawing.Size(19, 19);
            this.panel_WasteBorderColor.TabIndex = 1;
            this.panel_WasteBorderColor.Click += new System.EventHandler(this.panel_WasteBorderColor_Click);
            // 
            // panel_cutColor
            // 
            this.panel_cutColor.BackColor = System.Drawing.Color.Black;
            this.panel_cutColor.Location = new System.Drawing.Point(77, 33);
            this.panel_cutColor.Name = "panel_cutColor";
            this.panel_cutColor.Size = new System.Drawing.Size(19, 19);
            this.panel_cutColor.TabIndex = 1;
            this.panel_cutColor.Click += new System.EventHandler(this.panel_cutColor_Click);
            // 
            // checkBox_pieces
            // 
            this.checkBox_pieces.AutoSize = true;
            this.checkBox_pieces.Checked = true;
            this.checkBox_pieces.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_pieces.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBox_pieces.Location = new System.Drawing.Point(9, 132);
            this.checkBox_pieces.Name = "checkBox_pieces";
            this.checkBox_pieces.Size = new System.Drawing.Size(68, 23);
            this.checkBox_pieces.TabIndex = 0;
            this.checkBox_pieces.Text = "Piezas";
            this.checkBox_pieces.UseVisualStyleBackColor = true;
            this.checkBox_pieces.CheckedChanged += new System.EventHandler(this.checkBox_pieces_CheckedChanged);
            // 
            // checkBox_wastes
            // 
            this.checkBox_wastes.AutoSize = true;
            this.checkBox_wastes.Checked = true;
            this.checkBox_wastes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_wastes.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBox_wastes.Location = new System.Drawing.Point(9, 70);
            this.checkBox_wastes.Name = "checkBox_wastes";
            this.checkBox_wastes.Size = new System.Drawing.Size(102, 23);
            this.checkBox_wastes.TabIndex = 0;
            this.checkBox_wastes.Text = "Desperdicio";
            this.checkBox_wastes.UseVisualStyleBackColor = true;
            this.checkBox_wastes.CheckedChanged += new System.EventHandler(this.checkBox_wastes_CheckedChanged);
            // 
            // checkBox_cuts
            // 
            this.checkBox_cuts.AutoSize = true;
            this.checkBox_cuts.Checked = true;
            this.checkBox_cuts.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_cuts.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBox_cuts.Location = new System.Drawing.Point(9, 31);
            this.checkBox_cuts.Name = "checkBox_cuts";
            this.checkBox_cuts.Size = new System.Drawing.Size(71, 23);
            this.checkBox_cuts.TabIndex = 0;
            this.checkBox_cuts.Text = "Cortes";
            this.checkBox_cuts.UseVisualStyleBackColor = true;
            this.checkBox_cuts.CheckedChanged += new System.EventHandler(this.checkBox_cuts_CheckedChanged);
            // 
            // checkBox_pieceNumber
            // 
            this.checkBox_pieceNumber.AutoSize = true;
            this.checkBox_pieceNumber.Checked = true;
            this.checkBox_pieceNumber.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_pieceNumber.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBox_pieceNumber.Location = new System.Drawing.Point(25, 159);
            this.checkBox_pieceNumber.Name = "checkBox_pieceNumber";
            this.checkBox_pieceNumber.Size = new System.Drawing.Size(73, 19);
            this.checkBox_pieceNumber.TabIndex = 0;
            this.checkBox_pieceNumber.Text = "Número";
            this.checkBox_pieceNumber.UseVisualStyleBackColor = true;
            this.checkBox_pieceNumber.CheckedChanged += new System.EventHandler(this.checkBox_pieceNumber_CheckedChanged);
            // 
            // button_start
            // 
            this.button_start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_start.BackColor = System.Drawing.Color.White;
            this.button_start.Cursor = System.Windows.Forms.Cursors.Default;
            this.button_start.Enabled = false;
            this.button_start.FlatAppearance.BorderSize = 0;
            this.button_start.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button_start.Location = new System.Drawing.Point(185, 701);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(179, 39);
            this.button_start.TabIndex = 1;
            this.button_start.Text = "Calcular Solución";
            this.button_start.UseVisualStyleBackColor = false;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // groupBox_Pieces
            // 
            this.groupBox_Pieces.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox_Pieces.Controls.Add(this.dataGridView_Pieces);
            this.groupBox_Pieces.Location = new System.Drawing.Point(6, 213);
            this.groupBox_Pieces.Name = "groupBox_Pieces";
            this.groupBox_Pieces.Size = new System.Drawing.Size(358, 481);
            this.groupBox_Pieces.TabIndex = 3;
            this.groupBox_Pieces.TabStop = false;
            this.groupBox_Pieces.Text = "Piezas";
            // 
            // dataGridView_Pieces
            // 
            this.dataGridView_Pieces.AllowUserToResizeColumns = false;
            this.dataGridView_Pieces.AllowUserToResizeRows = false;
            this.dataGridView_Pieces.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView_Pieces.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView_Pieces.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_Pieces.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dataGridView_Pieces.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Pieces.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LengthColumn,
            this.WidthColumn,
            this.DemandColumn,
            this.ObtainedColumn});
            this.dataGridView_Pieces.Location = new System.Drawing.Point(7, 23);
            this.dataGridView_Pieces.Name = "dataGridView_Pieces";
            this.dataGridView_Pieces.RowHeadersWidth = 56;
            this.dataGridView_Pieces.Size = new System.Drawing.Size(340, 452);
            this.dataGridView_Pieces.TabIndex = 5;
            this.dataGridView_Pieces.Text = "dataGridView1";
            this.dataGridView_Pieces.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Pieces_CellValueChanged);
            this.dataGridView_Pieces.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView1_RowsAdded);
            this.dataGridView_Pieces.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridView_Pieces_RowsRemoved);
            // 
            // LengthColumn
            // 
            this.LengthColumn.HeaderText = "Largo";
            this.LengthColumn.MinimumWidth = 6;
            this.LengthColumn.Name = "LengthColumn";
            this.LengthColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.LengthColumn.Width = 63;
            // 
            // WidthColumn
            // 
            this.WidthColumn.HeaderText = "Ancho";
            this.WidthColumn.MinimumWidth = 6;
            this.WidthColumn.Name = "WidthColumn";
            this.WidthColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.WidthColumn.Width = 63;
            // 
            // DemandColumn
            // 
            this.DemandColumn.HeaderText = "Pedido";
            this.DemandColumn.MinimumWidth = 6;
            this.DemandColumn.Name = "DemandColumn";
            this.DemandColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DemandColumn.Width = 63;
            // 
            // ObtainedColumn
            // 
            this.ObtainedColumn.HeaderText = "Obtenido";
            this.ObtainedColumn.MinimumWidth = 6;
            this.ObtainedColumn.Name = "ObtainedColumn";
            this.ObtainedColumn.ReadOnly = true;
            this.ObtainedColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ObtainedColumn.Width = 73;
            // 
            // groupBox_stock
            // 
            this.groupBox_stock.Controls.Add(this.groupBox_Dimensions);
            this.groupBox_stock.Controls.Add(this.label2);
            this.groupBox_stock.Controls.Add(this.numericUpDown_CostStock);
            this.groupBox_stock.Location = new System.Drawing.Point(6, 18);
            this.groupBox_stock.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox_stock.Name = "groupBox_stock";
            this.groupBox_stock.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox_stock.Size = new System.Drawing.Size(215, 196);
            this.groupBox_stock.TabIndex = 2;
            this.groupBox_stock.TabStop = false;
            this.groupBox_stock.Text = "Material";
            // 
            // groupBox_Dimensions
            // 
            this.groupBox_Dimensions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_Dimensions.Controls.Add(this.panel_image);
            this.groupBox_Dimensions.Controls.Add(this.label_Width);
            this.groupBox_Dimensions.Controls.Add(this.label_Length);
            this.groupBox_Dimensions.Controls.Add(this.numericUpDown_LengthStock);
            this.groupBox_Dimensions.Controls.Add(this.numericUpDown_WidthStock);
            this.groupBox_Dimensions.Location = new System.Drawing.Point(6, 18);
            this.groupBox_Dimensions.Name = "groupBox_Dimensions";
            this.groupBox_Dimensions.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox_Dimensions.Size = new System.Drawing.Size(203, 130);
            this.groupBox_Dimensions.TabIndex = 1;
            this.groupBox_Dimensions.TabStop = false;
            this.groupBox_Dimensions.Text = "Dimensiones";
            // 
            // panel_image
            // 
            this.panel_image.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel_image.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel_image.BackgroundImage")));
            this.panel_image.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_image.Location = new System.Drawing.Point(43, 28);
            this.panel_image.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel_image.Name = "panel_image";
            this.panel_image.Size = new System.Drawing.Size(79, 52);
            this.panel_image.TabIndex = 3;
            // 
            // label_Width
            // 
            this.label_Width.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label_Width.AutoSize = true;
            this.label_Width.Location = new System.Drawing.Point(124, 21);
            this.label_Width.Name = "label_Width";
            this.label_Width.Size = new System.Drawing.Size(51, 20);
            this.label_Width.TabIndex = 1;
            this.label_Width.Text = "Ancho";
            // 
            // label_Length
            // 
            this.label_Length.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label_Length.AutoSize = true;
            this.label_Length.Location = new System.Drawing.Point(6, 87);
            this.label_Length.Name = "label_Length";
            this.label_Length.Size = new System.Drawing.Size(47, 20);
            this.label_Length.TabIndex = 1;
            this.label_Length.Text = "Largo";
            // 
            // numericUpDown_LengthStock
            // 
            this.numericUpDown_LengthStock.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.numericUpDown_LengthStock.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown_LengthStock.Location = new System.Drawing.Point(54, 87);
            this.numericUpDown_LengthStock.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numericUpDown_LengthStock.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericUpDown_LengthStock.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_LengthStock.Name = "numericUpDown_LengthStock";
            this.numericUpDown_LengthStock.Size = new System.Drawing.Size(65, 23);
            this.numericUpDown_LengthStock.TabIndex = 0;
            this.numericUpDown_LengthStock.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numericUpDown_LengthStock.ValueChanged += new System.EventHandler(this.numericUpDown_LengthStock_ValueChanged);
            // 
            // numericUpDown_WidthStock
            // 
            this.numericUpDown_WidthStock.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.numericUpDown_WidthStock.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown_WidthStock.Location = new System.Drawing.Point(128, 42);
            this.numericUpDown_WidthStock.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numericUpDown_WidthStock.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericUpDown_WidthStock.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_WidthStock.Name = "numericUpDown_WidthStock";
            this.numericUpDown_WidthStock.Size = new System.Drawing.Size(65, 23);
            this.numericUpDown_WidthStock.TabIndex = 0;
            this.numericUpDown_WidthStock.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_WidthStock.ValueChanged += new System.EventHandler(this.numericUpDown_WidthStock_ValueChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.Location = new System.Drawing.Point(11, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Costo por unidad";
            // 
            // numericUpDown_CostStock
            // 
            this.numericUpDown_CostStock.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.numericUpDown_CostStock.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown_CostStock.Location = new System.Drawing.Point(138, 162);
            this.numericUpDown_CostStock.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numericUpDown_CostStock.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericUpDown_CostStock.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_CostStock.Name = "numericUpDown_CostStock";
            this.numericUpDown_CostStock.Size = new System.Drawing.Size(65, 23);
            this.numericUpDown_CostStock.TabIndex = 0;
            this.numericUpDown_CostStock.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_CostStock.ValueChanged += new System.EventHandler(this.numericUpDown_CostStock_ValueChanged);
            // 
            // button_changeData
            // 
            this.button_changeData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_changeData.BackColor = System.Drawing.Color.White;
            this.button_changeData.Cursor = System.Windows.Forms.Cursors.Default;
            this.button_changeData.Enabled = false;
            this.button_changeData.FlatAppearance.BorderSize = 0;
            this.button_changeData.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button_changeData.Location = new System.Drawing.Point(6, 701);
            this.button_changeData.Name = "button_changeData";
            this.button_changeData.Size = new System.Drawing.Size(162, 39);
            this.button_changeData.TabIndex = 1;
            this.button_changeData.Text = "Cambiar Datos";
            this.button_changeData.UseVisualStyleBackColor = false;
            this.button_changeData.Click += new System.EventHandler(this.button_changeData_Click);
            // 
            // Length
            // 
            this.Length.HeaderText = "Largo";
            this.Length.MinimumWidth = 6;
            this.Length.Name = "Length";
            this.Length.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Length.Width = 63;
            // 
            // Width
            // 
            this.Width.HeaderText = "Ancho";
            this.Width.MinimumWidth = 6;
            this.Width.Name = "Width";
            this.Width.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Width.Width = 63;
            // 
            // Demand
            // 
            this.Demand.HeaderText = "Pedido";
            this.Demand.MinimumWidth = 6;
            this.Demand.Name = "Demand";
            this.Demand.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Demand.Width = 63;
            // 
            // pictureBox_sol
            // 
            this.pictureBox_sol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_sol.Location = new System.Drawing.Point(9, 26);
            this.pictureBox_sol.Name = "pictureBox_sol";
            this.pictureBox_sol.Size = new System.Drawing.Size(1064, 665);
            this.pictureBox_sol.TabIndex = 1;
            this.pictureBox_sol.TabStop = false;
            this.pictureBox_sol.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_sol_Paint);
            // 
            // label_pattern
            // 
            this.label_pattern.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label_pattern.AutoSize = true;
            this.label_pattern.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_pattern.Location = new System.Drawing.Point(338, 708);
            this.label_pattern.Name = "label_pattern";
            this.label_pattern.Size = new System.Drawing.Size(63, 25);
            this.label_pattern.TabIndex = 2;
            this.label_pattern.Text = "Patrón";
            this.label_pattern.Visible = false;
            // 
            // button_prevPattern
            // 
            this.button_prevPattern.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button_prevPattern.BackColor = System.Drawing.SystemColors.Control;
            this.button_prevPattern.Enabled = false;
            this.button_prevPattern.FlatAppearance.BorderSize = 0;
            this.button_prevPattern.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_prevPattern.Font = new System.Drawing.Font("Arial Narrow", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_prevPattern.Location = new System.Drawing.Point(304, 701);
            this.button_prevPattern.Name = "button_prevPattern";
            this.button_prevPattern.Size = new System.Drawing.Size(41, 39);
            this.button_prevPattern.TabIndex = 3;
            this.button_prevPattern.Text = "◄";
            this.button_prevPattern.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_prevPattern.UseVisualStyleBackColor = false;
            this.button_prevPattern.LocationChanged += new System.EventHandler(this.button_prevPattern_LocationChanged);
            this.button_prevPattern.Click += new System.EventHandler(this.button_prevPattern_Click);
            // 
            // button_nextPattern
            // 
            this.button_nextPattern.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button_nextPattern.BackColor = System.Drawing.SystemColors.Control;
            this.button_nextPattern.Enabled = false;
            this.button_nextPattern.FlatAppearance.BorderSize = 0;
            this.button_nextPattern.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_nextPattern.Font = new System.Drawing.Font("Arial Narrow", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_nextPattern.Location = new System.Drawing.Point(463, 701);
            this.button_nextPattern.Name = "button_nextPattern";
            this.button_nextPattern.Size = new System.Drawing.Size(41, 39);
            this.button_nextPattern.TabIndex = 3;
            this.button_nextPattern.Text = "►";
            this.button_nextPattern.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_nextPattern.UseVisualStyleBackColor = false;
            this.button_nextPattern.Click += new System.EventHandler(this.button_nextPattern_Click);
            // 
            // groupBox_Solution
            // 
            this.groupBox_Solution.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_Solution.Controls.Add(this.progressBar_calculating);
            this.groupBox_Solution.Controls.Add(this.textBox_totalMaterial);
            this.groupBox_Solution.Controls.Add(this.textBox_PatternRep);
            this.groupBox_Solution.Controls.Add(this.label_TotalMat);
            this.groupBox_Solution.Controls.Add(this.label_PatternRep);
            this.groupBox_Solution.Controls.Add(this.pictureBox_sol);
            this.groupBox_Solution.Controls.Add(this.button_nextPattern);
            this.groupBox_Solution.Controls.Add(this.button_prevPattern);
            this.groupBox_Solution.Controls.Add(this.panel_pb);
            this.groupBox_Solution.Controls.Add(this.textBox_cur_pattern);
            this.groupBox_Solution.Controls.Add(this.label_pattern);
            this.groupBox_Solution.Location = new System.Drawing.Point(387, 26);
            this.groupBox_Solution.Name = "groupBox_Solution";
            this.groupBox_Solution.Size = new System.Drawing.Size(1081, 748);
            this.groupBox_Solution.TabIndex = 5;
            this.groupBox_Solution.TabStop = false;
            this.groupBox_Solution.Text = "Patrones de corte";
            // 
            // progressBar_calculating
            // 
            this.progressBar_calculating.Location = new System.Drawing.Point(9, 701);
            this.progressBar_calculating.Name = "progressBar_calculating";
            this.progressBar_calculating.Size = new System.Drawing.Size(289, 37);
            this.progressBar_calculating.TabIndex = 7;
            this.progressBar_calculating.Visible = false;
            this.progressBar_calculating.TabIndexChanged += new System.EventHandler(this.progressBar_calculating_TabIndexChanged);
            // 
            // textBox_totalMaterial
            // 
            this.textBox_totalMaterial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_totalMaterial.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_totalMaterial.Location = new System.Drawing.Point(1012, 718);
            this.textBox_totalMaterial.Name = "textBox_totalMaterial";
            this.textBox_totalMaterial.Size = new System.Drawing.Size(65, 20);
            this.textBox_totalMaterial.TabIndex = 5;
            this.textBox_totalMaterial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_PatternRep
            // 
            this.textBox_PatternRep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_PatternRep.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_PatternRep.Location = new System.Drawing.Point(1012, 693);
            this.textBox_PatternRep.Name = "textBox_PatternRep";
            this.textBox_PatternRep.Size = new System.Drawing.Size(65, 20);
            this.textBox_PatternRep.TabIndex = 5;
            this.textBox_PatternRep.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_TotalMat
            // 
            this.label_TotalMat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label_TotalMat.AutoSize = true;
            this.label_TotalMat.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_TotalMat.Location = new System.Drawing.Point(791, 718);
            this.label_TotalMat.Name = "label_TotalMat";
            this.label_TotalMat.Size = new System.Drawing.Size(225, 25);
            this.label_TotalMat.TabIndex = 2;
            this.label_TotalMat.Text = "Total de Material necesario:";
            this.label_TotalMat.Visible = false;
            // 
            // label_PatternRep
            // 
            this.label_PatternRep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label_PatternRep.AutoSize = true;
            this.label_PatternRep.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_PatternRep.Location = new System.Drawing.Point(814, 693);
            this.label_PatternRep.Name = "label_PatternRep";
            this.label_PatternRep.Size = new System.Drawing.Size(202, 25);
            this.label_PatternRep.TabIndex = 2;
            this.label_PatternRep.Text = "Repeticiones del patrón:";
            this.label_PatternRep.Visible = false;
            // 
            // panel_pb
            // 
            this.panel_pb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_pb.BackColor = System.Drawing.Color.Transparent;
            this.panel_pb.Location = new System.Drawing.Point(9, 26);
            this.panel_pb.Name = "panel_pb";
            this.panel_pb.Size = new System.Drawing.Size(1064, 665);
            this.panel_pb.TabIndex = 6;
            this.panel_pb.SizeChanged += new System.EventHandler(this.panel_pb_SizeChanged);
            // 
            // textBox_cur_pattern
            // 
            this.textBox_cur_pattern.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.textBox_cur_pattern.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_cur_pattern.Location = new System.Drawing.Point(402, 708);
            this.textBox_cur_pattern.Name = "textBox_cur_pattern";
            this.textBox_cur_pattern.Size = new System.Drawing.Size(65, 20);
            this.textBox_cur_pattern.TabIndex = 5;
            this.textBox_cur_pattern.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // openFileDialog_data
            // 
            this.openFileDialog_data.DefaultExt = "json";
            this.openFileDialog_data.Filter = "JSON Files|*.json";
            // 
            // saveFileDialog_data
            // 
            this.saveFileDialog_data.DefaultExt = "json";
            this.saveFileDialog_data.Filter = "JSON Files|*.json";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(156, 24);
            this.toolStripMenuItem1.Text = "toolStripMenuItem1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.button_Clear,
            this.button_loadData,
            this.button_saveData,
            this.toolStripSeparator3,
            this.toolStripButton_drawingOptions,
            this.toolStripSeparator,
            this.button_defaultDimensions,
            this.toolStripSeparator1,
            this.button_emptyPieces,
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1476, 27);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // button_Clear
            // 
            this.button_Clear.Image = ((System.Drawing.Image)(resources.GetObject("button_Clear.Image")));
            this.button_Clear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.button_Clear.Name = "button_Clear";
            this.button_Clear.Size = new System.Drawing.Size(76, 24);
            this.button_Clear.Text = "&Nuevo";
            // 
            // button_loadData
            // 
            this.button_loadData.Image = ((System.Drawing.Image)(resources.GetObject("button_loadData.Image")));
            this.button_loadData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.button_loadData.Name = "button_loadData";
            this.button_loadData.Size = new System.Drawing.Size(120, 24);
            this.button_loadData.Text = "&Cargar Datos";
            // 
            // button_saveData
            // 
            this.button_saveData.Image = ((System.Drawing.Image)(resources.GetObject("button_saveData.Image")));
            this.button_saveData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.button_saveData.Name = "button_saveData";
            this.button_saveData.Size = new System.Drawing.Size(129, 24);
            this.button_saveData.Text = "&Guardar Datos";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripButton_drawingOptions
            // 
            this.toolStripButton_drawingOptions.Checked = true;
            this.toolStripButton_drawingOptions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripButton_drawingOptions.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_drawingOptions.Image")));
            this.toolStripButton_drawingOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_drawingOptions.Name = "toolStripButton_drawingOptions";
            this.toolStripButton_drawingOptions.Size = new System.Drawing.Size(163, 24);
            this.toolStripButton_drawingOptions.Text = "&Opciones de dibujo";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // button_defaultDimensions
            // 
            this.button_defaultDimensions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.button_defaultDimensions.Image = ((System.Drawing.Image)(resources.GetObject("button_defaultDimensions.Image")));
            this.button_defaultDimensions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.button_defaultDimensions.Name = "button_defaultDimensions";
            this.button_defaultDimensions.Size = new System.Drawing.Size(163, 24);
            this.button_defaultDimensions.Text = "&Restablecer materiales";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // button_emptyPieces
            // 
            this.button_emptyPieces.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.button_emptyPieces.Image = ((System.Drawing.Image)(resources.GetObject("button_emptyPieces.Image")));
            this.button_emptyPieces.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.button_emptyPieces.Name = "button_emptyPieces";
            this.button_emptyPieces.Size = new System.Drawing.Size(151, 24);
            this.button_emptyPieces.Text = "&Vaciar lista de piezas";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1476, 781);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox_Solution);
            this.Controls.Add(this.groupBox_dataEntry);
            this.MinimumSize = new System.Drawing.Size(970, 450);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Optimus Papercut";
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.groupBox_dataEntry.ResumeLayout(false);
            this.groupBox_Drawing.ResumeLayout(false);
            this.groupBox_Drawing.PerformLayout();
            this.groupBox_Pieces.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Pieces)).EndInit();
            this.groupBox_stock.ResumeLayout(false);
            this.groupBox_Dimensions.ResumeLayout(false);
            this.groupBox_Dimensions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_LengthStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_WidthStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_CostStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_sol)).EndInit();
            this.groupBox_Solution.ResumeLayout(false);
            this.groupBox_Solution.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox_dataEntry;
        private System.Windows.Forms.NumericUpDown numericUpDown_WidthStock;
        private System.Windows.Forms.GroupBox groupBox_stock;
        private System.Windows.Forms.Panel panel_image;
        private System.Windows.Forms.Label label_Width;
        private System.Windows.Forms.Label label_Length;
        private System.Windows.Forms.NumericUpDown numericUpDown_LengthStock;
        private System.Windows.Forms.NumericUpDown numericUpDown_CostStock;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox_Dimensions;
        private System.Windows.Forms.GroupBox groupBox_Pieces;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.PictureBox pictureBox_sol;
        private System.Windows.Forms.Label label_pattern;
        private System.Windows.Forms.Button button_prevPattern;
        private System.Windows.Forms.Button button_nextPattern;
        private System.Windows.Forms.DataGridViewTextBoxColumn Length;
        private System.Windows.Forms.DataGridViewTextBoxColumn Width;
        private System.Windows.Forms.DataGridViewTextBoxColumn Demand;
        private System.Windows.Forms.GroupBox groupBox_Solution;
        private System.Windows.Forms.Label label_PatternRep;
        private System.Windows.Forms.DataGridView dataGridView_Pieces;
        private System.Windows.Forms.Label label_TotalMat;
        private System.Windows.Forms.OpenFileDialog openFileDialog_data;
        private System.Windows.Forms.SaveFileDialog saveFileDialog_data;
        private System.Windows.Forms.DataGridViewTextBoxColumn LengthColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn WidthColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DemandColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ObtainedColumn;
        private System.Windows.Forms.Button button_changeData;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Label textBox_cur_pattern;
        private System.Windows.Forms.Label textBox_totalMaterial;
        private System.Windows.Forms.Label textBox_PatternRep;
        private System.Windows.Forms.Panel panel_pb;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton button_Clear;
        private System.Windows.Forms.ToolStripButton button_loadData;
        private System.Windows.Forms.ToolStripButton button_saveData;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton button_defaultDimensions;
        private System.Windows.Forms.ToolStripButton button_emptyPieces;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.GroupBox groupBox_Drawing;
        private System.Windows.Forms.CheckBox checkBox_pieces;
        private System.Windows.Forms.CheckBox checkBox_wastes;
        private System.Windows.Forms.CheckBox checkBox_cuts;
        private System.Windows.Forms.Panel panel_PieceBorderColor;
        private System.Windows.Forms.Panel panel_WasteFillColor;
        private System.Windows.Forms.Panel panel_WasteBorderColor;
        private System.Windows.Forms.Panel panel_cutColor;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.CheckBox checkBox_pieceNumber;
        private System.Windows.Forms.Panel panel_NumberColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_wasteFill;
        private System.Windows.Forms.ToolStripButton toolStripButton_drawingOptions;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ProgressBar progressBar_calculating;
    }
}

