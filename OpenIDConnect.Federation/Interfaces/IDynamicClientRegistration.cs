using System;
using System.Threading.Tasks;
using OpenIDConnect.Federation.Models;

namespace OpenIDConnect.Federation.Interfaces
{
    public interface IDynamicClientRegistration
    {
        Task<DynamicClientRegistrationResponse> Register(string registrationStatement, Uri openIdConnectProviderAddress);
    }
}