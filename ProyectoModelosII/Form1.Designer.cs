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
            this.button_saveData = new System.Windows.Forms.Button();
            this.button_loadData = new System.Windows.Forms.Button();
            this.button_Clear = new System.Windows.Forms.Button();
            this.button_start = new System.Windows.Forms.Button();
            this.groupBox_Pieces = new System.Windows.Forms.GroupBox();
            this.button_emptyPieces = new System.Windows.Forms.Button();
            this.dataGridView_Pieces = new System.Windows.Forms.DataGridView();
            this.LengthColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WidthColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DemandColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ObtainedColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox_stock = new System.Windows.Forms.GroupBox();
            this.button_defaultDimensions = new System.Windows.Forms.Button();
            this.groupBox_Dimensions = new System.Windows.Forms.GroupBox();
            this.panel_image = new System.Windows.Forms.Panel();
            this.label_Width = new System.Windows.Forms.Label();
            this.label_Length = new System.Windows.Forms.Label();
            this.numericUpDown_LengthStock = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_WidthStock = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown_CostStock = new System.Windows.Forms.NumericUpDown();
            this.Length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Width = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Demand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox_sol = new System.Windows.Forms.PictureBox();
            this.label_pattern = new System.Windows.Forms.Label();
            this.button_prevPattern = new System.Windows.Forms.Button();
            this.button_nextPattern = new System.Windows.Forms.Button();
            this.groupBox_Solution = new System.Windows.Forms.GroupBox();
            this.textBox_totalMaterial = new System.Windows.Forms.Label();
            this.textBox_PatternRep = new System.Windows.Forms.Label();
            this.textBox_cur_pattern = new System.Windows.Forms.Label();
            this.button_changeData = new System.Windows.Forms.Button();
            this.label_TotalMat = new System.Windows.Forms.Label();
            this.label_PatternRep = new System.Windows.Forms.Label();
            this.panel_pb = new System.Windows.Forms.Panel();
            this.openFileDialog_data = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog_data = new System.Windows.Forms.SaveFileDialog();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox_dataEntry.SuspendLayout();
            this.groupBox_Pieces.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Pieces)).BeginInit();
            this.groupBox_stock.SuspendLayout();
            this.groupBox_Dimensions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_LengthStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_WidthStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_CostStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_sol)).BeginInit();
            this.groupBox_Solution.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_dataEntry
            // 
            this.groupBox_dataEntry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox_dataEntry.Controls.Add(this.button_saveData);
            this.groupBox_dataEntry.Controls.Add(this.button_loadData);
            this.groupBox_dataEntry.Controls.Add(this.button_Clear);
            this.groupBox_dataEntry.Controls.Add(this.button_start);
            this.groupBox_dataEntry.Controls.Add(this.groupBox_Pieces);
            this.groupBox_dataEntry.Controls.Add(this.groupBox_stock);
            this.groupBox_dataEntry.Location = new System.Drawing.Point(3, 4);
            this.groupBox_dataEntry.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox_dataEntry.Name = "groupBox_dataEntry";
            this.groupBox_dataEntry.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox_dataEntry.Size = new System.Drawing.Size(371, 748);
            this.groupBox_dataEntry.TabIndex = 0;
            this.groupBox_dataEntry.TabStop = false;
            this.groupBox_dataEntry.Text = "Entrada de datos";
            // 
            // button_saveData
            // 
            this.button_saveData.BackColor = System.Drawing.Color.White;
            this.button_saveData.Cursor = System.Windows.Forms.Cursors.Default;
            this.button_saveData.FlatAppearance.BorderSize = 0;
            this.button_saveData.Font = new System.Drawing.Font("Segoe UI Light", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_saveData.Location = new System.Drawing.Point(226, 0);
            this.button_saveData.Name = "button_saveData";
            this.button_saveData.Size = new System.Drawing.Size(65, 28);
            this.button_saveData.TabIndex = 1;
            this.button_saveData.Text = "Guardar";
            this.button_saveData.UseVisualStyleBackColor = false;
            this.button_saveData.Click += new System.EventHandler(this.button_saveData_Click);
            // 
            // button_loadData
            // 
            this.button_loadData.BackColor = System.Drawing.Color.White;
            this.button_loadData.Cursor = System.Windows.Forms.Cursors.Default;
            this.button_loadData.FlatAppearance.BorderSize = 0;
            this.button_loadData.Font = new System.Drawing.Font("Segoe UI Light", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_loadData.Location = new System.Drawing.Point(296, 0);
            this.button_loadData.Name = "button_loadData";
            this.button_loadData.Size = new System.Drawing.Size(65, 28);
            this.button_loadData.TabIndex = 1;
            this.button_loadData.Text = "Cargar";
            this.button_loadData.UseVisualStyleBackColor = false;
            this.button_loadData.Click += new System.EventHandler(this.button_loadData_Click);
            // 
            // button_Clear
            // 
            this.button_Clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_Clear.BackColor = System.Drawing.Color.White;
            this.button_Clear.Cursor = System.Windows.Forms.Cursors.Default;
            this.button_Clear.FlatAppearance.BorderSize = 0;
            this.button_Clear.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button_Clear.Location = new System.Drawing.Point(6, 701);
            this.button_Clear.Name = "button_Clear";
            this.button_Clear.Size = new System.Drawing.Size(128, 39);
            this.button_Clear.TabIndex = 1;
            this.button_Clear.Text = "Limpiar Todo";
            this.button_Clear.UseVisualStyleBackColor = false;
            this.button_Clear.Click += new System.EventHandler(this.button_Clear_Click);
            // 
            // button_start
            // 
            this.button_start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_start.BackColor = System.Drawing.Color.White;
            this.button_start.Cursor = System.Windows.Forms.Cursors.Default;
            this.button_start.Enabled = false;
            this.button_start.FlatAppearance.BorderSize = 0;
            this.button_start.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button_start.Location = new System.Drawing.Point(200, 701);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(164, 39);
            this.button_start.TabIndex = 1;
            this.button_start.Text = "Calcular Solución";
            this.button_start.UseVisualStyleBackColor = false;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // groupBox_Pieces
            // 
            this.groupBox_Pieces.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox_Pieces.Controls.Add(this.button_emptyPieces);
            this.groupBox_Pieces.Controls.Add(this.dataGridView_Pieces);
            this.groupBox_Pieces.Location = new System.Drawing.Point(6, 206);
            this.groupBox_Pieces.Name = "groupBox_Pieces";
            this.groupBox_Pieces.Size = new System.Drawing.Size(358, 488);
            this.groupBox_Pieces.TabIndex = 3;
            this.groupBox_Pieces.TabStop = false;
            this.groupBox_Pieces.Text = "Piezas";
            // 
            // button_emptyPieces
            // 
            this.button_emptyPieces.BackColor = System.Drawing.SystemColors.Control;
            this.button_emptyPieces.Cursor = System.Windows.Forms.Cursors.Default;
            this.button_emptyPieces.FlatAppearance.BorderSize = 0;
            this.button_emptyPieces.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_emptyPieces.Font = new System.Drawing.Font("Segoe UI Light", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_emptyPieces.Location = new System.Drawing.Point(311, -1);
            this.button_emptyPieces.Name = "button_emptyPieces";
            this.button_emptyPieces.Size = new System.Drawing.Size(44, 22);
            this.button_emptyPieces.TabIndex = 1;
            this.button_emptyPieces.Text = "Vaciar";
            this.button_emptyPieces.UseVisualStyleBackColor = false;
            this.button_emptyPieces.Click += new System.EventHandler(this.button_emptyPieces_Click);
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
            this.dataGridView_Pieces.Size = new System.Drawing.Size(340, 459);
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
            this.groupBox_stock.Controls.Add(this.button_defaultDimensions);
            this.groupBox_stock.Controls.Add(this.groupBox_Dimensions);
            this.groupBox_stock.Controls.Add(this.label2);
            this.groupBox_stock.Controls.Add(this.numericUpDown_CostStock);
            this.groupBox_stock.Location = new System.Drawing.Point(6, 18);
            this.groupBox_stock.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox_stock.Name = "groupBox_stock";
            this.groupBox_stock.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox_stock.Size = new System.Drawing.Size(358, 181);
            this.groupBox_stock.TabIndex = 2;
            this.groupBox_stock.TabStop = false;
            this.groupBox_stock.Text = "Material";
            // 
            // button_defaultDimensions
            // 
            this.button_defaultDimensions.BackColor = System.Drawing.SystemColors.Control;
            this.button_defaultDimensions.Cursor = System.Windows.Forms.Cursors.Default;
            this.button_defaultDimensions.FlatAppearance.BorderSize = 0;
            this.button_defaultDimensions.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_defaultDimensions.Font = new System.Drawing.Font("Segoe UI Light", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_defaultDimensions.Location = new System.Drawing.Point(298, 16);
            this.button_defaultDimensions.Name = "button_defaultDimensions";
            this.button_defaultDimensions.Size = new System.Drawing.Size(54, 22);
            this.button_defaultDimensions.TabIndex = 1;
            this.button_defaultDimensions.Text = "Defecto";
            this.button_defaultDimensions.UseVisualStyleBackColor = false;
            this.button_defaultDimensions.Click += new System.EventHandler(this.button_defaultDimensions_Click);
            // 
            // groupBox_Dimensions
            // 
            this.groupBox_Dimensions.Controls.Add(this.panel_image);
            this.groupBox_Dimensions.Controls.Add(this.label_Width);
            this.groupBox_Dimensions.Controls.Add(this.label_Length);
            this.groupBox_Dimensions.Controls.Add(this.numericUpDown_LengthStock);
            this.groupBox_Dimensions.Controls.Add(this.numericUpDown_WidthStock);
            this.groupBox_Dimensions.Location = new System.Drawing.Point(6, 16);
            this.groupBox_Dimensions.Name = "groupBox_Dimensions";
            this.groupBox_Dimensions.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox_Dimensions.Size = new System.Drawing.Size(219, 157);
            this.groupBox_Dimensions.TabIndex = 1;
            this.groupBox_Dimensions.TabStop = false;
            this.groupBox_Dimensions.Text = "Dimensiones";
            // 
            // panel_image
            // 
            this.panel_image.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel_image.BackgroundImage")));
            this.panel_image.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_image.Location = new System.Drawing.Point(43, 30);
            this.panel_image.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel_image.Name = "panel_image";
            this.panel_image.Size = new System.Drawing.Size(101, 81);
            this.panel_image.TabIndex = 3;
            // 
            // label_Width
            // 
            this.label_Width.AutoSize = true;
            this.label_Width.Location = new System.Drawing.Point(144, 30);
            this.label_Width.Name = "label_Width";
            this.label_Width.Size = new System.Drawing.Size(51, 20);
            this.label_Width.TabIndex = 1;
            this.label_Width.Text = "Ancho";
            // 
            // label_Length
            // 
            this.label_Length.AutoSize = true;
            this.label_Length.Location = new System.Drawing.Point(9, 119);
            this.label_Length.Name = "label_Length";
            this.label_Length.Size = new System.Drawing.Size(47, 20);
            this.label_Length.TabIndex = 1;
            this.label_Length.Text = "Largo";
            // 
            // numericUpDown_LengthStock
            // 
            this.numericUpDown_LengthStock.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown_LengthStock.Location = new System.Drawing.Point(57, 119);
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
            this.numericUpDown_WidthStock.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown_WidthStock.Location = new System.Drawing.Point(148, 54);
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
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(228, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Costo por unidad";
            // 
            // numericUpDown_CostStock
            // 
            this.numericUpDown_CostStock.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown_CostStock.Location = new System.Drawing.Point(287, 147);
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
            this.label_pattern.Location = new System.Drawing.Point(431, 708);
            this.label_pattern.Name = "label_pattern";
            this.label_pattern.Size = new System.Drawing.Size(63, 25);
            this.label_pattern.TabIndex = 2;
            this.label_pattern.Text = "Patrón";
            this.label_pattern.Visible = false;
            // 
            // button_prevPattern
            // 
            this.button_prevPattern.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button_prevPattern.BackColor = System.Drawing.Color.White;
            this.button_prevPattern.Enabled = false;
            this.button_prevPattern.FlatAppearance.BorderSize = 0;
            this.button_prevPattern.Font = new System.Drawing.Font("Arial Narrow", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_prevPattern.Location = new System.Drawing.Point(379, 701);
            this.button_prevPattern.Name = "button_prevPattern";
            this.button_prevPattern.Size = new System.Drawing.Size(41, 39);
            this.button_prevPattern.TabIndex = 3;
            this.button_prevPattern.Text = "◄";
            this.button_prevPattern.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_prevPattern.UseVisualStyleBackColor = false;
            this.button_prevPattern.Click += new System.EventHandler(this.button_prevPattern_Click);
            // 
            // button_nextPattern
            // 
            this.button_nextPattern.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button_nextPattern.BackColor = System.Drawing.Color.White;
            this.button_nextPattern.Enabled = false;
            this.button_nextPattern.FlatAppearance.BorderSize = 0;
            this.button_nextPattern.Font = new System.Drawing.Font("Arial Narrow", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_nextPattern.Location = new System.Drawing.Point(569, 701);
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
            this.groupBox_Solution.Controls.Add(this.textBox_totalMaterial);
            this.groupBox_Solution.Controls.Add(this.textBox_PatternRep);
            this.groupBox_Solution.Controls.Add(this.textBox_cur_pattern);
            this.groupBox_Solution.Controls.Add(this.button_changeData);
            this.groupBox_Solution.Controls.Add(this.label_TotalMat);
            this.groupBox_Solution.Controls.Add(this.label_PatternRep);
            this.groupBox_Solution.Controls.Add(this.pictureBox_sol);
            this.groupBox_Solution.Controls.Add(this.button_nextPattern);
            this.groupBox_Solution.Controls.Add(this.label_pattern);
            this.groupBox_Solution.Controls.Add(this.button_prevPattern);
            this.groupBox_Solution.Controls.Add(this.panel_pb);
            this.groupBox_Solution.Location = new System.Drawing.Point(387, 4);
            this.groupBox_Solution.Name = "groupBox_Solution";
            this.groupBox_Solution.Size = new System.Drawing.Size(1081, 748);
            this.groupBox_Solution.TabIndex = 5;
            this.groupBox_Solution.TabStop = false;
            this.groupBox_Solution.Text = "Patrones de corte";
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
            // textBox_cur_pattern
            // 
            this.textBox_cur_pattern.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.textBox_cur_pattern.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_cur_pattern.Location = new System.Drawing.Point(495, 708);
            this.textBox_cur_pattern.Name = "textBox_cur_pattern";
            this.textBox_cur_pattern.Size = new System.Drawing.Size(65, 20);
            this.textBox_cur_pattern.TabIndex = 5;
            this.textBox_cur_pattern.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_changeData
            // 
            this.button_changeData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_changeData.BackColor = System.Drawing.Color.White;
            this.button_changeData.Cursor = System.Windows.Forms.Cursors.Default;
            this.button_changeData.Enabled = false;
            this.button_changeData.FlatAppearance.BorderSize = 0;
            this.button_changeData.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button_changeData.Location = new System.Drawing.Point(7, 701);
            this.button_changeData.Name = "button_changeData";
            this.button_changeData.Size = new System.Drawing.Size(162, 39);
            this.button_changeData.TabIndex = 1;
            this.button_changeData.Text = "← Cambiar Datos";
            this.button_changeData.UseVisualStyleBackColor = false;
            this.button_changeData.Click += new System.EventHandler(this.button_changeData_Click);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1476, 756);
            this.Controls.Add(this.groupBox_Solution);
            this.Controls.Add(this.groupBox_dataEntry);
            this.MinimumSize = new System.Drawing.Size(1150, 400);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Optimus Papercut";
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.groupBox_dataEntry.ResumeLayout(false);
            this.groupBox_Pieces.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Pieces)).EndInit();
            this.groupBox_stock.ResumeLayout(false);
            this.groupBox_stock.PerformLayout();
            this.groupBox_Dimensions.ResumeLayout(false);
            this.groupBox_Dimensions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_LengthStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_WidthStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_CostStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_sol)).EndInit();
            this.groupBox_Solution.ResumeLayout(false);
            this.groupBox_Solution.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Button button_Clear;
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
        private System.Windows.Forms.Button button_loadData;
        private System.Windows.Forms.OpenFileDialog openFileDialog_data;
        private System.Windows.Forms.SaveFileDialog saveFileDialog_data;
        private System.Windows.Forms.DataGridViewTextBoxColumn LengthColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn WidthColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DemandColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ObtainedColumn;
        private System.Windows.Forms.Button button_emptyPieces;
        private System.Windows.Forms.Button button_defaultDimensions;
        private System.Windows.Forms.Button button_changeData;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Button button_saveData;
        private System.Windows.Forms.Label textBox_cur_pattern;
        private System.Windows.Forms.Label textBox_totalMaterial;
        private System.Windows.Forms.Label textBox_PatternRep;
        private System.Windows.Forms.Panel panel_pb;
    }
}

