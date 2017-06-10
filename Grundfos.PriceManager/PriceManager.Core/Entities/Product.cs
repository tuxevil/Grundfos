using System;
using System.Collections.Generic;
using ProjectBase.Data;
using Iesi.Collections.Generic;

namespace PriceManager.Core
{
    [Serializable]
    public class Product : BaseAuditableEntity<int>
    {
        private string code;
        private string description;
        private ICollection<CategoryBase> families = new HashedSet<CategoryBase>();
        private ICollection<Selection> selections = new HashedSet<Selection>();
        private ProductStatus status;
        private ICollection<Provider> providers = new HashedSet<Provider>();
        private ICollection<PriceBase> priceBases = new HashedSet<PriceBase>();
        private string model;
        private string keywords;
        private Frequency? frequency;
        private string eAN;
        private string descriptionAlternative;
        private string observations;
        private string modelAlternative;
        private string image;


        public Product(int id)
        {
            this.id = id;
        }

        public Product()
        {
        }

        public virtual string Description
        {
            get { return description; }
            set { description = value; }
        }

        [DomainSignature]
        public virtual string Code
        {
            get { return code; }
            set { code = value; }
        }

        public virtual ICollection<CategoryBase> Families
        {
            get { return families; }
            set { families = value; }
        }

        public virtual ICollection<Selection> Selections
        {
            get { return selections; }
            set { selections = value; }
        }

        public virtual ProductStatus Status
        {
            get { return status; }
            set { status = value; }
        }

        public virtual ICollection<Provider> Providers
        {
            get { return providers; }
            set { providers = value; }
        }

        public virtual ICollection<PriceBase> PriceBases
        {
            get { return priceBases; }
            set { priceBases = value; }
        }

        [DomainSignature]
        public virtual string Model
        {
            get { return model; }
            set { model = value; }
        }

        public virtual string Keywords
        {
            get { return keywords; }
            set { keywords = value; }
        }

        public virtual Frequency? Frequency
        {
            get { return frequency; }
            set { frequency = value; }
        }

        [DomainSignature]
        public virtual string EAN
        {
            get { return eAN; }
            set { eAN = value; }
        }

        public virtual string ModelAlternative
        {
            get { return modelAlternative; }
            set { modelAlternative = value; }
        }

        public virtual string DescriptionAlternative
        {
            get { return descriptionAlternative; }
            set { descriptionAlternative = value; }
        }

        public virtual string Observations
        {
            get { return observations; }
            set { observations = value; }
        }

        public virtual string Image
        {
            get { return image; }
            set { image = value; }
        }
    }

}
