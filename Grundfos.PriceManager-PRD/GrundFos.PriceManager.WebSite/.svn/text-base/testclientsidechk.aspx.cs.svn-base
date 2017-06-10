using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using PriceManager.Business;
using ProjectBase.Utils.Email;

namespace GrundFos.PriceManager.WebSite
{
    public partial class testclientsidechk : System.Web.UI.Page
    {
        GridHelper gh = new GridHelper();

        protected void Page_Load(object sender, EventArgs e)
        {
            WebMailing wm = new WebMailing();
            wm.SendMail("lcrodriguez@gmail.com", "Título del mail", "<b>Subject</b> del mail", "Cuerpo del <b>mail</b>", false);

            //ControllerManager.PriceAttributeHistory.GetAttributeHistoricPrices(10654);

            //// We should recreate the GridHelper on each postback.
            //if (Page.IsPostBack)
            //    gh.RecreateFromJavascript(hidSelChecks.Value.Split(','), Convert.ToBoolean(hidAllSelected.Value));

            //// We are disabling the ViewState for the GridView because we dont need it and is important for the page size.
            //// We will normally recreate the grid on every postback action.
            //// Pending to test Sorting & Click on each row event
            //if (!Page.IsPostBack)
            //    LoadGrid();
        }

        private void LoadGrid()
        {
            ArrayList lst = new ArrayList();
            for (int i = 1; i <= 10; i++ )
                lst.Add(i.ToString());

            this.grdItems.DataSource = lst;
            this.grdItems.RowDataBound += new GridViewRowEventHandler(grdItems_RowDataBound);
            this.grdItems.DataBind();
        }

        void grdItems_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HtmlInputCheckBox chk = e.Row.Cells[0].Controls[1] as HtmlInputCheckBox;
                if (chk != null)
                {
                    chk.Value = e.Row.DataItem.ToString();
                    chk.Checked = gh.IsMarked(Convert.ToInt32(e.Row.DataItem));
                }
            }
        }

        protected void lnkAAA_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }

        protected void lnkChangePage_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }

        protected void grdItems_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            return;
        }
    }
}
