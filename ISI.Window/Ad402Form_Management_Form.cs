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
    public partial class Ad402Form_Management_Form : Form
    {
        DataRow dr;
        SqlAdminManeger _SqlAdminManeger = null;
        DataTable _dtADForm = null;
        string _connStr = "";
        string _userID = "";
        public Ad402Form_Management_Form(string connStr, string userID)
        {
            InitializeComponent();
            
            this._connStr = connStr;
            this._userID = userID;
            this._SqlAdminManeger = new SqlAdminManeger(this._connStr, this._userID);
            this._dtADForm = new DataTable();
            this._dtADForm = this._SqlAdminManeger.GetISI_FormList();

            this.SetObject();
            this.BindingSource();
            this.dgvADF.AutoGenerateColumns = false;

           
        }
        private void SetObject()
        {
            this.bdsADF.DataSource = _dtADForm;
            this.bdnADF.BindingSource = bdsADF;
            this.dgvADF.DataSource = bdsADF;
            dgvADF.ReadOnly = true;
        }
        private void BindingSource()
        {
            Binding br;
          
            br = null;
            br = new Binding("Text", bdsADF, "ISI_Form_Key", true);
            //br.NullValue = false;
            this.textBoxFormKey.DataBindings.Add(br);

            br = null;
            br = new Binding("Text", bdsADF, "ISI_Form_Desc", true);
            //br.NullValue = false;
            this.textBoxDesc.DataBindings.Add(br);

            br = null;
            br = new Binding("Text", bdsADF, "ISI_Form_Group", true);
            br.NullValue = false;
            this.comboBoxGroup.DataBindings.Add(br);

            br = null;
            br = new Binding("Checked", bdsADF, "Activated", true);
            br.NullValue = false;
            this.Act.DataBindings.Add(br);

        }

        private void tsbSave_Click(object sender, EventArgs e)
        {

            //this._dtADForm = new DataTable();
            //this._dtADForm = this._SqlAdminManeger.GetISI_FormList();
            //dr = _dtADForm.NewRow();
            //dr["ISI_Form_Key"] = textBoxFormKey.Text;
            //dr["ISI_Form_Desc"] = textBoxDesc.Text;
            //dr["ISI_Form_Group"] = comboBoxGroup.Text;
            //dr["Activated"] = Act.Checked;
            
            //this._dtADForm.Rows.Add(dr);
            SaveDB();
        
        }

        private void SaveDB()
        {
            this.dgvADF.EndEdit();
            this.bdsADF.EndEdit();
            if (!varidate())
            {
                return;
            }

            int result = this._SqlAdminManeger.SaveMastertoDB33(this._dtADForm);

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


            // check dupicate 
            for (int i = _dtADForm.Rows.Count - 1; i >= 0; i--)
            {
                dr = _dtADForm.Rows[i];
                if (dr.RowState != DataRowState.Deleted)
                {
                    if (!dupicate.Contains(dr["ISI_Form_Key"].ToString()))
                    {
                        dupicate.Add(dr["ISI_Form_Key"].ToString());
                    }
                    else
                    {
                        dup = true;
                        valueDup = dr["ISI_Form_Key"].ToString();
                        break;
                    }
                }

            }
            if (dup)
            {
                MessageBox.Show("Form Key Dupicate : " + valueDup, "Check data", MessageBoxButtons.OK, MessageBoxIcon.Error);

                refresh();
                return false;
            }

            return true;
        }

        private void refresh()
        {
            this._dtADForm.Rows.Clear();
            this._dtADForm.Merge(this._SqlAdminManeger.GetISI_FormList());
        }

        private void RefeshBT1_Click(object sender, EventArgs e)
        {
            refresh();
        }

      
    }
}
