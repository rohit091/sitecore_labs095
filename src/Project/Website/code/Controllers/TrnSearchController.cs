using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore;
using Coforge.Project.Website.Models;


namespace Coforge.Project.Website.Controllers
{
    public class TrnSearchController : Controller
    {
        //=====
        // GET: TrnSearch
        //=====
        [HttpGet]
        public ActionResult Index()
        { 
            //output to get SearchForm
            return View();
        }


        //=====
        //POST : TrnSearch
        //=====
        //we need to pass SearchTerm Model & Object for new View here
        [HttpPost]
        public ActionResult Index(SearchTerm sterm)
        {
            //CODE

            //Provide output after POST request
            //provide full path after the root
            return View("/Views/TrnSearch/SResult.cshtml");
        }
    }
}