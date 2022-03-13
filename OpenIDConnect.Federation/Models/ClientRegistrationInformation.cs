#nullable enable
namespace OpenIDConnect.Federation.Models
{
    public class ClientRegistrationInformation
    {
        public ClientRegistrationInformation(string name, string clientId, string[] redirectUri, string? description)
        {
            Name = name;
            ClientId = clientId;
            RedirectUri = redirectUri;
            Description = description;
        }

        public string Name { get; }
        public string ClientId { get; }
        public string[] RedirectUri { get; }
        public string? Description { get; }

    }
}
