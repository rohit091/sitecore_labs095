using System;
using System.Collections.Generic;
using System.Linq; //Linq in C# -> .Select
using System.Web;
using System.Web.Mvc;
using Sitecore;
using Coforge.Project.Website.Models;
using Sitecore.Links; //LinkManager
using Sitecore.Data.Items; //Database

namespace Coforge.Project.Website.Controllers
{
    public class TrnBreadcrumbController : Controller
    {
        // GET: TrnBreadcrumb
        public ActionResult Index()
        {
            //currentItem context
            var contextItem = Context.Item;

            //startPath
            var startItem = Context.Database.GetItem(Context.Site.StartPath);

            //Project existing sitecoreArray -> List of NavigationItems
            //-----------------------------------------------------------
            //List<NavigationItems> Generic for List
            //ancestors = items above current items
            //returns array[ancestors]
            //array -> List => .ToList()
            //itrerate through a lis of ancestors & create a new object
            //take every item + Select(iteration) - new NavigationItem
            //LINQ Statement (Language Integrated Query)A
            //LINQ - Reduces the line of code in C#
            //Select = LINQ Projection Operation(sitecore -> navigation method)
            //concat this array with new Item[] having only currentItem (contextItem)
            List<NavigationItem> ancestorItem = contextItem.Axes
                                          .GetAncestors()
                                          .Where(x => x.Axes.IsDescendantOf(startItem))
                                          .Concat(new Item[] { contextItem})
                                          .Select(x => new NavigationItem
                                          {
                                              NavItemName = x.Name,
                                              NavItemUrl = LinkManager.GetItemUrl(x)
                                          }).ToList();

            //Pass this output to View
            //--------------------------
            return View(ancestorItem);
        }
    }
}