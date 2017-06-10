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
using System.IO;
using PriceManager;

namespace GrundFos.PriceManager.WebSite.ctrl.editors
{
    public partial class ProductsEditor : System.Web.UI.UserControl
    {
        #region Product
        public int PriceBaseId
        {
            get
            {
                if (ViewState["pricebaseid"] != null)
                    return Convert.ToInt32(ViewState["pricebaseid"]);
                else
                    return 0;
            }
            set { ViewState["pricebaseid"] = value; }
        }

        public int ProductId
        {
            get
            {
                if (ViewState["productId"] != null)
                    return Convert.ToInt32(ViewState["productId"]);
                else
                    return 0;
            }
            set { ViewState["productId"] = value; }
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

        public bool IsEdit
        {
            get
            {
                if (ViewState["edit"] != null)
                    return (bool)ViewState["edit"];
                return false;
            }
            set { ViewState["edit"] = value; }
        }

        public bool IsAdminProduct
        {
            get
            {
                if (ViewState["admin"] != null)
                    return (bool)ViewState["admin"];
                return false;
            }
            set { ViewState["admin"] = value; }
        }

        #endregion

        #region load
        public override void DataBind()
        {
            if (!IsPostBack)
            {
                IList<Currency> currencyLst = ControllerManager.Currency.GetAll();

                ddlPurchase.DataSource = currencyLst;
                ddlPurchase.DataTextField = "Description";
                ddlPurchase.DataValueField = "ID";
                ddlPurchase.DataBind();

                ddlList.DataSource = currencyLst;
                ddlList.DataTextField = "Description";
                ddlList.DataValueField = "ID";
                ddlList.DataBind();

                ddlSuggested.DataSource = currencyLst;
                ddlSuggested.DataTextField = "Description";
                ddlSuggested.DataValueField = "ID";
                ddlSuggested.DataBind();

                ddlProvider.DataSource = ControllerManager.Provider.GetActives();
                ddlProvider.DataTextField = "Name";
                ddlProvider.DataValueField = "ID";
                ddlProvider.DataBind();

                ddlFrequency.DataSource = EnumHelper.GetList(typeof(Frequency));
                ddlFrequency.DataTextField = "Value";
                ddlFrequency.DataValueField = "Key";
                ddlFrequency.DataBind();

                if (Mode != EditionMode.Create)
                    LoadFields();
                else
                    imgImage.Visible = false;

                SetVisibility();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            CustomValidator cv;
            if (IsAdminProduct)
            {
                cv = new CustomValidator();
                cv.ID = "cv1of2";
                cv.ValidationGroup = "form";
                cv.Display = ValidatorDisplay.Dynamic;
                cv.ErrorMessage = "Por favor, ingrese Código o Código de Proveedor.";
                cv.ClientValidationFunction = "CheckCodes";
                cv.EnableClientScript = true;
                cv.ValidateEmptyText = true;
                cv.ServerValidate += new ServerValidateEventHandler(cv_ServerValidate);

                txtCode.AddValidator(cv);
            }

            cv = new CustomValidator();
            cv.ID = "cv1of2";
            cv.ValidationGroup = "form";
            cv.Display = ValidatorDisplay.Dynamic;
            cv.ErrorMessage = "Por favor, ingrese Código o Código de Proveedor.";
            cv.ClientValidationFunction = "CheckCodes";
            cv.EnableClientScript = true;
            cv.ValidateEmptyText = true;
            cv.ServerValidate += new ServerValidateEventHandler(cv_ServerValidate);

            this.txtProvider.AddValidator(cv);

        }

        void cv_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        private void LoadFields()
        {
            if (ProductId != 0 || PriceBaseId != 0)
            {
                Product product;
                ProductInfo pi = null;
                if (ProductId != 0)
                {
                    product = ControllerManager.Product.GetById(ProductId);
                }
                else
                {
                    pi = ControllerManager.ProductInfo.GetById(PriceBaseId);
                    product = pi.PriceBase.Product;
                }

                txtCode.Text = product.Code;
                txtDescripcion.Text = product.Description;
                if(pi != null)
                    txtProvider.Text = pi.PriceBase.ProviderCode;
                txtModel.Text = product.Model;
                //New fields
                txtAlternativeModel.Text = product.ModelAlternative;
                txtEAN.Text = product.EAN;
                txtDescriptionAlternative.Text = product.DescriptionAlternative;
                txtObservations.Text = product.Observations;

                if (product != null && product.Frequency != null)
                    ddlFrequency.SelectedValue = product.Frequency.ToString();

                if (pi != null)
                {
                    //Creation Fields
                    if (pi.PriceBase.PriceListCurrency != null)
                        ddlList.SelectedValue = ddlList.Items.FindByValue(pi.PriceBase.PriceListCurrency.ID.ToString()).Value;
                    txtPriceList.Text = pi.PriceBase.PriceList.ToString("#0.##");

                    txtPricePurchase.Text = pi.PriceBase.PricePurchase.ToString("#0.##");

                    if (pi.PriceBase.PricePurchaseCurrency != null)
                        ddlPurchase.SelectedValue = ddlPurchase.Items.FindByValue(pi.PriceBase.PricePurchaseCurrency.ID.ToString()).Value;

                    if (pi.PriceBase.PriceSuggestCurrency != null)
                        ddlSuggested.SelectedValue = ddlSuggested.Items.FindByValue(pi.PriceBase.PriceSuggestCurrency.ID.ToString()).Value;
                    txtPriceSuggested.Text = pi.PriceBase.PriceSuggest.ToString("#0.##");

                    

                    if (pi.PriceBase != null && pi.PriceBase.Provider != null)
                        ddlProvider.SelectedValue = pi.PriceBase.Provider.ID.ToString();

                    lblIndex.Text = pi.Index.ToString("#0.##");
                    lblCtm.Text = pi.PriceBase.PriceSuggestCurrency.Description + " " + pi.CTM.ToString("#0.##");
                    lblCtr.Text = "% " + pi.CTR.ToString("#0.##");
                    lblPv.Text = pi.PriceBase.PriceListCurrency.Description + " " + pi.PriceSell.ToString("#0.##");
                }

                if (!string.IsNullOrEmpty(product.Image))
                    imgImage.ImageUrl = Path.Combine(Config.ImagesProductsPath, product.Image);
                else
                    imgImage.Visible = false;
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

            if (PriceBaseId != 0)
                lnkEdit.Visible = !enabled;
            else
                lnkEdit.Visible = (Mode != EditionMode.Create);

            pricesForm.Visible = (IsEdit && Mode != EditionMode.View);
            
            if (Mode != EditionMode.View)
                txtObservations.CssClass = "mceEditor";
            else
                txtObservations.CssClass = "mceEditorReadOnly";

            lnkEdit.Visible = (PermissionManager.Check(lnkEdit) && Mode == EditionMode.View);

            ddlSuggested.Enabled = (Mode == EditionMode.Create);
            ddlPurchase.Enabled = (Mode == EditionMode.Create);
            ddlList.Enabled = (Mode == EditionMode.Create);
            txtPriceList.Enabled = (Mode == EditionMode.Create);
            txtPricePurchase.Enabled = (Mode == EditionMode.Create);
            txtPriceSuggested.Enabled = (Mode == EditionMode.Create);
            ddlProvider.Enabled = (Mode == EditionMode.Create);
        }
        #endregion

        #region Events
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            bool isNew = true;
            int p = 0;

            if (PriceBaseId != 0 || ProductId != 0)
                isNew = false;
            else
                p = Convert.ToInt32(ddlProvider.SelectedValue);

            decimal list = 0;
            if (!string.IsNullOrEmpty(txtPriceList.Text))
                list = Convert.ToDecimal(txtPriceList.Text);

            decimal suggest = 0;
            if (!string.IsNullOrEmpty(txtPriceSuggested.Text))
                suggest = Convert.ToDecimal(txtPriceSuggested.Text);

            decimal purchase = 0;
            if (!string.IsNullOrEmpty(txtPricePurchase.Text))
                purchase = Convert.ToDecimal(txtPricePurchase.Text);

            Frequency frequency = (Frequency)Enum.Parse(typeof(Frequency), ddlFrequency.SelectedValue);

            int productId = 0;
            int priceBaseId = 0;
            if (ControllerManager.PriceBase.ModifyCreateProduct(PriceBaseId, ProductId, txtCode.StringValue, txtDescripcion.StringValue, frequency, txtModel.StringValue, txtProvider.StringValue, p, isNew,
                ControllerManager.Currency.GetById(Convert.ToInt32(ddlList.SelectedValue)),
                ControllerManager.Currency.GetById(Convert.ToInt32(ddlSuggested.SelectedValue)),
                ControllerManager.Currency.GetById(Convert.ToInt32(ddlPurchase.SelectedValue)),
                list, suggest, purchase, txtAlternativeModel.StringValue, txtEAN.StringValue, txtDescriptionAlternative.StringValue, txtObservations.StringValue, out productId, out priceBaseId))
            {
                if (Mode != EditionMode.Create)
                {
                    Mode = EditionMode.View;
                    SetVisibility();
                }
                else
                    Response.Redirect("/admin/products/view/?id="+priceBaseId);
            }
            else
                Utils.ShowMessage(this.Page, "El código ingresado ya existes para ese proveedor.", Utils.MessageType.Error);

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
            SetVisibility();
        }
    }
}