using System;
using System.Collections.Generic;
using System.Text;

namespace PriceManager.Core.State
{
    #region GridState Intermediate Class

    [Serializable]
    public class GridState
    {
        public GridState(List<int> items, int pageSize, int pageNumber, string sortField, bool sortAscending, bool markedAll, DateTime searchDate, int? showInCurrency)
        {
            this.itemsSelected = items;
            this.currentPageSize = pageSize;
            this.currentPageNumber = pageNumber;
            this.sortField = sortField;
            this.sortAscending = sortAscending;
            this.allSelected = markedAll;
            this.searchDate = searchDate;
            this.showInCurrency = showInCurrency;
        }

        #region Private Properties

        private string sortField;
        private bool sortAscending;
        private int currentPageSize = 10;
        private int currentPageNumber = 1;
        private bool allSelected;
        private List<int> itemsSelected = new List<int>();
        private DateTime searchDate;
        private int? showInCurrency;
        #endregion

        #region Public Properties

        public List<int> Items
        {
            get { return itemsSelected; }
        }

        public int PageSize
        {
            get { return currentPageSize; }
        }

        public int PageNumber
        {
            get { return currentPageNumber; }
        }

        public string SortField
        {
            get { return sortField; }
        }

        public bool SortAscending
        {
            get { return sortAscending; }
        }

        public int? ShowInCurrency
        {
            get { return showInCurrency; }
        }

        public bool MarkedAll
        {
            get { return allSelected; }
        }

        public DateTime SearchDate
        {
            get { return searchDate; }
        }

        public bool IsAnyItemMarked
        {
            get { return allSelected || this.itemsSelected.Count > 0; }
        }

        #endregion

    }

    #endregion
}
