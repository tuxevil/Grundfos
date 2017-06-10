using System;
using System.Collections.Generic;
using System.Text;
using ProjectBase.Data;
using Iesi.Collections.Generic;

namespace PriceManager.Core
{
    [Serializable]
    public class PublishList : BaseAuditableEntity<int>
    {
        private DateTime validFrom;
        private PriceList priceList;
        private ICollection<PublishItem> publishItems = new HashedSet<PublishItem>();
        private ICollection<CatalogPage> publishedCategoryPages = new HashedSet<CatalogPage>();

        public virtual DateTime ValidFrom
        {
            get { return validFrom; }
            set { validFrom = value; }
        }

        public virtual PriceList PriceList
        {
            get { return priceList; }
            set { priceList = value; }
        }

        public virtual ICollection<PublishItem> PublishItems
        {
            get { return publishItems; }
            set { publishItems = value; }
        }

        public virtual ICollection<CatalogPage> PublishedCategoryPages
        {
            get { return publishedCategoryPages; }
            set { publishedCategoryPages = value; }
        }

        public PublishList() { }
        
        public PublishList(int id)
        {
            this.id = id;
        }
    }
}
