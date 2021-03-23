using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventListerInCSharp.FilterHandling;
using Microsoft.Extensions.DependencyInjection;

namespace EventListerInCSharp
{
    public class IoCContainerConfig
    {
        private readonly ServiceProvider _serviceProvider;

        public IoCContainerConfig()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IArgumentHandler, CommandLineArgumentHandler>();
            services.AddSingleton<ICommunicationHandler, NetworkCommunicationHandler>();
            services.AddSingleton<IContentInterpreter, HTTPOutputInterpreter>();
            services.AddSingleton<IFilterHandler, CsvBasedFilter>();
            
            services.AddSingleton<MainViewModel>();

            _serviceProvider = services.BuildServiceProvider();
        }

        public MainViewModel MainViewModel
            => _serviceProvider.GetService<MainViewModel>();
    }
}
