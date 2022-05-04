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
    public partial class MAS104DefectForm : Form
    {
        public bool _updatedFlag = false;
        public bool _deleteFlag = false;
        SqlMasterManegerDEF _SqlMasterManager4 = null;
        DataTable _dtDefect = null;
        DataRow dr;
        string _connStr = "";
        string _userID = "";


        public MAS104DefectForm(string connStr, string userID)
        {
            InitializeComponent();

            this._connStr = connStr;
            this._userID = userID;
            this._SqlMasterManager4 = new SqlMasterManegerDEF(this._connStr, this._userID);
            this._dtDefect = new DataTable();
            this._dtDefect = this._SqlMasterManager4.GetISI_DefectList();
            this.SetObject();
            this.BindingSource();


        }


        #region set Object

        private void SetObject()
        {


            bdsDef2.DataSource = _dtDefect;
            bdnDef.BindingSource = bdsDef2;
            this.dgvDef.DataSource = bdsDef2;
            dgvDef.ReadOnly = true;
        }

        #region Binding source
        private void BindingSource()
        {

            Binding br;
            br = null;
            br = new Binding("Text", bdsDef2, "Def_ID", true);
            textBoxDEFID.DataBindings.Add(br);

            br = null;
            br = new Binding("Text", bdsDef2, "Def_Desc", true);
            textBoxDEFName.DataBindings.Add(br);

            br = null;
            br = new Binding("Text", bdsDef2, "Def_Remark", true);
            textBoxDEFRe.DataBindings.Add(br);

            br = null;
            br = new Binding("Checked", bdsDef2, "Def_Activated", true);
            br.NullValue = false;
            checkBoxDEFACT.DataBindings.Add(br);


        #endregion
        }
        #endregion




        private void SaveDB()
        {
            if (!varidate())
            {
                return;
            }

            int result = this._SqlMasterManager4.SaveMastertoDB(this._dtDefect, "104");

            if (result == 1)
            {
                MessageBox.Show("Save to database completed...", "Save data", MessageBoxButtons.OK, MessageBoxIcon.Information);

                refresh();


            }
            else
            {
                MessageBox.Show(this._SqlMasterManager4.LastError4, "Fail Save data", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }


        private bool varidate()
        {

            bdsDef2.EndEdit();
            dgvDef.EndEdit();

            List<string> dupicate = new List<string>();
            bool dup = false;
            string valueDup = "";


            // check dupicate 
            for (int i = _dtDefect.Rows.Count - 1; i >= 0; i--)
            {
                dr = _dtDefect.Rows[i];
                if (dr.RowState != DataRowState.Deleted)
                {
                    if (!dupicate.Contains(dr["Def_ID"].ToString()))
                    {
                        dupicate.Add(dr["Def_ID"].ToString());
                    }
                    else
                    {
                        dup = true;
                        valueDup = dr["Def_ID"].ToString();
                        break;
                    }
                }

            }
            if (dup)
            {
                MessageBox.Show("Def ID Dupicate : " + valueDup, "Check data", MessageBoxButtons.OK, MessageBoxIcon.Error);

                refresh();
                return false;
            }



            foreach (DataRow drr in _dtDefect.Rows)
            {
                if (drr.RowState == DataRowState.Deleted)
                {
                    continue;
                }
                if (drr["Def_ID"].ToString().Length == 0 &&
                    drr["Def_Desc"].ToString().Length == 0)
                {

                    MessageBox.Show("Not null Def ID, Def Desc", "Check Null ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    refresh();

                    return false;
                }


                if (drr["Def_Desc"].ToString().Length == 0)
                {
                    MessageBox.Show("Not null : " + drr["Def_ID"].ToString(), "Check Null for Def_Desc", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    refresh();
                    return false;
                }



                if (drr["Def_ID"].ToString().Length == 0)
                {
                    MessageBox.Show("Not null : " + drr["Def_ID"].ToString(), "Check Null for Def_ID", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
            this._dtDefect.Rows.Clear();
            this._dtDefect.Merge(this._SqlMasterManager4.GetISI_DefectList());
        }

        private void AddR()
        {
            if (dr != null)
            {
                this._dtDefect.Rows.Add();
                int er = this.dgvDef.Rows.GetLastRow(DataGridViewElementStates.Displayed);
                er += 0;
                if (this.dgvDef.CurrentRow.Index < dgvDef.Rows.Count)
                {
                    dgvDef.FirstDisplayedScrollingRowIndex = er;
                    dgvDef.Refresh();
                    dgvDef.CurrentCell = dgvDef.Rows[er].Cells[0];
                    dgvDef.Rows[er].Selected = true;
                    er += 1;

                }


                textBoxDEFID.Focus();
                bdsDef2.EndEdit();

            }

        }

        //private void bindingNavigatorAddNewItem1_Click(object sender, EventArgs e)
        //{

        //    textBoxDEFID.Focus();

        //}

        //private void bindingNavigatorMoveNextItem1_Click(object sender, EventArgs e)
        //{
        //    dgvMat.CurrentRow.Selected = true;
        //}

        //private void bindingNavigatorMoveLastItem1_Click(object sender, EventArgs e)
        //{
        //    dgvMat.CurrentRow.Selected = true;
        //}

        //private void bindingNavigatorMovePreviousItem1_Click(object sender, EventArgs e)
        //{
        //    dgvMat.CurrentRow.Selected = true;
        //}

        //private void bindingNavigatorMoveFirstItem1_Click(object sender, EventArgs e)
        //{
        //    dgvMat.CurrentRow.Selected = true;
        //}

        //private void bindingNavigatorDeleteItem1_Click(object sender, EventArgs e)
        //{
        //    dgvDef.CurrentRow.Selected = true;
        //}

        //private void bindingNavigatorMoveFirstItem1_Click_1(object sender, EventArgs e)
        //{
        //    dgvDef.CurrentRow.Selected = true;
        //}

        //private void bindingNavigatorMovePreviousItem1_Click_1(object sender, EventArgs e)
        //{
        //    dgvDef.CurrentRow.Selected = true;
        //}

      

        //private void bindingNavigatorMoveNextItem1_Click_1(object sender, EventArgs e)
        //{
        //    dgvDef.CurrentRow.Selected = true;
        //}

        //private void bindingNavigatorMoveLastItem1_Click_1(object sender, EventArgs e)
        //{
        //    dgvDef.CurrentRow.Selected = true;
        //}

        //private void bindingNavigatorDeleteItem1_Click_1(object sender, EventArgs e)
        //{
        //    dgvDef.CurrentRow.Selected = true;
        //}

        ////private void bindingNavigatorMoveFirstItem1_Click(object sender, EventArgs e)
        ////{
        ////    dgvDef.CurrentRow.Selected = true;
        ////}

        //private void bindingNavigatorAddNewItem1_Click_1(object sender, EventArgs e)
        //{
        //    textBoxDEFID.Focus();
        //}

        //private void bindingNavigatorDeleteItem1_Click_2(object sender, EventArgs e)
        //{
        //    dgvDef.CurrentRow.Selected = true;
        //}

        //private void bindingNavigatorMovePreviousItem1_Click(object sender, EventArgs e)
        //{
        //    dgvDef.CurrentRow.Selected = true;
        //}

        //private void bindingNavigatorMoveNextItem1_Click(object sender, EventArgs e)
        //{
        //    dgvDef.CurrentRow.Selected = true;
        //}

        //private void bindingNavigatorMoveLastItem1_Click(object sender, EventArgs e)
        //{
        //    dgvDef.CurrentRow.Selected = true;
        //}

        //private void RefeshBT4_Click(object sender, EventArgs e)
        //{
        //    this.Refresh();
        //}

        private void tsbSave_Click(object sender, EventArgs e)
        {
            dgvDef.NotifyCurrentCellDirty(true);
            dgvDef.CurrentRow.Selected = true;
            this.SaveDB();

            if (dr != null)
            {
                AddR();
            }
            else
            {

            }
        }
        #region
        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            dgvDef.CurrentRow.Selected = true;
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            int er = this.dgvDef.Rows.GetLastRow(DataGridViewElementStates.Displayed);
            er += 0;
            if (this.dgvDef.CurrentRow.Index < dgvDef.Rows.Count)
            {
                dgvDef.FirstDisplayedScrollingRowIndex = er;
                dgvDef.Refresh();
                dgvDef.CurrentCell = dgvDef.Rows[er].Cells[0];
                dgvDef.Rows[er].Selected = true;
                er += 1;

            }
            textBoxDEFID.Focus();
        }
        

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            dgvDef.CurrentRow.Selected = true;
        }
        

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            dgvDef.CurrentRow.Selected = true;
        }
         

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            dgvDef.CurrentRow.Selected = true;
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            dgvDef.CurrentRow.Selected = true;
        }

        private void RefeshBT1_Click(object sender, EventArgs e)
        {
            Refresh();
        }
        #endregion

        
    }
}

        

