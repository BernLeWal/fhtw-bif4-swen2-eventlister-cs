using System;
using System.Collections.Generic;
using System.Linq;
using EventListerInCSharp.ArgumentHandling;

namespace EventListerInCSharp
{
    public class CommandLineArgumentHandler : DefaultArgumentHandler
    {
        public CommandLineArgumentHandler()
        {
            this.FilterCriterias.AddRange(Environment.GetCommandLineArgs().Skip(1));
        }
    }
}
