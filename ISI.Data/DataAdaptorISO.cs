using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;
namespace ISI.Data
{
    public partial class ISI_ISO
    {
        private SqlConnection _connection;
        private SqlDataAdapter _adapter;
        public ISI_ISO(SqlConnection connection)
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
            tableMapping.DataSetTable = "ISI_ISO";
            tableMapping.ColumnMappings.Add("ISO_ID", "ISO_ID");
            tableMapping.ColumnMappings.Add("ISO_Desc", "ISO_Desc");
            tableMapping.ColumnMappings.Add("ISO_TCODE", "ISO_TCODE");
            tableMapping.ColumnMappings.Add("ISO_NO", "ISO_NO");
            tableMapping.ColumnMappings.Add("ISO_created_by", "ISO_created_by");
            tableMapping.ColumnMappings.Add("ISO_created_Time", "ISO_created_Time");
            tableMapping.ColumnMappings.Add("ISO_updated_by", "ISO_updated_by");
            tableMapping.ColumnMappings.Add("ISO_updated_Time", "ISO_updated_Time");
            tableMapping.ColumnMappings.Add("ISO_Issused_Date", "ISO_Issused_Date");
            tableMapping.ColumnMappings.Add("ISO_Effective_Date", "ISO_Effective_Date");


                                //            /****** Script for SelectTopNRows command from SSMS  ******/
                                         //ISO_ID
                                         //     ,ISO_Desc
                                         //     ,ISO_TCODE
                                         //     ,ISO_NO
                                         //     ,ISO_created_by
                                         //     ,ISO_created_Time
                                         //     ,ISO_updated_by
                                         //     ,ISO_updated_Time
                                         //     ,ISO_Issused_Date
                                         //     ,ISO_Effective_Date
                                         //ISI_ISO
            Adapter.TableMappings.Add(tableMapping);
            _adapter.DeleteCommand = new SqlCommand();
            _adapter.DeleteCommand.Connection = _connection;
            _adapter.DeleteCommand.CommandText = " DELETE FROM ISI_ISO   WHERE ISO_ID = @originalISO_ID";
            _adapter.DeleteCommand.CommandType = CommandType.Text;
            _adapter.DeleteCommand.Parameters.Add(new SqlParameter("@originalISO_ID", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ISO_ID", DataRowVersion.Original, false, null, "", "", ""));
            _adapter.InsertCommand = new SqlCommand();
            _adapter.InsertCommand.Connection = _connection;

            _adapter.InsertCommand.CommandText = @"INSERT INTO  ISI_ISO ( ISO_ID,ISO_Desc,ISO_TCODE,ISO_NO,ISO_created_by,ISO_created_Time,ISO_updated_by,ISO_updated_Time ) VALUES
                                                                                ( @ISO_ID,@ISO_Desc,@ISO_TCODE,@ISO_NO,@ISO_created_by,GetDate(),@ISO_updated_by,GetDate() ) ";
            _adapter.InsertCommand.CommandType = CommandType.Text;

            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@ISO_ID", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ISO_ID", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@ISO_Desc", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ISO_Desc", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@ISO_TCODE", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ISO_TCODE", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@ISO_NO", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ISO_NO", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@ISO_created_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ISO_created_by", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@ISO_updated_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ISO_updated_by", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@ISO_Issused_Date", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ISO_Issused_Date", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@ISO_Effective_Date", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ISO_Effective_Date", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand = new SqlCommand();
            _adapter.UpdateCommand.Connection = _connection;
            _adapter.UpdateCommand.CommandText = @"UPDATE  ISI_ISO SET ISO_ID=@ISO_ID,ISO_Desc=@ISO_Desc,ISO_TCODE=@ISO_TCODE,ISO_NO=@ISO_NO,ISO_updated_by=@ISO_updated_by,ISO_updated_Time=GetDate(),ISO_Issused_Date=@ISO_Issused_Date,ISO_Effective_Date=@ISO_Effective_Date 
                                                WHERE ISO_ID = @originalISO_ID;
                                                SELECT * FROM ISI_ISO WHERE ISO_ID = @originalISO_ID";
            _adapter.UpdateCommand.CommandType = CommandType.Text;
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ISO_ID", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ISO_ID", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ISO_Desc", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ISO_Desc", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ISO_TCODE", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ISO_TCODE", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ISO_NO", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ISO_NO", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ISO_created_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ISO_created_by", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ISO_updated_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ISO_updated_by", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ISO_Issused_Date", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ISO_Issused_Date", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ISO_Effective_Date", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ISO_Effective_Date", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@originalISO_ID", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ISO_ID", DataRowVersion.Original, false, null, "", "", ""));
        }
        public int DeleteRecord(int Key)
        {
            SqlCommand command = new SqlCommand("DELETE FROM ISI_ISO WHERE ISO_ID = @Key ", this._connection);
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
