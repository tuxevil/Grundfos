using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using PriceManager;
using PriceManager.Business;
using PriceManager.Business.Actions;
using PriceManager.Business.Filters;
using PriceManager.Common;
using PriceManager.Core;
using System.Collections.Generic;
using ProjectBase.Data;
using System.Collections;
using NybbleMembership;
using System.Drawing;

namespace GrundFos.PriceManager.WebSite.ctrl
{
    public partial class PriceMasterList
    {
        #region Properties

        private string _urlForCreateNew = null;
        public string UrlForCreateNew
        {
            get
            {
                if (_urlForCreateNew == null && ViewState["UrlForCreateNew"] != null)
                    _urlForCreateNew = ViewState["UrlForCreateNew"].ToString();

                return _urlForCreateNew;
            }
            set { ViewState["UrlForCreateNew"] = value; }
        }

        public bool ShowFilters
        {
            get { return this.ucFilters.Visible; }
            set
            {
                this.ucFilters.Visible = value;
            }
        }

        private string _textForCreateNew = null;
        public string TextForCreateNew
        {
            get
            {
                if (_textForCreateNew == null && ViewState["TextForCreateNew"] != null)
                    _textForCreateNew = ViewState["TextForCreateNew"].ToString();

                return _textForCreateNew;
            }
            set { ViewState["TextForCreateNew"] = value; }
        }

        private MasterListType _type;
        public MasterListType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        private bool _allowMultipleSelection = true;
        public bool AllowMultipleSelection
        {
            get { return _allowMultipleSelection; }
            set { _allowMultipleSelection = value; }
        }

        private GridHelper _gridHelper;
        public GridHelper GridHelper
        {
            get
            {
                if (ViewState["GridHelper"] == null)
                    ViewState["GridHelper"] = new GridHelper();

                if (_gridHelper == null)
                    _gridHelper = (GridHelper)ViewState["GridHelper"];
                return _gridHelper;
            }
            set { ViewState["GridHelper"] = value; }
        }


        #endregion

        #region Action Creation Helper
        public void AddAction(IAction action)
        {
            AddAction(action, true);
        }

        public void AddAction(IAction action, bool asynPostback)
        {
            if (action is IActionClick)
            {
                ((IActionClick)action).ActionClick += new ActionClickEventHandler(PriceMasterList_ActionClick);

                UpdatePanelControlTrigger apbt;

                //TODO: Review why is not working properly with AsyncPostBack
                //if (asynPostback)
                //    apbt = new AsyncPostBackTrigger();
                //else
                    apbt = new PostBackTrigger();

                apbt.ControlID = action.ID;

                upGrid.Triggers.Add(apbt);
                //upMarkedCount.Triggers.Add(apbt);
                upMarked.Triggers.Add(apbt);
                upPager.Triggers.Add(apbt);
            }

            this.plhActions.Controls.Add(action as Control);
        }

        #endregion

        #region Page Load Events

        protected override void OnInit(EventArgs e)
        {
            Trace.Write("Begin Filters");
            SetFilters();
            Trace.Write("End Filters");

            Trace.Write("Begin Actions");
            SetActions();
            Trace.Write("End Actions");

            Trace.Write("Begin Grid");

            #region Set Grid Events

            grdItems.DataKeyNames = new string[] { "ID" };
            grdItems.Sorting += new GridViewSortEventHandler(grdItems_Sorting);
            grdItems.RowCreated += new GridViewRowEventHandler(grdItems_RowCreated);
            grdItems.RowDataBound += new GridViewRowEventHandler(grdItems_RowDataBound);
            grdItems.RowCommand += new GridViewCommandEventHandler(grdItems_RowCommand);

            if (AllowMultipleSelection)
            {
                TemplateField tc = new TemplateField();
                tc.ItemTemplate = new InputTemplateField(DataControlRowType.DataRow);
                tc.HeaderStyle.CssClass = "action";
                tc.ItemStyle.CssClass = "action";
                grdItems.Columns.Add(tc);
            }

            ulCheck.Visible = AllowMultipleSelection;
            plhActions.Visible = AllowMultipleSelection;

            #endregion

            SetColumns();
            Trace.Write("End Grid");

            base.OnInit(e);
        }

        void grdItems_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToLower() != "sort")
                OnRowCommand(sender, e);
        }

        public override void DataBind()
        {
            if (!IsPostBack)
            {
                OnDataBind();

                ddlToCurrency.DataSource = ControllerManager.Currency.GetAll();
                ddlToCurrency.DataTextField = "Description";
                ddlToCurrency.DataValueField = "ID";
                ddlToCurrency.DataBind();
                ListItem li = new ListItem();
                li.Text = Resource.Business.GetString("ToCurrencyOriginal");
                li.Value = "0";
                ddlToCurrency.Items.Insert(0, li);

                //GridHelper.SortAscending = true;
                GridHelper_Changed(null, null);
                if(Type == MasterListType.PriceListProducts || Type == MasterListType.PriceGroupView)
                    if(PriceGroupID > 0)
                    {
                        ddlToCurrency.SelectedValue = ddlToCurrency.Items.FindByValue(ControllerManager.PriceGroup.GetById(PriceGroupID).Currency.ID.ToString()).Value;
                        GridHelper.ShowInCurrency = Convert.ToInt32(ddlToCurrency.SelectedValue);
                    }
                    else if(PriceListID > 0)
                    {
                        ddlToCurrency.SelectedValue = ddlToCurrency.Items.FindByValue(ControllerManager.PriceList.GetById(PriceListID).Currency.ID.ToString()).Value;
                        GridHelper.ShowInCurrency = Convert.ToInt32(ddlToCurrency.SelectedValue);
                    }

                if(!AllowMultipleSelection)
                    selectedAndTotalCount.Visible = false;
                if(Type != MasterListType.QuoteProductsCreate && Type != MasterListType.QuoteProductsView)
                    SearchAndFillRepeater();

                //divActions.Visible = !litNoItems.Visible;
                //divMarked.Visible = !litNoItems.Visible;
                //divPaging.Visible = !litNoItems.Visible;
                //upGrid.Visible = !litNoItems.Visible;
                ///showFiltersButton.Visible = !litNoItems.Visible;
                //ucFilters.Visible = !litNoItems.Visible;
            }

            //base.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Pager1.PageChanged += Pager1_PageChanged;
            GridHelper.Changed += new GridHelperChangedEventHandler(GridHelper_Changed);
            ucFilters.FilterClick += (ucFilters_FilterClick);

            if (!string.IsNullOrEmpty(UrlForCreateNew))
            {
                HyperLink create = new HyperLink();
                if (!string.IsNullOrEmpty(TextForCreateNew))
                    create.Text = Resource.Business.GetString(TextForCreateNew);
                else
                    create.Text = Resource.Business.GetString("creationBtn");
                create.ID = "btnCreate";
                create.NavigateUrl = UrlForCreateNew;
                create.Visible = PermissionManager.Check(create);
                create.CssClass = "lbutton";
                create.ForeColor = Color.White;
                phCreation.Controls.Add(create);

                if(Type == MasterListType.CurrencyView)
                {
                    Button update = new Button();
                    update.CssClass = "button";
                    update.ID = "btnUpdate";
                    update.Text = Resource.Business.GetString("UpdateAllCurrencyRate");
                    update.Click += new EventHandler(update_Click);
                    //update.Visible = PermissionManager.Check(update);
                    phUpdate.Controls.Add(update);
                }
            }

            OnPageLoad(sender, e);
        }

        void update_Click(object sender, EventArgs e)
        {
            try
            {
                ControllerManager.CurrencyRate.Synchronize();
            }
            catch (Exception ex)
            {
                Utils.ShowMessage(Page, ex.Message, Utils.MessageType.Error);
                SearchAndFillRepeater();
                upGrid.Update();
                return;
            }
            
            SearchAndFillRepeater();
            upGrid.Update();
            Utils.ShowMessage(Page, "Las cotizaciones han sido actualizadas correctamente.", Utils.MessageType.Info);
        }

        #endregion

        #region Grid Events

        protected void GridHelper_Changed(object sender, EventArgs sp)
        {
            foreach (Control ctrl in plhActions.Controls)
                if (ctrl is IAction)
                    (ctrl as IAction).EnableControl(GridHelper.State);

            QuantitySelectedAndChecked();
        }

        private void Pager1_PageChanged(object sender, ctrl.Pager.PageChangedEventArgs e)
        {
            GridHelper.PageNumber = e.NewPageNumber;
            SearchAndFillRepeater();
        }

        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridHelper.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
            GridHelper.PageNumber = 1;
            SearchAndFillRepeater();
        }

        protected void ddlToCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ddlToCurrency.SelectedValue) == 0)
                GridHelper.ShowInCurrency = null;
            else
                GridHelper.ShowInCurrency = Convert.ToInt32(ddlToCurrency.SelectedValue);
            SearchAndFillRepeater();
        }

        void grdItems_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
                OnHeaderDataBound(sender, e);
            else if (e.Row.RowType != DataControlRowType.DataRow)
                return;

            //if (AllowMultipleSelection && Type == MasterListType.ProductsView && e.Row.RowType != DataControlRowType.Header)
            //    (e.Row.Cells[0].Controls[0] as HtmlInputCheckBox).Checked = GridHelper.IsMarked((e.Row.DataItem as Product).ID);
            ////else if (AllowMultipleSelection && Type == MasterListType.QuoteProductsView && Type == MasterListType.QuoteProductsCreate && e.Row.RowType != DataControlRowType.Header)
            ////    (e.Row.Cells[0].Controls[0] as HtmlInputCheckBox).Checked = GridHelper.IsMarked((e.Row.DataItem as ).ID);
            //else if (AllowMultipleSelection && Type != MasterListType.Import && e.Row.RowType != DataControlRowType.Header)
            //    (e.Row.Cells[0].Controls[0] as HtmlInputCheckBox).Checked = GridHelper.IsMarked((e.Row.DataItem as ProductListView).ID);

            if (AllowMultipleSelection && e.Row.RowType != DataControlRowType.Header)
                (e.Row.Cells[0].Controls[0] as HtmlInputCheckBox).Checked = GridHelper.IsMarked((e.Row.DataItem as Entity<int>).ID);

            
            OnRowDataBound(sender, e);
        }

        void grdItems_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header && Type != MasterListType.PriceCalculation)
                foreach (TableCell tc in e.Row.Cells)
                    if (tc.HasControls() && tc.Controls[0] is LinkButton)
                    {
                        // search for the header link
                        LinkButton lnk = (LinkButton)tc.Controls[0];

                        string order = lnk.CommandArgument;
                        if (lnk != null && GridHelper.SortField.Equals(order))
                        {
                            if (GridHelper.SortAscending)
                                lnk.CssClass = "up";
                            else
                                lnk.CssClass = "down";
                        }
                        if (lnk != null)
                            lnk.ToolTip = Resource.Business.GetString("tooltip" + lnk.Text);
                    }
            OnRowCreated(sender, e);
        }

        void grdItems_Sorting(object sender, GridViewSortEventArgs e)
        {
            string order = e.SortExpression.ToString();

            if (GridHelper.SortField == order)
                if (!GridHelper.SortAscending)
                    GridHelper.SortAscending = true;
                else
                    GridHelper.SortAscending = false;
            else
            {
                GridHelper.SortField = order;
                GridHelper.SortAscending = true;
            }

            GridHelper.PageNumber = 1;
            SearchAndFillRepeater();
        }

        #endregion

        #region Search
        protected void ucFilters_FilterClick(object sender, FilterEventArgs e)
        {
            GridHelper.PageNumber = 1;
            if(!SaveSelectedItems)
                GridHelper.UnMarkAllItems();
           
            SearchAndFillRepeater(e.Filters);
        }

        protected void SearchAndFillRepeater(IList<IFilter> filters)
        {
            int totalRecords = 0;
            object o = OnSetDataSource(filters, out totalRecords);
            GridHelper.PageNumber = Utils.AdjustPageNumber(GridHelper.PageNumber, GridHelper.PageSize, totalRecords);
            this.grdItems.DataSource = o;    
            
            this.grdItems.DataBind();

            GridHelper.SetSearchDate(DateTime.Now);
            GridHelper.TotalRecords = totalRecords;

            hidTotal.Value = GridHelper.TotalRecords.ToString();

            //lnkCheckAll.Enabled = true;
            //if (GridHelper.TotalRecords == 0)
            //    lnkCheckAll.Enabled = false;

            QuantitySelectedAndChecked();

            Pager1.PageCount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(GridHelper.TotalRecords) / Convert.ToDouble(GridHelper.PageSize)));
            Pager1.CurrentPage = GridHelper.PageNumber;
            Pager1.Step = 10;
            Pager1.DataBind();
        }

        protected void SearchAndFillRepeater()
        {
            SearchAndFillRepeater(this.ucFilters.GetFiltersApplied());
        }

        #endregion

        #region Checkbox Check/UnCheckAll

        protected void grdItemsCheck_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chbox = (CheckBox)sender;
            GridViewRow row = chbox.NamingContainer as GridViewRow;
            int id = Convert.ToInt32(this.grdItems.DataKeys[row.DataItemIndex].Value);

            if (GridHelper.IsMarkedAll())
            {
                if (chbox.Checked)
                    GridHelper.MarkItem(id);
                else
                    GridHelper.UnMarkItem(id);
            }
            else
            {
                if (chbox.Checked)
                    GridHelper.MarkItem(id);
                else
                    GridHelper.UnMarkItem(id);
            }

            if (GridHelper.MarkedCount == 0)
                GridHelper.UnMarkAllItems();

            //TODO: It will be ideal to only reload the current row.
            //TODO: We need these because the record could have changed and is reloading from ViewState.
            //TODO: But doing the full search again takes long time, maybe do it in JS when a checkbox is clicked.
        }

        protected void lnkCheckAll_Click(object sender, EventArgs e)
        {
            GridHelper.MarkAllItems();
            SearchAndFillRepeater();
        }

        protected void lnkUnCheckAll_Click(object sender, EventArgs e)
        {
            GridHelper.UnMarkAllItems();
            SearchAndFillRepeater();
        }

        private void QuantitySelectedAndChecked()
        {
            //int totalMarked = GridHelper.MarkedCount;
            //string count;

            //if (AllowMultipleSelection)
            //{
            //    count = string.Format("<strong>{0}</strong> registros marcados de <strong>{1}</strong> totales.", totalMarked.ToString(), GridHelper.TotalRecords.ToString());

            //    //if (totalMarked > 0)
            //    //{
            //    //    lnkUnCheckAll.Enabled = true;
            //    //    MarkedAll.Attributes["class"] = "";
            //    //    UnMarkedAll.Attributes["class"] = "";
            //    //}
            //    //else
            //    //{
            //    //    lnkUnCheckAll.Enabled = false;
            //    //    MarkedAll.Attributes["class"] = "";
            //    //    UnMarkedAll.Attributes["class"] = "pressed";
            //    //}

            //    //if (totalMarked == GridHelper.TotalRecords)
            //    //{
            //    //    lnkCheckAll.Enabled = false;
            //    //    MarkedAll.Attributes["class"] = "pressed";
            //    //    UnMarkedAll.Attributes["class"] = "";
            //    //}
            //    //else
            //    //{
            //    //    lnkCheckAll.Enabled = true;
            //    //    //MarkedAll.Attributes["class"] = "";
            //    //    //UnMarkedAll.Attributes["class"] = "";
            //    //}
            //}
            //else
            //    count = string.Format("<strong>{0}</strong> registros totales.", GridHelper.TotalRecords.ToString());

            //this.lblCount.InnerHtml = count;

            // TODO: Custom for Products
            OnQuantitySelectedAndChecked();
        }

        #endregion

        #region Action Events

        protected void PriceMasterList_ActionClick(object sender, EventArgs sp)
        {
            (sender as IAction).ExecuteAction(GridHelper.State, ucFilters.GetFiltersApplied());

            OnActionExecuted(sender, sp);

            SearchAndFillRepeater();
        }

        #endregion
    }
}
