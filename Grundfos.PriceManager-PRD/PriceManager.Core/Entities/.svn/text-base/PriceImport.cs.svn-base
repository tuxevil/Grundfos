using System;
using System.Collections.Generic;
using System.Text;
using ProjectBase.Data;
using Iesi.Collections.Generic;

namespace PriceManager.Core
{
    [Serializable]
    public class PriceImport : BaseAuditableEntity<Guid>
    {
        public PriceImport()
        {
        }

        public PriceImport(Guid id) { this.id = id; }

        private ImportStatus importStatus;
        private string file;
        private string description;
        private DateTime dateImported;
        private ICollection<PriceImportLog> logResults = new HashedSet<PriceImportLog>();
        private int number;
        private bool haveHeader;
        private char separationChar;
        private PriceImportView priceImportView;

        public virtual int Number
        {
            get { return number; }
            set { number = value; }
        }

        public virtual ImportStatus ImportStatus
        {
            get { return importStatus; }
            set { importStatus = value; }
        }

        public virtual string File
        {
            get { return file; }
            set { file = value; }
        }

        public virtual DateTime DateImported
        {
            get { return dateImported; }
            set { dateImported = value; }
        }

        public virtual ICollection<PriceImportLog> LogResults
        {
            get { return logResults; }
            set { logResults = value; }
        }

        public virtual string Description
        {
            get { return description; }
            set { description = value; }
        }

        public virtual bool HaveHeader
        {
            get { return haveHeader; }
            set { haveHeader = value; }
        }

        public virtual char SeparationChar
        {
            get { return separationChar; }
            set { separationChar = value; }
        }

        public virtual PriceImportView ImportView
        {
            get { return priceImportView; }
            set { priceImportView = value; }
        }
    }
}
