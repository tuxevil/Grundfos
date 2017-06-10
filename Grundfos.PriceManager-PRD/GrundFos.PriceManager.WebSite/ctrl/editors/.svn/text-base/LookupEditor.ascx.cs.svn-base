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
using PriceManager.Core;
using PriceManager.Business;
using System.Collections.Generic;
using PriceManager.Common;
using NybbleMembership;

namespace GrundFos.PriceManager.WebSite.ctrl.editors
{
    public partial class LookupEditor : System.Web.UI.UserControl
    {
        #region Properties

        public int LookupId
        {
            get
            {
                if (ViewState["LookupId"] != null)
                    return Convert.ToInt32(ViewState["LookupId"]);
                else
                    return 0;
            }
            set { ViewState["LookupId"] = value; }
        }

        public EditionMode Mode
        {
            get
            {
                if (ViewState["Type"] != null)
                    return (EditionMode)ViewState["Type"];
                return EditionMode.View;
            }
            set { ViewState["Type"] = value; }
        }

        #endregion

        #region Load

        public override void DataBind()
        {
            if (!Page.IsPostBack)
            {
                ddlType.DataSource = EnumHelper.GetList(typeof(LookupType));
                ddlType.DataTextField = "Value";
                ddlType.DataValueField = "Key";
                ddlType.DataBind();

                if (Mode != EditionMode.Create)
                    LoadFields();
                
                SetVisibility();
            }
        }
        protected void LoadFields()
        {
            if (LookupId != 0)
            {
                Lookup lu = ControllerManager.Lookup.GetById(LookupId);

                ddlType.SelectedValue = ddlType.Items.FindByValue(lu.LookupType.ToString()).Value;
                txtDescription.Text = lu.Description;

            }
        }

        protected void SetVisibility()
        {
            bool enabled = (Mode == EditionMode.Edit || Mode == EditionMode.Create);

            foreach (Control c in this.Controls)
                if (c is WebControl && c.GetType() != typeof(LinkButton)) 
                    (c as WebControl).Enabled = enabled;

            btnSave.Visible = enabled;
            ddlType.Enabled = (Mode == EditionMode.Create);
            lnkDetails.Visible = (Mode == EditionMode.Edit);

            if (LookupId != 0)
                lnkEdit.Visible = !enabled;
            else
                lnkEdit.Visible = (Mode != EditionMode.Create);

            lnkEdit.Visible = (PermissionManager.Check(lnkEdit) && Mode == EditionMode.View);
            if (Mode == EditionMode.Edit)
            {
                txtDescription.Focus();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        #endregion

        #region Events

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            LookupType lut = (LookupType)Enum.Parse(typeof(LookupType), ddlType.SelectedValue);

            if (Mode == EditionMode.Edit)
                ControllerManager.Lookup.Edit(LookupId, lut, txtDescription.Text);
            else
            {

                Lookup lu = ControllerManager.Lookup.Create(lut, txtDescription.Text);
                Response.Redirect("/admin/lookups/view/?Id=" + lu.ID);
            }
            
            Mode = EditionMode.View;
            SetVisibility();
        }

        #endregion

        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            Mode = EditionMode.Edit;
            lblTitle.Text = "Edición";
            SetVisibility();
        }

        protected void lnkDetails_Click(object sender, EventArgs e)
        {
            Mode = EditionMode.View;
            lblTitle.Text = "Detalles";
            LoadFields();
            SetVisibility();
        }

    }
}