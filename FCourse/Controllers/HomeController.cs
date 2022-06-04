using FCourse.Data;
using FCourse.Models;
using Microsoft.AspNet.Identity;
using PagedList;
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
            ViewBag.UserId = Convert.ToString(System.Web.HttpContext.Current.User.Identity.GetUserId());
            ViewBag.UserName = HttpContext.GetOwinContext().Authentication.User.Identity.Name;
            ViewBag.TeacherList = from s in db.Teachers select s;
            ViewBag.CategoryList = from s in db.Categories select s;
            return View(db.Courses.ToList());
        }

        public ActionResult Detail(string id)
        {
            ViewBag.UserId = Convert.ToString(System.Web.HttpContext.Current.User.Identity.GetUserId());

            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return View("~/Views/Home/Error_404.cshtml");
            }
            ViewBag.CategoryList = from s in db.Categories select s;
            ViewBag.SectionList = db.Sections.Where(x => x.CourseId == id);
            Section section = db.Sections.Where(x => x.CourseId == id).FirstOrDefault();
            if (section != null && section.Type == 0)
            {
              ViewBag.DefaultType = 0;
            }
            ViewBag.DefaultType = 1;
            ViewBag.SectionCount = db.Sections.Where(x => x.CourseId == id).Count();
            return View(course);
        }

        public ActionResult Learning(string id)
        {
            ViewBag.UserId = Convert.ToString(System.Web.HttpContext.Current.User.Identity.GetUserId());
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

        public double GetUserSection(string userId, string sectionId)
        {
            UserSection userSection = db.UserSections.Where(u => u.UserId == userId).Where(u => u.SectionId == sectionId).FirstOrDefault();
            return userSection.PausedAt;
        }

        public void UpdateUserSection(string userId, string sectionId, double pausedAt)
        {
            UserSection userSection = db.UserSections.Where(u => u.UserId == userId).Where(u => u.SectionId == sectionId).FirstOrDefault();
            Section section = db.Sections.Find(sectionId);
            userSection.PausedAt = pausedAt;
            if (pausedAt > section.Duration * 0.75)
            {
                userSection.IsFinished = true;
            }
            db.SaveChanges();
        }

        public void EndUserSection(string userId, string sectionId)
        {
            UserSection userSection = db.UserSections.Where(u => u.UserId == userId).Where(u => u.SectionId == sectionId).FirstOrDefault();
            userSection.IsFinished = true;
            userSection.PausedAt = 0;
            db.SaveChanges();
        }

        public ActionResult UserProfile()
        {
            ViewBag.CategoryList = from s in db.Categories select s;
            string userId = Convert.ToString(System.Web.HttpContext.Current.User.Identity.GetUserId());
            ViewBag.UserId = userId;

            User user = db.Users.Find(userId);
            List<UserCourse> userCourses = db.UserCourses.Where(c => c.UserId == userId).ToList();
            List<Course> courses = new List<Course>();
            if (userCourses != null)
            {
                foreach (var item in userCourses)
                {
                    Course course = item.Course;
                    courses.Add(course);
                }
            }
            ViewBag.Courses = courses;
            return View(user);
        }

        public ActionResult Explore(string keyword, string categoryId, string levelId, int? page)
        {
            ViewBag.UserId = Convert.ToString(System.Web.HttpContext.Current.User.Identity.GetUserId());

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