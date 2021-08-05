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
    public class StaffDetailsController : Controller
    {
        // GET: StaffDetails
        public ActionResult Index()
        {
            //Sitecore.Context.Item
            var contextItem = Context.Item;

            //Class Object + setting fields
            StaffDetails staffDB = new StaffDetails();
            staffDB.Photo = contextItem.Fields["Photo"].Value;
            staffDB.Name = contextItem.Fields["Name"].Value;
            staffDB.Experience = contextItem.Fields["Experience"].Value;
            staffDB.ProfileDetails = contextItem.Fields["ProfileDetails"].Value;
            staffDB.Specialization = contextItem.Fields["Specialization"].Value;


            //return classObject to View
            return View(staffDB);
        }
    }
}