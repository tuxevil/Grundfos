using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Grundfos_Despiece
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Server.ScriptTimeout = 3600;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataSet prueba = new DataSet();
            prueba.ReadXml(HttpContext.Current.Server.MapPath("~/interno/Codigos2.xml"));



            GridView1.DataSource = prueba;
            GridView1.DataBind();

            foreach (DataRow dr in prueba.Tables[0].Rows)
            {
                string connectionString = "data source=dbserver;User ID=grundfos;Password=grundfos;database=Grundfos_StockViewerInterface";
                SqlConnection con = new SqlConnection(connectionString);
                string insert = "insert into products (codigo) values ('" + dr.ItemArray[0].ToString() + "')";

                con.Open();
                SqlCommand com = new SqlCommand(insert, con);

                SqlDataReader reader = com.ExecuteReader();

                reader.Read();

                reader.Close();

                con.Close();

            }

        }
    }
}
