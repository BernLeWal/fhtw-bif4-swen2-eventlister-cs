using System.Net.Http;
using System.Threading.Tasks;

namespace EventListerInCSharp
{
    public class NetworkCommunicationHandler : ICommunicationHandler
    {
        /// <summary>
        /// This is a dependency on the argument handler
        /// </summary>
        private readonly IArgumentHandler _argumentHandler;
        
        private string _requestUri;
        private string _cachedContent = null;

        /// <summary>
        /// In our case, the CommandLineArgumentHandler is instantiated via the service provider, which also provides
        /// the argument handler parameter according to the configuration in IoCContainerConfig.cs 
        /// </summary>
        /// <param name="argumentHandler">The argument handler which stores the URI of the data source.</param>
        public NetworkCommunicationHandler(IArgumentHandler argumentHandler)
        {
            _argumentHandler = argumentHandler;
            _requestUri = argumentHandler.DataSourceAddress;
        }

        public async Task<string> GetContentAsync()
        {
            // TODO: consider memory cache based on an amount of time to cache
            // https://docs.microsoft.com/de-de/dotnet/api/system.runtime.caching.memorycache?view=dotnet-plat-ext-5.0&viewFallbackFrom=net-5.0
            if (_cachedContent != null)
            {
                // we have a cached result, no need for fetching it again
                // just wrap the result into a task and return it
                return await Task.FromResult(_cachedContent);
            }

            using var client = new HttpClient();
            var response = await client.GetAsync(_requestUri);
            var pageContent = await response.Content.ReadAsStringAsync();
            
            // cache the result for following requests and return it
            return _cachedContent = pageContent;
        }
    }
}
