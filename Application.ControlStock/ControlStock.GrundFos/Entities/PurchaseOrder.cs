using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;

namespace Grundfos.ScalaConnector
{
    public class PurchaseOrder
    {
        private string id;
        private DateTime date;

        public virtual int Month
        {
            get { return Date.Month; }
        }

        public virtual int Week
        {
            get { return Thread.CurrentThread.CurrentCulture.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday); }
        }

        public virtual int DateYear
        {
            get { return Date.Year; }
        }

        public virtual string Id
        {
            get { return id; }
            set { id = value; }
        }

        public virtual DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
    }
}
