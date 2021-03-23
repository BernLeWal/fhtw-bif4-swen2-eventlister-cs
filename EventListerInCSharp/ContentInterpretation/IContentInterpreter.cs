using System.Collections.Generic;

namespace EventListerInCSharp
{
    public interface IContentInterpreter
    {
        IEnumerable<string> Interpret(string content);
    }
}