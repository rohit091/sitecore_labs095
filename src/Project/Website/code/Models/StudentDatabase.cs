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
        public string Name  { get; set; }
        public string DOB { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string MyProperty { get; set; }
        public string Profile { get; set; }
        public string Photograph { get; set; }
    }
}