using System;
using System.Security.Cryptography.X509Certificates;
using JWT;
using JWT.Algorithms;
using JWT.Builder;
using JWT.Exceptions;
using JWT.Serializers;
using Newtonsoft.Json;
using OpenIDConnect.Federation.Models;
using IJwtValidator = OpenIDConnect.Federation.Interfaces.IJwtValidator;

namespace OpenIDConnect.Federation.Provider.ClientRegistrationValidation
{
    public class AuthenticationStatementValidator : IJwtValidator
    {
        public JwtValidationResult ValidateJwt(string authenticationToken)
        {
            try
            {
                var decoder = new JwtDecoder(new JsonNetSerializer(), new JwtBase64UrlEncoder());

                JwtHeader header = decoder.DecodeHeader<JwtHeader>(authenticationToken);

                var headerCertificate = new X509Certificate2(Convert.FromBase64String(header.X5c[0]));

                var json = new JwtBuilder()
                    .WithAlgorithm(new RS256Algorithm(headerCertificate))
                    .MustVerifySignature()
                    .Decode(authenticationToken);

                return new JwtValidationResult.Success<AuthenticationTokenModel>(SerializeAuthenticationToken(json));
            }
            catch (SignatureVerificationException e)
            {
                return new JwtValidationResult.Fail(isSignatureValid: false);
            }
            catch (Exception e)
            {
                return new JwtValidationResult.Fail(isValid: false, failReason: e.Message);
            }
        }

        private AuthenticationTokenModel SerializeAuthenticationToken(string json)
        {
            dynamic @object = JsonConvert.DeserializeObject(json);

            return new AuthenticationTokenModel(
                (string)@object.iss.ToObject<string>(),
                (string)@object.sub.ToObject<string>(),
                (string)@object.aud.ToObject<string>(),
                (string)@object.exp.ToObject<string>(),
                (string)@object.iat.ToObject<string>(),
                (string)@object.jti.ToObject<string>());
        }
    }
}