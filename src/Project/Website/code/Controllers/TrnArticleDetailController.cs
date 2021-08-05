using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; //for HtmlString
using System.Web.Mvc;
//Article class
using Coforge.Project.Website.Models;
//nameSpace
using Sitecore;
using Sitecore.Web.UI.WebControls;

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
            //FieldRendrer(contextItem,fieldName) - returns String  
            ArticleDetail articleDetail = new ArticleDetail();
            articleDetail.ArticleTitle =  new HtmlString(FieldRenderer.Render(contextItem,"ArticleTitle"));
            articleDetail.ArticleDescription = new HtmlString(FieldRenderer.Render(contextItem,"ArticleDescription"));
            articleDetail.ArticlePublishDate = new HtmlString(FieldRenderer.Render(contextItem,"ArticlePublishDate"));
            articleDetail.ArticleImage = new HtmlString(FieldRenderer.Render(contextItem,"ArticleImage"));


            //return this object of ArticelDetail class -> View
            return View(articleDetail);

        }
    }
}