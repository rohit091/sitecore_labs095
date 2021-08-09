using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coforge.Project.Website.Models
{
    public class EntityCard
    {
        public  string EntityName { get; set; }
        public HtmlString EntityBrief { get; set; }

        public string EntityUrl { get; set; }
    }
}