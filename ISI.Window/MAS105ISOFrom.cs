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
    public partial class MAS105ISOForm : Form
    {

        SqlMasterManegerISO _SqlMasterManager5 = null;
        DataTable _dtISO = null;
        DataRow dr;
        string _connStr = "";
        string _userID = "";
        public bool _updatedFlag = false;
        public bool _deleteFlag = false;


        public MAS105ISOForm(string connStr, string userID)
        {
            InitializeComponent();

            this._connStr = connStr;
            this._userID = userID;
            this._SqlMasterManager5 = new SqlMasterManegerISO(this._connStr, this._userID);
            this._dtISO = new DataTable();
            this._dtISO = this._SqlMasterManager5.GetISI_ISOList();

            this.SetObject();
            this.BindingSource();


        }


        #region set Object

        private void SetObject()
        {


            bdsISO.DataSource = _dtISO;
            bdnISO.BindingSource = bdsISO;
            this.dgvISO.DataSource = bdsISO;
            dgvISO.ReadOnly = true;
        }

        #region Binding source
        private void BindingSource()
        {

            Binding br;
            br = null;
            br = new Binding("Text", bdsISO, "ISO_ID", true);
            textBoxISOID.DataBindings.Add(br);

            br = null;
            br = new Binding("Text", bdsISO, "ISO_Desc", true);
            textBoxISOName.DataBindings.Add(br);

            br = null;
            br = new Binding("Text", bdsISO, "ISO_NO", true);
            textBoxISONUM.DataBindings.Add(br);

            
            br = null;
            br = new Binding("Text", bdsISO, "ISO_TCODE", true);
            textBoxISOTCODE.DataBindings.Add(br);

            br = null;
            br = new Binding("Text", bdsISO, "ISO_Issused_Date", true);
            dateTimePickerISOISD.DataBindings.Add(br);

            br = null;
            br = new Binding("Text", bdsISO, "ISO_Effective_Date", true);
            dateTimePickerISOEFFD.DataBindings.Add(br);


        #endregion
        }
        #endregion
        public void SetSecurityForm(bool updatedFlag, bool deletedFlag, bool readFlag)
        {
            this._updatedFlag = updatedFlag;
            this._deleteFlag = deletedFlag;

            this.tsbSave.Enabled = this._updatedFlag;
            this.DEL.Enabled = this._deleteFlag;
        }



        private void SaveDB()
        {
            if (!varidate())
            {
                return;
            }

            int result = this._SqlMasterManager5.SaveMastertoDB(this._dtISO, "105");

            if (result == 1)
            {
                MessageBox.Show("Save to database completed...", "Save data", MessageBoxButtons.OK, MessageBoxIcon.Information);

                refresh();



            }
            else
            {
                MessageBox.Show(this._SqlMasterManager5.LastError5, "Fail Save data", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }


        private bool varidate()
        {

            bdsISO.EndEdit();
            dgvISO.EndEdit();

            List<string> dupicate = new List<string>();
            bool dup = false;
            string valueDup = "";


            // check dupicate 
            for (int i = _dtISO.Rows.Count - 1; i >= 0; i--)
            {
                dr = _dtISO.Rows[i];
                if (dr.RowState != DataRowState.Deleted)
                {
                    if (!dupicate.Contains(dr["ISO_ID"].ToString()))
                    {
                        dupicate.Add(dr["ISO_ID"].ToString());
                    }
                    else
                    {
                        dup = true;
                        valueDup = dr["ISO_ID"].ToString();
                        break;
                    }
                }

            }
            if (dup)
            {
                MessageBox.Show("ISO ID Dupicate : " + valueDup, "Check data", MessageBoxButtons.OK, MessageBoxIcon.Error);

                refresh();
                return false;
            }



            //
            foreach (DataRow drr in _dtISO.Rows)
            {
                if (drr.RowState == DataRowState.Deleted)
                {
                    continue;
                }
                if (drr["ISO_ID"].ToString().Length == 0 &&
                    drr["ISO_Desc"].ToString().Length == 0)
                {

                    MessageBox.Show("Not null ISO ID, ISO Desc", "Check Null ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    refresh();

                    return false;
                }


                if (drr["ISO_Desc"].ToString().Length == 0)
                {
                    MessageBox.Show("Not null : " + drr["ISO_ID"].ToString(), "Check Null for ISO_Desc", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    refresh();
                    return false;
                }



                if (drr["ISO_ID"].ToString().Length == 0)
                {
                    MessageBox.Show("Not null : " + drr["ISO_ID"].ToString(), "Check Null for Def_ID", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    refresh();
                    return false;
                }

            }


            return true;
        }




        private void refresh()
        {
            this._dtISO.Rows.Clear();
            this._dtISO.Merge(this._SqlMasterManager5.GetISI_ISOList());
        }

        private void AddR()
        {
            if (dr != null)
            {
                this._dtISO.Rows.Add();
                int er = this.dgvISO.Rows.GetLastRow(DataGridViewElementStates.Displayed);
                er += 0;
                if (this.dgvISO.CurrentRow.Index < dgvISO.Rows.Count)
                {
                    dgvISO.FirstDisplayedScrollingRowIndex = er;
                    dgvISO.Refresh();
                    dgvISO.CurrentCell = dgvISO.Rows[er].Cells[0];
                    dgvISO.Rows[er].Selected = true;
                    er += 1;

                }


                textBoxISOID.Focus();
                bdsISO.EndEdit();

            }

        }

       

        //private void bindingNavigatorDeleteItem1_Click_1(object sender, EventArgs e)
        //{
        //    dgvISO.CurrentRow.Selected = true;
        //}

       

        //private void bindingNavigatorMoveFirstItem1_Click(object sender, EventArgs e)
        //{
        //    dgvISO.CurrentRow.Selected = true;
        //}

        //private void bindingNavigatorAddNewItem1_Click_1(object sender, EventArgs e)
        //{
        //    textBoxISOID.Focus();
        //}

        //private void bindingNavigatorDeleteItem1_Click_2(object sender, EventArgs e)
        //{
        //    dgvISO.CurrentRow.Selected = true;
        //}

        //private void bindingNavigatorMovePreviousItem1_Click(object sender, EventArgs e)
        //{
        //    dgvISO.CurrentRow.Selected = true;
        //}

        //private void bindingNavigatorMoveNextItem1_Click(object sender, EventArgs e)
        //{
        //    dgvISO.CurrentRow.Selected = true;
        //}

        //private void bindingNavigatorMoveLastItem1_Click(object sender, EventArgs e)
        //{
        //    dgvISO.CurrentRow.Selected = true;
        //}

        private void tsbSave_Click_1(object sender, EventArgs e)
        {
            
            this.SaveDB();

            if (dr != null)
            {
                AddR();
            }
            else
            {

            }
        }

        private void bindingNavigatorMoveFirstItem1_Click_1(object sender, EventArgs e)
        {
            dgvISO.CurrentRow.Selected = true;
            textBoxISOID.Focus();
        }

        private void bindingNavigatorMovePreviousItem1_Click_1(object sender, EventArgs e)
        {
            dgvISO.CurrentRow.Selected = true;
            textBoxISOID.Focus();
        }

        private void bindingNavigatorAddNewItem1_Click(object sender, EventArgs e)
        {
            int er = this.dgvISO.Rows.GetLastRow(DataGridViewElementStates.Displayed);
            er += 0;
            if (this.dgvISO.CurrentRow.Index < dgvISO.Rows.Count)
            {
                dgvISO.FirstDisplayedScrollingRowIndex = er;
                dgvISO.Refresh();
                dgvISO.CurrentCell = dgvISO.Rows[er].Cells[0];
                dgvISO.Rows[er].Selected = true;
                er += 1;

            }
            textBoxISOID.Focus();
           
        }

        private void bindingNavigatorDeleteItem1_Click(object sender, EventArgs e)
        {
            
            textBoxISOID.Focus();
        }

        private void bindingNavigatorMoveNextItem1_Click_1(object sender, EventArgs e)
        {
            dgvISO.CurrentRow.Selected = true;
            textBoxISOID.Focus();
        }

        private void bindingNavigatorMoveLastItem1_Click_1(object sender, EventArgs e)
        {
            dgvISO.CurrentRow.Selected = true;
            textBoxISOID.Focus();
        }

        private void RefeshBT5_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }



    }
}



