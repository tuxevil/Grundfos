using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PriceManager.Business
{
    #region GridHelper Class

    [Serializable]
    public class GridHelper
    {
        #region Private Properties

        private const int CONST_PAGE_SIZE = 20;

        private string sortField ="";
        private bool sortAscending;
        private int currentPageSize = CONST_PAGE_SIZE;
        private int currentPageNumber = 1;
        private readonly int[] pageSizesAvailables = { 10, 20, 50, 100 };
        private bool allSelected;
        private List<int> itemsSelected = new List<int>();
        private int totalRecords;
        private DateTime searchDate;
        private int? showInCurrency;

        #endregion

        #region Public Properties

        public int PageSize
        {
            get { return currentPageSize; }
            set
            {
                //TODO: Avoid loop
                bool found = false;
                foreach(int val in pageSizesAvailables)
                    if (value == val)
                        found = true;

                //TODO: Create custom exception
                if (!found)
                    throw new Exception("PageSize is out of range.");

                currentPageSize = value;
                isDirty = true;
            }
        }

        public int PageNumber
        {
            get { return currentPageNumber; }
            set
            {
                currentPageNumber = value;
                isDirty = true;
            }
        }

        public string SortField
        {
            get { return sortField; }
            set
            {
                sortField = value;
                isDirty = true;
            }
        }

        public int? ShowInCurrency
        {
            get { return showInCurrency; }
            set
            {
                showInCurrency = value;
                isDirty = true;
            }
        }

        public bool SortAscending
        {
            get { return sortAscending; }
            set
            {
                sortAscending = value;
                isDirty = true;
            }
        }

        public int[] PageSizesAvailables
        {
            get { return pageSizesAvailables; }
        }

        public int TotalRecords
        {
            get { return totalRecords; }
            set { totalRecords = value; }
        }

        /// <summary>
        /// Returns the amount of items selected
        /// </summary>
        public int MarkedCount
        {
            get
            {
                return (allSelected) ? this.totalRecords - this.itemsSelected.Count : this.itemsSelected.Count;
            }
        }

        #endregion

        #region Mark Methods

        public bool IsMarkedAll()
        {
            return allSelected;
        }

        public bool IsAnyItemMarked()
        {
            return allSelected || this.itemsSelected.Count > 0;
        }

        public bool IsMarked(int id)
        {
            bool exists = itemsSelected.Contains(id);
            return (exists && !this.allSelected) || (!exists && this.allSelected);
        }

        /// <summary>
        /// Mark all items
        /// </summary>
        public void MarkAllItems()
        {
            itemsSelected.Clear();
            allSelected = true;
            DoChanged();
        }

        /// <summary>
        /// Unmark all items
        /// </summary>
        public void UnMarkAllItems()
        {
            itemsSelected.Clear();
            allSelected = false;
            DoChanged();
        }

        /// <summary>
        /// Unmark only one item
        /// </summary>
        /// <param name="id"></param>
        public void UnMarkItem(int id)
        {
            UnMarkItems(id);
        }

        /// <summary>
        /// Mark only one item
        /// </summary>
        /// <param name="id"></param>
        public void MarkItem(int id)
        {
            MarkItems(id);
        }

        /// <summary>
        /// Mark several items
        /// </summary>
        /// <param name="ids"></param>
        public void MarkItems(params int[] ids)
        {
            MarkOrUnMarkItems(ids, false);
        }

        /// <summary>
        /// Mark several items
        /// </summary>
        /// <param name="ids"></param>
        public void UnMarkItems(params int[] ids)
        {
            MarkOrUnMarkItems(ids, true);
        }

        private void MarkOrUnMarkItems(int[] ids, bool unmark)
        {
            if ((!allSelected && unmark) || (allSelected && !unmark))
            {
                bool hasChanged = false;
                foreach (int id in ids)
                {
                    if (itemsSelected.Contains(id))
                    {
                        itemsSelected.Remove(id);
                        hasChanged = true;
                    }
                }

                if (hasChanged)
                    DoChanged();
            }
            else
            {
                bool hasChanged = false;
                foreach (int id in ids)
                {
                    if (!itemsSelected.Contains(id))
                    {
                        itemsSelected.Add(id);
                        hasChanged = true;
                    }
                }

                if (hasChanged)
                    DoChanged();
            }
        }

        #endregion

        #region Date Manager 
        public void SetSearchDate(DateTime searchDate)
        {
            this.searchDate = searchDate;
            isDirty = true;
        }
        #endregion

        #region State Manager

        [NonSerialized]
        private GridState state = null;
        private bool isDirty = false;

        /// <summary>
        /// Returns the current state to be able to use in the rest of the Business Logic
        /// </summary>
        /// <returns>Grid State object</returns>
        public GridState State
        {
            get
            {
                if (isDirty || state == null)
                {
                    state = new GridState(itemsSelected, currentPageSize, currentPageNumber, sortField, sortAscending, allSelected, searchDate, showInCurrency);
                    isDirty = false;
                }

                return state;
            }
        }

        #endregion

        #region OnFilter Event Methods

        [NonSerialized]
        private GridHelperChangedEventHandler changed;

        /// <summary>
        /// Indicates the state of the Grid was changed
        /// </summary>
        public event GridHelperChangedEventHandler Changed
        {
            add { changed += value;  }
            remove { changed -= value; } 
        }

        private void DoChanged()
        {
            isDirty = true;
            OnChanged(new EventArgs());
        }

        private void OnChanged(EventArgs e)
        {
            if (changed != null)
                changed(this, e);
        }

        #endregion

        public void RecreateFromJavascript(string[] ids, bool isMarkedAll)
        {
            allSelected = isMarkedAll;

            itemsSelected.Clear();
            foreach(string id in ids)
                if (id != string.Empty)
                    itemsSelected.Add(Convert.ToInt32(id));
        }
    }

    #endregion

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

    #region GridHelper Event Definition

    public delegate void GridHelperChangedEventHandler(object sender, EventArgs sp);

    #endregion
}
