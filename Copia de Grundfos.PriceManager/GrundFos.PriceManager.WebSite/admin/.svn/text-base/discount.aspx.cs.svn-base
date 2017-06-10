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

namespace GrundFos.PriceManager.WebSite
{
    public partial class discount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HtmlAnchor temp = (HtmlAnchor) Master.FindControl("lnkdiscount");
                temp.Attributes["class"] = "current";
                LoadCombo();
            }
            Form.DefaultButton = btnModify.UniqueID;
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            if (ddlDiscount.SelectedValue != "0" && !string.IsNullOrEmpty(txtModifyDiscount.Text))
            {
                Discount disc = ControllerManager.Discount.GetById(Convert.ToInt32(ddlDiscount.SelectedValue));
                MembershipUser user = Membership.GetUser();
                ControllerManager.Discount.Modify(disc, Convert.ToDecimal(txtModifyDiscount.Text.Replace(",", ".")));
                //take the pricelist list with his relationed discounts
                ControllerManager.Discount.RunModification(disc, (Guid)user.ProviderUserKey, DateTime.Now);
                lblModification.Visible = true;
                lblError.Visible = false;
            }
            else
            {
                if( ddlDiscount.SelectedValue == "0")
                {
                    lblError.Text = "Seleccione un descuento.";
                    lblError.Visible = true;
                }
            }
        }

        protected void LoadCombo()
        {
            ddlDiscount.DataSource = ControllerManager.Discount.GetAll();
            ddlDiscount.DataTextField = "Description";
            ddlDiscount.DataValueField = "ID";
            ddlDiscount.DataBind();
            ddlDiscount.Items.Insert(0, new ListItem("--Descuento--", "0"));
        }

        protected void ddlDiscount_SelectedIndexChange(object sender, EventArgs e)
        {

            if (ddlDiscount.SelectedValue != "0")
            {
                Discount d = new Discount();
                d = ControllerManager.Discount.GetById(Convert.ToInt32(ddlDiscount.SelectedValue));
                txtModifyDiscount.Text = d.MaxDiscount.ToString();
            }
            else
                txtModifyDiscount.Text = "";
            
            lblError.Visible = false;
            lblModification.Visible = false;
        }
       
    }
}
