using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventListerInCSharp.FilterHandling
{
    public class CsvBasedFilter : IFilterHandler
    {
        public IEnumerable<string> Filter(IEnumerable<string> content, string filter)
        {
            var filterItems = filter.Split(",").Select(x => x.Trim());
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
