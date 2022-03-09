using System;
using System.Security.Cryptography.X509Certificates;
using JWT.Algorithms;
using JWT.Builder;
using OpenIDConnect.Federation.Interfaces;
using OpenIDConnect.Federation.Models;

namespace OpenIDConnect.Federation.DynamicClientRegistration
{
    public class AuthenticationTokenGenerator : IAuthenticationTokenGenerator
    {
        public string GenerateAuthenticationStatement(AuthenticationStatement model, X509Certificate2 signingCertificate)
        {
            var jwtBuilder = new JwtBuilder();

            //Generate the Signed Encoded JWT
            var authenticationToken = jwtBuilder
                .WithAlgorithm(new RS256Algorithm(signingCertificate))
                .AddHeader(HeaderName.X5c, new[] { Convert.ToBase64String(signingCertificate.RawData) })
                .AddClaim("iss", model.Issuer) //Client App Operator’s unique identifying URI (identifying the holder of private key, also serves as the base URI for UDAP metadata including lookup of certificates)
                .AddClaim("sub", model.Subject) //same as iss
                .AddClaim("aud", model.Audience) //string, the Authorization Server’s registration endpoint URL
                .AddClaim("exp", ConvertToUnixTimestamp(model.ExpirationTimeUTC)) //number, expiration time (should be short-lived, max 5 minutes from iat)
                .AddClaim("iat", ConvertToUnixTimestamp(DateTime.UtcNow)) //number, issued at time
                .AddClaim("jti", model.TokenIdentifier) //string, unique token identifier used to identify token replay
                .Encode();

            return authenticationToken;
        }

        private double ConvertToUnixTimestamp(DateTime date)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan diff = date.ToUniversalTime() - origin;
            return Math.Floor(diff.TotalSeconds);
        }
    }
}