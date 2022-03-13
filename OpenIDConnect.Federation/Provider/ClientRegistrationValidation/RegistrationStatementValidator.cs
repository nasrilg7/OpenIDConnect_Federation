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
    public class RegistrationStatementValidator : IJwtValidator
    {
        public JwtValidationResult ValidateJwt(string registrationStatement)
        {
            try
            {
                var decoder = new JwtDecoder(new JsonNetSerializer(), new JwtBase64UrlEncoder());

                JwtHeader header = decoder.DecodeHeader<JwtHeader>(registrationStatement);

                var headerCertificate = new X509Certificate2(Convert.FromBase64String(header.X5c[0]));

                var json = new JwtBuilder()
                    .WithAlgorithm(new RS256Algorithm(headerCertificate))
                    .MustVerifySignature()
                    .Decode(registrationStatement);

                return new JwtValidationResult.Success<ClientRegistrationInformation>(SerializeSoftwareStatement(json));
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

        private ClientRegistrationInformation SerializeSoftwareStatement(string json)
        {
            dynamic @object = JsonConvert.DeserializeObject(json);

            return new ClientRegistrationInformation(
                (string)@object.client_name.ToObject<string>(),
                (string)@object.iss.ToObject<string>(),
                (string[])@object.redirect_uris.ToObject<string[]>(),
                null);
        }
    }
}
