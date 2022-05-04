using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISI.Maneger;

namespace ISI.Window
{
    public partial class AD401ID_Password_Management_Form : Form
    {

        SqlAdminManeger _SqlAdminManeger = null;
        DataTable _dtADUesr = null;
        DataRow dr;
        string _connStr = "";
        string _userID = "";
        public AD401ID_Password_Management_Form(string connStr, string userID)
        {
            InitializeComponent();
            this._connStr = connStr;
            this._userID = userID;
            this._SqlAdminManeger = new SqlAdminManeger(this._connStr, this._userID);
            this._dtADUesr = new DataTable();
            this._dtADUesr = this._SqlAdminManeger.GetISI_LOGINList();
            this.SetObject();
            this.BindingSource();
            this.dgvADU.AutoGenerateColumns = false;
           
        }

        private void BindingSource()
        {
            Binding br;

        
            br = null;
            br = new Binding("Text", bdsADU, "ISI_LOGIN_ID", true);
            //br.NullValue = false;
            this.textBoxID.DataBindings.Add(br);

            br = null;
            br = new Binding("Text", bdsADU, "ISI_LOGIN_Password", true);
            //br.NullValue = false;
            this.textBoxPassWord.DataBindings.Add(br);

            br = null;
            br = new Binding("Text", bdsADU, "ISI_LOGIN_FName", true);
            //br.NullValue = false;
            this.textBoxFNAME.DataBindings.Add(br);

            br = null;
            br = new Binding("Text", bdsADU, "ISI_LName", true);
            //br.NullValue = false;
            this.textBoxLName.DataBindings.Add(br);


            br = null;
            br = new Binding("Text", bdsADU, "ISI_LOGIN_Address", true);
            //br.NullValue = false;
            this.richtextBoxAddress.DataBindings.Add(br);

            br = null;
            br = new Binding("Text", bdsADU, "ISI_LOGIN_Email", true);
            //br.NullValue = false;
            this.textBoxEmail.DataBindings.Add(br);

            br = null;
            br = new Binding("Text", bdsADU, "ISI_LOGIN_Telephone", true);
            //br.NullValue = false;
            this.textBoxNO.DataBindings.Add(br);

            br = null;
            br = new Binding("Text", bdsADU, "ISI_National_ID", true);
            //br.NullValue = false;
            this.textBoxNationID.DataBindings.Add(br);
        }

        private void SetObject()
        {
            this.bdsADU.DataSource = _dtADUesr;
            this.bdnADU.BindingSource = bdsADU;
            this.dgvADU.DataSource = bdsADU;
            dgvADU.ReadOnly = true;
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            //this._dtADUesr = new DataTable();
            //this._dtADUesr = this._SqlAdminManeger.GetISI_LOGINList();
            //dr = _dtADUesr.NewRow();
            //dr["ISI_LOGIN_ID"] = textBoxID.Text;
            //dr["ISI_LOGIN_Password"] = textBoxPassWord.Text;
            //dr["ISI_LOGIN_FName"] = textBoxFNAME.Text;
            //dr["ISI_LName"] = textBoxLName.Text;
            //dr["ISI_LOGIN_Address"] = richtextBoxAddress.Text;
            //dr["ISI_LOGIN_Email"] = textBoxEmail.Text;
            //dr["ISI_LOGIN_Telephone"] = textBoxNO.Text;
            //dr["ISI_National_ID"] = textBoxNationID.Text;
            //this._dtADUesr.Rows.Add(dr);
            SaveDB();
        }

        private void SaveDB()
        {
           
            if (!varidate())
            {
                return;
            }

            int result = this._SqlAdminManeger.SaveMastertoDB22(this._dtADUesr);

            if (result == 1)
            {
                MessageBox.Show("Save to database completed...", "Save data", MessageBoxButtons.OK, MessageBoxIcon.Information);

             


            }
            else
            {
                MessageBox.Show(this._SqlAdminManeger.LastError22, "Fail Save data", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private bool varidate()
        {
            List<string> dupicate = new List<string>();
            bool dup = false;
            string valueDup = "";
            this.dgvADU.EndEdit();
            this.bdsADU.EndEdit();

            // check dupicate 
            for (int i = _dtADUesr.Rows.Count - 1; i >= 0; i--)
            {
                dr = _dtADUesr.Rows[i];
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
                }

            }
            if (dup)
            {
                MessageBox.Show("ID Dupicate : " + valueDup, "Check data", MessageBoxButtons.OK, MessageBoxIcon.Error);

                refresh();
                return false;
            }

            return true;
        }

        private void refresh()
        {
            this._dtADUesr.Rows.Clear();
            this._dtADUesr.Merge(this._SqlAdminManeger.GetISI_LOGINList());
        }
        private void RefeshBT1_Click(object sender, EventArgs e)
        {
            refresh();
        }
    }
}
