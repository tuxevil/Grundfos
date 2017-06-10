using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using GrundFos.Despiece.Business;

namespace Grundfos_Despiece
{
    public partial class _Default : Page
    {
        private SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TextBox1.Focus();
                TextBox2.Text = DateTime.Today.ToShortDateString();
            }
            RangeValidator2.MinimumValue = DateTime.Today.ToString("dd/MM/yyyy");
            RangeValidator2.MaximumValue = DateTime.Today.AddDays(365).ToString("dd/MM/yyyy");
        }

        #region Search Products

        protected void BotonBuscar_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            ListBox2.Items.Clear();

            SqlDataReader dr;
            if (RadioButtonList1.SelectedValue == "1")
                dr = new Search().FindProducts(TextBox1.Text);
            else
                dr = new Search().FindProductsByCode(TextBox1.Text);

            while (dr.Read())
            {
                ListItem li = new ListItem();
                if (Convert.ToInt32(dr[2]) >= 0)
                    li.Text = dr[2].ToString().PadLeft(4, '0');
                else
                    li.Text = "0000";
                li.Text += " | ";
                li.Text += dr[0].ToString();
                li.Text += " | ";
                li.Text += dr[1].ToString();
                li.Value = dr[0].ToString();
                ListBox2.Items.Add(li);
            }
            if (!dr.HasRows)
            {
                ListItem li = new ListItem();
                li.Text = "No se encontró ningún resultado con la descripción o el código ingresado.";
                ListBox2.Items.Add(li);
                BotonSeleccionar.Enabled = false;
            }
            else
                BotonSeleccionar.Enabled = true;
            dr.Close();
        
            
        }

        protected void BotonSeleccionar_Click(object sender, EventArgs e)
        {
            if (ListBox2.SelectedItem != null)
            {
                TextBox1.Text = ListBox2.SelectedValue;
                Label2.Visible = true;
                TextBox2.Visible = true;
                Label3.Visible = true;
                TextBox3.Visible = true;
                Label5.Text = ListBox2.SelectedItem.ToString();
                Label5.Visible = true;
                MultiView1.SetActiveView(View2);
                //Form.DefaultButton = BotonConsultarStock.UniqueID;
            }
        }

        #endregion

        #region Search Stock

        protected void BotonConsultarStock_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            DateTime fechapedido = Convert.ToDateTime(TextBox2.Text);
            DateTime fechahoy = DateTime.Today;

            bool ensamblado ;

            DataSet final = new Stock().Calculo(TextBox1.Text, fechahoy, fechapedido, Convert.ToInt32(TextBox3.Text), out ensamblado);

            GridView1.DataSource = final;
            GridView1.DataBind();

            if(ensamblado == true)
                Label7.Visible = true;
            else
                Label7.Visible = false;

            SqlCommand comseguimiento = new SqlCommand("sp_seguimiento", myConnection);
            comseguimiento.CommandType = CommandType.StoredProcedure;
            comseguimiento.Parameters.Add("@usuario", SqlDbType.UniqueIdentifier).Value = Membership.GetUser().ProviderUserKey;
            comseguimiento.Parameters.Add("@fecha", SqlDbType.DateTime).Value = DateTime.Now;
            comseguimiento.Parameters.Add("@busqueda", SqlDbType.VarChar).Value = TextBox1.Text;
            comseguimiento.Parameters.Add("@fechabusqueda", SqlDbType.DateTime).Value = TextBox2.Text;
            comseguimiento.Parameters.Add("@cantidadbusqueda", SqlDbType.Int).Value = TextBox3.Text;
            comseguimiento.Parameters.Add("@ip", SqlDbType.BigInt).Value = Utils.ConvertIp(HttpContext.Current.Request.UserHostAddress);

            SqlDataReader drseguimiento;
            myConnection.Open();
            drseguimiento = comseguimiento.ExecuteReader();
            drseguimiento.Read();
            drseguimiento.Close();
            myConnection.Close();
            
            GridView1.DataSource = final;
            GridView1.DataBind();

            //Form.DefaultButton = BotonConsultarStock.UniqueID;
        }

        #endregion

        protected void ImageButton1_Click(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(View1);
            GridView1.DataSource = null;
            GridView1.DataBind();
            //Form.DefaultButton = BotonBuscar.UniqueID;
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {
            //Form.DefaultButton = BotonConsultarStock.UniqueID;
        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {
            //Form.DefaultButton = BotonConsultarStock.UniqueID;
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            //Form.DefaultButton = BotonBuscar.UniqueID;
        }

       
    }
}