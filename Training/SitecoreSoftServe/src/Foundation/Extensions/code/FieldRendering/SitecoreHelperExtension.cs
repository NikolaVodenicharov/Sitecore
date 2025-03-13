using Sitecore.Mvc.Helpers;
using System.Web;
using Sitecore.Data;
using Sitecore.Data.Items;

namespace SitecoreSoftServe.Foundation.Extensions.FieldRendering
{
    public static class SitecoreHelperExtension
    {
        public static HtmlString Field(this SitecoreHelper helper, ID fieldId)
        {
            return helper.Field(fieldId.ToString());
        }

        public static HtmlString Field(this SitecoreHelper helper, ID fieldId, object parameters)
        {
            return helper.Field(fieldId.ToString(), parameters);
        }

        public static HtmlString Field(this SitecoreHelper helper, ID fieldId, Item item)
        {
            return helper.Field(fieldId.ToString(), item);
        }

        public static HtmlString Field(this SitecoreHelper helper, ID fieldId, Item item, object parameters)
        {
            return helper.Field(fieldId.ToString(), item, parameters);
        }
    }
}