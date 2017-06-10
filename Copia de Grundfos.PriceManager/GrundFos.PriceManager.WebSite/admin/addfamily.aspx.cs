using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Collections;
using System.IO;
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
    public partial class addfamily : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HtmlAnchor temp = (HtmlAnchor)Master.FindControl("lnkcategory");
                temp.Attributes["class"] = "current";
                LoadCombo();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDescription.Text) && !string.IsNullOrEmpty(txtName.Text))
            {
                ControllerManager.Family.AddFamily(ControllerManager.Family.GetById(Convert.ToInt32(ddlFamilia.SelectedValue)), txtName.Text, txtDescription.Text);
                Response.Redirect("/admin/addfamily.aspx");
            }
            
        }

        protected void btnErase_Click(object sender, EventArgs e)
        {
            if (ddlFamilia.SelectedValue != "0")
            {
                if (
                    !ControllerManager.Family.IsParent(
                         ControllerManager.Family.GetById(Convert.ToInt32(ddlFamilia.SelectedValue))))
                {
                    ControllerManager.Family.Delete(
                        ControllerManager.Family.GetById(Convert.ToInt32(ddlFamilia.SelectedValue)));
                    LoadCombo();
                }
                else
                    lblError.Visible = true;
            }
            else
                return;
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            if (ddlFamilia.SelectedValue != "0")
            {
                ControllerManager.Family.Modify(
                    ControllerManager.Family.GetById(Convert.ToInt32(ddlFamilia.SelectedValue)), txtModifyName.Text,
                    txtModifyDescription.Text);
                LoadCombo();
                txtModifyDescription.Text = "";
                txtModifyName.Text = "";
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            addForm.Visible = true;
        }

        

        protected void LoadCombo()
        {
            //ddlFamilia.DataSource = ControllerManager.Family.GetFamilyList();
            //ddlFamilia.DataTextField = "Name";
            //ddlFamilia.DataValueField = "ID";
            //ddlFamilia.DataBind();
            //ddlFamilia.Items.Insert(0, new ListItem("--Familia--", "0"));

            List<Family> familylist = ControllerManager.Family.GetAllFamily();
            ListItemCollection familydisplay = new ListItemCollection();

            List<Family> templist = familylist.FindAll(delegate(Family record)
                                                             {
                                                                 if (record.Parent == 0)
                                                                 {
                                                                     return true;
                                                                 }
                                                                 return false;
                                                             });
            foreach (Family family in templist)
            {
                ListItem li = new ListItem(family.Name, family.ID.ToString());
                familydisplay.Add(li);
                familydisplay = GetChildrens(familylist, family, 1, familydisplay);
            }

            ddlFamilia.DataSource = familydisplay;
            ddlFamilia.DataTextField = "Text";
            ddlFamilia.DataValueField = "Value";
            ddlFamilia.DataBind();
            ddlFamilia.Items.Insert(0, new ListItem("--Nueva Categoría--", "0"));
            
        }

        protected void ddlFamilia_SelectedIndexChange(object sender, EventArgs e)
        {
            Family f = new Family();
            f = ControllerManager.Family.GetById(Convert.ToInt32(((DropDownList)sender).SelectedValue));
            addForm.Visible = false;
            lblError.Visible = false;
            if (f != null)
            {
                txtModifyName.Enabled = true;
                txtModifyDescription.Enabled = true;
                txtModifyName.Text = f.Name;
                txtModifyDescription.Text = f.Description;
                btnErase.Enabled = true;
                btnModify.Enabled = true;
            }
            else
            {
                txtModifyName.Enabled = false;
                txtModifyDescription.Enabled = false;
                txtModifyName.Text = "";
                txtModifyDescription.Text = "";
                btnErase.Enabled = false;
                btnModify.Enabled = false;
            }
        }

        private ListItemCollection GetChildrens(List<Family> familylist, Family family, int level, ListItemCollection familydisplay)
        {
            string tabulation = "";

            for(int i = 1; i <= level; i++)
            {
                tabulation = tabulation.Insert(0, new String((char)160, 10));
            }
            tabulation = tabulation.Insert(tabulation.Length, " ");


            List<Family> tempchildrens = familylist.FindAll(delegate(Family record)
                                                             {
                                                                 if (record.Parent == family.ID)
                                                                 {
                                                                     return true;
                                                                 }
                                                                 return false;
                                                             });
            level++;
            foreach (Family tempchildren in tempchildrens)
            {
                ListItem li = new ListItem(tabulation + tempchildren.Name, tempchildren.ID.ToString());
                familydisplay.Add(li);
                GetChildrens(familylist, tempchildren, level, familydisplay);
            }
            return familydisplay;
        }
    }
}
