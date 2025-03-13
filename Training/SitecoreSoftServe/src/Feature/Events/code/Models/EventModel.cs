using Sitecore.Data.Items;
using Sitecore.Publishing.Pipelines.PublishItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace SitecoreSoftServe.Feature.Events.Models
{
    public class EventModel
    {
        public Item Item { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string LinkUrl { get; set; }

        public string LinkName { get; set; }

        public string Location { get; set; }


    }
}