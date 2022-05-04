using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using ISI.Maneger;


namespace ISI.Window
{
    public partial class REP103Quality_CheckForm : Form
    {
        SqlMasterManegerQC _SqlMasterManager3 = null;
        DataTable _dtQuality_Check = null;
        DataRow dr;
        string _connStr = "";
        string _userID = "";
        public REP103Quality_CheckForm(string connStr, string userID)
        {
            InitializeComponent();
            this._connStr = connStr;
            this._userID = userID;
            this._SqlMasterManager3 = new SqlMasterManegerQC(this._connStr, this._userID);
            this._dtQuality_Check = new DataTable();
            this._dtQuality_Check = this._SqlMasterManager3.GetISI_Quality_CheckList();

            this.setReport();
        }

        private void setReport()
        {
            //this.bdsRpt100.DataSource = _dtSuppiler;

            #region
            ReportDataSource datasource3 = new ReportDataSource("DataSet1", _dtQuality_Check);

            #endregion
            this.reportViewer1.LocalReport.DataSources.Clear();

            #region
            this.reportViewer1.LocalReport.DataSources.Add(datasource3);

            #endregion
            this.reportViewer1.RefreshReport();
            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
      


        }

        private void REP103Quality_CheckForm_Load(object sender, EventArgs e)
        {

        }

    }
}
