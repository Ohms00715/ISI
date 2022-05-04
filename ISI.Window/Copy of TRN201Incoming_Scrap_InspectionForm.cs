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
    public partial class TRN201Incoming_Scrap_InspectionForm2 : Form
    {
        
        SqlTransactionManager _SqlTransactionManager = null;
        DataSet _dsData = null;
        DataSet _dsCob = null;
        DataRow dr;
        DataTable dt;
    
       
        string _connStr = "";
        string _userID = "";

        public TRN201Incoming_Scrap_InspectionForm2(string connStr, string userID)
        {
            InitializeComponent();
            this._connStr = connStr;
            this._userID = userID;

            dateTimePickerTICTD.CustomFormat = "dd/MM/yyyy";

            this._SqlTransactionManager = new SqlTransactionManager(this._connStr, this._userID);
            this._dsData = new DataSet();
            this._dsData = this._SqlTransactionManager.GetISI_IncomingList("");
            this._dsCob = new DataSet();
            this._dsCob = this._SqlTransactionManager.GetISI_ComboboxList();
            this.SetObject();
            this.setCombobox();
            this.BindingSource();
            DataTable dt = _dsData.Tables[0];
            
            

        }

        #region set Object

        private void SetObject()
        {
            bdsDOC.DataSource = this._dsData.Tables[this._SqlTransactionManager.TableNameISI_Document];
            bdnDOC.BindingSource = bdsDOC;
            this.dgvDOC.DataSource = bdsDOC;
            dgvDOC.ReadOnly = true;

            bdsISI.DataSource = bdsDOC;
            bdsISI.DataMember = this._SqlTransactionManager.F_K_Incoming;
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
            br = new Binding("Text", bdsDOC, "Doc_Date", true);
            dateTimePickerDOCD.DataBindings.Add(br);

            br = null;
            br = new Binding("Text", bdsDOC, "Doc_Running", true);
            this.textBoxDocrun.DataBindings.Add(br);

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
            br = new Binding("Text", bdsISI, "Trn_Deduct_QC", true);
            textBoxTICQC.DataBindings.Add(br);

            br = null;
            br = new Binding("Text", bdsISI, "Trn_Deduct_LG", true);
            textBoxTICLG.DataBindings.Add(br);

            br = null;
            br = new Binding("Text", bdsISI, "Trn_Weight_IN", true);
            textBoxTICWIN.DataBindings.Add(br);

            br = null;
            br = new Binding("Text", bdsISI, "Trn_Weight_IN_Time", true);
            dateTimePickerTICWINT.DataBindings.Add(br);

            br = null;
            br = new Binding("Text", bdsISI, "Trn_Weight_OUT", true);
            textBoxTICWO.DataBindings.Add(br);

            br = null;
            br = new Binding("Text", bdsISI, "Trn_Weight_OUT_Time", true);
            dateTimePickerTICWOT.DataBindings.Add(br);

            br = null;
            br = new Binding("Text", bdsISI, "Trn_Weight_Net", true);
            textBoxTICWN.DataBindings.Add(br);

            br = null;
            br = new Binding("Text", bdsISI, "Trn_Weight_Net_Time", true);
            dateTimePickerTICWNT.DataBindings.Add(br);

            br = null;
            br = new Binding("Checked", bdsISI, "Approved__Flag", true);
            br.NullValue = false;
            checkBoxTICFLAG.DataBindings.Add(br);

            br = null;
            br = new Binding("Text", bdsPIC, "Pic_ID", true);
            textBoxPICID.DataBindings.Add(br);

            br = null;
            br = new Binding("Text", bdsPIC, "Pic_Des", true);
            textBoxPICN.DataBindings.Add(br);

            br = null;
            br = new Binding("Text", bdsPIC, "Pic_Path", true);
            richtextBoxPICPATH.DataBindings.Add(br);
            
           






       
        }
        #endregion

         private void SaveDB()
         {
             this._SqlTransactionManager.SaveTransactiontoDB(_dsData);
         //    if (!varidate())
         //    {
         //        return;
         //    }

         //    int result = this._SqlTransactionManager.SaveTransactiontoDB(dt, _dsData);

         //    if (result == 1)
         //    {
         //        MessageBox.Show("Save to database completed...", "Save data", MessageBoxButtons.OK, MessageBoxIcon.Information);




         //    }
         //    else
         //    {
         //        MessageBox.Show(this._SqlTransactionManager.LastError7, "Fail Save data", MessageBoxButtons.OK, MessageBoxIcon.Error);

         //    }

         //}

         //private bool varidate()
         //{



         //    List<string> dupicate = new List<string>();
         //    bool dup = false;
         //    string valueDup = "";


         //    // check dupicate 
         //    for (int i = dt.Rows.Count - 1; i >= 0; i--)
         //    {
         //        dr = dt.Rows[i];
         //        if (dr.RowState != DataRowState.Deleted)
         //        {
         //            if (!dupicate.Contains(dr["Trn_Ticket"].ToString()))
         //            {
         //                dupicate.Add(dr["Trn_Ticket"].ToString());
         //            }
         //            else
         //            {
         //                dup = true;
         //                valueDup = dr["Trn_Ticket"].ToString();
         //                break;
         //            }
         //        }

         //    }
         //    if (dup)
         //    {
         //        MessageBox.Show("Trn_Ticket Dupicate : " + valueDup, "Check data", MessageBoxButtons.OK, MessageBoxIcon.Error);


         //        return false;
         //    }



         //    //
         //    foreach (DataRow drr in dt.Rows)
         //    {
         //        if (drr.RowState == DataRowState.Deleted)
         //        {
         //            continue;
         //        }
         //        if (drr["Trn_Ticket"].ToString().Length == 0 &&
         //            drr["Doc_ID"].ToString().Length == 0)
         //        {

         //            MessageBox.Show("Not null Trn_Ticket, Doc_ID", "Check Null ", MessageBoxButtons.OK, MessageBoxIcon.Error);

         //            return false;
         //        }


         //        if (drr["Doc_ID"].ToString().Length == 0)
         //        {
         //            MessageBox.Show("Not null : " + drr["Trn_Ticket"].ToString(), "Check Null for SUP_name", MessageBoxButtons.OK, MessageBoxIcon.Error);


         //            return false;
         //        }



         //        if (drr["Trn_Ticket"].ToString().Length == 0)
         //        {
         //            MessageBox.Show("Not null : " + drr["Trn_Ticket"].ToString(), "Check Null for Trn_Ticket", MessageBoxButtons.OK, MessageBoxIcon.Error);


         //            return false;
         //        }

             //}


             //return true;
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
                 this.comboBoxDEFN.DataSource = dt.Select(" Def_Activated = 1").CopyToDataTable();
                 //this.comboBoxDEFN.DataSource = this._dsCob.Tables["ISI_Defect"];
                 this.comboBoxDEFN.DisplayMember = "Def_Desc";
                 this.comboBoxDEFN.ValueMember = "Def_ID";

                 this.comboBoxDEFRE.DataSource = dt.Select(" Def_Activated = 1").CopyToDataTable();
                 //this.comboBoxDEFRE.DataSource = this._dsCob.Tables["ISI_Defect"];
                 this.comboBoxDEFRE.DisplayMember = "Def_Remark";
                 this.comboBoxDEFRE.ValueMember = "Def_ID";
             }



             #endregion

             #region MAT Not Yet
             {
                 DataTable dt = this._dsCob.Tables["ISI_Material"];
                 //this.comboBoxTICMAT.DataSource = this._dsCob.Tables["ISI_Material"];
                 this.comboBoxTICMAT.DataSource = dt.Select(" Mat_Activated = 1").CopyToDataTable();
                 this.comboBoxTICMAT.DisplayMember = "Mat_Desc";
                 this.comboBoxTICMAT.ValueMember = "Mat_ID";

                 //this.comboBoxTICMATC.DataSource = this._dsCob.Tables["ISI_Material"];
                 this.comboBoxTICMATC.DataSource = dt.Select(" Mat_Activated = 1").CopyToDataTable();
                 this.comboBoxTICMATC.DisplayMember = "Mat_Code";
                 this.comboBoxTICMATC.ValueMember = "Mat_ID";
             }
             #endregion

             #region STT
             {
                 DataTable dt = this._dsCob.Tables["ISI_Quality_Control_Status"];
                 //this.comboBoxTICSTT.DataSource = this._dsCob.Tables["ISI_Quality_Control_Status"];
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


             }
             #endregion

         }

        private void comboBoxTICMAT_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //if (comboBoxTICMATC.SelectedValue != null)
            //{
            //    DataRow rows = this._dsCob.Tables["ISI_Material"].Select(string.Format("Mat_Desc = '{0}' ", comboBoxTICMATC.SelectedValue.ToString())).FirstOrDefault();
            //    textBoxTICMATC.Text = rows["Mat_Code"].ToString();
            //}
            //else
            //{
            //    textBoxTICMATC.Text = "";
            //}
        }

        

        private void BrowseBT_Click(object sender, EventArgs e)
        {

            openFilePIC.FilterIndex = 2;
            richtextBoxPICPATH.Focus();
            openFilePIC.ShowDialog();
            openFilePIC.Title = "Browse Text Files";
            openFilePIC.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";            
            openFilePIC.CheckFileExists = true;
            openFilePIC.CheckPathExists = true;
            richtextBoxPICPATH.Text = openFilePIC.FileName;
            richtextBoxPICPATH.SelectedText = openFilePIC.FileName;
            
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SaveDB();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorAddNewItem2_Click(object sender, EventArgs e)
        {
            addDoc();
        }
        private void addDoc()
        {
            string DocNo = "";
            int maxDoc = 0;
            string msgDocDupicate = "";
            DateTime dateAdd = DateTime.Now;  // dtpDocDate dtpApproveDate
            foreach (DataRow drg in this._dsData.Tables[this._SqlTransactionManager.TableNameISI_Document].Rows)
            {
                if (maxDoc < ConverttoInt(drg["Doc_Running"].ToString()))
                {
                    maxDoc = ConverttoInt(drg["Doc_Running"].ToString());
                }
                if (drg["Doc_Date"].ToString() != "")
                {
                    DateTime dateDoc = (DateTime)drg["Doc_Date"];

                    if (dateAdd.ToString("yyyyMMdd") == dateDoc.ToString("yyyyMMdd"))
                    {
                        msgDocDupicate = "มี Document Date : " + dateAdd.ToString("dd/MM/yyyy") + " แล้ว...";
                        break;
                    }
                }
                

            }
            if (msgDocDupicate.Length> 0)
            {
                MessageBox.Show(msgDocDupicate, "วันที่ Document Date ซ้ำ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            maxDoc += 1;
            textBoxDocrun.Text = maxDoc.ToString();

            for (int i = 4; i > maxDoc.ToString().Length; i--)
			{
			    DocNo += "0";
			}
            DocNo += maxDoc;
            textBoxDOCDesc.Text = "New Document";
            textBoxDOCID.Text = DocNo;
            dateTimePickerDOCD.Value = DateTime.Now.AddDays(2);
            dateTimePickerDOCD.Value = dateAdd;

            dgvDOC.Update();
            dgvDOC.EndEdit();
            bdsDOC.EndEdit();
            
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


    }
}


