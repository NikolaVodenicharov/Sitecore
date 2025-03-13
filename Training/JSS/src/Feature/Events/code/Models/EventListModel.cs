using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftServeJss.Feature.JssEvents.Models
{
    public class EventListModel
    {
        public Item Datasource { get; set; }
        public List<EventModel> Events { get; set; }
    }
}