using System;
using System.Collections.Generic;
using System.Text;
using PriceManager.Common;

namespace PriceManager.Core
{
    public class PriceImportLogView
    {
        private string codGrundfos;
        private string codProvider;
        private string model;
        private string description;
        private string provider;
        private string frequency;
        private string tP;
        private string gRP;
        private string pL;
        private string cat1;
        private string cat2;
        private string cat3;
        private string detail;

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

        public virtual string Provider
        {
            get { return provider; }
            set { provider = value; }
        }

        public virtual string Frequency
        {
            get { return frequency; }
            set { frequency = value; }
        }

        public virtual string TP
        {
            get { return tP; }
            set { tP = value; }
        }

        public virtual string GRp
        {
            get { return gRP; }
            set { gRP = value; }
        }

        public virtual string PL
        {
            get { return pL; }
            set { pL = value; }
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

        public virtual string Detail
        {
            get { return detail; }
            set { detail = value; }
        }

        public PriceImportLogView() {}

        public PriceImportLogView(PriceImportLog priceImportLog)
        {
            this.codGrundfos = priceImportLog.CodGrundfos;
            this.codProvider = priceImportLog.CodProvider;
            this.model = priceImportLog.Model;
            this.description = priceImportLog.Description;
            this.provider = priceImportLog.Provider;
            if(priceImportLog.TP != null)
                this.tP = priceImportLog.TPCurrency + Convert.ToDecimal(priceImportLog.TP).ToString("#,##0.00");
            if (priceImportLog.GRP != null)
                this.gRP = priceImportLog.GRPCurrency + Convert.ToDecimal(priceImportLog.GRP).ToString("#,##0.00");
            if (priceImportLog.PL != null)
                this.pL = priceImportLog.PLCurrency + Convert.ToDecimal(priceImportLog.PL).ToString("#,##0.00");
            this.cat1 = priceImportLog.Cat1;
            this.cat2 = priceImportLog.Cat2;
            this.cat3 = priceImportLog.Cat3;
            this.detail = priceImportLog.Detail;
            this.frequency = priceImportLog.Frequency;
        }
    }

}
