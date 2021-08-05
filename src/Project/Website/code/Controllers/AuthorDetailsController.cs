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
    public class AuthorDetailsController : Controller
    {
        // GET: AuthorDetails
        public ActionResult Index()
        {
            //Sitecore.Context.Item
            var contextItem = Context.Item;

            //class Object
            AuthorDetails authDetails = new AuthorDetails();
            authDetails.AuthorName = new HtmlString(FieldRenderer.Render(contextItem, "AuthorName"));
            authDetails.AuthorImage = new HtmlString(FieldRenderer.Render(contextItem, "AuthorImage"));
            authDetails.AuthorDesignation = new HtmlString(FieldRenderer.Render(contextItem, "AuthorDesignation"));

            //return object to View
            return View(authDetails);
        }
    }
}