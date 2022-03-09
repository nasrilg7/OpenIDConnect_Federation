using System;

namespace OpenIDConnect.Federation.Models
{
    public class RegistrationStatement
    {
        public RegistrationStatement(string issuer, string subject, string audience, DateTime expirationTimeUtc, Guid tokenIdentifier, string clientName, Uri[] redirectUris)
        {
            Issuer = issuer;
            Subject = subject;
            Audience = audience;
            ExpirationTimeUTC = expirationTimeUtc;
            TokenIdentifier = tokenIdentifier;
            ClientName = clientName;
            RedirectUris = redirectUris;
        }

        public string Issuer { get; }
        public string Subject { get; }
        public string Audience { get; }
        public DateTime ExpirationTimeUTC { get; }
        public Guid TokenIdentifier { get; }
        public string ClientName { get; }
        public Uri[] RedirectUris { get; }
    }
}
