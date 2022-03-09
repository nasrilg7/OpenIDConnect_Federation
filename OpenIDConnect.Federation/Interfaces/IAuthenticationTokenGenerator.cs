using System.Security.Cryptography.X509Certificates;
using OpenIDConnect.Federation.Models;

namespace OpenIDConnect.Federation.Interfaces
{
    public interface IAuthenticationTokenGenerator
    {
        string GenerateAuthenticationStatement(AuthenticationStatement model, X509Certificate2 signingCertificate);
    }
}