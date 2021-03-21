using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventListerInCSharp.FilterHandling
{
    public interface IFilterHandler
    {
        IEnumerable<string> Filter(IEnumerable<string> content, string filter);
    }
}
