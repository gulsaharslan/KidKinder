using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers.AdminGallery
{
    public class AdminGalleryController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            var values = context.Galleries.ToList();
            return View(values);
        }


        [HttpGet]

        public ActionResult CreatePhoto()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult CreatePhoto(Gallery gallery)
        {

            context.Galleries.Add(gallery);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeletePhoto(int id)
        {

            var value = context.Galleries.Find(id);
            context.Galleries.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdatePhoto(int id)
        {
            var values = context.Galleries.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdatePhoto(Gallery p)
        {
            var value = context.Galleries.Find(p.GalleryId);
            value.Title = p.Title;
            value.ImageUrl = p.ImageUrl;
      
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ChangeStatus(int id)
        {
            var gallery = context.Galleries.Find(id);
            if (gallery.Status == true)
            {
                gallery.Status = false;
            }
            else
            {
                gallery.Status = true;
            }

            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}