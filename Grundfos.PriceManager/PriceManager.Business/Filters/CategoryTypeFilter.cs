using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using PriceManager.Common;
using PriceManager.Core;

namespace PriceManager.Business.Filters
{
    public class CategoryTypeFilter : DropDownFilter
    {
        #region Abstract Members

        public override Type ClassName
        {
            get { return typeof(Type); }
        }

        public override string PropertyName
        {
            get { return "FullName"; }
        }

        public override string FilterName
        {
            get { return PropertyName; }
        }

        #endregion

        protected override void OnInit(EventArgs e)
        {
            // OnInit always refresh because we need it for setup on page.
            Refresh();

            base.OnInit(e);
        }

        public override void Refresh()
        {
            //List<Pair> cblst = new List<Pair>();
            //cblst.Add( new Pair(Resource.Business.GetString(typeof(CatalogPage).FullName), typeof(CatalogPage).FullName));
            //cblst.Add(new Pair(Resource.Business.GetString(typeof(Family).FullName), typeof(Family).FullName));
            //cblst.Add(new Pair(Resource.Business.GetString(typeof(Category).FullName), typeof(Category).FullName));
            //cblst.Add(new Pair(Resource.Business.GetString(typeof(ProductType).FullName), typeof(ProductType).FullName));

            //DataSource = cblst;
            //DataTextField = "First";
            //DataValueField = "Second";
            //DataBind();
            Items.Insert(0, new ListItem("--Tipo de Categoria--", "0"));
            Items.Add(new ListItem(Resource.Business.GetString(typeof(CatalogPage).FullName), typeof(CatalogPage).FullName));
            Items.Add(new ListItem(Resource.Business.GetString(typeof(Family).FullName), typeof(Family).FullName));
            Items.Add(new ListItem(Resource.Business.GetString(typeof(Application).FullName), typeof(Application).FullName));
            Items.Add(new ListItem(Resource.Business.GetString(typeof(ProductType).FullName), typeof(ProductType).FullName));
        }
    }
}
