using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventListerInCSharp.ArgumentHandling
{
    /// <summary>
    /// Provides default startup arguments
    /// </summary>
    public class DefaultArgumentHandler : IArgumentHandler
    {
        public List<string> FilterCriterias { get; } = new List<string>();
        public string DataSourceAddress { get; } = "https://www.technikum-wien.at/newsroom/veranstaltungen/";
    }
}
