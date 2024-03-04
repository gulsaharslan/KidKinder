using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;

namespace KidKinder.Controllers.AdminPanel
{
    public class AdminStudentController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            var values = context.Students.ToList();
            return View(values);
        }


        [HttpGet]

        public ActionResult CreateStudent()
        {

            List<SelectListItem> values = (from x in context.Classrooms.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Title,
                                               Value = x.ClassroomId.ToString()

                                           }).ToList();
            ViewBag.v = values;

            return View();
        }

        [HttpPost]
        public ActionResult CreateStudent(Student student)
        {

            context.Students.Add(student);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteStudent(int id)
        {

            var value = context.Students.Find(id);
            context.Students.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateStudent(int id)
        {
            List<SelectListItem> values = (from x in context.Classrooms.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Title,
                                               Value = x.ClassroomId.ToString()

                                           }).ToList();
            ViewBag.v = values;
            var value = context.Students.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateStudent(Student p)
        {
            var value = context.Students.Find(p.StudentId);
            value.NameSurname = p.NameSurname;
            value.Gender = p.Gender;
            value.ClassroomId= p.ClassroomId;
            value.Age= p.Age;

            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}