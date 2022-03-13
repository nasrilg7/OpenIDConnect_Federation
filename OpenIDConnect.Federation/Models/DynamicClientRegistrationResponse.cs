using Newtonsoft.Json;

namespace OpenIDConnect.Federation.Models
{
    public class DynamicClientRegistrationResponse
    {
        [JsonProperty("clientId")]
        public string ClientId { get; }

        public DynamicClientRegistrationResponse(
            string clientId, string softwareStatement,
            string clientName, string[] redirectUris,
            string[] grantTypes, string[] responseTypes,
            string tokenEndpointAuthMode)
        {
            ClientId = clientId;
            SoftwareStatement = softwareStatement;
            ClientName = clientName;
            RedirectUris = redirectUris;
            GrantTypes = grantTypes;
            ResponseTypes = responseTypes;
            TokenEndpointAuthMode = tokenEndpointAuthMode;
        }

        [JsonProperty("softwareStatement")]
        public string SoftwareStatement { get; }

        [JsonProperty("clientName")]
        public string ClientName { get; }

        [JsonProperty("redirectUris")]
        public string[] RedirectUris { get; }

        [JsonProperty("grantTypes")]
        public string[] GrantTypes { get; }

        [JsonProperty("responseTypes")]
        public string[] ResponseTypes { get; }

        [JsonProperty("tokenEndpointAuthMode")]
        public string TokenEndpointAuthMode { get; }
    }
}