using System;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace OpenIDConnect.Federation.Interfaces
{
    public interface IOpenIdConnectConfigurationMetadataRetriever
    {
        Task<OpenIdConnectConfiguration> GetOpenIdConfiguration(Uri host);
    }
}