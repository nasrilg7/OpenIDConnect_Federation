using OpenIDConnect.Federation.Models;

namespace OpenIDConnect.Federation.Interfaces
{
    public interface IEmailIdentifierNormalizer
    {
        NormalizedIdentifier NormalizeIdentifier(string email);
    }
}