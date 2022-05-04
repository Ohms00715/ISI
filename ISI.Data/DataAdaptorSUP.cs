using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;


namespace ISI.Data
{

    public partial class ISI_Supplier
    {
        private SqlConnection _connection;
        private SqlDataAdapter _adapter;
        public ISI_Supplier(SqlConnection connection)
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
            tableMapping.DataSetTable = "ISI_Supplier";
            tableMapping.ColumnMappings.Add("Sup_ID", "Sup_ID");
            tableMapping.ColumnMappings.Add("Sup_Desc", "Sup_Desc");
            tableMapping.ColumnMappings.Add("Sup_Activated", "Sup_Activated");
            tableMapping.ColumnMappings.Add("Sup_created_by", "Sup_created_by");
            tableMapping.ColumnMappings.Add("Sup_created_Time", "Sup_created_Time");
            tableMapping.ColumnMappings.Add("Sup_updated_by", "Sup_updated_by");
            tableMapping.ColumnMappings.Add("Sup_Updated_Time", "Sup_Updated_Time");


            /*
             Sup_ID
  ,Sup_Desc
  ,Sup_Activated
  ,Sup_created_by
  ,Sup_created_Time
  ,Sup_updated_by
  ,Sup_Updated_Time
FROM ISIDB.dbo.ISI_Supplier
             */
            Adapter.TableMappings.Add(tableMapping);
            _adapter.DeleteCommand = new SqlCommand();
            _adapter.DeleteCommand.Connection = _connection;
            _adapter.DeleteCommand.CommandText = " DELETE FROM ISI_Supplier   WHERE Sup_ID = @originalSup_ID";
            _adapter.DeleteCommand.CommandType = CommandType.Text;
            _adapter.DeleteCommand.Parameters.Add(new SqlParameter("@originalSup_ID", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Sup_ID", DataRowVersion.Original, false, null, "", "", ""));
            _adapter.InsertCommand = new SqlCommand();
            _adapter.InsertCommand.Connection = _connection;
            //_adapter.InsertCommand.CommandText = @"INSERT INTO  ISI_Supplier ( Sup_Desc) VALUES ( @Sup_Desc) ";
            _adapter.InsertCommand.CommandText = @"INSERT INTO  ISI_Supplier ( Sup_ID,Sup_Desc,Sup_Activated,Sup_created_by,Sup_created_Time,Sup_updated_by,Sup_Updated_Time ) VALUES
                                                                                ( @Sup_ID,@Sup_Desc,@Sup_Activated,@Sup_created_by,GetDate(),@Sup_updated_by,GetDate() ) ";
            _adapter.InsertCommand.CommandType = CommandType.Text;

            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Sup_ID", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Sup_ID", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Sup_Desc", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Sup_Desc", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Sup_Activated", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "Sup_Activated", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Sup_created_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Sup_created_by", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Sup_updated_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Sup_updated_by", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand = new SqlCommand();
            _adapter.UpdateCommand.Connection = _connection;
            _adapter.UpdateCommand.CommandText = @"UPDATE  ISI_Supplier SET Sup_ID=@Sup_ID,Sup_Desc=@Sup_Desc,Sup_Activated=@Sup_Activated,Sup_updated_by=@Sup_updated_by,Sup_Updated_Time=GetDate()  
                                                WHERE Sup_ID = @originalSup_ID;
                                                SELECT * FROM ISI_Supplier WHERE Sup_ID = @originalSup_ID";
            _adapter.UpdateCommand.CommandType = CommandType.Text;
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Sup_ID", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Sup_ID", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Sup_Desc", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Sup_Desc", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Sup_Activated", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "Sup_Activated", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Sup_created_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Sup_created_by", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Sup_updated_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Sup_updated_by", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@originalSup_ID", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Sup_ID", DataRowVersion.Original, false, null, "", "", ""));
        }
        public int DeleteRecord(int Key)
        {
            SqlCommand command = new SqlCommand("DELETE FROM ISI_Supplier WHERE Sup_ID = @Key ", this._connection);
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
