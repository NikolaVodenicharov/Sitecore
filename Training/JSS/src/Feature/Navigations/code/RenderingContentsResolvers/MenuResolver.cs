using Sitecore.Data.Fields;
using Sitecore.LayoutService.Configuration;
using Sitecore.LayoutService.ItemRendering.ContentsResolvers;
using Sitecore.Mvc.Presentation;
using Sitecore.Data.Items;
using SitecoreSoftServe.Feature.NavigationJss.Common;
using SitecoreSoftServe.Feature.NavigationJss.Models;

using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json.Linq;
using Newtonsoft.Json;




namespace SoftServeJss.Feature.NavigationJss.RenderingContentsResolvers
{
    public class MenuResolver : RenderingContentsResolver
    {
        public override object ResolveContents(Rendering rendering, IRenderingConfiguration renderingConfig)
        {
            var datasourceItem = this.GetContextItem(rendering, renderingConfig);

            var navigationItems = GetNavigationItems(datasourceItem, 1);

            return new Dictionary<string, object>
            {
                {"menuItems", navigationItems}
            };
        }

        private static bool IsDataMissing(Item datasourceItem)
        {
            var isDataMissing = datasourceItem == null || !datasourceItem.DescendsFrom(Templates.Menu.TemplateId);

            return isDataMissing;
        }

        private List<NavigationItem> GetNavigationItems(Item parentItem, int currentLevel, int maxDepth = 3)
        {
            if (IsRecursionEnd(parentItem, currentLevel, maxDepth))
            {
                return new List<NavigationItem>();
            }

            var navigationItems = parentItem
                .Children
                .Where(child => child.DescendsFrom(Templates.MenuItem.TemplateId))
                .Select(child => CreateRecursiveNavigationItem(currentLevel, maxDepth, child))
                .ToList();

            return navigationItems;
        }

        private static bool IsRecursionEnd(Item parentItem, int currentLevel, int maxDepth)
        {
            var isRecursionEnd = currentLevel > maxDepth || parentItem == null;

            return isRecursionEnd;
        }
        private NavigationItem CreateRecursiveNavigationItem(int currentLevel, int maxDepth, Item child)
        {
            var navigationItem = new NavigationItem
            {
                Title = GetMenuName(child),
                Url = ExtractItemUrl(child),
                Children = GetNavigationItems(child, currentLevel + 1, maxDepth)
            };

            return navigationItem;
        }
        private static string GetMenuName(Item child)
        {
            var menuName = !string.IsNullOrEmpty(child[Templates.MenuItem.MenuName])
                                            ? child[Templates.MenuItem.MenuName]
                                            : child.Name;

            return menuName;
        }
        private static string ExtractItemUrl(Item child)
        {
            var url = Sitecore.Links.LinkManager.GetItemUrl(child);

            return url;
        }

        private JArray GetNavigationItemsJObject(Item parentItem, int currentLevel, int maxDepth = 3)
        {
            if (IsRecursionEnd(parentItem, currentLevel, maxDepth))
            {
                return new JArray(); ;
            }

            var children = parentItem
                .Children
                .Where(child => child.DescendsFrom(Templates.MenuItem.TemplateId))
                .Select(child => new JObject
                {
                    ["fields"] = new JObject
                    {
                        ["title"] = new JObject
                        {
                            ["value"] = GetMenuName(child)
                        },
                        ["url"] = new JObject
                        {
                            ["value"] = new JObject
                            {
                                ["href"] = ExtractItemUrl(child),
                                ["target"] = "_blank"
                            }
                        },
                        ["children"] = GetNavigationItemsJObject(child, currentLevel + 1, maxDepth)
                    }
                });

            var jArray = new JArray(children);

            return jArray;
        }
    }
}