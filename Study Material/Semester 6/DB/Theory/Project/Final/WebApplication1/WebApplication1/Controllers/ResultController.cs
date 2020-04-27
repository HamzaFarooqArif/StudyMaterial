using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ResultController : Controller
    {
        // GET: Result
        public ActionResult Index(int SemesterID, int CourseID)
        {
            DB11V2Entities db = new DB11V2Entities();
            List<ResultViewModels> list = new List<ResultViewModels>();
            int i = db.CourseSemester_MTM.Where(b => b.CourseID == CourseID && b.SemesterID == SemesterID).SingleOrDefault().ID;
            List<Result> res = db.Results.Where(b => b.CourseSemesterID == i).ToList();
            foreach (Result r in res)
            {
                ResultViewModels rs = new ResultViewModels();
                rs.ID = r.ID;
                //rs.ObtainedMarks = r.ObtainedMarks;
                //rs.TotalMarks = r.TotalMarks;

                rs.RegNo = db.Students.Where(b => b.PersonID == r.StudentID).SingleOrDefault().RegNo;
                //    rs.CourseSemesterID = db.CourseSemester_MTM.Where(b => b.CourseID == CourseID && b.SemesterID == SemesterID).SingleOrDefault().ID;
                rs.ObtainedMarks = db.Results.Where(b => b.ID == r.ID).SingleOrDefault().ObtainedMarks;
                //    rs.StudentID = db.Results.Where(b => b.CourseSemesterID == rs.CourseSemesterID).SingleOrDefault().StudentID;
                //    rs.RegNo = db.Students.Where(b => b.PersonID ==rs.StudentID).SingleOrDefault().RegNo;
                rs.Name = db.People.Where(b => b.ID == r.StudentID).SingleOrDefault().Name;
                rs.TotalMarks = db.Results.Where(b => b.ID == r.ID).SingleOrDefault().TotalMarks;
                list.Add(rs);

            }



            return View(list.ToList());
        }

        //public ActionResult Index()
        //{
        //    DB11V2Entities db = new DB11V2Entities();
        //    List<ResultViewModels> list = new List<ResultViewModels>();
        //    foreach (Result r in db.Results)
        //    {
        //        ResultViewModels rs = new ResultViewModels();
        //        rs.ID = r.ID;
        //        rs.ObtainedMarks = r.ObtainedMarks;
        //        rs.TotalMarks = r.TotalMarks;
        //        rs.RegNo = db.Students.Where(b => b.PersonID == r.StudentID).SingleOrDefault().RegNo;
        //        rs.semesterID = db.CourseSemester_MTM.Where(b => b.ID == r.CourseSemesterID).SingleOrDefault().SemesterID;
        //        rs.Semester = db.Semesters.Where(b => b.ID == rs.semesterID).SingleOrDefault().Name;
        //        rs.courseID = db.CourseSemester_MTM.Where(a => a.ID == r.CourseSemesterID).SingleOrDefault().CourseID;
        //        rs.Course = db.Courses.Where(b => b.ID == rs.courseID).SingleOrDefault().Name;
        //        int bId = db.Semesters.Where(b => b.ID == rs.semesterID).SingleOrDefault().BatchID;
        //        rs.Batch = db.Batches.Where(b => b.ID == bId).SingleOrDefault().Session;
        //        list.Add(rs);


        //        //int r = db.Semesters.Where(b=>b.) 
        //        //rs.CourseSemesterID = r.CourseSemesterID;
        //    }



        //    return View(list.ToList());
        //}

        // GET: Result/Details/5
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

        public JsonResult LoadStudent(int item)
        {
            DB11V2Entities db = new DB11V2Entities();
            List<Student> res = db.Students.Where(s => s.SemesterID == item).ToList();
            return Json(res.Select(x => new
            {
                ID = x.PersonID,
                Name = x.RegNo

            }));
        }
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

        // GET: Result/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Result/Create
        [HttpPost]
        public ActionResult Create(ResultViewModels collection)
        {
            try
            {
                bool result = Classes.ResultAction.Create(collection);
                if (result)
                {
                    ViewBag.color = "green";
                    ViewBag.message = "Result Added Successfully";
                    ModelState.Clear();
                }
                else
                {
                    ViewBag.color = "red";
                    ViewBag.message = "Result is Added Already";
                    ModelState.Clear();
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ViewResult()
        {
            return View();

        }

        [HttpPost]
        public ActionResult ViewResult(FormCollection f)
        {



            var Semester = f["SemesterID"];
            int SemesterID = Convert.ToInt32(Semester);
            var Course = f["CourseID"];
            int CourseID = Convert.ToInt32(Course);
            //Index(SemesterID, CourseID);
            return RedirectToAction("Index", new { SemesterID = SemesterID, CourseID = CourseID });

        }




        // GET: Result/Edit/5
        public ActionResult Edit(int id)
        {
            DB11V2Entities db = new DB11V2Entities();
            ResultViewModels res = new ResultViewModels();
            foreach (Result r in db.Results)
            {
                if (id == r.ID)
                {
                    res.TotalMarks = r.TotalMarks;
                    res.ObtainedMarks = r.ObtainedMarks;
                }
            }

            return View(res);
        }

        // POST: Result/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ResultViewModels r)
        {
            try
            {
                bool result = Classes.ResultAction.Edit(id, r);
                if (result)
                {
                    ViewBag.color = "green";
                    ViewBag.message = "Result Updated Successfully";
                    ModelState.Clear();
                }
                else
                {
                    ViewBag.color = "red";
                    ViewBag.message = "Please Enter Valid Marks";
                    ModelState.Clear();
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Result/Delete/5
        public ActionResult Delete(int id)
        {

            DB11V2Entities db = new DB11V2Entities();
            //List<Result> res = db.Results.Where(b => b.ID == id).ToList();
            ResultViewModels r = new ResultViewModels();
            r.ObtainedMarks = db.Results.Find(id).ObtainedMarks;
            r.TotalMarks = db.Results.Find(id).TotalMarks;
            int s = db.Results.Find(id).StudentID;
            r.RegNo = db.Students.Where(b => b.PersonID == s).SingleOrDefault().RegNo;
            r.Name = db.People.Where(b => b.ID == s).SingleOrDefault().Name;
            int sID = db.Students.Where(b => b.PersonID == s).SingleOrDefault().SemesterID;
            r.Semester = db.Semesters.Where(b => b.ID == sID).SingleOrDefault().Name;
            int bs = db.Semesters.Where(b => b.ID == sID).SingleOrDefault().BatchID;
            r.Batch = db.Batches.Where(b => b.ID == bs).SingleOrDefault().Session;
            int cs = db.Results.Where(b => b.ID == id).SingleOrDefault().CourseSemesterID;
            int course = db.CourseSemester_MTM.Where(b => b.ID == cs).SingleOrDefault().CourseID;
            r.Course = db.Courses.Where(b => b.ID == course).SingleOrDefault().Name;
            return View(r);
        }

        // POST: Result/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ResultViewModels re)
        {
            try
            {
                bool result = Classes.ResultAction.Delete(id, re);
                if (result)
                {
                    ViewBag.color = "green";
                    ViewBag.message = "Result Deleted Successfully";

                }
                else
                {
                    ViewBag.color = "red";
                    ViewBag.message = "Result can't be deleted ";

                }

                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
