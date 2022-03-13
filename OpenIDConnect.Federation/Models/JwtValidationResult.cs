#nullable enable
namespace OpenIDConnect.Federation.Models
{
    public abstract class JwtValidationResult
    {
        public sealed class Fail : JwtValidationResult
        {
            public Fail(bool isSignatureValid = true, bool isUdap = true, bool isValid = true, string? failReason = default)
            {
                IsSignatureValid = isSignatureValid;
                IsUdap = isUdap;
                IsValid = isValid;
                FailReason = failReason;
            }

            public bool IsSignatureValid { get; }
            public bool IsUdap { get; }
            public bool IsValid { get; }
            public string? FailReason { get; set; }
        }
        public sealed class Success<TModel> : JwtValidationResult
        {
            public Success(TModel model)
            {
                Model = model;
            }

            public TModel Model { get; }
        }
    }
}