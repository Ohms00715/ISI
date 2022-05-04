using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;

namespace ISI.Data
{
    
    //class DataAdaptorTRN
    //{

    //}
    #region AdaptorDOC
    public partial class ISI_DOC
    {
        private SqlConnection _connection;
        private SqlDataAdapter _adapter;
        public ISI_DOC(SqlConnection connection)
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
            tableMapping.DataSetTable = "ISI_Document";
            tableMapping.ColumnMappings.Add("Doc_ID", "Doc_ID");
            tableMapping.ColumnMappings.Add("Doc_Des", "Doc_Des");
            tableMapping.ColumnMappings.Add("Doc_Date", "Doc_Date");
            tableMapping.ColumnMappings.Add("Doc_Activated", "Doc_Activated");
            tableMapping.ColumnMappings.Add("Doc_created_by", "Doc_created_by");
            tableMapping.ColumnMappings.Add("Doc_created_Time", "Doc_created_Time");
            tableMapping.ColumnMappings.Add("Doc_updated_by", "Doc_updated_by");
            tableMapping.ColumnMappings.Add("Doc_Updated_Time", "Doc_Updated_Time");
            tableMapping.ColumnMappings.Add("QC_Inspector", "QC_Inspector");
            tableMapping.ColumnMappings.Add("LG_Inspector", "LG_Inspector");
            tableMapping.ColumnMappings.Add("Approved_Inspector", "Approved_Inspector");
            tableMapping.ColumnMappings.Add("Doc_Running", "Doc_Running");



  //         Doc_ID
  //    ,Doc_Des
  //    ,Doc_Date
  //    ,Doc_Activated
  //    ,Doc_created_by
  //    ,Doc_created_Time
  //    ,Doc_updated_by
  //    ,Doc_Updated_Time
  //    ,QC_Inspector
  //    ,LG_Inspector
  //    ,Approved_Inspector
  //    ,Doc_Running
  //FROM ISI_Document
           
            Adapter.TableMappings.Add(tableMapping);
            _adapter.DeleteCommand = new SqlCommand();
            _adapter.DeleteCommand.Connection = _connection;
            _adapter.DeleteCommand.CommandText = " DELETE FROM ISI_Document   WHERE Doc_ID = @originalDoc_ID";
            _adapter.DeleteCommand.CommandType = CommandType.Text;
            _adapter.DeleteCommand.Parameters.Add(new SqlParameter("@originalDoc_ID", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Doc_ID", DataRowVersion.Original, false, null, "", "", ""));
            _adapter.InsertCommand = new SqlCommand();
            _adapter.InsertCommand.Connection = _connection;
            //_adapter.InsertCommand.CommandText = @"INSERT INTO  ISI_Supplier ( Sup_Desc) VALUES ( @Sup_Desc) ";
            _adapter.InsertCommand.CommandText = @"INSERT INTO  ISI_Document ( Doc_ID,Doc_Des,Doc_Date,Doc_Activated,Doc_created_by,Doc_created_Time,Doc_updated_by,Doc_Updated_Time,QC_Inspector,LG_Inspector,Approved_Inspector,Doc_Running ) VALUES
                                                                                ( @Doc_ID,@Doc_Des,@Doc_Date,@Doc_Activated,@Doc_created_by,GetDate(),@Doc_updated_by,GetDate(),@QC_Inspector,@LG_Inspector,@Approved_Inspector,@Doc_Running )";
            _adapter.InsertCommand.CommandType = CommandType.Text;

            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Doc_ID", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Doc_ID", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Doc_Des", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Doc_Des", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Doc_Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Doc_Date", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Doc_Activated", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "Doc_Activated", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Doc_created_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Doc_created_by", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Doc_updated_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Doc_updated_by", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@QC_Inspector", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "QC_Inspector", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@LG_Inspector", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "LG_Inspector", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Approved_Inspector", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Approved_Inspector", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Doc_Running", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Doc_Running", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand = new SqlCommand();
            _adapter.UpdateCommand.Connection = _connection;
            _adapter.UpdateCommand.CommandText = @"UPDATE  ISI_Document SET Doc_ID=@Doc_ID,Doc_Des=@Doc_Des,Doc_Date=@Doc_Date,Doc_Activated=@Doc_Activated,Doc_updated_by=@Doc_updated_by,Doc_Updated_Time=GetDate(),QC_Inspector=@QC_Inspector,LG_Inspector=@LG_Inspector,Approved_Inspector=@Approved_Inspector,Doc_Running=@Doc_Running
                                                WHERE Doc_ID = @originalDoc_ID;
                                                SELECT * FROM ISI_Document WHERE Doc_ID = @originalDoc_ID";
            _adapter.UpdateCommand.CommandType = CommandType.Text;
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Doc_ID", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Doc_ID", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Doc_Des", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Doc_Des", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Doc_Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Doc_Date", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Doc_Activated", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "Doc_Activated", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Doc_created_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Doc_created_by", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Doc_updated_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Doc_updated_by", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@QC_Inspector", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "QC_Inspector", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@LG_Inspector", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "LG_Inspector", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Approved_Inspector", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Approved_Inspector", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Doc_Running", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Doc_Running", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@originalDoc_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Doc_ID", DataRowVersion.Original, false, null, "", "", ""));
        }
        public int DeleteRecord(int Key)
        {
            SqlCommand command = new SqlCommand("DELETE FROM ISI_Document WHERE Doc_ID = @Key ", this._connection);
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
    #endregion
    #region Adaptor TRN
    public partial class ISI_Incoming
    {
        private SqlConnection _connection;
        private SqlDataAdapter _adapter;
        public ISI_Incoming(SqlConnection connection)
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
            tableMapping.DataSetTable = "ISI_Incoming";
            tableMapping.ColumnMappings.Add("Trn_Ticket", "Trn_Ticket");
            tableMapping.ColumnMappings.Add("Trn_PO", "Trn_PO");
            tableMapping.ColumnMappings.Add("Trn_Date", "Trn_Date");
            tableMapping.ColumnMappings.Add("Trn_Deduct_QC", "Trn_Deduct_QC");
            tableMapping.ColumnMappings.Add("Trn_Deduct_LG", "Trn_Deduct_LG");
            tableMapping.ColumnMappings.Add("Trn_Weight_IN", "Trn_Weight_IN");
            tableMapping.ColumnMappings.Add("Trn_Weight_IN_Time", "Trn_Weight_IN_Time");
            tableMapping.ColumnMappings.Add("Trn_Weight_OUT", "Trn_Weight_OUT");
            tableMapping.ColumnMappings.Add("Trn_Weight_OUT_Time", "Trn_Weight_OUT_Time");
            tableMapping.ColumnMappings.Add("Trn_Weight_Net", "Trn_Weight_Net");
            tableMapping.ColumnMappings.Add("Trn_Weight_Net_Time", "Trn_Weight_Net_Time");
            tableMapping.ColumnMappings.Add("Inspector_Approved", "Inspector_Approved");
            tableMapping.ColumnMappings.Add("Inspector_Approved_Date", "Inspector_Approved_Date");
            tableMapping.ColumnMappings.Add("Approved_Flag", "Approved_Flag");
            tableMapping.ColumnMappings.Add("Trn_created_Time", "Trn_created_Time");
            tableMapping.ColumnMappings.Add("Trn_created_by", "Trn_created_by");
            tableMapping.ColumnMappings.Add("Trn_updated_by", "Trn_updated_by");
            tableMapping.ColumnMappings.Add("Trn_updated_Time", "Trn_updated_Time");
            tableMapping.ColumnMappings.Add("Mat_Id", "Mat_Id");
            tableMapping.ColumnMappings.Add("Status_ID", "Status_ID");
            tableMapping.ColumnMappings.Add("Sup_ID", "Sup_ID");
            tableMapping.ColumnMappings.Add("Doc_ID", "Doc_ID");
            tableMapping.ColumnMappings.Add("Trn_Ticket_Run", "Trn_Ticket_Run");




  //         Trn_Ticket
  //    ,Trn_PO
  //    ,Trn_Truck_Id
  //    ,Trn_Date
  //    ,Trn_Deduct_QC
  //    ,Trn_Deduct_LG
  //    ,Trn_Weight_IN
  //    ,Trn_Weight_IN_Time
  //    ,Trn_Weight_OUT
  //    ,Trn_Weight_OUT_Time
  //    ,Trn_Weight_Net
  //    ,Trn_Weight_Net_Time
  //    ,Inspector_Approved
  //    ,Inspector_Approved_Date
  //    ,Approved_Flag
  //    ,Trn_created_Time
  //    ,Trn_created_by
  //    ,Trn_updated_by
  //    ,Trn_updated_Time
  //    ,Mat_Id
  //    ,Status_ID
  //    ,Sup_ID
  //    ,Doc_ID
  //    ,Trn_Ticket_Run
  //FROM ISI_Incoming

            Adapter.TableMappings.Add(tableMapping);
            _adapter.DeleteCommand = new SqlCommand();
            _adapter.DeleteCommand.Connection = _connection;
            _adapter.DeleteCommand.CommandText = " DELETE FROM ISI_Incoming   WHERE Trn_Ticket = @originalTrn_Ticket";
            _adapter.DeleteCommand.CommandType = CommandType.Text;
            _adapter.DeleteCommand.Parameters.Add(new SqlParameter("@originalTrn_Ticket", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Trn_Ticket", DataRowVersion.Original, false, null, "", "", ""));
            _adapter.InsertCommand = new SqlCommand();
            _adapter.InsertCommand.Connection = _connection;
            //_adapter.InsertCommand.CommandText = @"INSERT INTO  ISI_Supplier ( Sup_Desc) VALUES ( @Sup_Desc) ";
            _adapter.InsertCommand.CommandText = @"INSERT INTO  ISI_Incoming 
            ( Trn_Ticket,Trn_PO,Trn_Truck_Id,Trn_Date,Trn_Deduct_QC,Trn_Deduct_LG,Trn_Weight_IN,Trn_Weight_IN_Time,Trn_Weight_OUT,Trn_Weight_OUT_Time,Trn_Weight_Net,Trn_Weight_Net_Time,Inspector_Approved,Inspector_Approved_Date,Approved_Flag,Trn_created_Time,Trn_created_by,Trn_updated_by,Trn_updated_Time,Mat_Id,Status_ID,Sup_ID,Doc_ID,Trn_Ticket_Run) VALUES
            ( @Trn_Ticket,@Trn_PO,@Trn_Truck_Id,@Trn_Date,@Trn_Deduct_QC,@Trn_Deduct_LG,@Trn_Weight_IN,@Trn_Weight_IN_Time,@Trn_Weight_OUT,@Trn_Weight_OUT_Time,@Trn_Weight_Net,@Trn_Weight_Net_Time,@Inspector_Approved,@Inspector_Approved_Date,@Approved_Flag,GetDate(),@Trn_created_by,@Trn_updated_by,GetDate(),@Mat_Id,@Status_ID,@Sup_ID,@Doc_ID,@Trn_Ticket_Run)";
            _adapter.InsertCommand.CommandType = CommandType.Text;

            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Trn_Ticket", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Trn_Ticket", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Trn_PO", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Trn_PO", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Trn_Truck_Id", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Trn_Truck_Id", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Trn_Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Trn_Date", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Trn_Deduct_QC", SqlDbType.Decimal, 0, ParameterDirection.Input, 0, 0, "Trn_Deduct_QC", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Trn_Deduct_LG", SqlDbType.Decimal, 0, ParameterDirection.Input, 0, 0, "Trn_Deduct_LG", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Trn_Weight_IN", SqlDbType.Decimal, 0, ParameterDirection.Input, 0, 0, "Trn_Weight_IN", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Trn_Weight_IN_Time", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Trn_Weight_IN_Time", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Trn_Weight_OUT", SqlDbType.Decimal, 0, ParameterDirection.Input, 0, 0, "Trn_Weight_OUT", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Trn_Weight_OUT_Time", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Trn_Weight_OUT_Time", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Trn_Weight_Net", SqlDbType.Decimal, 0, ParameterDirection.Input, 0, 0, "Trn_Weight_Net", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Trn_Weight_Net_Time", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Trn_Weight_Net_Time", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Inspector_Approved", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Inspector_Approved", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Inspector_Approved_Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Inspector_Approved_Date", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Approved_Flag", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "Approved_Flag", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Trn_created_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Trn_created_by", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Trn_updated_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Trn_updated_by", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Mat_Id", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Mat_Id", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Sup_ID", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Sup_ID", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Doc_ID", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Doc_ID", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Status_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Status_ID", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Trn_Ticket_Run", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Trn_Ticket_Run", DataRowVersion.Current, false, null, "", "", ""));
            
            _adapter.UpdateCommand = new SqlCommand();
            _adapter.UpdateCommand.Connection = _connection;
            _adapter.UpdateCommand.CommandText = @"UPDATE  ISI_Incoming SET Trn_PO=@Trn_PO,Trn_Truck_Id=@Trn_Truck_Id,Trn_Date=@Trn_Date,
            Trn_Deduct_QC=@Trn_Deduct_QC,Trn_Deduct_LG=@Trn_Deduct_LG,Trn_Weight_IN=@Trn_Weight_IN,Trn_Weight_IN_Time=@Trn_Weight_IN_Time,Trn_Weight_OUT=@Trn_Weight_OUT,Trn_Weight_OUT_Time=@Trn_Weight_OUT_Time,Trn_Weight_Net=@Trn_Weight_Net,Trn_Weight_Net_Time=@Trn_Weight_Net_Time,
            Inspector_Approved=@Inspector_Approved,Inspector_Approved_Date=@Inspector_Approved_Date,Approved_Flag=@Approved_Flag,Trn_updated_by=@Trn_updated_by,Trn_updated_Time=GetDate(),Mat_Id=@Mat_Id,
            Sup_ID=@Sup_ID,Doc_ID=@Doc_ID,Status_ID=@Status_ID
                                                WHERE Trn_Ticket = @originalTrn_Ticket;
                                                SELECT * FROM ISI_Incoming WHERE Trn_Ticket = @originalTrn_Ticket";
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Trn_Ticket", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Trn_Ticket", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Trn_PO", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Trn_PO", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Trn_Truck_Id", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Trn_Truck_Id", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Trn_Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Trn_Date", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Trn_Deduct_QC", SqlDbType.Decimal, 0, ParameterDirection.Input, 0, 0, "Trn_Deduct_QC", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Trn_Deduct_LG", SqlDbType.Decimal, 0, ParameterDirection.Input, 0, 0, "Trn_Deduct_LG", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Trn_Weight_IN", SqlDbType.Decimal, 0, ParameterDirection.Input, 0, 0, "Trn_Weight_IN", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Trn_Weight_IN_Time", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Trn_Weight_IN_Time", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Trn_Weight_OUT", SqlDbType.Decimal, 0, ParameterDirection.Input, 0, 0, "Trn_Weight_OUT", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Trn_Weight_OUT_Time", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Trn_Weight_OUT_Time", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Trn_Weight_Net", SqlDbType.Decimal, 0, ParameterDirection.Input, 0, 0, "Trn_Weight_Net", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Trn_Weight_Net_Time", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Trn_Weight_Net_Time", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Inspector_Approved", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Inspector_Approved", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Inspector_Approved_Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Inspector_Approved_Date", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Approved_Flag", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "Approved_Flag", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Trn_created_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Trn_created_by", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Trn_updated_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Trn_updated_by", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Mat_Id", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Mat_Id", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Sup_ID", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Sup_ID", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Doc_ID", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Doc_ID", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Status_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Status_ID", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Trn_Ticket_Run", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Trn_Ticket_Run", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@originalTrn_Ticket", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Trn_Ticket", DataRowVersion.Original, false, null, "", "", ""));
        }
        public int DeleteRecord(int Key)
        {
            SqlCommand command = new SqlCommand("DELETE FROM ISI_Incoming WHERE Trn_Ticket = @Key ", this._connection);
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
    #endregion
    #region Adaptor INDEF

    public partial class ISI_Incoming_Defect
    {
        private SqlConnection _connection;
        private SqlDataAdapter _adapter;
        public ISI_Incoming_Defect(SqlConnection connection)
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
            tableMapping.DataSetTable = "ISI_Incoming_Defect";
            tableMapping.ColumnMappings.Add("In_Def_ID", "In_Def_ID");
            tableMapping.ColumnMappings.Add("In_Def_Weigth_Kg", "In_Def_Weigth_Kg");
            tableMapping.ColumnMappings.Add("In_Def_created_Time", "In_Def_created_Time");
            tableMapping.ColumnMappings.Add("In_Def_created_by", "In_Def_created_by");
            tableMapping.ColumnMappings.Add("In_Def_updated_by", "In_Def_updated_by");
            tableMapping.ColumnMappings.Add("In_Def_updated_Time", "In_Def_updated_Time");
            tableMapping.ColumnMappings.Add("Def_ID", "Def_ID");
            tableMapping.ColumnMappings.Add("Trn_Ticket", "Trn_Ticket");
            
           



                          //        In_Def_ID
                          //    ,In_Def_Weigth_Kg
                          //    ,In_Def_created_Time
                          //    ,In_Def_created_by
                          //    ,In_Def_updated_by
                          //    ,In_Def_updated_Time
                          //    ,Def_ID
                          //    ,Trn_Ticket
                          //    ,In_Def_Run
                          //    ,Doc_ID
                          //FROM ISI_Incoming_Defect

            Adapter.TableMappings.Add(tableMapping);
            _adapter.DeleteCommand = new SqlCommand();
            _adapter.DeleteCommand.Connection = _connection;
            _adapter.DeleteCommand.CommandText = " DELETE FROM ISI_Incoming_Defect   WHERE In_Def_ID = @originalIn_Def_ID";
            _adapter.DeleteCommand.CommandType = CommandType.Text;
            _adapter.DeleteCommand.Parameters.Add(new SqlParameter("@originalIn_Def_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "In_Def_ID", DataRowVersion.Original, false, null, "", "", ""));
            _adapter.InsertCommand = new SqlCommand();
            _adapter.InsertCommand.Connection = _connection;
            //_adapter.InsertCommand.CommandText = @"INSERT INTO  ISI_Supplier ( Sup_Desc) VALUES ( @Sup_Desc) ";
            _adapter.InsertCommand.CommandText = @"INSERT INTO  ISI_Incoming_Defect ( In_Def_Weigth_Kg,In_Def_created_Time,In_Def_created_by,In_Def_updated_by,In_Def_updated_Time,Def_ID,Trn_Ticket) VALUES
                                                                                ( @In_Def_Weigth_Kg,GetDate(),@In_Def_created_by,@In_Def_updated_by,GetDate(),@Def_ID,@Trn_Ticket)";
            _adapter.InsertCommand.CommandType = CommandType.Text;

            //_adapter.InsertCommand.Parameters.Add(new SqlParameter("@In_Def_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "In_Def_ID", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@In_Def_Weigth_Kg", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "In_Def_Weigth_Kg", DataRowVersion.Current, false, null, "", "", ""));
            //_adapter.InsertCommand.Parameters.Add(new SqlParameter("@In_Def_created_Time", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "In_Def_created_Time", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@In_Def_created_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "In_Def_created_by", DataRowVersion.Current, false, null, "", "", ""));
            //_adapter.InsertCommand.Parameters.Add(new SqlParameter("@In_Def_updated_Time", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "In_Def_updated_Time", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@In_Def_updated_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "In_Def_updated_by", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Trn_Ticket", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Trn_Ticket", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Def_ID", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Def_ID", DataRowVersion.Current, false, null, "", "", ""));
            //_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Doc_ID", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Doc_ID", DataRowVersion.Current, false, null, "", "", ""));
            
            _adapter.UpdateCommand = new SqlCommand();
            _adapter.UpdateCommand.Connection = _connection;
            _adapter.UpdateCommand.CommandText = @"UPDATE  ISI_Incoming_Defect SET 
                In_Def_Weigth_Kg=@In_Def_Weigth_Kg,
                In_Def_created_Time=GetDate(),In_Def_updated_by=@In_Def_updated_by
                ,In_Def_updated_Time=GetDate(),Def_ID=@Def_ID

                                                
                                                WHERE In_Def_ID = @originalIn_Def_ID;
                                                SELECT * FROM ISI_Incoming_Defect WHERE In_Def_ID = @originalIn_Def_ID";
            _adapter.UpdateCommand.CommandType = CommandType.Text;
            //_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@In_Def_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "In_Def_ID", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@In_Def_Weigth_Kg", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "In_Def_Weigth_Kg", DataRowVersion.Current, false, null, "", "", ""));
            //_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@In_Def_created_Time", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "In_Def_created_Time", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@In_Def_created_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "In_Def_created_by", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@In_Def_updated_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "In_Def_updated_by", DataRowVersion.Current, false, null, "", "", ""));
             _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Def_ID", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Def_ID", DataRowVersion.Current, false, null, "", "", ""));
            //_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@In_Def_Run", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "In_Def_Run", DataRowVersion.Current, false, null, "", "", ""));
           // _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Doc_ID", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Doc_ID", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@originalIn_Def_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "In_Def_ID", DataRowVersion.Original, false, null, "", "", ""));
        }
        public int DeleteRecord(int Key)
        {
            SqlCommand command = new SqlCommand("DELETE FROM ISI_Incoming_Defect WHERE In_Def_ID = @Key ", this._connection);
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

#endregion
    #region Adaptor PIC
    public partial class ISI_Picture
    {
        private SqlConnection _connection;
        private SqlDataAdapter _adapter;
        public ISI_Picture(SqlConnection connection)
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
            tableMapping.DataSetTable = "ISI_Picture";
            tableMapping.ColumnMappings.Add("Pic_ID", "Pic_ID");
            tableMapping.ColumnMappings.Add("Pic_Path", "Pic_Path");
            tableMapping.ColumnMappings.Add("Trn_Ticket", "Trn_Ticket");
        
           


                              //         Pic_ID
                              //    ,Pic_Path
                              //    ,Pic_Des
                              //    ,Trn_Ticket
                              //    ,Pic_Run
                              //    ,Doc_ID
                              //FROM ISI_Picture
             //*/
           
            Adapter.TableMappings.Add(tableMapping);
            _adapter.DeleteCommand = new SqlCommand();
            _adapter.DeleteCommand.Connection = _connection;
            _adapter.DeleteCommand.CommandText = " DELETE FROM ISI_Picture   WHERE Pic_ID = @originalPic_ID";
            _adapter.DeleteCommand.CommandType = CommandType.Text;
            _adapter.DeleteCommand.Parameters.Add(new SqlParameter("@originalPic_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Pic_ID", DataRowVersion.Original, false, null, "", "", ""));
            _adapter.InsertCommand = new SqlCommand();
            _adapter.InsertCommand.Connection = _connection;
            //_adapter.InsertCommand.CommandText = @"INSERT INTO  ISI_Supplier ( Sup_Desc) VALUES ( @Sup_Desc) ";
            _adapter.InsertCommand.CommandText = @"INSERT INTO  ISI_Picture (Pic_Path,Pic_Des,Trn_Ticket ) VALUES
                                                                                ( @Pic_Path,@Pic_Des,@Trn_Ticket)";
            _adapter.InsertCommand.CommandType = CommandType.Text;

           // _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Pic_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Pic_ID", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Pic_Path", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Pic_Path", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Pic_Des", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Pic_Des", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Trn_Ticket", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Trn_Ticket", DataRowVersion.Current, false, null, "", "", ""));
            //_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Pic_Run", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Pic_Run", DataRowVersion.Current, false, null, "", "", ""));
            //_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Doc_ID", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Doc_ID", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand = new SqlCommand();
            _adapter.UpdateCommand.Connection = _connection;
            _adapter.UpdateCommand.CommandText = @"UPDATE  ISI_Picture SET Pic_Path=@Pic_Path,Pic_Des=@Pic_Des
                                                WHERE Pic_ID = @originalPic_ID;
                                                SELECT * FROM ISI_Picture WHERE Pic_ID = @originalPic_ID";
            _adapter.UpdateCommand.CommandType = CommandType.Text;
            //_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Pic_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Pic_ID", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Pic_Path", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Pic_Path", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Pic_Des", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Pic_Des", DataRowVersion.Current, false, null, "", "", ""));
            //_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Trn_Ticket", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Trn_Ticket", DataRowVersion.Current, false, null, "", "", ""));
           // _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Pic_Run", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Pic_Run", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@originalPic_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Pic_ID", DataRowVersion.Original, false, null, "", "", ""));
        }
        public int DeleteRecord(int Key)
        {
            SqlCommand command = new SqlCommand("DELETE FROM ISI_Picture WHERE Pic_ID = @Key ", this._connection);
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




    #endregion

    #region AdaptorReport
    public partial class Report
    {
        private SqlConnection _connection;
        private SqlDataAdapter _adapter;
        public Report(SqlConnection connection)
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
            tableMapping.DataSetTable = "V_Incoming";
            tableMapping.ColumnMappings.Add("Doc_ID", "Doc_ID");
            tableMapping.ColumnMappings.Add("Doc_Date", "Doc_Date");
            tableMapping.ColumnMappings.Add("QC_Inspector", "QC_Inspector");
            tableMapping.ColumnMappings.Add("LG_Inspector", "LG_Inspector");
            tableMapping.ColumnMappings.Add("LG_InspectorName", "LG_InspectorName");
            tableMapping.ColumnMappings.Add("Approved_Inspector", "Approved_Inspector");
            tableMapping.ColumnMappings.Add("ApprovedName", "ApprovedName");
            tableMapping.ColumnMappings.Add("Tck_No", "Tck_No");
            tableMapping.ColumnMappings.Add("Truck_No", "Truck_No");
            tableMapping.ColumnMappings.Add("Trn_Date", "Trn_Date");
            tableMapping.ColumnMappings.Add("Trn_Deduct_QC", "Trn_Deduct_QC");
            tableMapping.ColumnMappings.Add("Trn_Deduct_LG", "Trn_Deduct_LG");
            tableMapping.ColumnMappings.Add("Trn_Weight_IN", "Trn_Weight_IN");
            tableMapping.ColumnMappings.Add("Trn_Weight_IN_Time", "Trn_Weight_IN_Time");
            tableMapping.ColumnMappings.Add("Trn_Weight_OUT", "Trn_Weight_OUT");
            tableMapping.ColumnMappings.Add("Trn_Weight_OUT_Time", "Trn_Weight_OUT_Time");
            tableMapping.ColumnMappings.Add("Trn_Weight_Net", "Trn_Weight_Net");
            tableMapping.ColumnMappings.Add("Trn_Weight_Net_Time", "Trn_Weight_Net_Time");
            tableMapping.ColumnMappings.Add("Inspector_Approved", "Inspector_Approved");
            tableMapping.ColumnMappings.Add("Inspector_ApprovedName", "Inspector_ApprovedName");
            tableMapping.ColumnMappings.Add("Inspector_Approved_Date", "Inspector_Approved_Date");
            tableMapping.ColumnMappings.Add("Approved_Flag", "Approved_Flag");
            tableMapping.ColumnMappings.Add("Status_Desc", "Status_Desc");
            tableMapping.ColumnMappings.Add("Status_ID", "Status_ID");
            tableMapping.ColumnMappings.Add("Status_Remark", "Status_Remark");
            tableMapping.ColumnMappings.Add("Status_Desc", "Status_Desc");
            tableMapping.ColumnMappings.Add("Mat_Code", "Mat_Code");
            tableMapping.ColumnMappings.Add("Sup_desc", "Sup_desc");
            tableMapping.ColumnMappings.Add("Pic_Path", "Pic_Path");
            tableMapping.ColumnMappings.Add("In_Def_Weigth_Kg", "In_Def_Weigth_Kg");
            tableMapping.ColumnMappings.Add("Def_Desc", "Def_Desc");
            tableMapping.ColumnMappings.Add("Def_ID", "Def_ID");
            tableMapping.ColumnMappings.Add("Defect", "Defect");


            //          SELECT TOP (1000) [Doc_ID]
            //    ,[Doc_Date]
            //    ,[QC_Inspector]
            //    ,[QC_InspectorName]
            //    ,[LG_Inspector]
            //    ,[LG_InspectorName]
            //    ,[Approved_Inspector]
            //    ,[ApprovedName]
            //    ,[Tck_No]
            //    ,[PO]
            //    ,[Truck_No]
            //    ,[Trn_Date]
            //    ,[Trn_Deduct_QC]
            //    ,[Trn_Deduct_LG]
            //    ,[Trn_Weight_IN]
            //    ,[Trn_Weight_IN_Time]
            //    ,[Trn_Weight_OUT]
            //    ,[Trn_Weight_OUT_Time]
            //    ,[Trn_Weight_Net]
            //    ,[Inspector_Approved]
            //    ,[Inspector_ApprovedName]
            //    ,[Trn_Weight_Net_Time]
            //    ,[Inspector_Approved_Date]
            //    ,[Approved_Flag]
            //    ,[Status_Desc]
            //    ,[Status_ID]
            //    ,[Status_Remark]
            //    ,[Mat_Code]
            //    ,[Mat_Desc]
            //    ,[Sup_desc]
            //    ,[Pic_Path]
            //    ,[In_Def_Weigth_Kg]
            //    ,[Def_Desc]
            //    ,[Def_ID]
            //    ,[Defect]
            //FROM [ISIDB].[dbo].[V_Incoming]

            Adapter.TableMappings.Add(tableMapping);
            _adapter.DeleteCommand = new SqlCommand();
            _adapter.DeleteCommand.Connection = _connection;
            _adapter.DeleteCommand.CommandText = " DELETE FROM V_Incoming   WHERE Doc_ID = @originalDoc_ID";
            _adapter.DeleteCommand.CommandType = CommandType.Text;
            _adapter.DeleteCommand.Parameters.Add(new SqlParameter("@originalDoc_ID", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Doc_ID", DataRowVersion.Original, false, null, "", "", ""));
            _adapter.InsertCommand = new SqlCommand();
            _adapter.InsertCommand.Connection = _connection;
            _adapter.InsertCommand.CommandText = @"INSERT INTO  V_Incoming ( Doc_ID,Doc_Date,QC_Inspector,QC_InspectorName,LG_Inspector,LG_InspectorName,Approved_Inspector,ApprovedName,Tck_No,PO,Truck_No,Trn_Date,Trn_Deduct_QC,Trn_Deduct_LG,Trn_Weight_IN,Trn_Weight_IN_Time,Trn_Weight_OUT,Trn_Weight_OUT_Time,Trn_Weight_Net,Trn_Weight_Net_Time,Inspector_Approved,Inspector_ApprovedName,Inspector_Approved_Date,Approved_Flag,Status_Desc,Status_ID,Status_Remark,Mat_Code,Mat_Desc,Sup_desc,Pic_Path,In_Def_Weigth_Kg,Def_Desc,Def_ID) VALUES
                                                                                ( @Doc_ID,@Doc_Date,@QC_Inspector,@QC_InspectorName,@LG_Inspector,@LG_InspectorName,@Approved_Inspector,@ApprovedName,@Tck_No,@PO,@Truck_No,@Trn_Date,@Trn_Deduct_QC,@Trn_Deduct_LG,@Trn_Weight_IN,@Trn_Weight_IN_Time,@Trn_Weight_OUT,@Trn_Weight_OUT_Time,@Trn_Weight_Net,@Trn_Weight_Net_Time,@Inspector_Approved,@Inspector_ApprovedName,@Inspector_Approved_Date,@Approved_Flag,@Status_Desc,@Status_ID,@Status_Remark,@Mat_Code,@Mat_Desc,@Sup_desc,@Pic_Path,@In_Def_Weigth_Kg,@Def_Desc,@Def_ID)";
            _adapter.InsertCommand.CommandType = CommandType.Text;

            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Doc_ID", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Doc_ID", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Doc_Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Doc_Date", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@QC_Inspector", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "QC_Inspector", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@QC_InspectorName", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "QC_InspectorName", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@LG_Inspector", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "LG_Inspector", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@LG_InspectorName", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "LG_InspectorName", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Approved_Inspector", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Approved_Inspector", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@ApprovedName", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ApprovedName", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Tck_No", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Tck_No", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@PO", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "PO", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Truck_No", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Truck_No", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Trn_Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Trn_Date", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Trn_Deduct_QC", SqlDbType.Decimal, 0, ParameterDirection.Input, 0, 0, "Trn_Deduct_QC", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Trn_Deduct_LG", SqlDbType.Decimal, 0, ParameterDirection.Input, 0, 0, "Trn_Deduct_LG", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Trn_Weight_IN", SqlDbType.Decimal, 0, ParameterDirection.Input, 0, 0, "Trn_Weight_IN", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Trn_Weight_IN_Time", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Trn_Weight_IN_Time", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Trn_Weight_OUT", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Trn_Weight_OUT", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Trn_Weight_OUT_Time", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Trn_Weight_OUT_Time", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Trn_Weight_Net", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Trn_Weight_Net", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Trn_Weight_Net_Time", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Trn_Weight_Net_Time", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Inspector_Approved", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Inspector_Approved", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Inspector_ApprovedName", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Inspector_ApprovedName", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Inspector_Approved_Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Inspector_Approved_Date", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Approved_Flag", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "Approved_Flag", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Status_Desc", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Status_Desc", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Status_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Status_ID", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Status_Remark", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Status_Remark", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Mat_Code", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Mat_Code", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Mat_Desc", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Mat_Desc", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Sup_desc", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Sup_desc", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Pic_Path", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Pic_Path", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@In_Def_Weigth_Kg", SqlDbType.Decimal, 0, ParameterDirection.Input, 0, 0, "In_Def_Weigth_Kg", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Def_Desc", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Def_Desc", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Def_ID", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Def_ID", DataRowVersion.Current, false, null, "", "", ""));


            _adapter.UpdateCommand = new SqlCommand();
            _adapter.UpdateCommand.Connection = _connection;
            _adapter.UpdateCommand.CommandText = @"UPDATE  V_Incoming SET Doc_ID=@Doc_ID,Doc_Date=@Doc_Date,QC_Inspector=@QC_Inspector,QC_InspectorName=@QC_InspectorName,LG_Inspector=@LG_Inspector,LG_InspectorName=@LG_InspectorName,Approved_Inspector=@Approved_Inspector,ApprovedName=@ApprovedName,Tck_No=@Tck_No,PO=@PO,Truck_No=@Truck_No,Trn_Date=@Trn_Date,Trn_Deduct_QC=@Trn_Deduct_QC,Trn_Deduct_LG=@Trn_Deduct_LG,Trn_Weight_IN=@Trn_Weight_IN,Trn_Weight_IN_Time=@Trn_Weight_IN_Time,Trn_Weight_OUT=@Trn_Weight_OUT,Trn_Weight_OUT_Time=@Trn_Weight_OUT_Time,Trn_Weight_Net=@Trn_Weight_Net,Trn_Weight_Net_Time=@Trn_Weight_Net_Time,Inspector_Approved=@Inspector_Approved,Inspector_ApprovedName=@Inspector_ApprovedName,Inspector_Approved_Date=@Inspector_Approved_Date,Approved_Flag=@Approved_Flag,Status_Desc=@Status_Desc,Status_ID=@Status_ID,Status_Remark=@Status_Remark,Mat_Code=@Mat_Code,Mat_Desc=@Mat_Desc,Sup_desc=@Sup_desc,Pic_Path=@Pic_Path,In_Def_Weigth_Kg=@In_Def_Weigth_Kg,Def_Desc=@Def_Desc,Def_ID=@Def_ID
                                                WHERE Doc_ID = @originalDoc_ID;
                                                SELECT * FROM V_Incoming WHERE Doc_ID = @originalDoc_ID";
            _adapter.UpdateCommand.CommandType = CommandType.Text;
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Doc_ID", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Doc_ID", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Doc_Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Doc_Date", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@QC_Inspector", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "QC_Inspector", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@QC_InspectorName", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "QC_InspectorName", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@LG_Inspector", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "LG_Inspector", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@LG_InspectorName", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "LG_InspectorName", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Approved_Inspector", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Approved_Inspector", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ApprovedName", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ApprovedName", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Tck_No", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Tck_No", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@PO", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "PO", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Truck_No", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Truck_No", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Trn_Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Trn_Date", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Trn_Deduct_QC", SqlDbType.Decimal, 0, ParameterDirection.Input, 0, 0, "Trn_Deduct_QC", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Trn_Deduct_LG", SqlDbType.Decimal, 0, ParameterDirection.Input, 0, 0, "Trn_Deduct_LG", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Trn_Weight_IN", SqlDbType.Decimal, 0, ParameterDirection.Input, 0, 0, "Trn_Weight_IN", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Trn_Weight_IN_Time", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Trn_Weight_IN_Time", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Trn_Weight_OUT", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Trn_Weight_OUT", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Trn_Weight_OUT_Time", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Trn_Weight_OUT_Time", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Trn_Weight_Net", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Trn_Weight_Net", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Trn_Weight_Net_Time", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Trn_Weight_Net_Time", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Inspector_Approved", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Inspector_Approved", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Inspector_ApprovedName", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Inspector_ApprovedName", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Inspector_Approved_Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Inspector_Approved_Date", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Approved_Flag", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "Approved_Flag", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Status_Desc", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Status_Desc", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Status_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Status_ID", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Status_Remark", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Status_Remark", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Mat_Code", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Mat_Code", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Mat_Desc", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Mat_Desc", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Sup_desc", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Sup_desc", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Pic_Path", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Pic_Path", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@In_Def_Weigth_Kg", SqlDbType.Decimal, 0, ParameterDirection.Input, 0, 0, "In_Def_Weigth_Kg", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Def_Desc", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Def_Desc", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Def_ID", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Def_ID", DataRowVersion.Current, false, null, "", "", ""));
        }
        public int DeleteRecord(int Key)
        {
            SqlCommand command = new SqlCommand("DELETE FROM V_Incoming WHERE Doc_ID = @Key ", this._connection);
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
    #endregion

}
