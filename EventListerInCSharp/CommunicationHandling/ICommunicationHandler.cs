using System.Threading.Tasks;

namespace EventListerInCSharp
{
    /// <summary>
    /// Fetches the content data via an asynchronous call
    /// </summary>
    public interface ICommunicationHandler
    {
        Task<string> GetContentAsync();
    }
}