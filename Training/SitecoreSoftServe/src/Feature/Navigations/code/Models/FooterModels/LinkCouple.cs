namespace SitecoreSoftServe.Feature.Navigations.Models.FooterModels
{
    public class LinkCouple
    {
        public LinkCouple(string name, string url)
        {
            Name = name;
            Url = url;
        }

        public string Name { get; set; }
        public string Url { get; set; }
    }
}