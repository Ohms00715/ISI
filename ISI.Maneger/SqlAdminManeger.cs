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
   public class SqlAdminManeger
    {
          
        string _connStr = "";
        string _userID = "";
        string _lastError = "";
        public string _tabbleNameAuthorize = "ISI_Authorize";

        public SqlAdminManeger(string connStr, string userID)
        {
            this._connStr = connStr;
            this._userID = userID;
        }
        public DataTable GetISI_LOGINList()
        {
            DataSet dataSet = null;

            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();

                string sqlText = @"SELECT ISI_LOGIN_ID
                                          ,ISI_LOGIN_Password
                                          ,ISI_LOGIN_FName
                                          ,ISI_LName
                                          ,ISI_LOGIN_Address
                                          ,ISI_LOGIN_Email
                                          ,ISI_LOGIN_Telephone
                                          ,ISI_National_ID
                                          ,Created_By
                                          ,Created_Time
                                          ,Updated_by
                                          ,Updated_Time
                                      FROM ISI_Login";

                dataSet = DataHelper.ExecuteDataSet(connection,
                                                    sqlText,
                                                    CommandType.Text,
                                                    null,
                                                    "ISI_Login");

            }
            return dataSet.Tables[0];
        }
        public DataTable GetISI_LOGINRegister()
        {
            DataSet dataSet = null;

            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();

                string sqlText = @"SELECT ISI_LOGIN_ID
                                          ,ISI_LOGIN_Password
                                          ,ISI_LOGIN_FName
                                          ,ISI_LName
                                          ,ISI_LOGIN_Address
                                          ,ISI_LOGIN_Email
                                          ,ISI_LOGIN_Telephone
                                          ,ISI_National_ID
                                          ,Created_By
                                          ,Created_Time
                                          ,Updated_by
                                          ,Updated_Time
                                      FROM ISI_Login WHERE ISI_LOGIN_ID = '0'";

                dataSet = DataHelper.ExecuteDataSet(connection,
                                                    sqlText,
                                                    CommandType.Text,
                                                    null,
                                                    "ISI_Login");

            }
            return dataSet.Tables[0];
        }
        #region Save data
        public int SaveMastertoDB22(DataTable dt)
        {
            this.LastError22 = "";
            StringBuilder sb = new StringBuilder();

            foreach (DataRow drr in dt.Rows)
            {
                if (drr.RowState == DataRowState.Added)
                {
                    drr["Created_By"] = this._userID;
                    drr["Updated_by"] = this._userID;
                }
                if (drr.RowState == DataRowState.Modified)
                {
                    drr["Updated_by"] = this._userID;
                }

            }

            try
            {
                using (System.Transactions.TransactionScope scope = new TransactionScope())
                {
                    using (System.Data.SqlClient.SqlConnection connect = new System.Data.SqlClient.SqlConnection(_connStr))
                    {
                        connect.Open();

                        new ISI_LOGIN(connect).UpdateRecord(dt);

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
                this.LastError22 = sb.ToString();
                return -1;
            }
        }


        #endregion
        #region properties

        public string LastError22
        {
            get { return _lastError; }
            set { _lastError = value; }
        }
        #endregion

       
        public DataTable GetISI_FormList()
        {
            DataSet dataSet = null;

            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();

                           string sqlText = @"SELECT  ISI_Form_Key
                                                      ,ISI_Form_Desc
                                                      ,ISI_Form_Group
                                                      ,Activated
                                                      ,Created_by
                                                      ,Created_time
                                                      ,Updated_by
                                                      ,Updated_time
                                                  FROM ISI_Form";

                dataSet = DataHelper.ExecuteDataSet(connection,
                                                    sqlText,
                                                    CommandType.Text,
                                                    null,
                                                    "ISI_Form");

            }
            return dataSet.Tables[0];
        }
        #region Save data
        public int SaveMastertoDB33(DataTable dt)
        {
            this.LastError33 = "";
            StringBuilder sb = new StringBuilder();

            foreach (DataRow drr in dt.Rows)
            {
                if (drr.RowState == DataRowState.Added)
                {
                    drr["Created_by"] = this._userID;
                    drr["Updated_by"] = this._userID;
                }
                if (drr.RowState == DataRowState.Modified)
                {
                    drr["Updated_by"] = this._userID;
                }

            }

            try
            {
                using (System.Transactions.TransactionScope scope = new TransactionScope())
                {
                    using (System.Data.SqlClient.SqlConnection connect = new System.Data.SqlClient.SqlConnection(_connStr))
                    {
                        connect.Open();

                        new ISI_Form(connect).UpdateRecord(dt);

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
                this.LastError33 = sb.ToString();
                return -1;
            }
        }


        #endregion
        #region properties

        public string LastError33
        {
            get { return _lastError; }
            set { _lastError = value; }
        }
        #endregion

        public DataTable GetISI_AuthorizeList(string UserAuthorize)
        {
            DataSet dataSet = null;

            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();

                string sqlText = @" SELECT f.ISI_Form_Key as ISI_authorize_TCode
                                            ,f.ISI_Form_Desc
                                            ,f.ISI_Form_Group
                                            ,f.Activated
                                            ,v.ISI_LOGIN_ID
                                            ,v.ISI_LOGIN_Password
                                            ,v.ISI_LOGIN_FName
                                            ,v.ISI_LName
                                            ,v.ISI_LOGIN_Address
                                            ,v.ISI_LOGIN_Email
                                            ,v.ISI_LOGIN_Telephone
                                            ,v.ISI_National_ID
                                            ,@UserAuthorize as ISI_authorize_ID
                                            ,v.ISI_authorize_Visible
                                            ,v.ISI_authorize_Update
                                            ,v.ISI_authorize_Delect
                                            ,v.ISI_authorize_ReadOnly
                                            ,v.Created_by
                                            ,v.Created_time
                                            ,v.Updated_by
                                            ,v.Updated_time
                                            ,v.ISI_authorize_Key
                                            FROM ISI_Form as f               
                                            LEFT OUTER JOIN 
                                            (select a.ISI_authorize_Key,a.ISI_authorize_ID
                                            ,a.ISI_authorize_TCode
                                            ,a.ISI_authorize_Visible
                                            ,a.ISI_authorize_Update
                                            ,a.ISI_authorize_Delect
                                            ,a.ISI_authorize_ReadOnly
                                            ,a.Created_by
                                            ,a.Created_time
                                            ,a.Updated_by
                                            ,l.ISI_LOGIN_ID
                                            ,l.ISI_LOGIN_Password
                                            ,l.ISI_LOGIN_FName
                                            ,l.ISI_LName
                                            ,l.ISI_LOGIN_Address
                                            ,l.ISI_LOGIN_Email
                                            ,l.ISI_LOGIN_Telephone
                                            ,l.ISI_National_ID
                                            ,a.Updated_time from ISI_Authorize as a 
                                            LEFT OUTER JOIN ISI_Login as l ON a.ISI_authorize_ID = l.ISI_LOGIN_ID
                                            WHERE l.ISI_LOGIN_ID = @UserAuthorize )v on v.ISI_authorize_TCode = f.ISI_Form_Key";

                dataSet = DataHelper.ExecuteDataSet(connection,
                                                    sqlText,
                                                    CommandType.Text,
                                                    new SqlParameter[]
                                                    {
                                                        new SqlParameter("@UserAuthorize",UserAuthorize),
                                                    },
                                                    "ISI_Authorize");

            }
            return dataSet.Tables[0];
        }
        
       #region Save data
        public int SaveMastertoDB2222(DataTable dt)
        {
            this.LastError2222 = "";
            StringBuilder sb = new StringBuilder();

            foreach (DataRow drr in dt.Rows)
            {
                if (drr["ISI_authorize_Key"].ToString() == "")
                {
                    drr["Created_by"] = this._userID;
                    drr["Updated_by"] = this._userID;
                    drr.AcceptChanges();
                    drr.SetAdded();
                }
                if (drr.RowState == DataRowState.Modified)
                {
                    drr["Updated_by"] = this._userID;
                }

            }

            try
            {
                using (System.Transactions.TransactionScope scope = new TransactionScope())
                {
                    using (System.Data.SqlClient.SqlConnection connect = new System.Data.SqlClient.SqlConnection(_connStr))
                    {
                        connect.Open();

                        new ISI_Authorize(connect).UpdateRecord(dt);

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
                this.LastError2222 = sb.ToString();
                return -1;
            }
        }


        #endregion
        #region properties

        public string LastError2222
        {
            get { return _lastError; }
            set { _lastError = value; }
        }
        public string TabbleNameAuthorize
        {
            get { return this._tabbleNameAuthorize; }
        }
        #endregion

        #region Get Data Authorized
        public DataSet GetRecoedUserByAppUserCode(string strEmpID)
        {
            DataSet dataSet = null;

            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();

                string sqlText = @" SELECT ISI_authorize_Key
                                      ,ISI_authorize_ID
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
                                  where ISI_authorize_ID = @strEmpID";
                dataSet = DataHelper.ExecuteDataSet(connection,
                                                    sqlText,
                                                    CommandType.Text,
                                                    new SqlParameter[]
                                                    {
                                                        new SqlParameter("@strEmpID",strEmpID),
                                                    },
                                                    this.TabbleNameAuthorize);

            }
            return dataSet;
        }

        #endregion Get Data Authorized
    }
}
