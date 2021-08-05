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
    public class AuthorDetailsController : Controller
    {
        // GET: AuthorDetails
        public ActionResult Index()
        {
            //Sitecore.Context.Item
            var contextItem = Context.Item;

            //class Object
            AuthorDetails authDetails = new AuthorDetails();
            authDetails.AuthorName = contextItem.Fields["AuthorName"].Value;
            authDetails.AuthorImage = contextItem.Fields["AuthorImage"].Value;
            authDetails.AuthorDesignation = contextItem.Fields["AuthorDesignation"].Value;

            //return object to View
            return View(authDetails);
        }
    }
}