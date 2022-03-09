using System;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Web;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;
using OpenIDConnect.Federation.DynamicDiscovery.Interfaces;
using OpenIDConnect.Federation.DynamicDiscovery.Models;

namespace OpenIDConnect.Federation.DynamicDiscovery
{
    public class WebFingerIssuerRequester : IWebFingerIssuerRequester
    {
        private const string WebFingerUrl = "/.well-known/webfinger";

        private readonly HttpClient httpClient;
        private readonly IEmailIdentifierNormalizer emailIdentifierNormalizer;

        public WebFingerIssuerRequester(IEmailIdentifierNormalizer emailIdentifierNormalizer)
        {
            this.emailIdentifierNormalizer = emailIdentifierNormalizer;
            httpClient = new HttpClient();
        }


        public async Task<IssuerResponse> RequestIssuer(string email)
        {
            var identifier = emailIdentifierNormalizer.NormalizeIdentifier(email);

            var builder = new UriBuilder(identifier.Host + WebFingerUrl);

            var query = HttpUtility.ParseQueryString(builder.Query);
            query["resource"] = $"acct:{email}";
            query["rel"] = "http://openid.net/specs/connect/1.0/issuer";
            builder.Query = query.ToString();


            var response = await httpClient.GetAsync(builder.ToString());

            response.EnsureSuccessStatusCode();

            var responseJson = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<IssuerResponse>(responseJson);
        }
    }
}