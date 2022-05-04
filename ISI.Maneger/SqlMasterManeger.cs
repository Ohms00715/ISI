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
    public class SqlMasterManeger
    {

        string _connStr = "";
        string _userID = "";
        string _lastError = "";

        public SqlMasterManeger(string connStr, string userID)
        {
            this._connStr = connStr;
            this._userID = userID;
        }


        #region get data

        public DataTable GetISI_SupplierList()
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

            }
            return dataSet.Tables[0];
        }

        // test report 
        public DataTable GetISI_IncommingList()
        {
            DataSet dataSet = null;

            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();

                string sqlText = @"SELECT d.Doc_ID AS DocumentNo, i.Trn_Truck_Id AS TickNo, i.Trn_PO AS PO, d.Doc_Des AS PODesc, CONVERT(varchar(8), d.Doc_Date, 103) AS DocumentDate,
                      (SELECT QC_First_Name
                       FROM      ISI_Quality_Check AS q
                       WHERE   (QC_ID = d.QC_Inspector)) AS QCName,
                      (SELECT QC_First_Name
                       FROM      ISI_Quality_Check AS q
                       WHERE   (QC_ID = d.LG_Inspector)) AS LGName,
                      (SELECT QC_First_Name
                       FROM      ISI_Quality_Check AS q
                       WHERE   (QC_ID = d.Approved_Inspector)) AS InsName
                        FROM     ISIDB.dbo.ISI_Document AS d LEFT OUTER JOIN
                                          ISI_Incoming AS i ON i.Doc_ID = d.Doc_ID";

                dataSet = DataHelper.ExecuteDataSet(connection,
                                                    sqlText,
                                                    CommandType.Text,
                                                    null,
                                                    "ISI_Incomming");

            }
            return dataSet.Tables[0];
        }
       



        #endregion get data

        #region Save data
        public int SaveMastertoDB(DataTable dt, string Tcode)
        {
            this.LastError = "";
            StringBuilder sb = new StringBuilder();

            foreach (DataRow drr in dt.Rows)
            {
                if (drr.RowState == DataRowState.Added)
                {
                    drr["Sup_created_by"] = this._userID;
                    drr["Sup_Updated_by"] = this._userID;
                }
                if (drr.RowState == DataRowState.Modified)
                {
                    drr["Sup_Updated_by"] = this._userID;
                }

            }

            try
            {
                using (System.Transactions.TransactionScope scope = new TransactionScope())
                {
                    using (System.Data.SqlClient.SqlConnection connect = new System.Data.SqlClient.SqlConnection(_connStr))
                    {
                        connect.Open();

                        new ISI_Supplier(connect).UpdateRecord(dt);

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
                this.LastError = sb.ToString();
                return -1;
            }
        }
        #endregion
        #region properties

        public string LastError
        {
            get { return _lastError; }
            set { _lastError = value; }
        }
        #endregion

    }
    public class SqlMasterManegerMAT
    {
        string _connStr = "";
        string _userID = "";
        string _lastError2 = "";

        public SqlMasterManegerMAT(string connStr, string userID)
        {
            this._connStr = connStr;
            this._userID = userID;
        }
        //  [Mat_ID]
        //,[Mat_Desc]
        //,[Mat_Code]
        //,[Mat_Activated]
        //,[Mat_created_by]
        //,[Mat_created_Time]
        //,[Mat_updated_by]
        //,[Mat_Updated_Time]

        public DataTable GetISI_MaterialList()
        {
            DataSet dataSet = null;

            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();

                string sqlText = @"SELECT Mat_ID
                                          ,Mat_Desc
                                          ,Mat_Code
                                          ,Mat_Activated
                                          ,Mat_created_by
                                          ,Mat_created_Time
                                          ,Mat_updated_by
                                          ,Mat_Updated_Time
                                      FROM ISI_Material";

                dataSet = DataHelper.ExecuteDataSet(connection,
                                                    sqlText,
                                                    CommandType.Text,
                                                    null,
                                                    "ISI_Material");

            }
            return dataSet.Tables[0];
        }


        #region Save data
        public int SaveMastertoDB(DataTable dt, string Tcode)
        {
            this._lastError2 = "";
            StringBuilder sb = new StringBuilder();

            foreach (DataRow drr in dt.Rows)
            {
                if (drr.RowState == DataRowState.Added)
                {
                    drr["Mat_created_by"] = this._userID;
                    drr["Mat_updated_by"] = this._userID;
                }
                if (drr.RowState == DataRowState.Modified)
                {
                    drr["Mat_updated_by"] = this._userID;
                }

            }

            try
            {
                using (System.Transactions.TransactionScope scope = new TransactionScope())
                {
                    using (System.Data.SqlClient.SqlConnection connect = new System.Data.SqlClient.SqlConnection(_connStr))
                    {
                        connect.Open();

                        new ISI_Material(connect).UpdateRecord(dt);

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
                this._lastError2 = sb.ToString();
                return -1;
            }
        }

        #endregion
        #region properties

        public string LastError2
        {
            get { return _lastError2; }
            set { _lastError2 = value; }
        }
        #endregion

    }
    public class SqlMasterManegerQC
    {
        string _connStr = "";
        string _userID = "";
        string _lastError3 = "";

        public SqlMasterManegerQC(string connStr, string userID)
        {
            this._connStr = connStr;
            this._userID = userID;
        }


        public DataTable GetISI_Quality_CheckList()
        {
            DataSet dataSet = null;

            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();
                //                /****** Script for SelectTopNRows command from SSMS  ******/
                //SELECT TOP (1000) [QC_ID]
                //      ,[QC_First_Name]
                //      ,[QC_Last_Name]
                //      ,[QC_Department]
                //      ,[QC_Activated]
                //      ,[QC_created_Time]
                //      ,[QC_created_by]
                //      ,[QC_updated_by]
                //      ,[QC_Updated_Time]
                //  FROM [ISIDB].[dbo].[ISI_Quality_Check]
                string sqlText = @"SELECT QC_ID
                                          ,QC_First_Name
                                          ,QC_Last_Name
                                          ,QC_Department
                                          ,QC_For_Create
                                          ,QC_For_Appproved
                                          ,QC_Activated
                                          ,QC_created_by
                                          ,QC_created_Time
                                          ,QC_updated_by
                                          ,QC_Updated_Time
                                      FROM ISI_Quality_Check";

                dataSet = DataHelper.ExecuteDataSet(connection,
                                                    sqlText,
                                                    CommandType.Text,
                                                    null,
                                                    "ISI_Quality_Check");

            }
            return dataSet.Tables[0];
        }


        #region Save data
        public int SaveMastertoDB(DataTable dt, string Tcode)
        {
            this._lastError3 = "";
            StringBuilder sb = new StringBuilder();

            foreach (DataRow drr in dt.Rows)
            {
                if (drr.RowState == DataRowState.Added)
                {
                    drr["QC_created_by"] = this._userID;
                    drr["QC_updated_by"] = this._userID;
                }
                if (drr.RowState == DataRowState.Modified)
                {
                    drr["QC_updated_by"] = this._userID;
                }

            }

            try
            {
                using (System.Transactions.TransactionScope scope = new TransactionScope())
                {
                    using (System.Data.SqlClient.SqlConnection connect = new System.Data.SqlClient.SqlConnection(_connStr))
                    {
                        connect.Open();

                        new ISI_Quality_Check(connect).UpdateRecord(dt);

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
                this._lastError3 = sb.ToString();
                return -1;
            }
        }

        #endregion
        #region properties

        public string LastError3
        {
            get { return _lastError3; }
            set { _lastError3 = value; }
        }
        #endregion

    }
    public class SqlMasterManegerDEF
    {
        string _connStr = "";
        string _userID = "";
        string _lastError4 = "";

        public SqlMasterManegerDEF(string connStr, string userID)
        {
            this._connStr = connStr;
            this._userID = userID;
        }

        //        /****** Script for SelectTopNRows command from SSMS  ******/
        //SELECT TOP (1000) [Def_ID]
        //      ,[Def_Desc]
        //      ,[Def_Remark]
        //      ,[Def_Activated]
        //      ,[Def_created_Time]
        //      ,[Def_created_by]
        //      ,[Def_updated_by]
        //      ,[Def_updated_Time]
        //  FROM [ISIDB].[dbo].[ISI_Defect]

        public DataTable GetISI_DefectList()
        {
            DataSet dataSet = null;

            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();

                string sqlText = @"SELECT Def_ID
                                          ,Def_Desc
                                          ,Def_Remark
                                          ,Def_Activated
                                          ,Def_created_by
                                          ,Def_created_Time
                                          ,Def_updated_by
                                          ,Def_updated_Time
                                      FROM ISI_Defect";

                dataSet = DataHelper.ExecuteDataSet(connection,
                                                    sqlText,
                                                    CommandType.Text,
                                                    null,
                                                    "ISI_Defect");

            }
            return dataSet.Tables[0];
        }


        #region Save data
        public int SaveMastertoDB(DataTable dt, string Tcode)
        {
            this._lastError4 = "";
            StringBuilder sb = new StringBuilder();

            foreach (DataRow drr in dt.Rows)
            {
                if (drr.RowState == DataRowState.Added)
                {
                    drr["Def_created_by"] = this._userID;
                    drr["Def_updated_by"] = this._userID;
                }
                if (drr.RowState == DataRowState.Modified)
                {
                    drr["Def_updated_by"] = this._userID;
                }

            }

            try
            {
                using (System.Transactions.TransactionScope scope = new TransactionScope())
                {
                    using (System.Data.SqlClient.SqlConnection connect = new System.Data.SqlClient.SqlConnection(_connStr))
                    {
                        connect.Open();

                        new ISI_Defect(connect).UpdateRecord(dt);

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
                this._lastError4 = sb.ToString();
                return -1;
            }
        }

        #endregion
        #region properties

        public string LastError4
        {
            get { return _lastError4; }
            set { _lastError4 = value; }
        }
        #endregion

    }
    public class SqlMasterManegerISO
    {
        string _connStr = "";
        string _userID = "";
        string _lastError5 = "";

        public SqlMasterManegerISO(string connStr, string userID)
        {
            this._connStr = connStr;
            this._userID = userID;
        }

        //       /****** Script for SelectTopNRows command from SSMS  ******/
        //SELECT TOP (1000) [ISO_ID]
        //      ,[ISO_Desc]
        //      ,[ISO_TCODE]
        //      ,[ISO_NO]
        //      ,[ISO_created_by]
        //      ,[ISO_created_Time]
        //      ,[ISO_updated_by]
        //      ,[ISO_updated_Time]
        //  FROM [ISIDB].[dbo].[ISI_ISO]

        public DataTable GetISI_ISOList()
        {
            DataSet dataSet = null;

            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();

                string sqlText = @"SELECT ISO_ID
                                          ,ISO_Desc
                                          ,ISO_TCODE
                                          ,ISO_NO
                                          ,ISO_created_by
                                          ,ISO_created_Time
                                          ,ISO_updated_by
                                          ,ISO_updated_Time
                                          ,ISO_Issused_Date
                                          ,ISO_Effective_Date
                                      FROM ISI_ISO";

                dataSet = DataHelper.ExecuteDataSet(connection,
                                                    sqlText,
                                                    CommandType.Text,
                                                    null,
                                                    "ISI_ISO");

            }
            return dataSet.Tables[0];
        }


        #region Save data
        public int SaveMastertoDB(DataTable dt, string Tcode)
        {
            this._lastError5 = "";
            StringBuilder sb = new StringBuilder();

            foreach (DataRow drr in dt.Rows)
            {
                if (drr.RowState == DataRowState.Added)
                {
                    drr["ISO_created_by"] = this._userID;
                    drr["ISO_updated_by"] = this._userID;
                }
                if (drr.RowState == DataRowState.Modified)
                {
                    drr["ISO_updated_by"] = this._userID;
                }

            }

            try
            {
                using (System.Transactions.TransactionScope scope = new TransactionScope())
                {
                    using (System.Data.SqlClient.SqlConnection connect = new System.Data.SqlClient.SqlConnection(_connStr))
                    {
                        connect.Open();

                        new ISI_ISO(connect).UpdateRecord(dt);

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
                this._lastError5 = sb.ToString();
                return -1;
            }
        }

        #endregion
        #region properties

        public string LastError5
        {
            get { return _lastError5; }
            set { _lastError5 = value; }
        }
        #endregion

    }
    public class SqlMasterManegerStatus
    {
        string _connStr = "";
        string _userID = "";
        string _lastError6 = "";

        public SqlMasterManegerStatus(string connStr, string userID)
        {
            this._connStr = connStr;
            this._userID = userID;
        }
        //        /****** Script for SelectTopNRows command from SSMS  ******/
        //SELECT TOP (1000) [Status_ID]
        //      ,[Status_Desc]
        //      ,[Status_Remark]
        //      ,[Status_Activated]
        //      ,[Status_created_by]
        //      ,[Status_created_Time]
        //      ,[Status_updated_by]
        //      ,[Status_updated_Time]
        //  FROM [ISIDB].[dbo].[ISI_Quality_Control_Status]

        public DataTable GetISI_StatusList()
        {
            DataSet dataSet = null;

            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();

                string sqlText = @"SELECT Status_ID
                                          ,Status_Desc
                                          ,Status_Remark
                                          ,Status_Activated
                                          ,Status_created_by
                                          ,Status_created_Time
                                          ,Status_updated_by
                                          ,Status_updated_Time
                                      FROM ISI_Quality_Control_Status";

                dataSet = DataHelper.ExecuteDataSet(connection,
                                                    sqlText,
                                                    CommandType.Text,
                                                    null,
                                                    "ISI_Quality_Control_Status");

            }
            return dataSet.Tables[0];
        }


        #region Save data
        public int SaveMastertoDB(DataTable dt, string Tcode)
        {
            this._lastError6 = "";
            StringBuilder sb = new StringBuilder();

            foreach (DataRow drr in dt.Rows)
            {
                if (drr.RowState == DataRowState.Added)
                {
                    drr["Status_created_by"] = this._userID;
                    drr["Status_updated_by"] = this._userID;
                }
                if (drr.RowState == DataRowState.Modified)
                {
                    drr["Status_updated_by"] = this._userID;
                }

            }

            try
            {
                using (System.Transactions.TransactionScope scope = new TransactionScope())
                {
                    using (System.Data.SqlClient.SqlConnection connect = new System.Data.SqlClient.SqlConnection(_connStr))
                    {
                        connect.Open();

                        new ISI_Quality_Control_Status(connect).UpdateRecord(dt);

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
                this._lastError6 = sb.ToString();
                return -1;
            }
        }

        #endregion
        #region properties

        public string LastError6
        {
            get { return _lastError6; }
            set { _lastError6 = value; }
        }
        #endregion


    }


}



