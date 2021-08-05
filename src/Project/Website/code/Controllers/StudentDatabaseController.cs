using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//Namespace added! - sidecore + model(to access class)
using Sitecore;
using Coforge.Project.Website.Models;
using Sitecore.Web.UI.WebControls;

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
            studentDB.Name = new HtmlString(FieldRenderer.Render(contextItem, "Name"));
            studentDB.DOB = new HtmlString(FieldRenderer.Render(contextItem, "DOB"));
            studentDB.Email = new HtmlString(FieldRenderer.Render(contextItem, "Email"));
            studentDB.PhoneNo = new HtmlString(FieldRenderer.Render(contextItem, "PhoneNo"));
            studentDB.Profile = new HtmlString(FieldRenderer.Render(contextItem, "Profile"));
            studentDB.Photograph = new HtmlString(FieldRenderer.Render(contextItem, "Photograph"));


            //Return Action(class Object after setting all Properties) to the view
            return View(studentDB);
        }
    }
}