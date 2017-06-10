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

namespace GrundFos.PriceManager.WebSite.ctrl.editors
{
    public partial class CategoryEditor : System.Web.UI.UserControl
    {
        #region Properties
        
        public int CategoryId
        {
            get
            {
                if (ViewState["CategoryId"] != null)
                    return Convert.ToInt32(ViewState["CategoryId"]);
                else
                    return 0;
            }
            set { ViewState["CategoryId"] = value; }
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

        public bool IsPageList
        {
            get
            {
                if (ViewState["PageList"] != null)
                    return (bool)ViewState["PageList"];
                return false;
            }
            set { ViewState["PageList"] = value; }
        }

        public bool IsPageListSon
        {
            get
            {
                if (ViewState["PageListSon"] != null)
                    return (bool)ViewState["PageListSon"];
                return false;
            }
            set { ViewState["PageListSon"] = value; }
        }
        #endregion

        #region Load

        public override void DataBind()
        {
            if (!Page.IsPostBack)
            {
                ListItemCollection lst = new ListItemCollection();

                lst.Add(new ListItem(Resource.Business.GetString(typeof(Application).FullName), "4"));
                lst.Add(new ListItem(Resource.Business.GetString(typeof(Area).FullName), "6"));
                lst.Add(new ListItem(Resource.Business.GetString(typeof(Family).FullName), "1"));
                lst.Add(new ListItem(Resource.Business.GetString(typeof(Line).FullName), "5"));
                lst.Add(new ListItem(Resource.Business.GetString(typeof(CatalogPage).FullName), "2"));
                lst.Add(new ListItem(Resource.Business.GetString(typeof(ProductType).FullName), "3"));

                ddlType.DataSource = lst;
                ddlType.DataTextField = "Text";
                ddlType.DataValueField = "Value";
                ddlType.DataBind();
                ddlType.SelectedValue = "2";
                
                
                if (Mode != EditionMode.Create)
                {
                    LoadFields();
                }

                LoadParent();
                SetVisibility();
            }
        }
        protected void LoadFields()
        {
            if (CategoryId != 0)
            {
                CategoryBase cb = ControllerManager.CategoryBase.GetById(CategoryId);

                txtName.Text = cb.Name;
                txtDescripcion.Text = cb.Description;

                if(cb.GetType().AssemblyQualifiedName == typeof (Family).AssemblyQualifiedName)
                    ddlType.Value = "1";
                else if (cb.GetType().AssemblyQualifiedName == typeof(CatalogPage).AssemblyQualifiedName)
                    ddlType.Value = "2";
                else if (cb.GetType().AssemblyQualifiedName == typeof(ProductType).AssemblyQualifiedName)
                    ddlType.Value = "3";
                else if (cb.GetType().AssemblyQualifiedName == typeof(Application).AssemblyQualifiedName)
                    ddlType.Value = "4";
                else if (cb.GetType().AssemblyQualifiedName == typeof(Line).AssemblyQualifiedName)
                    ddlType.Value = "5";
                else if (cb.GetType().AssemblyQualifiedName == typeof(Area).AssemblyQualifiedName)
                    ddlType.Value = "6";
                
                txtDescriptionEnglish.Text = cb.DescripionEnglish;
                txtNameEnglish.Text = cb.NameEnglish;
                txtObservations.Text = cb.Observations;
                if(!string.IsNullOrEmpty(cb.Image))
                    imgImage.ImageUrl = Path.Combine(Config.ImagesProductsPath, cb.Image);
                else
                    imgImage.Visible = false;
            }
        }

        protected void LoadParent()
        {
            CategoryBase cb = null;
            //ListItemCollection lst = ControllerManager.CategoryBase.GetHierarchyItems(ControllerManager.CategoryBase.GetPagesTree(ddlType.Value.ToString()), ControllerManager.CategoryBase.GetById(CategoryId));
            //ddlParent.DataSource = lst;
            ListItemCollection lst;
            if (!IsPageList)
            {
                if (CategoryId != 0 && Mode == EditionMode.Create)
                    lst = ControllerManager.CategoryBase.GetHierarchyItems(ddlType.Value.ToString());
                else
                    lst = ControllerManager.CategoryBase.GetHierarchyItems(ControllerManager.CategoryBase.GetPagesTree(ddlType.Value.ToString()), ControllerManager.CategoryBase.GetById(CategoryId));
                
                
                //if (CategoryId != 0 && Mode != EditionMode.Create)
                //{
                //    cb = ControllerManager.CategoryBase.GetById(CategoryId);
                //    ListItem li = lst.FindByValue(cb.ID.ToString());
                //    if (li != null)
                //        lst.Remove(li);
                //}

                ddlParent.DataSource = lst;
                ddlParent.DataTextField = "Text";
                ddlParent.DataValueField = "Value";
                ddlParent.DataBind();

                if (CategoryId != 0)
                {
                    cb = ControllerManager.CategoryBase.GetById(CategoryId);
                    string parentValue = string.Empty;
                    if (cb != null && Mode == EditionMode.Create)
                        parentValue = cb.ID.ToString();
                    else
                        if (cb != null && cb.Parent != null)
                            parentValue = cb.Parent.ID.ToString();

                    if (!string.IsNullOrEmpty(parentValue))
                    {
                        ListItem li = lst.FindByValue(parentValue);
                        if (li != null)
                            ddlParent.SelectedValue = li.Value;
                    }
                }
            }
            else
            {
                ddlParent.DataSource = ControllerManager.CatalogPage.GetFirstLevelParents();
                ddlParent.DataTextField = "Name";
                ddlParent.DataValueField = "ID";
                ddlParent.DataBind();
                ddlParent.IsRequired = false;
                if (CategoryId != 0)
                {
                    CatalogPage cp = ControllerManager.CatalogPage.GetById(CategoryId);
                    if(cp.Parent != null)
                        ddlParent.SelectedValue = cp.Parent.ID.ToString();
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

            if (CategoryId != 0)
                lnkEdit.Visible = !enabled;
            else
                lnkEdit.Visible = (Mode != EditionMode.Create);
            
            lnkEdit.Visible = (PermissionManager.Check(lnkEdit) && Mode == EditionMode.View);

            ddlParent.Enabled = enabled;
            ddlType.Visible = !this.IsPageList;
            if (Mode == EditionMode.Create && CategoryId != 0)
            {
                ddlParent.Enabled = !enabled;
                ddlType.Visible = !enabled;
            }
            
            if (Mode == EditionMode.Edit)
            {
                txtName.Focus();
                ddlType.Enabled = false;
            }
            
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
           
            CategoryBase parent = null;
            if(ddlParent.SelectedValue != string.Empty)
                parent = ControllerManager.CategoryBase.GetById(Convert.ToInt32(ddlParent.SelectedValue));
            int id;
            if (Mode == EditionMode.Edit)
            {
                ControllerManager.CategoryBase.ModifyCategory(CategoryId, parent, txtName.StringValue, txtDescripcion.StringValue, txtNameEnglish.StringValue, txtDescriptionEnglish.StringValue, txtObservations.StringValue);
                id = CategoryId;
            }
            else
            {
                Type type = null;

                if (ddlType.StringValue ==  "1")
                    type = Type.GetType(typeof(Family).AssemblyQualifiedName);
                else if (ddlType.StringValue == "2")
                    type = Type.GetType(typeof(CatalogPage).AssemblyQualifiedName);
                else if (ddlType.StringValue == "3")
                    type = Type.GetType(typeof(ProductType).AssemblyQualifiedName);
                else if (ddlType.StringValue == "4")
                    type = Type.GetType(typeof(Application).AssemblyQualifiedName);
                else if (ddlType.StringValue == "5")
                    type = Type.GetType(typeof(Line).AssemblyQualifiedName);
                else if (ddlType.StringValue == "6")
                    type = Type.GetType(typeof(Area).AssemblyQualifiedName);

                CategoryBase cb = ControllerManager.CategoryBase.CreateCategory(type, parent, txtName.StringValue, txtDescripcion.StringValue, txtNameEnglish.StringValue, txtDescriptionEnglish.StringValue, txtObservations.StringValue);
                id = cb.ID;
            }
            
            if (IsPageList)
                Response.Redirect("/pagelist/view/?Id=" + id);
            else
                if(IsPageListSon)
                    Response.Redirect("/pagelist/childs/view/?Id=" + id);
                else
                    Response.Redirect("/categorys/view/?Id=" + id);
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
            imgImage.ImageUrl = "/img/";
            LoadFields();
            LoadParent();
            SetVisibility();
        }

        protected void ddlType_SelectedIndexChange(object sender, EventArgs e)
        {
            if (ddlType.SelectedValue != string.Empty)
                LoadParent();
        }
    }
}