using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventListerInCSharp.FilterHandling
{
    /// <summary>
    /// Filters a list of strings according to a provided filter string and returns a new list.
    /// </summary>
    public interface IFilterHandler
    {
        IEnumerable<string> Filter(IEnumerable<string> content, string filter);

        IEnumerable<string> GetFilterItemsFromFromFilterString(string filter);
        string GetFilterStringFromFilterItems(IEnumerable<string> filterItems);

    }
}
