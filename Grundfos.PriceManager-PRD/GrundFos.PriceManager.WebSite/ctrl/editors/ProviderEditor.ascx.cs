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
    public partial class ProviderEditor : System.Web.UI.UserControl
    {
        #region Properties

        public int ProviderId
        {
            get
            {
                if (ViewState["ProviderId"] != null)
                    return Convert.ToInt32(ViewState["ProviderId"]);
                else
                    return 0;
            }
            set { ViewState["ProviderId"] = value; }
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
                ddlCountry.DataSource = ControllerManager.Country.GetAll();
                ddlCountry.DataTextField = "Name";
                ddlCountry.DataValueField = "ID";
                ddlCountry.DataBind();
                ddlCountry.Items.Insert(0, new ListItem("--Países--", "0"));

                ddlSaleConditions.DataSource = EnumHelper.GetList(typeof(Incoterm));
                ddlSaleConditions.DataTextField = "Value";
                ddlSaleConditions.DataValueField = "Key";
                ddlSaleConditions.DataBind();
                ddlSaleConditions.Items.Insert(0, new ListItem("--Condiciones de Venta--", "0"));

                ddlPurchaseCondition.DataSource = ControllerManager.Lookup.List(LookupType.PurchaseType);
                ddlPurchaseCondition.DataTextField = "Description";
                ddlPurchaseCondition.DataValueField = "ID";
                ddlPurchaseCondition.DataBind();
                ddlPurchaseCondition.Items.Insert(0, new ListItem("--Condiciones de Compra--", "0"));

                if (Mode != EditionMode.Create)
                   LoadFields();   
                
                SetVisibility();
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

            if (ProviderId != 0)
                lnkEdit.Visible = !enabled;
            else
                lnkEdit.Visible = enabled;

            lnkEdit.Visible = (PermissionManager.Check(lnkEdit) && Mode == EditionMode.View);
            if(enabled)
                txtDescripcion.Focus();

            bool importantFieldsVisibility = false;
            
            ExecutePermissionValidator epv = new ExecutePermissionValidator();
            epv.ClassType = typeof(Provider);
            epv.KeyIdentifier = Config.ProviderFields;
            
            importantFieldsVisibility = PermissionManager.Check(epv);
            
            ttlPurchaseYTD.Visible = importantFieldsVisibility;
            lblPurchaseYTD.Visible = importantFieldsVisibility;
            ttlPurchPrevYear.Visible = importantFieldsVisibility;
            lblPurchPrevYear.Visible = importantFieldsVisibility;
        }

        private void LoadFields()
        {
            if (ProviderId != 0)
            {
                Provider p = ControllerManager.Provider.GetById(ProviderId);

                txtCity.Text = p.City;

                txtDescripcion.Text = p.Description;

                txtLeadTime.Text = "0";
                if (!string.IsNullOrEmpty(p.LeadTime.ToString()))
                    txtLeadTime.Text = p.LeadTime.ToString();

                txtMail.Text = p.Email;

                lblAddress.Text = "N/D";
                if (!string.IsNullOrEmpty(p.Address))
                    lblAddress.Text = p.Address;

                lblCode.Text = "N/D";
                if (!string.IsNullOrEmpty(p.Code))
                    lblCode.Text = p.Code;

                lblComment.Text = "N/D";
                if (!string.IsNullOrEmpty(p.Comment))
                    lblComment.Text = p.Comment;

                lblCompleteName.Text = "N/D";
                if (!string.IsNullOrEmpty(p.CompleteName))
                    lblCompleteName.Text = p.CompleteName;

                lblContact.Text = "N/D";
                if (!string.IsNullOrEmpty(p.Contact))
                    lblContact.Text = p.Contact;

                lblFax.Text = "N/D";
                if (!string.IsNullOrEmpty(p.Fax))
                    lblFax.Text = p.Fax;

                lblLastInvDate.Text = "N/D";
                if (!string.IsNullOrEmpty(p.LastInvDate.ToString()))
                    lblLastInvDate.Text = ((DateTime)p.LastInvDate).ToShortDateString();

                lblName.Text = "N/D";
                if (!string.IsNullOrEmpty(p.Name))
                    lblName.Text = p.Name;

                lblPhone.Text = "N/D";
                if (!string.IsNullOrEmpty(p.Telephone))
                    lblPhone.Text = p.Telephone;

                lblPurchaseYTD.Text = "N/D";
                if (!string.IsNullOrEmpty(p.PurchaseYTD))
                    lblPurchaseYTD.Text = "U$S " + p.PurchaseYTD;

                lblPurchPrevYear.Text = "N/D";
                if (!string.IsNullOrEmpty(p.PurchPrevYear))
                    lblPurchPrevYear.Text = "U$S " + p.PurchPrevYear;

                lblScalaCountryCode.Text = "N/D";
                if (!string.IsNullOrEmpty(p.ScalaCountryCode))
                    lblScalaCountryCode.Text = p.ScalaCountryCode;

                lblTaxCode.Text = "N/D";
                if (!string.IsNullOrEmpty(p.TaxCode))
                    lblTaxCode.Text = p.TaxCode;

                lblStatus.Text = Resource.Business.GetString(p.ProviderStatus.ToString());

                if (p.Country != null)
                    ddlCountry.SelectedValue = ddlCountry.Items.FindByValue(p.Country.ID.ToString()).Value;
                else
                    ddlCountry.SelectedIndex = 0;

                if (p.SaleConditions != null && p.SaleConditions != 0)
                    ddlSaleConditions.SelectedValue = ddlSaleConditions.Items.FindByValue(p.SaleConditions.ToString()).Value;
                else
                    ddlSaleConditions.SelectedIndex = 0;

                if (p.PurchaseType != null)
                    ddlPurchaseCondition.SelectedValue = ddlPurchaseCondition.Items.FindByValue(p.PurchaseType.ID.ToString()).Value;
                else
                    ddlPurchaseCondition.SelectedIndex = 0;
            }
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

            Country c = null;
            if (ddlCountry.SelectedIndex != 0)
                c = ControllerManager.Country.GetById(Convert.ToInt32(ddlCountry.SelectedValue));

            Incoterm? incoterm = null;
            if (ddlSaleConditions.SelectedIndex != 0)
                incoterm = (Incoterm)Enum.Parse(typeof(Incoterm), ddlSaleConditions.SelectedValue);

            int leadTime = 0;
            if(!string.IsNullOrEmpty(txtLeadTime.Text))
                leadTime = Convert.ToInt32(txtLeadTime.Text);

            Lookup purchaseType = null;
            if (ddlPurchaseCondition.SelectedIndex != 0)
                purchaseType = ControllerManager.Lookup.GetById(Convert.ToInt32(ddlPurchaseCondition.SelectedValue));
            decimal discount = 0;

            ControllerManager.Provider.Updates(ProviderId, txtDescripcion.Text, txtCity.Text, leadTime, txtMail.Text, purchaseType, c, incoterm, discount);
            
            Mode = EditionMode.View;
            SetVisibility();
        }

        #endregion

        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            Mode = EditionMode.Edit;
            lblTitle.Text = "Edición";
            SetVisibility();
        }

        protected void lnkDetails_Click(object sender, EventArgs e)
        {
            Provider p = ControllerManager.Provider.GetById(ProviderId);
            Mode = EditionMode.View;
            lblTitle.Text = "Detalle";
            LoadFields();
            SetVisibility();
        }
    }
}