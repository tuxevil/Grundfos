using System;
using System.Collections.Generic;
using System.Text;

namespace PriceManager.Core
{
    public class PriceImport
    {
        private ImportStatus importStatus;
        private string file;
        private DateTime dateImported;
        private string logResult;

        public ImportStatus ImportStatus
        {
            get { return importStatus; }
            set { importStatus = value; }
        }

        public string File
        {
            get { return file; }
            set { file = value; }
        }

        public DateTime DateImported
        {
            get { return dateImported; }
            set { dateImported = value; }
        }

        public string LogResult
        {
            get { return logResult; }
            set { logResult = value; }
        }
    }
}
