using OpenIDConnect.Federation.DynamicClientRegistration.Models;

namespace OpenIDConnect.Federation.DynamicClientRegistration.Interfaces
{
    public interface IAuthenticationTokenGenerator
    {
        string GenerateAuthenticationStatement(AuthenticationStatement model);
    }
}