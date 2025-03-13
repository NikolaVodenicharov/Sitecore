using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreSoftServe.Feature.Navigations.Models.FooterModels
{
    public class MainFooterSocialMediaModel
    {
        public Item Item { get; set; }
        public string ImageLink {  get; set; }

        public string FacebookLink {  get; set; }
        public string RssLink {  get; set; }
        public string GoogleLink {  get; set; }
        public string PinterestLink {  get; set; }
        public string InstagramLink {  get; set; }

        // these are rendered in the view, because they are editable
        //public string ImageUrl {  get; set; }
        //public string Description {  get; set; }
    }
}