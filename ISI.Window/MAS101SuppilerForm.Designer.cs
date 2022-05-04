namespace ISI.Window
{
    partial class MAS101SuppilerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAS101SuppilerForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxSubID = new System.Windows.Forms.TextBox();
            this.textBoxSUBName = new System.Windows.Forms.TextBox();
            this.checkBoxSUBAct = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bdnSuppi = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.panelH = new System.Windows.Forms.Panel();
            this.ucTopl12 = new ISI.Window.UCTopl1();
            this.dgvSup = new System.Windows.Forms.DataGridView();
            this.bdsSup = new System.Windows.Forms.BindingSource(this.components);
            this.ucBottom1 = new ISI.Window.UCBottom();
            this.ucPagecs2 = new ISI.Window.UCPagecs();
            this.ucPagecs1 = new ISI.Window.UCPagecs();
            this.ucTopl11 = new ISI.Window.UCTopl1();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdnSuppi)).BeginInit();
            this.bdnSuppi.SuspendLayout();
            this.panelH.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsSup)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.ForestGreen;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.label1, "label1");
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // textBoxSubID
            // 
            resources.ApplyResources(this.textBoxSubID, "textBoxSubID");
            this.textBoxSubID.Name = "textBoxSubID";
            // 
            // textBoxSUBName
            // 
            resources.ApplyResources(this.textBoxSUBName, "textBoxSUBName");
            this.textBoxSUBName.Name = "textBoxSUBName";
            // 
            // checkBoxSUBAct
            // 
            resources.ApplyResources(this.checkBoxSUBAct, "checkBoxSUBAct");
            this.checkBoxSUBAct.Name = "checkBoxSUBAct";
            this.checkBoxSUBAct.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bdnSuppi);
            this.panel1.Controls.Add(this.textBoxSubID);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.checkBoxSUBAct);
            this.panel1.Controls.Add(this.textBoxSUBName);
            this.panel1.Controls.Add(this.label3);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // bdnSuppi
            // 
            this.bdnSuppi.AddNewItem = this.ADD;
            this.bdnSuppi.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.bdnSuppi.CountItem = this.bindingNavigatorCountItem;
            this.bdnSuppi.DeleteItem = this.DEL;
            this.bdnSuppi.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            resources.ApplyResources(this.bdnSuppi, "bdnSuppi");
            this.bdnSuppi.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bdnSuppi.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bdnSuppi.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bdnSuppi.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bdnSuppi.Name = "bdnSuppi";
            this.bdnSuppi.PositionItem = this.bindingNavigatorPositionItem;
            // 
            // ADD
            // 
            this.ADD.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.ADD, "ADD");
            this.ADD.Name = "ADD";
            this.ADD.Click += new System.EventHandler(this.bindingNavigatorAddNewItem_Click_1);
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            resources.ApplyResources(this.bindingNavigatorCountItem, "bindingNavigatorCountItem");
            // 
            // DEL
            // 
            this.DEL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.DEL, "DEL");
            this.DEL.Name = "DEL";
            this.DEL.Click += new System.EventHandler(this.bindingNavigatorDeleteItem_Click);
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.bindingNavigatorMoveFirstItem, "bindingNavigatorMoveFirstItem");
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.Click += new System.EventHandler(this.bindingNavigatorMoveFirstItem_Click);
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.bindingNavigatorMovePreviousItem, "bindingNavigatorMovePreviousItem");
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.Click += new System.EventHandler(this.bindingNavigatorMovePreviousItem_Click);
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            resources.ApplyResources(this.bindingNavigatorSeparator, "bindingNavigatorSeparator");
            // 
            // bindingNavigatorPositionItem
            // 
            resources.ApplyResources(this.bindingNavigatorPositionItem, "bindingNavigatorPositionItem");
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            resources.ApplyResources(this.bindingNavigatorSeparator1, "bindingNavigatorSeparator1");
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.bindingNavigatorMoveNextItem, "bindingNavigatorMoveNextItem");
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.Click += new System.EventHandler(this.bindingNavigatorMoveNextItem_Click);
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.bindingNavigatorMoveLastItem, "bindingNavigatorMoveLastItem");
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.Click += new System.EventHandler(this.bindingNavigatorMoveLastItem_Click);
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            resources.ApplyResources(this.bindingNavigatorSeparator2, "bindingNavigatorSeparator2");
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // tsbSave
            // 
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSave.Image = global::ISI.Window.Properties.Resources.Save;
            this.tsbSave.Name = "tsbSave";
            resources.ApplyResources(this.tsbSave, "tsbSave");
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // RefeshBT1
            // 
            this.RefeshBT1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RefeshBT1.Image = global::ISI.Window.Properties.Resources.computer_icons_clip_art_png_favpng_M070FyPc8TCR8X7L1JpvGcVe3_t;
            resources.ApplyResources(this.RefeshBT1, "RefeshBT1");
            this.RefeshBT1.Name = "RefeshBT1";
            this.RefeshBT1.Click += new System.EventHandler(this.RefeshBT1_Click);
            // 
            // panelH
            // 
            this.panelH.Controls.Add(this.ucTopl12);
            resources.ApplyResources(this.panelH, "panelH");
            this.panelH.Name = "panelH";
            // 
            // ucTopl12
            // 
            this.ucTopl12._MAS101SuppilerForm = null;
            resources.ApplyResources(this.ucTopl12, "ucTopl12");
            this.ucTopl12.Name = "ucTopl12";
            this.ucTopl12.Load += new System.EventHandler(this.ucTopl12_Load);
            // 
            // dgvSup
            // 
            this.dgvSup.AllowUserToAddRows = false;
            this.dgvSup.AllowUserToDeleteRows = false;
            this.dgvSup.BackgroundColor = System.Drawing.SystemColors.ButtonShadow;
            this.dgvSup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dgvSup, "dgvSup");
            this.dgvSup.Name = "dgvSup";
            this.dgvSup.ReadOnly = true;
            this.dgvSup.RowTemplate.Height = 24;
            // 
            // ucBottom1
            // 
            resources.ApplyResources(this.ucBottom1, "ucBottom1");
            this.ucBottom1.Name = "ucBottom1";
            // 
            // ucPagecs2
            // 
            resources.ApplyResources(this.ucPagecs2, "ucPagecs2");
            this.ucPagecs2.Name = "ucPagecs2";
            // 
            // ucPagecs1
            // 
            resources.ApplyResources(this.ucPagecs1, "ucPagecs1");
            this.ucPagecs1.Name = "ucPagecs1";
            // 
            // ucTopl11
            // 
            this.ucTopl11._MAS101SuppilerForm = null;
            resources.ApplyResources(this.ucTopl11, "ucTopl11");
            this.ucTopl11.Name = "ucTopl11";
            // 
            // MAS101SuppilerForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.dgvSup);
            this.Controls.Add(this.ucBottom1);
            this.Controls.Add(this.ucPagecs2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelH);
            this.Controls.Add(this.ucPagecs1);
            this.Controls.Add(this.ucTopl11);
            this.Controls.Add(this.label1);
            this.Name = "MAS101SuppilerForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdnSuppi)).EndInit();
            this.bdnSuppi.ResumeLayout(false);
            this.bdnSuppi.PerformLayout();
            this.panelH.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsSup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private UCTopl1 ucTopl11;
        private UCPagecs ucPagecs1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxSubID;
        private System.Windows.Forms.TextBox textBoxSUBName;
        private System.Windows.Forms.CheckBox checkBoxSUBAct;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelH;
        private System.Windows.Forms.BindingNavigator bdnSuppi;
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
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.BindingSource bdsSup;
        private UCPagecs ucPagecs2;
        private UCBottom ucBottom1;
        private System.Windows.Forms.DataGridView dgvSup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton RefeshBT1;
        private UCTopl1 ucTopl12;








    }
}