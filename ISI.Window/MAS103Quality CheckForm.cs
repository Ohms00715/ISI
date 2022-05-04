
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
    public partial class MAS103Quality_CheckForm : Form
    {

        SqlMasterManegerQC _SqlMasterManager3 = null;
        DataTable _dtQuality_Check = null;
        DataRow dr;
        string _connStr = "";
        string _userID = "";
        public bool _updatedFlag = false;
        public bool _deleteFlag = false;


        public MAS103Quality_CheckForm(string connStr, string userID)
        {
            InitializeComponent();

            this._connStr = connStr;
            this._userID = userID;
            this._SqlMasterManager3 = new SqlMasterManegerQC(this._connStr, this._userID);
            this._dtQuality_Check = new DataTable();
            this._dtQuality_Check = this._SqlMasterManager3.GetISI_Quality_CheckList();

            this.SetObject();
            this.BindingSource();


        }


        #region set Object

        private void SetObject()
        {


            bdsQC.DataSource = _dtQuality_Check;
            bdnQC.BindingSource = bdsQC;
            this.dgvQC.DataSource = bdsQC;
            dgvQC.ReadOnly = true;
        }

        #region Binding source
        private void BindingSource()
        {

            Binding br;
            br = null;
            br = new Binding("Text", bdsQC, "QC_ID", true);                                         
            textBoxQCID.DataBindings.Add(br);

            br = null;
            br = new Binding("Text", bdsQC, "QC_First_name", true);
            textBoxQCFName.DataBindings.Add(br);

            br = null;
            br = new Binding("Text", bdsQC, "QC_Last_name", true);
            textBoxQCLName.DataBindings.Add(br);

            br = null;
            br = new Binding("Text", bdsQC, "QC_Department", true);
            textBoxQCDEP.DataBindings.Add(br);


            br = null;
            br = new Binding("Checked", bdsQC, "QC_Activated", true);
            br.NullValue = false;
            checkBox3.DataBindings.Add(br);

            br = null;
            br = new Binding("Checked", bdsQC, "QC_For_Create", true);
            br.NullValue = false;
            checkBox5.DataBindings.Add(br);

            br = null;
            br = new Binding("Checked", bdsQC, "QC_For_Appproved", true);
            br.NullValue = false;
            checkBox4.DataBindings.Add(br);


        #endregion
        }
        public void SetSecurityForm(bool updatedFlag, bool deletedFlag, bool readFlag)
        {
            this._updatedFlag = updatedFlag;
            this._deleteFlag = deletedFlag;

            this.tabSaveQC.Enabled = this._updatedFlag;
            this.DEL.Enabled = this._deleteFlag;
        }
        #endregion
        private void tabSaveQC_Click(object sender, EventArgs e)
        {
            
            dgvQC.CurrentRow.Selected = true;
            this.SaveDB();
           
            if (dr != null)
            {
       
                AddR();
                
            }
         
        }



        private void SaveDB()
        {
            if (!varidate())
            {
                return;
            }

            int result = this._SqlMasterManager3.SaveMastertoDB(this._dtQuality_Check, "103");

            if (result == 1)
            {
                MessageBox.Show("Save to database completed...", "Save data", MessageBoxButtons.OK, MessageBoxIcon.Information);

                refresh();


            }
            else
            {
                MessageBox.Show(this._SqlMasterManager3.LastError3, "Fail Save data", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }


        private bool varidate()
        {

            bdsQC.EndEdit();
            dgvQC.EndEdit();

            List<string> dupicate = new List<string>();
            bool dup = false;
            string valueDup = "";


            // check dupicate 
            for (int i = _dtQuality_Check.Rows.Count - 1; i >= 0; i--)
            {
                dr = _dtQuality_Check.Rows[i];
                if (dr.RowState != DataRowState.Deleted)
                {
                    if (!dupicate.Contains(dr["QC_ID"].ToString()))
                    {
                        dupicate.Add(dr["QC_ID"].ToString());
                    }
                    else
                    {
                        dup = true;
                        valueDup = dr["QC_ID"].ToString();
                        break;
                    }
                }

            }
            if (dup)
            {
                MessageBox.Show("QC ID Dupicate : " + valueDup, "Check data", MessageBoxButtons.OK, MessageBoxIcon.Error);

                refresh();
                return false;
            }



            //
            foreach (DataRow drr in _dtQuality_Check.Rows)
            {
                if (drr.RowState == DataRowState.Deleted)
                {
                    continue;
                }
                if (drr["QC_ID"].ToString().Length == 0 &&
                    drr["QC_First_name"].ToString().Length == 0&&
                    drr["QC_Last_name"].ToString().Length == 0)
                {

                    MessageBox.Show("Not null QC ID, QC FirstName,QC Last Name", "Check Null ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    refresh();

                    return false;
                }


                if (drr["QC_First_Name"].ToString().Length == 0)
                {
                    MessageBox.Show("Not null : " + drr["QC_ID"].ToString(), "Check Null for QC_First_Name", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    refresh();
                    return false;
                }

                if (drr["QC_Last_Name"].ToString().Length == 0)
                {
                    MessageBox.Show("Not null : " + drr["QC_ID"].ToString(), "Check Null for QC_Last_Name", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    refresh();
                    return false;
                }

                if (drr["QC_ID"].ToString().Length == 0)
                {
                    MessageBox.Show("Not null : " + drr["QC_ID"].ToString(), "Check Null for QC_ID", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    refresh();
                    return false;
                }

            }


            return true;
        }




        private void refresh()
        {
            this._dtQuality_Check.Rows.Clear();
            this._dtQuality_Check.Merge(this._SqlMasterManager3.GetISI_Quality_CheckList());
        }

        private void AddR()
        {

             
            if (dr != null)
            {
                this._dtQuality_Check.Rows.Add();
                int er = this.dgvQC.Rows.GetLastRow(DataGridViewElementStates.Displayed);
                er += 0;
                if (this.dgvQC.CurrentRow.Index < dgvQC.Rows.Count)
                {
                    dgvQC.FirstDisplayedScrollingRowIndex = er;
                    dgvQC.Refresh();
                    dgvQC.CurrentCell = dgvQC.Rows[er].Cells[0];
                    dgvQC.Rows[er].Selected = true;
                    er += 1;

                }
               
                
              

                textBoxQCID.Focus();
                bdsQC.EndEdit();

            }

        }

        //public void bindingNavigatorAddNewItem_Click_1(object sender, EventArgs e)
        //{

        //    textBoxQCID.Focus();

        //}

        //private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        //{
        //    dgvQC.CurrentRow.Selected = true;
        //}

        //private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        //{
        //    dgvQC.CurrentRow.Selected = true;
        //}

        //private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        //{
        //    dgvQC.CurrentRow.Selected = true;
        //}

        //private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        //{
        //    dgvQC.CurrentRow.Selected = true;
        //}

        //private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        //{
        //    dgvQC.CurrentRow.Selected = true;
        //}

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            int er = this.dgvQC.Rows.GetLastRow(DataGridViewElementStates.Displayed);
            er += 0;
            if (this.dgvQC.CurrentRow.Index < dgvQC.Rows.Count)
            {
                dgvQC.FirstDisplayedScrollingRowIndex = er;
                dgvQC.Refresh();
                dgvQC.CurrentCell = dgvQC.Rows[er].Cells[0];
                dgvQC.Rows[er].Selected = true;
                er += 1;

            }
            textBoxQCID.Focus();
        }

        private void bindingNavigatorMoveFirstItem_Click_1(object sender, EventArgs e)
        {
            dgvQC.CurrentRow.Selected = true;
        }

        private void bindingNavigatorMovePreviousItem_Click_1(object sender, EventArgs e)
        {
            dgvQC.CurrentRow.Selected = true;
        }

        private void bindingNavigatorMoveNextItem_Click_1(object sender, EventArgs e)
        {
            dgvQC.CurrentRow.Selected = true;
        }

        private void bindingNavigatorMoveLastItem_Click_1(object sender, EventArgs e)
        {
            dgvQC.CurrentRow.Selected = true;
        }

        private void bindingNavigatorDeleteItem_Click_1(object sender, EventArgs e)
        {
            dgvQC.CurrentRow.Selected = true;
        }

        private void RefeshBT3_Click(object sender, EventArgs e)
        {
            this.Refresh();
            dgvQC.CurrentRow.Selected = true;
        }

        

    }
}

    



        
    

