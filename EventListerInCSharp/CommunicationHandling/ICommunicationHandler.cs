using System.Threading.Tasks;

namespace EventListerInCSharp
{
    public interface ICommunicationHandler
    {
        Task<string> GetContentAsync();
    }
}