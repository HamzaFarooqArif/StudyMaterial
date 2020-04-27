using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AttendanceController : Controller
    {

        public ActionResult Index(int item)
        {

            return RedirectToAction("Create");
        }

        // GET: Attendance/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
            List<Semester> res = db.Semesters.Where(s => s.BatchID == item).ToList();
            return Json(res.Select(x => new
            {
                ID = x.ID,
                Name = x.Name
            }));
        }

        public JsonResult LoadStudent(int semesterID)
        {
            DB11V2Entities db = new DB11V2Entities();
            List<Student> res = db.Students.Where(s => s.SemesterID == semesterID).ToList();
            return Json(res.Select(x => new
            {
                ID = x.PersonID,
                Name = x.RegNo,
                IsChecked = false
            }));
            //DB11V2Entities1 db = new DB11V2Entities1();
            //var list = db.Students.Where(b=>b.SemesterID == item).ToList();
            //ViewBag.ItemList = list;
        }



        //public JsonResult GetId(string itemList)
        //{
        //    string[] arr = itemList.Split(' ');
        //    return Json("", JsonRequestBehavior.AllowGet);

        //}
        public JsonResult LoadCourse(int item)
        {
            DB11V2Entities db = new DB11V2Entities();
            List<CourseSemester_MTM> cm = db.CourseSemester_MTM.Where(b => b.SemesterID == item).ToList();
            List<Course> c = new List<Course>();

            foreach (CourseSemester_MTM m in cm)
            {
                Course ct = new Course();
                ct.ID = m.CourseID;
                ct.Name = db.Courses.Where(b => b.ID == m.CourseID).SingleOrDefault().Name;
                c.Add(ct);
            }
            return Json(c.Select(x => new
            {
                ID = x.ID,
                Name = x.Name

            }));

        }



        public ActionResult MarkAttendance()
        {
            return View();
        }

        public ActionResult AddAttendance()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAttendance(AttendanceViewModels attendance)
        {

            return View();
        }


        [HttpPost]
        public ActionResult MarkAttendance(AttendanceViewModels Atd)
        {

            DB11V2Entities db = new DB11V2Entities();
            var list = db.Students.Where(b => b.SemesterID == Atd.semester).ToList();
            ViewBag.ItemList = list;


            return PartialView("MarkAttendance");
        }
        // GET: Attendance/Create
        public ActionResult Create()
        {




            return View();
        }

        // POST: Attendance/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            List<int> lst = new List<int>();
            for (int i = 0; i < collection.Count; i++)
            {
                if (collection.Keys[i].StartsWith("Check_"))
                {
                    var t = collection.Keys[i].Split('_');
                    lst.Add(Convert.ToInt32(t[1]));

                }
            }
            DB11V2Entities db = new DB11V2Entities();

            var date = collection["AtdDate"];
            var course = collection["course"];
            var semster = collection["semester"];
            int courseId = Convert.ToInt32(course.ToString());
            int sid = Convert.ToInt32(semster.ToString());
            //var StudentId = collection["StudentID"]; 
            List<Student> std = new List<Student>();
            foreach (Student s in db.Students)
            {
                Student st = new Student();
                if (s.SemesterID == Convert.ToInt32(semster))
                {
                    st.PersonID = s.PersonID;
                    std.Add(st);
                }
            }
            foreach (Student s in std)
            {
                int val = 0;
                Attendance at = new Attendance();
                for (int k = 0; k < lst.Count; k++)
                {
                    val = Convert.ToInt32(s.PersonID.ToString());
                    if (val == lst[k])
                    {
                        at.AtdStatus = "Present";
                        break;
                    }
                    at.AtdStatus = "Absent";


                }
                at.AtdDate = Convert.ToDateTime(date);
                at.StudentID = val;

                at.CourseSemesterID = db.CourseSemester_MTM.Where(b => b.CourseID == courseId && b.SemesterID == sid).FirstOrDefault().ID;
                if (db.Attendances.Any(b => b.AtdDate == at.AtdDate && b.StudentID == at.StudentID && b.CourseSemesterID == at.CourseSemesterID))
                {
                    ViewBag.color = "red";
                    ViewBag.message = "Attendance has been marked Already";
                    break;
                    //ViewBag.color = "green";
                    //ViewBag.message = "Attendance marked Successfully";
                    // ModelState.Clear();
                    //break;
                }
                else
                {
                    db.Attendances.Add(at);
                    db.SaveChanges();
                }



                //at.AtdStatus = 


            }
            ViewBag.color = "green";
            ViewBag.message = "Attendance has bee marked successfully";
            ModelState.Clear();
            return View();





        }

        // GET: Attendance/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Attendance/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Attendance/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Attendance/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
