using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;
namespace ISI.Data
{
    public partial class ISI_Defect
    {
        private SqlConnection _connection;
        private SqlDataAdapter _adapter;
        public ISI_Defect(SqlConnection connection)
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
            tableMapping.DataSetTable = "ISI_Defect";
            tableMapping.ColumnMappings.Add("Def_ID", "Def_ID");
            tableMapping.ColumnMappings.Add("Def_Desc", "Def_Desc");
            tableMapping.ColumnMappings.Add("Def_Remark", "Def_Remark");
            tableMapping.ColumnMappings.Add("Def_Activated", "Def_Activated");
            tableMapping.ColumnMappings.Add("Def_created_by", "Def_created_by");
            tableMapping.ColumnMappings.Add("Def_created_Time", "Def_created_Time");
            tableMapping.ColumnMappings.Add("Def_updated_by", "Def_updated_by");
            tableMapping.ColumnMappings.Add("Def_updated_Time", "Def_updated_Time");


                                    //            /****** Script for SelectTopNRows command from SSMS  ******/
                                    //SELECT TOP (1000) [Def_ID]
                                    //      ,[Def_Desc]
                                    //      ,[Def_Remark]
                                    //      ,[Def_Activated]
                                    //      ,[Def_created_by]
                                    //      ,[Def_created_Time]
                                    //      ,[Def_updated_by]
                                    //      ,[Def_updated_Time]
                                    //  FROM [ISIDB].[dbo].[ISI_Defect]
            Adapter.TableMappings.Add(tableMapping);
            _adapter.DeleteCommand = new SqlCommand();
            _adapter.DeleteCommand.Connection = _connection;
            _adapter.DeleteCommand.CommandText = " DELETE FROM ISI_Defect   WHERE Def_ID = @originalDef_ID";
            _adapter.DeleteCommand.CommandType = CommandType.Text;
            _adapter.DeleteCommand.Parameters.Add(new SqlParameter("@originalDef_ID", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Def_ID", DataRowVersion.Original, false, null, "", "", ""));
            _adapter.InsertCommand = new SqlCommand();
            _adapter.InsertCommand.Connection = _connection;

            _adapter.InsertCommand.CommandText = @"INSERT INTO  ISI_Defect ( Def_ID,Def_Desc,Def_Remark,Def_Activated,Def_created_by,Def_created_Time,Def_updated_by,Def_updated_Time ) VALUES
                                                                                ( @Def_ID,@Def_Desc,@Def_Remark,@Def_Activated,@Def_created_by,GetDate(),@Def_updated_by,GetDate() ) ";
            _adapter.InsertCommand.CommandType = CommandType.Text;

            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Def_ID", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Def_ID", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Def_Desc", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Def_Desc", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Def_Remark", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Def_Remark", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Def_Activated", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "Def_Activated", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Def_created_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Def_created_by", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Def_updated_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Def_updated_by", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand = new SqlCommand();
            _adapter.UpdateCommand.Connection = _connection;
            _adapter.UpdateCommand.CommandText = @"UPDATE  ISI_Defect SET Def_ID=@Def_ID,Def_Desc=@Def_Desc,Def_Remark=@Def_Remark,Def_Activated=@Def_Activated,Def_updated_by=@Def_updated_by,Def_updated_Time=GetDate()  
                                                WHERE Def_ID = @originalDef_ID;
                                                SELECT * FROM ISI_Defect WHERE Def_ID = @originalDef_ID";
            _adapter.UpdateCommand.CommandType = CommandType.Text;
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Def_ID", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Def_ID", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Def_Desc", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Def_Desc", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Def_Remark", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Def_Remark", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Def_Activated", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "Def_Activated", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Def_created_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Def_created_by", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Def_updated_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Def_updated_by", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@originalDef_ID", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Def_ID", DataRowVersion.Original, false, null, "", "", ""));
        }
        public int DeleteRecord(int Key)
        {
            SqlCommand command = new SqlCommand("DELETE FROM ISI_Defect WHERE Def_ID = @Key ", this._connection);
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
