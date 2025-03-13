using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreSoftServe.Feature.Navigations.Models.FooterModels
{
    public class MainFooterContactsModel
    {


        public MainFooterContactsModel(Item item) 
        { 
            Item = item;
        }        
        
        public Item Item { get; set; }
        //public string Title { get; set; }
        //public string PhoneNumber { get; set; }
        //public string Email { get; set; }
        //public string WebSite { get; set; }
        //public string Address { get; set; }
    }
}