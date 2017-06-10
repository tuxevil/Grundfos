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
using PriceManager.Common;
using NybbleMembership.Core.Domain;
using NybbleMembership;

namespace GrundFos.PriceManager.WebSite.ctrl.editors
{
    public partial class QuoteLineEditor : System.Web.UI.UserControl
    {
        #region Properties
        public int QuoteId
        {
            get
            {
                if (ViewState["quoteId"] != null)
                    return Convert.ToInt32(ViewState["quoteId"]);
                else
                    return 0;
            }
            set { ViewState["quoteId"] = value; }
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

        private QuoteItem quoteItem;
        public QuoteItem QuoteItem
        {
            get
            {
                if (quoteItem != null)
                {
                    QuoteItemId = quoteItem.ID;
                    return quoteItem;
                }
                else
                    return null;
            }

            set
            {
                quoteItem = value;
            }
        }

        public int QuoteItemId
        {
            get
            {
                if (ViewState["quoteItemId"] != null)
                    return Convert.ToInt32(ViewState["quoteItemId"]);
                else
                    return 0;
            }
            set { ViewState["quoteItemId"] = value; }
        }

        


        #endregion

        public override void DataBind()
        {
            ddlDeliveryTerm.DataSource = ControllerManager.Lookup.List(LookupType.DeliveryTerm);
            ddlDeliveryTerm.DataTextField = "Description";
            ddlDeliveryTerm.DataValueField = "ID";
            ddlDeliveryTerm.DataBind();

            ddlIncoterm.DataSource = ControllerManager.Lookup.List(LookupType.Incoterm);
            ddlIncoterm.DataTextField = "Title";
            ddlIncoterm.DataValueField = "ID";
            ddlIncoterm.DataBind();

            #region Weeks
            string[] weekLst = new string[19];
            weekLst[0] = "N/D";
            weekLst[1] = "1-2";
            weekLst[2] = "3-4";
            weekLst[3] = "5-6";
            weekLst[4] = "7-8";
            weekLst[5] = "9-10";
            weekLst[6] = "11-13";
            weekLst[7] = "14-16";
            weekLst[8] = "17-19";
            weekLst[9] = "20-22";
            weekLst[10] = "23-25";
            weekLst[11] = "26-28";
            weekLst[12] = "29-31";
            weekLst[13] = "32-35";
            weekLst[14] = "36-39";
            weekLst[15] = "40-43";
            weekLst[16] = "44-47";
            weekLst[17] = "48-51";
            weekLst[18] = "52-55";

            ddlDeliveryTime.DataSource = weekLst;
            ddlDeliveryTime.DataBind();
            #endregion

            LoadFields();
            LoadInsideFields();
            SetVisibility();
        }

        private void LoadFields()
        {
            if (QuoteItem != null)
            {
                lblCode.Text = QuoteItem.Code;
                if(!string.IsNullOrEmpty( QuoteItem.Model))
                    lblDescription.Text = StringFormat.Cut(QuoteItem.Model, 32);
                lblDescription.ToolTip = QuoteItem.Description;
                lblPV.Text = QuoteItem.PriceSell;
                lblQuantity.Text = QuoteItem.Quantity.ToString();
                lblDeliveryTime.Text = QuoteItem.DeliveryTime;
                if (quoteItem.SaleCondition != null)
                {
                    lblIncoterm.Text = QuoteItem.SaleCondition.Title;
                    lblIncoterm.ToolTip = QuoteItem.SaleCondition.Description;
                }

                lblSubtotal.Text = QuoteItem.PriceCurrency.Description + " " + QuoteItem.Subtotal.ToString("#.00");

                lblPL.Text = QuoteItem.LastPriceList;
                lblPL.ToolTip = QuoteItem.PriceList;
                
            }
        }

        private void LoadInsideFields()
        {
            if (QuoteItem != null)
            {
                txtQuantity.Value = QuoteItem.Quantity;
                if(QuoteItem.SaleCondition != null)
                    ddlIncoterm.Value = QuoteItem.SaleCondition.ID;
                ddlDeliveryTime.Value = QuoteItem.DeliveryTime;
                if(QuoteItem.DeliveryTerm != null)
                    ddlDeliveryTerm.Value = QuoteItem.DeliveryTerm.ID;

                txtListPrice.Value = QuoteItem.LastPrice.ToString("0.##");
                lblTP.Value = QuoteItem.PriceCurrency.Description + " " + QuoteItem.PriceBase.PricePurchase.ToString("0.##");
                lblGrp.Text = QuoteItem.PriceCurrency.Description + " " + QuoteItem.PriceBase.PriceSuggest.ToString("0.##");

                lblcurrency.Value = QuoteItem.PriceCurrency.Description;
                lblTpNum.Value = QuoteItem.PriceBase.PricePurchase.ToString();
                lblGrpNum.Value = QuoteItem.PriceBase.PriceSuggest.ToString();

                //Rango para el PL
                QuoteRange plRange = ControllerManager.QuoteRange.GetRange();
                hidMaxPL.Value = plRange.Maximum.ToString();
                hidMinPL.Value = plRange.Minimum.ToString();

                //rangos para index y ctr
                hidMinCtr.Value = ControllerManager.QuoteRange.GetQuoteMinimumCtr();
                hidMinIndex.Value = ControllerManager.QuoteRange.GetQuoteMinimumIndex();

                hidOriginalPl.Value = QuoteItem.LastPrice.ToString("#.##");
                
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            QuoteItem = ControllerManager.Quote.EditQuoteItem(QuoteId, QuoteItemId, Convert.ToInt32(txtQuantity.Value), ddlDeliveryTime.SelectedValue, ControllerManager.Lookup.GetById(Convert.ToInt32(ddlDeliveryTerm.SelectedValue)), ControllerManager.Lookup.GetById(Convert.ToInt32(ddlIncoterm.SelectedValue)), Convert.ToDecimal(txtListPrice.Value));
            Mode = EditionMode.View;
            LoadInsideFields();
            LoadFields();
            SetVisibility();
        }

        private void SetVisibility()
        {
            bool enabled = (Mode == EditionMode.Edit || Mode == EditionMode.Create);

            foreach (Control c in this.Controls)
                if (c is WebControl && c.GetType() != typeof(LinkButton) && c.GetType() != typeof(ImageButton) && c.GetType() != typeof(HtmlContainerControl))
                    (c as WebControl).Enabled = enabled;

            lnkDetails.Visible = (Mode != EditionMode.View);
            lnkEdit.Visible = (Mode == EditionMode.View);
            btnSave.Visible = (Mode != EditionMode.View);

            //txtListPrice.Visible = enabled;
            //lblIPL.Visible = enabled;

            //txtQuantity.Visible = enabled;
            //lblIQuantity.Visible = enabled;

            //ddlIncoterm.Visible = enabled;
            //lblIIncoterm.Visible = enabled;

            //ddlDeliveryTerm.Visible = enabled;
            //ddlDeliveryTime.Visible = enabled;
            //lblIDeliveryTime.Visible = enabled;

            ExecutePermissionValidator epv = new ExecutePermissionValidator();
            epv.ClassType = typeof(QuoteRange);
            epv.KeyIdentifier = Config.CanSeeImportantQuoteData;

            lblTP.Visible = PermissionManager.Check(epv);
            lblITp.Visible = PermissionManager.Check(epv);

            lblGrp.Visible = PermissionManager.Check(epv);
            lblIGrp.Visible = PermissionManager.Check(epv);

            lblCtr.Visible = PermissionManager.Check(epv);
            lblICtr.Visible = PermissionManager.Check(epv);

            lblIndex.Visible = PermissionManager.Check(epv);
            lblIIndex.Visible = PermissionManager.Check(epv);

            if(enabled)
                divInsideFields.Attributes["class"] = "showme";
            else
                divInsideFields.Attributes["class"] = "hideme";

        }

        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            Mode = EditionMode.Edit;
            SetVisibility();
        }

        protected void lnkDetails_Click(object sender, EventArgs e)
        {
            Mode = EditionMode.View;
            QuoteItem = ControllerManager.QuoteItem.GetById(QuoteItemId);
            LoadInsideFields();
            LoadFields();
            SetVisibility();
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            string valGroup = "val" + QuoteItemId;
            btnSave.ValidationGroup = valGroup;
            txtQuantity.ValidationGroup = valGroup;
            txtListPrice.ValidationGroup = valGroup;
            ddlIncoterm.ValidationGroup = valGroup;
            ddlDeliveryTime.ValidationGroup = valGroup;
            ddlDeliveryTerm.ValidationGroup = valGroup;
            //customvPL.ValidationGroup = valGroup;

            RangeValidator rgVal = new RangeValidator();
            rgVal.ControlToValidate = "txtQuantity";
            rgVal.MinimumValue = "1";
            rgVal.MaximumValue = "9999";
            rgVal.ValidationGroup = valGroup;
            rgVal.Display = ValidatorDisplay.Dynamic;
            rgVal.ErrorMessage = "Ingrese un número entre 1 y 9999.";
            rgVal.Type = ValidationDataType.Integer;
            rgVal.CssClass = "valerror";
            txtQuantity.AddValidator(rgVal);

            CompareValidator cvPL = new CompareValidator();
            cvPL.ControlToValidate = "txtListPrice";
            cvPL.Type = ValidationDataType.Double;
            cvPL.ValueToCompare = "0";
            cvPL.Operator = ValidationCompareOperator.GreaterThan;
            cvPL.CssClass = "valerror";
            cvPL.Display = ValidatorDisplay.Dynamic;
            cvPL.ErrorMessage = "Ingrese un numero mayor a 0.";
            txtListPrice.AddValidator(cvPL);

            //CustomValidator customvPL = new CustomValidator();
            //customvPL.ControlToValidate="txtListPrice";
            //customvPL.Display = ValidatorDisplay.Dynamic; 
            //customvPL.Text="PL Inconrrecto."; 
            //customvPL.CssClass="valerror"; 
            //customvPL.EnableClientScript=true;
            //customvPL.ClientValidationFunction = "CalculateRange()";
            //customvPL.ValidateEmptyText = true;
            //customvPL.ServerValidate += new ServerValidateEventHandler(cv_ServerValidate);
            //customvPL.ValidationGroup = valGroup;
            //txtListPrice.AddValidator(customvPL);
        }
        //void cv_ServerValidate(object source, ServerValidateEventArgs args)
        //{
        //    //throw new Exception("The method or operation is not implemented.");
        //}
    }
}