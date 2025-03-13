using Sitecore.Data;

namespace SitecoreSoftServe.Feature.NavigationJss.Common
{
    public class Templates
    {
        public static class Menu
        {
            public static readonly ID TemplateId = new ID("{7B9EFB3C-7D4F-4B89-B8A2-DA3E36107C1E}");
            //public static readonly ID MenuRootItem = new ID("{C5D94333-465B-4D1F-8F95-D2E9AD3EDB02}");
            public static readonly ID Icon = new ID("{C5D94333-465B-4D1F-8F95-D2E9AD3EDB02}");
        }

        public static class MenuItem
        {
            public static readonly ID TemplateId = new ID("{30B93D36-9785-4793-AB66-765EC5FD2A5F}");
            public static readonly ID MenuName = new ID("{CD411159-F1D1-4BCB-9C15-EF3D73053753}");
            public static readonly ID PageLink = new ID("{5CEC2000-B526-4289-A315-96D555B10CD1}");
        }
    }
}