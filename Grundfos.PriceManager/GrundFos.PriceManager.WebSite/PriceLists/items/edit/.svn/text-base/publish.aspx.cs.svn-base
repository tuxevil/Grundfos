using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using PriceManager;
using PriceManager.Business;
using PriceManager.Core;

namespace GrundFos.PriceManager.WebSite.PriceLists.items.edit
{
    public partial class publish : PriceListPage
    {
        private int _priceListID = 0;
        public int PriceListID
        {
            get
            {
                if (_priceListID == 0 && ViewState["PriceListId"] != null)
                    _priceListID = Convert.ToInt32(ViewState["PriceListId"]);

                return _priceListID;
            }
            set { ViewState["PriceListId"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack && !string.IsNullOrEmpty(Request.QueryString["Id"]))
            {
                PriceListID = Convert.ToInt32(Request.QueryString["Id"]);

                PriceList pl = ControllerManager.PriceList.GetById(PriceListID);
                litChangesCount.InnerText = pl.CurrentState.ModifiedSinceLastApproval.ToString();
                litPendingApprove.InnerText = pl.CurrentState.PendingToApproveCount.ToString();
                litPriceList.InnerText = pl.Name;

                if (ControllerManager.PriceList.GetCount(pl.ID) == 0)
                {
                    btnPublish.Enabled = false;
                    Flash.InnerHtml = "El Grupo de precios no contiene productos.";
                    Flash.Attributes["class"] = "flash_alert";
                    Flash.Visible = true;
                }
                else
                {
                    if (pl.CurrentState.PendingToApproveCount > 0 && pl.CurrentState.Status != PublishListStatus.Approved)
                    {
                        btnPublish.Enabled = false;
                        Flash.InnerHtml = "El Grupo de precios no se encuentra en estado Aprobado.<br>El mismo no podrá ser publicado.";
                        Flash.Attributes["class"] = "flash_alert";
                        Flash.Visible = true;
                    }
                    else
                    {
                        btnPublish.Visible = true;
                        formPub.Visible = true;
                        txtComercialConditions.Text = ControllerManager.Lookup.List(LookupType.ComercialCondition)[0].Description;
                        btnPublish.OnClientClick = "javascript : return confirm('¿Esta seguro que desea Publicar estos registros y enviar minutas?');";
                        if (pl.Distributors == null || pl.Distributors.Count == 0)
                        {
                            distributorsbox.Visible = false;
                            Utils.ShowMessage(this.Page, "No hay Canales de Venta asignados para este grupo de precios.", Utils.MessageType.Error);
                        }
                        else
                        {
                            rpterMails.DataSource = pl.Distributors;
                            rpterMails.DataBind();
                        }
                    }
                }

                rvDate.MinimumValue = DateTime.Now.ToShortDateString();
                rvDate.MaximumValue = DateTime.MaxValue.ToShortDateString();
            }
        }

        protected void btnPublish_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            string path = Server.MapPath("/img/") + "PdfHeader.GIF";
            PublishList pl =ControllerManager.PriceList.Publish(PriceListID, Convert.ToDateTime(txtDate.Text), txtComercialConditions.Text, txtBodyMail.Text, path);
            if (pl != null)
                Response.Redirect("/pricelists/items/published/?Id=" + PriceListID.ToString());
        }

        protected void ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem )
            {
                Distributor d = (e.Item.DataItem as Distributor);
                if (d != null)
                {
                    if (!string.IsNullOrEmpty(d.Email) || !string.IsNullOrEmpty(d.AlternativeEmail))
                    {
                        ((HtmlImage)e.Item.FindControl("imgPicture")).Src = "/img/okmail.jpg";
                        ((HtmlImage)e.Item.FindControl("imgPicture")).Attributes["title"] = "E-Mail Valido";
                    }
                    else
                    { 
                        ((HtmlImage)e.Item.FindControl("imgPicture")).Src = "/img/notmail.jpg";
                        ((HtmlImage)e.Item.FindControl("imgPicture")).Attributes["title"] = "No tiene E-Mail";
                    }
                }
            }
        }
    }
}
