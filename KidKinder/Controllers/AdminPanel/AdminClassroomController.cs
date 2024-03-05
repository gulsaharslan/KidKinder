using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers.AdminPanel
{
    [Authorize]
    public class AdminClassroomController : Controller
    {
        KidKinderContext context=new KidKinderContext();
        public ActionResult Index()
        {
            var values = context.Classrooms.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateClassroom() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateClassroom(Classroom classroom) 
        {
            context.Classrooms.Add(classroom);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateClassroom(int id) 
        {
            var value = context.Classrooms.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateClassroom (Classroom classroom)
        {
            var value = context.Classrooms.Find(classroom.ClassroomId);
            value.Title = classroom.Title;
            value.AgeofKids = classroom.AgeofKids;
            value.ClassTime = classroom.ClassTime;
            value.Description = classroom.Description;
            value.TotalSeat = classroom.TotalSeat;
            value.Price = classroom.Price;
            value.ImageUrl = classroom.ImageUrl;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteClassroom (int id)
        {
            var value=context.Classrooms.Find(id);
            context.Classrooms.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}