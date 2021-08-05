using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//Article class
using Coforge.Project.Website.Models;
//nameSpace
using Sitecore;


namespace Coforge.Project.Website.Controllers
{
    public class TrnArticleDetailController : Controller
    {
        // GET: TrnArticleDetail
        public ActionResult Index()
        {
            //anonymous type - implicit time
            //String name = "rk" explicit time
            //usingNamespace here
            //var contextItem = Sitecore.Context.Item;
            
            //PRIMITIVE Variable - Access context Item
            var contextItem = Context.Item;
            
            //Reference Variable - Populating the ContextItem
            //creating object for class ArticleDetail - calls default constructor
            ArticleDetail articleDetail = new ArticleDetail();
            articleDetail.ArticleTitle = contextItem.Fields["ArticleTitle"].Value;
            articleDetail.ArticleDescription = contextItem.Fields["ArticleDescription"].Value;
            articleDetail.ArticlePublishDate = contextItem.Fields["ArticlePublishDate"].Value;
            articleDetail.ArticleImage = contextItem.Fields["ArticleImage"].Value;


            //return this object of ArticelDetail class -> View
            return View(articleDetail);

        }
    }
}