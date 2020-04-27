using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Classes;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class SemesterController : Controller
    {
        public JsonResult LoadAllCourses()
        {
            DB11V2Entities db = new DB11V2Entities();
            //IEnumerable<GetProducts_Result> res = db.GetProducts();
            List<Course> res = db.Courses.ToList();
            return Json(res.Select(x => new
            {
                ID = x.ID,
                Name = x.Name
            }));
        }
        public JsonResult LoadBatches()
        {
            DB11V2Entities db = new DB11V2Entities();
            //IEnumerable<GetProducts_Result> res = db.GetProducts();
            List<Batch> res = db.Batches.ToList();
            return Json(res.Select(x => new
            {
                ID = x.ID,
                Name = x.Session
            }));
        }

        public JsonResult LoadSemester(int item)
        {
            DB11V2Entities db = new DB11V2Entities();
            //IEnumerable<GetProducts_Result> res = db.GetProducts();
            List<Semester> res = db.Semesters.Where(s=>s.BatchID == item).ToList();
            return Json(res.Select(x => new
            {
                ID = x.ID,
                Name = x.Name
            }));
        }

        public JsonResult LoadCourses()
        {
            DB11V2Entities db = new DB11V2Entities();
            //IEnumerable<GetProducts_Result> res = db.GetProducts();
            List<Course> res = db.Courses.ToList();
            return Json(res.Select(x => new
            {
                ID = x.ID,
                Name = x.Name
            }));
        }

        public JsonResult LoadSemesterCourses(int semesterID)
        {
            //IEnumerable<GetProducts_Result> res = db.GetProducts();
            List<Course> courseList = new List<Course>();
            SqlDataReader reader;
            string cmd = "SELECT * FROM Course WHERE Course.ID IN (SELECT CourseID FROM CourseSemester_MTM WHERE SemesterID = "+semesterID+")";
            reader = dbConnection.getInstance().getData(cmd);
            while(reader.Read())
            {
                Course c = new Course();
                c.ID = reader.GetInt32(0);
                c.Name = reader.GetString(1);
                courseList.Add(c);
            }
            return Json(courseList.Select(x => new
            {
                ID = x.ID,
                Name = x.Name
            }));
        }
        // GET: Semester
        public ActionResult Index()
        {
            return View();
        }

        // GET: Semester/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Semester/Create
        public ActionResult Create(int id)
        {
            DB11V2Entities db = new DB11V2Entities();
            Semester sm = db.Semesters.Where(s => s.ID == id).FirstOrDefault();

            ViewBag.batch = db.Batches.Where(b => b.ID == sm.BatchID).FirstOrDefault().Session;
            ViewBag.semester = sm.Name;
            ViewBag.semesterID = sm.ID;

            return View();
        }

        // POST: Semester/Create
        [HttpPost]
        public ActionResult Create(int id, CourseSemester_MTM collection)
        {
            DB11V2Entities db = new DB11V2Entities();
            Semester sm = db.Semesters.Where(s => s.ID == id).FirstOrDefault();

            ViewBag.batch = db.Batches.Where(b => b.ID == sm.BatchID).FirstOrDefault().Session;
            ViewBag.semester = sm.Name;
            ViewBag.semesterID = sm.ID;

            bool result = CourseSemesterAction.Create(id, collection.CourseID);
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

        // GET: Semester/Edit/5
        public ActionResult Edit(int sid, int cid)
        {
            DB11V2Entities db = new DB11V2Entities();
            Course c = db.Courses.Where(temp => temp.ID == cid).FirstOrDefault();
            return View(c);
        }

        // POST: Semester/Edit/5
        [HttpPost]
        public ActionResult Edit(int sid, int cid, Course collection)
        {
            bool result = CourseSemesterAction.Edit(sid, cid, collection);
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

        // GET: Semester/Delete/5
        public ActionResult Delete(int sid, int cid)
        {
            DB11V2Entities db = new DB11V2Entities();
            Course cs = db.Courses.Where(c => c.ID == cid).FirstOrDefault();
            return View(cs);
        }

        // POST: Semester/Delete/5
        [HttpPost]
        public ActionResult Delete(int sid, int cid, FormCollection collection)
        {
            try
            {
                CourseSemesterAction.Delete(sid, cid);
                return RedirectToAction("Index");
            }
            catch
            {
                DB11V2Entities db = new DB11V2Entities();
                Course cs = db.Courses.Where(c => c.ID == cid).FirstOrDefault();

                ViewBag.color = "red";
                ViewBag.message = "Can't Delete";

                return View(cs);
            }
        }
    }
}
