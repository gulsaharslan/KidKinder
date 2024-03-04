using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
   
    public class AdminTeacherController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult TeacherList()
        {
            var values = context.Teachers.ToList();
            return View(values);
        }

        [HttpGet]

        public ActionResult CreateTeacher()
        {
            List<SelectListItem> values = (from x in context.Branches.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.BranchName,
                                               Value = x.BranchId.ToString()

                                           }).ToList();
            ViewBag.v = values;
            return View();
        }

        [HttpPost]
        public ActionResult CreateTeacher(Teacher teacher)
        {

            context.Teachers.Add(teacher);
            context.SaveChanges();
            return RedirectToAction("TeacherList");
        }

        public ActionResult DeleteTeacher(int id)
        {

            var value = context.Teachers.Find(id);
            context.Teachers.Remove(value);
            context.SaveChanges();
            return RedirectToAction("TeacherList");
        }

        [HttpGet]
        public ActionResult UpdateTeacher(int id)
        {
            List<SelectListItem> values = (from x in context.Branches.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.BranchName,
                                               Value = x.BranchId.ToString()

                                           }).ToList();
            ViewBag.v = values;
            var value = context.Teachers.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateTeacher(Teacher p)
        {
            var value = context.Teachers.Find(p.TeacherId);
            value.NameSurname = p.NameSurname;
            value.ImageUrl = p.ImageUrl;
            value.BranchId = p.BranchId;
            context.SaveChanges();
            return RedirectToAction("TeacherList");
        }

    }
}