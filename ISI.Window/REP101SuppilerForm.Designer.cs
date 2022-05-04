namespace ISI.Window
{
    partial class REP101SuppilerForm
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.pnlData = new System.Windows.Forms.Panel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ucBottom1 = new ISI.Window.UCBottom();
            this.ucPagecs1 = new ISI.Window.UCPagecs();
            this.ucTopl11 = new ISI.Window.UCTopl1();
            this.pnlHead = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.bdsRpt100 = new System.Windows.Forms.BindingSource(this.components);
            this.pnlData.SuspendLayout();
            this.pnlHead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsRpt100)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlData
            // 
            this.pnlData.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.pnlData.Controls.Add(this.reportViewer1);
            this.pnlData.Controls.Add(this.ucBottom1);
            this.pnlData.Controls.Add(this.ucPagecs1);
            this.pnlData.Controls.Add(this.ucTopl11);
            this.pnlData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlData.Location = new System.Drawing.Point(0, 52);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(1924, 1003);
            this.pnlData.TabIndex = 2;
            // 
            // reportViewer1
            // 
            this.reportViewer1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "SUP112";
            reportDataSource1.Value = null;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = null;
            reportDataSource3.Name = "Incomming";
            reportDataSource3.Value = null;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ISI.Window.ReportSUP.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 40);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ShowBackButton = false;
            this.reportViewer1.Size = new System.Drawing.Size(1924, 888);
            this.reportViewer1.TabIndex = 3;
            this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // ucBottom1
            // 
            this.ucBottom1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucBottom1.Location = new System.Drawing.Point(0, 928);
            this.ucBottom1.Name = "ucBottom1";
            this.ucBottom1.Size = new System.Drawing.Size(1924, 40);
            this.ucBottom1.TabIndex = 2;
            // 
            // ucPagecs1
            // 
            this.ucPagecs1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucPagecs1.Location = new System.Drawing.Point(0, 968);
            this.ucPagecs1.Name = "ucPagecs1";
            this.ucPagecs1.Size = new System.Drawing.Size(1924, 35);
            this.ucPagecs1.TabIndex = 1;
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
            // pnlHead
            // 
            this.pnlHead.BackColor = System.Drawing.Color.YellowGreen;
            this.pnlHead.Controls.Add(this.label1);
            this.pnlHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHead.Location = new System.Drawing.Point(0, 0);
            this.pnlHead.Name = "pnlHead";
            this.pnlHead.Size = new System.Drawing.Size(1924, 52);
            this.pnlHead.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.ForestGreen;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1924, 52);
            this.label1.TabIndex = 5;
            this.label1.Text = "Suppiler Report";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // REP101SuppilerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.pnlData);
            this.Controls.Add(this.pnlHead);
            this.Name = "REP101SuppilerForm";
            this.Text = "REP101SuppilerForm";
            this.Load += new System.EventHandler(this.REP101SuppilerForm_Load);
            this.pnlData.ResumeLayout(false);
            this.pnlHead.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bdsRpt100)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

       
        private System.Windows.Forms.Panel pnlData;
        private UCBottom ucBottom1;
        private UCPagecs ucPagecs1;
        private UCTopl1 ucTopl11;
        private System.Windows.Forms.Panel pnlHead;
        private System.Windows.Forms.Label label1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        protected System.Windows.Forms.BindingSource bdsRpt100;
        private Report.DataSet12 dataSet121;
       
    }
}