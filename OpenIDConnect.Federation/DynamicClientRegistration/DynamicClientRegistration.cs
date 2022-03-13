using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OpenIDConnect.Federation.Interfaces;
using OpenIDConnect.Federation.Models;

namespace OpenIDConnect.Federation.DynamicClientRegistration
{
    public class DynamicClientRegistration : IDynamicClientRegistration
    {
        private readonly HttpClient httpClient;
        private readonly IOpenIdConnectConfigurationMetadataRetriever configurationRetriever;

        public DynamicClientRegistration(HttpClient httpClient, IOpenIdConnectConfigurationMetadataRetriever configurationRetriever)
        {
            this.httpClient = httpClient;
            this.configurationRetriever = configurationRetriever;
        }

      
        public async Task<DynamicClientRegistrationResponse> Register(string registrationStatement, Uri openIdConnectProviderAddress)
        {
            var configuration = await configurationRetriever.GetOpenIdConfiguration(openIdConnectProviderAddress);
            var registrationEndpoint = configuration.RegistrationEndpoint;

            var content = new List<KeyValuePair<string, string>>(
                new []
                {
                    new KeyValuePair<string, string>("software_statement", registrationStatement)
                });
            
            var req = new HttpRequestMessage(HttpMethod.Post, registrationEndpoint)
            {
                Content = new FormUrlEncodedContent(content),
                Headers = { { "Content-Type", "application/x-www-form-urlencoded" } }
            };

            var response = await httpClient.SendAsync(req);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Dynamic Registration failed with status code " + response.StatusCode);
            }

           var responseJson = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<DynamicClientRegistrationResponse>(responseJson);
        }
    }
}