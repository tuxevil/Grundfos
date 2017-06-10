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
using PriceManager;

namespace GrundFos.PriceManager.WebSite.ctrl.editors
{
    public partial class QuoteRangeEditor : System.Web.UI.UserControl
    {
        #region Properties

        public int RangeId
        {
            get
            {
                if (ViewState["rangeId"] != null)
                    return Convert.ToInt32(ViewState["rangeId"]);
                else
                    return 0;
            }
            set { ViewState["rangeId"] = value; }
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
                if (Mode != EditionMode.Create)
                    LoadFields();
                
                SetVisibility();
            }
        }
        protected void LoadFields()
        {
            if (RangeId != 0)
            {
                QuoteRange qr = ControllerManager.QuoteRange.GetById(RangeId);

                txtTitle.Text = qr.Title;
                txtMaximum.Text = qr.Maximum.ToString();
                txtMinimum.Text = qr.Minimum.ToString();
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

            if (RangeId != 0)
                lnkEdit.Visible = !enabled;
            else
                lnkEdit.Visible = (Mode != EditionMode.Create);

            lnkEdit.Visible = (Mode == EditionMode.View);
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            RangeValidator rvMin = new RangeValidator();
            rvMin.ControlToValidate = "txtMinimum";
            rvMin.ValidationGroup = "form";
            rvMin.Display = ValidatorDisplay.Dynamic;
            rvMin.Text = "Ingrese un numero entre -100 y 100.";
            rvMin.MinimumValue = "-100";
            rvMin.MaximumValue = "100";
            rvMin.CssClass = "valerror";
            rvMin.Type = ValidationDataType.Integer;
            txtMinimum.AddValidator(rvMin);

            RangeValidator rvMax = new RangeValidator();
            rvMax.ControlToValidate = "txtMaximum";;
            rvMax.ValidationGroup = "form";
            rvMax.Display = ValidatorDisplay.Dynamic;
            rvMax.Text = "Ingrese un numero entre -100 y 100.";
            rvMax.MinimumValue = "-100";
            rvMax.MaximumValue = "100";
            rvMax.CssClass = "valerror";
            rvMax.Type = ValidationDataType.Integer;
            txtMaximum.AddValidator(rvMax);
        }

        #endregion

        #region Events

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            if (Convert.ToInt32(txtMaximum.Value) <= Convert.ToInt32(txtMinimum.Value))
            {
                Utils.ShowMessageInAjax(this.Page, "El Maximo debe ser mayor al Minimo.", Utils.MessageType.Error);
                return;
            }

            if (Mode == EditionMode.Edit)
            {
                try
                {
                    ControllerManager.QuoteRange.Edit(RangeId, txtTitle.Value.ToString(), Convert.ToInt32(txtMaximum.Value), Convert.ToInt32(txtMinimum.Value));
                    Mode = EditionMode.View;
                    SetVisibility();
                }
                catch (Exception)
                {
                    Utils.ShowMessageInAjax(this.Page, "Ya existe un rango con ese titulo.", Utils.MessageType.Error);
                }
            }
            else
            {
                try
                {
                    QuoteRange qr = ControllerManager.QuoteRange.Create(txtTitle.Value.ToString(), Convert.ToInt32(txtMaximum.Value), Convert.ToInt32(txtMinimum.Value));
                    RangeId = qr.ID;
                    Mode = EditionMode.View;
                    SetVisibility();
                }
                catch (Exception)
                {
                    Utils.ShowMessageInAjax(this.Page, "Ya existe un rango con ese titulo.", Utils.MessageType.Error);
                }
            }
            
            
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
            lblTitle.Text = "Detalles";
            LoadFields();
            SetVisibility();
        }

    }
}