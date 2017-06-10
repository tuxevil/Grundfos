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
    public class PropertyTemplateField : ITemplate
    {
        private DataControlRowType templateType;
        private string dataTextField;
        private string dataPropertyField;
        private string dataTextFormatString;

        public PropertyTemplateField(DataControlRowType templateType, string dataPropertyField, string dataTextField)
        {
            Initialize(templateType, dataPropertyField, dataTextField, null);
        }

        public PropertyTemplateField(DataControlRowType templateType, string dataPropertyField, string dataTextField, string dataTextFormatString)
        {
            Initialize(templateType, dataPropertyField, dataTextField, dataTextFormatString);
        }

        public void Initialize(DataControlRowType templateType, string dataPropertyField, string dataTextField, string dataTextFormatString)
        {
            this.TemplateType = templateType;
            this.DataPropertyField = dataPropertyField;
            this.DataTextField = dataTextField;
            this.DataTextFormatString = dataTextFormatString;
        }

        public string DataTextFormatString
        {
            get { return dataTextFormatString; }
            set { dataTextFormatString = value; }
        }

        public string DataTextField
        {
            get { return dataTextField; }
            set { dataTextField = value; }
        }

        public string DataPropertyField
        {
            get { return dataPropertyField; }
            set { dataPropertyField = value; }
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
                    Literal lc2 = new Literal();
                    lc2.DataBinding += new EventHandler(lc_DataBinding);

                    container.Controls.Add(lc2);
                    break;
            }
        }

        private void lc_DataBinding(object sender, EventArgs e)
        {
            Literal lc = (Literal)sender;
            GridViewRow row = (GridViewRow)lc.NamingContainer;
            object o = DataBinder.Eval(DataBinder.Eval(row.DataItem, DataPropertyField), DataTextField);

            if (o is Enum)
                o = EnumHelper.GetDescription(o as Enum);

            if (o != null)
                lc.Text = (DataTextFormatString != null) ? String.Format(DataTextFormatString, o) : o.ToString();
            else
                lc.Text = "N/D";
        }

        #endregion

    }
}
