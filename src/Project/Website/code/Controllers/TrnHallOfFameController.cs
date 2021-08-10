using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Coforge.Project.Website.Models;
using Sitecore;
using Sitecore.Links;
using Sitecore.Mvc.Presentation;



namespace Coforge.Project.Website.Controllers
{
    public class TrnHallOfFameController : Controller
    {
        // GET: TrnHallOfFame
        public ActionResult Index()
        {
            //var contextItem = Context.Item;
            var contextItem = RenderingContext.Current.Rendering.Item;

 
            var entityCard = new EntityCard
            {
                EntityName = contextItem.Fields["EntityName"].Value,
                EntityBrief = new HtmlString(contextItem.Fields["EntityBrief"].Value),
                EntityUrl = LinkManager.GetItemUrl(contextItem)
            };


            //SingleEntity Display
            return View(entityCard);
        }
    }
}

