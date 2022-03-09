using System;

namespace OpenIDConnect.Federation.Models
{
    public class AuthenticationStatement
    {
        public AuthenticationStatement(string issuer, string subject, string audience, DateTime expirationTimeUtc, Guid tokenIdentifier)
        {
            Issuer = issuer;
            Subject = subject;
            Audience = audience;
            ExpirationTimeUTC = expirationTimeUtc;
            TokenIdentifier = tokenIdentifier;
        }

        public string Issuer { get; }
        public string Subject { get; }
        public string Audience { get; }
        public DateTime ExpirationTimeUTC { get; }
        public Guid TokenIdentifier { get; }

    }
}