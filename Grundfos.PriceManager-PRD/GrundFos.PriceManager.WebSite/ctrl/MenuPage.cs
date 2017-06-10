using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using PriceManager.Business;
using PriceManager.Core;
using PriceManager.Common;

namespace GrundFos.PriceManager.WebSite
{
    public abstract class BaseMasterPage : MasterPage
    {
        public abstract void LoadMenu();
    }

    public abstract class MenuPage : Page
    {
        public abstract string GetTitle();
    }

    public class PriceListPage : MenuPage
    {
        private int _priceListId = 0;

        public int PriceListId
        {
            get { return _priceListId; }
            set { _priceListId = value; }
        }

        protected override void OnInit(EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
                this.PriceListId = Convert.ToInt32(Request.QueryString["Id"]);

            base.OnInit(e);
        }

        public override string GetTitle()
        {
            string title = string.Empty;
            if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
            {
                int priceListId = Convert.ToInt32(Request.QueryString["Id"]);
                PriceList pl = ControllerManager.PriceList.GetById(priceListId);
                if (pl != null)
                    title += (!string.IsNullOrEmpty(pl.FullName)) ? pl.FullName : pl.ID.ToString();

                if (!string.IsNullOrEmpty(Request.QueryString["CatalogPageId"]))
                {
                    int lineId = Convert.ToInt32(Request.QueryString["CatalogPageId"]);
                    CatalogPage l = ControllerManager.CatalogPage.GetById(lineId);
                    if (l != null)
                        title += " - " + l.Name;
                }
                else
                {
                    title += " - Todas las páginas";
                }
            }
            else
                title = Resource.Business.GetString("GridViewColumnListName");

            return title;
        }
    }

    public class DistributorPage : MenuPage
    {
        private int _distributorId = 0;

        public int DistributorId 
        {
            get { return _distributorId; }
            set { _distributorId = value; }
        }

        protected override void OnInit(EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
                this.DistributorId = Convert.ToInt32(Request.QueryString["Id"]);

            base.OnInit(e);
        }

        public override string GetTitle()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
            {
                int priceListId = Convert.ToInt32(Request.QueryString["Id"]);
                Distributor pl = ControllerManager.Distributor.GetById(priceListId);
                if (pl != null)
                    return (!string.IsNullOrEmpty(pl.Name)) ? pl.ID + " - " + pl.Name : pl.ID.ToString();
            }

            return "Canales de Venta";
        }
    }

    public class ProductsPage : MenuPage
    {
        private int _productId = 0;

        public int ProductId 
        {
            get { return _productId; }
            set { _productId = value; }
        }

        protected override void OnInit(EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                this.ProductId = Convert.ToInt32(Request.QueryString["id"]);

            base.OnInit(e);
        }

        public override string GetTitle()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                int productId = Convert.ToInt32(Request.QueryString["id"]);
                
                Product p = ControllerManager.Product.GetById(productId);
                if (p != null && !string.IsNullOrEmpty(p.Code))
                    return (!string.IsNullOrEmpty(p.Model)) ? p.Code + " - " + p.Model : p.Code.ToString();
                else
                    return Resource.Business.GetString("ProductTitle");
            }
            return Resource.Business.GetString("ProductTitle");
        }
    }

    public class CategoryPage : MenuPage
    {
        public override string GetTitle()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
            {
                int id = Convert.ToInt32(Request.QueryString["Id"]);

                CategoryBase c = ControllerManager.CategoryBase.GetById(id);
                if (c != null)
                    return c.Name.ToString();

                return Resource.Business.GetString("CategoryTitle");
            }

            return Resource.Business.GetString("CategoryTitle");
        }
    }

    public class ProviderPage : MenuPage
    {
        public override string GetTitle()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
            {
                int providerId = Convert.ToInt32(Request.QueryString["Id"]);
                Provider p = ControllerManager.Provider.GetById(providerId);
                if (p != null)
                    return (!string.IsNullOrEmpty(p.Name)) ? p.Code + " - " + p.Name : p.Code.ToString();
                else
                    return Resource.Business.GetString("ProviderTitle");
            }
            else
              return Resource.Business.GetString("ProviderTitle");
        }
    }

    public class CurrencyPage : MenuPage
    {
        public override string GetTitle()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
            {
                int id = Convert.ToInt32(Request.QueryString["Id"]);

                Currency c = ControllerManager.Currency.GetById(id);
                if (c != null)
                    return c.Description.ToString();

                return Resource.Business.GetString("CurrencyTitle");
            }
            return Resource.Business.GetString("CurrencyTitle");
        }
    }

    public class PriceGroupPage : MenuPage
    {
        public override string GetTitle()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["PriceGroupId"]))
            {
                int id = Convert.ToInt32(Request.QueryString["PriceGroupId"]);

                PriceGroup pg = ControllerManager.PriceGroup.GetById(id);
                if (pg != null)
                    return pg.Name;

                return Resource.Business.GetString("PriceGroupTitle");
            }
            return Resource.Business.GetString("PriceGroupTitle");
        }
    }

    public class LookupPage : MenuPage
    {
        public override string GetTitle()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
            {
                int id = Convert.ToInt32(Request.QueryString["Id"]);

                Lookup l = ControllerManager.Lookup.GetById(id);
                if (l != null)
                    return l.Description.ToString();

                return Resource.Business.GetString("LookUpTitle");
            }
            return Resource.Business.GetString("LookUpTitle");
        }
    }

    public class QuotePage : MenuPage
    {
        public override string GetTitle()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
            {
                int quoteId = Convert.ToInt32(Request.QueryString["Id"]);
                Quote q = ControllerManager.Quote.GetById(quoteId);
                if (q != null)
                    if (!string.IsNullOrEmpty(q.Description))
                        if (q.Description.Length > 16)
                            return q.Number + " - " + q.Description.Substring(0, 16) + "...";
                        else
                            return q.Number + " - " + q.Description;
                    else return q.Number.ToString();
            }

            return Resource.Business.GetString("QuoteTitle");
        }
    }

    public class PricePoliticPage : MenuPage
    {
        public override string GetTitle()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
            {
                int id = Convert.ToInt32(Request.QueryString["Id"]);

               PriceCalculation pc = ControllerManager.PriceCalculation.GetById(id);
               string title = Resource.Business.GetString("PricePoliticTitle");
                if (pc != null)
               {
                   if (pc.Provider != null)
                       title = title + " - "+ pc.Provider.Name;
                   if (pc.CategoryBase != null)
                       title = title + " - " + pc.CategoryBase.Name;

                   return title;

               }

               return Resource.Business.GetString("PricePoliticTitle");
            }
            return Resource.Business.GetString("PricePoliticTitle");
        }
    }

    public class ImportPage : MenuPage
    {
        public override string GetTitle()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                Guid Id = new Guid(Request.QueryString["id"]);
                PriceImport pi = ControllerManager.PriceImport.GetById(Id);
                if (pi != null)
                    return (!string.IsNullOrEmpty(pi.Description)) ? pi.Number.ToString() + " - " + pi.Description : pi.Number.ToString();
                else
                    return Resource.Business.GetString("ImportTitle");
            }
            else
                return Resource.Business.GetString("ImportTitle");
        }
    }

    public class PageListPage : MenuPage
    {
        public override string GetTitle()
        {
            string title = Resource.Business.GetString("PageListTitle");
            if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
            {
                int id = Convert.ToInt32(Request.QueryString["Id"]);
                CatalogPage cp = ControllerManager.CatalogPage.GetById(id);

                if (cp != null)
                    title = title + " - " + cp.Name.ToString();
            }

            return title;
        }
    }
}
