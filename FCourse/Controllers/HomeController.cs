using FCourse.Data;
using FCourse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FCourse.Controllers
{
    public class HomeController : Controller
    {
        private DBContext db = new DBContext();

        public ActionResult Index()
        {
            ViewBag.TeacherList = from s in db.Teachers select s;
            ViewBag.CategoryList = from s in db.Categories select s;
            return View(db.Courses.ToList());
        }

        public ActionResult Detail(string id)
        {
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryList = from s in db.Categories select s;
            ViewBag.SectionList = db.Sections.Where(x => x.CourseId == id);
            ViewBag.SectionCount = db.Sections.Where(x => x.CourseId == id).Count();
            return View(course);
        }

        public ActionResult Explore()
        {
            ViewBag.CategoryList = from s in db.Categories select s;
            return View(db.Courses.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Test()
        {
            ViewBag.Message = "Your Test page.";

            return View();
        }

        public ActionResult TestAdmin()
        {
            ViewBag.Message = "Your Test page.";

            return View();
        }
    }
}