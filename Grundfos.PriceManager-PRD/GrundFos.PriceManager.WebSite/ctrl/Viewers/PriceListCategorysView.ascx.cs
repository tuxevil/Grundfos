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
using System.Drawing;


namespace GrundFos.PriceManager.WebSite.ctrl.Viewers
{
    public partial class PriceListCategorysView : System.Web.UI.UserControl
    {
        #region Properties

        private int _publishListId = 0;
        public int PublishListID
        {
            get
            {
                if (_publishListId == 0 && ViewState["PublishListID"] != null)
                    _publishListId = Convert.ToInt32(ViewState["PublishListID"]);

                return _publishListId;
            }
            set { ViewState["PublishListID"] = value; }
        }

        private int _priceListID = 0;
        public int PriceListID
        {
            get
            {
                if (_priceListID == 0 && ViewState["PriceListId"] != null)
                    _priceListID = Convert.ToInt32(ViewState["PriceListId"]);

                return _priceListID;
            }
            set { ViewState["PriceListId"] = value; }
        }

        public PriceList PriceList
        {
            get
            {
                return (PriceListID != 0) ? new PriceList(PriceListID) : null;
            }

        }

        private string _urlToNavigate = null;
        public string UrlToNavigate
        {
            get
            {
                if (_urlToNavigate == null && ViewState["UrlToNavigate"] != null)
                    _urlToNavigate = ViewState["UrlToNavigate"].ToString();

                return _urlToNavigate;
            }
            set { ViewState["UrlToNavigate"] = value; }
        }

        public bool isPriceList;
        #endregion

        public override void DataBind()
        {
            List<CatalogPage> catalogPageList = new List<CatalogPage>();

            if (isPriceList)
                catalogPageList = new List<CatalogPage>(ControllerManager.PriceList.GetById(PriceList.ID).CategoryPages);
            else
            {
                if (PublishListID > 0)
                    catalogPageList = new List<CatalogPage>(ControllerManager.PublishList.GetById(PublishListID).PublishedCategoryPages);
            }

            if (catalogPageList.Count == 0)
            {
                litNoItems.Visible = true;
                return;
            }

            LoadTreeView(catalogPageList);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void LoadTreeView(List<CatalogPage> catalogPageList)
        {
            List<CategoryBase> temp = new List<CategoryBase>();
            foreach (CatalogPage catalogPage in catalogPageList)
            {
                temp.Add(catalogPage);
                CategoryBase catalogParent = catalogPage.Parent;
                if (catalogParent != null)
                {
                    if(!temp.Exists(delegate(CategoryBase record)
                                                          {
                                                              if (record.ID == catalogParent.ID)
                                                                  return true;
                                                              return false;
                                                          }))
                    {
                        temp.Add(catalogParent);
                        CategoryBase catalogGrandParent = catalogParent.Parent;
                        if (catalogGrandParent != null)
                            if (!temp.Exists(delegate(CategoryBase record)
                                      {
                                          if (record.ID == catalogGrandParent.ID)
                                              return true;
                                          return false;
                                      }))
                                temp.Add(catalogGrandParent);
                    }
                }
            }

            TreeNode parent = null;
            int level = 0;
            IList<PageTreeView> categorysView = ControllerManager.CategoryBase.GetPagesTree("2");
            foreach (PageTreeView cv in categorysView)
            {
                if (!temp.Exists(delegate(CategoryBase record)
                                                          {
                                                              if (record.ID == cv.Id)
                                                                  return true;
                                                              return false;
                                                          }))
                    continue;
                
                if (cv.Level == 0)
                    parent = null;

                TreeNode node = new TreeNode();
                node.Text = cv.Name.Trim();
                if (cv.Id != 0)
                    node.NavigateUrl = UrlToNavigate + "?Id=" + PriceListID + "&CatalogPageId=" + cv.Id;


                if (parent == null)
                    tvw.Nodes.Add(node);
                else
                {
                    if (cv.Level < level)
                    {
                        if (parent.Parent.Parent == null)
                        {
                            parent.Parent.ChildNodes.Add(node);
                            parent = parent.Parent;
                        }
                        else
                        {
                            parent.Parent.Parent.ChildNodes.Add(node);
                            parent = node;
                        }
                        level = cv.Level;
                        continue;
                    }
                    else if (cv.Level == level)
                    {
                        if (parent.Parent == null)
                        {
                            parent.ChildNodes.Add(node);
                            parent = parent.Parent;
                        }
                        else
                        {
                            parent.Parent.ChildNodes.Add(node);
                            parent = node;
                        }
                        level = cv.Level;
                        continue;
                    }
                    parent.ChildNodes.Add(node);
                }
                parent = node;
                level = cv.Level;
            }

            
        }

    }
}