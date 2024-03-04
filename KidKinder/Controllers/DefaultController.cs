using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KidKinder.Entities;
using KidKinder.Context;

namespace KidKinder.Controllers
{
    public class DefaultController : Controller
    {
        KidKinderContext context=new KidKinderContext();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialHead()
        {
            return PartialView();
        }

        public PartialViewResult PartialNavbar() 
        {
            return PartialView();

        }

        public PartialViewResult PartialFeature()
        {
            var values =context.Features.ToList();
            return PartialView(values);

        }

        public PartialViewResult PartialService()
        {
            var values = context.Services.ToList();
            return PartialView(values);

        }

        public PartialViewResult PartialAbout()
        {
            var about = context.Abouts.FirstOrDefault();
            return PartialView(about);

        }
        public PartialViewResult AboutListPartial()
        {
            var values = context.AboutLists.ToList();
            return PartialView(values);
        }

            public PartialViewResult PartialClassrooms()
        {
            var values=context.Classrooms.OrderByDescending(x=>x.ClassroomId).Take(3).ToList();
            return PartialView(values);

        }

        [HttpGet]
        public PartialViewResult PartialBookASeat()
        {
            ViewBag.Classrooms = GetClassroomSelectList();
            return PartialView();

        }

        [HttpPost]
        public ActionResult PartialBookASeat(BookASeat bookASeat)
        {
            ViewBag.Classrooms = GetClassroomSelectList();
            context.BookASeats.Add(bookASeat);
            context.SaveChanges();
            return PartialView();
        }


        public PartialViewResult PartialTeacher()
        {
            var values = context.Teachers.ToList();
           
            return PartialView(values);

        }

        public PartialViewResult PartialTestimonial()
        {
            var values = context.Testimonials.ToList();
            return PartialView(values);

        }

        public PartialViewResult PartialFooter()
        {
            return PartialView();

        }

        public PartialViewResult PartialScripts()
        {
            return PartialView();

        }

        private List<SelectListItem> GetClassroomSelectList()
        {
            List<SelectListItem> values = context.Classrooms
                .Select(x => new SelectListItem
                {
                    Text = x.Title,
                    Value = x.ClassroomId.ToString()
                })
                .ToList();

            return values;
        }
    }
}