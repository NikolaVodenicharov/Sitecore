using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreSoftServe.Foundation.ErrorHandling.Common
{
    public class ErrorServices
    {
        public static bool IsDatasourceMissing(RenderingContext currentRenderingContext)
        {
            var isDatasourceMissing = string.IsNullOrEmpty(currentRenderingContext.Rendering.DataSource);

            return isDatasourceMissing;
        }
    }
}