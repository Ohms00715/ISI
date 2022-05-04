namespace ISI.Window
{
    partial class MAS103Quality_CheckForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAS103Quality_CheckForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ucTopl12 = new ISI.Window.UCTopl1();
            this.panel3 = new System.Windows.Forms.Panel();
            this.bdnQC = new System.Windows.Forms.BindingNavigator(this.components);
            this.ADD = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.DEL = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tabSaveQC = new System.Windows.Forms.ToolStripButton();
            this.RefeshBT3 = new System.Windows.Forms.ToolStripButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.textBoxQCLName = new System.Windows.Forms.TextBox();
            this.textBoxQCFName = new System.Windows.Forms.TextBox();
            this.textBoxQCDEP = new System.Windows.Forms.TextBox();
            this.textBoxQCID = new System.Windows.Forms.TextBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.bdsQC = new System.Windows.Forms.BindingSource(this.components);
            this.dgvQC = new System.Windows.Forms.DataGridView();
            this.ucBottom1 = new ISI.Window.UCBottom();
            this.ucPagecs2 = new ISI.Window.UCPagecs();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdnQC)).BeginInit();
            this.bdnQC.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsQC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQC)).BeginInit();
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
            this.label1.TabIndex = 0;
            this.label1.Text = "Qualitty Check Data Management";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ucTopl12);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 52);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1924, 39);
            this.panel2.TabIndex = 31;
            // 
            // ucTopl12
            // 
            this.ucTopl12._MAS101SuppilerForm = null;
            this.ucTopl12.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucTopl12.Location = new System.Drawing.Point(0, 0);
            this.ucTopl12.Name = "ucTopl12";
            this.ucTopl12.Size = new System.Drawing.Size(1924, 39);
            this.ucTopl12.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.bdnQC);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 91);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1924, 32);
            this.panel3.TabIndex = 32;
            // 
            // bdnQC
            // 
            this.bdnQC.AddNewItem = this.ADD;
            this.bdnQC.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.bdnQC.CountItem = this.bindingNavigatorCountItem;
            this.bdnQC.DeleteItem = this.DEL;
            this.bdnQC.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.ADD,
            this.DEL,
            this.toolStripSeparator1,
            this.tabSaveQC,
            this.RefeshBT3});
            this.bdnQC.Location = new System.Drawing.Point(0, 0);
            this.bdnQC.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bdnQC.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bdnQC.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bdnQC.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bdnQC.Name = "bdnQC";
            this.bdnQC.PositionItem = this.bindingNavigatorPositionItem;
            this.bdnQC.Size = new System.Drawing.Size(1924, 27);
            this.bdnQC.TabIndex = 0;
            this.bdnQC.Text = "bindingNavigator1";
            // 
            // ADD
            // 
            this.ADD.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ADD.Image = ((System.Drawing.Image)(resources.GetObject("ADD.Image")));
            this.ADD.Name = "ADD";
            this.ADD.RightToLeftAutoMirrorImage = true;
            this.ADD.Size = new System.Drawing.Size(23, 24);
            this.ADD.Text = "Add new";
            this.ADD.Click += new System.EventHandler(this.bindingNavigatorAddNewItem_Click);
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(45, 24);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // DEL
            // 
            this.DEL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DEL.Image = ((System.Drawing.Image)(resources.GetObject("DEL.Image")));
            this.DEL.Name = "DEL";
            this.DEL.RightToLeftAutoMirrorImage = true;
            this.DEL.Size = new System.Drawing.Size(23, 24);
            this.DEL.Text = "Delete";
            this.DEL.Click += new System.EventHandler(this.bindingNavigatorDeleteItem_Click_1);
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 24);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            this.bindingNavigatorMoveFirstItem.Click += new System.EventHandler(this.bindingNavigatorMoveFirstItem_Click_1);
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 24);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            this.bindingNavigatorMovePreviousItem.Click += new System.EventHandler(this.bindingNavigatorMovePreviousItem_Click_1);
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 27);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 24);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            this.bindingNavigatorMoveNextItem.Click += new System.EventHandler(this.bindingNavigatorMoveNextItem_Click_1);
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 24);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            this.bindingNavigatorMoveLastItem.Click += new System.EventHandler(this.bindingNavigatorMoveLastItem_Click_1);
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // tabSaveQC
            // 
            this.tabSaveQC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tabSaveQC.Image = global::ISI.Window.Properties.Resources.Save;
            this.tabSaveQC.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tabSaveQC.Name = "tabSaveQC";
            this.tabSaveQC.Size = new System.Drawing.Size(23, 24);
            this.tabSaveQC.Text = "Save  Data";
            this.tabSaveQC.Click += new System.EventHandler(this.tabSaveQC_Click);
            // 
            // RefeshBT3
            // 
            this.RefeshBT3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RefeshBT3.Image = global::ISI.Window.Properties.Resources.computer_icons_clip_art_png_favpng_M070FyPc8TCR8X7L1JpvGcVe3_t;
            this.RefeshBT3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RefeshBT3.Name = "RefeshBT3";
            this.RefeshBT3.Size = new System.Drawing.Size(23, 24);
            this.RefeshBT3.Text = "Refresh";
            this.RefeshBT3.Click += new System.EventHandler(this.RefeshBT3_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.textBoxQCLName);
            this.panel4.Controls.Add(this.textBoxQCFName);
            this.panel4.Controls.Add(this.textBoxQCDEP);
            this.panel4.Controls.Add(this.textBoxQCID);
            this.panel4.Controls.Add(this.checkBox5);
            this.panel4.Controls.Add(this.checkBox4);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.checkBox3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 123);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1924, 181);
            this.panel4.TabIndex = 33;
            // 
            // textBoxQCLName
            // 
            this.textBoxQCLName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.textBoxQCLName.Location = new System.Drawing.Point(1193, 77);
            this.textBoxQCLName.Multiline = true;
            this.textBoxQCLName.Name = "textBoxQCLName";
            this.textBoxQCLName.Size = new System.Drawing.Size(192, 30);
            this.textBoxQCLName.TabIndex = 56;
            // 
            // textBoxQCFName
            // 
            this.textBoxQCFName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.textBoxQCFName.Location = new System.Drawing.Point(1193, 24);
            this.textBoxQCFName.Multiline = true;
            this.textBoxQCFName.Name = "textBoxQCFName";
            this.textBoxQCFName.Size = new System.Drawing.Size(192, 30);
            this.textBoxQCFName.TabIndex = 55;
            // 
            // textBoxQCDEP
            // 
            this.textBoxQCDEP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.textBoxQCDEP.Location = new System.Drawing.Point(436, 65);
            this.textBoxQCDEP.Multiline = true;
            this.textBoxQCDEP.Name = "textBoxQCDEP";
            this.textBoxQCDEP.Size = new System.Drawing.Size(192, 30);
            this.textBoxQCDEP.TabIndex = 54;
            // 
            // textBoxQCID
            // 
            this.textBoxQCID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.textBoxQCID.Location = new System.Drawing.Point(436, 24);
            this.textBoxQCID.Multiline = true;
            this.textBoxQCID.Name = "textBoxQCID";
            this.textBoxQCID.Size = new System.Drawing.Size(192, 30);
            this.textBoxQCID.TabIndex = 53;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Checked = true;
            this.checkBox5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.checkBox5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBox5.Location = new System.Drawing.Point(273, 123);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox5.Size = new System.Drawing.Size(171, 36);
            this.checkBox5.TabIndex = 28;
            this.checkBox5.Text = "For Create";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Checked = true;
            this.checkBox4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.checkBox4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBox4.Location = new System.Drawing.Point(507, 123);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox4.Size = new System.Drawing.Size(224, 36);
            this.checkBox4.TabIndex = 27;
            this.checkBox4.Text = "For Appproved";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(-79, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(569, 48);
            this.label5.TabIndex = 26;
            this.label5.Text = "Quality Check DepartMent:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(796, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(430, 48);
            this.label6.TabIndex = 17;
            this.label6.Text = "Quality Check First Name:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(127, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(277, 48);
            this.label7.TabIndex = 16;
            this.label7.Text = "Quality Check ID:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(796, 65);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(430, 48);
            this.label9.TabIndex = 18;
            this.label9.Text = "Quality Check Last Name:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.checkBox3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBox3.Location = new System.Drawing.Point(21, 123);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox3.Size = new System.Drawing.Size(131, 36);
            this.checkBox3.TabIndex = 23;
            this.checkBox3.Text = "Actived";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // dgvQC
            // 
            this.dgvQC.AllowUserToAddRows = false;
            this.dgvQC.AllowUserToDeleteRows = false;
            this.dgvQC.BackgroundColor = System.Drawing.SystemColors.ButtonShadow;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvQC.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvQC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvQC.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvQC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvQC.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvQC.Location = new System.Drawing.Point(0, 304);
            this.dgvQC.Name = "dgvQC";
            this.dgvQC.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvQC.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvQC.RowTemplate.Height = 24;
            this.dgvQC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvQC.Size = new System.Drawing.Size(1924, 676);
            this.dgvQC.TabIndex = 34;
            // 
            // ucBottom1
            // 
            this.ucBottom1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucBottom1.Location = new System.Drawing.Point(0, 980);
            this.ucBottom1.Name = "ucBottom1";
            this.ucBottom1.Size = new System.Drawing.Size(1924, 40);
            this.ucBottom1.TabIndex = 7;
            // 
            // ucPagecs2
            // 
            this.ucPagecs2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucPagecs2.Location = new System.Drawing.Point(0, 1020);
            this.ucPagecs2.Name = "ucPagecs2";
            this.ucPagecs2.Size = new System.Drawing.Size(1924, 35);
            this.ucPagecs2.TabIndex = 6;
            // 
            // MAS103Quality_CheckForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.dgvQC);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.ucBottom1);
            this.Controls.Add(this.ucPagecs2);
            this.Controls.Add(this.label1);
            this.Name = "MAS103Quality_CheckForm";
            this.RightToLeftLayout = true;
            this.Text = "MAS103Quality_CheckForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdnQC)).EndInit();
            this.bdnQC.ResumeLayout(false);
            this.bdnQC.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsQC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private UCPagecs ucPagecs2;
        private UCBottom ucBottom1;
        private System.Windows.Forms.Panel panel2;
        private UCTopl1 ucTopl12;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.BindingNavigator bdnQC;
        private System.Windows.Forms.ToolStripButton ADD;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton DEL;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.BindingSource bdsQC;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.TextBox textBoxQCFName;
        private System.Windows.Forms.TextBox textBoxQCDEP;
        private System.Windows.Forms.DataGridView dgvQC;
        private System.Windows.Forms.TextBox textBoxQCLName;
        private System.Windows.Forms.TextBox textBoxQCID;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tabSaveQC;
        private System.Windows.Forms.ToolStripButton RefeshBT3;

       
    }
}