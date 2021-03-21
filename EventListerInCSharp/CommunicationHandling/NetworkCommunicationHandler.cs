using System.Net.Http;
using System.Threading.Tasks;

namespace EventListerInCSharp
{
    public class NetworkCommunicationHandler : ICommunicationHandler
    {
        private string _requestUri;
        private string _cachedContent = null;

        public NetworkCommunicationHandler(IArgumentHandler argumentHandler)
        {
            _requestUri = argumentHandler.DataSourceAddress;
        }

        public async Task<string> GetContentAsync()
        {
            if (_cachedContent != null)
            {
                return await Task.FromResult(_cachedContent);
            }

            using var client = new HttpClient();
            var response = await client.GetAsync(_requestUri);
            var pageContent = await response.Content.ReadAsStringAsync();
            return pageContent;
        }
    }
}
