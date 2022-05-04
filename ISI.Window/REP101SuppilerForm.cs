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
    public partial class REP101SuppilerForm : Form
    {
        SqlMasterManeger _SqlMasterManager = null;
        DataTable _dtSuppiler = null;
        #region 
        SqlMasterManegerDEF _SqlMasterManager4 = null;
        DataTable _dtDefect = null;
        DataTable _dtIncomming = null;
        #endregion
        public string _connStr = "";
        public string _userID = "";
        public REP101SuppilerForm(string connStr, string userID)
        {
            InitializeComponent();
            this._connStr = connStr;
            this._userID = userID;
            this._dtSuppiler = new DataTable();
            this._SqlMasterManager = new SqlMasterManeger(this._connStr, this._userID);
            this._dtSuppiler = this._SqlMasterManager.GetISI_SupplierList();

           #region
            _dtIncomming = new DataTable();
            this._SqlMasterManager4 = new SqlMasterManegerDEF(this._connStr, this._userID);
            this._dtDefect = new DataTable();
            this._dtDefect = this._SqlMasterManager4.GetISI_DefectList();
            this._dtIncomming = this._SqlMasterManager.GetISI_IncommingList();
           #endregion

            this.setReport();
        }

  
        private void setReport() 
        {
            this.bdsRpt100.DataSource = _dtSuppiler;
            ReportDataSource datasource = new ReportDataSource("SUP112", _dtSuppiler);
            #region
            ReportDataSource datasource2 = new ReportDataSource("DataSet1", _dtDefect);
            ReportDataSource datasource3 = new ReportDataSource("Incomming", _dtIncomming);
            #endregion
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(datasource);
            #region
            this.reportViewer1.LocalReport.DataSources.Add(datasource2);
            this.reportViewer1.LocalReport.DataSources.Add(datasource3);
            #endregion
            this.reportViewer1.RefreshReport();
            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
      

        }

        //private DataTable GetData()
        //{
        //    System.Data.DataTable DT = new System.Data.DataTable("SUP");
        //    DataRow dr;

        //    DT.Columns.Add("Sup_Id", typeof(string));
        //    DT.Columns.Add("Sup_Desc", typeof(string));
        //    dr = DT.NewRow();
        //    dr["Sup_Id"] = "[1]";
        //    dr["Sup_Desc"] = "[2]";
        //    DT.Rows.Add(dr);
        //    dr = DT.NewRow();
        //    dr["Sup_Id"] = "[Sup_ID]";
        //    dr["Sup_Desc"] = "[Sup_ID]";
           

        //    return DT;

        //    //string constr = @"Data Source=.\Sql2005;Initial Catalog=Northwind;Integrated Security = true";
        //    //using (SqlConnection con = new SqlConnection(constr))
        //    //{
        //    //    using (SqlCommand cmd = new SqlCommand("SELECT TOP 20 * FROM customers"))
        //    //    {
        //    //        using (SqlDataAdapter sda = new SqlDataAdapter())
        //    //        {
        //    //            cmd.Connection = con;
        //    //            sda.SelectCommand = cmd;
        //    //            using (Customers dsCustomers = new Customers())
        //    //            {
        //    //                sda.Fill(dsCustomers, "DataTable1");
        //    //                return dsCustomers;
        //    //            }
        //    //        }
        //    //    }
        //    //}
        //}

        private void button1_Click(object sender, EventArgs e)
       
        {

            //DataTable dt = GetData();
            //this.bdsRpt100.DataSource = dt;
            //ReportDataSource datasource = new ReportDataSource("SUP112", dt);
            ////ReportDataSource datasource = new ReportDataSource("SUP112", dt);
            ////ReportDataSource datasource = new ReportDataSource("ISIReport", dt);
            //this.reportViewer1.LocalReport.DataSources.Clear();
            //this.reportViewer1.LocalReport.DataSources.Add(datasource);
            
            ////this.DataSet1BindingSource.DataSource = dt;
            //dataGridView1.DataSource =  this.bdsRpt100;
            ////this.reportViewer1..DataBindings = this.bdsRpt100;
            //this.reportViewer1.RefreshReport();
        }

        private void REP101SuppilerForm_Load(object sender, EventArgs e)
        {

        }

    }
}
