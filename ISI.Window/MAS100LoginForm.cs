using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISI.Maneger;
using System.Configuration;

namespace ISI.Window
{
    public partial class MAS100LoginForm : Form
    {
        SqlAdminManeger _SqlAdminManeger = null;
        DataTable _dtLOGIN = null;
        DataRow dr;
        string _connStr = "";
        string _userID = "";
        string _documentKey1 = "";
        string _documentKey2 = "";
 
        public MAS100LoginForm(string connStr)
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            Bitmap bm = new Bitmap(Properties.Resources.ISILOGOUSE);

            // Convert to an icon and use for the form's icon.
            this.Icon = Icon.FromHandle(bm.GetHicon());
            //this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this._connStr = connStr;
            this._SqlAdminManeger = new SqlAdminManeger(this._connStr, this._userID);
            this._dtLOGIN = new DataTable();
            this._dtLOGIN = this._SqlAdminManeger.GetISI_LOGINList();
            
        }

        private void Login_Click(object sender, EventArgs e)
        {
            string DocumenKeysID = "";
            string DocumenKeyPassword = "";
            DocumenKeysID = this.textBoxID.Text;
            DocumenKeyPassword = this.textBoxPassword.Text;

            if (DocumenKeysID != "" && DocumenKeyPassword != "")
            {
                DataRow drx = this._dtLOGIN.Select(string.Format(" ISI_LOGIN_ID = '{0}' AND ISI_LOGIN_Password = '{1}' ", DocumenKeysID, DocumenKeyPassword)).FirstOrDefault();
                
                if (drx != null)
                {
                    System.Windows.Forms.Form form = this.GetExistingChildForm("MAS100LoginForm");
                    if (form == null)
                    {
                        DocumenKeys = drx["ISI_LOGIN_ID"].ToString();
                        _MDI = new MDI(DocumenKeys);
                        SetFormOpen(_MDI);
                        this.Hide();
                        
                    }
                    else
                    {
                        SetFormActivate(form);
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show(" Incorrect ", "Incorect", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                MessageBox.Show(" User or Password is not null!! ", "Incorect", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            





        }
        private void Register_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form form = this.GetExistingChildForm("MAS000RegisterForm");
            if (form == null)
            {
                _MAS000RegisterForm = new MAS000RegisterForm(this._connStr, this._userID);
                SetFormOpen(_MAS000RegisterForm);
                this.Hide();
            }
            else
            {
                SetFormActivate(form);
            }
                
        }

      
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
                this.textBoxPassword.UseSystemPasswordChar = false;
            else
                this.textBoxPassword.UseSystemPasswordChar = true;

        }
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


        private void SetFormOpen(Form form)
        {
            form.Show();
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
        #region propotile

        public MDI _MDI { get; set; }
        public MAS000RegisterForm _MAS000RegisterForm { get; set; }
        public string DocumenKeys
        {
            get { return _documentKey1; }
            set { _documentKey1 = value; }
        }
        #endregion

    

        private void textBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.textBoxID.Text != "" && this.textBoxPassword.Text != null)
            {
                if (e.KeyData == Keys.Enter)
                {
                    Login_Click(null, null);
                }
            }
        }

        

       

     
      




    }
}
