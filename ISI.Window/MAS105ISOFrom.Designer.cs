namespace ISI.Window
{
    partial class MAS105ISOForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAS105ISOForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.ucPagecs1 = new ISI.Window.UCPagecs();
            this.ucBottom1 = new ISI.Window.UCBottom();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ucTopl11 = new ISI.Window.UCTopl1();
            this.panel3 = new System.Windows.Forms.Panel();
            this.bdnISO = new System.Windows.Forms.BindingNavigator(this.components);
            this.ADD = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem1 = new System.Windows.Forms.ToolStripLabel();
            this.DEL = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem1 = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.RefeshBT5 = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dateTimePickerISOEFFD = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerISOISD = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxISOID = new System.Windows.Forms.TextBox();
            this.textBoxISONUM = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxISOTCODE = new System.Windows.Forms.TextBox();
            this.textBoxISOName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvISO = new System.Windows.Forms.DataGridView();
            this.bdsISO = new System.Windows.Forms.BindingSource(this.components);
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdnISO)).BeginInit();
            this.bdnISO.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvISO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsISO)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.ForestGreen;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1924, 52);
            this.label1.TabIndex = 1;
            this.label1.Text = "ISO Data Management";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucPagecs1
            // 
            this.ucPagecs1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucPagecs1.Location = new System.Drawing.Point(0, 1020);
            this.ucPagecs1.Name = "ucPagecs1";
            this.ucPagecs1.Size = new System.Drawing.Size(1924, 35);
            this.ucPagecs1.TabIndex = 4;
            // 
            // ucBottom1
            // 
            this.ucBottom1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucBottom1.Location = new System.Drawing.Point(0, 980);
            this.ucBottom1.Name = "ucBottom1";
            this.ucBottom1.Size = new System.Drawing.Size(1924, 40);
            this.ucBottom1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ucTopl11);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 52);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1924, 39);
            this.panel2.TabIndex = 36;
            // 
            // ucTopl11
            // 
            this.ucTopl11._MAS101SuppilerForm = null;
            this.ucTopl11.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucTopl11.Location = new System.Drawing.Point(0, 0);
            this.ucTopl11.Name = "ucTopl11";
            this.ucTopl11.Size = new System.Drawing.Size(1924, 40);
            this.ucTopl11.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.bdnISO);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 91);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1924, 32);
            this.panel3.TabIndex = 37;
            // 
            // bdnISO
            // 
            this.bdnISO.AddNewItem = this.ADD;
            this.bdnISO.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.bdnISO.CountItem = this.bindingNavigatorCountItem1;
            this.bdnISO.DeleteItem = this.DEL;
            this.bdnISO.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem1,
            this.bindingNavigatorMovePreviousItem1,
            this.bindingNavigatorSeparator3,
            this.bindingNavigatorPositionItem1,
            this.bindingNavigatorCountItem1,
            this.bindingNavigatorSeparator4,
            this.bindingNavigatorMoveNextItem1,
            this.bindingNavigatorMoveLastItem1,
            this.bindingNavigatorSeparator5,
            this.ADD,
            this.DEL,
            this.toolStripSeparator3,
            this.tsbSave,
            this.RefeshBT5});
            this.bdnISO.Location = new System.Drawing.Point(0, 0);
            this.bdnISO.MoveFirstItem = this.bindingNavigatorMoveFirstItem1;
            this.bdnISO.MoveLastItem = this.bindingNavigatorMoveLastItem1;
            this.bdnISO.MoveNextItem = this.bindingNavigatorMoveNextItem1;
            this.bdnISO.MovePreviousItem = this.bindingNavigatorMovePreviousItem1;
            this.bdnISO.Name = "bdnISO";
            this.bdnISO.PositionItem = this.bindingNavigatorPositionItem1;
            this.bdnISO.Size = new System.Drawing.Size(1924, 27);
            this.bdnISO.TabIndex = 17;
            this.bdnISO.Text = "bindingNavigator1";
            // 
            // ADD
            // 
            this.ADD.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ADD.Image = ((System.Drawing.Image)(resources.GetObject("ADD.Image")));
            this.ADD.Name = "ADD";
            this.ADD.RightToLeftAutoMirrorImage = true;
            this.ADD.Size = new System.Drawing.Size(23, 24);
            this.ADD.Text = "Add new";
            this.ADD.Click += new System.EventHandler(this.bindingNavigatorAddNewItem1_Click);
            // 
            // bindingNavigatorCountItem1
            // 
            this.bindingNavigatorCountItem1.Name = "bindingNavigatorCountItem1";
            this.bindingNavigatorCountItem1.Size = new System.Drawing.Size(45, 24);
            this.bindingNavigatorCountItem1.Text = "of {0}";
            this.bindingNavigatorCountItem1.ToolTipText = "Total number of items";
            // 
            // DEL
            // 
            this.DEL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DEL.Image = ((System.Drawing.Image)(resources.GetObject("DEL.Image")));
            this.DEL.Name = "DEL";
            this.DEL.RightToLeftAutoMirrorImage = true;
            this.DEL.Size = new System.Drawing.Size(23, 24);
            this.DEL.Text = "Delete";
            this.DEL.Click += new System.EventHandler(this.bindingNavigatorDeleteItem1_Click);
            // 
            // bindingNavigatorMoveFirstItem1
            // 
            this.bindingNavigatorMoveFirstItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem1.Image")));
            this.bindingNavigatorMoveFirstItem1.Name = "bindingNavigatorMoveFirstItem1";
            this.bindingNavigatorMoveFirstItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem1.Size = new System.Drawing.Size(23, 24);
            this.bindingNavigatorMoveFirstItem1.Text = "Move first";
            this.bindingNavigatorMoveFirstItem1.Click += new System.EventHandler(this.bindingNavigatorMoveFirstItem1_Click_1);
            // 
            // bindingNavigatorMovePreviousItem1
            // 
            this.bindingNavigatorMovePreviousItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem1.Image")));
            this.bindingNavigatorMovePreviousItem1.Name = "bindingNavigatorMovePreviousItem1";
            this.bindingNavigatorMovePreviousItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem1.Size = new System.Drawing.Size(23, 24);
            this.bindingNavigatorMovePreviousItem1.Text = "Move previous";
            this.bindingNavigatorMovePreviousItem1.Click += new System.EventHandler(this.bindingNavigatorMovePreviousItem1_Click_1);
            // 
            // bindingNavigatorSeparator3
            // 
            this.bindingNavigatorSeparator3.Name = "bindingNavigatorSeparator3";
            this.bindingNavigatorSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorPositionItem1
            // 
            this.bindingNavigatorPositionItem1.AccessibleName = "Position";
            this.bindingNavigatorPositionItem1.AutoSize = false;
            this.bindingNavigatorPositionItem1.Name = "bindingNavigatorPositionItem1";
            this.bindingNavigatorPositionItem1.Size = new System.Drawing.Size(50, 27);
            this.bindingNavigatorPositionItem1.Text = "0";
            this.bindingNavigatorPositionItem1.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator4
            // 
            this.bindingNavigatorSeparator4.Name = "bindingNavigatorSeparator4";
            this.bindingNavigatorSeparator4.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorMoveNextItem1
            // 
            this.bindingNavigatorMoveNextItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem1.Image")));
            this.bindingNavigatorMoveNextItem1.Name = "bindingNavigatorMoveNextItem1";
            this.bindingNavigatorMoveNextItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem1.Size = new System.Drawing.Size(23, 24);
            this.bindingNavigatorMoveNextItem1.Text = "Move next";
            this.bindingNavigatorMoveNextItem1.Click += new System.EventHandler(this.bindingNavigatorMoveNextItem1_Click_1);
            // 
            // bindingNavigatorMoveLastItem1
            // 
            this.bindingNavigatorMoveLastItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem1.Image")));
            this.bindingNavigatorMoveLastItem1.Name = "bindingNavigatorMoveLastItem1";
            this.bindingNavigatorMoveLastItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem1.Size = new System.Drawing.Size(23, 24);
            this.bindingNavigatorMoveLastItem1.Text = "Move last";
            this.bindingNavigatorMoveLastItem1.Click += new System.EventHandler(this.bindingNavigatorMoveLastItem1_Click_1);
            // 
            // bindingNavigatorSeparator5
            // 
            this.bindingNavigatorSeparator5.Name = "bindingNavigatorSeparator5";
            this.bindingNavigatorSeparator5.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // tsbSave
            // 
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSave.Image = global::ISI.Window.Properties.Resources.Save;
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(23, 24);
            this.tsbSave.Text = "Save Data";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click_1);
            // 
            // RefeshBT5
            // 
            this.RefeshBT5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RefeshBT5.Image = global::ISI.Window.Properties.Resources.computer_icons_clip_art_png_favpng_M070FyPc8TCR8X7L1JpvGcVe3_t;
            this.RefeshBT5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RefeshBT5.Name = "RefeshBT5";
            this.RefeshBT5.Size = new System.Drawing.Size(23, 24);
            this.RefeshBT5.Text = "Refresh";
            this.RefeshBT5.Click += new System.EventHandler(this.RefeshBT5_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dateTimePickerISOEFFD);
            this.panel1.Controls.Add(this.dateTimePickerISOISD);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.textBoxISOID);
            this.panel1.Controls.Add(this.textBoxISONUM);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBoxISOTCODE);
            this.panel1.Controls.Add(this.textBoxISOName);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 123);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1924, 119);
            this.panel1.TabIndex = 38;
            // 
            // dateTimePickerISOEFFD
            // 
            this.dateTimePickerISOEFFD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dateTimePickerISOEFFD.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerISOEFFD.Location = new System.Drawing.Point(1554, 63);
            this.dateTimePickerISOEFFD.Name = "dateTimePickerISOEFFD";
            this.dateTimePickerISOEFFD.Size = new System.Drawing.Size(192, 30);
            this.dateTimePickerISOEFFD.TabIndex = 56;
            this.dateTimePickerISOEFFD.Value = new System.DateTime(2020, 12, 25, 11, 10, 10, 0);
            // 
            // dateTimePickerISOISD
            // 
            this.dateTimePickerISOISD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dateTimePickerISOISD.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerISOISD.Location = new System.Drawing.Point(1554, 22);
            this.dateTimePickerISOISD.Name = "dateTimePickerISOISD";
            this.dateTimePickerISOISD.Size = new System.Drawing.Size(192, 30);
            this.dateTimePickerISOISD.TabIndex = 55;
            this.dateTimePickerISOISD.Value = new System.DateTime(2020, 12, 25, 11, 10, 10, 0);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(1282, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(285, 48);
            this.label7.TabIndex = 36;
            this.label7.Text = "ISO Effective Date:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(1299, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(263, 48);
            this.label5.TabIndex = 35;
            this.label5.Text = "ISO Issused Date:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxISOID
            // 
            this.textBoxISOID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.textBoxISOID.Location = new System.Drawing.Point(178, 18);
            this.textBoxISOID.Multiline = true;
            this.textBoxISOID.Name = "textBoxISOID";
            this.textBoxISOID.Size = new System.Drawing.Size(369, 30);
            this.textBoxISOID.TabIndex = 30;
            this.textBoxISOID.Text = "ISO";
            // 
            // textBoxISONUM
            // 
            this.textBoxISONUM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.textBoxISONUM.Location = new System.Drawing.Point(178, 60);
            this.textBoxISONUM.Multiline = true;
            this.textBoxISONUM.Name = "textBoxISONUM";
            this.textBoxISONUM.Size = new System.Drawing.Size(369, 30);
            this.textBoxISONUM.TabIndex = 34;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(-15, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(208, 48);
            this.label6.TabIndex = 33;
            this.label6.Text = "ISI Numble:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(48, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 48);
            this.label2.TabIndex = 25;
            this.label2.Text = "ISO ID:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxISOTCODE
            // 
            this.textBoxISOTCODE.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.textBoxISOTCODE.Location = new System.Drawing.Point(910, 63);
            this.textBoxISOTCODE.Multiline = true;
            this.textBoxISOTCODE.Name = "textBoxISOTCODE";
            this.textBoxISOTCODE.Size = new System.Drawing.Size(369, 30);
            this.textBoxISOTCODE.TabIndex = 28;
            // 
            // textBoxISOName
            // 
            this.textBoxISOName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.textBoxISOName.Location = new System.Drawing.Point(910, 24);
            this.textBoxISOName.Multiline = true;
            this.textBoxISOName.Name = "textBoxISOName";
            this.textBoxISOName.Size = new System.Drawing.Size(369, 30);
            this.textBoxISOName.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(692, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(246, 48);
            this.label4.TabIndex = 27;
            this.label4.Text = "ISO TCODE:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(708, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(233, 48);
            this.label3.TabIndex = 26;
            this.label3.Text = "ISO Name:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvISO
            // 
            this.dgvISO.AllowUserToAddRows = false;
            this.dgvISO.AllowUserToDeleteRows = false;
            this.dgvISO.BackgroundColor = System.Drawing.SystemColors.ButtonShadow;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvISO.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvISO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvISO.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvISO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvISO.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvISO.Location = new System.Drawing.Point(0, 242);
            this.dgvISO.Name = "dgvISO";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvISO.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvISO.RowTemplate.Height = 24;
            this.dgvISO.Size = new System.Drawing.Size(1924, 738);
            this.dgvISO.TabIndex = 39;
            // 
            // MAS105ISOForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.dgvISO);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.ucBottom1);
            this.Controls.Add(this.ucPagecs1);
            this.Controls.Add(this.label1);
            this.Name = "MAS105ISOForm";
            this.RightToLeftLayout = true;
            this.Text = "MAS105ISOForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdnISO)).EndInit();
            this.bdnISO.ResumeLayout(false);
            this.bdnISO.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvISO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsISO)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private UCPagecs ucPagecs1;
        private UCBottom ucBottom1;
        private System.Windows.Forms.Panel panel2;
        private UCTopl1 ucTopl11;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxISOID;
        private System.Windows.Forms.TextBox textBoxISONUM;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxISOTCODE;
        private System.Windows.Forms.TextBox textBoxISOName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvISO;
        private System.Windows.Forms.BindingSource bdsISO;
        private System.Windows.Forms.BindingNavigator bdnISO;
        private System.Windows.Forms.ToolStripButton ADD;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem1;
        private System.Windows.Forms.ToolStripButton DEL;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator3;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator4;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton RefeshBT5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePickerISOEFFD;
        private System.Windows.Forms.DateTimePicker dateTimePickerISOISD;
    }
}