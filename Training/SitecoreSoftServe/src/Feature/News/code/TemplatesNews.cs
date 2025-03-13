using Sitecore.Data;

namespace SitecoreSoftServe.Feature.News
{
    public class TemplatesNews
    {
        public static class NewstList
        {
            public static readonly ID TemplateId = new ID("{32195457-AE47-4D3C-8DED-D5AF045A6B7A}");
            public static readonly ID Title = new ID("{70D9208A-B345-462C-A24E-5AB7B5D56619}");
            public static readonly ID Description = new ID("{05E90FD1-75BA-4323-B2AF-FD94CA236347}");
        }

        public static class NewsInfo
        {
            public static readonly ID TemplateId = new ID("{1EA199A6-9DC5-4242-90C0-71565A72C013}");

            public static readonly ID Title = new ID("{01BF4D6D-B6B5-4061-83FA-84A1E904B22F}");
            public static readonly ID Description = new ID("{73EE15C3-EE96-4598-B113-CD0924ABA896}");
            public static readonly ID Image = new ID("{5F74E55E-4594-45FF-974B-7B8D2B70C4BE}");
        }

        public static class NewsHints
        {
            public static readonly ID Date = new ID("{77D423E3-DD49-446A-BE2D-A0159CA74F76}");
            public static readonly ID ViewsCount = new ID("{3F60AFB7-B2C7-48E9-B1FF-9EE4554C8047}");
            public static readonly ID CommentsCount = new ID("{CEDACB2F-A0ED-4CB9-AB8E-EF0EBDEE3807}");

            public const string DateIndexFieldName = "Empty";
        }
    }
}