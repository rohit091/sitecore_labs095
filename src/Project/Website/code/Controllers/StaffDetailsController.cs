using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//namespace
using Sitecore;
using Coforge.Project.Website.Models;
using Sitecore.Web.UI.WebControls;

namespace Coforge.Project.Website.Controllers
{
    public class StaffDetailsController : Controller
    {
        // GET: StaffDetails
        public ActionResult Index()
        {
            //Sitecore.Context.Item
            var contextItem = Context.Item;

            //Class Object + setting fields
            StaffDetails staffDB = new StaffDetails();
            staffDB.Photo = new HtmlString(FieldRenderer.Render(contextItem, "Photo"));
            staffDB.Name = new HtmlString(FieldRenderer.Render(contextItem, "Name"));
            staffDB.Experience = new HtmlString(FieldRenderer.Render(contextItem, "Experience"));
            staffDB.ProfileDetails = new HtmlString(FieldRenderer.Render(contextItem, "ProfileDetails"));
            staffDB.Specialization = new HtmlString(FieldRenderer.Render(contextItem, "Specialization"));


            //return classObject to View
            return View(staffDB);
        }
    }
}