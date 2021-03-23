using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventListerInCSharp.FilterHandling
{
    /// <summary>
    /// Filters a list of strings according to a comma-separated list of filter criteria and returns a new list.
    /// </summary>
    public class CsvBasedFilter : IFilterHandler
    {
        public string GetFilterStringFromFilterItems(IEnumerable<string> filterItems)
        {
            return string.Join(", ", filterItems);
        }

        public IEnumerable<string> GetFilterItemsFromFromFilterString(string filter)
        {
            // fetch the individual, comma-separated filter terms
            return filter.Split(",").Select(x => x.Trim()).ToList();

        }

        public IEnumerable<string> Filter(IEnumerable<string> content, string filter)
        {
            var filterItems = GetFilterItemsFromFromFilterString(filter);
            
            // only keep those content items, which contain all filter terms
            // equivalent to:
            //    content.Where(x => filterItems.All(x.Contains));
            return content.Where(x =>
            {
                foreach (var filterItem in filterItems)
                {
                    if (!x.Contains(filterItem))
                    {
                        return false;
                    }
                }

                return true;
            });
        }
    }
}
