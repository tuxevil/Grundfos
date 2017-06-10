using System;
using System.Collections.Generic;
using System.Text;
using ProjectBase.Data;

namespace PriceManager.Core
{
    [Serializable]
    public class Log : Entity<int>
    {
        private string processName;
        private ExecutionStatus executionStatus;
        private string observations;
        private DateTime creationDate;

        [DomainSignature]
        public virtual string ProcessName
        {
            get { return processName; }
            set { processName = value; }
        }

        public virtual ExecutionStatus ExecutionStatus
        {
            get { return executionStatus; }
            set { executionStatus = value; }
        }

        public virtual string Observations
        {
            get { return observations; }
            set { observations = value; }
        }

        [DomainSignature]
        public virtual DateTime CreationDate
        {
            get { return creationDate; }
            set { creationDate = value; }
        }
    }
}
