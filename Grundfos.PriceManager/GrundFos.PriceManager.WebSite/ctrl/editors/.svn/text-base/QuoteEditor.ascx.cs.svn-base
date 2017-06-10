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
using GrundFos.PriceManager.WebSite.ctrl.Viewers;
using PriceManager;
using PriceManager.Core;
using PriceManager.Business;
using System.Collections.Generic;
using PriceManager.Common;
using NybbleMembership;
using NybbleMembership.Core.Domain;

namespace GrundFos.PriceManager.WebSite.ctrl.editors
{
    public partial class QuoteEditor : System.Web.UI.UserControl
    {
        #region Properties
        
        public int QuoteId
        {
            get
            {
                if (ViewState["QuoteId"] != null)
                    return Convert.ToInt32(ViewState["QuoteId"]);
                else
                    return 0;
            }
            set { ViewState["QuoteId"] = value; }
        }

        public EditionMode Mode
        {
            get
            {
                if (ViewState["Type"] != null)
                    return (EditionMode)ViewState["Type"];
                return EditionMode.Edit;
            }
            set { 
                ViewState["Type"] = value;
                PriceMasterList1.AllowMultipleSelection = value != EditionMode.View;
                if (value == EditionMode.View)
                    PriceMasterList1.Type = MasterListType.QuoteProductsView;
                else
                    PriceMasterList1.Type = MasterListType.QuoteProductsCreate;
            }
        }

        #endregion

        #region Load

        public override void DataBind()
        {
            //if (Page.IsPostBack)
            {
                lblTitle.Text = "Nueva Cotización";
                ddlQuoteIntroText.DataSource = ControllerManager.Lookup.List(LookupType.QuoteIntroText);
                ddlQuoteIntroText.DataTextField = "Title";
                ddlQuoteIntroText.DataValueField = "ID";
                ddlQuoteIntroText.DataBind();
                ddlQuoteIntroText.Items.Insert(0, new ListItem("--Texto Introductorio--", "0"));

                ddlQuoteCondition.DataSource = ControllerManager.Lookup.List(LookupType.QuoteCondition);
                ddlQuoteCondition.DataTextField = "Title";
                ddlQuoteCondition.DataValueField = "ID";
                ddlQuoteCondition.DataBind();
                ddlQuoteCondition.Items.Insert(0, new ListItem("--Condición--", "0"));

                ddlQuoteVigency.DataSource = ControllerManager.Lookup.List(LookupType.QuoteVigency);
                ddlQuoteVigency.DataTextField = "Description";
                ddlQuoteVigency.DataValueField = "ID";
                ddlQuoteVigency.DataBind();

                ddlToCurrency.DataSource = ControllerManager.Currency.GetAll();
                ddlToCurrency.DataTextField = "Description";
                ddlToCurrency.DataValueField = "ID";
                ddlToCurrency.DataBind();
                
                PriceMasterList1.AllowMultipleSelection = true;

                if (PriceMasterList1.GridHelper == null)
                {
                    PriceMasterList1.GridHelper = new GridHelper();
                    PriceMasterList1.GridHelper.SortAscending = true;
                    
                }

                PriceMasterList1.GridHelper.PageSize = 10;
                
                LoadFields();

                PriceMasterList1.DataBind();

                SetVisibility();
            }
        }

        private void LoadFields()
        {
            if (QuoteId != 0)
            {
                Quote q = null;
                if (QuoteId > 0)
                {
                    q = ControllerManager.Quote.GetById(QuoteId);
                    Mode = EditionMode.Edit;
                }

                //if (!MembershipManager.IsAdministrator())
                ExecutePermissionValidator epv = new ExecutePermissionValidator();
                epv.ClassType = typeof(Quote);
                epv.KeyIdentifier = Config.SeeQuotes;

                if (PermissionManager.Check(epv) == false)
                {
                    PermissionManager.Validate(q);
                }

                if (q != null)
                {
                    if (q.Status == QuoteStatus.Sent)
                        Response.Redirect("/accessdenied.aspx");

                    if(!ControllerManager.Quote.ValidateQuote(q))
                        Utils.ShowMessage(this.Page, "Se modifico la información de la cotización.", Utils.MessageType.Warning);

                    txtDistributor.Text = q.Distributor.Name + "-[" + q.Distributor.Code + "]";
                    txtDescripcion.Text = q.Description;
                    txtObservations.Text = q.Observations;
                    
                    ContactsUpdate(q.Distributor);

                    string email = string.Empty;
                    string contact = string.Empty;
                    List<IQuoteNotification> toDelete = new List<IQuoteNotification>();
                    foreach (IQuoteNotification notification in q.QuoteNotifications)
                    {
                        if (notification is QuoteNotification)
                        {
                            email = notification.Email;
                            contact = notification.Name;
                        }
                        else
                        {
                            ListItem li = cblContacts.Items.FindByValue(((ContactQuoteNotification) notification).Contact.ID.ToString());
                            if(li != null)
                                li.Selected = true;
                            else
                                toDelete.Add(notification);
                        }
                    }

                    if(toDelete.Count > 0)
                        foreach (IQuoteNotification notification in toDelete)
                        {
                            q.QuoteNotifications.Remove(notification);
                        }

                    txtEmail.Text = email;
                    txtContact.Text = contact;

                    ddlQuoteCondition.SelectedValue = q.Condition.ID.ToString();
                    ddlQuoteIntroText.SelectedValue = q.IntroText.ID.ToString();
                    ddlQuoteVigency.SelectedValue = q.Vigency.ID.ToString();

                    foreach (QuoteItem item in q.SortedQuoteItems)
                    {
                        PriceMasterList1.GridState.Items.Add(item.PriceBase.ID);
                        PriceMasterList1.HidSelChecks = PriceMasterList1.HidSelChecks + item.PriceBase.ID + ",";

                        HtmlAnchor a = new HtmlAnchor();
                        a.InnerText = "[x]";
                        a.Attributes["class"] = "removeItem";
                        a.Attributes["onclick"] = "removeItem()";
                        HtmlGenericControl h3 = new HtmlGenericControl("h3");
                        if (string.IsNullOrEmpty(item.PriceBase.Product.Code))
                            h3.InnerText = item.PriceBase.ProviderCode;
                        else
                            h3.InnerText = item.PriceBase.Product.Code;
                        HtmlGenericControl p = new HtmlGenericControl("p");
                        p.InnerText = item.PriceBase.Product.Model;
                        HtmlGenericControl li = new HtmlGenericControl("li");
                        li.Attributes["id"] = item.PriceBase.ID.ToString();
                        li.Controls.Add(a);
                        li.Controls.Add(h3);
                        li.Controls.Add(p);
                        productlist.Controls.Add(li);
                    }
                    if (PriceMasterList1.HidSelChecks.Length > 0)
                        PriceMasterList1.HidSelChecks = PriceMasterList1.HidSelChecks.Substring(0, PriceMasterList1.HidSelChecks.Length - 1);
                    //PriceMasterList1.AllowMultipleSelection = false;
                    //PriceMasterList1.QuoteId = q.ID;

                    if(q.Currency != null)
                    {
                        ddlToCurrency.SelectedValue = ddlToCurrency.Items.FindByValue(q.Currency.ID.ToString()).Value;
                        lblCurrencyRate.Text = ControllerManager.CurrencyRate.GetLast(q.Currency).Rate.ToString("(##0.####)");
                    }
                }
            }
        }


        protected void SetVisibility()
        {
            bool enabled = (Mode == EditionMode.Edit || Mode == EditionMode.Create);
            
            foreach (Control c in this.Controls)
                if (c is WebControl && c.GetType() != typeof(LinkButton) )
                    (c as WebControl).Enabled = enabled;

            btnSave.Visible = enabled;

            if(enabled)
                txtDistributor.Focus();
        }

        private void ContactsUpdate(Distributor distributor)
        {
            cblContacts.DataSource = distributor.ActiveContacts;
            cblContacts.DataTextField = "FullName";
            cblContacts.DataValueField = "ID";
            cblContacts.DataBind();
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
            {
                PriceMasterList1.RecreateFromJavascript();
                foreach (int item in PriceMasterList1.GridState.Items)
                {
                    PriceBase pb = ControllerManager.PriceBase.GetById(item);
                    HtmlAnchor a = new HtmlAnchor();
                    a.InnerText = "[x]";
                    a.Attributes["class"] = "removeItem";
                    a.Attributes["onclick"] = "removeItem()";
                    HtmlGenericControl h3 = new HtmlGenericControl("h3");
                    if (string.IsNullOrEmpty(pb.Product.Code))
                        h3.InnerText = pb.ProviderCode;
                    else
                        h3.InnerText = pb.Product.Code;
                    HtmlGenericControl p = new HtmlGenericControl("p");
                    p.InnerText = pb.Product.Model;
                    HtmlGenericControl li = new HtmlGenericControl("li");
                    li.Attributes["id"] = pb.ID.ToString();
                    li.Controls.Add(a);
                    li.Controls.Add(h3);
                    li.Controls.Add(p);
                    productlist.Controls.Add(li);
                }
                
            }
            else
            {
                //[BUG]: Se debe setear el foco primero en otro control, para que funcione de primera el 
                //buscador de Ajax
                AjaxControlToolkit.Utility.SetFocusOnLoad(txtObservations); 
                AjaxControlToolkit.Utility.SetFocusOnLoad(txtDistributor); 
            }
        }

        #endregion

        #region Events

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            bool canfinal;
            string[] name = txtDistributor.Text.Split('-', ']');
            List<int> selectedcontactlist = new List<int>();
            foreach (ListItem item in cblContacts.Items)
                if (item.Selected)
                    selectedcontactlist.Add(Convert.ToInt32(item.Value));

            Quote q = ControllerManager.Quote.AddItems(PriceMasterList1.GridState, QuoteId, name[0], txtDescripcion.Text, txtObservations.Text, Convert.ToInt32(ddlQuoteVigency.SelectedValue), Convert.ToInt32(ddlQuoteCondition.SelectedValue), Convert.ToInt32(ddlQuoteIntroText.SelectedValue), txtEmail.Text, txtContact.Text, out canfinal, selectedcontactlist, Convert.ToInt32(ddlToCurrency.SelectedValue));
            Session["QuoteItemError"] = !canfinal;
            Response.Redirect("/quotes/view/?Id=" + q.ID);

            SetVisibility();
        }

        #endregion

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string[] name = txtDistributor.Text.Split('-', ']');
            args.IsValid = ControllerManager.Distributor.Check(name[0]);
        }

        protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = PriceMasterList1.GridState.Items.Count > 0;
        }

        protected void CustomValidator3_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = ddlQuoteCondition.SelectedValue != "0" && ddlQuoteIntroText.SelectedValue != "0";
        }

        protected void txtDistributor_TextChanged(object sender, EventArgs e)
        {
            string[] name = txtDistributor.Text.Split('-', ']');
            Distributor d = ControllerManager.Distributor.GetByName(name[0]);
            if(d != null)
            {
                ContactsUpdate(d);
                upCheckBoxList.Update();
                if (d.PriceList != null)
                {
                    ddlToCurrency.SelectedValue = ddlToCurrency.Items.FindByValue(d.PriceList.Currency.ID.ToString()).Value;
                    lblCurrencyRate.Text = ControllerManager.CurrencyRate.GetLast(d.PriceList.Currency).Rate.ToString("(##0.####)");
                    upCurrency.Update();
                }
            }
        }

        protected void ddlToCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblCurrencyRate.Text = ControllerManager.CurrencyRate.GetLast(ControllerManager.Currency.GetById(Convert.ToInt32(ddlToCurrency.SelectedValue))).Rate.ToString("(##0.####)");
        }
    }
}