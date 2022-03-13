using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using OpenIDConnect.Federation.Interfaces;

namespace OpenIDConnect.Federation.DynamicClientRegistration
{
    public class OpenIdConnectConfigurationMetadataRetriever : IOpenIdConnectConfigurationMetadataRetriever
    {
        public async Task<OpenIdConnectConfiguration> GetOpenIdConfiguration(Uri host)
        {
            var openIdConfigurationEndpoint = $"{host}/.well-known/openid-configuration";

            var configurationManager =
                new ConfigurationManager<OpenIdConnectConfiguration>(
                    openIdConfigurationEndpoint,
                    new OpenIdConnectConfigurationRetriever());

            return await configurationManager.GetConfigurationAsync(CancellationToken.None);
        }
    }
}