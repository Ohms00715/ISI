using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISI.Window;
using System.Configuration;
using ISI.Maneger;


namespace ISI.Window
{
    public partial class MDI : Form
    {
        public string _connStr = "";
        public string _userID = "";
        public SqlAdminManeger _sqlAdminManagers = null;
        public DataSet _dataSet;
      

        public MDI(string userID)
        {
            InitializeComponent();

            this._connStr = ConfigurationManager.AppSettings["CONSTRDB"].ToString();// "Data Source=.\\SQLEXPRESS;Initial Catalog=ISIDB;Integrated Security=True";
            //this._connStr = "Data Source=.\\SQLEXPRESS;Initial Catalog=ISIDB;Integrated Security=True";
            this._userID = userID.ToString();
            this._sqlAdminManagers = new SqlAdminManeger(this._connStr, this._userID);
            this._dataSet = new DataSet();
            MAS100LoginForm form_ = new MAS100LoginForm(this._connStr);
            this.setMenuAuthorize();
            Bitmap bm = new Bitmap(Properties.Resources.ISILOGOUSE);

            // Convert to an icon and use for the form's icon.
            this.Icon = Icon.FromHandle(bm.GetHicon());
        }

       
       

       
        #region Master File
        private void M_MAS101_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form form = this.GetExistingChildForm("MAS101SuppilerForm");
            if (form == null)
            {
                
                _MAS101SuppilerForm = new MAS101SuppilerForm(this._connStr, this._userID);
                SetFormOpen(_MAS101SuppilerForm, M_MAS101.Text);
                #region set cecurity

                string strTag;

                bool boUp = false, boDel = false, boRead = false;

                DataView dv = this._dataSet.Tables[this._sqlAdminManagers.TabbleNameAuthorize].DefaultView;

                strTag = M_MAS101.Tag.ToString();

                dv.RowFilter = string.Format(" ISI_authorize_TCode = '{0}' ", strTag);

                if (dv.Count > 0)
                {

                    if (dv[0]["ISI_authorize_Update"] != DBNull.Value)
                    {

                        boUp = (bool)dv[0]["ISI_authorize_Update"];

                    }

                    if (dv[0]["ISI_authorize_Delect"] != DBNull.Value)
                    {

                        boDel = (bool)dv[0]["ISI_authorize_Delect"];
                    }

                    if (dv[0]["ISI_authorize_ReadOnly"] != DBNull.Value)
                    {

                        boRead = (bool)dv[0]["ISI_authorize_ReadOnly"];

                    }

                    _MAS101SuppilerForm.SetSecurityForm(boUp, boDel, boRead);

                }

                #endregion set cecurity

            }
            else
            {
                SetFormActivate(form);
            }
        }

        private void M_MAS102_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form form = this.GetExistingChildForm("MAS102MaterialForm");
            if (form == null)
            {
        
                _MAS102MaterialForm = new MAS102MaterialForm(this._connStr, this._userID);
                SetFormOpen(_MAS102MaterialForm, M_MAS102.Text);
                #region set cecurity

                string strTag;

                bool boUp = false, boDel = false, boRead = false;

                DataView dv = this._dataSet.Tables[this._sqlAdminManagers.TabbleNameAuthorize].DefaultView;

                strTag = M_MAS102.Tag.ToString();

                dv.RowFilter = string.Format(" ISI_authorize_TCode = '{0}' ", strTag);

                if (dv.Count > 0)
                {

                    if (dv[0]["ISI_authorize_Update"] != DBNull.Value)
                    {

                        boUp = (bool)dv[0]["ISI_authorize_Update"];

                    }

                    if (dv[0]["ISI_authorize_Delect"] != DBNull.Value)
                    {

                        boDel = (bool)dv[0]["ISI_authorize_Delect"];
                    }

                    if (dv[0]["ISI_authorize_ReadOnly"] != DBNull.Value)
                    {

                        boRead = (bool)dv[0]["ISI_authorize_ReadOnly"];

                    }

                    _MAS102MaterialForm.SetSecurityForm(boUp, boDel, boRead);

                }

                #endregion set cecurity
            }
            else
            {
                SetFormActivate(form);
            }
        }
        private void M_MAS103_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form form = this.GetExistingChildForm("MAS103Quality_CheckForm");
            if (form == null)
            {
             
                _MAS103Quality_CheckForm = new MAS103Quality_CheckForm(this._connStr, this._userID);
                SetFormOpen(_MAS103Quality_CheckForm, M_MAS103.Text);
                #region set cecurity

                string strTag;

                bool boUp = false, boDel = false, boRead = false;

                DataView dv = this._dataSet.Tables[this._sqlAdminManagers.TabbleNameAuthorize].DefaultView;

                strTag = M_MAS103.Tag.ToString();

                dv.RowFilter = string.Format(" ISI_authorize_TCode = '{0}' ", strTag);

                if (dv.Count > 0)
                {

                    if (dv[0]["ISI_authorize_Update"] != DBNull.Value)
                    {

                        boUp = (bool)dv[0]["ISI_authorize_Update"];

                    }

                    if (dv[0]["ISI_authorize_Delect"] != DBNull.Value)
                    {

                        boDel = (bool)dv[0]["ISI_authorize_Delect"];
                    }

                    if (dv[0]["ISI_authorize_ReadOnly"] != DBNull.Value)
                    {

                        boRead = (bool)dv[0]["ISI_authorize_ReadOnly"];

                    }

                    _MAS103Quality_CheckForm.SetSecurityForm(boUp, boDel, boRead);

                }

                #endregion set cecurity
            }
            else
            {
                SetFormActivate(form);
            }
        }

        private void M_MAS104_Click(object sender, EventArgs e)
        {
           

                System.Windows.Forms.Form form = this.GetExistingChildForm("MAS104DefectForm");
                if (form == null)
                {
                    _MAS104DefectForm = new MAS104DefectForm(this._connStr, this._userID);
                    SetFormOpen(_MAS104DefectForm, M_MAS104.Text);
                    #region set cecurity

                    string strTag;

                    bool boUp = false, boDel = false, boRead = false;

                    DataView dv = this._dataSet.Tables[this._sqlAdminManagers.TabbleNameAuthorize].DefaultView;

                    strTag = M_MAS104.Tag.ToString();

                    dv.RowFilter = string.Format(" ISI_authorize_TCode = '{0}' ", strTag);

                    if (dv.Count > 0)
                    {

                        if (dv[0]["ISI_authorize_Update"] != DBNull.Value)
                        {

                            boUp = (bool)dv[0]["ISI_authorize_Update"];

                        }

                        if (dv[0]["ISI_authorize_Delect"] != DBNull.Value)
                        {

                            boDel = (bool)dv[0]["ISI_authorize_Delect"];
                        }

                        if (dv[0]["ISI_authorize_ReadOnly"] != DBNull.Value)
                        {

                            boRead = (bool)dv[0]["ISI_authorize_ReadOnly"];

                        }

                        _MAS104DefectForm.SetSecurityForm(boUp, boDel, boRead);

                    }

                    #endregion set cecurity
                }
                else
                {
                    SetFormActivate(form);
                }
            
        }

        private void M_MAS105_Click(object sender, EventArgs e)
        {
         
            System.Windows.Forms.Form form = this.GetExistingChildForm("MAS105ISOForm");
            if (form == null)
            {
                _MAS105ISOForm = new MAS105ISOForm(this._connStr, this._userID);
                SetFormOpen(_MAS105ISOForm, M_MAS105.Text);
                #region set cecurity

                string strTag;

                bool boUp = false, boDel = false, boRead = false;

                DataView dv = this._dataSet.Tables[this._sqlAdminManagers.TabbleNameAuthorize].DefaultView;

                strTag = M_MAS105.Tag.ToString();

                dv.RowFilter = string.Format(" ISI_authorize_TCode = '{0}' ", strTag);

                if (dv.Count > 0)
                {

                    if (dv[0]["ISI_authorize_Update"] != DBNull.Value)
                    {

                        boUp = (bool)dv[0]["ISI_authorize_Update"];

                    }

                    if (dv[0]["ISI_authorize_Delect"] != DBNull.Value)
                    {

                        boDel = (bool)dv[0]["ISI_authorize_Delect"];
                    }

                    if (dv[0]["ISI_authorize_ReadOnly"] != DBNull.Value)
                    {

                        boRead = (bool)dv[0]["ISI_authorize_ReadOnly"];

                    }

                    _MAS105ISOForm.SetSecurityForm(boUp, boDel, boRead);

                }

                #endregion set cecurity
            }
            else
            {
                SetFormActivate(form);
            }
        }

        private void M_MAS106_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form form = this.GetExistingChildForm("MAS106Quality_Control_StatusForm");
            if (form == null)
            {
           
                _MAS106Quality_Control_StatusForm = new MAS106Quality_Control_StatusForm(this._connStr, this._userID);
                SetFormOpen(_MAS106Quality_Control_StatusForm, M_MAS106.Text);
                #region set cecurity

                string strTag;

                bool boUp = false, boDel = false, boRead = false;

                DataView dv = this._dataSet.Tables[this._sqlAdminManagers.TabbleNameAuthorize].DefaultView;

                strTag = M_MAS106.Tag.ToString();

                dv.RowFilter = string.Format(" ISI_authorize_TCode = '{0}' ", strTag);

                if (dv.Count > 0)
                {

                    if (dv[0]["ISI_authorize_Update"] != DBNull.Value)
                    {

                        boUp = (bool)dv[0]["ISI_authorize_Update"];

                    }

                    if (dv[0]["ISI_authorize_Delect"] != DBNull.Value)
                    {

                        boDel = (bool)dv[0]["ISI_authorize_Delect"];
                    }

                    if (dv[0]["ISI_authorize_ReadOnly"] != DBNull.Value)
                    {

                        boRead = (bool)dv[0]["ISI_authorize_ReadOnly"];

                    }

                    _MAS106Quality_Control_StatusForm.SetSecurityForm(boUp, boDel, boRead);

                }

                #endregion set cecurity
            }
            else
            {
                SetFormActivate(form);
            }
        }


        #endregion Master File

        #region Transaction

        private void T_TRN201_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form form = this.GetExistingChildForm("TRN201Incoming_Scrap_InspectionForm");
            if (form == null)
            {
                _TRN201Incoming_Scrap_InspectionForm = new TRN201Incoming_Scrap_InspectionForm(this._connStr, this._userID);
                SetFormOpen(_TRN201Incoming_Scrap_InspectionForm, "TRN201Incoming_Scrap_InspectionForm");
                #region set cecurity

                string strTag;

                bool boUp = false, boDel = false, boRead = false;

                DataView dv = this._dataSet.Tables[this._sqlAdminManagers.TabbleNameAuthorize].DefaultView;

                strTag = TRN201.Tag.ToString();

                dv.RowFilter = string.Format(" ISI_authorize_TCode = '{0}' ", strTag);

                if (dv.Count > 0)
                {

                    if (dv[0]["ISI_authorize_Update"] != DBNull.Value)
                    {

                        boUp = (bool)dv[0]["ISI_authorize_Update"];

                    }

                    if (dv[0]["ISI_authorize_Delect"] != DBNull.Value)
                    {

                        boDel = (bool)dv[0]["ISI_authorize_Delect"];
                    }

                    if (dv[0]["ISI_authorize_ReadOnly"] != DBNull.Value)
                    {

                        boRead = (bool)dv[0]["ISI_authorize_ReadOnly"];

                    }

                    _TRN201Incoming_Scrap_InspectionForm.SetSecurityForm(boUp, boDel, boRead);

                }

                #endregion set cecurity
            }
            else
            {
                SetFormActivate(form);
            }
        }

        #endregion Transaction

        #region Report
        private void REP101Suppiler_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form form = this.GetExistingChildForm("REP101SuppilerForm");
            if (form == null)
            {
                _REP101SuppilerForm = new REP101SuppilerForm(this._connStr, this._userID);
                SetFormOpen(_REP101SuppilerForm, REP101.Text);
            }
            else
            {
                SetFormActivate(form);
            }
        }

        private void REP102_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form form = this.GetExistingChildForm("REP102MaterialForm");
            if (form == null)
            {
                _REP102MaterialForm = new REP102MaterialForm(this._connStr, this._userID);
                SetFormOpen(_REP102MaterialForm, REP102.Text);
            }
            else
            {
                SetFormActivate(form);
            }
        }

        private void REP103_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form form = this.GetExistingChildForm("REP103Quality_CheckForm");
            if (form == null)
            {
                _REP103Quality_CheckForm = new REP103Quality_CheckForm(this._connStr, this._userID);
                SetFormOpen(_REP103Quality_CheckForm, REP103.Text);
            }
            else
            {
                SetFormActivate(form);
            }
        }

        private void REP104_Click(object sender, EventArgs e)
        {

            System.Windows.Forms.Form form = this.GetExistingChildForm("REP104DefectForm");
            if (form == null)
            {
                _REP104DefectForm = new REP104DefectForm(this._connStr, this._userID);
                SetFormOpen(_REP104DefectForm, REP104.Text);
            }
            else
            {
                SetFormActivate(form);
            }

        }

        private void REP105_Click(object sender, EventArgs e)
        {

            System.Windows.Forms.Form form = this.GetExistingChildForm("REP105ISOForm");
            if (form == null)
            {
                _REP105ISOForm = new REP105ISOForm(this._connStr, this._userID);
                SetFormOpen(_REP105ISOForm, REP105.Text);
            }
            else
            {
                SetFormActivate(form);
            }
        }

        private void REP106_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form form = this.GetExistingChildForm("REP106Quality_Control_StatusForm");
            if (form == null)
            {
                _REP106Quality_Control_StatusForm = new REP106Quality_Control_StatusForm(this._connStr, this._userID);
                SetFormOpen(_REP106Quality_Control_StatusForm, REP106.Text);
            }
            else
            {
                SetFormActivate(form);
            }
        }
        private void REP107_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form form = this.GetExistingChildForm("REP107Incoming_Scrap_InspectionForm");
            if (form == null)
            {
                _REP107Incoming_Scrap_InspectionForm = new REP107Incoming_Scrap_InspectionForm(this._connStr, this._userID);
                SetFormOpen(_REP107Incoming_Scrap_InspectionForm, REP107.Text);
            }
            else
            {
                SetFormActivate(form);
            }

        }


        #endregion
        
        #region Admim
        private void AD401_Click(object sender, EventArgs e)
        {
            //if (_userID =="Ohm00715")
            //{
                System.Windows.Forms.Form form = this.GetExistingChildForm("AD401ID_Password_Management_Form");
                if (form == null)
                {
                    _AD401ID_Password_Management_Form = new AD401ID_Password_Management_Form(this._connStr, this._userID);
                    SetFormOpen(_AD401ID_Password_Management_Form, AD401.Text);
                }
                else
                {
                    SetFormActivate(form);
                }
            //}
            //else
            //{
            //    MessageBox.Show("This Form is for Admin only !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            
        }
        private void AD402_Click(object sender, EventArgs e)
        {
            //if (_userID == "Ohm00715")
            //{
                System.Windows.Forms.Form form = this.GetExistingChildForm("Ad402Form_Management_Form");
                if (form == null)
                {
                    _Ad402Form_Management_Form = new Ad402Form_Management_Form(this._connStr, this._userID);
                    SetFormOpen(_Ad402Form_Management_Form, AD402.Text);
                }
                else
                {
                    SetFormActivate(form);
                }
            //}
            //else
            //{
            //    MessageBox.Show("This Form is for Admin only !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
        }
        private void AD403_Click(object sender, EventArgs e)
        {
            //if (_userID == "Ohm00715")
            //{
                System.Windows.Forms.Form form = this.GetExistingChildForm("AD403Authorized_Management_Form");
                if (form == null)
                {
                    _AD403Authorized_Management_Form = new AD403Authorized_Management_Form(this._connStr, this._userID);
                    SetFormOpen(_AD403Authorized_Management_Form, AD403.Text);
                }
                else
                {
                    SetFormActivate(form);
                }
            //}
            //else
            //{
            //    MessageBox.Show("This Form is for Admin only !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
        }

        #endregion

        #region Method Service
        private System.Windows.Forms.Form GetExistingChildForm(string formName)
        {
            string formNameStr;
            int findInt;
            foreach (System.Windows.Forms.Form ChildForm in this.MdiChildren)
            {
                formNameStr = ChildForm.GetType().ToString().ToUpper();
                findInt = formNameStr.IndexOf(formName.ToUpper());
                if (findInt > 0)
                {
                    return ChildForm;
                }
            }
            return null;
        }

        private void SetFormOpen(Form form, string fName)
        {
            form.MdiParent = this;
            form.Text = fName;
            form.Show();
            form.WindowState = FormWindowState.Maximized;
            form.Activate();
        }
        private void SetFormOpen2(Form form, string fName)
        {
            form.MdiParent = this;
            form.Text = fName;
            form.Show();
            form.StartPosition = FormStartPosition.CenterParent;
            form.WindowState = FormWindowState.Normal;
           
            form.Activate();
        }

        private void SetFormActivate(Form form)
        {
            form.Activate();
            if (form.WindowState != FormWindowState.Maximized)
            {
                form.WindowState = FormWindowState.Normal;
            }
        }
        #endregion Method Service

        #region event button
        public REP107Incoming_Scrap_InspectionForm _REP107Incoming_Scrap_InspectionForm { get; set; }

        public REP106Quality_Control_StatusForm _REP106Quality_Control_StatusForm { get; set; }

        public REP105ISOForm _REP105ISOForm { get; set; }

        public REP104DefectForm _REP104DefectForm { get; set; }

        public REP103Quality_CheckForm _REP103Quality_CheckForm { get; set; }

        public REP102MaterialForm _REP102MaterialForm { get; set; }

        public REP101SuppilerForm _REP101SuppilerForm { get; set; }

        public TRN201Incoming_Scrap_InspectionForm _TRN201Incoming_Scrap_InspectionForm { get; set; }

        public MAS106Quality_Control_StatusForm _MAS106Quality_Control_StatusForm { get; set; }

        public MAS105ISOForm _MAS105ISOForm { get; set; }

        public MAS104DefectForm _MAS104DefectForm { get; set; }

        public MAS103Quality_CheckForm _MAS103Quality_CheckForm { get; set; }

        public MAS102MaterialForm _MAS102MaterialForm { get; set; }

        public MAS101SuppilerForm _MAS101SuppilerForm { get; set; }

        public MAS100LoginForm _MAS100LoginForm { get; set; }

        public AD401ID_Password_Management_Form _AD401ID_Password_Management_Form { get; set; }

        public Ad402Form_Management_Form _Ad402Form_Management_Form { get; set; }

        public AD403Authorized_Management_Form _AD403Authorized_Management_Form { get; set; }
        #endregion event button

        

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form form = this.GetExistingChildForm("MAS100LoginForm");
            if (form == null)
            {
                this.Close();
                _MAS100LoginForm = new MAS100LoginForm(this._connStr);
                //SetFormOpen2(_MAS100LoginForm, LOGOUT.Text);
                _MAS100LoginForm.Show();
                
            }
            else
            {
                SetFormActivate(form);
            }
        }

        #region setAuthorizedMenu


        private void SetMenuItems(ToolStripMenuItem MyMenuItem)
        {

            ToolStripMenuItem menuItem;

            string strTag;

            DataView dv = this._dataSet.Tables[this._sqlAdminManagers.TabbleNameAuthorize].DefaultView;


            foreach (object mni in MyMenuItem.DropDownItems)
            {

                if (mni.GetType() == typeof(ToolStripMenuItem))
                {

                    menuItem = (ToolStripMenuItem)mni;

                    if (((ToolStripMenuItem)mni).DropDownItems.Count > 0)
                    {

                        strTag = menuItem.Tag.ToString();

                        dv.RowFilter = string.Format(" ISI_authorize_TCode = '{0}' ", strTag);

                        if (dv.Count > 0)
                        {

                            if (dv[0]["ISI_authorize_Visible"] != DBNull.Value)
                            {
                                menuItem.Visible = (bool)dv[0]["ISI_authorize_Visible"];
                            }

                        }

                        else
                        {

                            menuItem.Visible = false;

                        }


                        SetMenuItems(((ToolStripMenuItem)mni));

                    }

                    else
                    {

                        if (menuItem.Tag != null)
                        {

                            strTag = menuItem.Tag.ToString();

                            dv.RowFilter = string.Format(" ISI_authorize_TCode = '{0}' ", strTag);

                            if (dv.Count > 0)
                            {

                                if (dv[0]["ISI_authorize_Visible"] != DBNull.Value)
                                {

                                    menuItem.Visible = (bool)dv[0]["ISI_authorize_Visible"];

                                }

                            }

                            else
                            {
                                menuItem.Visible = false;
                            }

                        }
                        else
                        {
                            menuItem.Visible = false;
                        }

                    }

                }

            }

        }

        private void setMenuAuthorize()
        {

            string strTag;

            this._dataSet = this._sqlAdminManagers.GetRecoedUserByAppUserCode(this._userID);

            DataView dv = this._dataSet.Tables[this._sqlAdminManagers.TabbleNameAuthorize].DefaultView;


            foreach (ToolStripMenuItem itemLevel0 in this.MainMenu.Items)
            {

                if (itemLevel0.Tag != null)
                {

                    strTag = itemLevel0.Tag.ToString();

                    dv.RowFilter = string.Format(" ISI_authorize_TCode = '{0}' ", strTag);

                    if (dv.Count > 0)
                    {

                        if (dv[0]["ISI_authorize_Visible"] != DBNull.Value)
                        {
                            itemLevel0.Visible = (bool)dv[0]["ISI_authorize_Visible"];
                          
                        }

                    }

                    else
                    {

                        itemLevel0.Visible = false;
                        
                    }

                }

                if (itemLevel0.DropDownItems.Count > 0)
                {
                    
                    this.SetMenuItems(itemLevel0);
                }

            }
           
        }
       
        #endregion setAuthorizedMenu
        public void callMdiChild(string menuCode)
        {
               
              
            switch (menuCode.ToUpper())
            {
                case "MAS100":
                    if (M_MAS101.Tag.ToString() == "MAS101")
                    {
                        if (Convert.ToBoolean(M_MAS101.Available) == true)
                        {      
                            this.M_MAS101_Click(null, null);  
                        }                     
                    }
                    break;
                   

                case "MAS200":

                    if (Convert.ToBoolean(M_MAS102.Available) == true)
                    {
                        this.M_MAS102_Click(null, null);            
                    }
                    break;

                case "MAS300":
                         if (Convert.ToBoolean(M_MAS103.Available) == true)
                         {
                             this.M_MAS103_Click(null, null);

                         }
                   
                    break;

                case "MAS400":

                    if (Convert.ToBoolean(M_MAS104.Available) == true)
                     {
                        this.M_MAS104_Click(null, null);
                    }
                   
                    break;

                case "MAS500":

                    if (Convert.ToBoolean(M_MAS105.Available) == true)
                    {
                        this.M_MAS105_Click(null, null);
                    }
                    break;

                case "MAS600":

                    if (Convert.ToBoolean(M_MAS106.Available) == true)
                    {
                        this.M_MAS106_Click(null, null);
                    }
                    break;

                case "TRN201":
                    if (Convert.ToBoolean(TRN201.Available) == true)
                    {
                        this.T_TRN201_Click(null, null);
                    }
                    break;

                case "REP101":

                    if (Convert.ToBoolean(REP101.Available) == true)
                    {
                        this.REP101Suppiler_Click(null, null);
                    }
                    break;

                case "REP102":

                    if (Convert.ToBoolean(REP102.Available) == true)
                    {
                        this.REP102_Click(null, null);
                    }
                    break;

                case "REP103":

                    if (Convert.ToBoolean(REP103.Available) == true)
                    {
                       this.REP103_Click(null, null);
                    }
                    break;

                case "REP104":
                    if (Convert.ToBoolean(REP104.Available) == true)
                    {
                        this.REP104_Click(null, null);
                    }
                    break;

                case "REP105":

                    if (Convert.ToBoolean(REP105.Available) == true)
                    {
                        this.REP105_Click(null, null);
                    }
                    break;

                case "REP106":

                    if (Convert.ToBoolean(REP106.Available) == true)
                    {
                        this.REP106_Click(null, null);
                    }
                    break;

                case "REP107":

                    if (Convert.ToBoolean(REP107.Available) == true)
                    {
                        this.REP107_Click(null, null);
                    }
                    break;




            }
          
           
        }
        public void MDI_FormClosing(object sender, FormClosingEventArgs e)
        {
            _MAS100LoginForm = new MAS100LoginForm(this._connStr);
            _MAS100LoginForm.Close();
        }
  
        
    }
}


