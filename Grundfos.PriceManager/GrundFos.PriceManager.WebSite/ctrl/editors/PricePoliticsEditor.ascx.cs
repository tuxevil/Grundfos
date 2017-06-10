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
using PriceManager;
using PriceManager.Core;
using PriceManager.Business;
using System.Collections.Generic;
using PriceManager.Common;
using NybbleMembership;
using NybbleMembership.Core.Domain;

namespace GrundFos.PriceManager.WebSite.ctrl.editors
{
    public partial class PricePoliticsEditor : System.Web.UI.UserControl
    {
        #region Properties

        public int PoliticId
        {
            get
            {
                if (ViewState["PoliticId"] != null)
                    return Convert.ToInt32(ViewState["PoliticId"]);
                else
                    return 0;
            }
            set { ViewState["PoliticId"] = value; }
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
                //ddlCategory.DataSource = ControllerManager.CategoryBase.GetHierarchyItems(false);
                //ddlCategory.DataTextField = "Text";
                //ddlCategory.DataValueField = "Value";
                //ddlCategory.DataBind();
                //ddlCategory.Items.Insert(0, new ListItem("--Categoría--", "0"));
                ddlCategoryLinked.DataBind();

                ddlProvider.DataSource = ControllerManager.Provider.GetActives();
                ddlProvider.DataTextField = "Name";
                ddlProvider.DataValueField = "ID";
                ddlProvider.DataBind();
                ddlProvider.Items.Insert(0, new ListItem("--Proveedor--", "0"));

                if (Mode != EditionMode.Create)
                {
                    LoadFields();

                    //RequiredFieldValidator rfvForm1 = new RequiredFieldValidator();
                    //rfvForm1.ErrorMessage="Por favor, ingrese una formula.";
                    //rfvForm1.Display = ValidatorDisplay.Dynamic;
                    //rfvForm1.ValidationGroup = "valFields"; 
                    //rfvForm1.ControlToValidate= "txtFormula1";
                  
                }
                txtFormula2.Visible = true;
                lblform2.Visible = true;
                SetVisibility();
            }
        }

        private void LoadFields()
        {
            if (PoliticId != 0)
            {
                PriceCalculation pc = ControllerManager.PriceCalculation.GetById(PoliticId);
                if(pc != null)
                {
                    PriceCalculation pc2 = ControllerManager.PriceCalculation.Get(pc.Provider, pc.CategoryBase, 2);

                    txtFormula1.Text = pc.Formula;
                    if (pc2 != null)
                        txtFormula2.Text = pc2.Formula;
                    if (pc.CategoryBase != null)
                        ddlCategoryLinked.Values = pc.CategoryBase.ID;

                    if (pc.Provider != null)
                        ddlProvider.SelectedValue = ddlProvider.Items.FindByValue(pc.Provider.ID.ToString()).Value;    
                }
                else
                {
                    Utils.ShowMessage(Page, "La política de precios seleccionada no existe.", Utils.MessageType.Error);
                }

                


            }
        }

        protected void SetVisibility()
        {
            bool enabled = (Mode == EditionMode.Edit || Mode == EditionMode.Create);

            foreach (Control c in this.Controls)
                if (c is WebControl && c.GetType() != typeof(LinkButton) )
                    (c as WebControl).Enabled = enabled;

            btnSave.Visible = enabled;
            lnkDetails.Visible = (Mode == EditionMode.Edit);

            if (PoliticId != 0)
                lnkEdit.Visible = !enabled;
            else
                lnkEdit.Visible = (Mode != EditionMode.Create);

            lnkEdit.Visible = (PermissionManager.Check(lnkEdit) && Mode == EditionMode.View);
            if(enabled)
                txtFormula1.Focus();
                
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

            Provider provider = null;
            if (ddlProvider.SelectedIndex != 0)
                provider = ControllerManager.Provider.GetById(Convert.ToInt32(ddlProvider.SelectedValue));

            CategoryBase category = null;
            if (ddlCategoryLinked.Index != 0)
                category = ControllerManager.CategoryBase.GetById(Convert.ToInt32(ddlCategoryLinked.Values));

            string errors;
            bool mainvalid = false;
            bool secvalid = true;
            bool error = false;
            PriceCalculation pc = null;

            if ((!string.IsNullOrEmpty(txtFormula1.Text) || !string.IsNullOrEmpty(txtFormula2.Text)) && (txtFormula1.Text != txtFormula2.Text))
            {
                if (!string.IsNullOrEmpty(txtFormula1.Text))
                {
                    try
                    {
                        ControllerManager.PriceCalculation.CheckFormula(txtFormula1.Text, out errors, out mainvalid);
                    }
                    catch (Exception ex)
                    {
                        Utils.ShowMessage(this.Page, "Error en la formula principal.", Utils.MessageType.Error);
                    }
                    
                    if (mainvalid && !string.IsNullOrEmpty(txtFormula2.Text))
                        try
                        {
                            ControllerManager.PriceCalculation.CheckFormula(txtFormula2.Text, out errors, out secvalid);
                        }
                        catch (Exception)
                        {
                            Utils.ShowMessage(this.Page, "Error en la formula secundaria.", Utils.MessageType.Error);   
                        }
                        

                    if (mainvalid && secvalid)
                    {
                        int pcid = 0;
                        pc = ControllerManager.PriceCalculation.FindOrCreate(PoliticId, provider, category, txtFormula1.Text, 1);
                        if (pc.ID == -1)
                        {
                            Utils.ShowMessage(this.Page, "Ya existe fórmula principal para esa política.", Utils.MessageType.Error);
                            error = true;
                        }
                        else
                            pcid = pc.ID;
                        if (!string.IsNullOrEmpty(txtFormula2.Text))
                        {
                            pc = ControllerManager.PriceCalculation.FindOrCreate(0, provider, category, txtFormula2.Text, 2);
                            if (pc.ID == -1)
                            {
                                Utils.ShowMessage(this.Page, "Ya existe fórmula secundaria para esa política.", Utils.MessageType.Error);
                                error = true;
                            }
                        }

                        ControllerManager.PriceCalculation.Run(pc.Provider, pc.CategoryBase);

                        if (!error)
                            Response.Redirect("/admin/pricespolitics/view/?Id=" + pcid);

                    }
                    else
                        Utils.ShowMessage(this.Page, "Revise las formulas.", Utils.MessageType.Error);
                }
            }
            else
                Utils.ShowMessage(this.Page, "No ingrese 2 formulas iguales.", Utils.MessageType.Error);
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