using Sitecore.Diagnostics;
using Sitecore.Mvc.Presentation;
using SitecoreSoftServe.Feature.Content.Common;
using SitecoreSoftServe.Feature.Content.Models.Abouts;
using SitecoreSoftServe.Feature.Content.Models.Testimonials;
using SitecoreSoftServe.Foundation.ErrorHandling.Common;
using SitecoreSoftServe.Foundation.ErrorHandling.Models;
using SitecoreSoftServe.Foundation.ErrorHandling;
using System.Web.Mvc;

namespace SitecoreSoftServe.Feature.Content.Controllers
{
    public class TestimonialController : Controller
    {
        public ActionResult Testimonial()
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

                TestimonialViewModel testimonialViewModel = CreateTestimonialViewModel();

                return View("~/Views/Feature/Testimonials/TestimonialView.cshtml", testimonialViewModel);
            }
            catch (System.Exception e)
            {
                var errorMessage = $"Error for {nameof(Testimonial)} component.";

                Log.Error(errorMessage, e.InnerException, this);

                ErrorModel errorModel = ErrorModel.Error(errorMessage);

                return View(ErrorConstants.ErrorView, errorModel);
            }
        }
        
        private static TestimonialViewModel CreateTestimonialViewModel()
        {
            var datasourceItem = RenderingContext.Current?.Rendering.Item;

            TestimonialViewModel testimonialViewModel = new TestimonialViewModel()
            {
                Item = datasourceItem,
                AuthorImageUrl = Services.GetImageUrl(datasourceItem, Templates.Testimonial.AuthorImage),
                BackgroundImageUrl = Services.GetImageUrl(datasourceItem, Templates.Testimonial.BackgroundImage)
            };

            return testimonialViewModel;
        }
    }
}