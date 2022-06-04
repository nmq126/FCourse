using FCourse.Data;
using FCourse.Models;
using PagedList;
using System;
using System.Linq;
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
                return View("~/Views/Home/Error_404.cshtml");
            }
            ViewBag.CategoryList = from s in db.Categories select s;
            ViewBag.SectionList = db.Sections.Where(x => x.CourseId == id);
            ViewBag.SectionCount = db.Sections.Where(x => x.CourseId == id).Count();
            return View(course);
        }

        public ActionResult Learning(string id)
        {
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return View("~/Views/Home/Error_404.cshtml");
            }
            ViewBag.CategoryList = from s in db.Categories select s;
            ViewBag.SectionList = db.Sections.Where(x => x.CourseId == id);
            ViewBag.SectionCount = db.Sections.Where(x => x.CourseId == id).Count();
            return View(course);
        }

        public ActionResult Explore(string keyword, string categoryId, string levelId, int? page)
        {
            var courses = from s in db.Courses select s;
            ViewBag.CategoryList = from s in db.Categories select s;
            ViewBag.LevelList = from s in db.Levels select s;
            ViewBag.CategoryID = categoryId;
            ViewBag.Keyword = keyword;
            ViewBag.LevelID = levelId;

            if (!String.IsNullOrEmpty(keyword))
            {
                courses = courses.Where(s => s.Name.Contains(keyword)
                                       || s.Teacher.Name.Contains(keyword));
            }

            if (!String.IsNullOrEmpty(categoryId))
            {
                courses = courses.Where(s => s.CategoryId == categoryId);
            }

            if (!String.IsNullOrEmpty(levelId))
            {
                courses = courses.Where(s => s.LevelId == levelId);
            }

            int pageNumber = (page ?? 1);
            int pageSize = 8;

            return View(courses.OrderBy(s => s.CreatedAt).ToPagedList(pageNumber, pageSize));
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

        [Authorize(Roles = "USER")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize(Roles = "ADMIN")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}