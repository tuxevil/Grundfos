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
using NybbleMembership;

namespace GrundFos.PriceManager.WebSite.admin.Importation.view
{
    public partial class _default : ImportPage
    {
        public Guid Id
        {
            get { return new Guid(ViewState["Id"].ToString()); }
            set { ViewState["Id"] = value.ToString(); }
        }

        public PriceImportLogStatus priceImportLogStatus
        {
            get { return (PriceImportLogStatus)ViewState["PILStatus"]; }
            set { ViewState["PILStatus"] = value; }
        }

        public int PageSize
        {
            get { return Convert.ToInt32(ViewState["PageSize"]); }
            set { ViewState["PageSize"] = value; }
        }

        public int PageNumber
        {
            get { return Convert.ToInt32(ViewState["PageNumber"]); }
            set { ViewState["PageNumber"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Pager1.PageChanged += Pager1_PageChanged;
            if (!Page.IsPostBack && !string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                Id = new Guid(Request.QueryString["id"]);
                LoadInfo();
            }
        }

        public void LoadInfo()
        {
            PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
            PageNumber = 1;
            priceImportLogStatus = PriceImportLogStatus.Error;
            liError.Attributes["class"] = "pressed";
            FillRepeater();
            PriceImport priceImport = ControllerManager.PriceImport.GetById(Id);
            lblPriceImport.Text = priceImport.Description;
            lblCod.Text = priceImport.Number.ToString();
            lblFile.Text = priceImport.File;

            lblNew.Text = priceImport.ImportView.AmountNew.ToString();
            lblModified.Text = priceImport.ImportView.AmountChange.ToString();
            lblErrors.Text = priceImport.ImportView.AmountError.ToString();

            MembershipHelperUser mhu = MembershipHelper.GetUser(priceImport.TimeStamp.ModifiedBy);
            if (mhu != null)
                lblUser.Text = mhu.UserName;

            if (priceImport.TimeStamp.ModifiedOn.HasValue)
                lblDate.Text = priceImport.TimeStamp.ModifiedOn.Value.ToShortDateString();

            lblStatus.Text = EnumHelper.GetDescription(priceImport.ImportStatus);

            if (priceImport.ImportStatus != ImportStatus.Verified && priceImport.ImportStatus != ImportStatus.VerifiedSomeInvalid)
                btnImport.Visible = false;

            if (priceImport.ImportView.AmountError == 0)
                btnErrorExport.Visible = false;
        }

        private void FillRepeater()
        {
            int totalcount;
            
            rpterPriceImportList.DataSource = ControllerManager.PriceImport.GetList(Id, priceImportLogStatus, PageSize, PageNumber, out totalcount);
            rpterPriceImportList.DataBind();

            Pager1.PageCount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(totalcount) / Convert.ToDouble(PageSize)));
            Pager1.CurrentPage = PageNumber;
            Pager1.Step = 10;
            Pager1.DataBind();

            lblSelectedCount.Text = totalcount.ToString();
        }

        protected void lnkAdd_Click(object sender, EventArgs e)
        {
            priceImportLogStatus = PriceImportLogStatus.Add;
            PageNumber = 1;
            liAdd.Attributes["class"] = "pressed";
            liError.Attributes["class"] = "";
            liMod.Attributes["class"] = "";
            FillRepeater();
            lblQuantitystatus.Text = lnkAdd.Text;
        }

        protected void lnkMod_Click(object sender, EventArgs e)
        {
            priceImportLogStatus = PriceImportLogStatus.Modify;
            PageNumber = 1;
            liAdd.Attributes["class"] = "";
            liError.Attributes["class"] = "";
            liMod.Attributes["class"] = "pressed";
            FillRepeater();
            lblQuantitystatus.Text = lnkMod.Text;
        }

        protected void lnkError_Click(object sender, EventArgs e)
        {
            priceImportLogStatus = PriceImportLogStatus.Error;
            PageNumber = 1;
            liAdd.Attributes["class"]= "";
            liError.Attributes["class"] = "pressed";
            liMod.Attributes["class"] = "";
            FillRepeater();
            lblQuantitystatus.Text = lnkError.Text;
        }

        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
            PageNumber = 1;
            FillRepeater();
        }

        private void Pager1_PageChanged(object sender, ctrl.Pager.PageChangedEventArgs e)
        {
            PageNumber = e.NewPageNumber;
            FillRepeater();
        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            try
            {
#if DEBUG 
                ControllerManager.PriceImport.Import(Id, MembershipHelper.GetUser().UserId);
#else
                ControllerManager.PriceImport.ImportOffLine(Id);
#endif
            }
            catch (Exception ex)
            {
                Utils.ShowMessage(Page, "Ocurrío un error al importar el archivo. Comuniquese con el administrador.", Utils.MessageType.Error);
                Utils.GetLogger().Error(ex);
                return;
            }

            LoadInfo();
            Utils.ShowMessage(Page, "La importación se ha enviado a procesar...", Utils.MessageType.Info);
        }

        protected void btnErrorExport_Click(object sender, EventArgs e)
        {
            MemoryStream ms = ControllerManager.PriceImport.Export(Id, PriceImportLogStatus.Error, Server.MapPath(Config.ImportFileFolder) + "\\");

            Response.Clear();
            Response.AppendHeader("Content-Disposition", "attachment;filename=export.csv");
            Response.ContentType = "application/octet-stream";
            Response.OutputStream.Write(ms.GetBuffer(), 0, (int)ms.Length);
            Response.OutputStream.Flush();
            Response.End();
        }

        protected void btnDownloadOriginalFile_Click(object sender, EventArgs e)
        {
            PriceImport pi = ControllerManager.PriceImport.GetById(Id);

            Byte[] imageBytes;
            imageBytes = File.ReadAllBytes(Server.MapPath(Config.ImportFileFolder) + "\\" + pi.ID + ".csv");

            Response.ContentType = "application/octet-stream";
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", Server.UrlEncode(pi.File)));
            Response.OutputStream.Write(imageBytes, 0, imageBytes.Length);
            Response.OutputStream.Flush();
            Response.End();
        }
    }
}
