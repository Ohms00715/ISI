using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;
namespace ISI.Data
{
    public partial class ISI_LOGIN
    {
        private SqlConnection _connection;
        private SqlDataAdapter _adapter;
        public ISI_LOGIN(SqlConnection connection)
        {
            _connection = connection;
        }
        private SqlDataAdapter Adapter
        {
            get
            {
                if (_adapter == null)
                    InitAdapter();
                return _adapter;
            }
        }
        private void InitAdapter()
        {
            _adapter = new SqlDataAdapter();
            DataTableMapping tableMapping = new DataTableMapping();
            tableMapping.SourceTable = "Table";
            tableMapping.DataSetTable = "ISI_Login";
            tableMapping.ColumnMappings.Add("ISI_LOGIN_ID", "ISI_LOGIN_ID");
            tableMapping.ColumnMappings.Add("ISI_LOGIN_Password", "ISI_LOGIN_Password");
            tableMapping.ColumnMappings.Add("ISI_LOGIN_Address", "ISI_LOGIN_Address");
            tableMapping.ColumnMappings.Add("ISI_LOGIN_Email", "ISI_LOGIN_Email");
            tableMapping.ColumnMappings.Add("ISI_LOGIN_Telephone", "ISI_LOGIN_Telephone");
            tableMapping.ColumnMappings.Add("ISI_National_ID", "ISI_National_ID");
            tableMapping.ColumnMappings.Add("Created_By", "Created_By");
            tableMapping.ColumnMappings.Add("Created_Time", "Created_Time");
            tableMapping.ColumnMappings.Add("Updated_by", "Updated_by");
            tableMapping.ColumnMappings.Add("Updated_Time", "Updated_Time");

                                      //          SELECT  ISI_LOGIN_ID
                                      //    ,ISI_LOGIN_Password
                                      //    ,ISI_LOGIN_FName
                                      //    ,ISI_LName
                                      //    ,ISI_LOGIN_Address
                                      //    ,ISI_LOGIN_Email
                                      //    ,ISI_LOGIN_Telephone
                                      //    ,ISI_National_ID
                                      //    ,Created_By
                                      //    ,Created_Time
                                      //    ,Updated_by
                                      //    ,Updated_Time
                                      //FROM ISI_Login
            Adapter.TableMappings.Add(tableMapping);
            _adapter.DeleteCommand = new SqlCommand();
            _adapter.DeleteCommand.Connection = _connection;
            _adapter.DeleteCommand.CommandText = " DELETE FROM ISI_Login   WHERE ISI_LOGIN_ID = @originalISI_LOGIN_ID";
            _adapter.DeleteCommand.CommandType = CommandType.Text;
            _adapter.DeleteCommand.Parameters.Add(new SqlParameter("@originalISI_LOGIN_ID", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ISI_LOGIN_ID", DataRowVersion.Original, false, null, "", "", ""));
            _adapter.InsertCommand = new SqlCommand();
            _adapter.InsertCommand.Connection = _connection;

            _adapter.InsertCommand.CommandText = @"INSERT INTO  ISI_Login ( ISI_LOGIN_ID,ISI_LOGIN_Password,ISI_LOGIN_FName,ISI_LName,ISI_LOGIN_Address,ISI_LOGIN_Email,ISI_LOGIN_Telephone,ISI_National_ID,Created_By,Created_Time,Updated_by,Updated_Time ) VALUES
                                                                                ( @ISI_LOGIN_ID,@ISI_LOGIN_Password,@ISI_LOGIN_FName,@ISI_LName,@ISI_LOGIN_Address,@ISI_LOGIN_Email,@ISI_LOGIN_Telephone,@ISI_National_ID,@Created_By,GetDate(),@Updated_by,GetDate() ) ";
            _adapter.InsertCommand.CommandType = CommandType.Text;

            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@ISI_LOGIN_ID", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ISI_LOGIN_ID", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@ISI_LOGIN_Password", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ISI_LOGIN_Password", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@ISI_LOGIN_FName", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ISI_LOGIN_FName", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@ISI_LName", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ISI_LName", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@ISI_LOGIN_Address", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ISI_LOGIN_Address", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@ISI_LOGIN_Email", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ISI_LOGIN_Email", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@ISI_LOGIN_Telephone", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ISI_LOGIN_Telephone", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@ISI_National_ID", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ISI_National_ID", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Created_By", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Created_By", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Updated_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Updated_by", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand = new SqlCommand();
            _adapter.UpdateCommand.Connection = _connection;
            _adapter.UpdateCommand.CommandText = @"UPDATE  ISI_Login SET ISI_LOGIN_ID=@ISI_LOGIN_ID,ISI_LOGIN_Password=@ISI_LOGIN_Password,ISI_LOGIN_FName=@ISI_LOGIN_FName,ISI_LName=@ISI_LName,ISI_LOGIN_Address=@ISI_LOGIN_Address,ISI_LOGIN_Email=@ISI_LOGIN_Email,ISI_LOGIN_Telephone=@ISI_LOGIN_Telephone,ISI_National_ID=@ISI_National_ID,Updated_by=@Updated_by,Updated_Time=GetDate()  
                                                WHERE ISI_LOGIN_ID = @originalISI_LOGIN_ID;
                                                SELECT * FROM ISI_Login WHERE ISI_LOGIN_ID = @originalISI_LOGIN_ID";
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ISI_LOGIN_ID", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ISI_LOGIN_ID", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ISI_LOGIN_Password", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ISI_LOGIN_Password", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ISI_LOGIN_FName", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ISI_LOGIN_FName", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ISI_LName", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ISI_LName", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ISI_LOGIN_Address", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ISI_LOGIN_Address", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ISI_LOGIN_Email", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ISI_LOGIN_Email", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ISI_LOGIN_Telephone", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ISI_LOGIN_Telephone", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ISI_National_ID", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ISI_National_ID", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Updated_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Updated_by", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@originalISI_LOGIN_ID", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ISI_LOGIN_ID", DataRowVersion.Original, false, null, "", "", ""));
        }
        public int DeleteRecord(int Key)
        {
            SqlCommand command = new SqlCommand("DELETE FROM ISI_Login WHERE ISI_LOGIN_ID = @Key ", this._connection);
            command.Parameters.Add(new SqlParameter("@Key", Key));
            return command.ExecuteNonQuery();
        }
        public int UpdateRecord(DataTable dataTable)
        {
            return Adapter.Update(dataTable);
        }
        public int UpdateRecord(params DataRow[] dataRows)
        {
            return Adapter.Update(dataRows);
        }
    }

    public partial class ISI_Form
    {
        private SqlConnection _connection;
        private SqlDataAdapter _adapter;
        public ISI_Form(SqlConnection connection)
        {
            _connection = connection;
        }
        private SqlDataAdapter Adapter
        {
            get
            {
                if (_adapter == null)
                    InitAdapter();
                return _adapter;
            }
        }
        private void InitAdapter()
        {
            _adapter = new SqlDataAdapter();
            DataTableMapping tableMapping = new DataTableMapping();
            tableMapping.SourceTable = "Table";
            tableMapping.DataSetTable = "ISI_Form";
            tableMapping.ColumnMappings.Add("ISI_Form_Key", "ISI_Form_Key");
            tableMapping.ColumnMappings.Add("ISI_Form_Desc", "ISI_Form_Desc");
            tableMapping.ColumnMappings.Add("ISI_Form_Group", "ISI_Form_Group");
            tableMapping.ColumnMappings.Add("Activated", "Activated");
            tableMapping.ColumnMappings.Add("Created_By", "Created_By");
            tableMapping.ColumnMappings.Add("Created_Time", "Created_Time");
            tableMapping.ColumnMappings.Add("Updated_by", "Updated_by");
            tableMapping.ColumnMappings.Add("Updated_Time", "Updated_Time");

            ////        ISI_Form_Key
            //                                          ,ISI_Form_Desc
            //                                          ,ISI_Form_Group
            //                                          ,Activated
            //                                          ,Created_by
            //                                          ,Created_time
            //                                          ,Updated_by
            //                                          ,Updated_time
            //                                      FROM ISI_Form
            Adapter.TableMappings.Add(tableMapping);
            _adapter.DeleteCommand = new SqlCommand();
            _adapter.DeleteCommand.Connection = _connection;
            _adapter.DeleteCommand.CommandText = " DELETE FROM ISI_Form   WHERE ISI_Form_Key = @originalISI_Form_Key";
            _adapter.DeleteCommand.CommandType = CommandType.Text;
            _adapter.DeleteCommand.Parameters.Add(new SqlParameter("@originalISI_Form_Key", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ISI_Form_Key", DataRowVersion.Original, false, null, "", "", ""));
            _adapter.InsertCommand = new SqlCommand();
            _adapter.InsertCommand.Connection = _connection;

            _adapter.InsertCommand.CommandText = @"INSERT INTO  ISI_Form ( ISI_Form_Key,ISI_Form_Desc,ISI_Form_Group,Activated,Created_By,Created_Time,Updated_by,Updated_Time ) VALUES
                                                                                ( @ISI_Form_Key,@ISI_Form_Desc,@ISI_Form_Group,@Activated,@Created_By,GetDate(),@Updated_by,GetDate() ) ";
            _adapter.InsertCommand.CommandType = CommandType.Text;

            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@ISI_Form_Key", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ISI_Form_Key", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@ISI_Form_Desc", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ISI_Form_Desc", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@ISI_Form_Group", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ISI_Form_Group", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Activated", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "Activated", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Created_By", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Created_By", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Updated_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Updated_by", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand = new SqlCommand();
            _adapter.UpdateCommand.Connection = _connection;
            _adapter.UpdateCommand.CommandText = @"UPDATE  ISI_Form SET ISI_Form_Key=@ISI_Form_Key,ISI_Form_Desc=@ISI_Form_Desc,ISI_Form_Group=@ISI_Form_Group,Activated=@Activated,Updated_by=@Updated_by,Updated_Time=GetDate()  
                                                WHERE ISI_Form_Key = @originalISI_Form_Key;
                                                SELECT * FROM ISI_Form WHERE ISI_Form_Key = @originalISI_Form_Key";
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ISI_Form_Key", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ISI_Form_Key", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ISI_Form_Desc", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ISI_Form_Desc", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ISI_Form_Group", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ISI_Form_Group", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Activated", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "Activated", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Updated_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Updated_by", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@originalISI_Form_Key", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ISI_Form_Key", DataRowVersion.Original, false, null, "", "", ""));
        }
        public int DeleteRecord(int Key)
        {
            SqlCommand command = new SqlCommand("DELETE FROM ISI_Form WHERE ISI_Form_Key = @Key ", this._connection);
            command.Parameters.Add(new SqlParameter("@Key", Key));
            return command.ExecuteNonQuery();
        }
        public int UpdateRecord(DataTable dataTable)
        {
            return Adapter.Update(dataTable);
        }
        public int UpdateRecord(params DataRow[] dataRows)
        {
            return Adapter.Update(dataRows);
        }
    }


    public partial class ISI_Authorize
    {
        private SqlConnection _connection;
        private SqlDataAdapter _adapter;
        public ISI_Authorize(SqlConnection connection)
        {
            _connection = connection;
        }
        private SqlDataAdapter Adapter
        {
            get
            {
                if (_adapter == null)
                    InitAdapter();
                return _adapter;
            }
        }
        private void InitAdapter()
        {
            _adapter = new SqlDataAdapter();
            DataTableMapping tableMapping = new DataTableMapping();
            tableMapping.SourceTable = "Table";
            tableMapping.DataSetTable = "ISI_Authorize";
            tableMapping.ColumnMappings.Add("ISI_authorize_Key", "ISI_authorize_Key");
            tableMapping.ColumnMappings.Add("ISI_authorize_ID", "ISI_authorize_ID");
            tableMapping.ColumnMappings.Add("ISI_authorize_TCode", "ISI_authorize_TCode");
            tableMapping.ColumnMappings.Add("ISI_authorize_Visible", "ISI_authorize_Visible");
            tableMapping.ColumnMappings.Add("ISI_authorize_Update", "ISI_authorize_Update");
            tableMapping.ColumnMappings.Add("ISI_authorize_Delect", "ISI_authorize_Delect");
            tableMapping.ColumnMappings.Add("ISI_authorize_ReadOnly", "ISI_authorize_ReadOnly");
            tableMapping.ColumnMappings.Add("Created_By", "Created_By");
            tableMapping.ColumnMappings.Add("Created_Time", "Created_Time");
            tableMapping.ColumnMappings.Add("Updated_by", "Updated_by");
            tableMapping.ColumnMappings.Add("Updated_Time", "Updated_Time");

            //////       SELECT  ISI_authorize_ID
            //                                  
            //                                  ,ISI_authorize_TCode
            //                                  ,ISI_authorize_Visible
            //                                  ,ISI_authorize_Update
            //                                  ,ISI_authorize_Delect
            //                                  ,ISI_authorize_ReadOnly
          
            //                                  ,Created_by
            //                                  ,Created_time
            //                                  ,Updated_by
            //                                  ,Updated_time
            //                              FROM ISI_Authorize
            Adapter.TableMappings.Add(tableMapping);
            _adapter.DeleteCommand = new SqlCommand();
            _adapter.DeleteCommand.Connection = _connection;
            _adapter.DeleteCommand.CommandText = " DELETE FROM ISI_Authorize   WHERE ISI_authorize_Key = @originalISI_authorize_Key";
            _adapter.DeleteCommand.CommandType = CommandType.Text;
            _adapter.DeleteCommand.Parameters.Add(new SqlParameter("@originalISI_authorize_Key", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ISI_authorize_Key", DataRowVersion.Original, false, null, "", "", ""));
            _adapter.InsertCommand = new SqlCommand();
            _adapter.InsertCommand.Connection = _connection;

            _adapter.InsertCommand.CommandText = @"INSERT INTO  ISI_Authorize ( ISI_authorize_ID,ISI_authorize_TCode,ISI_authorize_Visible,ISI_authorize_Update,ISI_authorize_Delect,ISI_authorize_ReadOnly,Created_By,Created_Time,Updated_by,Updated_Time ) VALUES
                                                                                ( @ISI_authorize_ID,@ISI_authorize_TCode,@ISI_authorize_Visible,@ISI_authorize_Update,@ISI_authorize_Delect,@ISI_authorize_ReadOnly,@Created_By,GetDate(),@Updated_by,GetDate() ) ";
            _adapter.InsertCommand.CommandType = CommandType.Text;

            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@ISI_authorize_ID", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ISI_authorize_ID", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@ISI_authorize_TCode", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ISI_authorize_TCode", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@ISI_authorize_Visible", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "ISI_authorize_Visible", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@ISI_authorize_Update", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "ISI_authorize_Update", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@ISI_authorize_Delect", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "ISI_authorize_Delect", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@ISI_authorize_ReadOnly", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "ISI_authorize_ReadOnly", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Created_By", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Created_By", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Updated_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Updated_by", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand = new SqlCommand();
            _adapter.UpdateCommand.Connection = _connection;
            _adapter.UpdateCommand.CommandText = @"UPDATE  ISI_Authorize SET ISI_authorize_ID=@ISI_authorize_ID,ISI_authorize_TCode=@ISI_authorize_TCode,ISI_authorize_Visible=@ISI_authorize_Visible,ISI_authorize_Update=@ISI_authorize_Update,ISI_authorize_Delect=@ISI_authorize_Delect,ISI_authorize_ReadOnly=@ISI_authorize_ReadOnly,Updated_by=@Updated_by,Updated_Time=GetDate()  
                                                WHERE ISI_authorize_Key = @originalISI_authorize_Key;
                                                SELECT * FROM ISI_Authorize WHERE ISI_authorize_Key = @originalISI_authorize_Key";
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ISI_authorize_ID", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ISI_authorize_ID", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ISI_authorize_TCode", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ISI_authorize_TCode", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ISI_authorize_Visible", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "ISI_authorize_Visible", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ISI_authorize_Update", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "ISI_authorize_Update", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ISI_authorize_Delect", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "ISI_authorize_Delect", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ISI_authorize_ReadOnly", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "ISI_authorize_ReadOnly", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Created_By", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Created_By", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Updated_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Updated_by", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@originalISI_authorize_Key", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ISI_authorize_Key", DataRowVersion.Original, false, null, "", "", ""));
        }
        public int DeleteRecord(int Key)
        {
            SqlCommand command = new SqlCommand("DELETE FROM ISI_Authorize WHERE ISI_authorize_Key = @Key ", this._connection);
            command.Parameters.Add(new SqlParameter("@Key", Key));
            return command.ExecuteNonQuery();
        }
        public int UpdateRecord(DataTable dataTable)
        {
            return Adapter.Update(dataTable);
        }
        public int UpdateRecord(params DataRow[] dataRows)
        {
            return Adapter.Update(dataRows);
        }
    }

}
