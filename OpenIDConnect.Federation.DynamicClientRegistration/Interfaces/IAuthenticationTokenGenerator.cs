using System.Security.Cryptography.X509Certificates;
using OpenIDConnect.Federation.DynamicClientRegistration.Models;

namespace OpenIDConnect.Federation.DynamicClientRegistration.Interfaces
{
    public interface IAuthenticationTokenGenerator
    {
        string GenerateAuthenticationStatement(AuthenticationStatement model, X509Certificate2 signingCertificate);
    }
}