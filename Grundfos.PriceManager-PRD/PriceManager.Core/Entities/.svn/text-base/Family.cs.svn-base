using System;
using System.Collections.Generic;
using ProjectBase.Data;
using Iesi.Collections.Generic;
using PriceManager.Common;

namespace PriceManager.Core
{
    [Serializable]
    public class CategoryBase : BaseAuditableEntity<int>
    {
        public CategoryBase(int id) { this.id = id; }

        public CategoryBase() { }

        private string description;
        private string name;
        private ICollection<Product> products = new HashedSet<Product>();
        private CategoryBase parent;
        private string type;
        private string nameEnglish;
        private string descripionEnglish;
        private string image;
        private string observations;
        private ICollection<PriceImportLog> priceImportLogs = new HashedSet<PriceImportLog>();
        private CategoryPageStatus? categoryPageStatus;
        private ICollection<PriceList> priceLists = new HashedSet<PriceList>();
        private int? totalCount;
        private int childCount;
        private ICollection<PriceList> publishLists = new HashedSet<PriceList>();

        public virtual ICollection<PriceImportLog> PriceImportLogs
        {
            get { return priceImportLogs; }
            set { priceImportLogs = value; }
        }

        [DomainSignature]
        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }

        public virtual string ShortName
        {
            get { return StringFormat.Cut(Name, 72); }
        }

        public virtual string Description
        {
            get { return description; }
            set { description = value; }
        }

        public virtual ICollection<Product> Products
        {
            get { return products; }
            set { products = value; }
        }

        [DomainSignature]
        public virtual CategoryBase Parent
        {
            get { return parent; }
            set { parent = value; }
        }

        [DomainSignature]
        public virtual string Type
        {
            get { return type; }
            set { type = value; }
        }

        public virtual string NameEnglish
        {
            get { return nameEnglish; }
            set { nameEnglish = value; }
        }

        public virtual string DescripionEnglish
        {
            get { return descripionEnglish; }
            set { descripionEnglish = value; }
        }

        public virtual string Image
        {
            get { return image; }
            set { image = value; }
        }

        public virtual string Observations
        {
            get { return observations; }
            set { observations = value; }
        }

        public virtual CategoryPageStatus? CategoryPageStatus
        {
            get { return categoryPageStatus; }
            set { categoryPageStatus = value; }
        }

        public virtual ICollection<PriceList> PriceLists
        {
            get { return priceLists; }
            set { priceLists = value; }
        }

        public virtual ICollection<PriceList> PublishLists
        {
            get { return publishLists; }
            set { publishLists = value; }
        }
        
        public virtual int? TotalCount
        {
            get { return totalCount; }
            set { totalCount = value; }
        }

        public virtual int ChildCount
        {
            get { return childCount; }
        }
    }

    [Serializable]
    public class Family : CategoryBase { }
    
    [Serializable]
    public class CatalogPage : CategoryBase 
    {
        public CatalogPage(int id)
        {
            this.id = id;
        }

        public CatalogPage(string name)
        {
            this.Name = name;
        }
        public CatalogPage(int id, string name)
        {
            this.id = id;
            this.Name = name;
        }
        public CatalogPage()
        {
        }
    }
    [Serializable]
    public class ProductType : CategoryBase { }
    [Serializable]
    public class Application : CategoryBase { }
    [Serializable]
    public class Area : CategoryBase { }
    [Serializable]
    public class Line : CategoryBase { }
}
