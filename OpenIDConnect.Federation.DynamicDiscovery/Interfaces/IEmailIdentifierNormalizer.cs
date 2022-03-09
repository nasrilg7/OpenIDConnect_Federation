using OpenIDConnect.Federation.DynamicDiscovery.Models;

namespace OpenIDConnect.Federation.DynamicDiscovery.Interfaces
{
    public interface IEmailIdentifierNormalizer
    {
        NormalizedIdentifier NormalizeIdentifier(string email);
    }
}