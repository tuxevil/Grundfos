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
using PriceManager.Core;
using PriceManager.Business;
using System.Collections.Generic;
using PriceManager.Common;
using NybbleMembership;
using NybbleMembership.Core.Domain;

namespace GrundFos.PriceManager.WebSite.ctrl.editors
{
    public partial class DistributorEditor : System.Web.UI.UserControl
    {
        #region Properties
        
        public int DistributorId
        {
            get
            {
                if (ViewState["DistributorId"] != null)
                    return Convert.ToInt32(ViewState["DistributorId"]);
                else
                    return 0;
            }
            set { ViewState["DistributorId"] = value; }
        }

        public EditionMode Mode
        {
            get
            {
                if (ViewState["Type"] != null)
                    return (EditionMode)ViewState["Type"];
                return EditionMode.View;
            }
            set { ViewState["Type"] = value; }
        }

        #endregion

        #region Load

        public override void DataBind()
        {
            if (!Page.IsPostBack)
            {
                ddlCountry.DataSource = ControllerManager.Country.GetAll("Name");
                ddlCountry.DataTextField = "Name";
                ddlCountry.DataValueField = "ID";
                ddlCountry.DataBind();
                ddlCountry.Items.Insert(0, new ListItem("--Países--", "0"));

                ddlPaymentTerm.DataSource = ControllerManager.Lookup.List(LookupType.PaymentTerm);
                ddlPaymentTerm.DataTextField = "Description";
                ddlPaymentTerm.DataValueField = "ID";
                ddlPaymentTerm.DataBind();
                ddlPaymentTerm.Items.Insert(0, new ListItem("--Condiciones de Pago--", "0"));

                ddlPriceList.DataSource = ControllerManager.PriceList.GetActives();
                ddlPriceList.DataTextField = "Name";
                ddlPriceList.DataValueField = "ID";
                ddlPriceList.DataBind();
                ddlPriceList.Items.Insert(0, new ListItem("--Listas de Precios--", "0"));

                ddlSaleConditions.DataSource = EnumHelper.GetList(typeof(Incoterm));
                ddlSaleConditions.DataTextField = "Value";
                ddlSaleConditions.DataValueField = "Key";
                ddlSaleConditions.DataBind();
                ddlSaleConditions.Items.Insert(0, new ListItem("--Condiciones de Venta--", "0"));

                ddlType.DataSource = ControllerManager.Lookup.List(LookupType.DistributorType);
                ddlType.DataTextField = "Description";
                ddlType.DataValueField = "ID";
                ddlType.DataBind();
                ddlType.Items.Insert(0, new ListItem("--Tipo de Distribuidor--", "0"));

                if (Mode != EditionMode.Create)
                    LoadFields();
                
                SetVisibility();
            }
        }

        protected void LoadFields()
        {
            if (DistributorId != 0)
            {
                Distributor d = ControllerManager.Distributor.GetById(DistributorId);

                lblCode.Text = "N/D";
                if (!string.IsNullOrEmpty(d.Code))
                    lblCode.Text = d.Code;

                lblName.Text = "N/D";
                if (!string.IsNullOrEmpty(d.Name))
                    lblName.Text = d.Name;

                txtDiscount.Text = 0.ToString("#0.##");
                if (!string.IsNullOrEmpty(d.Discount.ToString()))
                    txtDiscount.Text = d.Discount.ToString("#0.##");

                txtDescripcion.Text = d.Description;

                txtContact.Text = d.Contact;

                lblStatus.Text = "N/D";
                if (!string.IsNullOrEmpty(d.DistributorStatus.ToString()))
                    lblStatus.Text = Resource.Business.GetString(d.DistributorStatus.ToString());

                lblMail.Text = "N/D";
                if (!string.IsNullOrEmpty(d.Email))
                    lblMail.Text = d.Email;

                lblPhone.Text = "N/D";
                if (!string.IsNullOrEmpty(d.Telephone))
                    lblPhone.Text = d.Telephone;

                if (d.Country != null)
                    ddlCountry.SelectedValue = ddlCountry.Items.FindByValue(d.Country.ID.ToString()).Value;
                else
                    ddlCountry.SelectedIndex = 0;
                
                if (d.PaymentTerm != null)
                    ddlPaymentTerm.SelectedValue = ddlPaymentTerm.Items.FindByValue(d.PaymentTerm.ID.ToString()).Value;
                else
                    ddlPaymentTerm.SelectedIndex = 0;

                if (Mode != EditionMode.View)
                {
                    ddlPriceList.Visible = true;
                    lnkPriceList.Visible = false;
                    if (d.PriceList != null && (d.PriceList.PriceListStatus != PriceListStatus.Deleted && d.PriceList.PriceListStatus != PriceListStatus.Disable))
                        if( ddlPriceList.Items.FindByValue(d.PriceList.ID.ToString()) != null)
                            ddlPriceList.SelectedValue = ddlPriceList.Items.FindByValue(d.PriceList.ID.ToString()).Value;
                    else
                        ddlPriceList.SelectedIndex = 0;
                }
                else
                {
                    ddlPriceList.Visible = false;
                    lnkPriceList.Visible = true;
                    if (d.PriceList != null && (d.PriceList.PriceListStatus != PriceListStatus.Deleted && d.PriceList.PriceListStatus != PriceListStatus.Disable))
                    {
                        lnkPriceList.Text = d.PriceList.Name;
                        lnkPriceList.NavigateUrl = "/pricelists/view/default.aspx?Id=" + d.PriceList.ID;
                        lnkPriceList.ToolTip = "Ir";
                    }
                    else
                        lnkPriceList.Visible = false;
                }

                if (d.Type != null)
                    ddlType.SelectedValue = ddlType.Items.FindByValue(d.Type.ID.ToString()).Value;
                else
                    ddlType.SelectedIndex = 0;

                lblAddress.Text = "N/D";
                if (!string.IsNullOrEmpty(d.Address))
                    lblAddress.Text = d.Address;

                lblFax.Text = "N/D";
                if (!string.IsNullOrEmpty(d.Fax))
                    lblFax.Text = d.Fax;

                lblSalesTaxCode.Text = "N/D";
                if (!string.IsNullOrEmpty(d.SalesTaxCode))
                    lblSalesTaxCode.Text = d.SalesTaxCode;

                lblScalaPaymentTerm.Text = "N/D";
                if (!string.IsNullOrEmpty(d.ScalaPaymentTerm))
                    lblScalaPaymentTerm.Text = d.ScalaPaymentTerm;

                lblSalePrevYear.Text = "N/D";
                if (!string.IsNullOrEmpty(d.SalePrevYear))
                    lblSalePrevYear.Text = "U$S " + d.SalePrevYear;

                lblSaleYTD.Text = "N/D";
                if (!string.IsNullOrEmpty(d.SaleYTD))
                    lblSaleYTD.Text = "U$S " + d.SaleYTD;

                lblProfitYTD.Text = "N/D";
                if (!string.IsNullOrEmpty(d.ProfitYTD))
                    lblProfitYTD.Text = "U$S " + d.ProfitYTD;

                lblComment.Text = "N/D";
                if (!string.IsNullOrEmpty(d.Comment))
                    lblComment.Text = d.Comment;

                lblScalaCountryCode.Text = "N/D";
                if (!string.IsNullOrEmpty(d.ScalaCountryCode))
                    lblScalaCountryCode.Text = d.ScalaCountryCode;

                lblCompleteName.Text = "N/D";
                if (!string.IsNullOrEmpty(d.CompleteName))
                    lblCompleteName.Text = d.CompleteName;

                lblImpExpCustomer.Text = "N/D";
                if (!string.IsNullOrEmpty(d.ImpExpCustomer))
                    lblImpExpCustomer.Text = d.ImpExpCustomer;

                if (d.SaleConditions != 0 && d.SaleConditions != null)
                    ddlSaleConditions.SelectedValue = ddlSaleConditions.Items.FindByValue(d.SaleConditions.ToString()).Value;
                else
                    ddlSaleConditions.SelectedIndex = 0;

                lblListPub.Text = "N/D";
                if (d.PriceList != null && d.PriceList.CurrentState.LastPublishedOn != null)
                    lblListPub.Text = d.PriceList.CurrentState.LastPublishedOn.Value.ToShortDateString();

                lblListVigency.Text = "N/D";
                if (d.PriceList != null && d.PriceList.CurrentState.PublishOn != null)
                    lblListVigency.Text = d.PriceList.CurrentState.PublishOn.Value.ToShortDateString();

                txtAltMail.Text = d.AlternativeEmail;
            }
        }

        protected void SetVisibility()
        {
            bool enabled = (Mode == EditionMode.Edit);

            foreach (Control c in this.Controls)
                if (c is WebControl && c.GetType() != typeof(LinkButton) )
                    (c as WebControl).Enabled = enabled;

            btnSave.Visible = enabled;
            lnkDetails.Visible = enabled;

            if (DistributorId != 0)
                lnkEdit.Visible = !enabled;
            else
                lnkEdit.Visible = enabled;

            lnkEdit.Visible = (PermissionManager.Check(lnkEdit) && Mode == EditionMode.View);
            if(enabled)
                txtDiscount.Focus();

            bool importantFieldsVisibility = false;

            ExecutePermissionValidator epv = new ExecutePermissionValidator();
            epv.ClassType = typeof(Distributor);
            epv.KeyIdentifier = Config.DistributorFields;

            importantFieldsVisibility = PermissionManager.Check(epv);

            ttlProfitYTD.Visible = importantFieldsVisibility;
            lblProfitYTD.Visible = importantFieldsVisibility;
            ttlSalePrevYear.Visible = importantFieldsVisibility;
            lblSalePrevYear.Visible = importantFieldsVisibility;
            ttlSaleYTD.Visible = importantFieldsVisibility;
            lblSaleYTD.Visible = importantFieldsVisibility;

            lnkPriceList.Enabled = !enabled;
                
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        #endregion

        #region Events

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            PriceList pl = null;
            if(ddlPriceList.SelectedIndex != 0)
                pl = ControllerManager.PriceList.GetById(Convert.ToInt32(ddlPriceList.SelectedValue));

            Country c = null;
            if(ddlCountry.SelectedIndex != 0)
                c =ControllerManager.Country.GetById(Convert.ToInt32(ddlCountry.SelectedValue));
            
            Lookup paymentTerm = null;
            if(ddlPaymentTerm.SelectedIndex != 0)
                paymentTerm = ControllerManager.Lookup.GetById(Convert.ToInt32(ddlPaymentTerm.SelectedValue));

            Incoterm? incoterm = null;
            if (ddlSaleConditions.SelectedIndex != 0)
                incoterm = (Incoterm)Enum.Parse(typeof(Incoterm), ddlSaleConditions.SelectedValue);

            Lookup l = null;
            if (ddlType.SelectedIndex != 0)
                l = ControllerManager.Lookup.GetById(Convert.ToInt32(ddlType.SelectedValue));
            

            ControllerManager.Distributor.Update(DistributorId, txtDescripcion.Text, txtContact.Text, pl, c, Convert.ToDecimal(txtDiscount.Text), paymentTerm, incoterm, l, txtAltMail.Text);
            
            Mode = EditionMode.View;
            SetVisibility();
        }

        #endregion

        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            Mode = EditionMode.Edit;
            lblTitle.Text = "Edición";
            lnkPriceList.Visible = false;
            ddlPriceList.Visible = true;
            LoadFields();
            SetVisibility();
        }

        protected void lnkDetails_Click(object sender, EventArgs e)
        {
            Mode = EditionMode.View;
            lblTitle.Text = "Detalle";
            LoadFields();
            SetVisibility();
        }

        protected void ddlPriceList_SelectedIndexChange(object sender, EventArgs e)
        {
            if (ddlPriceList.SelectedValue != "0")
            {
                PriceList pl = ControllerManager.PriceList.GetById(Convert.ToInt32(ddlPriceList.SelectedValue));

                lblListPub.Text = "N/D";
                if (pl != null && pl.CurrentState.LastPublishedOn != null)
                    lblListPub.Text = pl.CurrentState.LastPublishedOn.Value.ToShortDateString();

                lblListVigency.Text = "N/D";
                if (pl != null && pl.CurrentState.PublishOn != null)
                    lblListVigency.Text = pl.CurrentState.PublishOn.Value.ToShortDateString();
            }
            else
            {
                lblListPub.Text = "N/D";
                lblListVigency.Text = "N/D";
            }
        }

    }
}