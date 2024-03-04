using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers.AdminPanel
{
    public class AdminServiceController : Controller
    {
        KidKinderContext context=new KidKinderContext();
        public ActionResult Index()
        {
            var values = context.Services.ToList();
            return View(values);
        }


        [HttpGet]

        public ActionResult CreateService()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CreateService(Service service)
        {

            context.Services.Add(service);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteService(int id)
        {

            var value = context.Services.Find(id);
            context.Services.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateService(int id)
        {
            var values = context.Services.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateService(Service p)
        {
            var value = context.Services.Find(p.ServiceId);
            value.Title = p.Title;
            value.Description = p.Description;
            value.IconUrl= p.IconUrl;

            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}