using System.Threading.Tasks;
using OpenIDConnect.Federation.Models;

namespace OpenIDConnect.Federation.Interfaces
{
    public interface IJwtValidator
    {
        JwtValidationResult ValidateJwt(string jwt);
    }
}