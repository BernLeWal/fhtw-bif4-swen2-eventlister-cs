using System.Collections.Generic;

namespace EventListerInCSharp
{
    /// <summary>
    /// Provides startup arguments
    /// </summary>
    public interface IArgumentHandler
    {
        List<string> FilterCriterias { get; }
        string DataSourceAddress { get; }
    }
}