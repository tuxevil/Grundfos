using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using PriceManager.Common;
using NybbleMembership;
using PriceManager.Core;

namespace PriceManager.Business.Controls
{
    public class LinkedDropDown : CompositeControl
    {
        protected DropDownList categoryType;
        protected DropDownList categoryResult;

        public bool IsPopUp
        {
            get
            {
                if (ViewState["popup"] != null)
                    return (bool)ViewState["popup"];
                return false;
            }
            set { ViewState["popup"] = value; }
        }

        protected override void CreateChildControls()
        {
            Controls.Clear();

            categoryType = new DropDownList();
            categoryType.ID = "categoryType";
            categoryType.AutoPostBack = true;
            categoryType.Items.Add(new ListItem("--Tipo--", "0"));
            categoryType.Items.Add(new ListItem(Resource.Business.GetString(typeof(Application).FullName), "4"));
            categoryType.Items.Add(new ListItem(Resource.Business.GetString(typeof(Area).FullName), "6"));
            categoryType.Items.Add(new ListItem(Resource.Business.GetString(typeof(Family).FullName), "1"));
            categoryType.Items.Add(new ListItem(Resource.Business.GetString(typeof(Line).FullName), "5"));
            if(!IsPopUp)
                categoryType.Items.Add(new ListItem(Resource.Business.GetString(typeof(CatalogPage).FullName), "2"));
            categoryType.Items.Add(new ListItem(Resource.Business.GetString(typeof(ProductType).FullName), "3"));
            categoryType.SelectedIndexChanged += new EventHandler(categoryType_SelectedIndexChanged);
            categoryType.Width = Unit.Pixel(125);
            
            categoryResult = new DropDownList();
            categoryResult.ID = "categoryResult";
            categoryResult.Items.Insert(0, new ListItem("--Seleccione un tipo--", "0"));
            categoryResult.Width = Unit.Pixel(220);

            this.Controls.Add(categoryType);
            this.Controls.Add(categoryResult);

            ClearChildViewState();
        }

        void categoryType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Update();
        }

        void Update()
        {
            if (categoryType.SelectedValue != "0")
            {
                ListItemCollection lst = ControllerManager.CategoryBase.GetHierarchyItems(categoryType.SelectedValue);
                categoryResult.DataSource = lst;
                categoryResult.DataTextField = "Text";
                categoryResult.DataValueField = "Value";
                categoryResult.DataBind();
                if (categoryResult.Items.Count > 0)
                    categoryResult.Items.Insert(0, new ListItem("--Padre--", "0"));
                else
                    categoryResult.Items.Insert(0, new ListItem("--No existen categorias--", "0"));
                if (Type.GetType(categoryType.SelectedValue) == typeof(CatalogPage))
                    categoryResult.Items.RemoveAt(categoryResult.Items.Count - 1);
            }
            else
            {
                categoryResult.Items.Clear();
                categoryResult.Items.Insert(0, new ListItem("--Seleccione un tipo--", "0"));
            }
        }
        
        public object Values
        {
            get
            {
                int val;
                if (StringFormat.IsInteger(categoryResult.SelectedValue, out val))
                    return val;
                else
                    return categoryResult.SelectedValue;
            }

            set
            {
                if (value != null)
                {
                    CategoryBase cat =  ControllerManager.CategoryBase.GetById(Convert.ToInt32(value));

                    if (ControllerManager.CatalogPage.GetById(Convert.ToInt32(value)) != null)
                        categoryType.SelectedValue = "2";
                    else if (ControllerManager.Family.GetById(Convert.ToInt32(value)) != null)
                        categoryType.SelectedValue = "1";
                    else if (ControllerManager.Application.GetById(Convert.ToInt32(value)) != null)
                        categoryType.SelectedValue = "4";
                    else if (ControllerManager.ProductType.GetById(Convert.ToInt32(value)) != null)
                        categoryType.SelectedValue = "3";
                    else if (ControllerManager.Line.GetById(Convert.ToInt32(value)) != null)
                        categoryType.SelectedValue = "5";
                    else if (ControllerManager.Area.GetById(Convert.ToInt32(value)) != null)
                        categoryType.SelectedValue = "6";

                    Update();
                    categoryResult.SelectedValue = categoryResult.Items.FindByValue(value.ToString()).Value;
                    Update();
                }
                else
                    categoryResult.SelectedIndex = 0;
            }
        }

        public int Index
        {
            get { return categoryResult.SelectedIndex; }
            set
            {
                if(value == 0)
                    categoryType.SelectedIndex = 0;
                categoryResult.SelectedIndex = value;
                Update();
            }
        }

        public object TextValue
        {
            get
            {
                this.EnsureChildControls();
                return categoryResult.SelectedItem.Text;
            }
        }
    }
}
