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
using System.IO;


namespace ISI.Window
{
    public partial class REP107Incoming_Scrap_InspectionForm : Form
    {
        DataSet _dsCob = null;
        string _connStr = "";
        string _userID = "";
        SqlTransactionManager _SqlTransactionManager = null;
        DataTable _dtData = null;
        DataTable _dtDataM = null;
        DataTable _dtDataSelect = null;
        string _1 = null;
        string _2 = null;
        string _3 = null;
        string _4 = null;
        string _5 = null;
        string _6 = null;
        string _7 = null;
        string _8 = null;
        string _9 = null;
        string _10 = null;
        string _11 = null;
        string _12 = null;
        //string _13 = null;
        //string _14 = null;
        //string _15 = null;

        DateTime d = DateTime.Now;
        DataSet _dsData3 = null;
        string strDocId = "01";
       
       
        public REP107Incoming_Scrap_InspectionForm(string connStr, string userID)
        {
            InitializeComponent();
            this._connStr = connStr;
            this._userID = userID;
            SetDTP();
            this._SqlTransactionManager = new SqlTransactionManager(this._connStr, this._userID);
            this._dsCob = new DataSet();
            this._dsCob = this._SqlTransactionManager.GetISI_ComboboxList();
            this._dtData = new DataTable();

            //this._dtData = this._SqlTransactionManager.GetISI_Report("");
            this.setCombobox();
            this._dtDataM = new DataTable();
            this.getData(strDocId);
           
        }
        private void SetDTP()
        {
            this.dtpTimeForm.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            this.dtpTimeTo.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
            dtpTimeForm.Format = DateTimePickerFormat.Custom;
            dtpTimeForm.CustomFormat = " ";
            dtpTimeTo.Format = DateTimePickerFormat.Custom;
            dtpTimeTo.CustomFormat = " ";
        }
        private bool button1WasClicked = false;
        private bool button1WasClicked2 = false;
        private void setCombobox()
        {
            #region SUP

            {
                DataView dv;
                DataTable dt = this._dsCob.Tables["ISI_Supplier"];
                DataRow dr = dt.NewRow();
                dr["Sup_ID"] = "0";
                dr["Sup_Desc"] = "- All -";
                dt.Rows.Add(dr);
                dv = dt.DefaultView;
                dv.Sort = "Sup_ID  asc";
                this.CBSUP.DataSource = dv;
                this.CBSUP.DisplayMember = "Sup_Desc";
                this.CBSUP.ValueMember = "Sup_Desc";

            }
            #endregion

            #region MAT
            {
                DataView dv;
                DataTable dt = this._dsCob.Tables["ISI_Material"];
                DataRow dr = dt.NewRow();
                dr["Mat_Code"] = "0";
                dr["Mat_Desc"] = "- All -";
                dt.Rows.Add(dr);
                dv = dt.DefaultView;
                dv.Sort = "Mat_Code  asc";
                this.CBMAT.DataSource = dv;
                this.CBMAT.DisplayMember = "Mat_Desc";
                this.CBMAT.ValueMember = "Mat_Code";
            }
            #endregion

            #region STT
            {
                DataView dv;
                DataTable dt = this._dsCob.Tables["ISI_Quality_Control_Status"];
                DataRow dr = dt.NewRow();
                dr["Status_ID"] = "0";
                dr["Status_Desc"] = "- All -";
                dt.Rows.Add(dr);
                dv = dt.DefaultView;
                dv.Sort = "Status_ID  asc";
                this.CBStatus.DataSource = dv;
                this.CBStatus.DisplayMember = "Status_Desc";
                this.CBStatus.ValueMember = "Status_ID";
            }
            #endregion

            #region QC

            {
            //dt.Copy().Select("QC_For_Appproved = 1").CopyToDataTable()
                string expressionQC = "QC_For_Create = 1";
                string expressionAPP = "QC_For_Appproved = 1";
                DataView dv;
                DataView dv2;
                DataTable dt = this._dsCob.Tables["ISI_Quality_Check"].Select(expressionQC).CopyToDataTable();
                DataTable dt2 = this._dsCob.Tables["ISI_Quality_Check"].Select(expressionAPP).CopyToDataTable();
                DataRow dr = dt.NewRow();
                DataRow dr2 = dt2.NewRow();
                dr["QC_ID"] = "0";
                dr["QC_First_Name"] = "- All -";
                dr2["QC_ID"] = "0";
                dr2["QC_First_Name"] = "- All -";
                dt.Rows.Add(dr);
                dv = dt.DefaultView;
                dv.Sort = "QC_ID  asc";
                dt2.Rows.Add(dr2);
                dv2 = dt2.DefaultView;
                dv2.Sort = "QC_ID  asc";

                this.CBInspec.DataSource = dv;
                this.CBInspec.DisplayMember = "QC_First_Name";
                this.CBInspec.ValueMember = "QC_ID";


                this.CBAPP.DataSource = dv2;
                this.CBAPP.DisplayMember = "QC_First_Name";
                this.CBAPP.ValueMember = "QC_ID";

               
                this.CBAPPS.DataSource = dv2;
                this.CBAPPS.DisplayMember = "QC_First_Name";
                this.CBAPPS.ValueMember = "QC_ID";

                

            }
            #endregion

        }
        private void setReport(DataTable dt)
        {
            ReportDataSource datasource8 = new ReportDataSource("DataSet1", dt);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(datasource8);
            this.reportViewer1.LocalReport.EnableExternalImages = true;
            this.reportViewer1.RefreshReport();
            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);  
        }
        private void setReportCHT()
        {
           
            //this._dtDataM = this._SqlTransactionManager.GetISI_ReportM("", "", "","", "","Pass","", "","","","","","","","");
            ReportDataSource datasource9 = new ReportDataSource("DataSetISI", _dtDataM);
            this.reportViewer2.LocalReport.DataSources.Clear();
            this.reportViewer2.LocalReport.DataSources.Add(datasource9);
            this.reportViewer2.LocalReport.EnableExternalImages = true;
            this.reportViewer2.RefreshReport();
            this.reportViewer2.SetDisplayMode(DisplayMode.PrintLayout);
        }

        private void RefreshData()
        {
            if (this._dtDataM != null)
            {
                this._dtDataM.Rows.Clear();
            }
        }
      

        private void getData(string paraDocID)
        {
            this.RefreshData();
            this._dtDataM = this._SqlTransactionManager.GetISI_ReportM(paraDocID,"","","","","","","","","","","");
            this.setReport(this._dtDataM);
        }
       
        private void FilterData(string paraDocID2, string paraTruck, string paraPO, string paraSUP, string paraMAT, string paraStatus, string paraInspec, string paraApproved, string paraApprovedS, string paraINTime, string paraOutTime, string paraNetTime)
        {
            this.RefreshData();
            this._dtDataM = this._SqlTransactionManager.GetISI_ReportM(paraDocID2, paraTruck, paraPO, paraSUP, paraMAT, paraStatus, paraInspec, paraApproved, paraApprovedS, paraINTime, paraOutTime, paraNetTime);
            this.setReport(this._dtDataM);
        }
        private void FilterDataS(string paraDocID2, string paraTruck, string paraPO, string paraSUP, string paraMAT, string paraStatus, string paraInspec, string paraApproved, string paraApprovedS, string paraINTime, string paraOutTime, string paraNetTime)
        {
            this.RefreshData();
            this._dtDataM = this._SqlTransactionManager.GetISI_ReportM(paraDocID2, paraTruck, paraPO, paraSUP, paraMAT, paraStatus, paraInspec, paraApproved, paraApprovedS, paraINTime, paraOutTime, paraNetTime);
            this.setReportCHT();
        }
        

        //View all
        private void buttonViewALL_Click(object sender, EventArgs e)
        {
            button1WasClicked = true;
            this.getData("");
        }
        //Select View 
        private void buttonSelectView_Click(object sender, EventArgs e)
        {
            ReportViewForm form_ = new ReportViewForm(this._connStr);
             if (form_.ShowDialog() == System.Windows.Forms.DialogResult.OK)
             {
                 //_dtDataSelect.Rows.Clear();
                 button1WasClicked2 = true;
                 this.getData(form_.DocumenKeys);

                     //Doc_ID ส่งไปในหน้า sqltransaction ค่าจากหน้า ReportForm
                   //this._dtDataSelect = this._SqlTransactionManager.GetISI_ReportSelect(form_.DocumenKeys);
                   // Doc_IDส่งไปในหน้า sqltransaction ค่าจากหน้า ReportForm

                    
                 
             }
        }
        private void SetNewDoc()
        {
             d =  DateTime.Now;
        }
        
        private void Refresh_Report_Click(object sender, EventArgs e)
        {
            if (button1WasClicked && button1WasClicked == false)
            {
                this.getData("");
            }
            if (button1WasClicked2 && button1WasClicked == false)
            {
                ReportViewForm form_ = new ReportViewForm(this._connStr);
                 if (form_.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                 this.getData(form_.DocumenKeys);   
                 }
                 
            }
            else 
            {
                reportViewer1.RefreshReport();
            }
            
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            this.dtpTimeForm.CustomFormat = "dd/MMM/yyyy"; 
            this.dtpTimeTo.CustomFormat = "dd/MMM/yyyy";
            string TimeForm = null;
            string TimeTo = null;
            TimeForm = dtpTimeForm.Value.ToString("dd/MM/yyyy");
            TimeTo = dtpTimeTo.Value.ToString("dd/MM/yyyy");
            

            if (checkedListBox1.SelectedIndex == 0)
            {
                
                this.dtpTimeForm.Enabled = true;
                INTIME += "and (Trn_Weight_IN_Time between ";
                INTIME += "\t";
                INTIME += TimeForm;
                INTIME += "\t";
                INTIME += "and ";
                INTIME += "\t";
                INTIME += TimeTo;
                INTIME += "\t";
                INTIME += ")";
            }
            if (checkedListBox1.SelectedIndex == 2)
            {
              
                this.dtpTimeForm.Enabled = true;
                OUTTIME += "and (Trn_Weight_OUT_Time between ";
                OUTTIME += "\t";
                OUTTIME += TimeForm;
                OUTTIME += "\t";
                OUTTIME += "and ";
                OUTTIME += "\t";
                OUTTIME += TimeTo;
                OUTTIME += "\t"; 
                OUTTIME += ")";
            }
            if (checkedListBox1.SelectedIndex == 1)
            {
                
                this.dtpTimeForm.Enabled = true;
                NETTIME += "and (Trn_Weight_Net_Time between ";
                NETTIME += "\t"; ;
                NETTIME += TimeForm;
                NETTIME += "\t"; 
                NETTIME += "and ";
                NETTIME += "\t"; 
                NETTIME += TimeTo;
                NETTIME += "\t"; 
                NETTIME += ")";
            }

        }

        #region propotile
        public string Doc
        {
            get { return _1; }
            set { _1 = value; }
        }
        public string Truck
        {
            get { return _2; }
            set { _2 = value; }
        }
        public string PO
        {
            get { return _3; }
            set { _3 = value; }
        }
        public string SUP
        {
            get { return _4; }
            set { _4 = value; }
        }

        public string MAT
        {
            get { return _5; }
            set { _5 = value; }
        }
        public string Status
        {
            get { return _6; }
            set { _6 = value; }
        }

        public string Inspec
        {
            get { return _7; }
            set { _7 = value; }
        }
        public string Approved
        {
            get { return _8; }
            set { _8 = value; }
        }
        public string ApprovedS
        {
            get { return _9; }
            set { _9 = value; }
        }

        public string INTIME
        {
            get { return _10; }
            set { _10 = value; }

        }

        public string OUTTIME
        {
            get { return _11; }
            set { _11 = value; }

        }
        public string NETTIME
        {
            get { return _12; }
            set { _12 = value; }

        }
        //public string WeightIN
        //{
        //    get { return _13; }
        //    set { _13 = value; }
        //}
        //public string WeightOUT
        //{
        //    get { return _14; }
        //    set { _14 = value; }

        //}
        //public string WeightNET
        //{
        //    get { return _15; }
        //    set { _15 = value; }

        //}
        #endregion

        private void dtpTimeForm_EnabledChanged(object sender, EventArgs e)
        {
            if (dtpTimeForm.Enabled == true)
            {
                dtpTimeTo.Enabled = true;
            }
            else
            {
                dtpTimeTo.Enabled = false;
            }
            
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            List<string> checkedItems = new List<string>();
            foreach (var item in checkedListBox1.CheckedItems)
                checkedItems.Add(item.ToString());
            {
                if (e.NewValue == CheckState.Unchecked)
                {
                    checkedItems.Add(checkedListBox1.Items[e.Index].ToString());
                    this.dtpTimeForm.Enabled = false;
                }
            }



        }

        private void Filter_Data_Click(object sender, EventArgs e)
        {
            ChknullFilter();
            FilterData(Doc, Truck, PO, SUP, MAT, Status, Inspec, Approved, ApprovedS, INTIME, OUTTIME, NETTIME);
            
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex ==1)
            {
                //this.buttonSelectView.Visible = true;
                //this.buttonViewALL.Visible = true;
                //this.Filter_Data.Visible = false;
                //this.Refresh_Report.Visible = true;
                this.BTFT.Visible = true;
                setReportCHT();
                
            }
           else
            {
                //this.buttonSelectView.Visible = true;
                //this.buttonViewALL.Visible = true;
                //this.Filter_Data.Visible = true;
                //this.Refresh_Report.Visible = true;
                this.BTFT.Visible = false;
                setReport(_dtDataM);
            }
            
        }

      

        private void TxtTurck_TextChanged(object sender, EventArgs e)
        {
            if (TxtTurck.Text.ToString() != "")
            {
                string strTruck = null;
                strTruck = TxtTurck.ToString();
                Truck = strTruck;
                Filter_Data.Enabled = true;
            }
            else
            {
                Filter_Data.Enabled = false;
                Truck = "";
            }
            
        }

        private void TxtPO_TextChanged(object sender, EventArgs e)
        {
            if (TxtPO.Text.ToString() !="")
            {
                string strPO = null;
                strPO = TxtPO.ToString();
                PO = strPO;
                Filter_Data.Enabled = true;
            }
            else
            {
                Filter_Data.Enabled = false;
                PO = "";
            }
           
        }

        private void CBSUP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBSUP.SelectedIndex.ToString()!= null)
            {
                string strSUP = null;
                strSUP = CBSUP.SelectedValue.ToString();
                SUP = strSUP;
                Filter_Data.Enabled = true;
            }
            else
            {
                SUP = "";
                Filter_Data.Enabled = false;
            }
            
        }

        private void CBMAT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBMAT.SelectedIndex.ToString() != null)
            {
                string strMAT = null;
                strMAT = CBMAT.SelectedValue.ToString();
                MAT = strMAT;
                Filter_Data.Enabled = true;
            }
            else
            {
              
                Filter_Data.Enabled = false;
            }
        }


        private void CBStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBStatus.SelectedIndex.ToString() != null)
            {
                string strStatus = null;
                strStatus = CBStatus.SelectedValue.ToString();
                Status = strStatus;
                Filter_Data.Enabled = true;
            }
            else
            {
                Filter_Data.Enabled = false;
            }
        }

        private void CBInspec_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBInspec.SelectedIndex.ToString() != null)
            {
                string strInspec = null;
                strInspec = CBInspec.SelectedValue.ToString();
                Inspec = strInspec;
                Filter_Data.Enabled = true;
            }
            else
            {
                
                Filter_Data.Enabled = false;
            }
        }

        private void CBAPP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBAPP.SelectedIndex.ToString() != null)
            {
                string strAPP = null;
                strAPP = CBAPP.SelectedValue.ToString();
                Approved = strAPP;
                Filter_Data.Enabled = true;
            }
            else
            {
               
                Filter_Data.Enabled = false;
            }
        }

        private void CBAPPS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBAPPS.SelectedIndex.ToString()!=null)
            {
             string strAPPS = null;
             strAPPS = CBAPPS.SelectedValue.ToString();
            ApprovedS = strAPPS;
            Filter_Data.Enabled = true;
            }
            else
            {
                Filter_Data.Enabled = false;
            }
            
        }

        private void tetDOC_TextChanged(object sender, EventArgs e)
        {
            if (tetDOC.Text!="")
            {
                string strDOC = null;
                strDOC = tetDOC.Text.ToString();
                Doc = strDOC;
                Filter_Data.Enabled = true;
            }
            else
            {
                Doc ="";
                Filter_Data.Enabled = false;
            }
            
        }

        private void BTFT_Click(object sender, EventArgs e)
        {
            ChknullFilter();
            FilterDataS(Doc,Truck, PO,SUP, MAT, Status, Inspec, Approved, ApprovedS, INTIME,OUTTIME,NETTIME);
        }

        
        private void ChknullFilter()
        {
          if (Doc == null)
            {
                Doc = "";
            }
            if (Truck == null)
            {
                Truck = "";
            }
            if (PO == null)
            {
                PO = "";
            }
            if (SUP == "System.Data.DataRowView")
            {
                SUP = "";
                
            }
            if (MAT == "System.Data.DataRowView")
            {
                MAT = "";
            }
            if (Status == "System.Data.DataRowView")
            {
                Status = "";
            }
            if (Inspec == "System.Data.DataRowView")
            {
                Inspec = "";
            }
            if (Approved == "System.Data.DataRowView")
            {
                Approved = "";

            }
            if (ApprovedS == "System.Data.DataRowView")
            {
                ApprovedS = "";
            }
            if (INTIME == null)
            {
                INTIME = "";
            }
            if (OUTTIME == null)
            {
                OUTTIME = "";
            }
            if (NETTIME == null)
            {
                NETTIME = "";
            }
            if (SUP == "0")
            {
                SUP = "";

            }
            if (MAT == "0")
            {
                MAT = "";
            }
            if (Status == "0")
            {
                Status = "";
            }
            if (Inspec == "0")
            {
                Inspec = "";
            }
            if (Approved == "0")
            {
                Approved = "";

            }
            if (ApprovedS == "0")
            {
                ApprovedS = "";
            }
            
            //if (WeightIN == "0")
            //{
            //    WeightIN = "";
            //}
            //if (WeightOUT == "0")
            //{
            //    WeightOUT = "";
            //}
            //if (WeightNET == "0")
            //{
            //    WeightNET = "";
            //}

        
        }

        private void dtpTimeForm_CloseUp(object sender, EventArgs e)
        {
            if (dtpTimeForm.Value > dtpTimeTo.Value)
            {
                MessageBox.Show(" Your selected Date Day form is incorect cause day from value must have less value than day to ", "Incorect", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.dtpTimeForm.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                return;
            }
        }

        private void dtpTimeTo_CloseUp(object sender, EventArgs e)
        {
            if (dtpTimeTo.Value < dtpTimeForm.Value)
            {
                MessageBox.Show(" Your selected Date Day form is incorect cause day from value must have less value than day to ", "Incorect", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.dtpTimeTo.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
                return;
            }
        }

        
      
       

        
     
        

        

       
               
    }
}
