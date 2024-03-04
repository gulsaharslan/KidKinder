using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KidKinder.Entities;
using KidKinder.Context;

namespace KidKinder.Controllers
{
    public class ContactController : Controller
    {
        KidKinderContext context = new KidKinderContext();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveMessage(Contact contact)
        {
            contact.SendDate = DateTime.Now;
            context.Contacts.Add(contact);
            context.SaveChanges();
            return RedirectToAction("Index");
           
        }


        public PartialViewResult ContactHeaderPartial()
        {
            return PartialView();
        }

        public PartialViewResult ContactAddressPartial()
        {
            ViewBag.description = context.Communications.Select(x => x.Description).FirstOrDefault();
            ViewBag.phone = context.Communications.Select(x => x.Phone).FirstOrDefault();
            ViewBag.address = context.Communications.Select(x => x.Address).FirstOrDefault();
            ViewBag.email = context.Communications.Select(x => x.Email).FirstOrDefault();

            return PartialView();
        }
    }
}