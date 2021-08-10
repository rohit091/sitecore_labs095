using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore;
using Coforge.Project.Website.Models; //Model
using Sitecore.Links; //LinkManager

namespace Coforge.Project.Website.Controllers
{
    public class TrnListingController : Controller
    {
        // GET: TrnListing
        public ActionResult Index()
        {
            //ContextItem - currentContext
            var contextItem = Context.Item;

            //Sitecore.Data.Items.Item = Sitecore.Context.Item
            //GetChildren() - collection return type
            //-------------------------------------------------
            //Articles:
            //Article1 Descritpion...
            //Article2 Description...
            //---------------------------
            //returns childrens under a current Item context(Articles)
            //use LINQ to iterate on collections using Select()
            //convert childList(Complete information) -> List(display- Article only Name(url),descritpion)
            var listingCardItems = contextItem.GetChildren()
                   .Select(x => new ListingCard{
                       ListingCardTitle = x.Fields["ArticleTitle"].Value,
                       ListingCardDescription = new HtmlString(x.Fields["ArticleDescription"].Value),   
                       ListingCardUrl = LinkManager.GetItemUrl(x)
                   }).ToList();


            //return listingCardItems to View
            return View(listingCardItems);
        }
    }
}