using Sitecore.Data;
using Sitecore.Mvc.Presentation;

namespace SitecoreSoftServe.Feature.Banners
{
    public class Templates
    {
        public static class Banner
        {
            public static readonly ID TemplateId = new ID("{64C86D8A-80D3-4058-88E1-DCAA0D213326}");
            public static readonly ID Title = new ID("{29E42C40-44E4-4300-8932-CEAE6B5B96CC}");
            public static readonly ID Text = new ID("{3BBA1FFA-4844-45AE-A174-5A04DA8595FC}");
            public static readonly ID Link = new ID("{DE5AB5DB-67F9-4CFE-96A1-7F5BD043291D}");
            public static readonly ID BackgroundImage = new ID("{D0B72631-7EE5-49B8-B291-1EA060F275A2}");

            public static class RenderingParameters
            {
                public static readonly string HideTitle = "hideTitle";
                public static readonly string ButtonStyleClass = "buttonStyleClass";
            }
        }
    }
}