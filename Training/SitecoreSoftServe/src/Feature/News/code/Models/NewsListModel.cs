using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreSoftServe.Feature.News.Models
{
    public class NewsListModel
    {
        public Item Datasource { get; set; }
        public List<NewsModel> News { get; set; }
    }
}