using Sitecore.Data.Items;
using System.Collections.Generic;

namespace SoftServeJss.Feature.JssNews.Models
{
    public class NewsListModel
    {
        public Item Datasource { get; set; }
        public List<NewsModel> News { get; set; }
    }
}