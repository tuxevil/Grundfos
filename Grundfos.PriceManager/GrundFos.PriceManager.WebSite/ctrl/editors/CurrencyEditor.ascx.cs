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

namespace GrundFos.PriceManager.WebSite.ctrl.editors
{
    public partial class CurrencyEditor : System.Web.UI.UserControl
    {
        #region Properties
        
        public int CurrencyId
        {
            get
            {
                if (ViewState["CurrencyId"] != null)
                    return Convert.ToInt32(ViewState["CurrencyId"]);
                else
                    return 0;
            }
            set { ViewState["CurrencyId"] = value; }
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

        private bool BaseCurrency
        {
            get
            {
                if (ViewState["BaseCurrency"] != null)
                    return (bool)ViewState["BaseCurrency"];
                return false;
            }
            set { ViewState["BaseCurrency"] = value; }
        }

        #endregion

        #region Load

        public override void DataBind()
        {
            if (!Page.IsPostBack)
            {
                if (Mode != EditionMode.Create)
                    LoadFields();
                else
                {
                    ddlCodes.DataSource = ControllerManager.Currency.GetCurrencyCodes();
                    ddlCodes.DataBind();
                }
                
                SetVisibility();
            }
        }
        protected void LoadFields()
        {
            if (CurrencyId != 0)
            {
                Currency c = ControllerManager.Currency.GetById(CurrencyId);
                Currency bc = ControllerManager.Currency.GetBaseCurrency();

                txtCurrency.Text = c.Description;
                txtValue.Text = c.LastCurrencyRateView.Rate.ToString("#0.####");
                ddlCodes.DataSource = ControllerManager.Currency.GetCurrencyCodes(c.Code);
                ddlCodes.DataBind();

                ddlCodes.SelectedValue = ddlCodes.Items.FindByValue(c.Code).Value;

                BaseCurrency = c == bc;
            }
        }

        protected void SetVisibility()
        {
            bool enabled = (Mode == EditionMode.Edit || Mode == EditionMode.Create);

            foreach (Control c in this.Controls)
                if (c is WebControl && c.GetType() != typeof(LinkButton)) 
                    (c as WebControl).Enabled = enabled;

            btnSave.Visible = enabled;
            lnkDetails.Visible = (Mode == EditionMode.Edit);
            if(BaseCurrency)
                txtValue.Enabled = false;

            if (CurrencyId != 0)
                lnkEdit.Visible = !enabled;
            else
                lnkEdit.Visible = (Mode != EditionMode.Create);

            lnkEdit.Visible = (PermissionManager.Check(lnkEdit)  && Mode == EditionMode.View);
            if (Mode == EditionMode.Edit)
            {
                txtCurrency.Focus();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
                UpdateGrid();
        }

        #endregion

        #region Events

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            if (Mode == EditionMode.Edit)
                ControllerManager.Currency.Edit(CurrencyId, txtCurrency.Text, Convert.ToDecimal(txtValue.Text), ddlCodes.SelectedValue);
            else
            {
                Currency c = ControllerManager.Currency.Create(txtCurrency.Text, Convert.ToDecimal(txtValue.Text), ddlCodes.SelectedValue);
                Response.Redirect("/admin/currencies/view/?Id=" + c.ID);
            }
            
            Mode = EditionMode.View;
            SetVisibility();
            UpdateGrid();
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

        private void UpdateGrid()
        {
            grvHistory.DataSource = ControllerManager.CurrencyRate.ListByCurrency(ControllerManager.Currency.GetById(CurrencyId));
            grvHistory.DataBind();
        }

    }
}