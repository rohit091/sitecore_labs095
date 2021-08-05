using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; //For HtmlString

namespace Coforge.Project.Website.Models
{
    public class ArticleDetail
    {
        public HtmlString ArticleTitle { get; set; }
        public HtmlString ArticlePublishDate { get; set; }
        public HtmlString ArticleDescription { get; set; }
        public HtmlString ArticleImage { get; set; }
    }
}