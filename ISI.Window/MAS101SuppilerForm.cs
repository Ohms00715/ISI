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
    public partial class MAS101SuppilerForm : Form
    {

        SqlMasterManeger _SqlMasterManager = null;
        DataTable _dtSuppiler = null;
        DataRow dr;
        string _connStr = "";
        string _userID = "";
        public bool _updatedFlag = false;
        public bool _deleteFlag = false;

        public MAS101SuppilerForm(string connStr, string userID)
        {
            InitializeComponent();
            this._connStr = connStr;
            this._userID = userID;
            this._SqlMasterManager = new SqlMasterManeger(this._connStr, this._userID);
            this._dtSuppiler = new DataTable();
            this._dtSuppiler = this._SqlMasterManager.GetISI_SupplierList();
            
            this.SetObject();
            this.BindingSource();
            
            this.dgvSup.AutoGenerateColumns = false;

        }

        #region security check

        public void SetSecurityForm(bool updatedFlag, bool deletedFlag, bool readFlag)
        {
            this._updatedFlag = updatedFlag;
            this._deleteFlag = deletedFlag;

            this.tsbSave.Enabled = this._updatedFlag ;
            this.DEL.Enabled = this._deleteFlag;
        }

        #endregion security check

        #region set Object

        private void SetObject()
        {
            bdsSup.DataSource = _dtSuppiler;
            bdnSuppi.BindingSource = bdsSup;
            this.dgvSup.DataSource = bdsSup;
            dgvSup.ReadOnly = true;
        }

        #endregion

        #region Binding source
        private void BindingSource()
        {
            Binding br;

            br = null;
            br = new Binding("Text", bdsSup, "Sup_ID", true);
            textBoxSubID.DataBindings.Add(br);

            br = null;
            br = new Binding("Text", bdsSup, "Sup_Desc", true);
            textBoxSUBName.DataBindings.Add(br);

            br = null;
            br = new Binding("Checked", bdsSup, "Sup_Activated", true);
            br.NullValue = false;
            checkBoxSUBAct.DataBindings.Add(br);
        }

        #endregion

        private void tsbSave_Click(object sender, EventArgs e)
        {

            dgvSup.NotifyCurrentCellDirty(true);
            dgvSup.CurrentRow.Selected = true;
            this.SaveDB();

            if (dr != null)
            {
                AddR();
            }
            else
            {
              
            }
        }

        

        private void SaveDB()
        {
            if (!varidate())
            {
                return;
            }

            int result = this._SqlMasterManager.SaveMastertoDB(this._dtSuppiler, "101");

            if (result == 1)
            {
                MessageBox.Show("Save to database completed...", "Save data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                refresh();


            }
            else
            {
                MessageBox.Show(this._SqlMasterManager.LastError, "Fail Save data", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

       
        private bool varidate()
        {

            bdsSup.EndEdit();
            dgvSup.EndEdit();

            List<string> dupicate = new List<string>();
            bool dup = false;
            string valueDup = "";


            // check dupicate 
            for (int i = _dtSuppiler.Rows.Count - 1; i >= 0; i--)
            {
                dr = _dtSuppiler.Rows[i];
                if (dr.RowState != DataRowState.Deleted)
                {
                    if (!dupicate.Contains(dr["Sup_ID"].ToString()))
                    {
                        dupicate.Add(dr["Sup_ID"].ToString());
                    }
                    else
                    {
                        dup = true;
                        valueDup = dr["Sup_ID"].ToString();
                        break;
                    }
                }

            }
            if (dup)
            {
                MessageBox.Show("Sup ID Dupicate : " + valueDup, "Check data", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
                refresh();
                return false;
            }



            //
            foreach (DataRow drr in _dtSuppiler.Rows)
            {
                if (drr.RowState == DataRowState.Deleted)
                {
                    continue;
                }
                if (drr["Sup_ID"].ToString().Length == 0 &&
                    drr["Sup_Desc"].ToString().Length == 0)
                {

                    MessageBox.Show("Not null Sup ID, Sup Name", "Check Null ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    refresh();

                    return false;
                }


                if (drr["Sup_Desc"].ToString().Length == 0)
                {
                    MessageBox.Show("Not null : " + drr["SUp_ID"].ToString(), "Check Null for SUP_name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                    refresh();
                    return false;
                }



                if (drr["Sup_ID"].ToString().Length == 0)
                {
                    MessageBox.Show("Not null : " + drr["SUp_ID"].ToString(), "Check Null for SUP_ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                    refresh();
                    return false;
                }

            }


            return true;
        }

        


        private void refresh()
        {
            this._dtSuppiler.Rows.Clear();
            this._dtSuppiler.Merge(this._SqlMasterManager.GetISI_SupplierList());
        }

        private void AddR()
        {
   
            if (dr != null)
            {
                this._dtSuppiler.Rows.Add();
                int er = this.dgvSup.Rows.GetLastRow(DataGridViewElementStates.None);
                er += 0;
                if (this.dgvSup.CurrentRow.Index < dgvSup.Rows.Count)
                {
                    dgvSup.FirstDisplayedScrollingRowIndex = er;
                    dgvSup.Refresh();
                    dgvSup.CurrentCell = dgvSup.Rows[er].Cells[0];
                    dgvSup.Rows[er].Selected = true;
                    er += 1;

                }
                textBoxSubID.Focus();
                bdsSup.EndEdit();

            }

        }

        public void bindingNavigatorAddNewItem_Click_1(object sender, EventArgs e)
        {
            int er = this.dgvSup.Rows.GetLastRow(DataGridViewElementStates.Displayed);
            er += 0;
            if (this.dgvSup.CurrentRow.Index < dgvSup.Rows.Count)
            {
                dgvSup.FirstDisplayedScrollingRowIndex = er;
                dgvSup.Refresh();
                dgvSup.CurrentCell = dgvSup.Rows[er].Cells[0];
                dgvSup.Rows[er].Selected = true;
                er += 1;

            }
            textBoxSubID.Focus();
          
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            dgvSup.CurrentRow.Selected = true;
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            dgvSup.CurrentRow.Selected = true;
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            dgvSup.CurrentRow.Selected = true;
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            dgvSup.CurrentRow.Selected = true;
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            dgvSup.CurrentRow.Selected = true;
        }

        private void RefeshBT1_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void ucTopl12_Load(object sender, EventArgs e)
        {

        }

       
       
        
        


    }
}
