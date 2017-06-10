using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net;
using System.IO;

namespace Grundfos_Despiece
{
    public partial class Calculo : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Server.ScriptTimeout = 3600;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //string connectionString = "data source=BGA_SQL02;User ID=scala;Password=scala;database=scalaDB";
            
            string sqlordcomp = "SELECT dbo.SC060100.SC06003 AS Producto, dbo.PC030100.PC03010 AS PurchaseOrders, PC030100.PC03016 as FechaArribo";
            sqlordcomp += " FROM dbo.PC030100";
            sqlordcomp += " INNER JOIN dbo.SC060100";
            sqlordcomp += " ON dbo.PC030100.PC03005 = dbo.SC060100.SC06003";
            sqlordcomp += " WHERE (dbo.PC030100.PC03016 >= '" + DateTime.Today.ToString("yyyyMMdd") + "') and (dbo.PC030100.PC03016 < '" + DateTime.Today.AddDays(84).ToString("yyyyMMdd") + "') and (dbo.PC030100.PC03029 = '1')";
            sqlordcomp += " group by dbo.SC060100.SC06003, dbo.PC030100.PC03010, PC030100.PC03016";
            sqlordcomp += " order by dbo.PC030100.PC03016";

            string sqlordcomp2 = "SELECT Grundfos_StockViewerInterface.dbo.products.codigo AS Producto, dbo.PC030100.PC03010 AS PurchaseOrders, PC030100.PC03016 as FechaArribo";
            sqlordcomp2 += " FROM dbo.PC030100";
            sqlordcomp2 += " INNER JOIN Grundfos_StockViewerInterface.dbo.products";
            sqlordcomp2 += " ON dbo.PC030100.PC03005 = Grundfos_StockViewerInterface.dbo.products.codigo";
            sqlordcomp2 += " WHERE (dbo.PC030100.PC03016 >= '" + DateTime.Today.ToString("yyyyMMdd") + "') and (dbo.PC030100.PC03016 < '" + DateTime.Today.AddDays(84).ToString("yyyyMMdd") + "') and (dbo.PC030100.PC03029 = '1')";
            sqlordcomp2 += " group by Grundfos_StockViewerInterface.dbo.products.codigo, dbo.PC030100.PC03010, PC030100.PC03016";
            sqlordcomp2 += " order by dbo.PC030100.PC03016";

            string sqldespiece = "select SC06002 as Producto, SC06003 as Parte, SC06004 as CantReq";
            sqldespiece += " from SC060100";
            sqldespiece += " where SC06001='B' and SC06004 > 0";
            sqldespiece += " order by SC06002";

            string sqlstock = "select isnull(D.Parte, E.Parte) as Parte, isnull(D.StockAct, E.StockAct) as StockAct, isnull(D.Sustituto, E.Sustituto) as Sustituto, isnull(D.FechaSust, E.FechaSust) as FechaSust from";
            sqlstock += " (select isnull(B.Parte, C.Parte) as Parte, isnull(B.StockAct, C.StockAct) as StockAct, isnull(B.Sustituto, C.Sustituto) as Sustituto, isnull(B.FechaSust, C.FechaSust) as FechaSust from";
            sqlstock += " (	select SC06003 as Parte, A.suma as StockAct, SC01089 as Sustituto, SC01125 as FechaSust";
            sqlstock += " from SC060100";
            sqlstock += " inner join";
            sqlstock += " (select SC03001 as producto, sum(SC03003-SC03004) as suma";
            sqlstock += " from SC030100";
            sqlstock += " where (SC03002='01' or SC03002='09')";
            sqlstock += " group by SC03001";
            sqlstock += " ) A";
            sqlstock += " on A.producto = SC060100.SC06003";
            sqlstock += " left outer join SC010100";
            sqlstock += " on SC010100.SC01001 = SC060100.SC06003";
            sqlstock += " where SC06001='B'";
            sqlstock += " group by SC060100.SC06003, A.suma, SC01089, SC01125";
            sqlstock += " )B";
            sqlstock += " full outer join";
            sqlstock += " (	select SC06002 as Parte, A.suma as StockAct, SC01089 as Sustituto, SC01125 as FechaSust";
            sqlstock += " from SC060100";
            sqlstock += " inner join";
            sqlstock += " (select SC03001 as producto, sum(SC03003-SC03004) as suma";
            sqlstock += " from SC030100";
            sqlstock += " where (SC03002='01' or SC03002='03' or SC03002='05' or SC03002='08' or SC03002='09')";
            sqlstock += " group by SC03001";
            sqlstock += " ) A";
            sqlstock += " on A.producto = SC060100.SC06002";
            sqlstock += " left outer join SC010100";
            sqlstock += " on SC010100.SC01001 = SC060100.SC06002";
            sqlstock += " where SC06001='B'";
            sqlstock += " group by SC060100.SC06002, A.suma, SC01089, SC01125";
            sqlstock += " ) C";
            sqlstock += " on C.Parte = B.Parte";
            sqlstock += " )D";
            sqlstock += " full outer join";
            sqlstock +=
                " (select SC01089 as Parte, sum(SC03003-SC03004) as StockAct, '' as Sustituto, SC01125 as FechaSust";
            sqlstock += " from SC010100";
            sqlstock += " inner join SC030100";
            sqlstock += " on SC010100.SC01089 = SC030100.SC03001";
            sqlstock += " right outer join (select SC060100.SC06003 as Parte from SC060100 group by SC06003) A";
            sqlstock += " on SC010100.SC01001 = A.Parte";
            sqlstock +=
                " where (SC03002='01' or SC03002='03' or SC03002='05' or SC03002='08' or SC03002='09') and SC01089 is not null and SC01089 != ' '";
            sqlstock += " group by SC010100.SC01089, SC010100.SC01125";
            sqlstock += " )E";
            sqlstock += " on D.Parte = E.Parte";
            sqlstock += " order by Parte";

            string sqlstock2 = "select isnull(C.codigo,D.codigo), isnull(C.stock,D.stock), isnull(C.alternativo,D.alternativo), isnull(C.fechaalt,D.fechaalt)";
            sqlstock2 += " from";
            sqlstock2 += " (select Grundfos_StockViewerInterface.dbo.products.codigo as codigo, sum(SC03003-SC03004) as stock, SC01089 as alternativo, SC01125 as fechaalt";
            sqlstock2 += " from SC030100";
            sqlstock2 += " inner join Grundfos_StockViewerInterface.dbo.products";
            sqlstock2 += " on Grundfos_StockViewerInterface.dbo.products.codigo = SC03001";
            sqlstock2 += " inner join SC010100";
            sqlstock2 += " on SC01001 = SC03001";
            sqlstock2 += " group by Grundfos_StockViewerInterface.dbo.products.codigo, SC03001, SC01089, SC01125) C";
            sqlstock2 += " full outer join";
            sqlstock2 += " (select B.codigo as codigo, B.stock as stock, B.alternativo as alternativo, B.fechaalt as fechaalt from";
            sqlstock2 += " (select Grundfos_StockViewerInterface.dbo.products.codigo as codigo, sum(SC03003-SC03004) as stock, SC01089 as alternativo, SC01125 as fechaalt";
            sqlstock2 += " from SC030100";
            sqlstock2 += " inner join Grundfos_StockViewerInterface.dbo.products";
            sqlstock2 += " on Grundfos_StockViewerInterface.dbo.products.codigo = SC03001";
            sqlstock2 += " inner join SC010100";
            sqlstock2 += " on SC01001 = SC03001";
            sqlstock2 += " group by Grundfos_StockViewerInterface.dbo.products.codigo, SC03001, SC01089, SC01125) A";
            sqlstock2 += " inner join (select SC03001 as codigo, sum(SC03003-SC03004) as stock, SC01089 as alternativo, SC01125 as fechaalt";
            sqlstock2 += " from SC030100";
            sqlstock2 += " inner join SC010100";
            sqlstock2 += " on SC01001 = SC03001";
            sqlstock2 += " group by SC03001, SC03001, SC01089, SC01125) B";
            sqlstock2 += " on A.alternativo = B.codigo) D";
            sqlstock2 += " on C.codigo = D.codigo";

            string sqlproductos = "select distinct(isnull(C.codigo, D.codigo)) as codigo, isnull(C.descripcion, D.descripcion) as descripcion";
            sqlproductos += " from";
            sqlproductos += " (select distinct(isnull(A.codigo, B.codigo)) as codigo, isnull(A.descripcion, B.descripcion) as descripcion";
            sqlproductos += " from (select distinct(SC06002) as codigo, SC01002 as descripcion from SC060100 inner join SC010100 on SC01001 = SC06002 where SC06001 = 'B') A";
            sqlproductos += " full outer join (select distinct(SC06003) as codigo, SC01002 as descripcion from SC060100 inner join SC010100 on SC01001 = SC06003 where SC06001 = 'B') B";
            sqlproductos += " on B.codigo = A.codigo) C";
            sqlproductos += " full outer join";
            sqlproductos += " (select Grundfos_StockViewerInterface.dbo.products.codigo as codigo, SC01002 as descripcion";
            sqlproductos += " from Grundfos_StockViewerInterface.dbo.products";
            sqlproductos += " inner join SC010100";
            sqlproductos += " on Grundfos_StockViewerInterface.dbo.products.codigo = SC01001) D";
            sqlproductos += " on C.codigo = D.codigo";

            SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ScalaSqlServer"].ToString());

            SqlDataAdapter daordcomp = new SqlDataAdapter(sqlordcomp, myConnection);
            SqlDataAdapter daordcomp2 = new SqlDataAdapter(sqlordcomp2, myConnection);
            SqlDataAdapter dadespiece = new SqlDataAdapter(sqldespiece, myConnection);
            SqlDataAdapter dastock = new SqlDataAdapter(sqlstock, myConnection);
            SqlDataAdapter dastock2 = new SqlDataAdapter(sqlstock2, myConnection);
            SqlDataAdapter daproductos = new SqlDataAdapter(sqlproductos, myConnection);

            daordcomp.SelectCommand.CommandTimeout = 300;
            daordcomp2.SelectCommand.CommandTimeout = 300;
            dastock.SelectCommand.CommandTimeout = 300;
            dastock2.SelectCommand.CommandTimeout = 300;
            dadespiece.SelectCommand.CommandTimeout = 600;
            daproductos.SelectCommand.CommandTimeout = 600;

            DataSet ds = new DataSet();
            DataSet ds2 = new DataSet();

            ds.Tables.Add("PO");
            ds.Tables.Add("Stock");
            ds.Tables.Add("PO2");
            ds.Tables.Add("Stock2");
            ds.Tables.Add("Productos");
            ds2.Tables.Add("Despiece");

            try
            {
                daordcomp.Fill(ds.Tables["PO"]);
                daordcomp2.Fill(ds.Tables["PO2"]);
                dastock.Fill(ds.Tables["Stock"]);
                dastock2.Fill(ds.Tables["Stock2"]);
                daproductos.Fill(ds.Tables["Productos"]);
                dadespiece.Fill(ds2.Tables["Despiece"]);

                ds.WriteXml("c:/PruebasDesarme/transac.xml");
                ds2.WriteXml("c:/PruebasDesarme/despiece.xml");

                //Upload("transac.xml");
                //Upload("despiece.xml");
            }
            catch (Exception ex)
            {
       
            }

        }

        private void Upload(string filename)
        {
            string ftpServerIP = "72.232.50.186";
            string ftpUserID = "automatic";
            string ftpPassword = "grundfos324";

            FileInfo fileInf = new FileInfo("c:/PruebasDesarme/" + filename);
            string uri = "ftp://" + ftpServerIP + "/" + fileInf.Name;
            FtpWebRequest reqFTP;
            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpServerIP + "/" + fileInf.Name));
            reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
            reqFTP.KeepAlive = false;
            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
            reqFTP.UseBinary = true;
            reqFTP.ContentLength = fileInf.Length;
            int buffLength = 2048;
            byte[] buff = new byte[buffLength];
            int contentLen;
            FileStream fs = fileInf.OpenRead();
            try
            {
                Stream strm = reqFTP.GetRequestStream();
                contentLen = fs.Read(buff, 0, buffLength);
                while (contentLen != 0)
                {
                    strm.Write(buff, 0, contentLen);
                    contentLen = fs.Read(buff, 0, buffLength);
                }
                strm.Close();
                fs.Close();
            }
            catch
            {
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            DataSet prueba = new DataSet();
            prueba.ReadXml(HttpContext.Current.Server.MapPath("~/images/despiece.xml"));

            GridView1.DataSource = prueba;
            GridView1.DataBind();

        }
    }
}