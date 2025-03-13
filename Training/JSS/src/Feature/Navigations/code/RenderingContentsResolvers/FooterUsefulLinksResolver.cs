using Sitecore.Data.Items;
using Sitecore.LayoutService.Configuration;
using Sitecore.LayoutService.ItemRendering.ContentsResolvers;
using System.Collections.Generic;
using Sitecore.Mvc.Presentation;
using SitecoreSoftServe.Feature.NavigationJss.Common;
using Newtonsoft.Json.Linq;
using Sitecore.Data.Fields;
using Sitecore.Links.UrlBuilders;
using Sitecore.Links;
using SoftServeJss.Feature.NavigationJss.Common;
using System;
using Sitecore.LayoutService.Helpers;
using static SoftServeJss.Feature.NavigationJss.Common.FooterTemplates;

namespace SoftServeJss.Feature.NavigationJss.RenderingContentsResolvers
{
    public class FooterUsefulLinksResolver : RenderingContentsResolver
    {
        private const string ValueString = "value";
        private const string FieldsString = "fields";

        public override object ResolveContents(Rendering rendering, IRenderingConfiguration renderingConfig)
        {
            var datasourceItem = this.GetContextItem(rendering, renderingConfig);

            JObject usefulLinksJObject = CreateFooterUsefulLinks(datasourceItem);

            return usefulLinksJObject;
        }

        private JObject CreateFooterUsefulLinks(Item datasourceItem)
        {
            MultilistField usefullLinks = datasourceItem.Fields[FooterTemplates.UsefulLinks.LinksList];

            JArray jArray = new JArray();

            foreach (var footerLink in usefullLinks.GetItems())
            {
                JObject item = new JObject
                {
                    [FieldsString] = new JObject
                    {
                        ["name"] = new JObject
                        {
                            [ValueString] = GetFooterLinkName(footerLink)
                        },
                        ["link"] = new JObject
                        {
                            [ValueString] = GetFooterLinkReference(footerLink)
                        }
                    }
                };

                jArray.Add(item);
            }

            var eventList = new JObject
            {
                ["title"] = new JObject
                {
                    [ValueString] = datasourceItem[FooterTemplates.UsefulLinks.Title]
                },
                ["linksList"] = jArray
            };

            return eventList;
        }

        private static string GetFooterLinkName(Item child)
        {
            string title = null;

            var isMenuCustomNameExist = !string.IsNullOrEmpty(child[FooterTemplates.FooterLink.Name]);

            if (isMenuCustomNameExist)
            {
                title = child[FooterTemplates.FooterLink.Name];
            }
            else
            {
                title = child.Name;
            }

            return title;
        }
        private static string GetFooterLinkReference(Item item)
        {
            LinkField linkField = item.Fields[FooterTemplates.FooterLink.Link];

            var isLinkExist = linkField != null && linkField.TargetItem != null;

            if (!isLinkExist)
            {
                return string.Empty;
            }

            var targetItem = linkField.TargetItem;

            var targetPageItemUrl = LinkManager.GetItemUrl(
                targetItem,
                new ItemUrlBuilderOptions { AlwaysIncludeServerUrl = true });

            return targetPageItemUrl;
        }

    }
}