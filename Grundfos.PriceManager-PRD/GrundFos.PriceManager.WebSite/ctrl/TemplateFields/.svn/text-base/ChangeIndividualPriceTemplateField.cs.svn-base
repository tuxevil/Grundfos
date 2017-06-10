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
    public class ChangeIndividualPriceTemplateField : ITemplate
    {
        private DataControlRowType templateType;

        public ChangeIndividualPriceTemplateField(DataControlRowType templateType)
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
                    HtmlImage img = new HtmlImage();
                    img.Src = "/img/edit.jpg";
                    img.Attributes["class"] = "change_price";
                    container.Controls.Add(img);
                    break;
            }
        }

        #endregion
    }
}
