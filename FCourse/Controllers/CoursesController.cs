using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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

        // GET: Courses
        public ActionResult Index()
        {
            var courses = db.Courses;
            return View(courses.ToList());
        }

        // GET: Courses/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses
              .Include(c => c.Sections)
              .First(c => c.Id == id);
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

        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CategoryId,JobId,Name,Description,Detail,Duration,LevelId,Rating,Thumbnail,Price,Discount,TeacherId,CreatedAt,UpdatedAt,DisabledAt,Status")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "ParentId", course.CategoryId);
            ViewBag.LevelId = new SelectList(db.Levels, "Id", "Name", course.LevelId);
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
              .First(c => c.Id == id);
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
        public ActionResult Edit([Bind(Include = "Id,CategoryId,JobId,Name,Description,Detail,Duration,LevelId,Rating,Thumbnail,Price,Discount,TeacherId,CreatedAt,UpdatedAt,DisabledAt,Status")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", course.CategoryId);
            ViewBag.LevelId = new SelectList(db.Levels, "Id", "Name", course.LevelId);
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