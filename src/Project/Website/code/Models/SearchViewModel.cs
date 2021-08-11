using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coforge.Project.Website.Models
{
    //MODEL3 - VIEW MODEL
    //WE cannot use 2 models in a single View
    //as we need multiple models in single view, we combine multiple models here
    //use this model in the required View
    public class SearchViewModel
    {
        //MODEL1 - SearchResult List
        public List<SearchResult> Results { get; set; }
        //MODEL2 - SearchTerm
        public SearchTerm Term { get; set; }
    }
}