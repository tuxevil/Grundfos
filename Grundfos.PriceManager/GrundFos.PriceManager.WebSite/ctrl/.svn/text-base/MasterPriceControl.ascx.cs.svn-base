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
using PriceManager.Business.Filters;
using PriceManager.Business.Actions;
using PriceManager.Core;

namespace GrundFos.PriceManager.WebSite.ctrl
{
    public partial class MasterPriceControl : UserControl
    {

        private MasterListType _type;
        public MasterListType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        protected override void OnInit(EventArgs e)
        {
            #region Set Filters

            ucListControl.Filters.Add(new SearchFilter());
            ucListControl.Filters.Add(new CategoryFilter());
            ucListControl.Filters.Add(new CurrencyFilter());
            ucListControl.Filters.Add(new CtrRangeFilter());
            ucListControl.Filters.Add(new IndexFilter());
            ucListControl.Filters.Add(new SelectionFilter());
            ucListControl.Filters.Add(new ProviderFilter());
            ucListControl.Filters.Add(new FrequencyFilter());
            ucListControl.Filters.Add(new PriceBaseModifiedOnFilter());
            ucListControl.Filters.Add(new FixedFilter(typeof(PriceGroup), "ID", false));

            switch (Type)
            {
                case MasterListType.MasterPriceView:
                   ucListControl.Filters.Add(new FixedFilter(typeof(ProductStatus), "ID", EnumHelper.GetDescription(ProductStatus.Active), ProductStatus.Active));
                   ucListControl.Filters.Add(new FixedFilter(typeof(PriceBaseStatus), "ID", EnumHelper.GetDescription(PriceBaseStatus.Verified), PriceBaseStatus.Verified));
                    break;
                case MasterListType.OutOfGroupView:
                   ucListControl.Filters.Add(new FixedFilter(typeof(ProductStatus), "ID", EnumHelper.GetDescription(ProductStatus.Active), ProductStatus.Active));
                   ucListControl.Filters.Add(new FixedFilter(typeof(PriceBaseStatus), "ID", EnumHelper.GetDescription(PriceBaseStatus.NotVerified), PriceBaseStatus.NotVerified));
                    break;
                case MasterListType.PriceGroupView:
                   ucListControl.Filters.Add(new FixedFilter(typeof(ProductStatus), "ID", EnumHelper.GetDescription(ProductStatus.Active), ProductStatus.Active));
                   ucListControl.Filters.Add(new FixedFilter(typeof(PriceBaseStatus), "ID", EnumHelper.GetDescription(PriceBaseStatus.Verified), PriceBaseStatus.Verified));
                    break;
                case MasterListType.AdminView:
                   ucListControl.Filters.Add(new ProductStatusFilter());
                   ucListControl.Filters.Add(new PriceBaseStatusFilter());
                    break;
            }

            #endregion

            #region Set Actions
            ExportToExcelAction etea = new ExportToExcelAction();
            etea.ID = "btnExportExcel";
            etea.Click += new ImageClickEventHandler(ExportButton_Click);
            ucListControl.Actions.Add(etea);

            ExportToPdfAction etpa = new ExportToPdfAction();
            etpa.ID += "btnExportPDF";
            etpa.Click += new ImageClickEventHandler(ExportButton_Click);
            ucListControl.Actions.Add(etpa);

            MoveToSelectionAction mtsa = new MoveToSelectionAction();
            mtsa.ID += "btnMoveToSelection";
            ucListControl.Actions.Add(mtsa);

            EraseFromSelectionAction efsa = new EraseFromSelectionAction();
            efsa.ID = "lnkEraseFromSelection";
            efsa.Click += new EventHandler(efsa_Click);
            efsa.Visible = false;
            ucListControl.Actions.Add(efsa);

            AsyncPostBackTrigger apbt = new AsyncPostBackTrigger();
            apbt.ControlID = efsa.ID;
            apbt.EventName = "Click";
            this.upGrid.Triggers.Add(apbt);

            switch (Type)
            {
                case MasterListType.MasterPriceView:

                    //Add Action if is MasterPrice page or Country Page
                    MoveProductsToOutOfListAction mptos = new MoveProductsToOutOfListAction();
                    mptos.ID = "btnTakeOutOfMasterList";
                    mptos.Click += new EventHandler(mptos_Click);
                    ucListControl.Actions.Add(mptos);

                    AsyncPostBackTrigger apbmptos = new AsyncPostBackTrigger();
                    apbmptos.ControlID = mptos.ID;
                    apbmptos.EventName = "Click";
                    this.upGrid.Triggers.Add(apbmptos);

                    MoveToPricegroupAction mtpga = new MoveToPricegroupAction();
                    mtpga.ID += "btnMoveToPriceGroup";
                    ucListControl.Actions.Add(mtpga);
                    break;

                case MasterListType.OutOfGroupView:
                    AddProductsToMasterListAction aptmla = new AddProductsToMasterListAction();
                    aptmla.ID = "AddToMasterList";
                    aptmla.Click += new EventHandler(aptmla_Click);
                    ucListControl.Actions.Add(aptmla);

                    AsyncPostBackTrigger apbtaptmla = new AsyncPostBackTrigger();
                    apbtaptmla.ControlID = aptmla.ID;
                    apbtaptmla.EventName = "Click";
                    this.upGrid.Triggers.Add(apbtaptmla);

                    DeactivateProductsAction dpa = new DeactivateProductsAction();
                    dpa.ID = "btnDeactivateProduct";
                    dpa.Click += new EventHandler(dpa_Click);
                    ucListControl.Actions.Add(dpa);

                    AsyncPostBackTrigger apbtdpa2 = new AsyncPostBackTrigger();
                    apbtdpa2.ControlID = dpa.ID;
                    apbtdpa2.EventName = "Click";
                    this.upGrid.Triggers.Add(apbtdpa2);
                    break;

                case MasterListType.PriceGroupView:
                    ModifyPricesAction mpa = new ModifyPricesAction();
                    mpa.ID = "btnModifyPrices";
                    ucListControl.Actions.Add(mpa);

                    MoveProductsToBaseListAction mptbs = new MoveProductsToBaseListAction();
                    mptbs.ID = "btnTakeOutOfPriceGroup";
                    mptbs.Click += new EventHandler(mptbs_Click);
                    ucListControl.Actions.Add(mptbs);

                    AsyncPostBackTrigger apbmptbs = new AsyncPostBackTrigger();
                    apbmptbs.ControlID = mptbs.ID;
                    apbmptbs.EventName = "Click";
                    this.upGrid.Triggers.Add(apbmptbs);

                    break;

                case MasterListType.AdminView:
                    MoveToCategoryAction mtca = new MoveToCategoryAction();
                    mtca.ID += "btnMoveToCategory";
                    ucListControl.Actions.Add(mtca);

                    TakeOutFromCategoryAction tkofc = new TakeOutFromCategoryAction();
                    tkofc.ID = "btnTakeOutFromCategory";
                    ucListControl.Actions.Add(tkofc);

                    dpa = new DeactivateProductsAction();
                    dpa.ID = "btnDeactivateProduct";
                    dpa.Click += new EventHandler(dpa_Click);
                    dpa.Visible = false;
                    ucListControl.Actions.Add(dpa);

                    AsyncPostBackTrigger apbtdpa = new AsyncPostBackTrigger();
                    apbtdpa.ControlID = dpa.ID;
                    apbtdpa.EventName = "Click";
                    this.upGrid.Triggers.Add(apbtdpa);

                    ActivateProductsAction apa = new ActivateProductsAction();
                    apa.ID = "btnActivateProduct";
                    apa.Click += new EventHandler(apa_Click);
                    apa.Visible = false;
                    ucListControl.Actions.Add(apa);

                    AsyncPostBackTrigger apbtapa = new AsyncPostBackTrigger();
                    apbtapa.ControlID = apa.ID;
                    apbtapa.EventName = "Click";
                    this.upGrid.Triggers.Add(apbtapa);
                    break;
            }

            #endregion

            #region Set Grid Columns

            BoundField bf = new BoundField();
            bf.DataField = "Code";
            bf.HeaderText = "Código";
            bf.SortExpression = "P.Code";
            ucListControl.DataFields.Add(bf);

            bf = new BoundField();
            bf.DataField = "Description";
            bf.HeaderText = "Descripción";
            bf.SortExpression = "P.Description";
            bf.HeaderStyle.CssClass = "description";
            bf.ItemStyle.CssClass = "description";
            ucListControl.DataFields.Add(bf);

            bf = new BoundField();
            bf.DataField = "Type";
            bf.HeaderText = "Hz";
            ucListControl.DataFields.Add(bf);

            bf = new BoundField();
            bf.DataField = "Index";
            bf.HeaderText = "Indice";
            bf.SortExpression = "PI.Index";
            bf.HeaderStyle.CssClass = "price";
            ucListControl.DataFields.Add(bf);

            bf = new BoundField();
            bf.DataField = "PriceSell";
            bf.HeaderText = "P. Vta";
            bf.SortExpression = "PriceSell";
            bf.HeaderStyle.CssClass = "price";
            ucListControl.DataFields.Add(bf);

            bf = new BoundField();
            bf.DataField = "PriceSuggest";
            bf.HeaderText = "GRP";
            bf.SortExpression = "PB.PriceSuggest";
            bf.HeaderStyle.CssClass = "price";
            ucListControl.DataFields.Add(bf);

            bf = new BoundField();
            bf.DataField = "PricePurchase";
            bf.HeaderText = "TP";
            bf.SortExpression = "PB.PricePurchase";
            bf.HeaderStyle.CssClass = "price";
            ucListControl.DataFields.Add(bf);

            bf = new BoundField();
            bf.DataField = "Price";
            bf.HeaderText = "Price";
            bf.SortExpression = "Price";
            bf.HeaderStyle.CssClass = "price";
            ucListControl.DataFields.Add(bf);

            bf = new BoundField();
            bf.DataField = "CTM";
            bf.HeaderText = "CTM";
            bf.SortExpression = "PI.CTM";
            bf.HeaderStyle.CssClass = "price";
            ucListControl.DataFields.Add(bf);

            bf = new BoundField();
            bf.DataField = "CTR";
            bf.HeaderText = "CTR";
            bf.SortExpression = "PI.CTR";
            bf.HeaderStyle.CssClass = "price";
            ucListControl.DataFields.Add(bf);

            #endregion

            base.OnInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public override void DataBind()
        {
            if (!Page.IsPostBack)
                PriceMasterList1.DataBind();

            base.DataBind();
        }
    }
}