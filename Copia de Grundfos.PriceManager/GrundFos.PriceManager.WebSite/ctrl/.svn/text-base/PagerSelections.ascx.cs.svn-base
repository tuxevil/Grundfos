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

namespace GrundFos.PriceManager.WebSite.ctrl
{
    public partial class PagerSelections : System.Web.UI.UserControl
    {
        #region PagerItem Class

        /// <summary>
        /// Internal Class To Manage Easily Page Numbers on Repeater
        /// </summary>    
        protected class PagerItem
        {
            public string Name;
            public int PageNumber;

            public PagerItem(string name, int pageNumber)
            {
                Name = name;
                PageNumber = pageNumber;
            }
        }

        #endregion

        #region Pager Event Definition

        public delegate void PageChangedEventHandler(
                object sender, PageChangedEventArgs e);

        public class PageChangedEventArgs : EventArgs
        {
            public PageChangedEventArgs(int newPageNumber)
            {
                _newPageNumber = newPageNumber;
            }

            private int _newPageNumber;
            public int NewPageNumber
            {
                get { return _newPageNumber; }
                set { _newPageNumber = value; }
            }
        }

        #endregion

        public override void DataBind()
        {
            // Creates an ArrayList to DataBind in the Repeater
            // Filled with PagerItem objects.
            if (PageCount > 1)
            {
                ArrayList pages = new ArrayList();

                // Solo si no es la primer pagina
                if (CurrentPage != 1)
                    pages.Add(new PagerItem("<", CurrentPage - 1));

                // Solo si no es la ultima pagina
                if (PageCount != CurrentPage)
                    pages.Add(new PagerItem(">", CurrentPage + 1));

                rptPages.DataSource = pages;
                rptPages.DataBind();
            }
            base.DataBind();
        }

        #region Public Properties

        /// <summary>
        /// Total of pages to be shown
        /// </summary>
        public int PageCount
        {
            get
            {
                if (ViewState["PageCount"] != null)
                    return Convert.ToInt32(ViewState["PageCount"]);
                else
                    throw new SystemException("PageCount must be defined.");
            }
            set
            {
                ViewState["PageCount"] = value;
            }
        }

        /// <summary>
        /// Current page to be marked
        /// </summary>
        public int CurrentPage
        {
            get
            {
                if (ViewState["CurrentPage"] != null)
                    return Convert.ToInt32(ViewState["CurrentPage"]);
                else
                    return 1;
            }
            set
            {
                ViewState["CurrentPage"] = value;
            }
        }

        /// <summary>
        /// Number of pages to show per section
        /// </summary>
        public int Step
        {
            get
            {
                if (ViewState["Step"] != null)
                    return Convert.ToInt32(ViewState["Step"]);
                else
                    return 10;
            }
            set
            {
                ViewState["Step"] = value;
            }
        }

        #endregion

        #region Internal Use Properties

        /// <summary>
        /// Current Section
        /// </summary>
        private int CurrentSection
        {
            get
            {
                // Get Current Section
                int sect = (int)(CurrentPage / Step);

                // If zero, should be one.
                // If current section differs from CurrentPage - 1, means we are in a next click, we should add one also.
                if (sect == 0 || (int)((CurrentPage - 1) / Step) == sect)
                    return sect + 1;
                else
                    return sect;
            }
        }

        /// <summary>
        /// Start of Page of Current Step
        /// </summary>
        private int BegSection
        {
            get
            {
                return ((CurrentSection * Step) - Step + 1);
            }
        }

        /// <summary>
        /// End Page of Current Step
        /// </summary>
        private int EndSection
        {
            get
            {
                return CurrentSection * Step;
            }
        }

        #endregion

        #region Events

        protected void rptPages_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (PageCount > 1)
            // Shows the actual page as text, not as link.
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    ImageButton imgbut = (ImageButton)e.Item.FindControl("imgPage");
                    LinkButton pagbut = (LinkButton)e.Item.FindControl("btnPage");
                    switch (((PagerItem)e.Item.DataItem).Name)
                    {
                        case "<":
                       
                            e.Item.FindControl("litPage").Visible = false;
                            LinkButton temp = (LinkButton)e.Item.FindControl("btnPage");
                            temp.Text = "Anterior";
                            break;
                        case ">":
                       
                            e.Item.FindControl("litPage").Visible = false;
                            LinkButton temp2 = (LinkButton)e.Item.FindControl("btnPage");
                            temp2.Text = "Siguiente";
                            break;
                    }

                    if (((PagerItem)e.Item.DataItem).PageNumber == this.CurrentPage)
                    {
                        e.Item.FindControl("litPage").Visible = true;
                        e.Item.FindControl("btnPage").Visible = false;
                    }

                }
            }
        }

        protected void rptPages_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            // Launch the PageChangedEvent when a page is clicked
            if (e.CommandName == "ChangePage")
            {
                CurrentPage = Convert.ToInt32(e.CommandArgument);
                OnPageChanged(new PageChangedEventArgs(CurrentPage));
            }
        }

        #region Exposed Event for PageChanged

        public event PageChangedEventHandler PageChanged;

        protected virtual void OnPageChanged(PageChangedEventArgs e)
        {
            if (PageChanged != null)
            {
                DataBind();
                PageChanged(this, e);
            }
        }

        #endregion

        #endregion

        #region IPostBackEventHandler Members

        public void RaisePostBackEvent(string eventArgument)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}