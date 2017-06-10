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

namespace GrundFos.PriceManager.WebSite.ctrl.Viewers
{
    public partial class CategoryTreeView : System.Web.UI.UserControl
    {
        #region Properties

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

        public TreeNodeCollection Nodes
        {
            get { return tvw.Nodes; }
        }

        #endregion

        public override void DataBind()
        {
            IList<PageTreeView> categorysView = ControllerManager.CategoryBase.GetPagesTree("2");
            List<PageTreeView> lstCatalogPage = ControllerManager.CategoryBase.CategoryTreeGetByPriceListToLevel(PriceListID, 2, 2) as List<PageTreeView>;
            
            if (categorysView.Count == 0)
            {
                litNoItems.Visible = true;
                return;
            }

            LoadTreeView(categorysView, lstCatalogPage);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void LoadTreeView(IList<PageTreeView> categorysView, List<PageTreeView> lstCatalogPage)
        {
            TreeNode parent = null;
            int level = 0;
            bool allMarked = true;
            foreach (PageTreeView cv in categorysView)
            {
                if (cv.Level == 0)
                {
                    parent = null;
                    allMarked = true;
                }

                bool exist = lstCatalogPage.Exists(delegate(PageTreeView record)
                                                          {
                                                              if (record.Id == cv.Id)
                                                                  return true;
                                                              return false;
                                                          });
                
                TreeNode node = new TreeNode();
                node.Text = cv.Name.Trim();
                node.Expanded = false;
                node.Checked = false;
                node.Value = cv.Id.ToString();
                
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
                    if (cv.Level == level)
                    {
                        if (parent.Parent == null)
                        {
                            parent.ChildNodes.Add(node);
                            parent = parent.Parent;
                        }
                        else
                        {
                            if (cv.Level > 1)
                            {
                                node.Checked = exist;
                                if(exist)
                                {
                                    parent.Expanded = true;
                                    if(parent.Parent != null)
                                    {
                                        parent.Parent.Expanded = true;
                                        if (parent.Parent.Parent != null)
                                            parent.Parent.Parent.Expanded = true;
                                    }
                                }
                                if (allMarked)
                                {
                                    if (exist)
                                    {
                                        parent.Parent.Checked = true;
                                        foreach (TreeNode childNode in parent.Parent.ChildNodes)
                                            if (!childNode.Checked)
                                                parent.Parent.Checked = false;
                                        if (parent.Parent != null)
                                        {
                                            parent.Parent.Parent.Checked = true;
                                            foreach (TreeNode childNode in parent.Parent.Parent.ChildNodes)
                                                if (!childNode.Checked)
                                                    parent.Parent.Parent.Checked = false;
                                        }
                                    }
                                    else
                                    {
                                        allMarked = false;
                                        parent.Parent.Checked = false;
                                    }
                                }
                                else
                                    parent.Parent.Checked = false;
                            }
                            parent.Parent.ChildNodes.Add(node);
                            parent = node;
                        }
                        continue;
                    }
                    if (cv.Level > 1)
                    {
                        node.Checked = exist;
                        if (exist)
                        {
                            parent.Expanded = true;
                            parent.Parent.Expanded = true;
                        }
                        if(allMarked)
                        {
                            if (exist)
                            {
                                parent.Checked = true;
                                foreach (TreeNode childNode in parent.ChildNodes)
                                    if (!childNode.Checked)
                                        parent.Checked = false;
                                if (parent.Parent != null)
                                {
                                    parent.Parent.Checked = true;
                                    foreach (TreeNode childNode in parent.Parent.ChildNodes)
                                        if(!childNode.Checked)
                                            parent.Parent.Checked = false;
                                }
                            }
                            else
                            {
                                allMarked = false;
                                parent.Checked = false;
                            }
                        }
                        else
                            parent.Checked = false;
                    }
                    parent.ChildNodes.Add(node);
                }
                parent = node;
                level = cv.Level;
            }
        }
    }
}