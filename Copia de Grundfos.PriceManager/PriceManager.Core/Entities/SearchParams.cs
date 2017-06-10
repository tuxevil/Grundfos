using System;
using System.Collections.Generic;
using System.Text;

namespace PriceManager.Core
{
    [Serializable]
    public class SearchParams
    {
        private string description;
        private int family;
        private int ctrRange;
        private int selection;
        private int productType;
        private int pageNumber = 1;
        private int pageSize = 10;
        private string sortColumn = "Code";
        private string sortOrder = "desc";
        private int pagecount;
        private int currency;
        private int category;
        private bool marked;

        public virtual bool Marked
        {
            get { return marked;  }
            set { marked = value; }
        }

        public virtual string Description
        {
            get { return description; }
            set { description = value; }
        }

        public virtual int Family
        {
            get { return family; }
            set { family = value; }
        }

        public virtual int CtrRange
        {
            get { return ctrRange; }
            set { ctrRange = value; }
        }

        public virtual int Selection
        {
            get { return selection; }
            set { selection = value; }
        }

        public virtual int ProductType
        {
            get { return productType; }
            set { productType = value; }
        }

        public virtual int PageNumber
        {
            get { return pageNumber; }
            set { pageNumber = value; }
        }

        public virtual int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }

        public virtual string SortColumn
        {
            get { return sortColumn; }
            set { sortColumn = value; }
        }

        public virtual string SortOrder
        {
            get { return sortOrder; }
            set { sortOrder = value; }
        }

        public virtual int Pagecount
        {
            get { return pagecount; }
            set { pagecount = value; }
        }

        public virtual int Currency
        {
            get { return currency; }
            set { currency = value; }
        }

        public virtual int Category
        {
            get { return category; }
            set { category = value; }
        }
    }
}
