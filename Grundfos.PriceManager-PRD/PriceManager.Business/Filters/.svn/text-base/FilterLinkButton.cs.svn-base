using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace PriceManager.Business.Filters
{
    public class FilterLinkButton : LinkButton
    {
        public string RelatedFilterID
        {
            get
            {
                if (ViewState["RelatedFilterID"] != null)
                    return ViewState["RelatedFilterID"].ToString();
                else
                    return "";
            }
            set { ViewState["RelatedFilterID"] = value; }
        }

        public string LinkText
        {
            get
            {
                if (ViewState["LinkText"] != null)
                    return ViewState["LinkText"].ToString();
                else
                    return "";
            }
            set { ViewState["LinkText"] = value; }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            Label lbl = new Label();
            lbl.Text = LinkText.Trim();
            lbl.RenderControl(writer);
            writer.Write("&nbsp");
            base.Render(writer);
            writer.Write("&nbsp");
        }

        protected override void OnInit(EventArgs e)
        {
            Text = "[x]";
            base.OnInit(e);
        }
    }
}
