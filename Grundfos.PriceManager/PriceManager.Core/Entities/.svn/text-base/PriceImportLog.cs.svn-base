using System;
using System.Collections.Generic;
using System.Text;
using ProjectBase.Data;
using Iesi.Collections.Generic;

namespace PriceManager.Core
{
    [Serializable]
    public class PriceImportLog : BaseAuditableEntity<Guid>
    {
        private PriceImport priceImport;
        private string codGrundfos;
        private string codProvider;
        private string model;
        private string description;
        private string provider;
        private string frequency;
        private decimal? tP;
        private string tPCurrency;
        private decimal? gRP;
        private string gRPCurrency;
        private decimal? pL;
        private string pLCurrency;
        private string cat1;
        private string cat2;
        private string cat3;
        private string originalLine;
        private PriceImportLogStatus status;
        private string detail;
        private int fileIndex;

        private PriceBase parsedPriceBase;

        public virtual PriceBase ParsedPriceBase
        {
            get { return parsedPriceBase; }
            set { parsedPriceBase = value; }
        }
        private Provider parsedProvider;

        public virtual Provider ParsedProvider
        {
            get { return parsedProvider; }
            set { parsedProvider = value; }
        }
        private Frequency? parsedFrequency;

        public virtual Frequency? ParsedFrequency
        {
            get { return parsedFrequency; }
            set { parsedFrequency = value; }
        }
        private ICollection<CategoryBase> parsedCategories = new HashedSet<CategoryBase>();

        public virtual ICollection<CategoryBase> ParsedCategories
        {
            get { return parsedCategories; }
            set { parsedCategories = value; }
        }

        public virtual PriceImport PriceImport
        {
            get { return priceImport; }
            set { priceImport = value; }
        }

        public virtual string CodGrundfos
        {
            get { return codGrundfos; }
            set { codGrundfos = value; }
        }

        public virtual string CodProvider
        {
            get { return codProvider; }
            set { codProvider = value; }
        }

        public virtual string Model
        {
            get { return model; }
            set { model = value; }
        }

        public virtual string Description
        {
            get { return description; }
            set { description = value; }
        }

        public virtual string Frequency
        {
            get { return frequency; }
            set { frequency = value; }
        }

        public virtual decimal? TP
        {
            get { return tP; }
            set { tP = value; }
        }

        public virtual string TPCurrency
        {
            get { return tPCurrency; }
            set { tPCurrency = value; }
        }

        public virtual decimal? GRP
        {
            get { return gRP; }
            set { gRP = value; }
        }

        public virtual string GRPCurrency
        {
            get { return gRPCurrency; }
            set { gRPCurrency = value; }
        }

        public virtual decimal? PL
        {
            get { return pL; }
            set { pL = value; }
        }

        public virtual string PLCurrency
        {
            get { return pLCurrency; }
            set { pLCurrency = value; }
        }

        public virtual string Cat1
        {
            get { return cat1; }
            set { cat1 = value; }
        }

        public virtual string Cat2
        {
            get { return cat2; }
            set { cat2 = value; }
        }

        public virtual string Cat3
        {
            get { return cat3; }
            set { cat3 = value; }
        }

        public virtual string OriginalLine
        {
            get { return originalLine; }
            set { originalLine = value; }
        }

        public virtual string Provider
        {
            get { return provider; }
            set { provider = value; }
        }

        public virtual PriceImportLogStatus Status
        {
            get { return status; }
            set { status = value; }
        }

        public virtual string Detail
        {
            get { return detail; }
            set { detail = value; }
        }

        public virtual int FileIndex
        {
            get { return fileIndex; }
            set { fileIndex = value; }
        }
    }
}
