using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using NybbleMembership;
using NybbleMembership.Core.Domain;

namespace PriceManager.Business.Filters
{
    public class UserFilter : DropDownFilter
    {
        #region Abstract Members

        public override Type ClassName
        {
            get { return typeof(Guid); }
        }

        public override string PropertyName
        {
            get { return "UserId"; }
        }

        public override string FilterName
        {
            get { return PropertyName; }
        }

        #endregion

        protected override void OnInit(EventArgs e)
        {
            // OnInit always refresh because we need it for setup on page.
            Refresh();
            base.OnInit(e);
        }

        public override void Refresh()
        {
            IList<UserMember> lst = MembershipManager.ListBySite();
            IList<MembershipHelperUser> lstfinal = new List<MembershipHelperUser>();
            foreach (UserMember member in lst)
            {
                lstfinal.Add(MembershipHelper.GetUser(member.ID));
            }
            DataSource = lstfinal;
            DataTextField = "FullName";
            DataValueField = "UserId";
            DataBind();
            Items.Insert(0, new ListItem("--Usuario--", "0"));
        }
    }
}
