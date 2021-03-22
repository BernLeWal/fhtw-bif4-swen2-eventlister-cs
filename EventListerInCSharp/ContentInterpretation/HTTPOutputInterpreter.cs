using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace EventListerInCSharp
{
    public class HTTPOutputInterpreter : IContentInterpreter
    {
        private List<string> cachedOutput = null;

        public virtual List<string> Interpret(string content)
        {
            if (cachedOutput != null)
            {
                return cachedOutput;
            }

            List<string> entries = new List<string>();

            var regex = new Regex(
                "<div\\ class=\"views-row.*?<div.*?class=\"title\".*?<a\\ href.*?\">\\W*(.*?)\\W*<\\/a>.*?<a class=\"more-link\".*?<\\/div>", 
                RegexOptions.Singleline);

            var matches = regex.Matches(content);
            foreach (Match match in matches)
            {
                var entry = match.Groups[1].Value;
                entries.Add(entry);
            }

            return cachedOutput = entries;
        }
    }
}
