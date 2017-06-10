using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using PriceManager.Business;
using PriceManager.Core;

namespace GrundFos.PriceManager.WebSite.admin
{
    public partial class addproduct : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HtmlAnchor temp = (HtmlAnchor)Master.FindControl("lnkproduct");
                temp.Attributes["class"] = "current";
                LoadCombos();
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    LoadFields(Convert.ToInt32(Request.QueryString["id"]));
                    txtCode.Enabled = false;
                }
            }
        }

        private void LoadFields(int id)
        {
           ProductPrice pP = new ProductPrice();
            pP =  ControllerManager.ProductPrice.GetById(id);
            txtCode.Text = pP.Product.Code;
            txtDescripcion.Text = pP.Product.Description;
            txtPriceList.Text = pP.Price.ToString();
            txtPricePurchase.Text = pP.Product.BasePrices[0].PricePurchase.ToString();
            txtPriceSuggested.Text = pP.Product.BasePrices[0].PriceSuggest.ToString();
            ddlListCurrency.SelectedValue = ddlListCurrency.Items.FindByValue(pP.PriceCurrency.ID.ToString()).Value;
            ddlPurchaseCurrency.SelectedValue = ddlPurchaseCurrency.Items.FindByValue(pP.Product.BasePrices[0].PricePurchaseCurrency.ID.ToString()).Value;
            ddlSuggestedCurrency.SelectedValue = ddlSuggestedCurrency.Items.FindByValue(pP.Product.BasePrices[0].PriceSuggestCurrency.ID.ToString()).Value;
            rblProductType.SelectedValue = rblProductType.Items.FindByValue(pP.PriceList.Discount.ID.ToString()).Value;
            
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            lblErrorPrice.Visible = false;
            int id = 0;
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                 id = Convert.ToInt32(Request.QueryString["id"]);
            
            ProductType type;

            type = rblProductType.SelectedValue == "1" ? ProductType.Hz50 : ProductType.Hz60;
           
            if(isCorrectlyLoaded(id, type))
           {
                ControllerManager.ProductPrice.ModifyProduct(id, txtDescripcion.Text, txtCode.Text, Convert.ToDecimal(txtPriceSuggested.Text.Replace(",", ".")), ControllerManager.Currency.GetById(Convert.ToInt32(ddlSuggestedCurrency.SelectedValue)), Convert.ToDecimal(txtPricePurchase.Text.Replace(",", ".")), ControllerManager.Currency.GetById(Convert.ToInt32(ddlPurchaseCurrency.SelectedValue)), Convert.ToDecimal(txtPriceList.Text.Replace(",", ".")), ControllerManager.Currency.GetById(Convert.ToInt32(ddlListCurrency.SelectedValue)), type, (Guid)Membership.GetUser().ProviderUserKey);

                Response.Redirect("modifyProduct.aspx");
           }
        }

        private bool isCorrectlyLoaded(int id, ProductType type)
        {
            if (string.IsNullOrEmpty(txtPricePurchase.Text))
                txtPricePurchase.Text = "0,000";
            if (string.IsNullOrEmpty(txtPriceSuggested.Text))
                txtPriceSuggested.Text = "0,000";

            if (!string.IsNullOrEmpty(txtCode.Text))
            {
                ProductPrice pp = ControllerManager.ProductPrice.GetById(id);
                
                if (pp != null)
                {
                    //modify
                    if ((pp.Product.Code == txtCode.Text) && (pp.PriceList.Type == type))
                        return true;
                    else 
                    {
                        if (ControllerManager.ProductPrice.ExistsProduct(txtCode.Text, type))
                        {
                            lblError.Text = "El código ingresado ya existe. Por favor ingrese un nuevo código.";
                            lblError.Visible = true;
                            return false;
                        }
                        else
                            if (string.IsNullOrEmpty(txtPriceList.Text) || (Convert.ToDecimal(txtPriceList.Text) <= 0))
                            {
                                lblErrorPrice.Text = "El precio de lista debe ser mayor a 0.";
                                lblErrorPrice.Visible = true;
                                return false;
                            }
                            else
                               return true;
                    }
                }
                else
                    //create
                    if(ControllerManager.ProductPrice.ExistsProduct(txtCode.Text, type))
                    {
                        lblError.Text = "Ya existe un producto de ese tipo con dicho código. Por favor, ingrese un nuevo código o cambie el tipo.";
                        lblError.Visible = true;
                        return false;
                    }
                    else
                        if (string.IsNullOrEmpty(txtPriceList.Text) || (Convert.ToDecimal(txtPriceList.Text) <= 0))
                        {
                            lblErrorPrice.Text = "El precio de lista debe ser mayor a 0.";
                            lblErrorPrice.Visible = true;
                            return false;
                        }
                        else
                            return true;
            }
            else
            {
                lblError.Text = "Por favor, complete el código.";
                lblError.Visible = true;
                return false;
            }

            
                 
        }

        protected void LoadCombos()
        {
            ddlListCurrency.DataSource = ControllerManager.Currency.GetAll();
            ddlListCurrency.DataTextField = "Description";
            ddlListCurrency.DataValueField = "ID";
            ddlListCurrency.DataBind();

            ddlPurchaseCurrency.DataSource = ControllerManager.Currency.GetAll();
            ddlPurchaseCurrency.DataTextField = "Description";
            ddlPurchaseCurrency.DataValueField = "ID";
            ddlPurchaseCurrency.DataBind();

            ddlSuggestedCurrency.DataSource = ControllerManager.Currency.GetAll();
            ddlSuggestedCurrency.DataTextField = "Description";
            ddlSuggestedCurrency.DataValueField = "ID";
            ddlSuggestedCurrency.DataBind();

        }

        
    }
}
