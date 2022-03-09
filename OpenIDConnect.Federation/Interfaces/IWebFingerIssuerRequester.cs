using System.Threading.Tasks;
using OpenIDConnect.Federation.DynamicDiscovery.Models;

namespace OpenIDConnect.Federation.DynamicDiscovery.Interfaces
{
    public interface IWebFingerIssuerRequester
    {
        Task<IssuerResponse> RequestIssuer(string email);
    }
}