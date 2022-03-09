using System.Security.Cryptography.X509Certificates;
using OpenIDConnect.Federation.Models;

namespace OpenIDConnect.Federation.Interfaces
{
    public interface IRegistrationStatementGenerator
    {
        string GenerateRegistrationStatement(RegistrationStatement model, X509Certificate2 signingCertificate);
    }
}
