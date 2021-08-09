using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coforge.Project.Website.Models
{
    public class ListingCard
    {
        public  string ListingCardTitle { get; set; }
        public HtmlString ListingCardDescription { get; set; }

        public string ListingCardUrl { get; set; }

    }
}