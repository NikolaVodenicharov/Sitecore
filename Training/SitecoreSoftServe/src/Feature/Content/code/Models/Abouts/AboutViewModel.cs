using Sitecore.Data.Items;

namespace SitecoreSoftServe.Feature.Content.Models.Abouts
{
    public class AboutViewModel
    {
        public Item Item { get; set; }
        public string ImageUrl { get; set; }
        public bool IsImageLeftSide { get; set; }
    }
}