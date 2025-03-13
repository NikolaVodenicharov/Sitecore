using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreSoftServe.Feature.Navigations.Models.FooterModels
{
    public class MainFooterLinksModel
    {
        public MainFooterLinksModel(Item item, List<LinkCouple> linkCouples)
        {
            Item = item;
            LinkCouples = linkCouples;
        }

        public Item Item { get; set; }

        public List<LinkCouple> LinkCouples { get; set; }

        //public Dictionary<string, string> Links { get; set; }   // Url, Name
    }
}