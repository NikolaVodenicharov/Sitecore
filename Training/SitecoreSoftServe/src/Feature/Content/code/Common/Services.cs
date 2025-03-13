using Sitecore.Data;
using Sitecore.Resources.Media;
using Sitecore.Data.Items;

namespace SitecoreSoftServe.Feature.Content.Common
{
    public class Services
    {
        public static string GetImageUrl(Item item, ID fieldId)
        {
            var imageField = (Sitecore.Data.Fields.ImageField)item?.Fields[fieldId];

            if (imageField?.MediaItem != null)
            {
                return MediaManager.GetMediaUrl(imageField.MediaItem);
            }

            return string.Empty;
        }
    }
}