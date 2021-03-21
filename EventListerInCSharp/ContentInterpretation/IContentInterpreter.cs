using System.Collections.Generic;

namespace EventListerInCSharp
{
    public interface IContentInterpreter
    {
        List<string> Interpret(string content);
    }
}