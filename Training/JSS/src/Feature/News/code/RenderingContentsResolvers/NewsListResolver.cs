using Sitecore.Data.Fields;
using Sitecore.LayoutService.Configuration;
using Sitecore.LayoutService.ItemRendering.ContentsResolvers;
using Sitecore.Mvc.Presentation;
using Sitecore.Data.Items;
using SoftServeJss.Feature.JssNews.Common;
using SoftServeJss.Feature.JssNews.Models;

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
using System;




namespace SoftServeJss.Feature.JssNews.RenderingContentsResolvers
{
    public class NewsListResolver : RenderingContentsResolver
    {
        private const string ValueString = "value";
        private const string FieldsString = "fields";

        public override object ResolveContents(Rendering rendering, IRenderingConfiguration renderingConfig)
        {
            var datasourceItem = this.GetContextItem(rendering, renderingConfig);

            var newsItems = GetNewsInfoItems();

            var newsList = CreateNewsListJObject(rendering, renderingConfig, datasourceItem, newsItems);

            return newsList;
        }

        private static IEnumerable<Item> GetNewsInfoItems()
        {
            using (var context = ContentSearchManager.CreateSearchContext(new SitecoreIndexableItem(Sitecore.Context.Item)))
            {
                IQueryable<NewsSearchQuery> query = context.GetQueryable<NewsSearchQuery>();

                query = query.Where(e => e.Templates.Contains(IdHelper.NormalizeGuid(TemplatesNews.NewsInfo.TemplateId)) &&
                                         e.Name != "__Standard Values");

                query = query.OrderByDescending(e => e.NewsDate);

                SearchResults<NewsSearchQuery> results = query.GetResults();

                IEnumerable<Item> items = results.Hits.Select(s => s.Document.GetItem());

                return items;
            }
        }

        private object CreateNewsListJObject(Rendering rendering, IRenderingConfiguration renderingConfig, Item datasourceItem, IEnumerable<Item> newsItems)
        {
            JArray jArray = CreateNewsItemsJArray(rendering, renderingConfig, newsItems);

            var eventList = new JObject
            {
                ["newsListTitle"] = new JObject
                {
                    [ValueString] = datasourceItem[TemplatesNews.NewstList.Title]
                },
                ["newsListDescription"] = new JObject
                {
                    [ValueString] = datasourceItem[TemplatesNews.NewstList.Description]
                },
                ["news"] = jArray
            };

            return eventList;
        }

        private JArray CreateNewsItemsJArray(Rendering rendering, IRenderingConfiguration renderingConfig, IEnumerable<Item> newsItems)
        {
            JArray jArray = new JArray();

            foreach (var newsItem in newsItems)
            {
                JObject value = ProcessItem(newsItem, rendering, renderingConfig);

                JObject item = new JObject
                {
                    ["id"] = newsItem.ID.Guid.ToString(),
                    ["url"] = LinkManager.GetItemUrl(newsItem, ItemUrlHelper.GetLayoutServiceUrlOptions()),
                    ["name"] = newsItem.Name,
                    ["displayName"] = newsItem.DisplayName,
                    [FieldsString] = value
                };

                item[FieldsString]["linkUrl"] = new JObject
                {
                    [ValueString] = LinkManager.GetItemUrl(newsItem, ItemUrlHelper.GetLayoutServiceUrlOptions())
                };

                item[FieldsString]["linkName"] = new JObject
                {
                    [ValueString] = string.IsNullOrEmpty(newsItem.DisplayName)
                                ? newsItem.Name
                                : newsItem.DisplayName
                };

                jArray.Add(item);
            }

            return jArray;
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