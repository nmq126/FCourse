using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FCourse.Data;
using FCourse.Models;

namespace FCourse.Controllers
{
    public class CoursesController : Controller
    {
        private DBContext db = new DBContext();
        public class CreateCourseViewModel
        {
            public Course Course { get; set; }
            public List<Section> Sections { get; set; }
        }

        // GET: Courses
        public ActionResult Index()
        {
            var courses = db.Courses.OrderByDescending(c => c.CreatedAt);
            return View(courses.ToList());
        }

        // GET: Courses/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Include(c => c.Sections).FirstOrDefault(c => c.Id == id);
            if (course == null)
            {
                return HttpNotFound();
            } 
            return View(course);
        }

        // GET: Courses/Create
        public ActionResult Create()
        {
            ViewBag.CategoryList = new SelectList(db.Categories, "Id", "Name");
            ViewBag.LevelList = new SelectList(db.Levels, "Id", "Name");
            ViewBag.TeacherList = new SelectList(db.Teachers, "Id", "Name");
            return View();
        }

        public PartialViewResult AddNewSection(int number)
        {
            ViewBag.Number = number;
            return PartialView("SectionRow", new Section());
        }

        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                course.Rating = 5;
                course.Status = 1;
                course.CreatedAt = course.UpdatedAt = course.DisabledAt = DateTime.Now;
                do
                {
                    course.Id = String.Concat("CRS_", Guid.NewGuid().ToString("N").Substring(0, 5));
                } while (db.Courses.FirstOrDefault(c => c.Id == course.Id) != null);
               
                if (course.Sections == null || course.Sections.Count() == 0)
                {
                    return RedirectToAction("Index");
                }

                // section
                var order = 1;
                foreach (var item in course.Sections)
                {
                    do
                    {
                        item.Id = String.Concat("SCT_", Guid.NewGuid().ToString("N").Substring(0, 5));
                    } while (db.Sections.FirstOrDefault(s => s.Id == item.Id) != null);
                    item.Duration = 0;
                    item.Order = order;
                    order++;
                }
                db.Courses.Add(course);
                try
                {
                    db.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }
                return RedirectToAction("Index");
            }

            ViewBag.CategoryList = new SelectList(db.Categories, "Id", "Name");
            ViewBag.LevelList = new SelectList(db.Levels, "Id", "Name");
            ViewBag.TeacherList = new SelectList(db.Teachers, "Id", "Name");
            return View(course);
        }

        // GET: Courses/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses
              .Include(c => c.Sections)
              .FirstOrDefault(c => c.Id == id);
            if (course == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryList = new SelectList(db.Categories, "Id", "Name", course.CategoryId);
            ViewBag.LevelList = new SelectList(db.Levels, "Id", "Name", course.LevelId);
            ViewBag.TeacherList = new SelectList(db.Teachers, "Id", "Name", course.TeacherId);
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Thumbnail,CategoryId,LevelId,TeacherId,Name,Description,Detail,Duration,Price,Discount,Status,CreatedAt,UpdatedAt,DisabledAt")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                course.UpdatedAt = DateTime.Now;
                if (course.Status == 0)
                {
                    course.DisabledAt = DateTime.Now;
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", course.CategoryId);
            ViewBag.LevelId = new SelectList(db.Levels, "Id", "Name", course.LevelId);
            ViewBag.TeacherList = new SelectList(db.Teachers, "Id", "Name", course.TeacherId);
            return View(course);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}