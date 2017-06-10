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
    public partial class PriceGroupEditor : System.Web.UI.UserControl
    {
        #region Properties

        public int PriceGroupId
        {
            get
            {
                if (ViewState["PriceGroup"] != null)
                    return Convert.ToInt32(ViewState["PriceGroup"]);
                else
                    return 0;
            }
            set { ViewState["PriceGroup"] = value; }
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
                ddlCurrency.DataSource = ControllerManager.Currency.GetAll();
                ddlCurrency.DataTextField = "Description";
                ddlCurrency.DataValueField = "ID";
                ddlCurrency.DataBind();

                if (Mode != EditionMode.Create)
                    LoadFields();
                
                SetVisibility();
            }
        }
        protected void LoadFields()
        {
            if (PriceGroupId != 0)
            {
                PriceGroup pg = ControllerManager.PriceGroup.GetById(PriceGroupId);

                ddlCurrency.SelectedValue = ddlCurrency.Items.FindByValue(pg.Currency.ID.ToString()).Value;
                txtDescription.Text = pg.Description;
                txtName.Text = pg.Name;
                lblCurrency.Text = pg.Currency.Description;
                txtDiscount.Text = pg.Discount.ToString("#0.##");
               
                if (pg.Adjust != null)
                 txtAdjust.Text = pg.Adjust.Value.ToString("#0.##"); 
               
                txtGRP.Text = pg.PriceSuggestCoef.ToString("#0.##");
                
                ddlCurrency.Visible = false;
                lblCurrency.Visible = true;
                if (pg.PriceAttributes.Count == 0)
                {
                    ddlCurrency.Visible = true;
                    lblCurrency.Visible = false;
                }
                

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

            if (PriceGroupId != 0)
                lnkEdit.Visible = !enabled;
            else
                lnkEdit.Visible = (Mode != EditionMode.Create);

            lnkEdit.Visible = (PermissionManager.Check(lnkEdit) && Mode == EditionMode.View);
            if (Mode == EditionMode.Edit)
            {
                txtAdjust.Focus();
            }

            //always disabled fields (4 the moment)
            //txtName.Enabled = false;
            //txtDescription.Enabled = false;
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

            Currency c = ControllerManager.Currency.GetById(Convert.ToInt32(ddlCurrency.SelectedValue.ToString()));
            if (Mode == EditionMode.Edit)
            {
                PriceGroup pg = new PriceGroup(PriceGroupId);
                decimal? adjust = null;
                decimal? discount = null;
                if (!string.IsNullOrEmpty(txtAdjust.Text))
                    adjust = Convert.ToDecimal(txtAdjust.Text);

                if (!string.IsNullOrEmpty(txtDiscount.Text))
                    discount = Convert.ToDecimal(txtDiscount.Text);

                ControllerManager.PriceGroup.Modify(pg, txtName.Text, txtDescription.Text, adjust, discount, Convert.ToDecimal(txtGRP.Text), c); 
            }
            //else
            //{

            //    Lookup lu = ControllerManager.Lookup.Create(lut, txtDescription.Text);
            //    Response.Redirect("/admin/lookups/view/?LookupId=" + lu.ID);
            //}
            
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