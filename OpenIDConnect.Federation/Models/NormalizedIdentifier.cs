namespace OpenIDConnect.Federation.DynamicDiscovery.Models
{
    public class NormalizedIdentifier
    {
        public NormalizedIdentifier(string resource, string host)
        {
            Resource = resource;
            Host = host;
        }

        public string Resource { get;}
        public string Host { get;}
    }
}
