using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Links;
using Sitecore.Links.UrlBuilders;
using Sitecore.Mvc.Presentation;
using SitecoreSoftServe.Feature.Navigations.Common;
using SitecoreSoftServe.Feature.Navigations.Models;
using SitecoreSoftServe.Foundation.ErrorHandling.Common;
using SitecoreSoftServe.Foundation.ErrorHandling.Models;
using SitecoreSoftServe.Foundation.ErrorHandling;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SitecoreSoftServe.Feature.Navigations.Controllers
{
    public class MenuController : Controller
    {
        public ActionResult Menu()
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

                Menu model = CreateMenuModel();

                return View("~/Views/Feature/Menus/MenuView.cshtml", model);
            }
            catch (System.Exception e)
            {
                var errorMessage = $"Error for {nameof(Menu)} component.";

                Log.Error(errorMessage, e.InnerException, this);

                ErrorModel errorModel = ErrorModel.Error(errorMessage);

                return View(ErrorConstants.ErrorView, errorModel);
            }
        }

        private Menu CreateMenuModel()
        {
            var datasourceItem = RenderingContext.Current?.Rendering.Item;

            var navigationItems = GetNavigationItemsFromContentRefactored(datasourceItem, 1);

            var model = new Menu()
            {
                Item = datasourceItem,
                IconUrl = Services.GetImageUrl(datasourceItem, MenuTemplates.Menu.Icon),
                Children = navigationItems
            };
            return model;
        }

        private List<NavigationItem> GetNavigationItemsFromContent(Item parentItem, int currentLevel, int maxDepth = 3)
        {
            if (currentLevel > maxDepth || parentItem == null)  // repetition in this method and in GetNavigationItemsFromPage I should extract a method, after I make the code work.
            {
                return new List<NavigationItem>();
            }

            var navigationItems = parentItem
                .Children
                .Where(child => child.DescendsFrom(MenuTemplates.MenuItem.TemplateId))
                .Select(child =>
                {
                    var navigationItem = new NavigationItem
                    {
                        Title = !string.IsNullOrEmpty(child[MenuTemplates.MenuItem.MenuName])
                                ? child[MenuTemplates.MenuItem.MenuName]
                                : child.Name,
                        Children = GetNavigationItemsFromContent(child, currentLevel + 1, maxDepth)
                    };

                    LinkField linkField = child.Fields[MenuTemplates.MenuItem.PageLink];

                    if(linkField != null && !string.IsNullOrEmpty(linkField.Url))
                    {
                        navigationItem.Url = linkField.GetFriendlyUrl();
                    }

                    return navigationItem;
                })
                .ToList();

            return navigationItems;
        }

        private List<NavigationItem> GetNavigationItemsFromPage(Item parentItem, int currentLevel, int maxDepth = 3)
        {
            if(currentLevel > maxDepth || parentItem == null)
            {
                return new List<NavigationItem>();
            }

            var navigationItems = parentItem
                .Children
                .Where(child => 
                    child.DescendsFrom(MenuTemplates.HasNavigation.TemplateId) &&
                    child[MenuTemplates.HasNavigation.ExcludeFromNavigation] != "1") // not exclude from navigation
                .Select(child => new NavigationItem
                {
                    Title = !string.IsNullOrEmpty(child[MenuTemplates.HasNavigation.NavigationTitle])
                            ? child[MenuTemplates.HasNavigation.NavigationTitle]
                            : child.DisplayName,
                    Url = Sitecore.Links.LinkManager.GetItemUrl(child),
                    Children = GetNavigationItemsFromContent(child, currentLevel +1, maxDepth)
                })
                .ToList();

            return navigationItems;
        }


        // can be extracted to site helpers class in foundation layer
        private static Item GetContextHomeItem()
        {
            var site = Sitecore.Context.Site;

            if(site == null)
            {
                return null;
            }

            var startItemPath = site.StartPath;

            var item = Sitecore.Context.Database.GetItem(startItemPath);

            return item;
        }

        private List<NavigationItem> GetNavigationItemsFromContentRefactored(Item parentItem, int currentLevel, int maxDepth = 3)
        {
            var isRecursionEnd = currentLevel > maxDepth || parentItem == null;

            if (isRecursionEnd)
            {
                return new List<NavigationItem>();
            }

            var navigationItems = parentItem
                .Children
                .Where(child => child.DescendsFrom(MenuTemplates.MenuItem.TemplateId))
                .Select(child =>
                {
                    NavigationItem navigationItem = CreatenavigationItem(currentLevel, maxDepth, child);

                    AddLinkIfExist(child, navigationItem);

                    return navigationItem;
                })
                .ToList();

            return navigationItems;
        }

        private NavigationItem CreatenavigationItem(int currentLevel, int maxDepth, Item child)
        {
            var navigationItem = new NavigationItem
            {
                Title = GetMenuTitle(child),
                Children = GetNavigationItemsFromContentRefactored(child, currentLevel + 1, maxDepth)
            };

            return navigationItem;
        }

        private static string GetMenuTitle(Item child)
        {
            string title = null;

            var isMenuCustomNameExist = !string.IsNullOrEmpty(child[MenuTemplates.MenuItem.MenuName]);

            if (isMenuCustomNameExist)
            {
                title = child[MenuTemplates.MenuItem.MenuName];
            }
            else
            {
                title = child.Name;
            }

            return title;
        }

        private static void AddLinkIfExist(Item item, NavigationItem navigationItem)
        {
            LinkField linkField = item.Fields[MenuTemplates.MenuItem.PageLink];

            var isLinkExist = linkField != null && linkField.TargetItem != null;

            if (isLinkExist)
            {
                var targetItem = linkField.TargetItem;

                var targetPageItemUrl = LinkManager.GetItemUrl(
                    targetItem,
                    new ItemUrlBuilderOptions { AlwaysIncludeServerUrl = true});

                navigationItem.Url = targetPageItemUrl;
            }
        }
    }
}