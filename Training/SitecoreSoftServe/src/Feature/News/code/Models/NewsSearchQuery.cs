using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using System;
using System.Collections.Generic;

namespace SitecoreSoftServe.Feature.News.Models
{
    public class NewsSearchQuery : SearchResultItem
    {
        [IndexField("_templates")]
        public IEnumerable<string> Templates { get; set; }


        [IndexField(News.TemplatesNews.NewsHints.DateIndexFieldName)]
        public DateTime NewsDate { get; set; }

    }
}