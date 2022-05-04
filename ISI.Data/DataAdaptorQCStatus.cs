using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;
namespace ISI.Data
{
    public partial class ISI_Quality_Control_Status
    {
        private SqlConnection _connection;
        private SqlDataAdapter _adapter;
        public ISI_Quality_Control_Status(SqlConnection connection)
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
            tableMapping.DataSetTable = "ISI_Quality_Control_Status";
            tableMapping.ColumnMappings.Add("Status_ID", "Status_ID");
            tableMapping.ColumnMappings.Add("Status_Desc", "Status_Desc");
            tableMapping.ColumnMappings.Add("Status_Remark", "Status_Remark");
            tableMapping.ColumnMappings.Add("Status_Activated", "Status_Activated");
            tableMapping.ColumnMappings.Add("Status_created_by", "Status_created_by");
            tableMapping.ColumnMappings.Add("Status_created_Time", "Status_created_Time");
            tableMapping.ColumnMappings.Add("Status_updated_by", "Status_updated_by");
            tableMapping.ColumnMappings.Add("Status_updated_Time", "Status_updated_Time");


                                        //           /****** Script for SelectTopNRows command from SSMS  ******/
                                        //SELECT TOP (1000) [Status_ID]
                                        //      ,[Status_Desc]
                                        //      ,[Status_Remark]
                                        //      ,[Status_Activated]
                                        //      ,[Status_created_by]
                                        //      ,[Status_created_Time]
                                        //      ,[Status_updated_by]
                                        //      ,[Status_updated_Time]
                                        //  FROM [ISIDB].[dbo].[ISI_Quality_Control_Status]
            Adapter.TableMappings.Add(tableMapping);
            _adapter.DeleteCommand = new SqlCommand();
            _adapter.DeleteCommand.Connection = _connection;
            _adapter.DeleteCommand.CommandText = " DELETE FROM ISI_Quality_Control_Status   WHERE Status_ID = @originalStatus_ID";
            _adapter.DeleteCommand.CommandType = CommandType.Text;
            _adapter.DeleteCommand.Parameters.Add(new SqlParameter("@originalStatus_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Status_ID", DataRowVersion.Original, false, null, "", "", ""));
            _adapter.InsertCommand = new SqlCommand();
            _adapter.InsertCommand.Connection = _connection;

            _adapter.InsertCommand.CommandText = @"INSERT INTO  ISI_Quality_Control_Status ( Status_ID,Status_Desc,Status_Remark,Status_Activated,Status_created_by,Status_created_Time,Status_updated_by,Status_updated_Time ) VALUES
                                                                                ( @Status_ID,@Status_Desc,@Status_Remark,@Status_Activated,@Status_created_by,GetDate(),@Status_updated_by,GetDate() ) ";
            _adapter.InsertCommand.CommandType = CommandType.Text;

            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Status_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Status_ID", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Status_Desc", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Status_Desc", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Status_Remark", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Status_Remark", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Status_Activated", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "Status_Activated", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Status_created_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Status_created_by", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Status_updated_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Status_updated_by", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand = new SqlCommand();
            _adapter.UpdateCommand.Connection = _connection;
            _adapter.UpdateCommand.CommandText = @"UPDATE  ISI_Quality_Control_Status SET Status_ID=@Status_ID,Status_Desc=@Status_Desc,Status_Remark=@Status_Remark,Status_Activated=@Status_Activated,Status_updated_by=@Status_updated_by,Status_updated_Time=GetDate()  
                                                WHERE Status_ID = @originalStatus_ID;
                                                SELECT * FROM ISI_Quality_Control_Status WHERE Status_ID = @originalStatus_ID";
            _adapter.UpdateCommand.CommandType = CommandType.Text;
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Status_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Status_ID", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Status_Desc", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Status_Desc", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Status_Remark", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Status_Remark", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Status_Activated", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "Status_Activated", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Status_created_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Status_created_by", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Status_updated_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Status_updated_by", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@originalStatus_ID", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Status_ID", DataRowVersion.Original, false, null, "", "", ""));
        }
        public int DeleteRecord(int Key)
        {
            SqlCommand command = new SqlCommand("DELETE FROM ISI_Quality_Control_Status WHERE Status_ID = @Key ", this._connection);
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
