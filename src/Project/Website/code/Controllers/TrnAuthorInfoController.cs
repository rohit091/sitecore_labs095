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
    public class TrnAuthorInfoController : Controller
    {
        // GET: TrnAuthorInfo
        public ActionResult Index()
        {
            //NOTE:---------------
            //var contextItem = Context.Item;
            //AuthorInfo authorInfoListString = new AuthorInfo();
            //authorInfo.AuthorInformation = contextItem.Fields["AuthorInfo"].Value;
            //Output on page: list of id seprated by | symbol
            //--------------------


            //=====  WAY1 ==========
            //contextItem
            var contextItem = Context.Item;

            //get current context fields
            var authorInfoListStr = contextItem.Fields["AuthorInfo"].Value;

            //authors info List
            List<AuthorInfo> authorsInfo = new List<AuthorInfo>();

            //check if string is not empty
            if (!string.IsNullOrEmpty(authorInfoListStr))
            {
                //split() string -> array of id'
                //list of author id's = array
                var listofAuthorIds = authorInfoListStr.Split('|');

                //iterate through each id
                foreach (var authorid in listofAuthorIds)
                {
                    //get item by id 
                    var authoritem = Sitecore.Context.Database.GetItem(new Sitecore.Data.ID(authorid));
                    
                    //assign field for each item
                    AuthorInfo authorInfo = new AuthorInfo();
                    authorInfo.AuthorInformation = authoritem.Fields["EntityName"].Value;

                    //Add to List
                    authorsInfo.Add(authorInfo);
                }
            }

            //authorsInfo to View
            return View(authorsInfo);
        }
    }
}