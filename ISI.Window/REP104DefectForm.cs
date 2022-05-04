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
    public partial class REP104DefectForm : Form
    { 
        
      

        SqlMasterManegerDEF _SqlMasterManager4 = null;
        DataTable _dtDefect = null;
        public string _connStr = "";
        public string _userID = "";
       
        public REP104DefectForm(string connStr, string userID)
        {
            InitializeComponent();
             this._connStr = connStr;
            this._userID = userID;
            
       
          
            this._SqlMasterManager4 = new SqlMasterManegerDEF(this._connStr, this._userID);
            this._dtDefect = new DataTable();
            this._dtDefect = this._SqlMasterManager4.GetISI_DefectList();

          
            
            this.setReport();

        }

         private void setReport() 
        {
            //this.bdsRpt100.DataSource = _dtSuppiler;
           
         
            ReportDataSource datasource4 = new ReportDataSource("DataSet1", _dtDefect);
           
        
            this.reportViewer1.LocalReport.DataSources.Clear();
           
          
            this.reportViewer1.LocalReport.DataSources.Add(datasource4);
            
   
            this.reportViewer1.RefreshReport();
            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
      

        }

      
         

       
       
    }
}
