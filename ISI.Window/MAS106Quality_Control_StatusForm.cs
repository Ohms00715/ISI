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
    public partial class MAS106Quality_Control_StatusForm : Form
    {

        SqlMasterManegerStatus _SqlMasterManager6 = null;
        DataTable _dtStatus = null;
        DataRow dr;
        string _connStr = "";
        string _userID = "";
        public bool _updatedFlag = false;
        public bool _deleteFlag = false;

        public MAS106Quality_Control_StatusForm(string connStr, string userID)
        {
            InitializeComponent();

            this._connStr = connStr;
            this._userID = userID;
            this._SqlMasterManager6 = new SqlMasterManegerStatus(this._connStr, this._userID);
            this._dtStatus = new DataTable();
            this._dtStatus = this._SqlMasterManager6.GetISI_StatusList();

            this.SetObject();
            this.BindingSource();


        }


        #region set Object

        private void SetObject()
        {


            bdsStatus.DataSource = _dtStatus;
            bdnStatus.BindingSource = bdsStatus;
            this.dgvStatus.DataSource = bdsStatus;
            dgvStatus.ReadOnly = true;
        }

        #region Binding source
        private void BindingSource()
        {

            Binding br;
            br = null;
            br = new Binding("Text", bdsStatus, "Status_ID", true);
            comboBoxSTT.DataBindings.Add(br);

            br = null;
            br = new Binding("Text", bdsStatus, "Status_Desc", true);
            comboBoxSTTNa.DataBindings.Add(br);

            br = null;
            br = new Binding("Text", bdsStatus, "Status_Remark", true);
            textBoxSTTReM.DataBindings.Add(br);

            br = null;
            br = new Binding("Checked", bdsStatus, "Status_Activated", true);
            br.NullValue = false;
            checkBoxSTTACT.DataBindings.Add(br);


        #endregion
        }
        #endregion
       



        private void SaveDB()
        {
            if (!varidate())
            {
                return;
            }

            int result = this._SqlMasterManager6.SaveMastertoDB(this._dtStatus, "106");

            if (result == 1)
            {
                MessageBox.Show("Save to database completed...", "Save data", MessageBoxButtons.OK, MessageBoxIcon.Information);

                refresh();


            }
            else
            {
                MessageBox.Show(this._SqlMasterManager6.LastError6, "Fail Save data", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }


        private bool varidate()
        {

            bdsStatus.EndEdit();
            dgvStatus.EndEdit();

            List<string> dupicate = new List<string>();
            bool dup = false;
            string valueDup = "";


            // check dupicate 
            for (int i = _dtStatus.Rows.Count - 1; i >= 0; i--)
            {
                dr = _dtStatus.Rows[i];
                if (dr.RowState != DataRowState.Deleted)
                {
                    if (!dupicate.Contains(dr["Status_ID"].ToString()))
                    {
                        dupicate.Add(dr["Status_ID"].ToString());
                    }
                    else
                    {
                        dup = true;
                        valueDup = dr["Status_ID"].ToString();
                        break;
                    }
                }

            }
            if (dup)
            {
                MessageBox.Show("Status ID Dupicate : " + valueDup, "Check data", MessageBoxButtons.OK, MessageBoxIcon.Error);

                refresh();
                return false;
            }



            //
            foreach (DataRow drr in _dtStatus.Rows)
            {
                if (drr.RowState == DataRowState.Deleted)
                {
                    continue;
                }
                if (drr["Status_ID"].ToString().Length == 0 &&
                    drr["Status_Desc"].ToString().Length == 0)
                {

                    MessageBox.Show("Not null Status ID, Status Desc", "Check Null ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    refresh();

                    return false;
                }


                if (drr["Status_Desc"].ToString().Length == 0)
                {
                    MessageBox.Show("Not null : " + drr["Status_ID"].ToString(), "Check Null for Status_Desc", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    refresh();
                    return false;
                }



                if (drr["Status_ID"].ToString().Length == 0)
                {
                    MessageBox.Show("Not null : " + drr["Status_ID"].ToString(), "Check Null for Status_ID", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    refresh();
                    return false;
                }

            }


            return true;
        }
        public void SetSecurityForm(bool updatedFlag, bool deletedFlag, bool readFlag)
        {
            this._updatedFlag = updatedFlag;
            this._deleteFlag = deletedFlag;

            this.tsbSave.Enabled = this._updatedFlag;
            this.DEL.Enabled = this._deleteFlag;
        }



        private void refresh()
        {
            this._dtStatus.Rows.Clear();
            this._dtStatus.Merge(this._SqlMasterManager6.GetISI_StatusList());
        }

        private void AddR()
        {
            if (dr != null)
            {
                this._dtStatus.Rows.Add();
                int er = this.dgvStatus.Rows.GetLastRow(DataGridViewElementStates.Displayed);
                er += 0;
                if (this.dgvStatus.CurrentRow.Index < dgvStatus.Rows.Count)
                {
                    dgvStatus.FirstDisplayedScrollingRowIndex = er;
                    dgvStatus.Refresh();
                    dgvStatus.CurrentCell = dgvStatus.Rows[er].Cells[0];
                    dgvStatus.Rows[er].Selected = true;
                    er += 1;

                }
             


                comboBoxSTT.Focus();
                bdsStatus.EndEdit();

            }

        }

        //private void bindingNavigatorAddNewItem1_Click(object sender, EventArgs e)
        //{

        //    textBoxSTTID.Focus();

        //}

        

        //private void bindingNavigatorDeleteItem1_Click(object sender, EventArgs e)
        //{
        //    dgvStatus.CurrentRow.Selected = true;
        //}

        //private void bindingNavigatorMoveFirstItem1_Click_1(object sender, EventArgs e)
        //{
        //    dgvStatus.CurrentRow.Selected = true;
        //}

        //private void bindingNavigatorMovePreviousItem1_Click_1(object sender, EventArgs e)
        //{
        //    dgvStatus.CurrentRow.Selected = true;
        //}

        

        //private void bindingNavigatorMoveNextItem1_Click_1(object sender, EventArgs e)
        //{
        //    dgvStatus.CurrentRow.Selected = true;
        //}

        //private void bindingNavigatorMoveLastItem1_Click_1(object sender, EventArgs e)
        //{
        //    dgvStatus.CurrentRow.Selected = true;
        //}

        //private void bindingNavigatorDeleteItem1_Click_1(object sender, EventArgs e)
        //{
        //    dgvStatus.CurrentRow.Selected = true;
        //}

        private void tsbSave_Click_1(object sender, EventArgs e)
        {
            dgvStatus.CurrentRow.Selected = true;
            this.SaveDB();

            if (dr != null)
            {
                AddR();
            }
            else
            {

            }
        }

        private void bindingNavigatorMoveFirstItem1_Click(object sender, EventArgs e)
        {
            dgvStatus.CurrentRow.Selected = true;
        }

        private void bindingNavigatorMovePreviousItem1_Click(object sender, EventArgs e)
        {
            dgvStatus.CurrentRow.Selected = true;
        }

        private void bindingNavigatorMoveNextItem1_Click(object sender, EventArgs e)
        {
            dgvStatus.CurrentRow.Selected = true;
        }

        private void bindingNavigatorMoveLastItem1_Click(object sender, EventArgs e)
        {
            dgvStatus.CurrentRow.Selected = true;
        }

        private void bindingNavigatorDeleteItem1_Click_2(object sender, EventArgs e)
        {
            dgvStatus.CurrentRow.Selected = true;
        }

        private void bindingNavigatorAddNewItem1_Click_1(object sender, EventArgs e)
        {
            int er = this.dgvStatus.Rows.GetLastRow(DataGridViewElementStates.Displayed);
            er += 0;
            if (this.dgvStatus.CurrentRow.Index < dgvStatus.Rows.Count)
            {
                dgvStatus.FirstDisplayedScrollingRowIndex = er;
                dgvStatus.Refresh();
                dgvStatus.CurrentCell = dgvStatus.Rows[er].Cells[0];
                dgvStatus.Rows[er].Selected = true;
                er += 1;

            }
            comboBoxSTT.Focus();
        }

        private void RefeshBT6_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }


    }
}



