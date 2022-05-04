using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;
namespace ISI.Data
{
    public partial class ISI_Quality_Check
    {
        private SqlConnection _connection;
        private SqlDataAdapter _adapter;
        public ISI_Quality_Check(SqlConnection connection)
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
            tableMapping.DataSetTable = "ISI_Quality_Check";
            tableMapping.ColumnMappings.Add("QC_ID", "QC_ID");
            tableMapping.ColumnMappings.Add("QC_First_Name", "QC_First_Name");
            tableMapping.ColumnMappings.Add("QC_Last_Name", "QC_Last_Name");
            tableMapping.ColumnMappings.Add("QC_Department", "QC_Department");
            tableMapping.ColumnMappings.Add("QC_Activated", "QC_Activated");
            tableMapping.ColumnMappings.Add("QC_For_Create", "QC_For_Create");
            tableMapping.ColumnMappings.Add("QC_For_Appproved", "QC_For_Appproved");        
            tableMapping.ColumnMappings.Add("QC_created_by", "QC_created_by");
            tableMapping.ColumnMappings.Add("QC_created_Time", "QC_created_Time");
            tableMapping.ColumnMappings.Add("QC_updated_by", "QC_updated_by");
            tableMapping.ColumnMappings.Add("QC_updated_Time", "QC_updated_Time");

                                                                //            /****** Script for SelectTopNRows command from SSMS  ******/
                                                                //SELECT TOP (1000) [QC_ID]
                                                                //      ,[QC_First_Name]
                                                                //      ,[QC_Last_Name]
                                                                //      ,[QC_Department]
                                                                //      ,[QC_Activated]
                                                                //      ,[QC_For_Create]
                                                                //      ,[QC_For_Appproved]
                                                                //      ,[QC_created_Time]
                                                                //      ,[QC_created_by]
                                                                //      ,[QC_updated_by]
                                                                //      ,[QC_updated_Time]
                                                                //  FROM [ISIDB].[dbo].[ISI_Quality_Check]
            Adapter.TableMappings.Add(tableMapping);
            _adapter.DeleteCommand = new SqlCommand();
            _adapter.DeleteCommand.Connection = _connection;
            _adapter.DeleteCommand.CommandText = " DELETE FROM ISI_Quality_Check   WHERE QC_ID = @originalQC_ID";
            _adapter.DeleteCommand.CommandType = CommandType.Text;
            _adapter.DeleteCommand.Parameters.Add(new SqlParameter("@originalQC_ID", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "QC_ID", DataRowVersion.Original, false, null, "", "", ""));
            _adapter.InsertCommand = new SqlCommand();
            _adapter.InsertCommand.Connection = _connection;

            _adapter.InsertCommand.CommandText = @"INSERT INTO  ISI_Quality_Check ( QC_ID,QC_First_Name,QC_Last_Name,QC_Department,QC_Activated,QC_For_Create,QC_For_Appproved,QC_created_by,QC_created_Time,QC_updated_by,QC_updated_Time ) VALUES
                                                                                ( @QC_ID,@QC_First_Name,@QC_Last_Name,@QC_Department,@QC_Activated,@QC_For_Create,@QC_For_Appproved,@QC_created_by,GetDate(),@QC_updated_by,GetDate() ) ";
            _adapter.InsertCommand.CommandType = CommandType.Text;

            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@QC_ID", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "QC_ID", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@QC_First_Name", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "QC_First_Name", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@QC_Last_Name", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "QC_Last_Name", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@QC_Department", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "QC_Department", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@QC_Activated", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "QC_Activated", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@QC_For_Create", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "QC_For_Create", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@QC_For_Appproved", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "QC_For_Appproved", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@QC_created_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "QC_created_by", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@QC_updated_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "QC_updated_by", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand = new SqlCommand();
            _adapter.UpdateCommand.Connection = _connection;
            _adapter.UpdateCommand.CommandText = @"UPDATE  ISI_Quality_Check SET QC_ID=@QC_ID,QC_First_Name=@QC_First_Name,QC_Last_Name=@QC_Last_Name,QC_Department=@QC_Department,QC_Activated=@QC_Activated,QC_For_Create=@QC_For_Create,QC_For_Appproved=@QC_For_Appproved,QC_updated_by=@QC_updated_by,QC_updated_Time=GetDate()  
                                                WHERE QC_ID = @originalQC_ID;
                                                SELECT * FROM ISI_Quality_Check WHERE QC_ID = @originalQC_ID";
            _adapter.UpdateCommand.CommandType = CommandType.Text;
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@QC_ID", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "QC_ID", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@QC_First_Name", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "QC_First_Name", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@QC_Last_Name", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "QC_Last_Name", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@QC_Department", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "QC_Department", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@QC_Activated", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "QC_Activated", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@QC_For_Create", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "QC_For_Create", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@QC_For_Appproved", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "QC_For_Appproved", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@QC_created_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "QC_created_by", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@QC_updated_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "QC_updated_by", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@originalQC_ID", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "QC_ID", DataRowVersion.Original, false, null, "", "", ""));
        }
        public int DeleteRecord(int Key)
        {
            SqlCommand command = new SqlCommand("DELETE FROM ISI_Quality_Check WHERE QC_ID = @Key ", this._connection);
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
