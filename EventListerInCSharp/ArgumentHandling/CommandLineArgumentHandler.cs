using System;
using System.Collections.Generic;
using System.Linq;
using EventListerInCSharp.ArgumentHandling;

namespace EventListerInCSharp
{
    /// <summary>
    /// Parses the command line arguments for additional filter criteria
    /// </summary>
    public class CommandLineArgumentHandler : DefaultArgumentHandler
    {
        /// <summary>
        /// In our case, the CommandLineArgumentHandler is instantiated via the service provider.
        /// </summary>
        public CommandLineArgumentHandler()
        {
            // add all commandline arguments (except for the app name) as filter criteria
            // (in addition to those from the DefaultArgumentHandler)
            this.FilterCriterias.AddRange(Environment.GetCommandLineArgs().Skip(1));
        }
    }
}
