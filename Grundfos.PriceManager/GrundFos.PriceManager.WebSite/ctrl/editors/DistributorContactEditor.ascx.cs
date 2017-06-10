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
using PriceManager;
using NybbleMembership;

namespace GrundFos.PriceManager.WebSite.ctrl.editors
{
    public partial class DistributorContactEditor : System.Web.UI.UserControl
    {
        #region Event
        public event CommandEventHandler SaveCreation;
        #endregion

        #region Properties
        public int DistributorId
        {
            get
            {
                if (ViewState["distributorId"] != null)
                    return Convert.ToInt32(ViewState["distributorId"]);
                else
                    return 0;
            }
            set { ViewState["distributorId"] = value; }
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

        private Contact distributorContact;
        public Contact DistributorContact
        {
            get 
            {
                if (distributorContact != null)
                {
                    ContactId = distributorContact.ID;
                    Status = distributorContact.Status;
                    return distributorContact;
                }
                else
                    return null;
            }

            set
            {
                distributorContact = value;
            }
        }

        public int ContactId
        {
            get
            {
                if (ViewState["contactId"] != null)
                    return Convert.ToInt32(ViewState["contactId"]);
                else
                    return 0;
            }
            set { ViewState["contactId"] = value; }
        }

        public ContactStatus Status
        {
            get
            {
                if (ViewState["status"] != null)
                    return (ContactStatus)(ViewState["status"]);
                else
                    return ContactStatus.Disable;
            }
            set { ViewState["status"] = value; }
        }
        #endregion

        #region Load
        public override void DataBind()
        {
            SetVisibility();
            LoadFields();
        }

        private void SetVisibility()
        {
            bool enabled = (Mode == EditionMode.Edit || Mode == EditionMode.Create);

            foreach (Control c in this.Controls)
                if (c is WebControl && c.GetType() != typeof(LinkButton) && c.GetType() != typeof(ImageButton) && c.GetType() != typeof(HtmlContainerControl))
                    (c as WebControl).Enabled = enabled;

            btnSave.Visible = enabled;
            txtMail.Enabled = enabled;
            
            //Si es nuevo, no tiene que haber botones, salvo para salvar.
            lnkDetails.Visible = (Mode != EditionMode.View);
            lnkEdit.Visible = ((Mode == EditionMode.View) && (PermissionManager.Check(lnkEdit)));
            //btnStatus.Visible = ((Mode != EditionMode.Create)&& PermissionManager.Check(btnStatus));
            btnStatus.Visible = !enabled;

            //escondo los controles de nombres hasta apretar editar o cuando creo
            txtLastName.Visible = (Mode != EditionMode.View);
            txtName.Visible = (Mode != EditionMode.View);

            if (Mode == EditionMode.Create)
                lblCompleteName.Text = "Nuevo Contacto";

            //si esta descativado no puedo editar
            //if (Mode == EditionMode.View && Status == ContactStatus.Active && PermissionManager.Check(lnkEdit))
            //    lnkEdit.Visible = true;
            //else
            //    lnkEdit.Visible = false;
        }

        public void LoadFields()
        {
            if (DistributorContact != null)
            {
                lblCompleteName.Text = DistributorContact.InverseFullName; 
                txtLastName.Text = DistributorContact.LastName;
                txtName.Text = DistributorContact.Name;
                txtMail.Text = DistributorContact.Email;

                ChangeStatusView();
            }
        }

        private void ChangeStatusView()
        {
            if (Status == ContactStatus.Active)
            {
                btnStatus.ImageUrl = "~/img/deactivate.png";
                btnStatus.ToolTip = "Desactivar";
                //El estilo del recuadro debería ser celeste
                barTitle.Attributes["class"] = "contactOn";
                contactSquare.Attributes.Add("style", "background-color:");
            }
            else
            {
                btnStatus.ImageUrl = "~/img/activate.png";
                btnStatus.ToolTip = "Activar";
                //El estilo del recuadro debería ser rojizo
                barTitle.Attributes["class"] = "contactOff";
                contactSquare.Attributes.Add("style", "background-color:#eeeeee");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string valGroup = "val" + ContactId;
            txtLastName.ValidationGroup = valGroup;
            txtMail.ValidationGroup = valGroup;
            btnSave.ValidationGroup = valGroup;
            txtName.ValidationGroup = valGroup;
        }

        #endregion

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            if (Mode == EditionMode.Create)
            {
                try
                {
                    DistributorContact = ControllerManager.Distributor.AddContact(DistributorId, txtName.Value.ToString(), txtLastName.Text, txtMail.Text);

                    if (SaveCreation != null)
                        SaveCreation(sender, new CommandEventArgs("Created",DistributorContact.ID));
                }
                catch (DistributorContactAlreadyExistsException)
                {
                    Utils.ShowMessageInAjax(this.Page, "El Email ya existe para este Canal de Ventas.", Utils.MessageType.Error);
                    //txtMail.Text = string.Empty;
                }
            }
            else
            {
                try
                {
                    DistributorContact = ControllerManager.Distributor.EditContact(DistributorId, ContactId, txtName.Value.ToString(), txtLastName.Text, txtMail.Text);
                    if (SaveCreation != null)
                        SaveCreation(sender, new CommandEventArgs("Edited", DistributorContact.ID));

                    Mode = EditionMode.View;
                    LoadFields();
                    SetVisibility();
                }
                catch (DistributorContactAlreadyExistsException)
                {
                    Utils.ShowMessageInAjax(this.Page, "El Email ya existe para este Canal de Ventas.", Utils.MessageType.Error);
                    //ReloadFields();
                }
            }
            
        }

        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            Mode = EditionMode.Edit;
            SetVisibility();
        }

        private void ReloadFields()
        {
            DistributorContact = ControllerManager.Distributor.FindContactInDistributor(DistributorId, ContactId);
            LoadFields();
        }

        protected void lnkDetails_Click(object sender, EventArgs e)
        {
            if (Mode != EditionMode.Create)
            {
                Mode = EditionMode.View;
                ReloadFields();
                SetVisibility();
            }
            else
            {
                if (SaveCreation != null)
                    SaveCreation(sender, new CommandEventArgs("CloseCreate", null));
            }
        }

        private void Reload()
        {
            DistributorContact = ControllerManager.Distributor.FindContactInDistributor(DistributorId, ContactId);
            LoadFields();
        }

        protected void btnStatus_Click(object sender, ImageClickEventArgs e)
        {
            Contact c = ControllerManager.Distributor.ChangeStatus(DistributorId, ContactId);
            Status = c.Status;
            ChangeStatusView();

            if (SaveCreation != null)
                SaveCreation(sender, new CommandEventArgs("ChangeStatus", Status));
        }

        public void EraseFields()
        {
            txtLastName.Text = string.Empty;
            txtMail.Text = string.Empty;
            txtName.Text = string.Empty;
        }
    }
}