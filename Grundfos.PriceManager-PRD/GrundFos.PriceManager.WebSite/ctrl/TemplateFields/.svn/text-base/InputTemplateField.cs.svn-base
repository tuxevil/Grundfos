using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace GrundFos.PriceManager.WebSite.ctrl
{
    public class InputTemplateField : ITemplate
    {
        private DataControlRowType templateType;
        
        public InputTemplateField(DataControlRowType templateType)
        {
            this.TemplateType = templateType;
        }

        public DataControlRowType TemplateType
        {
            get { return templateType; }
            set { templateType = value; }
        }

        #region ITemplate Members

        public void InstantiateIn(Control container)
        {
            switch (TemplateType)
            {
                case DataControlRowType.DataRow:
                    HtmlInputCheckBox cbx = new HtmlInputCheckBox();
                    cbx.Visible = true;
                    cbx.Attributes["class"] = "chklist";
                    cbx.DataBinding += new EventHandler(lc_DataBinding);

                    container.Controls.Add(cbx);
                    break;
            }
        }

        private void lc_DataBinding(object sender, EventArgs e)
        {
            HtmlInputCheckBox cbx = (HtmlInputCheckBox)sender;

            GridViewRow row = (GridViewRow)cbx.NamingContainer;
            cbx.Value = DataBinder.Eval(row.DataItem, "ID").ToString();
        }

        #endregion
    }
}
