using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers.AdminPanel
{
    public class AdminContactController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            var values = context.Contacts.ToList();
            return View(values);
        }

        public ActionResult ReadMessage(int id)
        {
            var contact = context.Contacts.Find(id);

            contact.IsRead = true;

            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}