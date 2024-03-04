using KidKinder.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class ClassroomsController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            
            return View();
        }

        public PartialViewResult ClassroomsHeaderPartial () 
        {

            return PartialView();
        }
        public PartialViewResult ClassroomsPartial()
        {
            var values = context.Classrooms.OrderByDescending(x => x.ClassroomId).ToList();
            return PartialView(values);
        }
    }
}