using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//namespace
using Sitecore;
using Coforge.Project.Website.Models;

namespace Coforge.Project.Website.Controllers
{
    public class SpecializationSubjectController : Controller
    {
        // GET: SpecializationSubject
        public ActionResult Index()
        {
            //Sitecore current context
            var contextItem = Context.Item;

            //Class Object to set properties
            SpecializationSubject subjectDetails = new SpecializationSubject();
            subjectDetails.Title = contextItem.Fields["Title"].Value;
            subjectDetails.Description = contextItem.Fields["Description"].Value;

            //return classObject to views
            return View(subjectDetails);
        }
    }
}