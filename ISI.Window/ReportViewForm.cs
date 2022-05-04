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
    public partial class ReportViewForm : Form
    {
        DataTable _dtData = null;
        SqlTransactionManager _SqlTransactionManager = null;

        string _connStr = "";
        string _userID = "";
        string _documentKey = "";
        string _documentDKey = "";
        public ReportViewForm(string connStr)
        {
            InitializeComponent();
            this._connStr = connStr;
            this._SqlTransactionManager = new SqlTransactionManager(this._connStr, this._userID);
            this._dtData = new DataTable();
            this._dtData = this._SqlTransactionManager.GetISI_DocumentList();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            //this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.SetObject();            
        }
        private void SetObject()
        {

            bdsDoc2.DataSource = _dtData;
            bdnDOC.BindingSource = bdsDoc2;
            this.dgvDOC.DataSource = bdsDoc2;
            dgvDOC.ReadOnly = true;

        }
        private void tsbSelect_Click(object sender, EventArgs e)
        {
            selectDocument();
        }
        private void selectDocument()
        {

            if (dgvDOC.Rows.Count > 0)
            {
                DateTime dtDate = (DateTime)this.dgvDOC.CurrentRow.Cells["Doc_Date"].Value;
                _documentKey = dtDate.ToString("yyyyMMdd");
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                string docID = this.dgvDOC.CurrentRow.Cells["Doc_ID"].Value.ToString();
                DocumenKeys = docID.ToString();

                //MessageBox.Show("Doc at"+_documentDKey);
                
                
                if (dtDate != null)
                {
                    this.Close();
                }
            }

        }


        #region properties
        public string DocumenKey
        {
            get { return _documentKey; }
            set { _documentKey = value; }
        }
        public string DocumenKeys
        {
            get { return _documentDKey; }
            set { _documentDKey = value; }
        }

        #endregion

        

        private void tsbSelect_Click_1(object sender, EventArgs e)
        {
            selectDocument();
        }

        private void dgvDOC_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
             selectDocument();
              
        }

       
    }
}
