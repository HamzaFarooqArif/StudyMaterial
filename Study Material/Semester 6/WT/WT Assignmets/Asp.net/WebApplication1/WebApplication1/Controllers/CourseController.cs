using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Classes;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        public ActionResult Index()
        {
            DB11V2Entities db = new DB11V2Entities();
            List<Course> result = db.Courses.ToList();
            return View(result);
        }

        // GET: Course/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Course/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Course/Create
        [HttpPost]
        public ActionResult Create(CourseViewModels collection)
        {
            bool result = CourseAction.Create(collection);
            if (result)
            {
                ViewBag.color = "green";
                ViewBag.message = "Course Added Successfully";
            }
            else
            {
                ViewBag.color = "red";
                ViewBag.message = "Course Already Exists";
            }
            return View();
        }

        // GET: Course/Edit/5
        public ActionResult Edit(int id)
        {
            DB11V2Entities db = new DB11V2Entities();
            Course cr = db.Courses.Where(c => c.ID == id).FirstOrDefault();

            CourseViewModels crm = new CourseViewModels();
            crm.CourseName = cr.Name;

            return View(crm);
        }

        // POST: Course/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CourseViewModels collection)
        {
            bool result = CourseAction.Edit(id, collection);
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.color = "red";
                ViewBag.message = "Course Already Exists";
                return View();
            }
        }

        // GET: Course/Delete/5
        public ActionResult Delete(int id)
        {
            DB11V2Entities db = new DB11V2Entities();
            Course cr = db.Courses.Where(c => c.ID == id).FirstOrDefault();

            CourseViewModels crm = new CourseViewModels();
            crm.CourseName = cr.Name;

            return View(crm);
        }

        // POST: Course/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                CourseAction.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                DB11V2Entities db = new DB11V2Entities();
                Course cr = db.Courses.Where(c => c.ID == id).FirstOrDefault();

                CourseViewModels crm = new CourseViewModels();
                crm.CourseName = cr.Name;

                ViewBag.color = "red";
                ViewBag.message = "Can't Delete";
                return View(crm);
            }
        }
    }
}
