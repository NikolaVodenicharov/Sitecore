using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Globalization;
using Sitecore.Mvc.Presentation;
using Sitecore.Resources.Media;

using SitecoreSoftServe.Feature.Banners.Models;
using SitecoreSoftServe.Foundation.ErrorHandling;
using SitecoreSoftServe.Foundation.ErrorHandling.Common;
using SitecoreSoftServe.Foundation.ErrorHandling.Models;
using System.Web.Mvc;


namespace SitecoreSoftServe.Feature.Banners.Controllers
{
    public class BannerController : Controller
    {
        public ActionResult Banner()
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

                BannerViewModel bannerViewModel = CreateBannerViewModel();

                return View("~/Views/Feature/Banners/BannerView.cshtml", bannerViewModel);
            }
            catch (System.Exception e)
            {
                var errorMessage = $"Error for {nameof(Banner)} component.";

                Log.Error(errorMessage, e.InnerException, this);

                ErrorModel errorModel = ErrorModel.Error(errorMessage);

                return View(ErrorConstants.ErrorView, errorModel);
            }
        }

        private BannerViewModel CreateBannerViewModel()
        {
            var parameters = RenderingContext
                .Current?
                .Rendering?
                .Parameters;

            var datasourceItem = RenderingContext
                .Current?
                .Rendering
                .Item;

            var model = new BannerViewModel()
            {
                Item = datasourceItem,

                BackgroundImageUrl = GetImageUrl(datasourceItem, Templates.Banner.BackgroundImage),

                HideTitle = GetIsTitleHidden(parameters),

                ButtonStyleClass = GetButtonStyleClass(parameters)
            };

            return model;
        }

        private string GetImageUrl(Item item, ID fieldId)
        {
            var imageField = (Sitecore.Data.Fields.ImageField)item?.Fields[fieldId];

            if(imageField?.MediaItem != null)
            {
                return MediaManager.GetMediaUrl(imageField.MediaItem);
            }

            return string.Empty;
        }
        private bool GetIsTitleHidden(RenderingParameters parameters)
        {
            var hideTitle = parameters?[Templates.Banner.RenderingParameters.HideTitle] == "1";

            return hideTitle;
        }
        private string GetButtonStyleClass(RenderingParameters parameters)
        {
            var buttonStyleClass = parameters?[Templates.Banner.RenderingParameters.ButtonStyleClass] ?? "button-default";

            return buttonStyleClass;
        }
    }
}