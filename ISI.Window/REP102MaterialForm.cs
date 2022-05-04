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
    public partial class REP102MaterialForm : Form
    {
        SqlMasterManegerMAT _SqlMasterManager2 = null;
        DataTable _dtMaterial = null;
        DataRow dr;
        string _connStr = "";
        string _userID = "";
        public REP102MaterialForm(string connStr, string userID)
        {
            InitializeComponent();
            this._connStr = connStr;
            this._userID = userID;
            this._SqlMasterManager2 = new SqlMasterManegerMAT(this._connStr, this._userID);
            this._dtMaterial = new DataTable();
            this._dtMaterial = this._SqlMasterManager2.GetISI_MaterialList();

            this.setReport(); 
         
        }

     

        private void setReport()
        {
            //this.bdsRpt100.DataSource = _dtSuppiler;

            #region
            ReportDataSource datasource2 = new ReportDataSource("DataSet1", _dtMaterial);

            #endregion
            this.reportViewer1.LocalReport.DataSources.Clear();

            #region
            this.reportViewer1.LocalReport.DataSources.Add(datasource2);

            #endregion
            this.reportViewer1.RefreshReport();
            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);


        }

        private void REP102MaterialForm_Load(object sender, EventArgs e)
        {

        }

        
    }
}
