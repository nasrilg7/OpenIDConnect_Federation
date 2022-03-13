namespace OpenIDConnect.Federation.Models
{
    public class AuthenticationTokenModel
    {
        public AuthenticationTokenModel(string issuer, string subject, string audience, string expirationTime, string issuingTime, string tokenIdentifier)
        {
            Issuer = issuer;
            Subject = subject;
            Audience = audience;
            ExpirationTime = expirationTime;
            IssuingTime = issuingTime;
            TokenIdentifier = tokenIdentifier;
        }

        public string Issuer { get; }
        public string Subject { get; }
        public string Audience { get; }
        public string ExpirationTime { get; }
        public string IssuingTime { get; }
        public string TokenIdentifier { get; }
    }
}