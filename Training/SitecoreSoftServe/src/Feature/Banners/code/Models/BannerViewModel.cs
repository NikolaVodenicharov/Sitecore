using Sitecore.Data.Items;

namespace SitecoreSoftServe.Feature.Banners.Models
{
    public class BannerViewModel
    {
        public Item Item { get; set; }
        public string BackgroundImageUrl {  get; set; }
        public bool HideTitle { get ; set; }
        public string ButtonStyleClass { get; set; }
    }
}