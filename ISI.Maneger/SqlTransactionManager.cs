using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;
using ISI.Data;


namespace ISI.Maneger
{

     

   public class SqlTransactionManager
    {
        string _connStr = "";
        string _userID = "";
       
        string _tableNameISI_Document = "ISI_Document";
        string _tableNameISI_Incoming = "ISI_Incoming";
        string _tableNameISI_DefectDetail = "ISI_DefectDetail";
        string _tableNameISI_Pictrue = "ISI_Pictrue";
        string _tableNameISI_Defect = "ISI_Defect";
        string _tableNameISI_Material = "ISI_Material";
        string _tableNameISI_Quality_Control_Status = "ISI_Quality_Control_Status";
        string _tableNameISI_Quality_Check = "ISI_Quality_Check";
        string _F_K_Incoming = "F_K_Incoming";
        string _F_K_Defect = "F_K_Defect";
        string _F_K_Pictures = "F_K_Pictures";
        string _tableNameIncomingReport = "IncomingReport";
        string _ReportM = "ReportM";
        string _ReportSelect = "ReportSelect";
       
        public SqlTransactionManager(string connStr, string userID)
           
        {
            this._connStr = connStr;
            this._userID = userID;
            
           
        }


        #region get data

        public DataSet GetISI_IncomingList(string Doc_ID)
        {
            DataSet dataSet = null;


            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();

                string sqlText = @"SELECT Doc_ID
                                          ,Doc_Des
                                          ,Doc_Date
                                          ,isnull(Doc_Activated,0) as Doc_Activated
                                          ,Doc_created_by
                                          ,Doc_created_Time
                                          ,Doc_updated_by
                                          ,Doc_Updated_Time
                                          ,QC_Inspector
                                          ,LG_Inspector
                                          ,Approved_Inspector
                                          ,Doc_Running
                                      FROM ISI_Document 
                                    WHERE Doc_ID = @Doc_ID";

                dataSet = DataHelper.ExecuteDataSet(connection,
                                                    sqlText,
                                                    CommandType.Text,
                                                    new SqlParameter[]
                                                    {
                                                        new SqlParameter("@Doc_ID",Doc_ID),
                                                        //new SqlParameter("@Doc_ID",Doc_ID),
                                                        //new SqlParameter("@Doc_ID",Doc_ID),
                                                        //new SqlParameter("@Doc_ID",Doc_ID),
                                                        //new SqlParameter("@Doc_ID",Doc_ID),
                                                    },
                                                    this.TableNameISI_Document);




                sqlText = @"SELECT  
                                    Trn_Ticket
                                        ,Trn_PO
                                        ,Trn_Truck_Id
                                        ,Trn_Date
                                        ,Trn_Deduct_QC
                                        ,Trn_Deduct_LG
                                        ,Trn_Weight_IN
                                        ,Trn_Weight_IN_Time
                                        ,Trn_Weight_OUT
                                        ,Trn_Weight_OUT_Time
                                        ,Trn_Weight_Net
                                        ,Trn_Weight_Net_Time
                                        ,Inspector_Approved
                                        ,Inspector_Approved_Date
                                        ,Approved_Flag
                                        ,Trn_created_Time
                                        ,Trn_created_by
                                        ,Trn_updated_by
                                        ,Trn_updated_Time
                                        ,im.Mat_Id
                                        ,Status_ID
                                        ,Sup_ID
                                        ,Doc_ID
                                        ,Trn_Ticket_Run 
				                        ,m.Mat_Desc
				                        ,m.Mat_Code
                        FROM ISI_Incoming  as im
                        LEFT OUTER JOIN ISI_Material as m ON m.Mat_ID = im.Mat_Id
                        WHERE Doc_ID = @Doc_ID
                            ";

                dataSet.Merge(DataHelper.ExecuteDataSet(connection,
                                                    sqlText,
                                                    CommandType.Text,
                                                     new SqlParameter[]
                                                    {
                                                        new SqlParameter("@Doc_ID",Doc_ID),
                                                    },
                                                    this.TableNameISI_Incoming));

                sqlText = @"SELECT  
                                                       
                                                 Def.In_Def_ID
                                                      ,Def.In_Def_Weigth_Kg
                                                      ,Def.In_Def_created_Time
                                                      ,Def.In_Def_created_by
                                                      ,Def.In_Def_updated_by
                                                      ,Def.In_Def_updated_Time
                                                      ,Def.Def_ID
                                                      ,Def.Trn_Ticket
                                                      ,Incom.Doc_ID
                                                      ,de.Def_Desc
                                                      ,de.Def_Remark
                                                  FROM ISI_Incoming_Defect as Def
                                                  LEFT OUTER JOIN ISI_Incoming as Incom ON Incom.Trn_Ticket = Def.Trn_Ticket
                                                  LEFT OUTER JOIN ISI_Defect as de ON de.Def_ID = Def.Def_ID
                                            WHERE Incom.Doc_ID = @Doc_ID";

                dataSet.Merge(DataHelper.ExecuteDataSet(connection,
                                                    sqlText,
                                                    CommandType.Text,
                                                     new SqlParameter[]
                                                    {
                                                        new SqlParameter("@Doc_ID",Doc_ID),
                                                    },
                                                    this.TableNameISI_DefectDetail));



                sqlText = @"SELECT  
                                                        
                                                                 Pic.Pic_ID
                                                                      ,Pic.Pic_Path
                                                                      ,Pic.Pic_Des
                                                                      ,Pic.Trn_Ticket
                                                                      ,Incom.Doc_ID
                                                                  FROM ISI_Picture as Pic
                                                                  LEFT OUTER JOIN ISI_Incoming as Incom ON Incom.Trn_Ticket = Pic.Trn_Ticket     
                                                    WHERE Incom.Doc_ID = @Doc_ID";

                
                dataSet.Merge(DataHelper.ExecuteDataSet(connection,
                                                    sqlText,
                                                    CommandType.Text,
                                                    new SqlParameter[]
                                                    {
                                                        new SqlParameter("@Doc_ID",Doc_ID),
                                                    },
                                                    this.TableNameISI_Pictrue));
                


            }

            DataRelation Mapdata = new DataRelation(this.F_K_Incoming, dataSet.Tables[this.TableNameISI_Document].Columns["Doc_ID"],
                                                                      dataSet.Tables[this.TableNameISI_Incoming].Columns["Doc_ID"], false);
            dataSet.Relations.Add(Mapdata);

            DataRelation MapdataDef = new DataRelation(this.F_K_Defect, dataSet.Tables[this.TableNameISI_Incoming].Columns["Trn_Ticket"],
                                                                      dataSet.Tables[this.TableNameISI_DefectDetail].Columns["Trn_Ticket"], false);
            dataSet.Relations.Add(MapdataDef);

            DataRelation MapdataPic = new DataRelation(this.F_K_Pictures, dataSet.Tables[this.TableNameISI_Incoming].Columns["Trn_Ticket"],
                                                                      dataSet.Tables[this.TableNameISI_Pictrue].Columns["Trn_Ticket"], false);
            dataSet.Relations.Add(MapdataPic);



            return dataSet;
            
                
                
             


        }
        public DataTable GetISI_DocumentList()
        {
            DataSet dataSet = null;


            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();

                string sqlText = @"SELECT Doc_ID
                                          ,Doc_Des
                                          ,Doc_Date
                                          ,Doc_Activated
                                          ,Doc_created_by
                                          ,Doc_created_Time
                                          ,Doc_updated_by
                                          ,Doc_Updated_Time
                                          ,QC_Inspector
                                          ,LG_Inspector
                                          ,Approved_Inspector
                                          ,Doc_Running
                                      FROM ISI_Document";

                dataSet = DataHelper.ExecuteDataSet(connection,
                                                    sqlText,
                                                    CommandType.Text,
                                                    null,
                                                    this.TableNameISI_Document);
            }

            
            return dataSet.Tables[0];



        }
//        public DataTable GetISI_Report(string docId)
//        {
//            DataSet dataSet = null;

//            using (SqlConnection connection = new SqlConnection(_connStr))
//            {
                
//                connection.Open();

//                string sqlText = @"SELECT  Doc_ID
//                                    , CONVERT(varchar, Doc_Date, 106) AS Doc_Date
//                                    , QC_Inspector
//                                    , QC_InspectorName
//                                    , LG_Inspector
//                                    , LG_InspectorName
//                                    , Approved_Inspector
//                                    , ApprovedName
//                                    , Tck_No
//                                    , PO
//                                    , Truck_No
//                                    , Trn_Date
//                                    , Trn_Deduct_QC
//                                    , Trn_Weight_IN
//                                    , Trn_Deduct_LG
//                                    , Trn_Weight_IN_Time
//                                    , Trn_Weight_OUT
//                                    , Trn_Weight_OUT_Time
//                                    , Trn_Weight_Net AS Trn_Weight_Net_
//                                    , Inspector_Approved
//                                    , Inspector_ApprovedName
//                                    , Trn_Weight_Net_Time
//                                    , Inspector_Approved_Date
//                                    , Approved_Flag
//                                    , Status_Desc
//                                    , Status_ID
//                                    , Status_Remark
//                                    , Mat_Code
//                                    , Mat_Desc
//                                    , Sup_desc
//                                    , 0 as In_Def_Weigth_Kg
//                                    , '' as Defect
//                                    , '' as Pic_Path
//                                FROM  V_Incoming 
//                                ";

//                dataSet = DataHelper.ExecuteDataSet(connection,
//                                                    sqlText,
//                                                    CommandType.Text,
//                                                     new SqlParameter[]
//                                                    {
//                                                        new SqlParameter("@docID",docId),
//                                                    },
//                                                    //null,
//                                                    this.TableNameIncomingReport);
//                sqlText = @"SELECT x.Doc_ID, i.In_Def_ID
//                              ,i.In_Def_Weigth_Kg
//                              ,i.In_Def_created_Time
//                              ,i.In_Def_created_by
//                              ,i.In_Def_updated_by
//                              ,i.In_Def_updated_Time
//                              ,i.Def_ID
//                              ,i.Trn_Ticket
//	                          ,d.Def_Desc
//                          FROM ISI_Incoming_Defect i
//                          inner join ISI_Defect d on i.Def_ID = d.Def_ID 
//						        INNER JOIN ISI_Incoming as X ON 
//								i.Trn_Ticket  = x.Trn_Ticket   --WHERE  x.Doc_ID ='01' or Doc_ID = '02'or Doc_ID ='03' or Doc_ID = '04'or Doc_ID ='05' or Doc_ID = '06'";
                       
//                dataSet.Merge(DataHelper.ExecuteDataSet(connection,
//                                    sqlText,
//                                    CommandType.Text,
//                                     //new SqlParameter[]
//                                                    //{
//                                                    //    new SqlParameter("@docID",docId),
//                                                    //},
//                                     null,
//                                    this.TableNameISI_Defect));

//                sqlText = @"SELECT x.Doc_ID,i.Pic_ID
//                              ,i.Pic_Path
//                              ,i.Pic_Des
//                              ,i.Trn_Ticket
//                          FROM ISI_Picture  i INNER JOIN ISI_Incoming as X ON 
//								i.Trn_Ticket  = x.Trn_Ticket
//                                   --WHERE  x.Doc_ID ='01' or Doc_ID = '02'or Doc_ID ='03' or Doc_ID = '04'or Doc_ID ='05' or Doc_ID = '06'
//";
//                dataSet.Merge(DataHelper.ExecuteDataSet(connection,
//                                    sqlText,
//                                    CommandType.Text,
//                                     //new SqlParameter[]
//                                     //               {
//                                     //                   new SqlParameter("@docID",docId),
//                                     //               },
//                                     null,
//                                    this.TableNameISI_Pictrue));

//                DataRelation MapdataDef = new DataRelation(this.F_K_Defect, dataSet.Tables[this.TableNameIncomingReport].Columns["Tck_No"],
//                                                                            dataSet.Tables[this.TableNameISI_Defect].Columns["Trn_Ticket"], false);
//                dataSet.Relations.Add(MapdataDef);

//                DataRelation MapdataPic = new DataRelation(this.F_K_Pictures, dataSet.Tables[this.TableNameIncomingReport].Columns["Tck_No"],
//                                                                              dataSet.Tables[this.TableNameISI_Pictrue].Columns["Trn_Ticket"], false);
//                dataSet.Relations.Add(MapdataPic);

//            }

//            string strTrnNo = "";
//            string strDefect = "";
//            string strPICPATH = "";
//            #region Defect
//            DataTable dtReport2 = dataSet.Tables[this.TableNameIncomingReport].Copy();
//            dtReport2.Rows.Clear();
//            DataRow xdr2;
//            foreach (DataRow ldr in dataSet.Tables[this.TableNameIncomingReport].Rows)
//            {
//                strTrnNo = ldr["Tck_No"].ToString();
//                strDefect = "";
//                DataRow[] dr = dataSet.Tables[this.TableNameISI_Defect].Select(string.Format("Trn_Ticket = '{0}'", strTrnNo));

//                if (dr.Length > 0)
//                {
//                    for (int i = 0; i < dr.Length; i++)
//                    {
//                        strDefect += dr[i]["Def_Desc"].ToString();
//                        strDefect += " (";
//                        if (dr[i]["In_Def_Weigth_Kg"].ToString() == "0.00")
//                        {
//                            ldr["Defect"] = dr[i]["Def_Desc"].ToString();
//                            break;
//                        }
//                        strDefect += Convert.ToDecimal(dr[i]["In_Def_Weigth_Kg"].ToString()).ToString();
//                        strDefect += ") kg.";
//                        strDefect += "\n";
//                        ldr["Defect"] = strDefect;
//                        xdr2 = dtReport2.NewRow();
//                        for (int x = 0; x < dtReport2.Columns.Count; x++)
//                        {
//                            xdr2[x] = ldr[x];
//                        }
//                        dtReport2.Rows.Add(xdr2);
                        

//                    }
//                }
//                else
//                {
//                    xdr2 = dtReport2.NewRow();
//                    for (int x = 0; x < dtReport2.Columns.Count; x++)
//                    {
//                        xdr2[x] = ldr[x];
//                    }
//                    dtReport2.Rows.Add(xdr2);
//                }
//            }
//            #endregion
//            #region Picture
//            DataTable dtReport = dataSet.Tables[this.TableNameIncomingReport].Copy();
//            dtReport.Rows.Clear();
//            DataRow xdr;
//            foreach (DataRow ldr in dataSet.Tables[this.TableNameIncomingReport].Rows)
//            {
//                strTrnNo = ldr["Tck_No"].ToString();
//                DataRow[] dr = dataSet.Tables[this._tableNameISI_Pictrue].Select(string.Format("Trn_Ticket = '{0}'", strTrnNo));

//                if (dr.Length > 0)
//                {
//                    for (int i = 0; i < dr.Length; i++)
//                    {
//                        strPICPATH = "file:///";
//                        strPICPATH += dr[i]["Pic_Path"].ToString();
//                        ldr["Pic_Path"] = strPICPATH;
//                        xdr = dtReport.NewRow();
//                        for (int x = 0; x < dtReport.Columns.Count; x++)
//                        {
//                            xdr[x] = ldr[x];
//                        }
//                        dtReport.Rows.Add(xdr);
//                    }
//                }
//                  else
//                {
//                    xdr = dtReport.NewRow();
//                    for (int x = 0; x < dtReport.Columns.Count; x++)
//                    {
//                        xdr[x] = ldr[x];
//                    }
//                    dtReport.Rows.Add(xdr);
//                }
//            }
//            #endregion

//            return dtReport;
//        }

        // example
        public DataSet GetISI_ReportM_DS(string docId)
        {

            DataSet dataSet = null;

            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                string sql = @"SELECT DISTINCT Doc_ID
                                    , CONVERT(varchar, Doc_Date, 106) AS Doc_Date
                                    , QC_Inspector
                                    , QC_InspectorName
                                    , LG_Inspector
                                    , LG_InspectorName
                                    , Approved_Inspector
                                    , ApprovedName
                                    , Tck_No
                                    , PO
                                    , Truck_No
                                    , Trn_Date
                                    , Trn_Deduct_QC
                                    , Trn_Weight_IN
                                    , Trn_Deduct_LG
                                    , Trn_Weight_IN_Time
                                    , Trn_Weight_OUT
                                    , Trn_Weight_OUT_Time
                                    , Trn_Weight_Net AS Trn_Weight_Net_
                                    , Inspector_Approved
                                    , Inspector_ApprovedName
                                    , Trn_Weight_Net_Time
                                    , Inspector_Approved_Date
                                    , Approved_Flag
                                    , Status_Desc
                                    , Status_ID
                                    , Status_Remark
                                    , Mat_Code
                                    , Mat_Desc
                                    , Sup_desc
                                    , 0 as In_Def_Weigth_Kg
                                    , '' as Defect
                                    , '' as Pic_Path
                                FROM  V_Incoming
                            WHERE  (Doc_ID = @docID)";

                connection.Open();
                dataSet = DataHelper.ExecuteDataSet(connection,
                                                    sql,
                                                    CommandType.Text,
                                                    new SqlParameter[]
                                                    {
                                                        new SqlParameter("@docID",docId),
                                                    },
                                                    this.TableNameIncomingReport);

                sql = @"SELECT x.Doc_ID,i.In_Def_ID
                              ,i.In_Def_Weigth_Kg
                              ,i.In_Def_created_Time
                              ,i.In_Def_created_by
                              ,i.In_Def_updated_by
                              ,i.In_Def_updated_Time
                              ,i.Def_ID
                              ,i.Trn_Ticket
	                          ,d.Def_Desc
                          FROM ISI_Incoming_Defect i
                          inner join ISI_Defect d on i.Def_ID = d.Def_ID 
						        INNER JOIN ISI_Incoming as X ON 
								i.Trn_Ticket  = x.Trn_Ticket
                       WHERE  x.Doc_ID  =  @docID ";
                dataSet.Merge(DataHelper.ExecuteDataSet(connection,
                                    sql,
                                    CommandType.Text,
                                    new SqlParameter[]
                                                    {
                                                        new SqlParameter("@docID",docId),
                                                    },
                                    this.TableNameISI_Defect));

                sql = @"SELECT x.Doc_ID,i.Pic_ID
                              ,i.Pic_Path
                              ,i.Pic_Des
                              ,i.Trn_Ticket
                          FROM ISI_Picture  i INNER JOIN ISI_Incoming as X ON 
								i.Trn_Ticket  = x.Trn_Ticket";
                dataSet.Merge(DataHelper.ExecuteDataSet(connection,
                                    sql,
                                    CommandType.Text,
                                   new SqlParameter[]
                                                    {
                                                        new SqlParameter("@docID",docId),
                                                    },
                                    this.TableNameISI_Pictrue));

                DataRelation MapdataDef = new DataRelation(this.F_K_Defect, dataSet.Tables[this.TableNameIncomingReport].Columns["Tck_No"],
                                                                            dataSet.Tables[this.TableNameISI_Defect].Columns["Trn_Ticket"], false);
                dataSet.Relations.Add(MapdataDef);

                DataRelation MapdataPic = new DataRelation(this.F_K_Pictures, dataSet.Tables[this.TableNameIncomingReport].Columns["Tck_No"],
                                                                              dataSet.Tables[this.TableNameISI_Pictrue].Columns["Trn_Ticket"], false);
                dataSet.Relations.Add(MapdataPic);

            }

            string strTrnNo = "";
            string strDefect = "";
            string strPICPATH = "";
            if (dataSet.Tables[this.TableNameIncomingReport] != null)
            {
                foreach (DataRow drr in dataSet.Tables[this.TableNameIncomingReport].Rows)
                {
                    strTrnNo = drr["Tck_No"].ToString();

                    DataRow[] dr = dataSet.Tables[this.TableNameISI_Defect].Select(string.Format("Trn_Ticket = '{0}'", strTrnNo));

                    if (dr.Length > 0)
                    {
                        for (int i = 0; i < dr.Length; i++)
                        {
                            if (strDefect.Length > 0)
                            {
                                strDefect += "\n";
                            }
                            strDefect += dr[i]["Def_Desc"].ToString();
                            strDefect += " (";
                            strDefect += Convert.ToDecimal(dr[i]["In_Def_Weigth_Kg"].ToString()).ToString("####,##");
                            strDefect += ") kg.";
                        }
                    }
                    drr["Defect"] = strDefect;
                }
            }

            #region  Picture

            if (dataSet.Tables[this.TableNameIncomingReport] != null)
            {
                foreach (DataRow drr in dataSet.Tables[this.TableNameIncomingReport].Rows)
                {
                    strTrnNo = drr["Tck_No"].ToString();

                    DataRow[] dr = dataSet.Tables[this._tableNameISI_Pictrue].Select(string.Format("Trn_Ticket = '{0}'", strTrnNo));

                    if (dr.Length > 0)
                    {
                        for (int i = 0; i < dr.Length; i++)
                        {
                            if (strPICPATH.Length > 0)
                            {
                                strPICPATH += "\n";
                            }
                            strPICPATH += "file:///";
                            strPICPATH += dr[i]["Pic_Path"].ToString();


                        }
                    }
                    drr["Pic_Path"] = strPICPATH;
                }
            }
            #endregion 
            return dataSet;//.Tables[0];
        }
       // example
       // เเก้ sql report ทุกอย่างทีนี้
        public DataTable GetISI_ReportM(string docId, string Truck, string PO, string SUP, string MAT, string Status_ID, string Inspec, string Approved, string ApprovedS, string INTime, string OUTTime, string NetTime)
        {
            //string paraDocID,string paraTruck,string paraPO,string paraSUP,string paraMAT ,string paraStatus ,string paraInspec, string paraApproved ,string paraINTime ,string paraOutTime ,string paraNetTime ,string paraWeightIN, string paraWeightOUT , string paraWeightNet
            DataSet dataSet = null;
            string strWhere = "";
            if (docId != "")
            {
                strWhere += " and (Doc_ID = @docID)";
            }
            if (Truck != "" )
            {
                strWhere += " and (Truck_No = @Truck)";
            }
            if (PO != "")
            {
                strWhere += " and (PO = @PO)";
            }
            if (SUP != "")
            {
                strWhere += " and (Sup_desc = @SUP)";
            }
            if (MAT != "")
            {
                strWhere += " and (Mat_Code = @MAT)";
            }
            if (Status_ID != "")
            {
                strWhere += " and (Status_ID = @Status_ID)";
            }
            if (Inspec != "")
            {
                strWhere += " and (QC_Inspector = @Inspec)";
            }
            if (Approved != "")
            {
                strWhere += " and (Inspector_Approved = @Approved)";
            }
            if (ApprovedS != "")
            {
                strWhere += " and (Approved_Inspector = @ApprovedS)";
            }
            if (INTime != "")
            {
                strWhere +=@INTime;
            }
            if (OUTTime != "")
            {
                strWhere +=@OUTTime;
            }
            if (NetTime != "")
            {
                strWhere +=@NetTime;
            }
            //if (WeightIN != "")
            //{
            //    strWhere += " and (Trn_Weight_IN = '0')";
            //}
            //if (WeightOUT != "")
            //{
            //    strWhere += " and (Trn_Weight_OUT = '0')";
            //}
            //if (WeightNET != "")
            //{
            //    strWhere += "and (Trn_Weight_Net_  = '0')";
            //}




            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                string sql = @"SELECT DISTINCT Doc_ID
                                    , CONVERT(varchar, Doc_Date, 106) AS Doc_Date
                                    , QC_Inspector
                                    , QC_InspectorName
                                    , LG_Inspector
                                    , LG_InspectorName
                                    , Approved_Inspector
                                    , ApprovedName
                                    , Tck_No
                                    , PO
                                    , Truck_No
                                    , Trn_Date
                                    , Trn_Deduct_QC
                                    , Trn_Weight_IN
                                    , Trn_Deduct_LG
                                    , Trn_Weight_IN_Time
                                    , Trn_Weight_OUT
                                    , Trn_Weight_OUT_Time
                                    , Trn_Weight_Net AS Trn_Weight_Net_
                                    , Inspector_Approved
                                    , Inspector_ApprovedName
                                    , Trn_Weight_Net_Time
                                    , Inspector_Approved_Date
                                    , Approved_Flag
                                    , Status_Desc
                                    , Status_ID
                                    , Status_Remark
                                    , Mat_Code
                                    , Mat_Desc
                                    , Sup_desc
                                    ,0 as In_Def_Weigth_Kg
                                    , '' as Defect
                                    , '' as Pic_Path
                                FROM  V_Incoming
                            WHERE  1 = 1";
                sql += strWhere;

                connection.Open();       
                dataSet = DataHelper.ExecuteDataSet(connection,
                                                    sql,
                                                    CommandType.Text,
                                                    new SqlParameter[]
                                                    {
                                                        new SqlParameter("@docID",docId),
                                                        new SqlParameter("@Truck",@Truck),
                                                        new SqlParameter("@PO",PO),
                                                        new SqlParameter("@SUP",SUP),
                                                        new SqlParameter("@MAT",MAT),
                                                        new SqlParameter("@Status_ID",Status_ID),
                                                        new SqlParameter("@Inspec",Inspec),
                                                        new SqlParameter("@Approved",Approved),
                                                        new SqlParameter("@ApprovedS",ApprovedS),
                                                        new SqlParameter("@INTime",INTime),
                                                        new SqlParameter("@OUTTime",OUTTime),
                                                        new SqlParameter("@NetTime",NetTime),
                                                        //new SqlParameter("@WeightIN",WeightIN),
                                                        //new SqlParameter("@WeightOUT",WeightOUT),
                                                        //new SqlParameter("@WeightNET",WeightNET),
                                                    },
                                                    this.TableNameIncomingReport);

                sql = @"SELECT x.Doc_ID
                              ,i.In_Def_ID
                              ,i.In_Def_Weigth_Kg
                              ,i.In_Def_created_Time
                              ,i.In_Def_created_by
                              ,i.In_Def_updated_by
                              ,i.In_Def_updated_Time
                              ,i.Def_ID
                              ,i.Trn_Ticket
                              ,X.Trn_Deduct_QC
	                          ,d.Def_Desc
                          FROM ISI_Incoming_Defect i
                          inner join ISI_Defect d on i.Def_ID = d.Def_ID 
						        INNER JOIN ISI_Incoming as X ON 
								i.Trn_Ticket  = x.Trn_Ticket
                       WHERE  1 = 1 ";
            
                dataSet.Merge(DataHelper.ExecuteDataSet(connection,
                                    sql,
                                    CommandType.Text,
                                    new SqlParameter[]
                                                    {
                                                        new SqlParameter("@docID",docId),
                                                    },
                                    this.TableNameISI_Defect));


                sql = @"SELECT x.Doc_ID,i.Pic_ID
                              ,i.Pic_Path
                              ,i.Pic_Des
                              ,i.Trn_Ticket
                          FROM ISI_Picture  i INNER JOIN ISI_Incoming as X ON 
								i.Trn_Ticket  = x.Trn_Ticket
                       WHERE  1=1 ";
                

                dataSet.Merge(DataHelper.ExecuteDataSet(connection,
                                    sql,
                                    CommandType.Text,
                                     new SqlParameter[]
                                                    {
                                                        new SqlParameter("@docID",docId),
                                                    },
                                    this.TableNameISI_Pictrue));

                DataRelation MapdataDef = new DataRelation(this.F_K_Defect, dataSet.Tables[this.TableNameIncomingReport].Columns["Tck_No"],
                                                                            dataSet.Tables[this.TableNameISI_Defect].Columns["Trn_Ticket"], false);
                dataSet.Relations.Add(MapdataDef);

                DataRelation MapdataPic = new DataRelation(this.F_K_Pictures, dataSet.Tables[this.TableNameIncomingReport].Columns["Tck_No"],
                                                                              dataSet.Tables[this.TableNameISI_Pictrue].Columns["Trn_Ticket"], false);
                dataSet.Relations.Add(MapdataPic);

            }

            string strTrnNo = "";
            string strDefect = "";
            string strDefectKG = "";
            string strPICPATH = "";
            DataRow xdr2;
            #region Defect
            DataTable dtReport2 = dataSet.Tables[this.TableNameIncomingReport].Copy();
            dtReport2.Rows.Clear();

            if (dataSet.Tables[this.TableNameIncomingReport] != null)
            {
                foreach (DataRow drr in dataSet.Tables[this.TableNameIncomingReport].Rows)
                {
                    strTrnNo = drr["Tck_No"].ToString();

                    DataRow[] dr = dataSet.Tables[this.TableNameISI_Defect].Select(string.Format("Trn_Ticket = '{0}'", strTrnNo));

                    if (dr.Length > 0)
                    {
                        for (int q = 0; q < dr.Length; q++)
                        {
                            if (strDefect.Length > 0)
                            {
                                strDefect += "\n";
                            }
                            strDefect += dr[q]["Def_Desc"].ToString();
                            strDefect += " (";
                            if (dr[q]["In_Def_Weigth_Kg"].ToString() == "0.00")
                            {
                                drr["Defect"] = dr[q]["Def_Desc"].ToString();

                                break;
                            }
                            if (docId !="")
                            {
                                strDefect += Convert.ToDecimal(dr[q]["In_Def_Weigth_Kg"].ToString()).ToString();
                                if (strDefect!="0.00")
                                {
                                    strDefectKG += ((Convert.ToDecimal(dr[q]["In_Def_Weigth_Kg"]) / (Convert.ToDecimal(dr[q]["Trn_Deduct_QC"]))) * 100).ToString("#,0.00");
                                    strDefectKG += "%";
                                    strDefect += ") KG.";
                                    strDefect += "\n";
                                    strDefect += strDefectKG;
                                    drr["Defect"] = strDefect;
                                    xdr2 = dtReport2.NewRow();
                                    for (int x = 0; x < dtReport2.Columns.Count; x++)
                                    {
                                        xdr2[x] = drr[x];
                                    }
                                    dtReport2.Rows.Add(xdr2);
                                }
                                
                            }
                            
                            
                        }
                    }

                }

            }
            #endregion
            #region Picture
            DataTable dtReport = dataSet.Tables[this.TableNameIncomingReport].Copy();
            dtReport.Rows.Clear();
            DataRow xdr;
            foreach (DataRow ldr in dataSet.Tables[this.TableNameIncomingReport].Rows)
            {              
                strTrnNo = ldr["Tck_No"].ToString();
                DataRow[] dr = dataSet.Tables[this._tableNameISI_Pictrue].Select(string.Format("Trn_Ticket = '{0}'", strTrnNo));

                if (dr.Length > 0)
                {
                    for (int i = 0; i < dr.Length; i++)
                    {
                        strPICPATH = "file:///";
                        strPICPATH += dr[i]["Pic_Path"].ToString();
                        ldr["Pic_Path"] = strPICPATH;
                        xdr = dtReport.NewRow();
                        for (int x = 0; x < dtReport.Columns.Count; x++)
                        {
                            xdr[x] = ldr[x];
                        }
                        dtReport.Rows.Add(xdr);
                    }
                }
                else
                {
                    xdr = dtReport.NewRow();
                    for (int x = 0; x < dtReport.Columns.Count; x++)
                    {
                        xdr[x] = ldr[x];
                    }
                    dtReport.Rows.Add(xdr);
                }
            }
            



            
            #endregion 

            return dtReport;
        }

//        public DataTable GetISI_ReportSelect(string docId)
//        {
//            //วิธี 1 คือไปรับค่า string มาจากหน้า ReportForm   string docID = this.dgvDOC.CurrentRow.Cells["Doc_ID"].Value.ToString(); DocumenKeys = docID.ToString(); public string DocumenKeys {  set { _documentDKey = value; }}
        
           
 
//            DataSet dataSet = null;
//            String s;
//            string num = docId;
//            s = num.ToString();
//            string a = "'" + s;
//            string b = "')";
//            string add = "@";
//            string k = " = ";
//            string j = " WHERE (Doc_ID ";
//            string l = " SELECT DISTINCT Doc_ID, CONVERT(varchar, Doc_Date, 106) AS Doc_Date, QC_Inspector , QC_InspectorName , LG_Inspector , LG_InspectorName , Approved_Inspector, ApprovedName, Tck_No, PO, Truck_No, Trn_Date , Trn_Deduct_QC, Trn_Weight_IN , Trn_Deduct_LG , Trn_Weight_IN_Time , Trn_Weight_OUT, Trn_Weight_OUT_Time , Trn_Weight_Net AS Trn_Weight_Net_ , Inspector_Approved , Inspector_ApprovedName , Trn_Weight_Net_Time , Inspector_Approved_Date , Approved_Flag , Status_Desc , Status_ID , Status_Remark , Mat_Code, Mat_Desc , Sup_desc, 0 as In_Def_Weigth_Kg, '' as Defect, '' as Pic_Path FROM  V_Incoming";
//            add += l;
//            a += b;
//            k += a;
//            j += k;
//            l += j;

//            //ใช้ได้ 2 วิธี
//            //วิธี 2 คือ เอา comment ออก  + คือ ใช้ sql parameter ของ Doc ID
//           string  i= @"SELECT DISTINCT Doc_ID
//                                    , CONVERT(varchar, Doc_Date, 106) AS Doc_Date
//                                    , QC_Inspector
//                                    , QC_InspectorName
//                                    , LG_Inspector
//                                    , LG_InspectorName
//                                    , Approved_Inspector
//                                    , ApprovedName
//                                    , Tck_No
//                                    , PO
//                                    , Truck_No
//                                    , Trn_Date
//                                    , Trn_Deduct_QC
//                                    , Trn_Weight_IN
//                                    , Trn_Deduct_LG
//                                    , Trn_Weight_IN_Time
//                                    , Trn_Weight_OUT
//                                    , Trn_Weight_OUT_Time
//                                    , Trn_Weight_Net AS Trn_Weight_Net_
//                                    , Inspector_Approved
//                                    , Inspector_ApprovedName
//                                    , Trn_Weight_Net_Time
//                                    , Inspector_Approved_Date
//                                    , Approved_Flag
//                                    , Status_Desc
//                                    , Status_ID
//                                    , Status_Remark
//                                    , Mat_Code
//                                    , Mat_Desc
//                                    , Sup_desc
//                                    , 0 as In_Def_Weigth_Kg
//                                    , '' as Defect
//                                    , '' as Pic_Path
//                                FROM  V_Incoming
//                            WHERE  (Doc_ID = @docID)";

//            using (SqlConnection connection = new SqlConnection(_connStr))
//            {
                

//                connection.Open();

//                dataSet = DataHelper.ExecuteDataSet(connection,
//                                                                   i,
//                                                                   CommandType.Text,
//                                                                      new SqlParameter[]
//                                                    {
//                                                        new SqlParameter("@docID",docId),
//                                                    },
//                                                                   this.TableNameIncomingReport);

//                i = @"SELECT x.Doc_ID,i.In_Def_ID
//                              ,i.In_Def_Weigth_Kg
//                              ,i.In_Def_created_Time
//                              ,i.In_Def_created_by
//                              ,i.In_Def_updated_by
//                              ,i.In_Def_updated_Time
//                              ,i.Def_ID
//                              ,i.Trn_Ticket
//	                          ,d.Def_Desc
//                          FROM ISI_Incoming_Defect i
//                          inner join ISI_Defect d on i.Def_ID = d.Def_ID 
//						        INNER JOIN ISI_Incoming as X ON 
//								i.Trn_Ticket  = x.Trn_Ticket
//                       WHERE  x.Doc_ID  =  @docID ";

//                dataSet.Merge(DataHelper.ExecuteDataSet(connection,
//                                    i,
//                                    CommandType.Text,
//                                    new SqlParameter[]
//                                    {
//                                     new SqlParameter("@docID",docId),
//                                    } ,
//                                    this.TableNameISI_Defect));

//                i = @"SELECT x.Doc_ID,i.Pic_ID
//                              ,i.Pic_Path
//                              ,i.Pic_Des
//                              ,i.Trn_Ticket
//                          FROM ISI_Picture  i INNER JOIN ISI_Incoming as X ON 
//								i.Trn_Ticket  = x.Trn_Ticket
//                       WHERE  x.Doc_ID  =  @docID";

//                dataSet.Merge(DataHelper.ExecuteDataSet(connection,
//                                    i,
//                                    CommandType.Text,
//                                       new SqlParameter[]
//                                    {
//                                     new SqlParameter("@docID",docId),
//                                    },
//                                    this.TableNameISI_Pictrue));


               

//                DataRelation MapdataDef = new DataRelation(this.F_K_Defect, dataSet.Tables[this.TableNameIncomingReport].Columns["Tck_No"],
//                                                                            dataSet.Tables[this.TableNameISI_Defect].Columns["Trn_Ticket"], false);
//                dataSet.Relations.Add(MapdataDef);

//                DataRelation MapdataPic = new DataRelation(this.F_K_Pictures, dataSet.Tables[this.TableNameIncomingReport].Columns["Tck_No"],
//                                                                              dataSet.Tables[this.TableNameISI_Pictrue].Columns["Trn_Ticket"], false);
//                dataSet.Relations.Add(MapdataPic);

//            }

//            string strTrnNo = "";
//            string strDefect = "";
//            string strPICPATH = "";
//            DataRow xdr2;
//            #region Defect
//            DataTable dtReport2 = dataSet.Tables[this.TableNameIncomingReport].Copy();
//            dtReport2.Rows.Clear();
         
//            if (dataSet.Tables[this.TableNameIncomingReport] != null)
//            {
//                foreach (DataRow drr in dataSet.Tables[this.TableNameIncomingReport].Rows)
//                {
//                    strTrnNo = drr["Tck_No"].ToString();

//                    DataRow[] dr = dataSet.Tables[this.TableNameISI_Defect].Select(string.Format("Trn_Ticket = '{0}'", strTrnNo));

//                    if (dr.Length > 0)
//                    {
//                        for (int q = 0; q < dr.Length; q++)
//                        {
//                            if (strDefect.Length > 0)
//                            {
//                                strDefect += "\n";
//                            }
//                            strDefect += dr[q]["Def_Desc"].ToString();
//                            strDefect += " (";
//                            if (dr[q]["In_Def_Weigth_Kg"].ToString() == "0.00")
//                            {
//                                drr["Defect"] = dr[q]["Def_Desc"].ToString();
                                
//                                break;
//                            }
//                            strDefect += Convert.ToDecimal(dr[q]["In_Def_Weigth_Kg"].ToString()).ToString();
//                            strDefect += ") kg.";
//                            drr["Defect"] = strDefect;
//                            xdr2 = dtReport2.NewRow();
//                            for (int x = 0; x < dtReport2.Columns.Count; x++)
//                            {
//                                xdr2[x] = drr[x];
//                            }
//                            dtReport2.Rows.Add(xdr2);
//                        }
//                    }
                  
//                }

//            }
//            #endregion
//            #region Picture
//            DataTable dtReport = dataSet.Tables[this.TableNameIncomingReport].Copy();
//            dtReport.Rows.Clear();
//            DataRow xdr;
//            foreach (DataRow ldr in dataSet.Tables[this.TableNameIncomingReport].Rows)
//            {
//                strTrnNo = ldr["Tck_No"].ToString();
//                DataRow[] dr = dataSet.Tables[this._tableNameISI_Pictrue].Select(string.Format("Trn_Ticket = '{0}'", strTrnNo));

//                if (dr.Length > 0)
//                {
//                    for (int q = 0; q < dr.Length; q++)
//                    {
//                        strPICPATH = "file:///";
//                        strPICPATH += dr[q]["Pic_Path"].ToString();
//                        ldr["Pic_Path"] = strPICPATH;
//                        xdr = dtReport.NewRow();
//                        for (int x = 0; x < dtReport.Columns.Count; x++)
//                        {
//                            xdr[x] = ldr[x];
//                        }
//                        dtReport.Rows.Add(xdr);
//                    }
//                }
//                else
//                {
//                    xdr = dtReport.NewRow();
//                    for (int x = 0; x < dtReport.Columns.Count; x++)
//                    {
//                        xdr[x] = ldr[x];
//                    }
//                    dtReport.Rows.Add(xdr);
//                }
//            }


//            #endregion 


//            return dtReport;//dataSet.Tables[0];
//        }
       
        public string GetCheckDupDocument(string DocDate)
        {
            DataSet dataSet = null;

            string DocKey = "";

            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();

                string sqlText = @"SELECT Doc_ID
                                      FROM ISI_Document WHERE convert(varchar(8),Doc_Date,112) = @DocDate";

                dataSet = DataHelper.ExecuteDataSet(connection,
                                                    sqlText,
                                                    CommandType.Text,
                                                    new SqlParameter[]
                                                    {
                                                        new SqlParameter("@DocDate",DocDate),
                                                    },
                                                    this.TableNameISI_Document+"Date");
            }

            if (dataSet.Tables[this.TableNameISI_Document+"Date"].Rows.Count > 0)
            {
                DocKey = dataSet.Tables[this.TableNameISI_Document + "Date"].Rows[0]["Doc_ID"].ToString();
            }

            return DocKey;
        }
    

        // max Doc
        public int GetMaxDoc()
        {
            DataSet dataSet = null;
            int DocMax = 0;
            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();

                string sqlText = @"SELECT ISNULL(Max(Doc_Running),0) as Doc
                                    FROM ISI_Document";

                dataSet = DataHelper.ExecuteDataSet(connection,
                                                    sqlText,
                                                    CommandType.Text,
                                                    null,
                                                    "ISI_DocumentMax");


            }

            if (dataSet.Tables[0].Rows.Count > 0)
            {
                DocMax = Convert.ToInt32(dataSet.Tables[0].Rows[0]["Doc"].ToString());
            }
            return DocMax;
        }

        public string GetDefectRemarkByKey(string Def_ID)
        {
            DataSet dataSet = null;
            string Defect_Remark = "";
            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();

                string sqlText = @"SELECT Def_Remark
                                                      FROM ISI_Defect WHERE Def_ID =@Def_ID ";

                dataSet= DataHelper.ExecuteDataSet(connection,
                                                    sqlText,
                                                    CommandType.Text,
                                                    new SqlParameter[]
                                                    {
                                                        new SqlParameter("@Def_ID",Def_ID),
                                                    },
                                                    "ISI_Defect");


            }

            if (dataSet.Tables[0].Rows.Count > 0)
            {
                Defect_Remark = dataSet.Tables[0].Rows[0]["Def_Remark"].ToString();
            }
            return Defect_Remark;
        }

        public string GetMaterialCodeByKey(string Mat_ID)
        {
            DataSet dataSet = null;
            string Material_Code = "";
            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();

                string sqlText = @"SELECT Mat_Code
                                                      FROM ISI_Material WHERE Mat_ID =@Mat_ID ";

                dataSet = DataHelper.ExecuteDataSet(connection,
                                                    sqlText,
                                                    CommandType.Text,
                                                    new SqlParameter[]
                                                    {
                                                        new SqlParameter("@Mat_ID",Mat_ID),
                                                    },
                                                    "ISI_Material");


            }

            if (dataSet.Tables[0].Rows.Count > 0)
            {
                Material_Code = dataSet.Tables[0].Rows[0]["Mat_Code"].ToString();
            }
            return Material_Code;
        }



       #region  Save to DB


        public int SaveTransactiontoDB(DataSet dataSet)

        {
            this._lastError7 = "";
            bool checkDel = false;
            StringBuilder sb = new StringBuilder();
            DataTable dtDoc = dataSet.Tables[this.TableNameISI_Document];
            DataTable dtISI = dataSet.Tables[this.TableNameISI_Incoming];
            DataTable dtDef = dataSet.Tables[this.TableNameISI_DefectDetail];
            DataTable dtPic = dataSet.Tables[this.TableNameISI_Pictrue];


            foreach (DataRow drr in dtDoc.Rows)
            {
                if (drr.RowState == DataRowState.Added)
                {
                    drr["Doc_created_by"] = this._userID;
                    drr["Doc_updated_by"] = this._userID;

                   
                }
                if (drr.RowState == DataRowState.Modified)
                {
                    drr["Doc_updated_by"] = this._userID;
                }
            }

            foreach (DataRow drr in dtISI.Rows)
            {
                if (drr.RowState == DataRowState.Added)
                {
                    drr["Trn_created_by"] = this._userID;
                    drr["Trn_updated_by"] = this._userID;
                }
                if (drr.RowState == DataRowState.Modified)
                {
                    drr["Trn_updated_by"] = this._userID;
                    
                }
            }

            foreach (DataRow drr in dtDef.Rows)
            {
                if (drr.RowState == DataRowState.Added)
                {
                    drr["In_Def_created_by"] = this._userID;
                    drr["In_Def_updated_by"] = this._userID;
                }
                if (drr.RowState == DataRowState.Modified)
                {
                    drr["In_Def_updated_by"] = this._userID;
                }
            }

            



            // set for delete
            foreach (DataRow drr in dtISI.Rows)
            {
                if (drr.RowState == DataRowState.Deleted)
                {

                    checkDel = true;
                    
                    string TrnTicket = drr["Trn_Ticket", DataRowVersion.Original].ToString();
                    foreach (DataRow dr1 in dtDef.Rows)
                    {
                        int DefID = this.ConverttoInt(dr1["In_Def_ID"].ToString());
                        if (dr1["Trn_Ticket"].ToString() == TrnTicket && DefID != 0)
                        {
                            dr1.AcceptChanges();
                            dr1.Delete();
                        }
                    }
                    foreach (DataRow dr1 in dtPic.Rows)
                    {
                        int PicID = this.ConverttoInt(dr1["Pic_ID"].ToString());
                        if (dr1["Trn_Ticket"].ToString() == TrnTicket && PicID != 0)
                        {
                            dr1.AcceptChanges();
                            dr1.Delete();
                        }
                    }
                }
            }
            


            try
            {
                using (System.Transactions.TransactionScope scope = new TransactionScope())
                {
                    using (System.Data.SqlClient.SqlConnection connect = new System.Data.SqlClient.SqlConnection(_connStr))
                    {
                        connect.Open();

                        if (checkDel)
                        {
                            new ISI_Incoming_Defect(connect).UpdateRecord(dtDef);
                            new ISI_Picture(connect).UpdateRecord(dtPic);
                        }

                        new ISI_DOC(connect).UpdateRecord(dtDoc);
                        new ISI_Incoming(connect).UpdateRecord(dtISI);
                        new ISI_Incoming_Defect(connect).UpdateRecord(dtDef);
                        new ISI_Picture(connect).UpdateRecord(dtPic);


                    }
                    scope.Complete();
                }
                return 1;
            }
            catch (Exception exp)
            {
                sb.AppendLine("Call Error :: SaveData()");
                sb.AppendLine("Message: " + exp.Message.ToString());
                sb.AppendLine("Source: " + exp.Source.ToString());
                sb.AppendLine("StackTrace: " + exp.StackTrace.ToString());
                this._lastError7 = sb.ToString();
                return -1;
            }
        }
        #region properties 2

        public string LastError7
        {
            get { return _lastError7; }
            set { _lastError7 = value; }
        }
        #endregion
       #endregion


        public DataSet GetISI_ComboboxList()
        {
            DataSet dataSet = null;
            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();

                string sqlText = @"SELECT Sup_ID
                                          ,Sup_Desc
                                          ,Sup_Activated
                                          ,Sup_created_by
                                          ,Sup_created_Time
                                          ,Sup_updated_by
                                          ,Sup_Updated_Time
                                      FROM ISI_Supplier";

                dataSet = DataHelper.ExecuteDataSet(connection,
                                                    sqlText,
                                                    CommandType.Text,
                                                    null,
                                                    "ISI_Supplier");

                sqlText = @"SELECT  
                                                        Def_ID
                                                          ,Def_Desc
                                                          ,Def_Remark
                                                          ,Def_Activated
                                                          ,Def_created_by
                                                          ,Def_created_Time
                                                          ,Def_updated_by
                                                          ,Def_updated_Time
                                                      FROM ISI_Defect";

                dataSet.Merge(DataHelper.ExecuteDataSet(connection,
                                                    sqlText,
                                                    CommandType.Text,
                                                    null,
                                                    "ISI_Defect"));

                sqlText = @"SELECT  
                                                             Mat_ID
                                                              ,Mat_Desc
                                                              ,Mat_Code
                                                              ,Mat_Activated
                                                              ,Mat_created_by
                                                              ,Mat_created_Time
                                                              ,Mat_updated_by
                                                              ,Mat_Updated_Time
                                                          FROM ISI_Material";

                dataSet.Merge(DataHelper.ExecuteDataSet(connection,
                                                    sqlText,
                                                    CommandType.Text,
                                                    null,
                                                    "ISI_Material"));


                sqlText = @"SELECT  
                                                             
                                                Status_ID
                                                      ,Status_Desc
                                                      ,Status_Remark
                                                      ,Status_Activated
                                                      ,Status_created_by
                                                      ,Status_created_Time
                                                      ,Status_updated_by
                                                      ,Status_updated_Time
                                                  FROM ISI_Quality_Control_Status";

                dataSet.Merge(DataHelper.ExecuteDataSet(connection,
                                                    sqlText,
                                                    CommandType.Text,
                                                    null,
                                                    "ISI_Quality_Control_Status"));

                sqlText = @"SELECT  
                                                             
                                                 QC_ID
                                                      ,QC_First_Name
                                                      ,QC_Last_Name
                                                      ,QC_Department
                                                      ,QC_Activated 
                                                      ,isnull(QC_For_Create,0) as QC_For_Create
                                                      ,isnull(QC_For_Appproved,0)as QC_For_Appproved 
                                                      ,QC_created_by
                                                      ,QC_created_Time
                                                      ,QC_updated_by
                                                      ,QC_updated_Time
                                                  FROM ISI_Quality_Check where QC_Activated =1 ";
                dataSet.Merge(DataHelper.ExecuteDataSet(connection,
                                                    sqlText,
                                                    CommandType.Text,
                                                    null,
                                                    "ISI_Quality_Check"));











            }
            return dataSet;
        }

     

        #endregion get data

        #region properties

        public string TableNameISI_Document
        {
            get { return _tableNameISI_Document; }
        }
        public string TableNameISI_Incoming
        {
            get { return _tableNameISI_Incoming; }
        }
        public string TableNameISI_DefectDetail
        {
            get { return _tableNameISI_DefectDetail; }
        }
        public string TableNameISI_Pictrue
        {
            get { return _tableNameISI_Pictrue; }
        }
        public string TableNameISI_Defect
        {
            get { return _tableNameISI_Defect; }
        }
        public string TableNameISI_Material
        {
            get { return _tableNameISI_Material; }
        }
        public string TableNameISI_Quality_Control_Status
        {
            get { return _tableNameISI_Quality_Control_Status; }
        }
        public string TableNameISI_Quality_Check
        {
            get { return _tableNameISI_Quality_Check; }
        }
        public string F_K_Incoming
        {
            get { return _F_K_Incoming; }
        }
        public string F_K_Defect
        {
            get { return _F_K_Defect; }
        }
        public string F_K_Pictures
        {
            get { return _F_K_Pictures; }
        }
        public string TableNameIncomingReport
        {
            get { return _tableNameIncomingReport; }
        }
        public string ReportM
        {
            get { return _ReportM; }
        }
         public string ReportSelect
        {
            get { return _ReportSelect; }
        }


     
        #endregion



        public string _lastError7 { get; set; }

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
