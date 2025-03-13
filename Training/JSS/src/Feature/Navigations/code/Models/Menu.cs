using Sitecore.Data.Items;
using SitecoreSoftServe.Feature.NavigationJss.Models;
using System.Collections.Generic;

namespace SitecoreSoftServe.Feature.NavigationJss.Models
{
    public class Menu
    {
        public Item Item { get; set; }

        public string IconUrl { get; set; }

        public List<NavigationItem> Children {  get; set; } = new List<NavigationItem>();
    }
}