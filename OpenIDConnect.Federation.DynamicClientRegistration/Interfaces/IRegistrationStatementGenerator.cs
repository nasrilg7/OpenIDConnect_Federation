using OpenIDConnect.Federation.DynamicClientRegistration.Models;

namespace OpenIDConnect.Federation.DynamicClientRegistration.Interfaces
{
    public interface IRegistrationStatementGenerator
    {
        string GenerateRegistrationStatement(RegistrationStatement model);
    }
}
