using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq;
using Sitecore.ContentSearch.Utilities;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Mvc.Presentation;
using Sitecore.Resources.Media;
using SitecoreSoftServe.Feature.News.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SitecoreSoftServe.Feature.News.Controllers
{
    public class NewsListController : Controller
    {
        public ActionResult NewsList()
        {
            var newsList = new NewsListModel
            {
                News = GetNews(),
                Datasource = RenderingContext.Current?.Rendering.Item
            };

            return View("~/Views/Feature/News/NewsListView.cshtml", newsList);
        }

        private List<NewsModel> GetNews()
        {
            using (var context = ContentSearchManager.CreateSearchContext(new SitecoreIndexableItem(Sitecore.Context.Item)))
            {
                IEnumerable<Item> newInfoItems = GetNewsInfoItems(context);

                List<NewsModel> news = newInfoItems
                    .Select(item => CreateNewsModel(item))
                    .ToList();

                return news;
            }
        }

        private static IEnumerable<Item> GetNewsInfoItems(IProviderSearchContext context)
        {
            IQueryable<NewsSearchQuery> query = context.GetQueryable<NewsSearchQuery>();

            query = query.Where(e => e.Templates.Contains(IdHelper.NormalizeGuid(TemplatesNews.NewsInfo.TemplateId)) &&
                                     e.Name != "__Standard Values");

            query = query.OrderByDescending(e => e.NewsDate);

            SearchResults<NewsSearchQuery> results = query.GetResults();

            IEnumerable<Item> items = results.Hits.Select(s => s.Document.GetItem());

            return items;
        }

        private NewsModel CreateNewsModel(Item item)
        {
            var newsItem = new NewsModel
            {
                Item = item,
                Title = item[TemplatesNews.NewsInfo.Title],
                Description = item[TemplatesNews.NewsInfo.Description],
                ViewsCount = item[TemplatesNews.NewsHints.CommentsCount],
                CommentsCount = item[TemplatesNews.NewsHints.CommentsCount]
            };

            DateField startDate = item.Fields[TemplatesNews.NewsHints.Date];
            newsItem.Date = startDate.DateTime;

            newsItem.ImageUrl = GetImageUrl(item, TemplatesNews.NewsInfo.Image);

            newsItem.LinkUrl = LinkManager.GetItemUrl(item);

            newsItem.LinkName = string.IsNullOrEmpty(item.DisplayName) ? item.Name : item.DisplayName;

            return newsItem;
        }

        private string GetImageUrl(Item item, ID fieldId) //it could be exctracted to foundation layer, it is repeated in banners, and content features
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