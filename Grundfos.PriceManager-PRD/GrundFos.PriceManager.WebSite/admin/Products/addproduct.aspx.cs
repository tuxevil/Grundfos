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

namespace GrundFos.PriceManager.WebSite.admin.Products
{
    public partial class addproduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlPurchase.DataSource = ControllerManager.Currency.GetAll();
                ddlPurchase.DataTextField = "Description";
                ddlPurchase.DataValueField = "ID";
                ddlPurchase.DataBind();

                ddlList.DataSource = ControllerManager.Currency.GetAll();
                ddlList.DataTextField = "Description";
                ddlList.DataValueField = "ID";
                ddlList.DataBind();

                ddlSuggested.DataSource = ControllerManager.Currency.GetAll();
                ddlSuggested.DataTextField = "Description";
                ddlSuggested.DataValueField = "ID";
                ddlSuggested.DataBind();

                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    LoadFields(Convert.ToInt32(Request.QueryString["id"]));
                    txtPriceList.Enabled = false;
                    txtPriceSuggested.Enabled = false;
                    txtPricePurchase.Enabled = false;
                    ddlSuggested.Enabled = false;
                    ddlPurchase.Enabled = false;
                    ddlList.Enabled = false;
                    lstProviders.Visible = true;
                    ddlProvider.Visible = false;
                }
                else
                {
                    ddlProvider.DataSource = ControllerManager.Provider.GetActives();
                    ddlProvider.DataTextField = "Name";
                    ddlProvider.DataValueField = "ID";
                    ddlProvider.DataBind();
                    ddlProvider.Visible = true;
                    lstProviders.Visible = false;
                }
                
            }
        }

        private void LoadFields(int id)
        {
            ProductInfo pi = ControllerManager.ProductInfo.GetById(id);
            
            txtCode.Text = pi.PriceBase.Product.Code;

            txtDescripcion.Text = pi.PriceBase.Product.Description;

            if (pi.PriceBase.PriceListCurrency != null)
                ddlList.SelectedValue = ddlList.Items.FindByValue(pi.PriceBase.PriceListCurrency.ID.ToString()).Value;
            txtPriceList.Text = pi.PriceBase.PriceList.ToString("#0.##");

            txtPricePurchase.Text = pi.PriceBase.PricePurchase.ToString("#0.##");
            if (pi.PriceBase.PricePurchaseCurrency != null)
                ddlPurchase.SelectedValue = ddlPurchase.Items.FindByValue(pi.PriceBase.PricePurchaseCurrency.ID.ToString()).Value;

            if (pi.PriceBase.PriceSuggestCurrency != null)
                ddlSuggested.SelectedValue = ddlSuggested.Items.FindByValue(pi.PriceBase.PriceSuggestCurrency.ID.ToString()).Value;
            txtPriceSuggested.Text = pi.PriceBase.PriceSuggest.ToString("#0.##");
            txtPriceSell.Text = pi.PriceBase.PriceListCurrency.Description.ToString() + " " + pi.PriceSell.ToString("#0.##");
            
            if(pi.PriceBase != null && pi.PriceBase.Product != null && pi.PriceBase.Product.Frequency != null)
                 rblProductType.SelectedValue = rblProductType.Items.FindByValue(pi.PriceBase.Product.Frequency.ToString()).Value;
            txtProvider.Text = pi.PriceBase.ProviderCode;
            txtModel.Text = pi.PriceBase.Product.Model;
            
            lstProviders.DataSource =pi.PriceBase.Product.Providers;
            lstProviders.DataTextField = "Name";
            lstProviders.DataValueField = "ID";
            lstProviders.DataBind();

            txtIndex.Text = pi.Index.ToString("#0.#");
            txtCTM.Text = ControllerManager.Currency.GetBaseCurrency().Description + " " + pi.CTM.ToString("#0.##");
            txtCTR.Text = "% " + pi.CTR.ToString("#0.##"); 
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            bool isNew = true;
            int id = 0;
            int p = 0;
           
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                id = Convert.ToInt32(Request.QueryString["id"]);
                isNew = false;
            }
            else
            {
               p = Convert.ToInt32(ddlProvider.SelectedValue);
            }
            decimal list = 0;
            if (!string.IsNullOrEmpty(txtPriceList.Text))
                list = Convert.ToDecimal(txtPriceList.Text);

            decimal suggest = 0;
            if (!string.IsNullOrEmpty(txtPriceSuggested.Text))
                suggest = Convert.ToDecimal(txtPriceSuggested.Text);

            decimal purchase = 0;
            if (!string.IsNullOrEmpty(txtPricePurchase.Text))
                purchase = Convert.ToDecimal(txtPricePurchase.Text);

            if (ControllerManager.PriceBase.ModifyCreateProduct(id, txtCode.Text, txtDescripcion.Text, ((Frequency)Enum.Parse(typeof(Frequency), rblProductType.SelectedValue)), txtModel.Text, txtProvider.Text, p, isNew, ControllerManager.Currency.GetById(Convert.ToInt32(ddlList.SelectedValue)), ControllerManager.Currency.GetById(Convert.ToInt32(ddlSuggested.SelectedValue)), ControllerManager.Currency.GetById(Convert.ToInt32(ddlPurchase.SelectedValue)), list, suggest, purchase))
                Response.Redirect("default.aspx");
            else
                lblError.Visible = true;
            
         }
    }
}
