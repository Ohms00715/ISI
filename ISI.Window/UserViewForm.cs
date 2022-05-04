using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISI.Maneger;
using System.Configuration;

namespace ISI.Window
{
    public partial class UserViewForm : Form
    {
        DataTable _dtData = null;
        SqlAdminManeger _SqlAdminManeger = null;

        string _connStr = "";
        string _userID = "";
        string _UVsKey = "";
        string _UVKey = "";
        string _documentKey = "";
        string _documentKey2 = "";
        string _documentKey3 = "";
        string _documentKey4 = "";
        public UserViewForm(string connStr)
        {
            InitializeComponent();
            this._connStr = connStr;
            this.dgvUV.AutoGenerateColumns = false;
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this._SqlAdminManeger = new SqlAdminManeger(this._connStr, this._userID);
            this._dtData = new DataTable();
            this._dtData = this._SqlAdminManeger.GetISI_LOGINList();
            Bitmap bm = new Bitmap(Properties.Resources.ISILOGOUSE);

            // Convert to an icon and use for the form's icon.
            this.Icon = Icon.FromHandle(bm.GetHicon());
            //this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.SetObject();
            this.SetGrid();
        }

        private void SetObject()
        {
            bdsUV.DataSource = _dtData;
            bdnUV.BindingSource = bdsUV;
            this.dgvUV.DataSource = bdsUV;
            dgvUV.ReadOnly = true;
        }

        private void tsbSelect_Click(object sender, EventArgs e)
        {
            selectDocument();
        }

        private void selectDocument()
        {
            if (dgvUV.Rows.Count > 0)
            {
          
                _UVsKey = _dtData.ToString();
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                string ID = this.dgvUV.CurrentRow.Cells["ISI_LOGIN_ID"].Value.ToString();
                string FName = this.dgvUV.CurrentRow.Cells["ISI_LOGIN_FName"].Value.ToString();
                string LName = this.dgvUV.CurrentRow.Cells["ISI_LName"].Value.ToString();
                string Email = this.dgvUV.CurrentRow.Cells["ISI_LOGIN_Email"].Value.ToString();
                DocumenKey = ID.ToString();
                DocumenKey2 = FName.ToString();
                DocumenKey3 = LName.ToString();
                DocumenKey4 = Email.ToString();

                //MessageBox.Show("Doc at"+_documentDKey);


                if (_UVKey != null)
                {
                    this.Close();
                }
            }
      
          
        }
        private void SetGrid()
        {

            DataGridViewCheckBoxColumn CheckColumn = new DataGridViewCheckBoxColumn();
            DataGridViewTextBoxColumn ColumnText = new DataGridViewTextBoxColumn();
            DataGridViewComboBoxColumn cobColumn = new DataGridViewComboBoxColumn();



            //LOGIN_ID
            //                         ,ISI_LOGIN_Password
            //                         ,ISI_LOGIN_FName
            //                         ,ISI_LName
            //                         ,ISI_LOGIN_Address
            //                         ,ISI_LOGIN_Email
            //                         ,ISI_LOGIN_Telephone
            //                         ,ISI_National_ID



            #region Pattern 1
            this.dgvUV.ReadOnly = true;
            this.dgvUV.AutoGenerateColumns = false;
            this.dgvUV.EnableHeadersVisualStyles = false;
            this.dgvUV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;



            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Name = "ISI_LOGIN_ID";
            ColumnText.DataPropertyName = "ISI_LOGIN_ID";
            ColumnText.HeaderText = "User ID";
            ColumnText.Width = 100;
            ColumnText.ReadOnly = true;
            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            this.dgvUV.Columns.Add(ColumnText);



            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Name = "ISI_LOGIN_FName";
            ColumnText.DataPropertyName = "ISI_LOGIN_FName";
            ColumnText.HeaderText = "Frist Name";
            ColumnText.Width = 100;
            ColumnText.ReadOnly = true;
            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            ColumnText.DefaultCellStyle.Format = "dd/MM/yyyy";
            this.dgvUV.Columns.Add(ColumnText);


            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Name = "ISI_LName";
            ColumnText.DataPropertyName = "ISI_LName";
            ColumnText.HeaderText = "Last Name";
            ColumnText.Width = 100;
            ColumnText.ReadOnly = true;
            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            this.dgvUV.Columns.Add(ColumnText);

            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Name = "ISI_LOGIN_Address";
            ColumnText.DataPropertyName = "ISI_LOGIN_Address";
            ColumnText.HeaderText = "Address";
            ColumnText.Width = 100;
            ColumnText.ReadOnly = true;
            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            ColumnText.Visible = false;
            this.dgvUV.Columns.Add(ColumnText);


            
            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Name = "ISI_LOGIN_Email";
            ColumnText.DataPropertyName = "ISI_LOGIN_Email";
            ColumnText.HeaderText = "Email";
            ColumnText.Width = 160;
            ColumnText.ReadOnly = true;
            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            //ColumnText.Visible = false;
            this.dgvUV.Columns.Add(ColumnText);


            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Name = "ISI_LOGIN_Telephone";
            ColumnText.DataPropertyName = "ISI_LOGIN_Telephone";
            ColumnText.HeaderText = "Telephone Numble";
            ColumnText.Width = 150;
            ColumnText.ReadOnly = true;
            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            ColumnText.Visible = false;
            this.dgvUV.Columns.Add(ColumnText);


            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Name = "ISI_National_ID";
            ColumnText.DataPropertyName = "ISI_National_ID";
            ColumnText.HeaderText = "National ID";
            ColumnText.Width = 100;
            ColumnText.ReadOnly = true;
            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            ColumnText.Visible = false;
            this.dgvUV.Columns.Add(ColumnText);


            this.dgvUV.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 15, GraphicsUnit.Pixel);
            foreach (DataGridViewColumn c in dgvUV.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Tahoma", 15, GraphicsUnit.Pixel);

            }
            #endregion

        }
        public string DocumenKey
        {
            get { return _documentKey; }
            set { _documentKey = value; }
        }
        public string DocumenKey2
        {
            get { return _documentKey2; }
            set { _documentKey2 = value; }
        }
        public string DocumenKey3
        {
            get { return _documentKey3; }
            set { _documentKey3 = value; }
        }
        public string DocumenKey4
        {
            get { return _documentKey4; }
            set { _documentKey4 = value; }
        }

        private void dgvUV_DoubleClick(object sender, EventArgs e)
        {
            selectDocument();
        }
    }
}
