using Sitecore.Diagnostics;
using Sitecore.Mvc.Presentation;
using SitecoreSoftServe.Feature.Content.Common;
using SitecoreSoftServe.Feature.Content.Models.Abouts;
using SitecoreSoftServe.Foundation.ErrorHandling.Common;
using SitecoreSoftServe.Foundation.ErrorHandling.Models;
using SitecoreSoftServe.Foundation.ErrorHandling;
using System.Web.Mvc;

namespace SitecoreSoftServe.Feature.Content.Controllers
{
    public class AboutController : Controller
    {
        public ActionResult About()
        {
            try
            {
                if (ErrorServices.IsDatasourceMissing(RenderingContext.Current))
                {
                    var errorMessage = ErrorMessages.DatasourceIsMissingDictionary;

                    Log.Warn(errorMessage, this);

                    ErrorModel errorModel = ErrorModel.Warning(errorMessage);

                    return View(ErrorConstants.ErrorView, errorModel);
                }

                AboutViewModel aboutViewModel = CreateAboutViewModel();

                return View("~/Views/Feature/Abouts/AboutView.cshtml", aboutViewModel);
            }
            catch (System.Exception e)
            {
                var errorMessage = $"Error for {nameof(About)} component.";

                Log.Error(errorMessage, e.InnerException, this);

                ErrorModel errorModel = ErrorModel.Error(errorMessage);

                return View(ErrorConstants.ErrorView, errorModel);
            }
        }

        private AboutViewModel CreateAboutViewModel()
        {
            var parameters = RenderingContext
                .Current?
                .Rendering?
                .Parameters;

            var datasourceItem = RenderingContext
                .Current?
                .Rendering.
                Item;

            var model = new AboutViewModel()
            {
                Item = datasourceItem,
                ImageUrl = Services.GetImageUrl(datasourceItem, Templates.About.Image),
                IsImageLeftSide = GetIsImageLeftSide(parameters)
            };
            return model;
        }

        private bool GetIsImageLeftSide(RenderingParameters parameters)
        {
            bool isImageLeftSide =  parameters?[Templates.About.RenderingParameters.IsImageLeftSide] == "1";

            return isImageLeftSide;
        }
    }
}