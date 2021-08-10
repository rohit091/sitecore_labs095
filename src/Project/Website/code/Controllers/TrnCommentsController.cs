using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore;
using Coforge.Project.Website.Models;
using Sitecore.Links;

namespace Coforge.Project.Website.Controllers
{
    public class TrnCommentsController : Controller
    {
        // GET: TrnComments
        public ActionResult Index()
        {
            var contextItem = Context.Item;

            var commentsList = contextItem.GetChildren()
                .Select(x => new Comments{
                    CommenterName = x.Fields["CommenterName"].Value,
                    CommenterEmail = x.Fields["CommenterEmail"].Value,
                    CommenterComments = x.Fields["CommenterComments"].Value
                }).ToList();

            return View(commentsList);
        }
    }
}