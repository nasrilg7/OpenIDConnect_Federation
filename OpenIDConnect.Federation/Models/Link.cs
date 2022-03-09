namespace OpenIDConnect.Federation.Models
{
    public class Link
    {
        public Link(string rel, string hRef)
        {
            Rel = rel;
            HRef = hRef;
        }

        public string Rel { get;}

        public string HRef { get; }
    }
}