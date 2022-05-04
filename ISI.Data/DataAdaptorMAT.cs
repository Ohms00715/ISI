using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;
namespace ISI.Data
{
    public partial class ISI_Material
    {
        private SqlConnection _connection;
        private SqlDataAdapter _adapter;
        public ISI_Material(SqlConnection connection)
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
            tableMapping.DataSetTable = "ISI_Material";
            tableMapping.ColumnMappings.Add("Mat_ID", "Mat_ID");
            tableMapping.ColumnMappings.Add("Mat_Desc", "Mat_Desc");
            tableMapping.ColumnMappings.Add("Mat_Code", "Mat_Code");
            tableMapping.ColumnMappings.Add("Mat_Activated", "Mat_Activated");
            tableMapping.ColumnMappings.Add("Mat_created_by", "Mat_created_by");
            tableMapping.ColumnMappings.Add("Mat_created_Time", "Mat_created_Time");
            tableMapping.ColumnMappings.Add("Mat_updated_by", "Mat_updated_by");
            tableMapping.ColumnMappings.Add("Mat_updated_Time", "Mat_updated_Time");


            //        Mat_ID]
            //,[Mat_Desc]
            //,[Mat_Code]
            //,[Mat_Activated]
            //,[Mat_created_by]
            //,[Mat_created_Time]
            //,[Mat_updated_by]
            //,[Mat_Updated_Time]
            //*/
            Adapter.TableMappings.Add(tableMapping);
            _adapter.DeleteCommand = new SqlCommand();
            _adapter.DeleteCommand.Connection = _connection;
            _adapter.DeleteCommand.CommandText = " DELETE FROM ISI_Material   WHERE Mat_ID = @originalMat_ID";
            _adapter.DeleteCommand.CommandType = CommandType.Text;
            _adapter.DeleteCommand.Parameters.Add(new SqlParameter("@originalMat_ID", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Mat_ID", DataRowVersion.Original, false, null, "", "", ""));
            _adapter.InsertCommand = new SqlCommand();
            _adapter.InsertCommand.Connection = _connection;

            _adapter.InsertCommand.CommandText = @"INSERT INTO  ISI_Material ( Mat_ID,Mat_Desc,Mat_Code,Mat_Activated,Mat_created_by,Mat_created_Time,Mat_updated_by,Mat_Updated_Time ) VALUES
                                                                                ( @Mat_ID,@Mat_Desc,@MAT_Code,@Mat_Activated,@Mat_created_by,GetDate(),@Mat_updated_by,GetDate() ) ";
            _adapter.InsertCommand.CommandType = CommandType.Text;

            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Mat_ID", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Mat_ID", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Mat_Desc", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Mat_Desc", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Mat_Code", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Mat_Code", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Mat_Activated", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "Mat_Activated", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Mat_created_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Mat_created_by", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Mat_updated_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Mat_updated_by", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand = new SqlCommand();
            _adapter.UpdateCommand.Connection = _connection;
            _adapter.UpdateCommand.CommandText = @"UPDATE  ISI_Material SET Mat_ID=@Mat_ID,Mat_Desc=@Mat_Desc,Mat_Code=@Mat_Code,Mat_Activated=@Mat_Activated,Mat_updated_by=@Mat_updated_by,Mat_Updated_Time=GetDate()  
                                                WHERE Mat_ID = @originalMat_ID;
                                                SELECT * FROM ISI_Material WHERE Mat_ID = @originalMat_ID";
            _adapter.UpdateCommand.CommandType = CommandType.Text;
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Mat_ID", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Mat_ID", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Mat_Desc", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Mat_Desc", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Mat_Code", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Mat_Code", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Mat_Activated", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "Mat_Activated", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Mat_created_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Mat_created_by", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Mat_updated_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Mat_updated_by", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@originalMat_ID", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Mat_ID", DataRowVersion.Original, false, null, "", "", ""));
        }
        public int DeleteRecord(int Key)
        {
            SqlCommand command = new SqlCommand("DELETE FROM ISI_Material WHERE Mat_ID = @Key ", this._connection);
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
