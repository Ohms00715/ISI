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
    public partial class MAS102MaterialForm : Form
    {
        
        SqlMasterManegerMAT _SqlMasterManager2 = null;
        DataTable _dtMaterial = null;
        DataRow dr;
        string _connStr = "";
        string _userID = "";
        public bool _updatedFlag = false;
        public bool _deleteFlag = false;

        public MAS102MaterialForm(string connStr, string userID)
        {
            InitializeComponent();

            this._connStr = connStr;
            this._userID = userID;
            this._SqlMasterManager2 = new SqlMasterManegerMAT(this._connStr, this._userID);
            this._dtMaterial = new DataTable();
            this._dtMaterial = this._SqlMasterManager2.GetISI_MaterialList();

            this.SetObject();
            this.BindingSource();

        }

        
        #region set Object

        private void SetObject()
        {
            

            bdsMat.DataSource = _dtMaterial;
            bdnMat.BindingSource = bdsMat;
            this.dgvMat.DataSource = bdsMat;
            dgvMat.ReadOnly = true;
        }
           
    #region Binding source
        private void BindingSource()
        {
                        
            Binding br;
            br = null;
            br = new Binding("Text", bdsMat, "Mat_ID", true);
            textBoxMATID.DataBindings.Add(br);
            
            br = null;
            br = new Binding("Text", bdsMat, "Mat_Desc", true);
            textBoxMATName.DataBindings.Add(br);
           
            br = null;
            br = new Binding("Text", bdsMat, "Mat_Code", true);
            textBoxMATCode.DataBindings.Add(br);

            br = null;
            br = new Binding("Checked", bdsMat, "Mat_Activated", true);
            br.NullValue = false;
            checkBox1.DataBindings.Add(br);

            
            #endregion 
        }
        #endregion
        private void tsbSave_Click(object sender, EventArgs e)    
        {
            dgvMat.CurrentRow.Selected = true;
            this.SaveDB();

            if (dr != null)
            {
                AddR();
            }
            else
            {

            }
        }

        #region security check

        public void SetSecurityForm(bool updatedFlag, bool deletedFlag, bool readFlag)
        {
            this._updatedFlag = updatedFlag;
            this._deleteFlag = deletedFlag;

            this.tsbSave.Enabled = this._updatedFlag;
            this.DEL.Enabled = this._deleteFlag;
        }

        #endregion security check

        private void SaveDB()
        {
            if (!varidate())
            {
                return;
            }

            int result = this._SqlMasterManager2.SaveMastertoDB(this._dtMaterial, "102");

            if (result == 1)
            {
                MessageBox.Show("Save to database completed...", "Save data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                refresh();


            }
            else
            {
                MessageBox.Show(this._SqlMasterManager2.LastError2, "Fail Save data", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

       
        private bool varidate()
        {

            bdsMat.EndEdit();
            dgvMat.EndEdit();

            List<string> dupicate = new List<string>();
            bool dup = false;
            string valueDup = "";


            // check dupicate 
            for (int i = _dtMaterial.Rows.Count - 1; i >= 0; i--)
            {
                dr = _dtMaterial.Rows[i];
                if (dr.RowState != DataRowState.Deleted)
                {
                    if (!dupicate.Contains(dr["Mat_ID"].ToString()))
                    {
                        dupicate.Add(dr["Mat_ID"].ToString());
                    }
                    else
                    {
                        dup = true;
                        valueDup = dr["Mat_ID"].ToString();
                        break;
                    }
                }

            }
            if (dup)
            {
                MessageBox.Show("Mat ID Dupicate : " + valueDup, "Check data", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
                refresh();
                return false;
            }



            //
            foreach (DataRow drr in _dtMaterial.Rows)
            {
                if (drr.RowState == DataRowState.Deleted)
                {
                    continue;
                }
                if (drr["Mat_ID"].ToString().Length == 0 &&
                    drr["Mat_Desc"].ToString().Length == 0)
                {

                    MessageBox.Show("Not null Mat ID, Mat Name", "Check Null ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    refresh();

                    return false;
                }


                if (drr["Mat_Desc"].ToString().Length == 0)
                {
                    MessageBox.Show("Not null : " + drr["Mat_ID"].ToString(), "Check Null for Mat_name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                    refresh();
                    return false;
                }



                if (drr["Mat_ID"].ToString().Length == 0)
                {
                    MessageBox.Show("Not null : " + drr["Mat_ID"].ToString(), "Check Null for Mat_ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                    refresh();
                    return false;
                }

            }


            return true;
        }

        


        private void refresh()
        {
            this._dtMaterial.Rows.Clear();
            this._dtMaterial.Merge(this._SqlMasterManager2.GetISI_MaterialList());
        }

        private void AddR()
        {
            if (dr != null)
            {
                this._dtMaterial.Rows.Add();
                int er = this.dgvMat.Rows.GetLastRow(DataGridViewElementStates.Displayed);
                er += 0;
                if (this.dgvMat.CurrentRow.Index < dgvMat.Rows.Count)
                {
                    dgvMat.FirstDisplayedScrollingRowIndex = er;
                    dgvMat.Refresh();
                    dgvMat.CurrentCell = dgvMat.Rows[er].Cells[0];
                    dgvMat.Rows[er].Selected = true;
                    er += 1;

                }

                textBoxMATID.Focus();
                bdsMat.EndEdit();

            }

        }

        private void bindingNavigatorAddNewItem1_Click(object sender, EventArgs e)
        {
            
            textBoxMATID.Focus();
          
        }

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

        private void bindingNavigatorDeleteItem1_Click(object sender, EventArgs e)
        {
            dgvMat.CurrentRow.Selected = true;
        }

        private void bindingNavigatorMoveFirstItem1_Click_1(object sender, EventArgs e)
        {
            dgvMat.CurrentRow.Selected = true;
        }

        private void bindingNavigatorMovePreviousItem1_Click_1(object sender, EventArgs e)
        {
            dgvMat.CurrentRow.Selected = true;
        }

        private void bindingNavigatorPositionItem1_Click(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorMoveNextItem1_Click_1(object sender, EventArgs e)
        {
            dgvMat.CurrentRow.Selected = true;
        }

        private void bindingNavigatorMoveLastItem1_Click_1(object sender, EventArgs e)
        {
            dgvMat.CurrentRow.Selected = true;
        }

        private void bindingNavigatorDeleteItem1_Click_1(object sender, EventArgs e)
        {
            dgvMat.CurrentRow.Selected = true;
        }

        private void RefeshBT2_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void bindingNavigatorAddNewItem1_Click_1(object sender, EventArgs e)
        {
            int er = this.dgvMat.Rows.GetLastRow(DataGridViewElementStates.Displayed);
            er += 0;
            if (this.dgvMat.CurrentRow.Index < dgvMat.Rows.Count)
            {
                dgvMat.FirstDisplayedScrollingRowIndex = er;
                dgvMat.Refresh();
                dgvMat.CurrentCell = dgvMat.Rows[er].Cells[0];
                dgvMat.Rows[er].Selected = true;
                er += 1;

            }
            textBoxMATID.Focus();
        }

        

        
    }
}

    

