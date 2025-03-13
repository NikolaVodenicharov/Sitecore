using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreSoftServe.Feature.Navigations.Models
{
    public class NavigationItem
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public bool IsActive { get; set; }
        public List<NavigationItem> Children { get; set; } = new List<NavigationItem>();

    }
}