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
using PriceManager.Business;
using System.Collections.Generic;
using PriceManager.Core;
using NybbleMembership;
using NybbleMembership.Core.Domain;
using PriceManager.Common;

namespace GrundFos.PriceManager.WebSite.ctrl
{
    public partial class Notes : System.Web.UI.UserControl
    {
        #region Properties

        public int TypeIdentifier
        {
            get
            {
                if (ViewState["TypeIdentfier"] != null)
                    return Convert.ToInt32(ViewState["TypeIdentfier"]);
                else
                    return 0;
            }
            set { ViewState["TypeIdentfier"] = value; }
        }

        public int? MaxRows
        {
            get
            {
                if (ViewState["MaxRows"] != null)
                    return Convert.ToInt32(ViewState["MaxRows"]);
                else
                    return null;
            }
            set { ViewState["MaxRows"] = value; }
        }

        public Type NoteType
        {
            get
            {
                if (ViewState["NoteType"] != null)
                    return (Type)ViewState["NoteType"];
                else
                    return null;
            }
            set { ViewState["NoteType"] = value; }
        }

        #endregion

        #region PageLoad
        public override void  DataBind()
        {
            if (!Page.IsPostBack)
            {
                LoadNotes();
            }
            
            base.DataBind();
        }

        private void LoadNotes()
        {
            IList<Note> lst = ControllerManager.Note.ListByType(NoteType, TypeIdentifier, MaxRows);
            rpterNotes.DataSource = lst;
            rpterNotes.DataBind();

            if (lst.Count < MaxRows)
                lnkSeeAll.Visible = false;

            litNoItems.Visible = false;
            if (lst.Count == 0)
                litNoItems.Visible = true;

            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //Control de visibilidad para todas las notas.
            if (!Page.IsPostBack)
                this.Visible = PermissionManager.Check(this);
        }

        #endregion

        #region Grid Events
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (NoteType == null)
                    throw new NoteTypeNullException("Type of Note return null.");

                ControllerManager.Note.Create(NoteType, TypeIdentifier, string.Empty, txtDescription.Text.Replace("\r\n", "<br />"));
                txtDescription.Text = string.Empty;
                LoadNotes();
            }   
        }
       
        protected void rpterNotes_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
                return;

            Note nTemp = (Note)e.Item.DataItem;

            //Checkeo de permisos para borrar nota.
            e.Item.FindControl("lnkErase").Visible = PermissionManager.Check(e.Item.FindControl("lnkErase"));

            (e.Item.FindControl("litDate") as Literal).Text = string.Format("El {0} a las {1}" , nTemp.TimeStamp.CreatedOn.ToShortDateString(), nTemp.TimeStamp.CreatedOn.ToLongTimeString());
            MembershipHelperUser mhu = MembershipHelper.GetUser(nTemp.TimeStamp.CreatedBy);
            if (mhu != null)
                (e.Item.FindControl("litUser") as Literal).Text = string.Format("{0} ({1}) escribió:", mhu.FullName, mhu.UserName);
        }

        protected void lnkSeeAll_Click(object sender, EventArgs e)
        {
            rpterNotes.DataSource = ControllerManager.Note.ListByType(NoteType, TypeIdentifier);
            rpterNotes.DataBind();
            lnkSeeAll.Visible = false;
        }

        #endregion

        #region Erase

        protected void rpterNotes_ItemCommand(object source, RepeaterCommandEventArgs e)
            {
                if (e.CommandName == "Erase")
                    ControllerManager.Note.Remove(Convert.ToInt32(e.CommandArgument));
                
                LoadNotes();
            }

        #endregion
    }
}