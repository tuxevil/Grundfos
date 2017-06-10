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
    public partial class PriceListEditor : System.Web.UI.UserControl
    {
        #region Properties
        
        public int PriceListId
        {
            get
            {
                if (ViewState["PriceListId"] != null)
                    return Convert.ToInt32(ViewState["PriceListId"]);
                else
                    return 0;
            }
            set { ViewState["PriceListId"] = value; }
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
                ddlIncoterm.DataSource = EnumHelper.GetList(typeof(Incoterm));
                ddlIncoterm.DataTextField = "Value";
                ddlIncoterm.DataValueField = "Key";
                ddlIncoterm.DataBind();
                ddlIncoterm.Items.Insert(0, new ListItem("--Condición de Venta--", "0"));

                ddlFrequency.DataSource = EnumHelper.GetList(typeof(Frequency));
                ddlFrequency.DataTextField = "Value";
                ddlFrequency.DataValueField = "Key";
                ddlFrequency.DataBind();
                ddlFrequency.Items.Insert(0, new ListItem("--Frecuencia--", "0"));

                ddlType.DataSource = ControllerManager.Lookup.List(LookupType.PriceListType);
                ddlType.DataTextField = "Description";
                ddlType.DataValueField = "ID";
                ddlType.DataBind();
                ddlType.Items.Insert(0, new ListItem("--Tipo de Grupo de Precios--", "0"));

                ddlCurrency.DataSource = ControllerManager.Currency.GetAll();
                ddlCurrency.DataTextField = "Description";
                ddlCurrency.DataValueField = "ID";
                ddlCurrency.DataBind();

                if (Mode != EditionMode.Create)
                    LoadFields();
                else 
                {
                    ddlCountry.DataSource = ControllerManager.PriceGroup.GetAll();
                    ddlCountry.DataTextField = "Name";
                    ddlCountry.DataValueField = "ID";
                    ddlCountry.DataBind();

                    ddlCountry.Visible = true;
                    lblCountry.Visible = false;
                    lblTDate.Visible = false;
                    lblTDiscount.Visible = false;
                    lblTStatus.Visible = false;
                    lblTitle.Text = "Nuevo Grupo de Precios";
                }

                SetVisibility();
            }
        }

        private void LoadFields()
        {
            if (PriceListId != 0)
            {
                PriceList pl = ControllerManager.PriceList.GetById(PriceListId);
                
                //if (!MembershipManager.IsAdministrator())
                ExecutePermissionValidator epv = new ExecutePermissionValidator();
                epv.ClassType = typeof(PriceList);
                epv.KeyIdentifier = Config.SeePriceLists;

                if (PermissionManager.Check(epv) == false)
                {
                    PermissionManager.Validate(pl);
                }
                txtName.Text = pl.Name;
                txtDescripcion.Text = pl.Description;
                lblDiscount.Text = pl.Discount.ToString("#0.###") + "%";

                if (pl.Type != null)
                    ddlType.SelectedValue = ddlType.Items.FindByValue(pl.Type.ID.ToString()).Value;
                else
                    ddlType.SelectedIndex = 0;

                if (pl.SaleCondition != null)
                    ddlIncoterm.SelectedValue = ddlIncoterm.Items.FindByValue(pl.SaleCondition.ToString()).Value;
                else
                    ddlIncoterm.SelectedIndex = 0;

                lblStatus.Text = Resource.Business.GetString(pl.CurrentState.Status.ToString());

                if (pl.CurrentState.LastPublishedOn.HasValue)
                    lblLastPubDate.Text = pl.CurrentState.LastPublishedOn.Value.ToShortDateString();
                else
                    lblLastPubDate.Text = "N/D";

                if (pl.Frecuency != null)
                    ddlFrequency.SelectedValue = ddlFrequency.Items.FindByValue(pl.Frecuency.ToString()).Value;
                else
                    ddlFrequency.SelectedIndex = 0;

                if (pl.Currency != null)
                {
                    ddlCurrency.SelectedValue = ddlCurrency.Items.FindByValue(pl.Currency.ID.ToString()).Value;
                    lblCurrency.Text = pl.Currency.Description;
                }
                else
                    ddlCurrency.SelectedIndex = 0;

                lblCountry.Text = pl.PriceGroup.Name;
                lblCountry.Visible = true;
            }
        }

        protected void SetVisibility()
        {
            bool enabled = (Mode == EditionMode.Edit || Mode == EditionMode.Create);

            foreach (Control c in this.Controls)
                if (c is WebControl && c.GetType() != typeof(LinkButton) )
                    (c as WebControl).Enabled = enabled;

            btnSave.Visible = enabled;
            lnkDetails.Visible = (Mode == EditionMode.Edit);

            if (PriceListId != 0)
                lnkEdit.Visible = !enabled;
            else
                lnkEdit.Visible = (Mode != EditionMode.Create);

            lnkEdit.Visible = (PermissionManager.Check(lnkEdit) && Mode == EditionMode.View);

            ddlCurrency.Visible = (Mode == EditionMode.Create);
            lblCurrency.Visible = (Mode != EditionMode.Create);
            if(enabled)
                txtName.Focus();
                
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

            Incoterm? incoterm = null;
            if (ddlIncoterm.SelectedIndex != 0)
                incoterm = (Incoterm)Enum.Parse(typeof(Incoterm), ddlIncoterm.SelectedValue);

            Frequency? frequency = null;
            if (ddlFrequency.SelectedIndex != 0)
                frequency = (Frequency)Enum.Parse(typeof(Frequency), ddlFrequency.SelectedValue);

            Currency currency = ControllerManager.Currency.GetById(Convert.ToInt32(ddlCurrency.SelectedValue));
            if (Mode == EditionMode.Create)
            {
                PriceGroup pG = ControllerManager.PriceGroup.GetById(Convert.ToInt32(ddlCountry.SelectedValue));
                PriceList pl = ControllerManager.PriceList.Create(txtName.Text, txtDescripcion.Text, ControllerManager.Lookup.GetById(Convert.ToInt32(ddlType.SelectedItem.Value)), incoterm, PriceListStatus.Active, frequency, pG, currency);
                Response.Redirect("/pricelists/view/?Id=" + pl.ID);
            }

            if (Mode == EditionMode.Edit)
                ControllerManager.PriceList.Modify(new PriceList(PriceListId), txtName.Text, txtDescripcion.Text, ControllerManager.Lookup.GetById(Convert.ToInt32(ddlType.SelectedItem.Value)), incoterm, PriceListStatus.Active, frequency, currency);
           
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
            Mode = EditionMode.View;
            lblTitle.Text = "Detalle";
            LoadFields();
            SetVisibility();
        }
    }
}