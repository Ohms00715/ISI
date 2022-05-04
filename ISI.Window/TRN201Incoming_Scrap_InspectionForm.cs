using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISI.Maneger;
using System.IO;


namespace ISI.Window
{
    public partial class TRN201Incoming_Scrap_InspectionForm : Form
    {

        SqlTransactionManager _SqlTransactionManager = null;

        DataSet _dsData = null;
        DataSet _dsCob = null;
        DataRow dr;
        DataRow dr2;
        public bool _updatedFlag = false;
        public bool _deleteFlag = false;
        decimal A = 0;
        decimal B;
        decimal sum;
        //System.Nullable<DateTime> Nulldatetime;
        DataTable dt = null;


        string _connStr = "";
        string _userID = "";

        public TRN201Incoming_Scrap_InspectionForm(string connStr, string userID)
        {

            InitializeComponent();
            this._connStr = connStr;
            this._userID = userID;
            dateTimePickerDOCD.Value = DateTime.Now;
            dateTimePickerDOCAPPD.Value = dateTimePickerDOCD.Value.ToUniversalTime();
            dateTimePickerTICWINT.Value = dateTimePickerDOCD.Value.ToUniversalTime();
            dateTimePickerTICWOT.Value = dateTimePickerDOCD.Value.ToUniversalTime();
            dateTimePickerTICWNT.Value = dateTimePickerDOCD.Value.ToUniversalTime();

          
            this._SqlTransactionManager = new SqlTransactionManager(this._connStr, this._userID);
            this._dsData = new DataSet();
            this._dsData = this._SqlTransactionManager.GetISI_IncomingList("");
            this._dsCob = new DataSet();
            this._dsCob = this._SqlTransactionManager.GetISI_ComboboxList();
            this.dgvDEF.AutoGenerateColumns = false;
            this.dgvISI.AutoGenerateColumns = false;
            this.dgvPIC.AutoGenerateColumns = false;
            this.dt = new DataTable();
            this.dt = this._SqlTransactionManager.GetISI_DocumentList();
            this.SetObject();
            this.setCombobox();

            this.BindingSource();
            DataTable dt = _dsData.Tables[0];
            textBoxDefRE.Enabled = false;

            if (checkBoxTICFLAG.CheckState == 0)
            {
                dateTimePickerDOCAPPD.Enabled = false;


            }
            //if (textBoxTICNUM.Text == "")
            //{
            //    comboBoxDOCQC.SelectedValue = "";
            //    comboBoxDOCLG.SelectedValue = "";
            //    comboBoxDOCAPP.SelectedValue = "";
            //}
            //int i;
           

        }

        #region set Object

        private void SetObject()
        {
            bdsDOC.DataSource = this._dsData.Tables[this._SqlTransactionManager.TableNameISI_Document];
            bdnDOC.BindingSource = bdsDOC;
            //this.dgvDOC.DataSource = bdsDOC;
            //dgvDOC.ReadOnly = true;

            bdsISI.DataSource = this._dsData.Tables[this._SqlTransactionManager.TableNameISI_Incoming]; //bdsDOC;
            // bdsISI.DataMember = this._SqlTransactionManager.F_K_Incoming;
            bdnISI.BindingSource = bdsISI;
            this.dgvISI.DataSource = bdsISI;
            dgvISI.ReadOnly = true;

            bdsDEF.DataSource = bdsISI;
            bdsDEF.DataMember = this._SqlTransactionManager.F_K_Defect;
            bdnDef.BindingSource = bdsDEF;
            this.dgvDEF.DataSource = bdsDEF;
            dgvDEF.ReadOnly = true;


            bdsPIC.DataSource = bdsISI;
            bdsPIC.DataMember = this._SqlTransactionManager.F_K_Pictures;
            bdnPic.BindingSource = bdsPIC;
            this.dgvPIC.DataSource = bdsPIC;
            dgvPIC.ReadOnly = true;


        }

        private void BindingSource()
        {

            Binding br;
            br = null;
            br = new Binding("Text", bdsDOC, "Doc_ID", true);
            textBoxDOCID.DataBindings.Add(br);

            br = null;
            br = new Binding("Text", bdsDOC, "Doc_Des", true);
            textBoxDOCDesc.DataBindings.Add(br);

            br = null;
            br = new Binding("Value", bdsDOC, "Doc_Date", true);
            dateTimePickerDOCD.DataBindings.Add(br);

            br = null;
            br = new Binding("Text", bdsDOC, "Doc_Running", true);
            this.textBoxDocrun.DataBindings.Add(br);

            br = null;
            br = new Binding("SelectedValue", bdsDOC, "QC_Inspector", true);
            br.NullValue = false;
            this.comboBoxDOCQC.DataBindings.Add(br);

            br = null;
            br = new Binding("SelectedValue", bdsDOC, "LG_Inspector", true);
            br.NullValue = false;
            this.comboBoxDOCLG.DataBindings.Add(br);

            br = null;
            br = new Binding("SelectedValue", bdsDOC, "Approved_Inspector", true);
            br.NullValue = false;
            this.comboBoxDOCAPP.DataBindings.Add(br);



            br = null;
            br = new Binding("Text", bdsISI, "Trn_Ticket", true);
            textBoxTICNUM.DataBindings.Add(br);

            br = null;
            br = new Binding("Text", bdsISI, "Trn_PO", true);
            textBoxTICPO.DataBindings.Add(br);

            br = null;
            br = new Binding("Text", bdsISI, "Trn_Truck_Id", true);
            textBoxTICVeh.DataBindings.Add(br);

            br = null;
            br = new Binding("Text", bdsISI, "Trn_Date", true);
            dateTimePickerTICTD.DataBindings.Add(br);

            br = null;
            br = new Binding("Value", bdsISI, "Trn_Deduct_QC", true);
            this.QCW.DataBindings.Add(br);

            //br = null;
            //br = new Binding("Text", bdsISI, "Trn_Deduct_LG", true);
            //textBoxTICLG.DataBindings.Add(br);

            br = null;
            br = new Binding("Value", bdsISI, "Trn_Weight_IN", true);
            br.NullValue = false;
            this.INW.DataBindings.Add(br);

            br = null;
            br = new Binding("Value", bdsISI, "Trn_Weight_IN_Time", true);
            dateTimePickerTICWINT.DataBindings.Add(br);

            br = null;
            br = new Binding("Value", bdsISI, "Trn_Weight_OUT", true);
            br.NullValue = false;
            this.OUTW.DataBindings.Add(br);

            br = null;
            br = new Binding("Value", bdsISI, "Trn_Weight_OUT_Time", true);
            dateTimePickerTICWOT.DataBindings.Add(br);

            br = null;
            br = new Binding("Value", bdsISI, "Trn_Weight_Net", true);
            br.NullValue = false;
            this.NETW.DataBindings.Add(br);

            br = null;
            br = new Binding("Value", bdsISI, "Trn_Weight_Net_Time", true);
            dateTimePickerTICWNT.DataBindings.Add(br);

            br = null;
            br = new Binding("Checked", bdsISI, "Approved_Flag", true);
            br.NullValue = false;
            checkBoxTICFLAG.DataBindings.Add(br);

            br = null;
            br = new Binding("Text", bdsISI, "Trn_Ticket_Run", true);
            br.NullValue = false;
            textBoxTicketRun.DataBindings.Add(br);

            br = null;
            br = new Binding("Text", bdsISI, "Mat_Code", true);
            textBoxTICMATC.DataBindings.Add(br);
            //

           

            br = null;
            br = new Binding("SelectedValue", bdsDEF, "Def_ID", true);
            br.NullValue = false;
            //this.cobDefectName.DataBindings.Add(br);

            br = null;
            br = new Binding("Text", bdsDEF, "Def_Desc", true);
            this.cobDefectName.DataBindings.Equals(cobDefectName);
            //this.cobDefectName.DataBindings.Add(br);

            
            br = null;
            br = new Binding("Value", bdsDEF, "In_Def_Weigth_Kg", true);
            br.NullValue = false;
            DW.DataBindings.Add(br);


            //foreach (DataGridViewRow drg in this.dgvDEF.Rows)
            //{

            //    sum += Convert.ToDecimal(drg.Cells["In_Def_Weigth_Kg"].Value);

            //    if (sum > A)
            //    {                 
            //        DW.Focus();
            //        break;
            //    }
            //    else
            //    {
            //         DW.DataBindings.Add(br);
            //    }
            //}


            br = null;
            br = new Binding("Text", bdsDEF, "Def_Remark", true);
            br.NullValue = false;
            this.textBoxDefRE.DataBindings.Equals(this._SqlTransactionManager.GetDefectRemarkByKey(cobDefectName.SelectedValue.ToString()));
            this.textBoxDefRE.DataBindings.Add(br);




            br = null;
            br = new Binding("Value", bdsISI, "Inspector_Approved_Date", true);
            br.NullValue = false;
            dateTimePickerDOCAPPD.DataBindings.Add(br);


            br = null;
            br = new Binding("SelectedValue", bdsISI, "Inspector_Approved", true);
            br.NullValue = false;
            this.cb_Inspectror_App.DataBindings.Add(br);

            br = null;
            br = new Binding("SelectedValue", bdsISI, "Sup_ID", true);
            this.comboBoxTICSUB.DataBindings.Add(br);

            br = null;
            br = new Binding("SelectedValue", bdsISI, "Mat_Id", true);
            this.comboBoxTICMAT.DataBindings.Add(br);

            br = null;
            br = new Binding("SelectedValue", bdsISI, "Status_ID", true);
            this.comboBoxTICSTT.DataBindings.Add(br);



            br = null;
            br = new Binding("Text", bdsPIC, "Pic_ID", true);
            br.NullValue = false;
            //textBoxPICID.DataBindings.Add(br);

            //br = null;
            //br = new Binding("Text", bdsPIC, "Pic_Des", true);
            //br.NullValue = false;
            //textBoxPICN.DataBindings.Add(br);

            //br = null;
            //br = new Binding("Text", bdsPIC, "Pic_Path", true);
            //br.NullValue = false;
            //richtextBoxPICPATH.DataBindings.Add();
        }
        #endregion

        private void SaveDB()
        {
            bdsISI.EndEdit();
            bdsDEF.EndEdit();
            bdsPIC.EndEdit();
            bdsDOC.EndEdit();
            dgvDEF.EndEdit();
            dgvISI.EndEdit();
            dgvPIC.EndEdit();


            if (!varidate())
            {
                return;
            }

            int result = this._SqlTransactionManager.SaveTransactiontoDB(_dsData);

            if (result == 1)
            {
                MessageBox.Show("Save to database completed...", "Save data", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (_dsData.Tables[this._SqlTransactionManager.TableNameISI_Document].Rows.Count > 0)
                {
                    string DocKey = _dsData.Tables[this._SqlTransactionManager.TableNameISI_Document].Rows[0]["Doc_ID"].ToString();
                    GetData(DocKey);
                }
            }
            else
            {
                MessageBox.Show(this._SqlTransactionManager.LastError7, "Fail Save data", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }


        private bool varidate()
        {
            bdsDOC.EndEdit();


            List<string> dupicate = new List<string>();
            DateTime dtDoc;

            bool dup = false;
            string valueDup = "";


            // check dupicate 
            if (textBoxDOCID.Text != "")
            {
                dtDoc = (DateTime)dateTimePickerDOCD.Value;
                dupicate.Add(dtDoc.ToString("dd/MMM/yyyy"));
            }

            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                dr = dt.Rows[i];
                if (dr.RowState != DataRowState.Deleted)
                {
                    dtDoc = (DateTime)dr["Doc_Date"];
                    if (textBoxDOCID.Text != dr["Doc_ID"].ToString())
                    {
                        if (!dupicate.Contains(dtDoc.ToString("dd/MMM/yyyy")))
                        {
                            dupicate.Add(dtDoc.ToString("dd/MMM/yyyy"));
                        }
                        else
                        {
                            dup = true;
                            valueDup = dtDoc.ToString("dd/MMM/yyyy");
                            break;
                        }
                    }
                }
            }


            if (dup)
            {
                MessageBox.Show("Doc date Dupicate : " + valueDup, "Check data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateTimePickerDOCD.Focus();
                return false;
            }
            if (textBoxDOCID.Text == "")
            {
                MessageBox.Show("Not null Doc ID", "Check Null ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
                
            }
            //ChecknullTRN();
            setAppprovedTicket();

            if (!ChecknullTRN())
            {
                return false;
            }


            return CheckAllowNullDEFPIC();
            if (CheckAllowNullDEFPIC() == false)
            {
                
            }



        }
        private void setAppprovedTicket()
        {
            //int i = _dsData.Tables[this._SqlTransactionManager.TableNameISI_Incoming].Rows.Count;
            //i -= textBoxTicketRun.Text.CompareTo(textBoxTicketRun.Text) + 1;
            //dr2 = this._dsData.Tables[this._SqlTransactionManager.TableNameISI_Incoming].Rows[i];
            //dr = _dsData.Tables[this._SqlTransactionManager.TableNameISI_Incoming].NewRow();

            //    if (checkBoxTICFLAG.CheckState == CheckState.Unchecked)
            //    {
            //        dr2["Approved_Flag"] = 0;
            //        dr2["Inspector_Approved_Date"] = DBNull.Value;
            //    }
            //    else
            //    {
            //        dr2["Inspector_Approved_Date"] = dateTimePickerDOCAPPD.Value;

            //        dr2["Approved_Flag"] = checkBoxTICFLAG.Checked;

            //    }
            //    if (comboBox1.SelectedValue == null)
            //    {
            //        dr2["Inspector_Approved"] = comboBox1.SelectedValue;
            //    }

            //    else
            //    {
            //        dr2["Inspector_Approved"] = comboBox1.SelectedValue;
            //    }

            //    if (comboBoxTICMAT.SelectedValue != "" && comboBoxTICSTT.SelectedValue != "" && comboBoxTICSUB.SelectedValue != "" && comboBox1.SelectedValue != "")
            //    {
            //        dr2["Mat_Id"] = comboBoxTICMAT.SelectedValue.ToString();
            //        dr2["Status_ID"] = comboBoxTICSTT.SelectedValue.ToString();
            //        dr2["Sup_ID"] = comboBoxTICSUB.SelectedValue.ToString();
            //    }

            foreach (DataRow drr in this._dsData.Tables[this._SqlTransactionManager.TableNameISI_Incoming].Rows)
            {
                if (drr.RowState != DataRowState.Deleted)
                {
                    if (!this.ConverttoBool(drr["Approved_Flag"].ToString()))
                    {
                        drr["Approved_Flag"] = 0;
                        drr["Inspector_Approved_Date"] = DBNull.Value;
                    }
                }
            }



        }
        private bool ChecknullTRN()
        {
            if (comboBoxDOCQC.SelectedValue == null)
            {
                MessageBox.Show("Not null QC Inspector Name ", "Check Null ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxDOCQC.Focus();
                return false;


            }
            //if (comboBoxDOCLG.SelectedValue == null)
            //{
            //    MessageBox.Show("Not null LG Inspector Name ", "Check Null ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    comboBoxDOCLG.Focus();
            //    return false;


            //}
            if (comboBoxDOCAPP.SelectedValue == null)
            {
                MessageBox.Show("Not null Appproved Inspector Name ", "Check Null ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxDOCAPP.Focus();
                return false;


            }
            // check ทะเบียนรถ ห้ามว่าง
            if (textBoxTICVeh.Text == "")
            {
                MessageBox.Show("Not null Truck ID", "Check Null ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxTICVeh.Focus();
                return false;
            }
            // check PO ห้ามว่าง
            if (textBoxTICPO.Text == "")
            {
                MessageBox.Show("Not null PO", "Check Null ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxTICPO.Focus();
                return false;
            }
            if (comboBoxTICSUB.SelectedValue == null)
            {
                MessageBox.Show("Not null Suppiler Name ", "Check Null ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxTICSUB.Focus();
                return false;
            }
            if (comboBoxTICSTT.SelectedValue == null)
            {
                MessageBox.Show("Not null Status ", "Check Null ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxTICSTT.Focus();
                return false;
            }
            if (comboBoxTICMAT.SelectedValue == null)
            {
                MessageBox.Show("Not null Material Name ", "Check Null ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxTICMAT.Focus();
                return false;
            }

            if (this.INW.Text == "")
            {
                MessageBox.Show("Not null Weight IN ", "Check Null ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                INW.Focus();
                return false;
            }
            if (OUTW.Text == "")
            {
                MessageBox.Show("Not null Weight OUT ", "Check Null ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                OUTW.Focus();
                return false;
            }

            if (NETW.Text == "")
            {
                MessageBox.Show("Not null Weight NET ", "Check Null ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NETW.Focus();
                return false;
            }
            if (QCW.Text == "")
            {
                MessageBox.Show("Not null Deduct By QC ", "Check Null ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                QCW.Focus();
                return false;
            }
            //if (textBoxTICLG.Text == "")
            //{
            //    MessageBox.Show("Not null Deduct By LG ", "Check Null ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    textBoxTICLG.Focus();
            //    return false;
            //}

            if (checkBoxTICFLAG.Checked == true)
            {
                if (cb_Inspectror_App.SelectedValue == null)
                {
                    MessageBox.Show("Not null Inspector_Approved Name ", "Check Null ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cb_Inspectror_App.Focus();
                    return false;
                }
            }
            if (this._dsData.Tables[this._SqlTransactionManager.TableNameISI_Document].Rows.Count > 0)
            {
                dr = this._dsData.Tables[this._SqlTransactionManager.TableNameISI_Document].Rows[0];
                dr["Doc_Activated"] = 1;

            }
            if (checkBoxTICFLAG.Checked == false)
            {

                DialogResult dialog7 = MessageBox.Show("Are you sure this ticket not  Appproved ? ", " Question ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog7 == DialogResult.Yes)
                {
                }
                else
                {
                    checkBoxTICFLAG.Focus();
                    return false;

                }
            }




            return true;
        }
        private bool CheckAllowNullDEFPIC()
        {
            foreach (DataRow drr in this._dsData.Tables[this._SqlTransactionManager.TableNameISI_Incoming].Rows)
            {

                if (drr.RowState != DataRowState.Deleted)
                {
                    if (cobDefectName.SelectedValue == null && txtDefectWeight.Text == "")
                    {
                        DialogResult dialog4 = MessageBox.Show("Are you sure this Ticket don't have any Defect ? ", " Question ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (dialog4 == DialogResult.No)
                        {
                            cobDefectName.Focus();
                            return false;
                        }
                        else
                        {
                            if (richtextBoxPICPATH.Text != "" && textBoxPICN.Text != "" && this._dsData.Tables[this._SqlTransactionManager.TableNameISI_Pictrue].Rows.Count > 0)
                            {
                                return true;
                            }
                        }
                    }

                    if (richtextBoxPICPATH.Text != "" && textBoxPICN.Text != "")
                    {
                        return true;
                        break;
                    }
                    if (richtextBoxPICPATH.Text != "" && textBoxPICN.Text == "")
                    {
                        MessageBox.Show("Not Null Pictrue Name ", " Warning ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBoxPICN.Focus();
                        return false;
                        break;
                    }
                    if (richtextBoxPICPATH.Text == "" && textBoxPICN.Text == "")
                    {

                        DialogResult dialog5 = MessageBox.Show("Are you sure this Ticket don't have any Picture ? ", " Question ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialog5 == DialogResult.No)
                        {
                            textBoxPICN.Focus();
                            return false;
                            break;
                        }
                        else
                        {
                            return true;
                            break;


                        }
                    }

                }
            }

            return false;
        }

        public void SetSecurityForm(bool updatedFlag, bool deletedFlag, bool readFlag)
        {
            this._updatedFlag = updatedFlag;
            this._deleteFlag = deletedFlag;

            this.tsbSave.Enabled = this._updatedFlag;
            this.tsbOpenDOC.Enabled = this._deleteFlag;
        }


        private void setCombobox()
        {
            #region SUP

            {
                DataTable dt = this._dsCob.Tables["ISI_Supplier"];
                //this.comboBoxTICSUB.DataSource = this._dsCob.Tables["ISI_Supplier"];
                this.comboBoxTICSUB.DataSource = dt.Select(" Sup_Activated = 1").CopyToDataTable();
                this.comboBoxTICSUB.DisplayMember = "Sup_Desc";
                this.comboBoxTICSUB.ValueMember = "Sup_ID";

            }
            #endregion

            #region DEF
            {
                DataTable dt = this._dsCob.Tables["ISI_Defect"];
                this.cobDefectName.DataSource = dt.Select(" Def_Activated = 1").CopyToDataTable();
                //this.comboBoxDEFN.DataSource = this._dsCob.Tables["ISI_Defect"];
                this.cobDefectName.DisplayMember = "Def_Desc";
                this.cobDefectName.ValueMember = "Def_ID";
                //cobDefectName.SelectedIndex = 1;
                //this.comboBoxDEFRE.DataSource = dt.Select(" Def_Activated = 1").CopyToDataTable();
                //this.comboBoxDEFRE.DataSource = this._dsCob.Tables["ISI_Defect"];
                //this.comboBoxDEFRE.DisplayMember = "Def_ID";
                //this.comboBoxDEFRE.ValueMember = "Def_ID";
            }



            #endregion

            #region MAT
            {
                DataTable dt = this._dsCob.Tables["ISI_Material"];

                this.comboBoxTICMAT.DataSource = dt.Select(" Mat_Activated = 1").CopyToDataTable();
                this.comboBoxTICMAT.DisplayMember = "Mat_Desc";
                this.comboBoxTICMAT.ValueMember = "Mat_ID";




            }
            #endregion

            #region STT
            {
                DataTable dt = this._dsCob.Tables["ISI_Quality_Control_Status"];

                this.comboBoxTICSTT.DataSource = dt.Select(" Status_Activated = 1").CopyToDataTable();
                this.comboBoxTICSTT.DisplayMember = "Status_Desc";
                this.comboBoxTICSTT.ValueMember = "Status_ID";
            }
            #endregion

            #region QC

            {

                DataTable dt = this._dsCob.Tables["ISI_Quality_Check"];

                this.comboBoxDOCQC.DataSource = dt.Select(" QC_For_Create = 1").CopyToDataTable();
                this.comboBoxDOCQC.DisplayMember = "QC_First_Name";
                this.comboBoxDOCQC.ValueMember = "QC_ID";


                this.comboBoxDOCLG.DataSource = dt.Copy().Select("QC_For_Create = 1").CopyToDataTable();
                this.comboBoxDOCLG.DisplayMember = "QC_First_Name";
                this.comboBoxDOCLG.ValueMember = "QC_ID";


                this.comboBoxDOCAPP.DataSource = dt.Copy().Select("QC_For_Appproved = 1").CopyToDataTable();
                this.comboBoxDOCAPP.DisplayMember = "QC_First_Name";
                this.comboBoxDOCAPP.ValueMember = "QC_ID";

                this.cb_Inspectror_App.DataSource = dt.Copy().Select("QC_For_Appproved = 1").CopyToDataTable();
                this.cb_Inspectror_App.DisplayMember = "QC_First_Name";
                this.cb_Inspectror_App.ValueMember = "QC_ID";


            }
            #endregion

        }

        private void comboBoxTICMAT_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxTICMAT.SelectedValue != "")
                {
                    textBoxTICMATC.Text = this._SqlTransactionManager.GetMaterialCodeByKey(comboBoxTICMAT.SelectedValue.ToString());
                }

            }
            catch { }

        }

        private void BrowseBT_Click(object sender, EventArgs e)
        {
            openFilePIC.Filter = "Images|*.jpg;*.jpeg;*.png;";
            openFilePIC.FilterIndex = 2;
            richtextBoxPICPATH.Focus();
            openFilePIC.ShowDialog();
            openFilePIC.Title = "Browse Text Files";
            openFilePIC.CheckFileExists = true;
            openFilePIC.CheckPathExists = true;
            richtextBoxPICPATH.Text = openFilePIC.FileName;
            //richtextBoxPICPATH.SelectedText = openFilePIC.FileName;




        }

        //private void toolStripButton1_Click(object sender, EventArgs e)
        //{
        //    SaveDB();
        //}



        //private void addDocN()
        //{

        //    int maxDocN = 0;
        //    foreach (DataRow drg in this._dsData.Tables[this._SqlTransactionManager.TableNameISI_Document].Rows)
        //    {
        //        if (maxDocN < ConverttoInt(drg["Doc_Running"].ToString()))
        //        {
        //            maxDocN = ConverttoInt(drg["Doc_Running"].ToString());
        //        }
        //    }

        //    maxDocN += -1;
        //    textBoxTicketRun.Text = maxDocN.ToString();
        //    bdsDOC.EndEdit();

        //}
        private void addDoc(int DocInKey)
        {
            string DocNo = "";
            String DOCUMENT = "DOCUMENT";
            int maxDoc = 0;


            foreach (DataRow drg in this._dsData.Tables[this._SqlTransactionManager.TableNameISI_Document].Rows)
            {
                if (maxDoc < ConverttoInt(drg["Doc_Running"].ToString()))
                {
                    maxDoc = ConverttoInt(drg["Doc_Running"].ToString());
                }


                if (drg.RowState == DataRowState.Deleted)
                {
                    drg["Doc_ID"] = null;

                }
            }

            toolStripButton1.Enabled = true;
            DocInKey += 1;
            textBoxDocrun.Text = DocInKey.ToString();

            for (int i = 2; i > DocInKey.ToString().Length; i--)
            {
                DocNo += "0";
            }
            DocNo += DocInKey;
            DOCUMENT += DocInKey;
            textBoxDOCDesc.Text = DOCUMENT;
            textBoxDOCID.Text = DocNo;



        }
        private string addTicket(string DocID)
        {
            string TicketNo = "", DocNo = "";
            int maxTicket = 0;

            DataRow[] dtFiterbyDoc = this._dsData.Tables[this._SqlTransactionManager.TableNameISI_Incoming].Select(" Doc_ID = " + DocID);
            foreach (DataRow drg in dtFiterbyDoc)
            {
                if (maxTicket < ConverttoInt(drg["Trn_Ticket_Run"].ToString()))
                {
                    maxTicket = ConverttoInt(drg["Trn_Ticket_Run"].ToString());
                }
            }

            maxTicket += 1;
            textBoxTicketRun.Text = maxTicket.ToString();

            for (int i = 2; i > textBoxDocrun.Text.Length; i--)
            {
                DocNo += "0";
            }
            DocNo = DocNo + textBoxDocrun.Text;


            for (int i = 4; i > maxTicket.ToString().Length; i--)
            {
                TicketNo += "0";
            }
            TicketNo += maxTicket;
            textBoxTICNUM.Text = TicketNo;

            DateTime dtTime = (DateTime)dateTimePickerDOCD.Value;
            TicketNo = dtTime.ToString("yyMM") + DocNo + TicketNo;

            return TicketNo;
        }


        private bool ConverttoBool(string Value)
        {
            bool result = false;
            try
            {
                result = Convert.ToBoolean(Value);

                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private int ConverttoInt(string Value)
        {
            int result = 0;
            try
            {
                result = Convert.ToInt32(Value);

                return result;
            }
            catch (Exception)
            {
                return 0;
            }
        }



        private void tsbSave_Click(object sender, EventArgs e)
        {
            if (textBoxTICNUM.Text != "")
            {
                SaveDB();
            }

            if (checkBoxTICFLAG.CheckState == 0)
            {
                dateTimePickerDOCAPPD.Format = DateTimePickerFormat.Custom;
                dateTimePickerDOCAPPD.CustomFormat = " ";

            }
        }



        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //addPicture();
            //Refresh();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //Refresh();
        }

        //private void bindingNavigatorAddNewItem1_Click(object sender, EventArgs e)
        //{
        //    if (textBoxTICNUM.Text !="" && textBoxDOCID.Text != "")
        //    {
        //        dr = this._dsData.Tables[this._SqlTransactionManager.TableNameISI_DefectDetail].NewRow();
        //        dr["Trn_Ticket"] = textBoxTICNUM.Text;
        //        dr["Doc_ID"] = textBoxDOCID.Text;
        //        this._dsData.Tables[this._SqlTransactionManager.TableNameISI_DefectDetail].Rows.Add(dr);
        //    }
        //}




        #region get data

        private void tsbOpenDOC_Click(object sender, EventArgs e)
        {



            DocumentListForm form_ = new DocumentListForm(this._connStr);
            if (form_.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (tsbAdd.Enabled == false)
                {
                    tsbAdd.Enabled = true;
                    panel12.Enabled = true;

                }
                if (form_.DocumenKey.Length > 0)
                {
                    tsbAddDoc.Enabled = false;
                    SetNewDoc(form_.DocumenKey);

                    if (textBoxTICNUM.Text == "")
                    {
                        tsbAddPic.Enabled = false;
                        BrowseBT.Enabled = false;
                        textBoxTICVeh.Enabled = false;
                        textBoxTICPO.Enabled = false;
                        dateTimePickerTICTD.Enabled = false;
                        comboBoxTICSUB.Enabled = false;
                        comboBoxTICSTT.Enabled = false;
                        comboBoxTICMAT.Enabled = false;
                        textBoxTICWIN.Enabled = false;
                        dateTimePickerTICWINT.Enabled = false;
                        textBoxTICWO.Enabled = false;
                        dateTimePickerTICWOT.Enabled = false;
                        textBoxTICWN.Enabled = false;
                        dateTimePickerTICWNT.Enabled = false;
                        textBoxTICQC.Enabled = false;
                        textBoxTICLG.Enabled = false;
                        checkBoxTICFLAG.Enabled = false;
                        txtDefectWeight.Enabled = false;
                        cobDefectName.Enabled = false;
                        textBoxPICN.Enabled = false;
                        tsbAddnewDef.Enabled = false;
                    }


                    if (textBoxTICNUM.Text != "")
                    {
                       
                        panel12.Enabled = true;
                        

                    }
                     if (QCW.Value != 0)
                    {
                        tsbAddnewDef.Enabled = true;
                        panel12.Enabled = true;

                    }

                    if (textBoxTicketRun.Text != "")
                    {

                        BrowseBT.Enabled = true;
                       
                    }

                }
                else
                {
                }
            }
        }


        private void GetData(string DocKey)
        {
            try
            {
                this.resetDataBase();

                this._dsData.Merge(this._SqlTransactionManager.GetISI_IncomingList(DocKey));

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }


        private void resetDataBase()
        {

            //_dsData.Tables[this._SqlTransactionManager.TableNameISI_Pictrue].Rows.Clear();
            //_dsData.Tables[this._SqlTransactionManager.TableNameISI_DefectDetail].Rows.Clear();
            //_dsData.Tables[this._SqlTransactionManager.TableNameISI_Incoming].Rows.Clear();
            //_dsData.Tables[this._SqlTransactionManager.TableNameISI_Document].Rows.Clear();
            //textBoxDoc_IDText.Text = "";
            foreach (DataTable dt in _dsData.Tables)
            {
                dt.Rows.Clear();
            }

            this.dt.Rows.Clear();
            this.dt.Merge(this._SqlTransactionManager.GetISI_DocumentList());

        }

        #endregion

        #region New Doc

        private void dateTimePickerDOCD_ValueChanged(object sender, EventArgs e)
        {
            if (textBoxTICNUM.Text != "")
            {
                dateTimePickerTICTD.Value = dateTimePickerDOCD.Value.ToUniversalTime();
                dateTimePickerTICWINT.Value = dateTimePickerDOCD.Value.ToUniversalTime();
                dateTimePickerTICWOT.Value = dateTimePickerDOCD.Value.ToUniversalTime();
                dateTimePickerTICWNT.Value = dateTimePickerDOCD.Value.ToUniversalTime();
                dateTimePickerDOCAPPD.Value = dateTimePickerDOCD.Value.ToUniversalTime();
            }


        }

        private void SetNewDoc(string DateTimeValue)
        {
            string setDate = "";
            if (DateTimeValue.Length > 0)
            {
                setDate = DateTimeValue;
            }
            else
            {
                DateTime datetimeDocDate = (DateTime)dateTimePickerDOCD.Value;
                setDate = datetimeDocDate.ToString("yyyyMMdd");
            }

            int DocInKey = 0;
            string DocKey = this._SqlTransactionManager.GetCheckDupDocument(setDate);
            if (DocKey.Length > 0)
            {
                GetData(DocKey);
            }
            else
            {
                DocInKey = this._SqlTransactionManager.GetMaxDoc();
                addDoc(DocInKey);
            }

        }

        #endregion

        private void bdnDOC_RefreshItems(object sender, EventArgs e)
        {
            this.resetDataBase();
        }

        private void tsbAddDoc_Click(object sender, EventArgs e)
        {
            dateTimePickerDOCD.Value = DateTime.Now;
            tsbAdd.Enabled = true;
           
            panel12.Enabled = true;

            SetNewDoc("");


            DialogResult dialog = MessageBox.Show("Add Document can do Onec a Day", "แจ้งตือน", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);


            dr2 = _dsData.Tables[this._SqlTransactionManager.TableNameISI_Incoming].NewRow();
            dr = _dsData.Tables[this._SqlTransactionManager.TableNameISI_Document].NewRow();
            if (dialog == DialogResult.OK)
            {
                tsbAddDoc.Enabled = false;
                if (textBoxTICNUM.Text == "")
                {
                    tsbAddPic.Enabled = false;
                    BrowseBT.Enabled = false;
                    textBoxTICVeh.Enabled = false;
                    textBoxTICPO.Enabled = false;
                    dateTimePickerTICTD.Enabled = false;
                    comboBoxTICSUB.Enabled = false;
                    comboBoxTICSTT.Enabled = false;
                    comboBoxTICMAT.Enabled = false;
                    textBoxTICWIN.Enabled = false;
                    dateTimePickerTICWINT.Enabled = false;
                    textBoxTICWO.Enabled = false;
                    dateTimePickerTICWOT.Enabled = false;
                    textBoxTICWN.Enabled = false;
                    dateTimePickerTICWNT.Enabled = false;
                    textBoxTICQC.Enabled = false;
                    textBoxTICLG.Enabled = false;
                    checkBoxTICFLAG.Enabled = false;
                    txtDefectWeight.Enabled = false;
                    cobDefectName.Enabled = false;
                    textBoxPICN.Enabled = false;
                }

            }
            else
            {
                this.dr.Table.Rows.Clear();

                this.dr2.Table.Rows.Clear();
                this.dr2.Table.AcceptChanges();
                tsbAdd.Enabled = false;

                if (tsbAddDoc.Enabled == false)
                {
                    DialogResult dialog2 = MessageBox.Show("The Document has been Added!", "แจ้งตือน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (dialog2 == DialogResult.OK)
                    {
                        //if (textBoxTICNUM.Text != null)
                        //{
                        //    tsbAddnewDef.Enabled = true;
                        //}


                        if (textBoxTicketRun.Text != null)
                        {

                            BrowseBT.Enabled = true;

                        }
                    }
                }
            }
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {

            tsbAddDoc.Enabled = true;
            this.resetDataBase();
            tsbAddPic.Enabled = false;
            tsbAdd.Enabled = false;
            tsbAddnewDef.Enabled = false;
            if (textBoxDocrun.Text == "")
            {
                panel12.Enabled = false;

            }
            if (tsbAddDoc.Enabled == true)
            {
                toolStripButton1.Enabled = true;
            }

        }



        private void bindingNavigatorDeleteItem2_Click(object sender, EventArgs e)
        {
            tsbAddDoc.Enabled = true;
        }


        #region Add ticket

        private void AddTicket()
        {


            if (textBoxDOCID.Text != "" || textBoxTICNUM.Text != "")
            {

                dr = _dsData.Tables[this._SqlTransactionManager.TableNameISI_Incoming].NewRow();
                dr["Doc_ID"] = textBoxDOCID.Text;
                dr["Trn_Ticket"] = addTicket(textBoxDOCID.Text);
                dr["Trn_Ticket_Run"] = textBoxTicketRun.Text;
                _dsData.Tables[this._SqlTransactionManager.TableNameISI_Incoming].Rows.Add(dr);
                dr = _dsData.Tables[this._SqlTransactionManager.TableNameISI_Incoming].NewRow();
                dr["Trn_Weight_IN_Time"] = dateTimePickerTICWINT.Value.ToString();
                dr["Trn_Weight_OUT_Time"] = dateTimePickerTICWOT.Value.ToString();
                dr["Trn_Weight_Net_Time"] = dateTimePickerTICWNT.Value.ToString();
                dr["Trn_Date"] = dateTimePickerTICTD.Value.ToString();
                dr["Inspector_Approved_Date"] = dateTimePickerDOCAPPD.Value;
                int er = dgvISI.Rows.GetLastRow(DataGridViewElementStates.Displayed);
                er += 0;
                if (this.dgvISI.CurrentRow.Index < dgvISI.Rows.Count)
                {
                    dgvISI.FirstDisplayedScrollingRowIndex = er;
                    dgvISI.Refresh();
                    dgvISI.CurrentCell = dgvISI.Rows[er].Cells[0];
                    dgvISI.Rows[er].Selected = true;
                    er += 1;
                    dateTimePickerTICWINT.Value = dateTimePickerDOCD.Value.ToUniversalTime();
                    dateTimePickerTICWOT.Value = dateTimePickerDOCD.Value.ToUniversalTime();
                    dateTimePickerTICWNT.Value = dateTimePickerDOCD.Value.ToUniversalTime();
     

                }


            }
        }


        private void tsbAddnewDef_Click(object sender, EventArgs e)
        {
           
            bool CheckSUM = false;
            bool CheckDup = false;    
          
            foreach (DataGridViewRow drg in this.dgvDEF.Rows)
            {

                sum += Convert.ToDecimal(drg.Cells["In_Def_Weigth_Kg"].Value);

                if (sum > A)
                {
                    DW.Value = 0;
                    DW.Focus();
                    MessageBox.Show("Defect Weight must Equal or less than QC Inspection !!!", "Incorrect", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CheckSUM = true;
                    break;

                }
                if (drg.Cells["Def_Remark"].Value.ToString() == textBoxDefRE.Text.ToString())
                {
                    CheckDup = true;
                    cobDefectName.Focus();
                    tsbAddPic.Enabled = true;
                    PanalPIC.Enabled = true;
                    break;

                }
                
            }
           
            if (CheckDup != false)
            {
                MessageBox.Show("Defect Name Is Duppucate !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cobDefectName.Focus();

            }
            if (CheckSUM == false && CheckDup == false)
            {
                this.AddDefect();
            }
            
        }

        private void AddDefect()
        {


            if (textBoxTICNUM.Text != "" && cobDefectName.SelectedValue != null)
            {
                dr = _dsData.Tables[this._SqlTransactionManager.TableNameISI_DefectDetail].NewRow();
                dr["Doc_ID"] = textBoxDOCID.Text;
                dr["In_Def_Weigth_Kg"] =DW.Value;
                dr["Trn_Ticket"] = textBoxTICNUM.Text;
                dr["Def_ID"] = cobDefectName.SelectedValue;
                dr["Def_Desc"] = cobDefectName.Text;
                dr["Def_Remark"] = textBoxDefRE.Text;
                _dsData.Tables[this._SqlTransactionManager.TableNameISI_DefectDetail].Rows.Add(dr);
                //ModeDEF.Enabled = true;
                int er = this.dgvDEF.Rows.GetLastRow(DataGridViewElementStates.Displayed);
                er += 0;
               
                if (this.dgvDEF.CurrentRow.Index < dgvDEF.Rows.Count)
                {
                    this.dgvDEF.FirstDisplayedScrollingRowIndex = er;
                    dgvDEF.Refresh();
                    dgvDEF.CurrentCell = dgvDEF.Rows[er].Cells[0];
                    dgvDEF.Rows[er].Selected = true;
                   
                    er += 1;

                }

            }
        }

        private void tsbAddPic_Click(object sender, EventArgs e)
        {
            button1WasClicked = false;

            if (button1WasClicked == false) 
            {
               
                textBoxPICN.DataBindings.Clear();
                  editPIC.Enabled = true;
                
            }

            bool CheckDup = false;


            if (richtextBoxPICPATH.Text != "" && textBoxPICN.Text != "")
            {

                foreach (DataGridViewRow drg in this.dgvPIC.Rows)
                {
                    if ( drg.Cells["Pic_Path"].Value.ToString() == richtextBoxPICPATH.Text && textBoxPICN.Text != "" )
                    {
                        CheckDup = true;
                        
                    }
                   
                    if (drg.Cells["Pic_Des"].Value.ToString() == this.textBoxPICN.Text)
                    {
                        CheckDup = true;
                        break;
                    }
                   
                   
                }

                if (CheckDup == false)
                {
                    if (textBoxPICN.Text != "")
                    {
                        this.AddPictures();
                        

                    }
                    
                }

               


            }
            if (richtextBoxPICPATH.Text == "")
            {
                MessageBox.Show("Plese Go To Browse Pictrures Path Before Add new", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                BrowseBT.Focus();

            }

            if (textBoxPICN.Text == "")
            {
                MessageBox.Show("Plese Go To Add Pictrue Name Before Add new", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxPICN.Focus();
            }
           
        }

        private void AddPictures()
        {
            //string PictrueNo = "";
            //int maxPictrue = 0;
            //foreach (DataRow drg in this._dsData.Tables[this._SqlTransactionManager.TableNameISI_Pictrue].Rows)
            //{
            //    if (maxPictrue < ConverttoInt(drg["Pic_Run"].ToString()))
            //    {
            //        maxPictrue = ConverttoInt(drg["Pic_Run"].ToString());
            //    }
            //}

            //maxPictrue += 1;
            ////textBoxPictureRun.Text = maxPictrue.ToString();

            //for (int i = 4; i > maxPictrue.ToString().Length; i--)
            //{
            //    PictrueNo += "0";
            //}
            //PictrueNo += maxPictrue;
            //textBoxPICID.Text = PictrueNo;
            if (textBoxTICNUM.Text != "")
            {
                bool CheckDup = false;
                dr = _dsData.Tables[this._SqlTransactionManager.TableNameISI_Pictrue].NewRow();
                int i = 1;
                dr["Doc_ID"] = textBoxDOCID.Text;
                dr["Pic_Path"] = richtextBoxPICPATH.Text;
                dr["Pic_Des"] = textBoxPICN.Text;
                dr["Trn_Ticket"] = textBoxTICNUM.Text;
               
                _dsData.Tables[this._SqlTransactionManager.TableNameISI_Pictrue].Rows.Add(dr);



                if (CheckDup = true && dr["Pic_Path"].ToString() == richtextBoxPICPATH.Text && _dsData.Tables[this._SqlTransactionManager.TableNameISI_Pictrue].Rows.Count == _dsData.Tables[this._SqlTransactionManager.TableNameISI_Pictrue].Rows.Count.CompareTo(i))
                {

                    MessageBox.Show("Pictrues Path Is Duppucate !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    BrowseBT.Focus();

                }
               

                if (textBoxPICN.Text != "" && dr["Pic_Des"].ToString() == this.textBoxPICN.Text)
                {
                    MessageBox.Show("Pictrues Name Is Duppucate !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxPICN.Focus();
                }
                else
                {
                    i += 1;
                }
                int er = this.dgvPIC.Rows.GetLastRow(DataGridViewElementStates.Displayed);
                er += 0;
                if (this.dgvPIC.CurrentRow.Index < dgvPIC.Rows.Count)
                {
                    dgvPIC.FirstDisplayedScrollingRowIndex = er;
                    dgvPIC.Refresh();
                    dgvPIC.CurrentCell = dgvPIC.Rows[er].Cells[0];
                    dgvPIC.Rows[er].Selected = true;
                    er += 1;

                }
            }

        }

        #endregion

        //private void tsbSave_Click_1(object sender, EventArgs e)
        //{

        //}

        private void cobDefectName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                //dr = _dsData.Tables[this._SqlTransactionManager.TableNameISI_DefectDetail].NewRow();

                //bool CheckDup = false;


                if (cobDefectName.SelectedValue.ToString() != "")
                {
                    textBoxDefRE.Text = this._SqlTransactionManager.GetDefectRemarkByKey(cobDefectName.SelectedValue.ToString());
                    textBoxDefRE.Focus();


                    //foreach (DataGridViewRow drg in this.dgvDEF.Rows)
                    //{

                    //    if (drg.Cells["Def_Remark"].Value.ToString() == textBoxDefRE.Text.ToString())
                    //    {

                    //        CheckDup = true;
                    //        cobDefectName.Focus();

                    //    }
                    //    if (drg.Cells["Def_Desc"].Value.ToString() == cobDefectName.Text.ToString())
                    //    {

                    //        CheckDup = true;
                    //        break;
                    //    }

                    //}


                    //if (CheckDup == true)
                    //{
                    //    cobDefectName.SelectedValue = cobDefectName.SelectedValue;
                    //    cobDefectName.Focus();
                    //    MessageBox.Show("Defect Name is Duppicate ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    //}
                    //if (CheckDup == true && _dsData.Tables[this._SqlTransactionManager.TableNameISI_DefectDetail].Rows.Count > 0)
                    //{
                    //    cobDefectName.SelectedIndex = 1;
                    //    foreach (ComboBox cbi in cobDefectName.Items)
                    //    {
                    //        if (cbi.SelectedValue as String != "")
                    //        {
                    //            cobDefectName.SelectedItem = cbi;
                    //            break;
                    //        }
                    //    }
                    //}



                }

            }




            catch { }
        }



        private void tsbAdd_Click(object sender, EventArgs e)
        {
            panel12.Focus();
            PanalDef.Enabled = true;
            this.ModeChange.Enabled = true;
            
            AddTicket();

            
            panel12.Enabled = true;

            INW.Enabled = true;
            OUTW.Enabled = true;
            NETW.Enabled = true;
            QCW.Enabled = true;

            INW.Value = 0;
            OUTW.Value = 0;
            NETW.Value = 0;
            QCW.Value = 0;

           

            dateTimePickerTICWINT.Value = dateTimePickerDOCD.Value.ToUniversalTime();
            dateTimePickerTICWOT.Value = dateTimePickerDOCD.Value.ToUniversalTime();
            dateTimePickerTICWNT.Value = dateTimePickerDOCD.Value.ToUniversalTime();


            if (textBoxTICNUM.Text != null)
            {
               
                cb_Inspectror_App.Focus();

            }

            if (textBoxTICNUM.Text != "")
            {

                if (checkBoxTICFLAG.CheckState == 0)
                {
                    dateTimePickerDOCAPPD.Format = DateTimePickerFormat.Custom;
                    dateTimePickerDOCAPPD.CustomFormat = " ";
                    dateTimePickerDOCAPPD.Enabled = false;

                }

            }


        }

        private void textBoxTICPO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != null))
            {
                e.Handled = true;
            }




        }

        private void textBoxTICVeh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('-') < -1))
            {
                e.Handled = true;
                
            }


            //// If you want, you can allow decimal (float) numbers
            //if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            //{
            //    e.Handled = true;
            //}
        }

        private void textBoxTICWIN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if (e.KeyChar == '0')
            {
                if (textBoxTICWIN.Text != "")
                {

                }
                else
                {

                    MessageBox.Show("This Ticket cann't take '0'KG.  ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Handled = true;

                }
                if (e.Handled == true)
                {
                    textBoxTICWIN.Clear();
                }
            }
        }

        private void textBoxTICWO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if (e.KeyChar == '0')
            {
                if (textBoxTICWO.Text != "")
                {

                }
                else
                {

                    MessageBox.Show("This Ticket cann't take '0'KG.  ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Handled = true;

                }
                if (e.Handled == true)
                {
                    textBoxTICWO.Clear();
                }
            }
        }

        private void textBoxTICWN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                if (textBoxTICWN.Text == "")
                {

                }
                else
                {
                    MessageBox.Show("This Ticket cann't take Minus KG.  ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Handled = true;

                }
                if (e.Handled == true)
                {
                    textBoxTICWN.Clear();
                }
            }
        }

        private void textBoxTICQC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                if (textBoxTICQC.Text == "")
                {

                }
                else
                {

                    MessageBox.Show("This Ticket cann't take Minus KG.  ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Handled = true;

                }
                if (e.Handled == true)
                {
                    textBoxTICQC.Clear();
                }
            }

        }

        private void textBoxTICLG_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                if (textBoxTICLG.Text != "")
                {

                    MessageBox.Show("This Ticket cann't take Minus KG.  ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Handled = true;
                }
                else
                {


                }
                if (e.Handled == true)
                {
                    textBoxTICLG.Clear();
                }
            }
        }



        private void txtDefectWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if (e.KeyChar == '-')
            {
                if (txtDefectWeight.Text != "")
                {

                }
                else
                {

                    MessageBox.Show("This Ticket cann't take be in the red  ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Handled = true;

                }
                if (e.Handled == true)
                {
                    textBoxTICWIN.Clear();
                }
            }
        }

        private void textBoxTICNUM_TextChanged(object sender, EventArgs e)
        {
            BrowseBT.Enabled = true;
            textBoxTICVeh.Enabled = true;
            textBoxTICPO.Enabled = true;
            dateTimePickerTICTD.Enabled = true;
            comboBoxTICSUB.Enabled = true;
            comboBoxTICSTT.Enabled = true;
            comboBoxTICMAT.Enabled = true;
            textBoxTICWIN.Enabled = true;
            dateTimePickerTICWINT.Enabled = true;
            textBoxTICWO.Enabled = true;
            dateTimePickerTICWOT.Enabled = true;
            textBoxTICWN.Enabled = true;
            dateTimePickerTICWNT.Enabled = true;
            textBoxTICQC.Enabled = true;
            textBoxTICLG.Enabled = true;
            checkBoxTICFLAG.Enabled = true;
            comboBoxDOCQC.Enabled = true;
            comboBoxDOCLG.Enabled = true;
            comboBoxDOCAPP.Enabled = true;
            txtDefectWeight.Enabled = true;
            cobDefectName.Enabled = true;
            textBoxPICN.Enabled = true;
            INW.Enabled = true;
            OUTW.Enabled = true;
            NETW.Enabled = true;
            QCW.Enabled = true;
            checkBoxTICFLAG.Checked = true;
            PanalDef.Enabled = true;
            ModeChange.Enabled = true;
            
            
           
            

            if (checkBoxTICFLAG.CheckState != 0)
            {

                dateTimePickerDOCAPPD.Format = DateTimePickerFormat.Custom;
                dateTimePickerDOCAPPD.CustomFormat = "dd/MMM/yyyy";
                dateTimePickerDOCAPPD.Enabled = true;


            }

            else
            {
                dateTimePickerDOCAPPD.Enabled = false;
            }













        }

        //private void toolStripButton4_Click(object sender, EventArgs e)
        //{
        //    DefectListForm form_ = new DefectListForm(this._connStr);
        //    if (form_.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //    {
        //        if (form_.DocumenKey.Length > 0)
        //        {
        //            SetNewDoc(form_.DocumenKey);
        //        }
        //    }



        //    //private void dateTimePickerDOCD_Validated(object sender, EventArgs e)
        //    //{
        //    //    dateTimePickerDOCAPPD.Value = DateTime.Now;
        //    //}










        //    //private void toolStripButton5_Click(object sender, EventArgs e)
        //    //{
        //    //    SetNewDoc("");

        //    //}



        //}

        private void textBoxDOCID_TextChanged(object sender, EventArgs e)
        {

            textBoxDOCDesc.Enabled = true;


        }

        private void dateTimePickerTICTD_CloseUp(object sender, EventArgs e)
        {
            if (dateTimePickerTICTD.Value.Date == dateTimePickerDOCD.Value.Date)
            {

                return;
            }
            if (dateTimePickerTICTD.Value.Date != dateTimePickerDOCD.Value.Date)
            {
                DialogResult dialog4 = MessageBox.Show("Are you sure for Changing to this Date  ? ", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


                if (dialog4 == DialogResult.No)
                {
                    dateTimePickerTICTD.ResetText();

                }
            }
            else
            {
                return;
            }

        }

        private void dateTimePickerTICTD_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("Plase use Dropdown for select date only !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void dateTimePickerTICWINT_CloseUp(object sender, EventArgs e)
        {
            if (dateTimePickerTICWINT.Value.ToString() == dateTimePickerDOCD.Value.ToString())
            {
                return;

            }


            if (dateTimePickerTICWINT.Value.Date != dateTimePickerDOCD.Value.Date)
            {
                DialogResult dialog4 = MessageBox.Show("Are you sure for Changing to this Date  ? ", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialog4 == DialogResult.No)
                {
                    dateTimePickerTICWINT.ResetText();

                }
                else
                {
                    return;

                }
            }
            if (dateTimePickerTICWINT.Value == dateTimePickerTICWINT.Value)
            {
                return;

            }

        }


        private void dateTimePickerTICWINT_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("Plase use Dropdown for select date only !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void dateTimePickerTICWOT_CloseUp(object sender, EventArgs e)
        {
            if (dateTimePickerTICWOT.Value.ToString() == dateTimePickerDOCD.Value.ToString())
            {

                return;
            }
            if (dateTimePickerTICWOT.Value.Date != dateTimePickerDOCD.Value.Date)
            {
                DialogResult dialog4 = MessageBox.Show("Are you sure for Changing to this Date  ? ", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialog4 == DialogResult.No)
                {
                    dateTimePickerTICWOT.ResetText();

                }
            }
            else
            {
                return;
            }
        }

        private void dateTimePickerTICWOT_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("Plase use Dropdown for select date only !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void dateTimePickerTICWNT_CloseUp(object sender, EventArgs e)
        {
            if (dateTimePickerTICWNT.Value.ToString() == dateTimePickerDOCD.Value.ToString())
            {

                return;
            }
            if (dateTimePickerTICWNT.Value.Date != dateTimePickerDOCD.Value.Date)
            {
                DialogResult dialog4 = MessageBox.Show("Are you sure for Changing to this Date  ? ", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialog4 == DialogResult.No)
                {
                    dateTimePickerTICWNT.ResetText();

                }
            }
            else
            {
                return;
            }
        }

        private void dateTimePickerTICWNT_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("Plase use Dropdown for select date only !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void checkBoxTICFLAG_CheckStateChanged(object sender, EventArgs e)
        {
            cb_Inspectror_App.Enabled = true;
            dateTimePickerDOCAPPD.Enabled = true;
            if (checkBoxTICFLAG.CheckState == 0)
            {
                dateTimePickerDOCAPPD.Format = DateTimePickerFormat.Custom;
                dateTimePickerDOCAPPD.CustomFormat = " ";
                dateTimePickerDOCAPPD.Enabled = false;

            }
        }

        private void checkBoxTICFLAG_Click(object sender, EventArgs e)
        {
            cb_Inspectror_App.Focus();



        }

        private void comboBox1_Enter(object sender, EventArgs e)
        {
            if (checkBoxTICFLAG.CheckState == 0)
            {
                cb_Inspectror_App.Enabled = false;
                dateTimePickerDOCAPPD.Enabled = false;
                cb_Inspectror_App.SelectedValue = "";


            }
            else
            {
                cb_Inspectror_App.Enabled = true;
                dateTimePickerDOCAPPD.Format = DateTimePickerFormat.Custom;
                dateTimePickerDOCAPPD.CustomFormat = "dd/MMM/yyyy";

            }


        }



        private void dateTimePickerDOCAPPD_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("Plase use Dropdown for select date only !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void dateTimePickerDOCD_CloseUp(object sender, EventArgs e)
        {

            if (dateTimePickerDOCAPPD.Value.Date == dateTimePickerDOCD.Value.Date && checkBoxTICFLAG.CheckState == 0)
            {

                return;
            }


            if (dateTimePickerDOCAPPD.Value != dateTimePickerDOCD.Value && checkBoxTICFLAG.CheckState == 0)
            {
                DialogResult dialog4 = MessageBox.Show("Are you sure for Changing to this Date  ? ", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                DateTime d = new DateTime();
                d = dateTimePickerDOCD.Value;
                if (dialog4 == DialogResult.Yes)
                {
                    dateTimePickerDOCD.Value = d;
                }
                else
                {
                    dateTimePickerDOCD.ResetText();
                }
            }
            else
            {
                return;
            }

        }

        private void comboBoxDOCQC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDOCLG.SelectedValue != null)
            {
                if (comboBoxDOCQC.SelectedValue == comboBoxDOCLG.SelectedValue)
                {

                    comboBoxDOCQC.SelectedValue = "";


                    MessageBox.Show(" You cann't select same Inspector! ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                }
            }
        }

        private void comboBoxDOCLG_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (comboBoxDOCLG.SelectedValue != null)
            //{
            //    if (comboBoxDOCLG.SelectedValue == comboBoxDOCQC.SelectedValue)
            //    {


            //        comboBoxDOCLG.SelectedValue = "";

            //        MessageBox.Show(" You cann't select same Inspector! ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);




            //    }
            //}
        }

        private bool comboBoxDOCAPP_DropDownClosed(object sender, EventArgs e)
        {
            if (checkBoxTICFLAG.Enabled == true)
            {

                if (checkBoxTICFLAG.Checked == true)
                {
                    if (comboBoxDOCAPP.SelectedValue == cb_Inspectror_App.SelectedValue && cb_Inspectror_App.SelectedValue != null)
                    {

                        DialogResult dialog4 = MessageBox.Show("Are you sure for select same Appproved Inspector Name   ? ", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialog4 == DialogResult.No)
                        {
                            comboBoxDOCAPP.SelectedValue = "";

                            MessageBox.Show(" You cann't select same Appproved Inspector! ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }
                }

            }
            return true;
        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            if (checkBoxTICFLAG.Enabled == true)
            {
                for (int i = 0; i <= 0; i++)
                {
                    if (checkBoxTICFLAG.Checked == true)
                    {
                        if (cb_Inspectror_App.SelectedValue == comboBoxDOCAPP.SelectedValue && comboBoxDOCAPP.SelectedValue != null)
                        {

                            DialogResult dialog4 = MessageBox.Show("Are you sure for select same Appproved Inspector Name   ? ", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (dialog4 == DialogResult.No)
                            {
                                if (i == 0)
                                {

                                    cb_Inspectror_App.SelectedValue = "";
                                    MessageBox.Show(" You cann't select same Appproved Inspector! ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    i += 1;
                                }


                            }
                            else
                            {

                                i += 1;

                            }


                        }
                    }


                }

            }

        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            if (checkBoxTICFLAG.Checked == false)
            {
                MessageBox.Show("Select Flag before Add Name!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                checkBoxTICFLAG.Focus();
            }
        }

        private void panel8_DoubleClick(object sender, EventArgs e)
        {
            textBoxDocrun.Visible = true;
        }

        private void panel8_MouseLeave(object sender, EventArgs e)
        {
            textBoxDocrun.Visible = false;
        }

        private void panel12_DoubleClick(object sender, EventArgs e)
        {
            textBoxTicketRun.Visible = true;
        }

        private void panel12_MouseLeave(object sender, EventArgs e)
        {
            textBoxTicketRun.Visible = false;
        }

        private void dateTimePickerDOCAPPD_CloseUp(object sender, EventArgs e)
        {

            if (dateTimePickerDOCAPPD.Value.Date != dateTimePickerDOCD.Value.Date)
            {


                DialogResult dialog4 = MessageBox.Show("Are you sure for Changing to this Date  ? ", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


                if (dialog4 == DialogResult.No || dateTimePickerDOCAPPD.Value == dateTimePickerDOCD.Value)
                {

                    dateTimePickerDOCAPPD.ResetText();
                }

                else
                {
                    dateTimePickerDOCAPPD.Update();
                }
            }

        }

        private void dateTimePickerDOCAPPD_ValueChanged(object sender, EventArgs e)
        {
            dateTimePickerDOCAPPD.Format = DateTimePickerFormat.Custom;
            this.dateTimePickerDOCAPPD.CustomFormat = "dd/MMM/yyyy";
        }

        private void dateTimePickerDOCAPPD_EnabledChanged(object sender, EventArgs e)
        {
            if (checkBoxTICFLAG.CheckState == 0)
            {

                dateTimePickerDOCAPPD.Format = DateTimePickerFormat.Custom;
                dateTimePickerDOCAPPD.CustomFormat = " ";

            }
            else
            {
                dateTimePickerDOCAPPD.Format = DateTimePickerFormat.Custom;
                this.dateTimePickerDOCAPPD.CustomFormat = "dd/MMM/yyyy";
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (textBoxTICNUM.Text == "")
            {
                textBoxTICVeh.Enabled = false;
                textBoxTICPO.Enabled = false;
                dateTimePickerTICTD.Enabled = false;
                comboBoxTICSUB.Enabled = false;
                comboBoxTICSTT.Enabled = false;
                comboBoxTICMAT.Enabled = false;
                textBoxTICMATC.Enabled = false;
                textBoxTICWIN.Enabled = false;
                dateTimePickerTICWINT.Enabled = false;
                textBoxTICWO.Enabled = false;
                dateTimePickerTICWOT.Enabled = false;
                textBoxTICWN.Enabled = false;
                dateTimePickerTICWNT.Enabled = false;
                textBoxTICQC.Enabled = false;
                textBoxTICLG.Enabled = false;
                checkBoxTICFLAG.Enabled = false;
                cb_Inspectror_App.Enabled = false;
                dateTimePickerDOCAPPD.Enabled = false;
                PanalDef.Enabled = false;
                PanalPIC.Enabled = false;
                INW.Enabled = false;
                OUTW.Enabled = false;
                NETW.Enabled = false;
                QCW.Enabled = false;
            }
        }

        private void textBoxDefRE_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyData == Keys.Enter)
            //{
            //    MessageBox.Show("Enter key pressed");
            //    dgvDEF.SelectAll();

            //}
        }

        private void textBoxDefRE_TextChanged(object sender, EventArgs e)
        {
            this.Text = textBoxDefRE.Text;
           

        }

        //private void cobDefectName_MouseLeave(object sender, EventArgs e)
        //{
        //    textBoxDefRE.Enabled = false;
        //}

        //private void cobDefectName_MouseEnter(object sender, EventArgs e)
        //{
        //    textBoxDefRE.Enabled = false;
        //}



        private void tsbAdd_EnabledChanged(object sender, EventArgs e)
        {
            if (tsbAdd.Enabled == false)
            {
                panel12.Enabled = false;
                PanalDef.Enabled = false;
                PanalPIC.Enabled = false;
            }


        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void txtDefectWeight_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData == Keys.Enter)
            {
                bool CheckDup = false;

                if (txtDefectWeight.Text == "")
                {
                    MessageBox.Show("Plese Go To Add Defect Weight Before Add new", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDefectWeight.Focus();

                }
                




                if (txtDefectWeight.Text != "" && this._dsData.Tables[this._SqlTransactionManager.TableNameISI_DefectDetail].Rows.Count >= 0 && textBoxTICNUM.Text.ToString() != "" && textBoxDefRE.Text.ToString() != "")
                {
                    foreach (DataGridViewRow drg in this.dgvDEF.Rows)
                    {

                        if (drg.Cells["Def_Remark"].Value.ToString() == textBoxDefRE.Text.ToString())
                        {

                            CheckDup = true;
                            cobDefectName.Focus();

                        }


                    }
                    if (CheckDup == false)
                    {

                        this.AddDefect();
                       

                    }
                    else
                    {

                        MessageBox.Show("Defect Name Is Duppucate !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cobDefectName.Focus();
                        txtDefectWeight.Clear();
                    }
                }
              


            }


        }

        private void textBoxTICPO_MouseHover(object sender, EventArgs e)
        {

            toolTipALL.ShowAlways = true;
            toolTipALL.SetToolTip(textBoxTICPO, "Plese Fill in Purchase Order Here.");
        }

        private void textBoxTICVeh_MouseHover(object sender, EventArgs e)
        {
            toolTipALL.ShowAlways = true;
            toolTipALL.SetToolTip(textBoxTICVeh, "Plese Fill in Vehicle Numble Here.");
        }

        private void dateTimePickerTICTD_MouseHover(object sender, EventArgs e)
        {
            toolTipALL.ShowAlways = true;
            toolTipALL.SetToolTip(dateTimePickerTICTD, "Plese Select Transaction Date in Drowdown Here.");
        }

        private void comboBoxTICSUB_MouseHover(object sender, EventArgs e)
        {
            toolTipALL.ShowAlways = true;
            toolTipALL.SetToolTip(comboBoxTICSUB, "Plese Select Supplier Name  in Dropdown Here.");
        }

        private void comboBoxTICSTT_MouseHover(object sender, EventArgs e)
        {
            toolTipALL.ShowAlways = true;
            toolTipALL.SetToolTip(comboBoxTICSTT, "Plese Select Status in Dropdown Here.");
        }

        private void comboBoxTICMAT_MouseHover(object sender, EventArgs e)
        {
            toolTipALL.ShowAlways = true;
            toolTipALL.SetToolTip(comboBoxTICMAT, "Plese Select Material Name in Dropdown Here.");
        }

        private void textBoxTICWIN_MouseHover(object sender, EventArgs e)
        {
            toolTipALL.ShowAlways = true;
            toolTipALL.SetToolTip(textBoxTICWIN, "Plese Fill in Weight In Here.");
        }

        private void dateTimePickerTICWINT_MouseHover(object sender, EventArgs e)
        {
            toolTipALL.ShowAlways = true;
            toolTipALL.SetToolTip(dateTimePickerTICWINT, "Plese Select Weight In Time in Dropdown Here.");
        }

        private void textBoxTICWO_MouseHover(object sender, EventArgs e)
        {
            toolTipALL.ShowAlways = true;
            toolTipALL.SetToolTip(textBoxTICWO, "Plese Fill in Weight Out Here.");
        }

        private void dateTimePickerTICWOT_MouseHover(object sender, EventArgs e)
        {
            toolTipALL.ShowAlways = true;
            toolTipALL.SetToolTip(dateTimePickerTICWOT, "Plese Select Weight Out Time in Dropdown Here.");
        }

        private void textBoxTICWN_MouseHover(object sender, EventArgs e)
        {
            toolTipALL.ShowAlways = true;
            toolTipALL.SetToolTip(textBoxTICWN, "Plese Fill in Weight Net Here.");
        }

        private void dateTimePickerTICWNT_MouseHover(object sender, EventArgs e)
        {
            toolTipALL.ShowAlways = true;
            toolTipALL.SetToolTip(dateTimePickerTICWNT, "Plese Select Weight Net Time in Dropdown Here.");
        }

        private void textBoxTICQC_MouseHover(object sender, EventArgs e)
        {
            toolTipALL.ShowAlways = true;
            toolTipALL.SetToolTip(textBoxTICQC, "Plese Fill in Deduct by QC Here.");
        }

        private void textBoxTICLG_MouseHover(object sender, EventArgs e)
        {
            toolTipALL.ShowAlways = true;
            toolTipALL.SetToolTip(textBoxTICLG, "Plese Fill in Deduct by LG Here.");
        }

        private void checkBoxTICFLAG_MouseHover(object sender, EventArgs e)
        {
            toolTipALL.ShowAlways = true;
            toolTipALL.SetToolTip(checkBoxTICFLAG, "Plese Select Inspector Appproved Flag in Flag Here.");
        }

        private void cb_Inspectror_App_MouseHover(object sender, EventArgs e)
        {
            toolTipALL.ShowAlways = true;
            toolTipALL.SetToolTip(cb_Inspectror_App, "Plese Select Drowdron Inspector Appproved Name in Droprown Here.");
        }






        

        private void richtextBoxPICPATH_TextChanged(object sender, EventArgs e)
        {

            //bool CheckDup = false;
            //Int32 rowToDelete = this.dgvPIC.Rows.GetFirstRow(
            //                         DataGridViewElementStates.Selected);
            //Int32 r = this.dgvPIC.SelectedRows.Count;

            //if (richtextBoxPICPATH.Text != "" && textBoxPICN.Text != "")
            //{

            //    foreach (DataGridViewRow drg in this.dgvPIC.Rows)
            //    {
            //        this.dgvPIC.Rows[r].Frozen = true;
            //        if (drg.Cells["Pic_Path"].Value.ToString() == richtextBoxPICPATH.Text)
            //        {
            //            CheckDup = true;
            //            dgvPIC.ClearSelection();
            //            break;
            //        }

            //        CheckDup = false;

            //    }

            //    if (CheckDup == false)
            //    {
            //        if (textBoxPICN.Text != "")
            //        {

            //            dgvPIC.ClearSelection();

            //        }
            //    }

            //    foreach (DataRow drr in this._dsData.Tables[this._SqlTransactionManager.TableNameISI_Pictrue].Rows)
            //    {
            //        if (drr.RowState != DataRowState.Unchanged)

            //            foreach (DataGridViewRow drg in this.dgvPIC.Rows)
            //            {
            //                if (CheckDup == true && drg.Cells["Pic_Path"].Value.ToString() == richtextBoxPICPATH.Text)
            //                {

            //                    MessageBox.Show("Pictrues Path Is Duppucate !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            //                    if (rowToDelete == -1)
            //                    {

            //                        rowToDelete += 2;
            //                        richtextBoxPICPATH.ResetText();
            //                        dr2 = this._dsData.Tables[this._SqlTransactionManager.TableNameISI_Pictrue].Rows[r];
            //                        dr2["Pic_Path"] = richtextBoxPICPATH.Text; ;
            //                        break;

            //                    }

            //                }
            //                else
            //                {
            //                    break;
            //                }
            //            }
            //    }
            //}



        }

        private void bdsDefDel_Click(object sender, EventArgs e)
        {
            if (dgvDEF.Rows.Count==0)
                {
                    tsbAddPic.Enabled = false;
                    PanalPIC.Enabled = false;
                    //ModeDEF.Enabled = false;
                }
        }

        private void textBoxTICQC_TextChanged(object sender, EventArgs e)
        {
            //if (textBoxTICQC.Text == ".00" || textBoxTICQC.Text == "0" || textBoxTICQC.Text == "0.00" && textBoxTICLG.Text == "0.00")
            //{
            //    textBoxTICQC.Text = "0.00";
            //    this.tsbAddnewDef.Enabled = false;
            //}
            //else 
            
            //}
           
        }

        private void textBoxTICLG_TextChanged(object sender, EventArgs e)
        {
        //    if (textBoxTICLG.Text != "")
        //    {


        //        if (textBoxTICLG.Text == ".00" || textBoxTICLG.Text == "0" || textBoxTICLG.Text == "0.00" && textBoxTICQC.Text == "0.00")
        //        {
        //            textBoxTICLG.Text = "0.00";
        //            this.tsbAddnewDef.Enabled = false;
        //        }
        //        else
        //        {
        //            tsbAddnewDef.Enabled = true;
        //        }
               
            //}
        }

        private void textBoxTICWIN_TextChanged(object sender, EventArgs e)
        {
            //if (textBoxTICWIN.Text =="0.00")
            //{
            //    this.textBoxTICWO.Text ="0.00";
            //    textBoxTICWN.Text = "0.00";
            //}
        }

        private void textBoxTICWO_TextChanged(object sender, EventArgs e)
        {
            //if (textBoxTICWIN.Text == "0.00")
            //{
            //    this.textBoxTICQC.Text = "0.00";
            //    this.textBoxTICLG.Text = "0.00";
            //}
        }

        private void textBoxTICWN_TextChanged(object sender, EventArgs e)
        {
            //if (textBoxTICWN.Text == "0.00")
            //{
            //    this.textBoxTICQC.Text = "0.00";
            //    this.textBoxTICLG.Text = "0.00";
            //}
            
        }

        private void textBoxTICWIN_EnabledChanged(object sender, EventArgs e)
        {
           
        }

        private bool button1WasClicked = false;
        private bool button2WasClicked = false;
        private bool button3WasClicked = false;
        private bool button4WasClicked = false;
        private bool button5WasClicked = false;
        private bool button6WasClicked = false;
        private bool button7WasClicked = false;
     

        

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
           // if (this.ModeDEF.Checked)
           // {
           //     DW.Visible = true;
           //     this.txtDefectWeight.Visible = false;
               
               
           // }
           //else
           // {
           //     DW.Visible = false;
           //     txtDefectWeight.Visible = true;
               
           // }   
               
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
             button1WasClicked = true;
            editPIC.Enabled = false;
            if (button1WasClicked)
            {
                Binding br;
                br = null;
                br = new Binding("Text", bdsPIC, "Pic_Des", true);
                br.NullValue = false;
                textBoxPICN.DataBindings.Add(br);
            }
        }

        private void textBoxTicketRun_TextChanged(object sender, EventArgs e)
        {

           
        }

        private void textBoxTICQC_KeyDown(object sender, KeyEventArgs e)
        {
            this.textBoxTICQC.MaxLength = textBoxTICWN.Text.Count() - 1; 
              
        }

        private void textBoxTICLG_KeyDown(object sender, KeyEventArgs e)
        {

            this.textBoxTICLG.MaxLength = this.textBoxTICQC.MaxLength;
            
        }

        private void textBoxTICWIN_KeyDown(object sender, KeyEventArgs e1)
        {
            if (textBoxTICWIN.TextLength >= 1)
            {
                textBoxTICWIN.SelectedText.ToString();


                if (e1.KeyValue ==57 || e1.KeyValue ==56 || e1.KeyValue ==55  || e1.KeyValue ==54 || e1.KeyValue ==53 || e1.KeyValue ==52 || e1.KeyValue ==51 || e1.KeyValue ==50 || e1.KeyValue ==49)
                {
                    if (textBoxTICWIN.Text != "")
                    {
                        
                        e1.Handled = true;
                    }
   
                    //if (e1.Handled == true)
                    //{
                        
                        
                    //        textBoxTICWIN.Text.Count();
                           

                        
                    //    //MessageBox.Show(textBoxTICWIN.Text.Count().ToString());
                    //}
                }
            }
        }
        private void textBoxTICWO_KeyDown(object sender, KeyEventArgs e2)
        {
            this.textBoxTICWO.MaxLength = this.textBoxTICWIN.TextLength; 
             if (textBoxTICWIN.TextLength >= 1)
            {
                textBoxTICWO.SelectedText.ToString();


                if (e2.KeyValue ==57 || e2.KeyValue ==56 || e2.KeyValue ==55  || e2.KeyValue ==54 || e2.KeyValue ==53 || e2.KeyValue ==52 || e2.KeyValue ==51 || e2.KeyValue ==50 || e2.KeyValue ==49)
                {
                    if (textBoxTICWO.Text != "")
                    {
                        
                        e2.Handled = true;
                    }
   
                    if (e2.Handled == true)
                    {
                        
                            textBoxTICWO.Text.Count();
                         
                        
                        //MessageBox.Show(textBoxTICWIN.Text.Count().ToString());
                    }
                }
            }
        }

        private void textBoxTICWN_KeyDown(object sender, KeyEventArgs e)
        {
            this.textBoxTICWN.MaxLength = textBoxTICWIN.Text.Count(); 
        }

        private void txtDefectWeight_TextChanged(object sender, EventArgs e)
        {
        }

        private void NETW_ValueChanged(object sender, EventArgs e)
        {
            OUTW.ValueChanged += new EventHandler(OUTW_ValueChanged);       
        }

        private void OUTW_ValueChanged(object sender, EventArgs e)
        {
            
            if (INW.Value<OUTW.Value)
            {
                MessageBox.Show("Weight Out must have Value less than Weight IN", "Incorrect", MessageBoxButtons.OK, MessageBoxIcon.Error);
                OUTW.Value = INW.Value - 1;
            }
            if (button5WasClicked)
            {
                this.textBoxTICWO.Text = String.Empty;
                this.textBoxTICWN.Text = String.Empty;
            }
            if (OUTW.Value != 0)
            {
                this.textBoxTICWO.Text += (((OUTW.Value) / INW.Value) * 100).ToString("#,0.00");
                this.textBoxTICWO.Text += "%";
                this.textBoxTICWN.Text += (((INW.Value - OUTW.Value - QCW.Value) / INW.Value) * 100).ToString("#,0.00");
                NETW.Value = (INW.Value - OUTW.Value - QCW.Value);
                this.textBoxTICWN.Text += "%";
                button5WasClicked = true;
            }
            

        }

        private void ModeChange_Click(object sender, EventArgs e)
        {
            if (ModeChange.Checked)
            {
                INW.Visible = false;
                OUTW.Visible = false;
                NETW.Visible = false;
                QCW.Visible = false;
                textBoxTICWIN.Visible = true;
                textBoxTICWO.Visible = true;
                textBoxTICWN.Visible = true;
                textBoxTICQC.Visible = true;
                DW.Visible = false;
                this.txtDefectWeight.Visible = true;
                this.textBoxTICWN.ReadOnly = true;
                this.textBoxTICWIN.ReadOnly = true;
                this.textBoxTICWO.ReadOnly = true;
                this.textBoxTICQC.ReadOnly = true;
            }
            else
            {
                INW.Visible = true;
                OUTW.Visible = true;
                NETW.Visible = true;
                QCW.Visible = true;
                DW.Visible = true;
                txtDefectWeight.Visible = false;
                textBoxTICWIN.Visible = false;
                textBoxTICWO.Visible = false;
                textBoxTICWN.Visible = false;
                textBoxTICQC.Visible = false;
            }
        }

        private void INW_ValueChanged(object sender, EventArgs e)
        {
            if (button4WasClicked)
            {
                this.textBoxTICWIN.Text = String.Empty;
            }
            this.textBoxTICWIN.Text = "100%";
            button4WasClicked = true;
        }

        private void QCW_ValueChanged(object sender, EventArgs e)
        {
            if (QCW.Value > INW.Value)
            {
                MessageBox.Show("Inspection Weight must have Value less than Weight IN", "Incorrect", MessageBoxButtons.OK, MessageBoxIcon.Error);
                QCW.Value = INW.Value ;
            }
          if (button3WasClicked)
            {
                this.textBoxTICQC.Text = String.Empty;
            }
          if (QCW.Value !=0)
          {
              this.textBoxTICQC.Text += ((QCW.Value / INW.Value) * 100).ToString("#,0.00");
              this.textBoxTICQC.Text += "%";
              button3WasClicked = true;
              A = QCW.Value;
              DW.Value = A;
              DW.Refresh();
              tsbAddnewDef.Enabled = true;
              DW.Enabled = true;
              
          }
          else
          {
              tsbAddnewDef.Enabled = false;
          }
           
            
           
        }

        private void DW_ValueChanged(object sender, EventArgs e)
        {
            sum = DW.Value;
            if ( sum == 0)
            {
                tsbAddnewDef.Enabled = false;
            }
           
            if (sum > A )
            {
                MessageBox.Show("Defect Weight must Equal or less than QC Inspection ","Incorrect",MessageBoxButtons.OK,MessageBoxIcon.Error);
                DW.Focus();
                DW.Value = A;
            }
           
            if (button7WasClicked)
            {
                this.txtDefectWeight.Text = String.Empty;
               
            }
            this.txtDefectWeight.Text += ((((DW.Value) * 100)) / A).ToString("#,0.00");
            this.txtDefectWeight.Text += "%";
            button7WasClicked = true;
            
        }
       
        }
    }




