namespace ISI.Window
{
    partial class MAS104DefectForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAS104DefectForm));
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ucTopl11 = new ISI.Window.UCTopl1();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bdnDef = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.RefeshBT1 = new System.Windows.Forms.ToolStripButton();
            this.checkBoxDEFACT = new System.Windows.Forms.CheckBox();
            this.textBoxDEFRe = new System.Windows.Forms.TextBox();
            this.textBoxDEFName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxDEFID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvDef = new System.Windows.Forms.DataGridView();
            this.bdsDef2 = new System.Windows.Forms.BindingSource(this.components);
            this.ucBottom1 = new ISI.Window.UCBottom();
            this.ucPagecs2 = new ISI.Window.UCPagecs();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdnDef)).BeginInit();
            this.bdnDef.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDef)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDef2)).BeginInit();
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
            this.label1.Text = "Defect Data Management";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ucTopl11);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 52);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1924, 39);
            this.panel3.TabIndex = 33;
            // 
            // ucTopl11
            // 
            this.ucTopl11._MAS101SuppilerForm = null;
            this.ucTopl11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTopl11.Location = new System.Drawing.Point(0, 0);
            this.ucTopl11.Name = "ucTopl11";
            this.ucTopl11.Size = new System.Drawing.Size(1924, 39);
            this.ucTopl11.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bdnDef);
            this.panel1.Controls.Add(this.checkBoxDEFACT);
            this.panel1.Controls.Add(this.textBoxDEFRe);
            this.panel1.Controls.Add(this.textBoxDEFName);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBoxDEFID);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 91);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1924, 199);
            this.panel1.TabIndex = 34;
            // 
            // bdnDef
            // 
            this.bdnDef.AddNewItem = this.ADD;
            this.bdnDef.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.bdnDef.CountItem = this.bindingNavigatorCountItem;
            this.bdnDef.DeleteItem = this.DEL;
            this.bdnDef.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.toolStripSeparator1,
            this.DEL,
            this.toolStripSeparator3,
            this.tsbSave,
            this.toolStripSeparator2,
            this.RefeshBT1});
            this.bdnDef.Location = new System.Drawing.Point(0, 0);
            this.bdnDef.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bdnDef.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bdnDef.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bdnDef.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bdnDef.Name = "bdnDef";
            this.bdnDef.PositionItem = this.bindingNavigatorPositionItem;
            this.bdnDef.Size = new System.Drawing.Size(1924, 27);
            this.bdnDef.TabIndex = 37;
            this.bdnDef.Text = "bindingNavigator1";
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
            this.DEL.Click += new System.EventHandler(this.bindingNavigatorDeleteItem_Click);
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 24);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            this.bindingNavigatorMoveFirstItem.Click += new System.EventHandler(this.bindingNavigatorMoveFirstItem_Click);
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 24);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            this.bindingNavigatorMovePreviousItem.Click += new System.EventHandler(this.bindingNavigatorMovePreviousItem_Click);
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
            this.bindingNavigatorMoveNextItem.Click += new System.EventHandler(this.bindingNavigatorMoveNextItem_Click);
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 24);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            this.bindingNavigatorMoveLastItem.Click += new System.EventHandler(this.bindingNavigatorMoveLastItem_Click);
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
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // tsbSave
            // 
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSave.Image = global::ISI.Window.Properties.Resources.Save;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(23, 24);
            this.tsbSave.Text = "Save Data";
            this.tsbSave.ToolTipText = "Save ";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // RefeshBT1
            // 
            this.RefeshBT1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RefeshBT1.Image = global::ISI.Window.Properties.Resources.computer_icons_clip_art_png_favpng_M070FyPc8TCR8X7L1JpvGcVe3_t;
            this.RefeshBT1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RefeshBT1.Name = "RefeshBT1";
            this.RefeshBT1.Size = new System.Drawing.Size(23, 24);
            this.RefeshBT1.Text = "Refresh";
            this.RefeshBT1.Click += new System.EventHandler(this.RefeshBT1_Click);
            // 
            // checkBoxDEFACT
            // 
            this.checkBoxDEFACT.AutoSize = true;
            this.checkBoxDEFACT.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.checkBoxDEFACT.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBoxDEFACT.Location = new System.Drawing.Point(832, 111);
            this.checkBoxDEFACT.Name = "checkBoxDEFACT";
            this.checkBoxDEFACT.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxDEFACT.Size = new System.Drawing.Size(131, 36);
            this.checkBoxDEFACT.TabIndex = 23;
            this.checkBoxDEFACT.Text = "Actived";
            this.checkBoxDEFACT.UseVisualStyleBackColor = true;
            // 
            // textBoxDEFRe
            // 
            this.textBoxDEFRe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.textBoxDEFRe.Location = new System.Drawing.Point(235, 117);
            this.textBoxDEFRe.Multiline = true;
            this.textBoxDEFRe.Name = "textBoxDEFRe";
            this.textBoxDEFRe.Size = new System.Drawing.Size(369, 30);
            this.textBoxDEFRe.TabIndex = 19;
            // 
            // textBoxDEFName
            // 
            this.textBoxDEFName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.textBoxDEFName.Location = new System.Drawing.Point(1025, 52);
            this.textBoxDEFName.Multiline = true;
            this.textBoxDEFName.Name = "textBoxDEFName";
            this.textBoxDEFName.Size = new System.Drawing.Size(369, 30);
            this.textBoxDEFName.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(-54, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(357, 48);
            this.label4.TabIndex = 18;
            this.label4.Text = "Defect Remark:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxDEFID
            // 
            this.textBoxDEFID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.textBoxDEFID.Location = new System.Drawing.Point(235, 52);
            this.textBoxDEFID.Multiline = true;
            this.textBoxDEFID.Name = "textBoxDEFID";
            this.textBoxDEFID.Size = new System.Drawing.Size(369, 30);
            this.textBoxDEFID.TabIndex = 21;
            this.textBoxDEFID.Text = "DEF";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(65, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 48);
            this.label2.TabIndex = 16;
            this.label2.Text = "Defect ID:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(762, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(330, 48);
            this.label3.TabIndex = 17;
            this.label3.Text = "Defect Name:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvDef
            // 
            this.dgvDef.AllowUserToAddRows = false;
            this.dgvDef.AllowUserToDeleteRows = false;
            this.dgvDef.BackgroundColor = System.Drawing.SystemColors.ButtonShadow;
            this.dgvDef.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDef.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDef.Location = new System.Drawing.Point(0, 290);
            this.dgvDef.Name = "dgvDef";
            this.dgvDef.ReadOnly = true;
            this.dgvDef.RowTemplate.Height = 24;
            this.dgvDef.Size = new System.Drawing.Size(1924, 690);
            this.dgvDef.TabIndex = 35;
            // 
            // ucBottom1
            // 
            this.ucBottom1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucBottom1.Location = new System.Drawing.Point(0, 980);
            this.ucBottom1.Name = "ucBottom1";
            this.ucBottom1.Size = new System.Drawing.Size(1924, 40);
            this.ucBottom1.TabIndex = 5;
            // 
            // ucPagecs2
            // 
            this.ucPagecs2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucPagecs2.Location = new System.Drawing.Point(0, 1020);
            this.ucPagecs2.Name = "ucPagecs2";
            this.ucPagecs2.Size = new System.Drawing.Size(1924, 35);
            this.ucPagecs2.TabIndex = 4;
            // 
            // MAS104DefectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.dgvDef);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.ucBottom1);
            this.Controls.Add(this.ucPagecs2);
            this.Controls.Add(this.label1);
            this.Name = "MAS104DefectForm";
            this.RightToLeftLayout = true;
            this.Text = "MAS104Quality_Control_StatusForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdnDef)).EndInit();
            this.bdnDef.ResumeLayout(false);
            this.bdnDef.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDef)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDef2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private UCPagecs ucPagecs2;
        private UCBottom ucBottom1;
        
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBoxDEFACT;
        private System.Windows.Forms.TextBox textBoxDEFRe;
        private System.Windows.Forms.TextBox textBoxDEFName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxDEFID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvDef;
        private System.Windows.Forms.BindingSource bdsDef2;
        private UCTopl1 ucTopl11;
        private System.Windows.Forms.BindingNavigator bdnDef;
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
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton RefeshBT1;
    }
}