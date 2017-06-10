using System;
using System.Collections.Generic;
using System.Text;
using ProjectBase.Data;

namespace PriceManager.Core
{
    public class PriceListCurrentState : Entity<int>
    {
        private DateTime? publishOn;
        private DateTime? lastPublishedOn;
        private PublishListStatus status;
        private PriceList priceList;
        private int pendingToApproveCount;
        private int modifiedSinceLastApproval;

        public virtual DateTime? PublishOn
        {
            get { return publishOn; }
            set { publishOn = value; }
        }

        public virtual DateTime? LastPublishedOn
        {
            get { return lastPublishedOn; }
            set { lastPublishedOn = value; }
        }

        public virtual PublishListStatus Status
        {
            get { return status; }
            set { status = value; }
        }

        public virtual PriceList PriceList
        {
            get { return priceList; }
            set { priceList = value; }
        }

        public virtual int PendingToApproveCount
        {
            get { return pendingToApproveCount; }
            set { pendingToApproveCount = value; }
        }

        public virtual int ModifiedSinceLastApproval
        {
            get { return modifiedSinceLastApproval; }
            set { modifiedSinceLastApproval = value; }
        }
    }
}
