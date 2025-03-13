using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftServeJss.Feature.JssNews.Models
{
    public class NewsSearchQuery : SearchResultItem
    {
        [IndexField("_templates")]
        public IEnumerable<string> Templates { get; set; }


        [IndexField(Common.TemplatesNews.NewsHints.DateIndexFieldName)]
        public DateTime NewsDate { get; set; }
    }
}