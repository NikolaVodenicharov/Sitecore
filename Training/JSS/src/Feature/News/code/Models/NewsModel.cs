using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftServeJss.Feature.JssNews.Models
{
    public class NewsModel
    {
        public Item Item { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public DateTime Date { get; set; }
        public string ViewsCount { get; set; }
        public string CommentsCount { get; set; }

        public string LinkUrl { get; set; }
        public string LinkName { get; set; }
    }
}