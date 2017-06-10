using System;
using System.Collections.Generic;
using System.Text;

namespace PriceManager.Core
{
    public class PageTreeView
    {
        private int id;
        private string name;
        private int parentId;
        private int? count;
        private int level;

        public virtual int Id
        {
            get { return id; }
            set { id = value; }
        }

        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }

        public virtual string NameAsHtml
        {
            get { return name.Replace(' ', (char)160); }
        }

        public virtual int ParentId
        {
            get { return parentId; }
            set { parentId = value; }
        }

        public virtual int? Count
        {
            get { return count; }
            set { count = value; }
        }

        public virtual int Level
        {
            get { return level; }
            set { level = value; }
        }

        public PageTreeView() { }

        public PageTreeView (int id, int parentId, string name, int totalCount, int level)
        {
            this.id = id;
            this.parentId = parentId;
            this.name = name;
            this.count = totalCount;
            this.level = level;
        }

        public PageTreeView(int id, int parentId, string name, int level)
        {
            this.id = id;
            this.parentId = parentId;
            this.name = name;
            this.count = 0;
            this.level = level;
        }
    }
}
