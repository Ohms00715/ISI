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
    public partial class REP106Quality_Control_StatusForm : Form
    {
        SqlMasterManegerStatus _SqlMasterManager6 = null;
        DataTable _dtStatus = null;
        DataRow dr;
        string _connStr = "";
        string _userID = "";


        public REP106Quality_Control_StatusForm(string connStr, string userID)
        {
            InitializeComponent();
            this._connStr = connStr;
            this._userID = userID;
            this._SqlMasterManager6 = new SqlMasterManegerStatus(this._connStr, this._userID);
            this._dtStatus = new DataTable();
            this._dtStatus = this._SqlMasterManager6.GetISI_StatusList();

            this.setReport();


        }

        private void setReport()
        {
            //this.bdsRpt100.DataSource = _dtSuppiler;
            ReportDataSource datasource6 = new ReportDataSource("DataSet1", _dtStatus);

            this.reportViewer1.LocalReport.DataSources.Clear();

            this.reportViewer1.LocalReport.DataSources.Add(datasource6);

            this.reportViewer1.RefreshReport();
            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            


        }

        private void REP106Quality_Control_StatusForm_Load(object sender, EventArgs e)
        {

        }
    }
}
