using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Events;
using System;
using System.Collections.Generic;

namespace SoftServeJss.Feature.JssEvents.Models
{
    public class EventSearchQuery : SearchResultItem
    {
        [IndexField("_templates")]
        public IEnumerable<string> Templates { get; set; }

        [IndexField(Common.Templates.EventWhereabouts.StartDateIndexFieldName)]
        public DateTime EventStartDate { get; set; }


        [IndexField(Common.Templates.EventWhereabouts.EndDateIndexFieldName)]
        public string EventEndDate { get; set; }
    }
}