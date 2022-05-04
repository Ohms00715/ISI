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
    public partial class DocumentListForm : Form
    {
        DataTable _dtData = null;
        SqlTransactionManager _SqlTransactionManager = null;

        string _connStr = "";
        string _userID = "";
        string _documentKey = "";

        public DocumentListForm(string connStr)
        {
            InitializeComponent();
            //this._SqlTransactionManager = new SqlTransactionManager(this._connStr, this._userID);
            //this._dsData = new DataSet();
            //this._dsData = this._SqlTransactionManager.GetISI_IncomingList();
            //this.BindingSource();
            //this.SetObject();
            this._connStr = connStr;
            this._SqlTransactionManager = new SqlTransactionManager(this._connStr, this._userID);
            this._dtData = new DataTable();
            this._dtData = this._SqlTransactionManager.GetISI_DocumentList();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            this.SetObject();            
            //this.BindingSource();
            



        }
        private void SetObject()
        {

            bdsDoc2.DataSource = _dtData;
            bdnDOC.BindingSource = bdsDoc2;
            this.dgvDOC.DataSource = bdsDoc2;
            dgvDOC.ReadOnly = true;

        }
       
        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void tsbSelect_Click(object sender, EventArgs e)
        {
            selectDocument();
        }
        private void selectDocument() 
        {

            if (dgvDOC.Rows.Count > 0)
            {
                tsbSelect.Enabled = true;
                DateTime dtDate = (DateTime)this.dgvDOC.CurrentRow.Cells["Doc_Date"].Value;
                _documentKey = dtDate.ToString("yyyyMMdd");
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                if (dtDate != null)
                {
                    this.Close();
                }
                else
                {


                }
            }
            
        }


        #region properties
        public string DocumenKey { 
            get{ return _documentKey;}
            set { _documentKey = value; }
        }

        #endregion 

        private void dgvDOC_DoubleClick(object sender, EventArgs e)
        {

            if (dgvDOC.Rows.Count > 0)
            {
                DateTime dtDate = (DateTime)this.dgvDOC.CurrentRow.Cells["Doc_Date"].Value;
                _documentKey = dtDate.ToString("yyyyMMdd");
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                if (dtDate != null)
                {
                    this.Close();
                }
                else
                {


                }
            }
        }

    }

}
