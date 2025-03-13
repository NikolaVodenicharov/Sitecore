using Sitecore.Data.Items;
using SitecoreSoftServe.Feature.Navigations.Models;
using System.Collections.Generic;

namespace SitecoreSoftServe.Feature.Navigations.Models
{
    public class Menu
    {
        public Item Item { get; set; }

        public string IconUrl { get; set; }

        public List<NavigationItem> Children {  get; set; } = new List<NavigationItem>();
    }
}