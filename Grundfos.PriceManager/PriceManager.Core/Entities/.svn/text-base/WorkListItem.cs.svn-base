using System;
using System.Collections.Generic;
using System.Text;
using ProjectBase.Data;

namespace PriceManager.Core
{
    [Serializable]
    public class WorkListItemHistory : WorkListItemAbstract
    {
        private HistoryStatus historyStatus;
        private PriceBase priceBase;

        public virtual PriceBase PriceBase
        {
            get { return priceBase; }
            set { priceBase = value; }
        }

        public virtual HistoryStatus HistoryStatus
        {
            get { return historyStatus; }
            set { historyStatus = value; }
        }

        public WorkListItemHistory() { }

        public WorkListItemHistory(int id)
        {
            this.id = id;
        }
    }

    [Serializable]
    public class WorkListItem : WorkListItemAbstract
    {
    }


    [Serializable]
    public abstract class WorkListItemAbstract : ListItemAbstract
    {
        private PriceAttribute priceAttribute;
        private WorkListItemHistory lastApproved;
        private WorkListItemStatus workListItemStatus;
        private PriceList priceList;
        private PublishItem lastPublishItem;

        [DomainSignatureAttribute]
        public virtual PriceList PriceList
        {
            get { return priceList; }
            set { priceList = value; }
        }

        [DomainSignatureAttribute]
        public virtual PriceAttribute PriceAttribute
        {
            get { return priceAttribute; }
            set { priceAttribute = value; }
        }

        public virtual WorkListItemHistory LastApproved
        {
            get { return lastApproved; }
            set { lastApproved = value; }
        }

        public virtual PublishItem LastPublishItem
        {
            get { return lastPublishItem; }
            set { lastPublishItem = value; }
        }

        public virtual WorkListItemStatus WorkListItemStatus
        {
            get { return workListItemStatus; }
            set { workListItemStatus = value; }
        }
    }
}
