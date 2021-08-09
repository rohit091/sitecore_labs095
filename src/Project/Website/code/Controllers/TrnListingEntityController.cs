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
    public class TrnListingEntityController : Controller
    {
        // GET: TrnListingEntity
        public ActionResult Index()
        {
            //currentContext
            var contextItem = Context.Item;

            var EntityCardItems = contextItem.GetChildren()
                .Select(x => new EntityCard
                {
                    EntityName = x.Fields["EntityName"].Value,
                    EntityBrief = new HtmlString(x.Fields["EntityBrief"].Value),
                    EntityUrl = LinkManager.GetItemUrl(x)
                }).ToList();

            //return EntityCardItems to view
            return View(EntityCardItems);
        }
    }
}