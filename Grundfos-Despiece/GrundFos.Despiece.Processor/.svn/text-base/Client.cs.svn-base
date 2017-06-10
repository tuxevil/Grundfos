using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using ProjectBase.Utils.Email;
using GrundFos.Despiece.Common;

namespace GrundFos.Despiece.Processor
{
    public class Client
    {
        public static bool Execute()
        {
            DateTime startdate = DateTime.Today.AddMonths(-1);
            DateTime enddate = DateTime.Today.AddDays(84);

            Utils.GetLogger().Debug(string.Format("Preparing queries for {0} to {1}", startdate.ToShortDateString(), enddate.ToShortDateString()));

            string sqlordcomp = "SELECT distinct dbo.PC030100.PC03001 AS OrdCompra, dbo.SC060100.SC06003 AS Producto, CAST((dbo.PC030100.PC03010-dbo.PC030100.PC03011) as int) AS PurchaseOrders, PC030100.PC03016 as FechaArribo";
            sqlordcomp += " FROM dbo.PC030100";
            sqlordcomp += " INNER JOIN dbo.SC060100";
            sqlordcomp += " ON dbo.PC030100.PC03005 = dbo.SC060100.SC06003";
            sqlordcomp += " LEFT JOIN Grundfos_StockViewerInterface.dbo.ordcompras OC";
            sqlordcomp += " ON OC.id = dbo.PC030100.PC03001 AND OC.productcode = dbo.SC060100.SC06003";
            sqlordcomp += " WHERE (dbo.PC030100.PC03016 >= '" + startdate.ToString("yyyyMMdd") + "') and (dbo.PC030100.PC03016 < '" + enddate.ToString("yyyyMMdd") + "') and (dbo.PC030100.PC03029 = '1') and dbo.PC030100.PC03010-dbo.PC030100.PC03011 > 0 and PC030100.PC03035 = '01' and (OC.id is null or CAST((dbo.PC030100.PC03010-dbo.PC030100.PC03011) as int) != OC.quantity OR PC030100.PC03016  != OC.date)";
            sqlordcomp += " UNION";
            sqlordcomp += " SELECT distinct dbo.PC030100.PC03001 AS OrdCompra, P.codigo AS Producto, CAST((dbo.PC030100.PC03010-dbo.PC030100.PC03011) as int) AS PurchaseOrders, PC030100.PC03016 as FechaArribo";
            sqlordcomp += " FROM dbo.PC030100";
            sqlordcomp += " INNER JOIN Grundfos_StockViewerInterface.dbo.products P";
            sqlordcomp += " ON dbo.PC030100.PC03005 = P.codigo";
            sqlordcomp += " LEFT JOIN Grundfos_StockViewerInterface.dbo.ordcompras OC";
            sqlordcomp += " ON OC.id = dbo.PC030100.PC03001 AND OC.productcode = P.codigo";
            sqlordcomp += " WHERE (dbo.PC030100.PC03016 >= '" + startdate.ToString("yyyyMMdd") + "') and (dbo.PC030100.PC03016 < '" + enddate.ToString("yyyyMMdd") + "') and (dbo.PC030100.PC03029 = '1') and dbo.PC030100.PC03010-dbo.PC030100.PC03011 > 0 and PC030100.PC03035 = '01' and (OC.id is null or CAST((dbo.PC030100.PC03010-dbo.PC030100.PC03011) as int) != OC.quantity OR PC030100.PC03016  != OC.date)";
            sqlordcomp += " order by dbo.PC030100.PC03016";

            string sqldespiece = "select SC06002 as Producto, SC06003 as Parte, CAST(SC06004 as int) as CantReq";
            sqldespiece += " from SC060100";
            sqldespiece += " LEFT JOIN Grundfos_StockViewerInterface.dbo.despiece D";
            sqldespiece += " on SC06002 = D.productcode and SC06003 = D.partcode";
            sqldespiece += " where SC06001='B' and SC06004 > 0 and (D.productcode is null or D.quantity != CAST(SC06004 as int))";
            sqldespiece += " order by SC06002";

            string sqlstock = "select SC06003 as Parte, A.StockAct as StockAct, SC01089 as Sustituto, SC01125 as FechaSust";
            sqlstock += " from SC060100 P";
            sqlstock += " inner join (select SC03001 as Parte, sum(distinct SC03003-SC03004-SC03005) as StockAct from SC030100 where SC03002 in('01', '03', '05', '08', '09')	group by SC03001) A";
            sqlstock += " on A.Parte = P.SC06003";
            sqlstock += " left outer join SC010100 PR";
            sqlstock += " on PR.SC01001 = P.SC06003";
            sqlstock += " LEFT JOIN Grundfos_StockViewerInterface.dbo.stock ST";
            sqlstock += " ON ST.partcode = P.SC06003";
            sqlstock += " where SC06001='B' and (ST.partcode is null or ST.alternative != PR.SC01089 or ST.datealternative != PR.SC01125 or ST.quantity != A.StockAct) ";
            sqlstock += " UNION";
            sqlstock += " select SC06002 as Parte, A.StockAct as StockAct, SC01089 as Sustituto, SC01125 as FechaSust";
            sqlstock += " from SC060100 P";
            sqlstock += " inner join (select SC03001 as Parte, sum(distinct SC03003-SC03004-SC03005) as StockAct from SC030100 where SC03002 in('01', '03', '05', '08', '09')	group by SC03001) A";
            sqlstock += " on A.Parte = P.SC06002";
            sqlstock += " left outer join SC010100 PR";
            sqlstock += " on PR.SC01001 = P.SC06002";
            sqlstock += " LEFT JOIN Grundfos_StockViewerInterface.dbo.stock ST";
            sqlstock += " ON ST.partcode = P.SC06002";
            sqlstock += " where SC06001='B' and (ST.partcode is null or ST.alternative != PR.SC01089 or ST.datealternative != PR.SC01125 or ST.quantity != A.StockAct)";
            sqlstock += " UNION";
            sqlstock += " select P.SC01001 as Parte, A.StockAct as StockAct, P.SC01089 as Sustituto, P.SC01125 as FechaSust";
            sqlstock += " from SC010100 P";
            sqlstock += " inner join SC010100 P2";
            sqlstock += " on P2.SC01001 = P.SC01089";
            sqlstock += " inner join (select SC03001 as Parte, sum(distinct SC03003-SC03004-SC03005) as StockAct from SC030100 where SC03002 in('01', '03', '05', '08', '09')	group by SC03001) A";
            sqlstock += " on A.Parte = P.SC01001";
            sqlstock += " right outer join (select SC060100.SC06003 as Parte from SC060100 group by SC06003) B";
            sqlstock += " on P.SC01001 = B.Parte";
            sqlstock += " LEFT JOIN Grundfos_StockViewerInterface.dbo.stock ST";
            sqlstock += " ON ST.partcode = P.SC01001";
            sqlstock += " where P.SC01001 is not null and P.SC01001 != ' ' and (ST.partcode is null or ST.datealternative != P.SC01125 or ST.quantity != A.StockAct)";
            sqlstock += " UNION";
            sqlstock += " select Grundfos_StockViewerInterface.dbo.products.codigo as Parte, A.StockAct as StockAct, SC01089 as Sustituto, SC01125 as FechaSust";
            sqlstock += " from Grundfos_StockViewerInterface.dbo.products";
            sqlstock += " inner join (select SC03001 as Parte, sum(distinct SC03003-SC03004-SC03005) as StockAct from SC030100 where SC03002 in('01', '03', '05', '08', '09')	group by SC03001) A";
            sqlstock += " on A.Parte = Grundfos_StockViewerInterface.dbo.products.codigo";
            sqlstock += " left outer join SC010100 PR";
            sqlstock += " on SC01001 = Grundfos_StockViewerInterface.dbo.products.codigo";
            sqlstock += " LEFT JOIN Grundfos_StockViewerInterface.dbo.stock ST";
            sqlstock += " ON ST.partcode = Grundfos_StockViewerInterface.dbo.products.codigo";
            sqlstock += " where (ST.partcode is null or ST.alternative != PR.SC01089 or ST.datealternative != PR.SC01125 or ST.quantity != A.StockAct)";
            sqlstock += " UNION";
            sqlstock += " select SC01001 as Parte, A.StockAct as StockAct, SC01089 as Sustituto, SC01125 as FechaSust";
            sqlstock += " from SC010100 P";
            sqlstock += " inner join (select SC03001 as Parte, sum(distinct SC03003-SC03004-SC03005) as StockAct from SC030100 where SC03002 in('01', '03', '05', '08', '09')	group by SC03001) A";
            sqlstock += " on A.Parte = SC01001";
            sqlstock += " LEFT JOIN Grundfos_StockViewerInterface.dbo.stock ST";
            sqlstock += " ON ST.partcode = P.SC01001";
            sqlstock += " where SC01001 in(select SC01089 as alternativo";
            sqlstock += " from SC030100";
            sqlstock += " inner join Grundfos_StockViewerInterface.dbo.products";
            sqlstock += " on Grundfos_StockViewerInterface.dbo.products.codigo = SC03001";
            sqlstock += " inner join SC010100";
            sqlstock += " on SC01001 = SC03001";
            sqlstock += " where SC03002 in('01', '03', '05', '08', '09') and SC01089 != ' ') ";
            sqlstock += " and (ST.partcode is null or ST.alternative != P.SC01089 or ST.datealternative != P.SC01125 or ST.quantity != A.StockAct)";
            sqlstock += " order by Parte";

            string sqlproductos = "select distinct(SC06002) as codigo, SC01002 as descripcion";
            sqlproductos += " from SC060100";
            sqlproductos += " inner join SC010100 on SC01001 = SC06002";
            sqlproductos += " LEFT JOIN Grundfos_StockViewerInterface.dbo.productos P";
            sqlproductos += " ON P.productcode = SC06002";
            sqlproductos += " where SC06001 = 'B' and (P.description != SC01002 or P.description is null)";
            sqlproductos += " UNION";
            sqlproductos += " select distinct(SC06003) as codigo, SC01002 as descripcion";
            sqlproductos += " from SC060100";
            sqlproductos += " inner join SC010100 on SC01001 = SC06003";
            sqlproductos += " LEFT JOIN Grundfos_StockViewerInterface.dbo.productos P";
            sqlproductos += " ON P.productcode = SC06003";
            sqlproductos += " where SC06001 = 'B' and (P.description != SC01002 or P.description is null)";
            sqlproductos += " UNION";
            sqlproductos += " select Grundfos_StockViewerInterface.dbo.products.codigo as codigo, SC01002 as descripcion";
            sqlproductos += " from Grundfos_StockViewerInterface.dbo.products";
            sqlproductos += " inner join SC010100";
            sqlproductos += " on Grundfos_StockViewerInterface.dbo.products.codigo = SC01001";
            sqlproductos += " LEFT JOIN Grundfos_StockViewerInterface.dbo.productos P";
            sqlproductos += " ON P.productcode = Grundfos_StockViewerInterface.dbo.products.codigo";
            sqlproductos += " where (P.description != SC01002 or P.description is null)";

            DataSet ds = new DataSet();

            Utils.GetLogger().Debug("Preparing connection");
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ScalaSqlServer"].ToString()))
            {
                Utils.GetLogger().Debug("Preparing DataAdapters");
                SqlDataAdapter daordcomp = new SqlDataAdapter(sqlordcomp, myConnection);
                SqlDataAdapter dadespiece = new SqlDataAdapter(sqldespiece, myConnection);
                SqlDataAdapter dastock = new SqlDataAdapter(sqlstock, myConnection);
                SqlDataAdapter daproductos = new SqlDataAdapter(sqlproductos, myConnection);

                daordcomp.SelectCommand.CommandTimeout = 600;
                dastock.SelectCommand.CommandTimeout = 600;
                dadespiece.SelectCommand.CommandTimeout = 300;
                daproductos.SelectCommand.CommandTimeout = 300;

                Utils.GetLogger().Debug("Creating DataSet");
                ds.Tables.Add("PO");
                ds.Tables.Add("Stock");
                ds.Tables.Add("Productos");
                ds.Tables.Add("Despiece");

                Utils.GetLogger().Debug("Fill PO Dataset Table");
                daordcomp.Fill(ds.Tables["PO"]);
                Utils.GetLogger().Debug(string.Format("New Records Found: {0}", ds.Tables["PO"].Rows.Count));

                Utils.GetLogger().Debug("Fill Stock Dataset Table");
                dastock.Fill(ds.Tables["Stock"]);
                Utils.GetLogger().Debug(string.Format("New Records Found: {0}", ds.Tables["Stock"].Rows.Count));

                Utils.GetLogger().Debug("Fill Productos Dataset Table");
                daproductos.Fill(ds.Tables["Productos"]);
                Utils.GetLogger().Debug(string.Format("New Records Found: {0}", ds.Tables["Productos"].Rows.Count));

                Utils.GetLogger().Debug("Fill Despiece Dataset Table");
                dadespiece.Fill(ds.Tables["Despiece"]);
                Utils.GetLogger().Debug(string.Format("New Records Found: {0}", ds.Tables["Despiece"].Rows.Count));

                Utils.GetLogger().Debug("Closing connection");
                myConnection.Close();
            }

            Utils.GetLogger().Debug("Sending data through WebService");

            SendData(ds);

            Utils.GetLogger().Debug("Updating local data on migration");
            Server.ActualizarDatos(ds, ConfigurationManager.ConnectionStrings["MigrationSqlServer"].ConnectionString);

            return true;
        }

        

        private static void SendData (DataSet ds)
        {
            IntegrationService.integration service =  new IntegrationService.integration();
            service.UpdateDataCompleted += new GrundFos.Despiece.Processor.IntegrationService.UpdateDataCompletedEventHandler(service_UpdateDataCompleted);
            service.UpdateDataAsync(ds);
        }

        static void service_UpdateDataCompleted(object sender, GrundFos.Despiece.Processor.IntegrationService.UpdateDataCompletedEventArgs e)
        {
            if (e == null)
                return;

            if (e.Error != null)
                Utils.GetLogger().Debug(e.Error);
            else
                Utils.GetLogger().Debug(string.Format("Update Data Result: {0}", e.Result.ToString()));
        }
    }
}
