using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coforge.Project.Website.Models
{
    public class StudentDatabase
    {   
        //public dataType variableFieldName {get;set;}
        //variableFieldName - from _standardValues of template
        public HtmlString Name  { get; set; }
        public HtmlString DOB { get; set; }
        public HtmlString PhoneNo { get; set; }
        public HtmlString Email { get; set; }
        public HtmlString MyProperty { get; set; }
        public HtmlString Profile { get; set; }
        public HtmlString Photograph { get; set; }
    }
}