using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers.AdminPanel
{
    public class AdminAboutController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            var values = context.Abouts.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var value = context.Abouts.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateAbout(About about)
        {
            var value = context.Abouts.Find(about.AboutId);
            value.Description = about.Description;
            value.Header = about.Header;
            value.BigImageUrl = about.BigImageUrl;
            value.Title = about.Title;
            value.SmallImageUrl = about.SmallImageUrl;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}