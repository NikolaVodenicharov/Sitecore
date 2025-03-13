using Sitecore.Data.Fields;
using Sitecore.LayoutService.Configuration;
using Sitecore.LayoutService.ItemRendering.ContentsResolvers;
using Sitecore.Mvc.Presentation;
using Sitecore.Data.Items;
using SoftServeJss.Feature.JssEvents.Common;
using SoftServeJss.Feature.JssEvents.Models;

using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Sitecore.Links;
using Sitecore.LayoutService.Helpers;
using System.CodeDom;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq;
using Sitecore.ContentSearch.Utilities;
using Sitecore.Data;
using Sitecore.Resources.Media;




namespace SoftServeJss.Feature.JssEvents.RenderingContentsResolvers
{
    public class EventsResolver : RenderingContentsResolver
    {
        private const string ValueString = "value";
        private const string FieldsString = "fields";

        public override object ResolveContents(Rendering rendering, IRenderingConfiguration renderingConfig)
        {
            var datasourceItem = this.GetContextItem(rendering, renderingConfig);

            var eventItems = GetEventItems();

            JObject eventList = CreateEventListJObject(rendering, renderingConfig, datasourceItem, eventItems);

            return eventList;
        }

        private IEnumerable<Item> GetEventItems()
        {
            using (var context = ContentSearchManager.CreateSearchContext(new SitecoreIndexableItem(Sitecore.Context.Item)))
            {
                IQueryable<EventSearchQuery> query = context.GetQueryable<EventSearchQuery>();

                query = query.Where(e => e.Templates.Contains(IdHelper.NormalizeGuid(Templates.EventInfo.TemplateId)) &&
                                         e.Name != "__Standard Values");

                query = query.OrderByDescending(e => e.EventEndDate);

                SearchResults<EventSearchQuery> results = query.GetResults();

                IEnumerable<Item> items = results.Hits.Select(s => s.Document.GetItem());

                return items;
            }
        }
        private JObject CreateEventListJObject(Rendering rendering, IRenderingConfiguration renderingConfig, Item datasourceItem, IEnumerable<Item> eventItems)
        {
            JArray jArray = CreateEventItemsJArray(rendering, renderingConfig, eventItems);

            var eventList = new JObject
            {
                ["eventListTitle"] = new JObject
                {
                    [ValueString] = datasourceItem[Templates.EventList.Title]
                },
                ["eventListDescription"] = new JObject
                {
                    [ValueString] = datasourceItem[Templates.EventList.Description]
                },
                ["events"] = jArray
            };
            return eventList;
        }
        private JArray CreateEventItemsJArray(Rendering rendering, IRenderingConfiguration renderingConfig, IEnumerable<Item> eventItems)
        {
            JArray jArray = new JArray();

            foreach (var eventItem in eventItems)
            {
                JObject value = ProcessItem(eventItem, rendering, renderingConfig);

                JObject item = new JObject
                {
                    ["id"] = eventItem.ID.Guid.ToString(),
                    ["url"] = LinkManager.GetItemUrl(eventItem, ItemUrlHelper.GetLayoutServiceUrlOptions()),
                    ["name"] = eventItem.Name,
                    ["displayName"] = eventItem.DisplayName,
                    [FieldsString] = value
                };

                item[FieldsString]["linkUrl"] = new JObject
                {
                    [ValueString] = LinkManager.GetItemUrl(eventItem, ItemUrlHelper.GetLayoutServiceUrlOptions())
                };

                item[FieldsString]["linkName"] = new JObject
                {
                    [ValueString] = string.IsNullOrEmpty(eventItem.DisplayName)
                                ? eventItem.Name
                                : eventItem.DisplayName
                };

                jArray.Add(item);
            }

            return jArray;
        }
        

        private List<EventModel> CreateEventModels(IEnumerable<Item> eventItems)
        {
            List<EventModel> events = eventItems
                .Select(item => CreateEventModel(item))
                .ToList();

            return events;
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
        private string GetImageUrl(Item item, ID fieldId)
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