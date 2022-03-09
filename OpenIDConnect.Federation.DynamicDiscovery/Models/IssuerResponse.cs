namespace OpenIDConnect.Federation.DynamicDiscovery.Models
{
    public class IssuerResponse
    {
        public IssuerResponse(string subject, Link[] links)
        {
            Subject = subject;
            Links = links;
        }

        public string Subject { get;}

        public Link[] Links { get; }
    }
}