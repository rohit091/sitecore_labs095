using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//Namespace added! - sidecore + model(to access class)
using Sitecore;
using Coforge.Project.Website.Models;

namespace Coforge.Project.Website.Controllers
{
    public class StudentDatabaseController : Controller
    {
        // GET: StudentDatabase FieldValues from Items
        public ActionResult Index()
        {  //COLLECTION - KEY VALUE PAIR
           //Access collection values using - collectionName["key"].value;
             
            //Sitecore.Context.Item = gets/sets current item
            //Sitecore.Context.Item.Fields["key"].value - to set CollectionValue
            //Primitve DataType = contextItem
            var contextItem = Context.Item;

            //CLASS(Model) OBJECT - REFFERENTIAL DATA TYPE (Non Primitive)
            StudentDatabase studentDB = new StudentDatabase();
            studentDB.Name = contextItem.Fields["Name"].Value;
            studentDB.DOB = contextItem.Fields["DOB"].Value;
            studentDB.Email = contextItem.Fields["Email"].Value;
            studentDB.PhoneNo = contextItem.Fields["PhoneNo"].Value;
            studentDB.Profile = contextItem.Fields["Profile"].Value;
            studentDB.Photograph = contextItem.Fields["Photograph"].Value;

       
            //Return Action(class Object after setting all Properties) to the view
            return View(studentDB);
        }
    }
}