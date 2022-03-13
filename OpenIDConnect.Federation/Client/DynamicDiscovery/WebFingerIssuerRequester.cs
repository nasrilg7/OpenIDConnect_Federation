using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using OpenIDConnect.Federation.Interfaces;
using OpenIDConnect.Federation.Models;

namespace OpenIDConnect.Federation.Client.DynamicDiscovery
{
    public class WebFingerIssuerRequester : IWebFingerIssuerRequester
    {
        private const string WebFingerUrl = "/.well-known/webfinger";

        private readonly HttpClient httpClient;
        private readonly IEmailIdentifierNormalizer emailIdentifierNormalizer;

        public WebFingerIssuerRequester(IEmailIdentifierNormalizer emailIdentifierNormalizer, HttpClient httpClient)
        {
            this.emailIdentifierNormalizer = emailIdentifierNormalizer;
            this.httpClient = httpClient; //new HttpClient();
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