using Sitecore.Data.Items;
using Sitecore.Publishing.Pipelines.PublishItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace SitecoreSoftServe.Feature.News.Models
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