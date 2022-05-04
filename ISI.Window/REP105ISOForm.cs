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
    public partial class REP105ISOForm : Form
    {
        SqlMasterManegerISO _SqlMasterManager5 = null;
        DataTable _dtISO = null;
        DataRow dr;
        string _connStr = "";
        string _userID = "";
        
     
        
        public REP105ISOForm(string connStr, string userID)
        {
            InitializeComponent();

             this._connStr = connStr;
            this._userID = userID;
            this._SqlMasterManager5 = new SqlMasterManegerISO(this._connStr, this._userID);
            this._dtISO = new DataTable();
            this._dtISO = this._SqlMasterManager5.GetISI_ISOList();

            this.setReport();

        }

        private void setReport()
        {
            //this.bdsRpt100.DataSource = _dtSuppiler;
            ReportDataSource datasource5 = new ReportDataSource("DataSet1", _dtISO);

            this.reportViewer1.LocalReport.DataSources.Clear();

            this.reportViewer1.LocalReport.DataSources.Add(datasource5);

            this.reportViewer1.RefreshReport();
            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);


        }

        private void REP105ISOForm_Load(object sender, EventArgs e)
        {

        }






       
   
    
    }
}
