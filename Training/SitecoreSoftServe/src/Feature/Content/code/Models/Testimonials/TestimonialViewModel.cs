using Sitecore.Data.Items;

namespace SitecoreSoftServe.Feature.Content.Models.Testimonials
{
    public class TestimonialViewModel
    {
        public Item Item { get; set; }
        public string AuthorImageUrl { get; set; }
        public string BackgroundImageUrl { get; set; }
    }
}