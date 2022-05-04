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
    public partial class AD403Authorized_Management_Form : Form
    {
        string _connStr = "";
        string _userID = "";
        DataRow dr;
        SqlAdminManeger _SqlAdminManeger = null;
        DataTable _dtADAuthorize = null;
        public AD403Authorized_Management_Form(string connStr, string userID)
        {
            InitializeComponent();
            this._connStr = connStr;
            this._userID = userID;
            this.dgvADAU.AutoGenerateColumns = false;
            this._SqlAdminManeger = new SqlAdminManeger(this._connStr, this._userID);
            this._dtADAuthorize = new DataTable();
            this._dtADAuthorize = this._SqlAdminManeger.GetISI_AuthorizeList("0");

            //this.SetObject();
            this.BindingSource();
            //this.setCombobox();
            SetGrid();
           


        }

        //private void setCombobox()
        //{
           

        //    #region Tcode

        //    {
        //        DataTable dt = this._SqlAdminManeger.GetISI_FormList();
        //        this.comboBoxTcode.DataSource = dt;
        //        this.comboBoxTcode.DisplayMember = "ISI_Form_Key";
        //        this.comboBoxTcode.ValueMember = "ISI_Form_Key";

        //    }
        //    #endregion
        //}

        private void BindingSource()
        {
            this.bdsADAU.DataSource = _dtADAuthorize;
            this.bdnADAU.BindingSource = bdsADAU;
            this.dgvADAU.DataSource = bdsADAU;
            dgvADAU.ReadOnly = true;
        }

        private void SetObject()
        {
            //Binding br;

            //br = null;
            //br = new Binding("Text", bdsADAU, "ISI_authorize_ID", true);
            ////br.NullValue = false;
            //this.txtUserID.DataBindings.Add(br);

            //br = null;
            //br = new Binding("SelectedValue", bdsADAU, "ISI_authorize_TCode", true);
            ////br.NullValue = false;
            //this.comboBoxTcode.DataBindings.Add(br);

            //br = null;
            //br = new Binding("Checked", bdsADAU, "ISI_authorize_Visible", true);
            ////br.NullValue = false;
            //this.VIS.DataBindings.Add(br);

            //br = null;
            //br = new Binding("Checked", bdsADAU, "ISI_authorize_Update", true);
            ////br.NullValue = false;
            //this.UP.DataBindings.Add(br);

            //br = null;
            //br = new Binding("Checked", bdsADAU, "ISI_authorize_Delect", true);
            ////br.NullValue = false;
            //this.DEL.DataBindings.Add(br);

            //br = null;
            //br = new Binding("Checked", bdsADAU, "ISI_authorize_ReadOnly", true);
            ////br.NullValue = false;
            //this.RO.DataBindings.Add(br);


        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            SaveDB();
        }

        private void SaveDB()
        {
            this.dgvADAU.EndEdit();
            this.bdsADAU.EndEdit();
            if (!varidate())
            {
                return;
            }

            int result = this._SqlAdminManeger.SaveMastertoDB2222(this._dtADAuthorize);

            if (result == 1)
            {
                MessageBox.Show("Save to database completed...", "Save data", MessageBoxButtons.OK, MessageBoxIcon.Information);




            }
            else
            {
                MessageBox.Show(this._SqlAdminManeger.LastError2222, "Fail Save data", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private bool varidate()
        {
            List<string> dupicate = new List<string>();

            if (txtUserID.Text == "")
            {
                MessageBox.Show("Please selected employee code!!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false; 
            }

            /*
             SELECT TOP (1000) ISI_authorize_ID
      ,ISI_authorize_TCode
      ,ISI_authorize_Visible
      ,ISI_authorize_Update
      ,ISI_authorize_Delect
      ,ISI_authorize_ReadOnly
      ,Created_by
      ,Created_time
      ,Updated_by
      ,Updated_time
  FROM ISI_Authorize
             
             */
            

            return true;
        }
        private void refresh()
        {
          
            this._dtADAuthorize.Rows.Clear();
            this._dtADAuthorize.Merge(this._SqlAdminManeger.GetISI_AuthorizeList(""));
        }

        private void RefeshBT1_Click(object sender, EventArgs e)
        {
            refresh();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            UserViewForm form_ = new UserViewForm(this._connStr);
             if (form_.ShowDialog() == System.Windows.Forms.DialogResult.OK)
             {
                 txtUserID.Text = form_.DocumenKey.ToString();
                 this.textBoxFNAME.Text = form_.DocumenKey2.ToString();
                 this.textBoxLName.Text = form_.DocumenKey3.ToString();
                 this.textBoxEmail.Text = form_.DocumenKey4.ToString();
                 GetData();
             }
        }

        private void GetData() 
        {

            string userID = txtUserID.Text;
            this._dtADAuthorize.Rows.Clear();
            this._dtADAuthorize.Merge(this._SqlAdminManeger.GetISI_AuthorizeList(userID));
        }
        private void SetGrid()
        {

            DataGridViewCheckBoxColumn CheckColumn = new DataGridViewCheckBoxColumn();
            DataGridViewTextBoxColumn ColumnText = new DataGridViewTextBoxColumn();
            DataGridViewComboBoxColumn cobColumn = new DataGridViewComboBoxColumn();

            #region Pattern 1
            this.dgvADAU.ReadOnly = false;
            this.dgvADAU.AutoGenerateColumns = false;
            this.dgvADAU.EnableHeadersVisualStyles = false;
            this.dgvADAU.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;


            //ISI_Form_Key
            //                                ,f.ISI_Form_Desc
            //                                ,f.ISI_Form_Group
            //                                ,f.Activated
            //                                ,f.Created_by
            //                                ,f.Created_time
            //                                ,f.Updated_by
            //                                ,f.Updated_time
            //                                ,v.ISI_LOGIN_ID
            //                                ,v.ISI_LOGIN_Password
            //                                ,v.ISI_LOGIN_FName
            //                                ,v.ISI_LName
            //                                ,v.ISI_LOGIN_Address
            //                                ,v.ISI_LOGIN_Email
            //                                ,v.ISI_LOGIN_Telephone
            //                                ,v.ISI_National_ID
            //                                ,v.ISI_authorize_ID
            //                                ,v.ISI_authorize_TCode
            //                                ,v.ISI_authorize_Visible
            //                                ,v.ISI_authorize_Update
            //                                ,v.ISI_authorize_Delect
            //                                ,v.ISI_authorize_ReadOnly
            //                                ,v.Created_by
            //                                ,v.Created_time
            //                                ,v.Updated_by
            //                                ,v.Updated_time
            //                                FROM ISI_Form as f               
            //                                LEFT OUTER JOIN 
            //                                (select a.ISI_authorize_ID
            //                                ,a.ISI_authorize_TCode
            //                                ,a.ISI_authorize_Visible
            //                                ,a.ISI_authorize_Update
            //                                ,a.ISI_authorize_Delect
            //                                ,a.ISI_authorize_ReadOnly
            //                                ,a.Created_by
            //                                ,a.Created_time
            //                                ,a.Updated_by
            //                                ,l.ISI_LOGIN_ID
            //                                ,l.ISI_LOGIN_Password
            //                                ,l.ISI_LOGIN_FName
            //                                ,l.ISI_LName
            //                                ,l.ISI_LOGIN_Address
            //                                ,l.ISI_LOGIN_Email
            //                                ,l.ISI_LOGIN_Telephone
            //                                ,l.ISI_National_ID

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
            ColumnText.Visible = false;
            this.dgvADAU.Columns.Add(ColumnText);



            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Name = "ISI_authorize_TCode";
            ColumnText.DataPropertyName = "ISI_authorize_TCode";
            ColumnText.HeaderText = "TCode";
            ColumnText.Width = 100;
            ColumnText.ReadOnly = true;
            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;         
            this.dgvADAU.Columns.Add(ColumnText);


            CheckColumn = new DataGridViewCheckBoxColumn();
            CheckColumn.Name = "ISI_authorize_Visible";
            CheckColumn.DataPropertyName = "ISI_authorize_Visible";
            CheckColumn.HeaderText = "Visible";
            CheckColumn.Width = 100;
            CheckColumn.ReadOnly = false;
            CheckColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            CheckColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            CheckColumn.HeaderCell.Style.BackColor = Color.LightGray;
            CheckColumn.HeaderCell.Style.ForeColor = Color.Blue;
            this.dgvADAU.Columns.Add(CheckColumn);


            CheckColumn = new DataGridViewCheckBoxColumn();
            CheckColumn.Name = "ISI_authorize_Update";
            CheckColumn.DataPropertyName = "ISI_authorize_Update";
            CheckColumn.HeaderText = "Update";
            CheckColumn.Width = 100;
            CheckColumn.ReadOnly = false;
            CheckColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            CheckColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            CheckColumn.HeaderCell.Style.BackColor = Color.LightGray;
            CheckColumn.HeaderCell.Style.ForeColor = Color.Blue;
            this.dgvADAU.Columns.Add(CheckColumn);

            CheckColumn = new DataGridViewCheckBoxColumn();
            CheckColumn.Name = "ISI_authorize_Delect";
            CheckColumn.DataPropertyName = "ISI_authorize_Delect";
            CheckColumn.HeaderText = "Delect";
            CheckColumn.Width = 100;
            CheckColumn.ReadOnly = false;
            CheckColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            CheckColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            CheckColumn.HeaderCell.Style.BackColor = Color.LightGray;
            CheckColumn.HeaderCell.Style.ForeColor = Color.Blue;
            this.dgvADAU.Columns.Add(CheckColumn);




            CheckColumn = new DataGridViewCheckBoxColumn();
            CheckColumn.Name = "ISI_authorize_ReadOnly";
            CheckColumn.DataPropertyName = "ISI_authorize_ReadOnly";
            CheckColumn.HeaderText = "ReadOnly";
            CheckColumn.Width = 100;
            CheckColumn.ReadOnly = false;
            //ColumnText.DefaultCellStyle.Format = "HH:mm";

            CheckColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            CheckColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            CheckColumn.HeaderCell.Style.BackColor = Color.LightGray;
            CheckColumn.HeaderCell.Style.ForeColor = Color.Blue;
            this.dgvADAU.Columns.Add(CheckColumn);
          




            this.dgvADAU.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 15, GraphicsUnit.Pixel);
            foreach (DataGridViewColumn c in dgvADAU.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Tahoma", 15, GraphicsUnit.Pixel);

            }
            #endregion

        }

    }
}
