using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Security;
using ProjectBase.Data;
using NybbleMembership;

namespace PriceManager.Core
{
    [Serializable]
    public class BaseAuditableEntity<T> : AuditableEntity<T>
    {
        private string _createdByName = string.Empty;
        public virtual string CreatedByName
        {
            get
            {
                if (string.IsNullOrEmpty(_createdByName) && this.TimeStamp.CreatedBy != null)
                {
                    MembershipHelperUser mu = MembershipHelper.GetUser(this.TimeStamp.CreatedBy);
                    if (mu != null)
                        _createdByName = mu.FullName;

                }
                return _createdByName;
            }
        }

        private string _modifiedByName = string.Empty;
        public virtual string ModifiedByName
        {
            get
            {
                if (string.IsNullOrEmpty(_modifiedByName) && this.TimeStamp.ModifiedBy != null)
                {
                    MembershipHelperUser mu = MembershipHelper.GetUser(this.TimeStamp.ModifiedBy);
                    if (mu != null)
                        _modifiedByName = mu.UserName;

                }
                return _modifiedByName;
            }
        }


        public virtual string ModifiedOnFormatted
        {
            get
            {
                if (this.TimeStamp.ModifiedOn.HasValue)
                    return this.TimeStamp.ModifiedOn.Value.ToLongDateString();
                else
                    return string.Empty;
            }
        }

        public virtual string CreatedOnFormatted
        {
            get
            {
                return this.TimeStamp.CreatedOn.ToLongDateString();
            }
        }

    }
}
