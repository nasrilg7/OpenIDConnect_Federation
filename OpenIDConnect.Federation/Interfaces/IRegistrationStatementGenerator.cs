using System.Security.Cryptography.X509Certificates;
using OpenIDConnect.Federation.DynamicClientRegistration.Models;

namespace OpenIDConnect.Federation.DynamicClientRegistration.Interfaces
{
    public interface IRegistrationStatementGenerator
    {
        string GenerateRegistrationStatement(RegistrationStatement model, X509Certificate2 signingCertificate);
    }
}
