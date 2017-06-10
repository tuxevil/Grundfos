using System;
using System.Collections.Generic;
using System.Text;

namespace PriceManager.Business.Filters
{
    public interface IFilter
    {
        string ID { get; } 
        Type ClassName { get; }
        string PropertyName { get; }
        string FilterName { get; }
        object Values { get; set; }
        object TextValue { get; }
        bool HasValue { get; }
        bool IsStructure { get; }
        void Clear();
        void Refresh();
    }
}
