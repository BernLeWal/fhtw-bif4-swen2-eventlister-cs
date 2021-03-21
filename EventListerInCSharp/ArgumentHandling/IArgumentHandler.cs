using System.Collections.Generic;

namespace EventListerInCSharp
{
    public interface IArgumentHandler
    {
        List<string> FilterCriterias { get; }
        string DataSourceAddress { get; }
    }
}