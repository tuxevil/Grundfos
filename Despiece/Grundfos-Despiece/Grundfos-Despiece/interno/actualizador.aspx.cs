using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Data.SqlClient;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Grundfos_Despiece.interno
{
    public partial class actualizador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            ds.ReadXml(HttpContext.Current.Server.MapPath("~/transac.xml"));

            string cmddelete2 = "delete from ordcompras";
            string cmddelete3 = "delete from stock";
            string cmddelete4 = "delete from productos";

            SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);

            SqlCommand com2 = new SqlCommand(cmddelete2, myConnection);
            SqlCommand com3 = new SqlCommand(cmddelete3, myConnection);
            SqlCommand com5 = new SqlCommand(cmddelete4, myConnection);
            SqlDataReader dr;
            myConnection.Open();
            dr = com2.ExecuteReader();
            dr.Read();
            dr.Close();
            dr = com3.ExecuteReader();
            dr.Read();
            dr.Close();
            dr = com5.ExecuteReader();
            dr.Read();
            dr.Close();
            myConnection.Close();

            foreach (DataRow datar in ds.Tables["PO"].Rows)
            {
                string cmdinsert = "insert into ordcompras values ('" + datar.ItemArray[0] + "'," + datar.ItemArray[1] + ",'" + Convert.ToDateTime(datar.ItemArray[2]).ToString("yyyyMMdd") + "')";
                SqlCommand com4 = new SqlCommand(cmdinsert, myConnection);
                SqlDataReader dr2;
                myConnection.Open();
                dr2 = com4.ExecuteReader();
                dr2.Read();
                dr2.Close();
                myConnection.Close();
            }
            foreach (DataRow datar in ds.Tables["PO2"].Rows)
            {
                string cmdinsert = "insert into ordcompras values ('" + datar.ItemArray[0] + "'," + datar.ItemArray[1] + ",'" + Convert.ToDateTime(datar.ItemArray[2]).ToString("yyyyMMdd") + "')";
                SqlCommand com4 = new SqlCommand(cmdinsert, myConnection);
                SqlDataReader dr2;
                myConnection.Open();
                dr2 = com4.ExecuteReader();
                dr2.Read();
                dr2.Close();
                myConnection.Close();
            }
            foreach (DataRow datar in ds.Tables["Stock"].Rows)
            {
                string cmdinsert = "insert into stock values ('" + datar.ItemArray[0] + "'," + datar.ItemArray[1] + ",'" + datar.ItemArray[2] + "','" + Convert.ToDateTime(datar.ItemArray[3]).ToString("yyyyMMdd") + "')";
                SqlCommand com4 = new SqlCommand(cmdinsert, myConnection);
                SqlDataReader dr2;
                myConnection.Open();
                dr2 = com4.ExecuteReader();
                dr2.Read();
                dr2.Close();
                myConnection.Close();
            }
            foreach (DataRow datar in ds.Tables["Stock2"].Rows)
            {
                string cmdinsert = "insert into stock values ('" + datar.ItemArray[0] + "'," + datar.ItemArray[1] + ",'" + datar.ItemArray[2] + "','" + Convert.ToDateTime(datar.ItemArray[3]).ToString("yyyyMMdd") + "')";
                SqlCommand com4 = new SqlCommand(cmdinsert, myConnection);
                SqlDataReader dr2;
                myConnection.Open();
                dr2 = com4.ExecuteReader();
                dr2.Read();
                dr2.Close();
                myConnection.Close();
            }
            foreach (DataRow datar in ds.Tables["Productos"].Rows)
            {
                string cmdinsert = "insert into productos values ('" + datar.ItemArray[0] + "','" + datar.ItemArray[1] + "')";
                SqlCommand com4 = new SqlCommand(cmdinsert, myConnection);
                SqlDataReader dr2;
                myConnection.Open();
                dr2 = com4.ExecuteReader();
                dr2.Read();
                dr2.Close();
                myConnection.Close();
            }
        }
    }
}
