using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using KidKinder.Context;
using KidKinder.Entities;

namespace KidKinder.Controllers
{
    public class DashboardController : Controller
    {
      KidKinderContext context=new KidKinderContext();
        public ActionResult Index()
        {
            
            ViewBag.AvgPrice = context.Classrooms.Average(x => x.Price).ToString("0.00");
            ViewBag.GirlStudent = context.Students.Where(x => x.Gender == "K").Count();
            ViewBag.BoyStudent = context.Students.Where(x => x.Gender == "E").Count();
            ViewBag.Teacher = context.Teachers.Count();
            ViewBag.Classroom=context.Classrooms.Count();
            ViewBag.Message = context.Contacts.Where(x => x.IsRead == false).Count();
            ViewBag.Subscribe = context.MailSubscribes.Count();

            //ViewBag.totalStudentCount = context.Students.Count();
            //ViewBag.student4Age = context.Students.Where(x => x.Age == 4).Count();
            //ViewBag.student5Age = context.Students.Where(x => x.Age == 5).Count();
            //ViewBag.student6Age = context.Students.Where(x => x.Age == 6).Count();
            //ViewBag.student7Age = context.Students.Where(x => x.Age == 7).Count();
            //ViewBag.student8Age = context.Students.Where(x => x.Age == 8).Count();
            //ViewBag.student9Age = context.Students.Where(x => x.Age == 9).Count();


            var classrooms = context.Classrooms.ToList();

            var data = new[]
            {
                new object[] { "Sınıf Adı", "Öğrenci Sayısı" }
            };

            foreach (var classroom in classrooms)
            {
                var studentCount = context.Students.Count(s => s.ClassroomId == classroom.ClassroomId);

                data = data.Append(new object[] { classroom.Title, studentCount }).ToArray();
            }

            ViewBag.Classrooms = data;

            return View();
        }
    }
}