using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore; //for Sitecore.Context
using Coforge.Project.Website.Models; //for Model  
using Sitecore.SecurityModel; //for Security Disabler(){} method
using Sitecore.Publishing;

namespace Coforge.Project.Website.Controllers
{
    public class TrnCommentsFormController : Controller
    {
        //CREATE Different Views for GET/POST Requests
        //=============================================

        //======
        // GET: TrnCommentsForm
        //======
        //View For Get - Index(Form Page)
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        //=====
        //POST TrnCommentsForm - pass Comments model & object
        //=====
        //We are calling the new View for the Post - Summary(Posted Result) 
        [HttpPost]
        public ActionResult Index(Comments comment)
        {
            //Context Item(Article) - from WebDatabase
            //But it should come from the masterDatabase to create comments immediately
            var contextItem = Sitecore.Context.Item; 

            //Get the database(master) to create the item - returns Database
            var masterDatabase = Sitecore.Configuration.Factory.GetDatabase("master"); 
            var webDatabase = Sitecore.Configuration.Factory.GetDatabase("web");


            //Get the template in which item has to be created
            //ID copied from Comments Template
            Sitecore.Data.TemplateID commentsTemplateID = new Sitecore.Data.TemplateID(new Sitecore.Data.ID("{75059708-47FF-421E-9AA4-BA50D56AB973}"));

            //Get the parent item under which the item has to be created
            //get the corresponding item from database using ID of contextItem
            var parentItem = masterDatabase.GetItem(contextItem.ID);


            //SECURITY DISABLER Block
            using(new SecurityDisabler())
            {
                //Create the item
                //lock this object - edit - unlock
                //Avoid deadlock in multithreaded environment
                var createdCommentItem = parentItem.Add(comment.CommenterName, commentsTemplateID);

                createdCommentItem.Editing.BeginEdit();
                //Update the fields in the item
                createdCommentItem.Fields["CommenterName"].Value = comment.CommenterName;
                createdCommentItem.Fields["CommenterComments"].Value = comment.CommenterComments;
                createdCommentItem.Fields["CommenterEmail"].Value = comment.CommenterEmail;
                createdCommentItem.Editing.EndEdit();


                //Publish the item - To get Instant View
                PublishOptions publishOptions = new PublishOptions(masterDatabase,webDatabase,
                                                                   PublishMode.SingleItem,
                                                                   createdCommentItem.Language,
                                                                   DateTime.Now);

                //pass Publish Object to Publisher
                Publisher publisher = new Publisher(publishOptions);
                //Publishing Options
                publisher.Options.RootItem = createdCommentItem;
                publisher.Options.Deep = true;
                //Final Publish
                publisher.Publish();
            }


            //Provide full path after the root
            return View("/Views/TrnCommentsForm/Summary.cshtml");
        }
    }
}