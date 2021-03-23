using System.Collections.Generic;

namespace EventListerInCSharp
{
    /// <summary>
    /// Interprets/parses a content string into a list of content elements
    /// </summary>
    public interface IContentInterpreter
    {
        IEnumerable<string> Interpret(string content);
    }
}