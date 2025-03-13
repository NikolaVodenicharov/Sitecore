using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreSoftServe.Feature.Navigations.Models.FooterModels
{
    public class MainFooterInstagramModel
    {
        public MainFooterInstagramModel(Item item)
        {
            Item = item;
        }

        public Item Item { get; set; }
    }
}