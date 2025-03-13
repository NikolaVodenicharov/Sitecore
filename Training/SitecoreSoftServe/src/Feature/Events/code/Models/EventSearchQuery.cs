using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using System;
using System.Collections.Generic;

namespace SitecoreSoftServe.Feature.Events.Models
{
    public class EventSearchQuery : SearchResultItem
    {
        [IndexField("_templates")]
        public IEnumerable<string> Templates { get; set; }


        [IndexField(Events.Templates.EventWhereabouts.StartDateIndexFieldName)]
        public DateTime EventStartDate { get; set; }


        [IndexField(Events.Templates.EventWhereabouts.EndDateIndexFieldName)]
        public string EventEndDate { get; set; }
    }
}