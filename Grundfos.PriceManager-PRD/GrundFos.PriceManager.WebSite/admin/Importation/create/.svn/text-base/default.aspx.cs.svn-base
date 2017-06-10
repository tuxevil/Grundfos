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
using PriceManager;
using PriceManager.Business;
using PriceManager.Common;
using PriceManager.Core;

namespace GrundFos.PriceManager.WebSite.admin.Importation.create
{
    public partial class _default : ImportPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
                Page.Master.FindControl("divtemplatedownload").Visible = true;
            btnUpload.OnClientClick = string.Format("if (longProcessClickWithMessage(this)) {0}; else return false;", ClientScript.GetPostBackEventReference(btnUpload, btnUpload.ID.ToString()));
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            HttpPostedFile uploadedfile = fuArchImp.PostedFile;

            string originalfilename = Path.GetFileName(uploadedfile.FileName);
            if (!originalfilename.ToLower().EndsWith(".csv"))
            {
                Utils.ShowMessage(Page, Resource.Business.GetString("PriceImportationExtensionError"), Utils.MessageType.Error);
                return;
            }
            else if (uploadedfile.ContentLength == 0)
            {
                Utils.ShowMessage(Page, Resource.Business.GetString("PriceImportationEmptyFileError"), Utils.MessageType.Error);
                return;
            }

            string newfilename = DateTime.Now.Ticks.ToString() + ".csv";
            uploadedfile.SaveAs(Server.MapPath(Config.ImportFileFolder) + "\\" + newfilename);

            PriceImport pi;

            try
            {
                pi = ControllerManager.PriceImport.Create(newfilename, txtDescription.Text, chkHeader.Checked, Convert.ToChar(ddlCharacter.SelectedValue), Server.MapPath(Config.ImportFileFolder) + "\\", originalfilename);
            }
            catch (Exception ex)
            {
                if (ex is FileHelpers.ConvertException || ex is FileHelpers.FileHelpersException || ex is EmptyImportationFileException)
                {
                    Utils.ShowMessage(Page, ex.Message, Utils.MessageType.Error);
                }
                else
                {
                    Utils.ShowMessage(Page, Resource.Business.GetString("PriceImportationError"), Utils.MessageType.Error);
                    Utils.GetLogger().Error(ex);
                }

                return;
            }

            Response.Redirect("/admin/importation/view/default.aspx?id=" + pi.ID);
        }
    }
}
