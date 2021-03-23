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
        public IEnumerable<string> Filter(IEnumerable<string> content, string filter)
        {
            // fetch the individual, comma-separated filter terms
            var filterItems = filter.Split(",").Select(x => x.Trim()).ToList();
            
            // only keep those content items, which contain all filter terms
            // equivalent to:
            // content.Where(x => filterItems.All(x.Contains));
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
