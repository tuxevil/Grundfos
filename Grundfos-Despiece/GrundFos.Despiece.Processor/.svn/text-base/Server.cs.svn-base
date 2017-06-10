using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Net.Mail;
using System.Text;
using System.IO;
using System.Threading;
using GrundFos.Despiece.Common;

namespace GrundFos.Despiece.Processor
{
    public class Server
    {
        public static bool ActualizarDatos(DataSet ds, string server)
        {
            TimeZoneBlackedFix(ds);

            string ids = "";
            Utils.GetLogger().Debug("Preparing the delete query for PurchaseOrders");

            using(SqlConnection _connection = new SqlConnection(server))
            {
                _connection.Open();
                string delete = string.Empty;
                
                SqlTransaction tranPO = _connection.BeginTransaction();
                foreach (DataRow row in ds.Tables["PO"].Rows)
                {
                    //ids += "'" + row[0] + "',";
                    delete = "delete from ordcompras where id = '" + row[0] + "' and productcode = '" + row[1] +"'; ";
                }
                //if (ids.Length > 0)
                if (ds.Tables["PO"].Rows.Count > 0)
                {
                    //ids = ids.Substring(0, ids.Length - 1);
                    //delete = "delete from ordcompras where id in (" + ids + ")";
                    Utils.GetLogger().Debug(string.Format("Running the delete query for PurchaseOrders: {0} ", ds.Tables["PO"].Rows.Count));
                    Execute(delete, _connection, tranPO);
                }
                using (SqlBulkCopy copy = new SqlBulkCopy(_connection, new SqlBulkCopyOptions(), tranPO))
                {
                    Utils.GetLogger().Debug("Running the insert bulk for PurchaseOrders");
                    copy.DestinationTableName = "ordcompras";
                    copy.WriteToServer(ds.Tables["PO"]);
                }
                tranPO.Commit();
                
                SqlTransaction tranProd = _connection.BeginTransaction();
                ids = string.Empty;
                Utils.GetLogger().Debug("Preparing the delete query for Products");
                foreach (DataRow row in ds.Tables["Productos"].Rows)
                {
                    ids += "'" + row[0] + "',";
                }
                if (ids.Length > 0)
                {
                    ids = ids.Substring(0, ids.Length - 1);
                    delete = "delete from productos where productcode in (" + ids + ")";
                    Utils.GetLogger().Debug(string.Format("Running the delete query for Products: {0} ", ds.Tables["Productos"].Rows.Count));
                    Execute(delete, _connection, tranProd);
                }
                using (SqlBulkCopy copy = new SqlBulkCopy(_connection, new SqlBulkCopyOptions(), tranProd))
                {
                    Utils.GetLogger().Debug("Running the insert bulk for Products");
                    copy.DestinationTableName = "productos";
                    copy.WriteToServer(ds.Tables["Productos"]);
                }
                tranProd.Commit();
                
                SqlTransaction tranStock = _connection.BeginTransaction();
                ids = string.Empty;
                Utils.GetLogger().Debug("Preparing the delete query for Stock");
                foreach (DataRow row in ds.Tables["Stock"].Rows)
                {
                    ids += "'" + row[0] + "',";
                }
                if (ids.Length > 0)
                {
                    ids = ids.Substring(0, ids.Length - 1);
                    delete = "delete from stock where partcode in (" + ids + ")";
                    Utils.GetLogger().Debug(string.Format("Running the delete query for Stock: {0} ", ds.Tables["Stock"].Rows.Count));
                    Execute(delete, _connection, tranStock);
                    
                }
                using (SqlBulkCopy copy = new SqlBulkCopy(_connection, new SqlBulkCopyOptions(), tranStock))
                {
                    Utils.GetLogger().Debug("Running the insert bulk for Stock");
                    copy.DestinationTableName = "stock";
                    copy.WriteToServer(ds.Tables["Stock"]);
                }
                tranStock.Commit();

                _connection.Close();
            }
            return ActualizarDespiece(ds, server);
        }

        private static bool ActualizarDespiece(DataSet ds, string server)
        {
            List<string[]> ids = new List<string[]>();
            Utils.GetLogger().Debug("Prepating the delete query for Despiece");

            using (SqlConnection _connection = new SqlConnection(server))
            {
                _connection.Open();
                SqlTransaction tranDesp = _connection.BeginTransaction();
                
                foreach (DataRow row in ds.Tables["Despiece"].Rows)
                {
                    string[] desp = new string[2];
                    desp[0] = "'" + row[0] + "'";
                    desp[1] = "'" + row[1] + "'";
                    ids.Add(desp);
                }
                Utils.GetLogger().Debug(string.Format("Running the delete query for Despiece: {0} ", ds.Tables["Despiece"].Rows.Count));
                foreach (string[] s in ids)
                {
                    string delete = "delete from despiece where productcode = " + s[0] + " and partcode = " + s[1];
                    Execute(delete, _connection, tranDesp);
                }

                Utils.GetLogger().Debug("Running the insert bulk for Despiece");
                using (SqlBulkCopy copy = new SqlBulkCopy(_connection, new SqlBulkCopyOptions(), tranDesp))
                {
                    copy.DestinationTableName = "despiece";
                    copy.WriteToServer(ds.Tables["Despiece"]);
                }
                Utils.GetLogger().Debug("Running the exclude products cleaning for Despiece");
                string cmddelete = "delete from despiece where productcode in (select codigo from excluidos) OR partcode in (select codigo from excluidos)";
                Execute(cmddelete, _connection, tranDesp);

                tranDesp.Commit();
                _connection.Close();
            }
            Utils.GetLogger().Debug("Process finished correctly");
            Log("Process Finished", "Actualizacion", server);
            return true;
        }

        #region Common Methods

        private static void Execute(string query, SqlConnection myConnetion, SqlTransaction myTransaction)
        {
            if (string.IsNullOrEmpty(query))
                return;
            
            SqlCommand comLog = new SqlCommand();
            comLog.CommandText = query;
            comLog.Connection = myConnetion;
            comLog.Transaction = myTransaction;

            comLog.ExecuteNonQuery();
        }

        public static void Log(string message, string proceso, string server)
        {
            if (string.IsNullOrEmpty(message))
                message = "Process Executed";

            using (SqlConnection myConnection = new SqlConnection(server))
            {
                SqlCommand comLog = new SqlCommand();
                comLog.CommandText = "insert into log (actualizacion, proceso, excepcion) values ('" +
                                             DateTime.Now.AddHours(Config.TimeZoneFix).ToString("yyyyMMdd HH:mm:ss") + "','" + proceso + "', '" + message + "')";
                comLog.Connection = myConnection;
                try
                {
                    myConnection.Open();
                    comLog.ExecuteNonQuery();
                    myConnection.Close();
                }
                catch { }
            }
        }

        private static void TimeZoneBlackedFix(DataSet ds)
        {
            foreach (DataRow dataRow in ds.Tables["PO"].Rows)
                dataRow[3] = Convert.ToDateTime(dataRow[3]).AddHours(Config.TimeZoneFix);
        }

        #endregion
    }
}
