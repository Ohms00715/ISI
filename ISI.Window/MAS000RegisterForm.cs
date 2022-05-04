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
    public partial class MAS000RegisterForm : Form
    {
        SqlAdminManeger _SqlAdminManeger = null;
        DataTable _dtTRegister = null;
        DataTable _dtLOGIN = null;
        string DocumenKeysID = "";
        string DocumenKeyPassword = "";
        DataRow dr;
        string _connStr = "";
        string _userID = "";
       
        
   
        public MAS000RegisterForm(string connStr, string userID)
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this._connStr = connStr;
            this._userID = "ADMIN";
            Bitmap bm = new Bitmap(Properties.Resources.ISILOGOUSE);

            // Convert to an icon and use for the form's icon.
            this.Icon = Icon.FromHandle(bm.GetHicon());
            this._SqlAdminManeger = new SqlAdminManeger(this._connStr, this._userID);
            this._dtTRegister = new DataTable();
            this._dtTRegister = this._SqlAdminManeger.GetISI_LOGINRegister();
            this._dtLOGIN = new DataTable();
            this._dtLOGIN = this._SqlAdminManeger.GetISI_LOGINList();
            BindingSource();
         
           

        }
        #region Binding source
        private void BindingSource()
        {
            this.bdsRegister.DataSource = _dtTRegister;
          
            
            Binding br;
            br = null;
            br = new Binding("Text", bdsRegister, "ISI_LOGIN_ID", true);
            //br.NullValue = false;
            this.textBoxID.DataBindings.Add(br);

            br = null;
            br = new Binding("Text", bdsRegister, "ISI_LOGIN_Password", true);
            //br.NullValue = false;
            this.textBoxPassWord.DataBindings.Add(br);

            br = null;
            br = new Binding("Text", bdsRegister, "ISI_LOGIN_FName", true);
            //br.NullValue = false;
            this.textBoxFNAME.DataBindings.Add(br);

            br = null;
            br = new Binding("Text", bdsRegister, "ISI_LName", true);
            //br.NullValue = false;
            this.textBoxLName.DataBindings.Add(br);


            br = null;
            br = new Binding("Text", bdsRegister, "ISI_LOGIN_Address", true);
            br.NullValue = false;
            this.richtextBoxAddress.DataBindings.Add(br);

            br = null;
            br = new Binding("Text", bdsRegister, "ISI_LOGIN_Email", true);
            //br.NullValue = false;
            this.textBoxEmail.DataBindings.Add(br);

            br = null;
            br = new Binding("Text", bdsRegister, "ISI_LOGIN_Telephone", true);
            //br.NullValue = false;
            this.textBoxNO.DataBindings.Add(br);

            br = null;
            br = new Binding("Text", bdsRegister, "ISI_National_ID", true);
            //br.NullValue = false;
            this.textBoxNationID.DataBindings.Add(br);
        
        }

        #endregion

        private void btCF_Click(object sender, EventArgs e)
        {

            if (textBoxCPassWord.Text != textBoxPassWord.Text)
            {
                MessageBox.Show(" Incorect ", "Incorect", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxCPassWord.Focus();
            }
            else
            {
                DataRow drx = this._dtLOGIN.Select(string.Format(" ISI_LOGIN_ID = '{0}'", DocumenKeysID)).FirstOrDefault();
                if (drx == null)
                {
                    this._dtTRegister = new DataTable();
                    this._dtTRegister = this._SqlAdminManeger.GetISI_LOGINList();
                    dr = _dtTRegister.NewRow();
                    dr["ISI_LOGIN_ID"] = textBoxID.Text;
                    dr["ISI_LOGIN_Password"] = textBoxPassWord.Text;
                    dr["ISI_LOGIN_FName"] = textBoxFNAME.Text;
                    dr["ISI_LName"] = textBoxLName.Text;
                    dr["ISI_LOGIN_Address"] = richtextBoxAddress.Text;
                    dr["ISI_LOGIN_Email"] = textBoxEmail.Text;
                    dr["ISI_LOGIN_Telephone"] = textBoxNO.Text;
                    dr["ISI_National_ID"] = textBoxNationID.Text;
                    this._dtTRegister.Rows.Add(dr);
                    SaveDB();
                }
                
            }
            
        }
        #region CheckConfirm
        private void textBoxCPassWord_TextChanged(object sender, EventArgs e)
        {
            if (textBoxCPassWord.Text != "" && textBoxPassWord.Text != "" && textBoxID.Text != "" && textBoxNO.TextLength == 10 && IsValidEmail("") && textBoxNationID.TextLength == 13&&textBoxLName.Text != ""&&this.textBoxFNAME.Text != "")
            {
                this.btCFCHECKT();
            }
            else
            {
                this.btCFCHECKF();
            }
         
        }

        private void textBoxPassWord_TextChanged(object sender, EventArgs e)
        {
            if (textBoxCPassWord.Text != "" && textBoxPassWord.Text != "" && textBoxID.Text != "" && textBoxNO.TextLength == 10 && IsValidEmail("") && textBoxNationID.TextLength == 13 && textBoxLName.Text != "" && this.textBoxFNAME.Text != "")
            {
                this.btCFCHECKT();
            }
            else
            {
                this.btCFCHECKF();
            }
        }

        private void textBoxID_TextChanged(object sender, EventArgs e)
        {
            if (textBoxCPassWord.Text != "" && textBoxPassWord.Text != "" && textBoxID.Text != "" && textBoxNO.TextLength == 10 && IsValidEmail("") && textBoxNationID.TextLength == 13 && textBoxLName.Text != "" && this.textBoxFNAME.Text != "")
            {
                this.btCFCHECKT();
            }
            else
            {
                this.btCFCHECKF();
            }
        }

        private void textBoxNO_TextChanged(object sender, EventArgs e)
        {
            if (textBoxCPassWord.Text != "" && textBoxPassWord.Text != "" && textBoxID.Text != "" && textBoxNO.TextLength == 10 && IsValidEmail("") && textBoxNationID.TextLength == 13 && textBoxLName.Text != "" && this.textBoxFNAME.Text != "")
            {
                this.btCFCHECKT();
            }
            else
            {
                this.btCFCHECKF();
            }
        }

        private void MAS000RegisterForm_Load(object sender, EventArgs e)
        {
            this.btCFCHECKF();
        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {

            if (textBoxCPassWord.Text != "" && textBoxPassWord.Text != "" && textBoxID.Text != "" && textBoxNO.TextLength == 10 && IsValidEmail("") && textBoxNationID.TextLength == 13 && textBoxLName.Text != "" && this.textBoxFNAME.Text != "")
            {
                this.btCFCHECKT();
            }
            else
            {
                this.btCFCHECKF();
            }
           
        }

        private void textBoxNationID_TextChanged(object sender, EventArgs e)
        {
            if (textBoxCPassWord.Text != "" && textBoxPassWord.Text != "" && textBoxID.Text != "" && textBoxNO.TextLength == 10 && IsValidEmail("") && textBoxNationID.TextLength == 13 && textBoxLName.Text != "" && this.textBoxFNAME.Text != "")
            {
                this.btCFCHECKT();
            }
            else
            {
                this.btCFCHECKF();
            }
           
        }


        private void textBoxLName_TextChanged(object sender, EventArgs e)
        {
            if (textBoxCPassWord.Text != "" && textBoxPassWord.Text != "" && textBoxID.Text != "" && textBoxNO.TextLength == 10 && IsValidEmail("") && textBoxNationID.TextLength == 13 && textBoxLName.Text != "" && this.textBoxFNAME.Text != "")
            {
                this.btCFCHECKT();
            }
            else
            {
                this.btCFCHECKF();
            }
        }

        private void textBoxFNAME_TextChanged(object sender, EventArgs e)
        {
            if (textBoxCPassWord.Text != "" && textBoxPassWord.Text != "" && textBoxID.Text != "" && textBoxNO.TextLength == 10 && IsValidEmail("") && textBoxNationID.TextLength == 13 && textBoxLName.Text != "" && this.textBoxFNAME.Text != "")
            {
                this.btCFCHECKT();
            }
            else
            {
                this.btCFCHECKF();
            }
        }
        #endregion
        public void btCFCHECKT()
        { 
                btCF.Enabled = true;
        }
        public void btCFCHECKF()
        {
            btCF.Enabled = false;
        }
        private void SaveDB()
        {
            if (!varidate())
            {
                return;
            }

            int result = this._SqlAdminManeger.SaveMastertoDB22(this._dtTRegister);

            if (result == 1)
            {
                MessageBox.Show("Save to database completed...", "Save data", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show(this._SqlAdminManeger.LastError22, "Fail Save data", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void refresh()
        {
            this._dtTRegister.Rows.Clear();
            this._dtTRegister.Merge(this._SqlAdminManeger.GetISI_LOGINRegister());
        }
        private bool varidate()
        {
            List<string> dupicate = new List<string>();
            List<string> dupicate2 = new List<string>();
            bool dup = false;
            bool dup2 = false;
            string valueDup = "";
            // check dupicate 
            for (int i = _dtTRegister.Rows.Count - 1; i >= 0; i--)
            {
                dr = _dtTRegister.Rows[i];
                if (dr.RowState != DataRowState.Deleted)
                {
                   
                    if (!dupicate.Contains(dr["ISI_LOGIN_ID"].ToString()))
                    {
                        dupicate.Add(dr["ISI_LOGIN_ID"].ToString());
                    }
                    else
                    {
                        dup = true;
                        valueDup = dr["ISI_LOGIN_ID"].ToString();
                        break;
                    }

                    if (!dupicate2.Contains(dr["ISI_National_ID"].ToString()))
                    {
                        dupicate.Add(dr["ISI_National_ID"].ToString());
                    }
                    else
                    {
                        dup2 = true;
                        valueDup = dr["ISI_National_ID"].ToString();
                        break;
                    }
                }
            }
            if (dup)
            {
                //MessageBox.Show("ID Dupicate : " + valueDup, "Check data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(" This ID is already Use !!!  ", "Duppicated", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxID.Focus();
                refresh();
                return false;
            }

            if (dup2)
            {
                //MessageBox.Show("ID Dupicate : " + valueDup, "Check data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(" This National ID is already Use !!!  ", "Duppicated", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.textBoxNationID.Focus();
                return false;
            }
          
            return true;
        }
        public MAS100LoginForm _MAS100LoginForm { get; set; }

        private void MAS000RegisterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult a = MessageBox.Show(" Are you want to Log in ? ", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (a == DialogResult.Yes)
            {
                _MAS100LoginForm = new MAS100LoginForm(this._connStr);
                _MAS100LoginForm.Show();

            }
            
        }

        private void textBoxNationID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBoxNO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        bool IsValidEmail(string email)
        {
            try
            {
                email = textBoxEmail.Text;
                email = email.Trim();
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
             
            }
            catch
            {
                return false;
            }
        }
    }
}
