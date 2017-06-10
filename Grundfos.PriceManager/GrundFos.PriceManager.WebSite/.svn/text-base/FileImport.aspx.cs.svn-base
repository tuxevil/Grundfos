using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using PriceManager.Business;
using PriceManager.Common;
using PriceManager.Core;


namespace GrundFos.PriceManager.WebSite
{
    public partial class FileImport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                TextBox4.Text = Config.SeparationCharacter.ToString();
                ListBox1.DataSource = ControllerManager.PriceImport.GetAll();
                ListBox1.DataTextField = "ID";
                ListBox1.DataValueField = "ID";
                ListBox1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(ListBox1.SelectedValue != null)
            {
                DateTime start = DateTime.Now;
                Label2.Text = start.ToShortTimeString();

                if (ControllerManager.PriceImport.Import(Convert.ToInt32(ListBox1.SelectedValue)))
                {
                    Label5.Text = "importacion correcta";
                    Label5.Visible = true;
                }
                else
                {
                    Label5.Text = "importacion fallida";
                    Label5.Visible = true;
                }
                DateTime finish = DateTime.Now;
                Label3.Text = finish.ToShortTimeString();
                TimeSpan ts = new TimeSpan();
                ts = finish - start;
                Label4.Text = ts.TotalSeconds.ToString();
            }
            else
                Label5.Text = "Seleccione un PriceImport";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (ListBox1.SelectedValue != null)
            {
                if (ControllerManager.PriceImport.Export(Convert.ToInt32(ListBox1.SelectedValue), PriceImportLogStatus.Error, Server.MapPath(Config.ImportFileFolder) + "\\"))
                {
                    Response.Clear();
                    Response.AppendHeader("content-disposition", "attachment; filename=export.csv");
                    Response.WriteFile(Server.MapPath(Config.ImportFileFolder) + "\\" + "export.csv");
                    Response.End();
                }
            }
            else
                Label5.Text = "Seleccione un PriceImport";
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            HttpPostedFile uploadedfile = fuArchImp.PostedFile;

            string mimeType = uploadedfile.ContentType;

            if (mimeType == "application/vnd.ms-excel")
            {
                string originalfilename = Path.GetFileName(uploadedfile.FileName);
                
                if(originalfilename.EndsWith(".csv"))
                {
                    string newfilename = DateTime.Now.Ticks.ToString() + ".csv";
                    uploadedfile.SaveAs(Server.MapPath(Config.ImportFileFolder) + "\\" + newfilename);
                    DateTime start = DateTime.Now;
                    Label2.Text = start.ToShortTimeString();
                    try
                    {
                        PriceImport pi = ControllerManager.PriceImport.Create(newfilename, TextBox2.Text, CheckBox1.Checked, Convert.ToChar(TextBox4.Text), Server.MapPath(Config.ImportFileFolder) + "\\", originalfilename);

                        DateTime finish = DateTime.Now;
                        Label3.Text = finish.ToShortTimeString();
                        TimeSpan ts = new TimeSpan();
                        ts = finish - start;
                        Label4.Text = ts.TotalSeconds.ToString();

                        FillGrids(pi.ID);
                        ListBox1.DataSource = ControllerManager.PriceImport.GetAll();
                        ListBox1.DataTextField = "ID";
                        ListBox1.DataValueField = "ID";
                        ListBox1.DataBind();
                    }
                    catch (Exception)
                    {
                        Label5.Text = "Hubo un error en la carga del archivo por favor reviselo y vuelva a intentarlo";
                    }
                }
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (ListBox1.SelectedValue != null)
            {
                if (ListBox1.SelectedValue != null)
                    FillGrids(Convert.ToInt32(ListBox1.SelectedValue));
                else
                    Label5.Text = "Seleccione un PriceImport";
            }
            else
                Label5.Text = "Seleccione un PriceImport";
        }

        private void FillGrids(int id)
        {
            int count;
            GridView1.DataSource = ControllerManager.PriceImport.GetList(id, PriceImportLogStatus.Add, 0, 0, out count);
            GridView2.DataSource = ControllerManager.PriceImport.GetList(id, PriceImportLogStatus.Modify, 0, 0, out count);
            GridView3.DataSource = ControllerManager.PriceImport.GetList(id, PriceImportLogStatus.Error, 0, 0, out count);
            GridView1.DataBind();
            GridView2.DataBind();
            GridView3.DataBind();
        }
    }
}
