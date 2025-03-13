using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq;
using Sitecore.ContentSearch.Utilities;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Data.Query;
using Sitecore.Links;
using Sitecore.Mvc.Presentation;
using Sitecore.Resources.Media;
using SitecoreSoftServe.Feature.Events.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SitecoreSoftServe.Feature.Events.Controllers
{
    public class EventListController : Controller
    {
        public ActionResult EventList()
        {
            var eventList = new EventListModel
            {
                Events = GetEvents(),
                Datasource = RenderingContext.Current?.Rendering.Item
            };

            return View("~/Views/Feature/Events/EventListView.cshtml", eventList);
        }

        private List<EventModel> GetEvents()
        {
            using (var context = ContentSearchManager.CreateSearchContext(new SitecoreIndexableItem(Sitecore.Context.Item)))
            {
                IEnumerable<Item> eventInfoItems = GetEventInfoItems(context);

                List<EventModel> events = eventInfoItems
                    .Select(item => CreateEventModel(item))
                    .ToList();

                return events;
            }
        }

        private static IEnumerable<Item> GetEventInfoItems(IProviderSearchContext context)
        {
            IQueryable<EventSearchQuery> query = context.GetQueryable<EventSearchQuery>();

            query = query.Where(e => e.Templates.Contains(IdHelper.NormalizeGuid(Templates.EventInfo.TemplateId)) &&
                                     e.Name != "__Standard Values");

            query = query.OrderByDescending(e => e.EventEndDate);

            SearchResults<EventSearchQuery> results = query.GetResults();

            IEnumerable<Item> items = results.Hits.Select(s => s.Document.GetItem());

            return items;
        }

        private EventModel CreateEventModel(Item item)
        {
            var eventItem = new EventModel
            {
                Item = item,
                Title = item[Templates.EventInfo.Title],
                Description = item[Templates.EventInfo.Description],
                Location = item[Templates.EventWhereabouts.Location]
            };

            DateField startDate = item.Fields[Templates.EventWhereabouts.StartDate];
            eventItem.StartDate = startDate.DateTime;

            DateField endDate = item.Fields[Templates.EventWhereabouts.EndDate];
            eventItem.EndDate = endDate.DateTime;

            eventItem.ImageUrl = GetImageUrl(item, Templates.EventInfo.Image);

            eventItem.LinkUrl = LinkManager.GetItemUrl(item);

            eventItem.LinkName = string.IsNullOrEmpty(item.DisplayName) ? item.Name : item.DisplayName;

            return eventItem;
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