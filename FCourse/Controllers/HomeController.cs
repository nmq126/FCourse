using FCourse.Data;
using FCourse.Models;
using FCourse.Util;
using Microsoft.AspNet.Identity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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
            return View(db.Courses.Where(x => x.Status == 1).ToList());
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
            if (!User.Identity.IsAuthenticated)
            {
                TempData["data"] = "You must login to learn.";
                return RedirectToAction("Login", "User");
            }
            string userId;
            ViewBag.UserId = userId = Convert.ToString(System.Web.HttpContext.Current.User.Identity.GetUserId());
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return View("~/Views/Home/Error_404.cshtml");
            }
            UserCourse userCourse = db.UserCourses.Where(uc => uc.UserId == userId && uc.CourseId == course.Id).FirstOrDefault();
            if (userCourse == null)
            {
                return View("~/Views/Home/Error_404.cshtml");
            }
            ViewBag.CategoryList = from s in db.Categories select s;
            List<Section> listSection = db.Sections.Where(x => x.CourseId == id).ToList();
            List<String> listSectionId = new List<String>();
            foreach (var item in listSection)
            {
                listSectionId.Add(item.Id);
            }
            ViewBag.IsFinishedCourse = userCourse.IsFinished;
            ViewBag.UserSections = db.UserSections.Where(x => x.UserId == userId && listSectionId.Contains(x.SectionId));
            ViewBag.SectionList = db.Sections.Where(x => x.CourseId == id);
            ViewBag.SectionCount = db.Sections.Where(x => x.CourseId == id).Count();
            return View(course);
        }

        public double GetUserSection(string userId, string sectionId)
        {
            UserSection userSection = db.UserSections.Where(u => u.UserId == userId).Where(u => u.SectionId == sectionId).FirstOrDefault();
            return userSection != null ? userSection.PausedAt : 0;
        }

        public string GetUserSectionReading(string userId, string sectionId)
        {
            UserSection userSection = db.UserSections.Where(u => u.UserId == userId).Where(u => u.SectionId == sectionId).FirstOrDefault();
            if (userSection == null)
            {
                return null;
            }
            userSection.IsFinished = true;
            db.SaveChanges();
            return userSection.Section.Content;
        }

        public void UpdateUserSection(string userId, string sectionId, double pausedAt)
        {
            UserSection userSection = db.UserSections.Where(u => u.UserId == userId).Where(u => u.SectionId == sectionId).FirstOrDefault();
            if (userSection == null)
            {
                return;
            }
            Section section = db.Sections.Find(sectionId);
            if (pausedAt > userSection.PausedAt)
            {
                userSection.PausedAt = pausedAt;
                if (pausedAt > section.Duration * 0.75)
                {
                    userSection.IsFinished = true;
                    UpdateUserCourse(userId, sectionId);
                }
                db.SaveChanges();
            }
        }

        public void UpdateUserCourse(string userId, string sectionId)
        {
            var section = db.Sections.Find(sectionId);
            if (section == null)
            {
                return;
            }
            var courseId = section.CourseId;
            bool flag = true;
            var uc = db.UserCourses.Where(x => x.UserId == userId && x.CourseId == courseId).FirstOrDefault();
            if (uc == null)
            {
                return;
            }
            var sections = db.Sections.Where(x => x.CourseId == courseId);
            if (sections == null || sections.Count() == 0)
            {
                return;
            }
            foreach (var item in sections)
            {
                var us = db.UserSections.Where(x => x.UserId == userId && x.SectionId == item.Id).FirstOrDefault();
                if (us == null)
                {
                    return;
                }
                if (!us.IsFinished)
                {
                    flag = false;
                }
            }
            if (flag)
            {
                uc.IsFinished = true;
                db.SaveChanges();
                return;
            }
        }

        public void EndUserSection(string userId, string sectionId)
        {
            UserSection userSection = db.UserSections.Where(u => u.UserId == userId).Where(u => u.SectionId == sectionId).FirstOrDefault();
            if (userSection == null)
            {
                return;
            }
            userSection.IsFinished = true;
            userSection.PausedAt = 0;
            db.SaveChanges();
            UpdateUserCourse(userId, sectionId);
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

            return View(courses.Where(x => x.Status == 1).OrderBy(s => s.CreatedAt).ToPagedList(pageNumber, pageSize));
        }

        public async Task<ActionResult> Test()
        {
            ViewBag.Message = "TEst diu tup";
            ViewBag.CategoryList = from s in db.Categories select s;
            ViewBag.LevelList = from s in db.Levels select s;
            var result = await YoutubeGetDurationUtil.GetYoutubeVideoDurationAsync("262PMoup--4");
            Debug.WriteLine(result);
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