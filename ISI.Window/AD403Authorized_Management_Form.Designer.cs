namespace ISI.Window
{
    partial class AD403Authorized_Management_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AD403Authorized_Management_Form));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bdnADAU = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.RefeshBT1 = new System.Windows.Forms.ToolStripButton();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxLName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxFNAME = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.dgvADAU = new System.Windows.Forms.DataGridView();
            this.bdsADAU = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.paneldgv = new System.Windows.Forms.Panel();
            this.ucPagecs1 = new ISI.Window.UCPagecs();
            this.ucPagecs2 = new ISI.Window.UCPagecs();
            this.ucTopl11 = new ISI.Window.UCTopl1();
            ((System.ComponentModel.ISupportInitialize)(this.bdnADAU)).BeginInit();
            this.bdnADAU.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvADAU)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsADAU)).BeginInit();
            this.paneldgv.SuspendLayout();
            this.SuspendLayout();
            // 
            // bdnADAU
            // 
            this.bdnADAU.AddNewItem = null;
            this.bdnADAU.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.bdnADAU.CountItem = this.bindingNavigatorCountItem;
            this.bdnADAU.DeleteItem = null;
            this.bdnADAU.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.tsbSave,
            this.toolStripSeparator2,
            this.RefeshBT1});
            this.bdnADAU.Location = new System.Drawing.Point(0, 0);
            this.bdnADAU.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bdnADAU.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bdnADAU.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bdnADAU.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bdnADAU.Name = "bdnADAU";
            this.bdnADAU.PositionItem = this.bindingNavigatorPositionItem;
            this.bdnADAU.Size = new System.Drawing.Size(1924, 27);
            this.bdnADAU.TabIndex = 13;
            this.bdnADAU.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(45, 24);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 24);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 24);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
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
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 24);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 27);
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
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(-81, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 48);
            this.label2.TabIndex = 93;
            this.label2.Text = "ID :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.textBoxEmail);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.textBoxLName);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBoxFNAME);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.txtUserID);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.bdnADAU);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1924, 137);
            this.panel1.TabIndex = 39;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Enabled = false;
            this.textBoxEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxEmail.Location = new System.Drawing.Point(1561, 50);
            this.textBoxEmail.MaxLength = 50;
            this.textBoxEmail.Multiline = true;
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(323, 30);
            this.textBoxEmail.TabIndex = 118;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(1442, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 48);
            this.label5.TabIndex = 117;
            this.label5.Text = "Email :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxLName
            // 
            this.textBoxLName.Enabled = false;
            this.textBoxLName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxLName.Location = new System.Drawing.Point(1113, 47);
            this.textBoxLName.MaxLength = 24;
            this.textBoxLName.Multiline = true;
            this.textBoxLName.Name = "textBoxLName";
            this.textBoxLName.Size = new System.Drawing.Size(323, 30);
            this.textBoxLName.TabIndex = 116;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(903, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(213, 37);
            this.label4.TabIndex = 115;
            this.label4.Text = "Last Name :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxFNAME
            // 
            this.textBoxFNAME.Enabled = false;
            this.textBoxFNAME.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxFNAME.Location = new System.Drawing.Point(559, 50);
            this.textBoxFNAME.MaxLength = 24;
            this.textBoxFNAME.Multiline = true;
            this.textBoxFNAME.Name = "textBoxFNAME";
            this.textBoxFNAME.Size = new System.Drawing.Size(323, 30);
            this.textBoxFNAME.TabIndex = 114;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(373, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(193, 48);
            this.label3.TabIndex = 113;
            this.label3.Text = "First Name :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(300, 53);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 30);
            this.button1.TabIndex = 112;
            this.button1.Text = "....";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtUserID
            // 
            this.txtUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtUserID.Location = new System.Drawing.Point(118, 53);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.ReadOnly = true;
            this.txtUserID.Size = new System.Drawing.Size(176, 30);
            this.txtUserID.TabIndex = 111;
            // 
            // dgvADAU
            // 
            this.dgvADAU.AllowUserToAddRows = false;
            this.dgvADAU.AllowUserToDeleteRows = false;
            this.dgvADAU.BackgroundColor = System.Drawing.SystemColors.ButtonShadow;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvADAU.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvADAU.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvADAU.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvADAU.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvADAU.Location = new System.Drawing.Point(0, 0);
            this.dgvADAU.Name = "dgvADAU";
            this.dgvADAU.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvADAU.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvADAU.RowTemplate.Height = 24;
            this.dgvADAU.Size = new System.Drawing.Size(1924, 831);
            this.dgvADAU.TabIndex = 42;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.ForestGreen;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1924, 52);
            this.label1.TabIndex = 36;
            this.label1.Text = "Admin Authorize Data Management";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // paneldgv
            // 
            this.paneldgv.Controls.Add(this.dgvADAU);
            this.paneldgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paneldgv.Location = new System.Drawing.Point(0, 189);
            this.paneldgv.Name = "paneldgv";
            this.paneldgv.Size = new System.Drawing.Size(1924, 831);
            this.paneldgv.TabIndex = 43;
            // 
            // ucPagecs1
            // 
            this.ucPagecs1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPagecs1.Location = new System.Drawing.Point(0, 0);
            this.ucPagecs1.Name = "ucPagecs1";
            this.ucPagecs1.Size = new System.Drawing.Size(1924, 1020);
            this.ucPagecs1.TabIndex = 38;
            // 
            // ucPagecs2
            // 
            this.ucPagecs2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucPagecs2.Location = new System.Drawing.Point(0, 1020);
            this.ucPagecs2.Name = "ucPagecs2";
            this.ucPagecs2.Size = new System.Drawing.Size(1924, 35);
            this.ucPagecs2.TabIndex = 40;
            // 
            // ucTopl11
            // 
            this.ucTopl11._MAS101SuppilerForm = null;
            this.ucTopl11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTopl11.Location = new System.Drawing.Point(0, 0);
            this.ucTopl11.Name = "ucTopl11";
            this.ucTopl11.Size = new System.Drawing.Size(1924, 1055);
            this.ucTopl11.TabIndex = 37;
            // 
            // AD403Authorized_Management_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.paneldgv);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ucPagecs1);
            this.Controls.Add(this.ucPagecs2);
            this.Controls.Add(this.ucTopl11);
            this.Name = "AD403Authorized_Management_Form";
            this.Text = "AD403Authorized_Management_Form";
            ((System.ComponentModel.ISupportInitialize)(this.bdnADAU)).EndInit();
            this.bdnADAU.ResumeLayout(false);
            this.bdnADAU.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvADAU)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsADAU)).EndInit();
            this.paneldgv.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingNavigator bdnADAU;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton RefeshBT1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvADAU;
        private System.Windows.Forms.BindingSource bdsADAU;
        private UCPagecs ucPagecs1;
        private UCPagecs ucPagecs2;
        private System.Windows.Forms.Label label1;
        private UCTopl1 ucTopl11;
        private System.Windows.Forms.Panel paneldgv;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxFNAME;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxLName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxEmail;

    }
}