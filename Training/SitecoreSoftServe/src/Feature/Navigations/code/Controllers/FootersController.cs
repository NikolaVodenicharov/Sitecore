using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Links.UrlBuilders;
using Sitecore.Links;
using Sitecore.Mvc.Presentation;
using Sitecore.Resources.Media;
using SitecoreSoftServe.Feature.Navigations.Common;
using SitecoreSoftServe.Feature.Navigations.Models;
using SitecoreSoftServe.Feature.Navigations.Models.FooterModels;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace SitecoreSoftServe.Feature.Navigations.Controllers
{
    public class FootersController : Controller
    {
        public ActionResult TopFooter()
        {
            TopFooterModel topFooterModel = CreateTopFooterModel();

            return View("~/Views/Feature/Footers/TopFooterView.cshtml", topFooterModel);
        }
        public ActionResult MainFooterSocialMedia()
        {
            var datasourceItem = RenderingContext.Current?.Rendering.Item;

            MainFooterSocialMediaModel model = CreateMainFooterSocialMedia(datasourceItem);

            return View("~/Views/Feature/Footers/MainFooterSocialMediaView.cshtml", model);
        }
        public ActionResult MainFooterContacts()
        {
            var datasourceItem = RenderingContext.Current?.Rendering.Item;

            MainFooterContactsModel model = new MainFooterContactsModel(datasourceItem);

            return View("~/Views/Feature/Footers/MainFooterContactsView.cshtml", model);
        }
        public ActionResult MainFooterLinks()
        {
            var datasourceItem = RenderingContext.Current?.Rendering.Item;

            var model = CreateMainFooterLinks(datasourceItem);

            return View("~/Views/Feature/Footers/MainFooterLinksView.cshtml", model);
        }
        public ActionResult MainFooterInstagram()
        {
            var datasourceItem = RenderingContext.Current?.Rendering.Item;

            var model = CreateMainFooterInstagram(datasourceItem);

            return View("~/Views/Feature/Footers/MainFooterInstagramView.cshtml", model);
        }
        public ActionResult BottomFooter()
        {
            BottomFooterModel bottomFooterModel = CreateBottomFooterModel();

            return View("~/Views/Feature/Footers/BottomFooterView.cshtml", bottomFooterModel);
        }

        private TopFooterModel CreateTopFooterModel()
        {
            var datasourceItem = RenderingContext.Current?.Rendering.Item;

            TopFooterModel topFooterModel = new TopFooterModel
            {
                Item = datasourceItem
            };

            return topFooterModel;
        }     

        private MainFooterSocialMediaModel CreateMainFooterSocialMedia(Item datasourceItem)
        {
            MainFooterSocialMediaModel mainFooterSocialMedias = new MainFooterSocialMediaModel();

            mainFooterSocialMedias.Item = datasourceItem;
            mainFooterSocialMedias.FacebookLink = "#";
            mainFooterSocialMedias.RssLink = "#";
            mainFooterSocialMedias.GoogleLink = "#";
            mainFooterSocialMedias.PinterestLink = "#";
            mainFooterSocialMedias.InstagramLink = "#";

            return mainFooterSocialMedias;
        }

        private MainFooterLinksModel CreateMainFooterLinks(Item datasourceItem)
        {
            MultilistField usefullLinks = datasourceItem.Fields[FooterTemplates.UsefulLinks.LinksList];

            MainFooterLinksModel mainFooterLinks = new MainFooterLinksModel(datasourceItem, new List<LinkCouple>());

            foreach (var footerLink in usefullLinks.GetItems())
            {
                var linkCouple = new LinkCouple(
                    GetFooterLinkName(footerLink), 
                    GetFooterLinkReference(footerLink));

                mainFooterLinks.LinkCouples.Add(linkCouple);
            }

            return mainFooterLinks;
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

        private MainFooterInstagramModel CreateMainFooterInstagram(Item datasourceItem)
        {
            MainFooterInstagramModel mainFooterInstagram = new MainFooterInstagramModel(datasourceItem);

            return mainFooterInstagram;
        }

        private BottomFooterModel CreateBottomFooterModel()
        {
            var datasourceItem = RenderingContext.Current?.Rendering.Item;

            BottomFooterModel bottomFooterModel = new BottomFooterModel
            {
                Item = datasourceItem
            };

            return bottomFooterModel;
        }
    }
}