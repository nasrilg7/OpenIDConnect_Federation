using System.Threading.Tasks;
using OpenIDConnect.Federation.Models;

namespace OpenIDConnect.Federation.Interfaces
{
    public interface IWebFingerIssuerRequester
    {
        Task<IssuerResponse> RequestIssuer(string email);
    }
}