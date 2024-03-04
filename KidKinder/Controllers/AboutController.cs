using KidKinder.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class AboutController : Controller
    {
        KidKinderContext context=new KidKinderContext();
        public ActionResult Index()
        {
            var about=context.Abouts.FirstOrDefault();

        
            return View(about);
        }

        public PartialViewResult AboutHeaderPartial() 
        {
            return PartialView();
        }
    }
}