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
    public class TimetableController : Controller
    {
        public JsonResult LoadEmployee(int sid, int cid)
        {
            DB11V2Entities db = new DB11V2Entities();

            CourseSemester_MTM CourseSemester = db.CourseSemester_MTM.Where(temp => temp.SemesterID == sid && temp.CourseID == cid).FirstOrDefault();
            List<EmployeeCourseSemester_MTM> employeeCourseSemesterList = new List<EmployeeCourseSemester_MTM>();
            if(CourseSemester != null) employeeCourseSemesterList = db.EmployeeCourseSemester_MTM.Where(temp => temp.CourseSemesterID == CourseSemester.ID).ToList();
            
            List<Person> personList = new List<Person>();

            foreach(EmployeeCourseSemester_MTM ecs in employeeCourseSemesterList)
            {
                personList.Add(db.People.Where(temp=>temp.ID == ecs.EmployeeID).FirstOrDefault());
            }
            
            return Json(personList.Select(x => new
            {
                ID = x.ID,
                Name = x.Name,
                CNIC = x.CNIC
            }));
        }
        public JsonResult LoadWorkingDay()
        {
            DB11V2Entities db = new DB11V2Entities();
            //IEnumerable<GetProducts_Result> res = db.GetProducts();
            List<WorkingDay> res = db.WorkingDays.ToList();
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
        public JsonResult LoadTimeslot(int timetableId, int SET, int DOW)
        {
            DB11V2Entities db = new DB11V2Entities();
            Timeslot ts = new Timeslot();
            List<Timeslot> res = new List<Timeslot>();
            //-----------------------------------------------------------
            if (SET == 1)
            {
                ts.StartTime = new DateTime(2000, 1, 1, 8, 0, 0);
                ts.EndTime = new DateTime(2000, 1, 1, 9, 0, 0);
            }
            if (SET == 2)
            {
                ts.StartTime = new DateTime(2000, 1, 1, 9, 0, 0);
                ts.EndTime = new DateTime(2000, 1, 1, 10, 0, 0);
            }
            if (SET == 3)
            {
                ts.StartTime = new DateTime(2000, 1, 1, 10, 0, 0);
                ts.EndTime = new DateTime(2000, 1, 1, 11, 0, 0);
            }
            if (SET == 4)
            {
                ts.StartTime = new DateTime(2000, 1, 1, 11, 0, 0);
                ts.EndTime = new DateTime(2000, 1, 1, 12, 0, 0);
            }
            if (SET == 5)
            {
                ts.StartTime = new DateTime(2000, 1, 1, 1, 0, 0);
                ts.EndTime = new DateTime(2000, 1, 1, 2, 0, 0);
            }
            if (SET == 6)
            {
                ts.StartTime = new DateTime(2000, 1, 1, 2, 0, 0);
                ts.EndTime = new DateTime(2000, 1, 1, 3, 0, 0);
            }
            if (SET == 7)
            {
                ts.StartTime = new DateTime(2000, 1, 1, 3, 0, 0);
                ts.EndTime = new DateTime(2000, 1, 1, 4, 0, 0);
            }
            //-----------------------------------------------------------
            List<TimetableTimeslot_MTM> timetableTimeslotList = db.TimetableTimeslot_MTM.Where(temp=>temp.TimetableID == timetableId).ToList();
            List<Timeslot> timeslotList = new List<Timeslot>();
            foreach(TimetableTimeslot_MTM ttts in timetableTimeslotList)
            {
                timeslotList.Add(db.Timeslots.Where(temp=>temp.ID == ttts.TimeslotID).FirstOrDefault());
            }
            foreach(Timeslot tsA in timeslotList)
            {
                if (tsA.StartTime == ts.StartTime && tsA.EndTime == ts.EndTime && tsA.WorkingDaysID == DOW)
                {
                    res.Add(tsA);
                }
            }

            if(res.Count > 0)
            {
                int ecsid = res[0].EmployeeCourseSemesterID;
                int csid = db.EmployeeCourseSemester_MTM.Where(temp => temp.ID == ecsid).FirstOrDefault().CourseSemesterID;
                int cid = db.CourseSemester_MTM.Where(temp => temp.ID == csid).FirstOrDefault().CourseID;
                string cname = db.Courses.Where(temp => temp.ID == cid).FirstOrDefault().Name;

                return Json(res.Select(x => new
                {
                    ID = x.ID,
                    Name = cname
                }));
            }
            else
            {
                return Json(res.Select(x => new
                {
                    ID = x.ID,
                    Name = x.ID
                }));
            }
            
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
        public JsonResult LoadSemesterCourses(int semesterID)
        {
            //IEnumerable<GetProducts_Result> res = db.GetProducts();
            List<Course> courseList = new List<Course>();
            SqlDataReader reader;
            string cmd = "SELECT * FROM Course WHERE Course.ID IN (SELECT CourseID FROM CourseSemester_MTM WHERE SemesterID = " + semesterID + ")";
            reader = dbConnection.getInstance().getData(cmd);
            while (reader.Read())
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

        public JsonResult LoadTimetables(int isDatesheet, int batchId)
        {
            DB11V2Entities db = new DB11V2Entities();
            //IEnumerable<GetProducts_Result> res = db.GetProducts();
            List<Semester> semesterList = db.Semesters.Where(temp => temp.BatchID == batchId).ToList();
            List<Timetable> res = new List<Timetable>();
            bool ind = false;
            if (isDatesheet == 0) ind = false;
            if (isDatesheet == 1) ind = true;

            foreach(Semester sm in semesterList)
            {
                if(db.Timetables.Any(temp=>temp.SemesterID == sm.ID && temp.IsDatesheet == ind))
                {
                    res.Add(db.Timetables.Where(temp => temp.SemesterID == sm.ID && temp.IsDatesheet == ind).FirstOrDefault());
                }
            }
            return Json(res.Select(x => new
            {
                ID = x.ID,
                Name = db.Semesters.Where(temp => temp.ID == x.SemesterID).FirstOrDefault().Name
        }));
        }
        
        public ActionResult PreviewIndex(int id)
        {
            DB11V2Entities db = new DB11V2Entities();

            int semesterid = db.Timetables.Where(temp => temp.ID == id).FirstOrDefault().SemesterID;
            int batchid = db.Semesters.Where(temp => temp.ID == semesterid).FirstOrDefault().BatchID;

            TimetableViewModels ttvm = new TimetableViewModels();
            ttvm.ID = id;
            ttvm.Semester = db.Semesters.Where(temp => temp.ID == semesterid).FirstOrDefault().Name;
            ttvm.Batch = db.Batches.Where(temp => temp.ID == batchid).FirstOrDefault().Session;
            ttvm.isDatesheet = db.Timetables.Where(temp => temp.ID == id).FirstOrDefault().IsDatesheet.ToString();

            return View(ttvm);
        }
        public ActionResult PreviewCreate(int id, int set, int dow)
        {
            DB11V2Entities db = new DB11V2Entities();
            int semesterid = db.Timetables.Where(temp => temp.ID == id).FirstOrDefault().SemesterID;
            int batchid = db.Semesters.Where(temp => temp.ID == semesterid).FirstOrDefault().BatchID;
            
            TimeslotViewModels tsvm = new TimeslotViewModels();
            tsvm.StartEndTime = set;
            tsvm.WorkingDayID = dow;
            tsvm.BatchID = batchid;
            tsvm.SemesterID = semesterid;
            tsvm.TimetableID = id;

            return View(tsvm);
        }

        [HttpPost]
        public ActionResult PreviewCreate(TimeslotViewModels model)
        {
            DB11V2Entities db = new DB11V2Entities();
            
            TimeslotViewModels tsvm = new TimeslotViewModels();
            tsvm.StartEndTime = model.StartEndTime;
            tsvm.WorkingDayID = model.WorkingDayID;
            tsvm.BatchID = model.BatchID;
            tsvm.SemesterID = model.SemesterID;
            tsvm.CourseID = model.CourseID;
            tsvm.EmployeeID = model.EmployeeID;

            if(db.Timetables.Any(temp=>temp.SemesterID == model.SemesterID))
            {
                tsvm.TimetableID = db.Timetables.Where(temp => temp.SemesterID == model.SemesterID).FirstOrDefault().ID;
            }
            if (model.BatchID == 0 || model.SemesterID == 0 || model.CourseID == 0 || model.EmployeeID == 0)
            {
                ViewBag.color = "red";
                ViewBag.message = "Check Input Fields";
                return View(tsvm);
            }
            int result = TimetableAction.TimeslotCreate(tsvm);
            if(result == -1)
            {
                ViewBag.color = "red";
                ViewBag.message = "Timetable doesn't exist";
            }
            if(result == -2)
            {
                ViewBag.color = "red";
                ViewBag.message = "Timeslot already exists";
            }
            else
            {
                ViewBag.color = "green";
                ViewBag.message = "Added Successfully";
                return RedirectToAction("PreviewIndex", new { id = tsvm.TimetableID});
            }
            return View(tsvm);
        }
        public ActionResult PreviewEdit(int id, int set, int dow, int timeslotID)
        {
            DB11V2Entities db = new DB11V2Entities();
            Timeslot ts = db.Timeslots.Where(temp=>temp.ID == timeslotID).FirstOrDefault();

            int ecsid = ts.EmployeeCourseSemesterID;
            int eid = db.EmployeeCourseSemester_MTM.Where(temp => temp.ID == ecsid).FirstOrDefault().EmployeeID;
            int csid = db.EmployeeCourseSemester_MTM.Where(temp => temp.ID == ecsid).FirstOrDefault().CourseSemesterID;
            int cid = db.CourseSemester_MTM.Where(temp => temp.ID == csid).FirstOrDefault().CourseID;
            string cname = db.Courses.Where(temp => temp.ID == cid).FirstOrDefault().Name;


            int semesterid = db.Timetables.Where(temp => temp.ID == id).FirstOrDefault().SemesterID;
            int batchid = db.Semesters.Where(temp => temp.ID == semesterid).FirstOrDefault().BatchID;

            TimeslotViewModels tsvm = new TimeslotViewModels();
            tsvm.StartEndTime = set;
            tsvm.WorkingDayID = dow;
            tsvm.BatchID = batchid;
            tsvm.SemesterID = semesterid;
            tsvm.TimetableID = id;
            tsvm.EmployeeID = eid;
            tsvm.CourseID = cid;
            tsvm.ID = timeslotID;

            return View(tsvm);
        }

        [HttpPost]
        public ActionResult PreviewEdit(int timeslotID, TimeslotViewModels model)
        {
            DB11V2Entities db = new DB11V2Entities();

            TimeslotViewModels tsvm = new TimeslotViewModels();
            tsvm.StartEndTime = model.StartEndTime;
            tsvm.WorkingDayID = model.WorkingDayID;
            tsvm.BatchID = model.BatchID;
            tsvm.SemesterID = model.SemesterID;
            tsvm.CourseID = model.CourseID;
            tsvm.EmployeeID = model.EmployeeID;

            if (db.Timetables.Any(temp => temp.SemesterID == model.SemesterID))
            {
                tsvm.TimetableID = db.Timetables.Where(temp => temp.SemesterID == model.SemesterID).FirstOrDefault().ID;
            }
            if (model.BatchID == 0 || model.SemesterID == 0 || model.CourseID == 0 || model.EmployeeID == 0) return View(tsvm);
            int result = TimetableAction.TimeslotEdit(timeslotID, tsvm);
            if (result == -1)
            {
                ViewBag.color = "red";
                ViewBag.message = "Timetable doesn't exist";
            }
            else
            {
                ViewBag.color = "green";
                ViewBag.message = "Added Successfully";
                return RedirectToAction("PreviewIndex", new { id = tsvm.TimetableID });
            }
            return View(tsvm);
        }
        public ActionResult PreviewDelete(int id, int set, int dow, int timeslotID)
        {
            DB11V2Entities db = new DB11V2Entities();
            Timeslot ts = db.Timeslots.Where(temp => temp.ID == timeslotID).FirstOrDefault();

            int ecsid = ts.EmployeeCourseSemesterID;
            int eid = db.EmployeeCourseSemester_MTM.Where(temp => temp.ID == ecsid).FirstOrDefault().EmployeeID;
            int csid = db.EmployeeCourseSemester_MTM.Where(temp => temp.ID == ecsid).FirstOrDefault().CourseSemesterID;
            int cid = db.CourseSemester_MTM.Where(temp => temp.ID == csid).FirstOrDefault().CourseID;
            string cname = db.Courses.Where(temp => temp.ID == cid).FirstOrDefault().Name;


            int semesterid = db.Timetables.Where(temp => temp.ID == id).FirstOrDefault().SemesterID;
            int batchid = db.Semesters.Where(temp => temp.ID == semesterid).FirstOrDefault().BatchID;

            TimeslotViewModels tsvm = new TimeslotViewModels();
            tsvm.StartEndTime = set;
            tsvm.WorkingDayID = dow;
            tsvm.BatchID = batchid;
            tsvm.SemesterID = semesterid;
            tsvm.TimetableID = id;
            tsvm.EmployeeID = eid;
            tsvm.CourseID = cid;
            tsvm.ID = timeslotID;

            TimeslotDeleteViewModels tsdvm = new TimeslotDeleteViewModels();
            tsdvm.Batch = db.Batches.Where(temp=>temp.ID == tsvm.BatchID).FirstOrDefault().Session;
            tsdvm.Semester = db.Semesters.Where(temp => temp.ID == tsvm.SemesterID).FirstOrDefault().Name;
            tsdvm.Course = db.Courses.Where(temp => temp.ID == tsvm.CourseID).FirstOrDefault().Name;
            tsdvm.Employee = db.People.Where(temp => temp.ID == tsvm.EmployeeID).FirstOrDefault().Name;
            tsdvm.WorkingDay = db.WorkingDays.Where(temp => temp.ID == tsvm.WorkingDayID).FirstOrDefault().Name;
            tsdvm.StartTime = db.Timeslots.Where(temp => temp.ID == timeslotID).FirstOrDefault().StartTime.ToString();
            tsdvm.EndTime = db.Timeslots.Where(temp => temp.ID == timeslotID).FirstOrDefault().EndTime.ToString();
            tsdvm.TimetableID = tsvm.TimetableID;

            return View(tsdvm);
        }

        [HttpPost]
        public ActionResult PreviewDelete(int id, int set, int dow, int timeslotID, TimeslotViewModels model)
        {
            DB11V2Entities db = new DB11V2Entities();
            Timeslot ts = db.Timeslots.Where(temp => temp.ID == timeslotID).FirstOrDefault();

            int ecsid = ts.EmployeeCourseSemesterID;
            int eid = db.EmployeeCourseSemester_MTM.Where(temp => temp.ID == ecsid).FirstOrDefault().EmployeeID;
            int csid = db.EmployeeCourseSemester_MTM.Where(temp => temp.ID == ecsid).FirstOrDefault().CourseSemesterID;
            int cid = db.CourseSemester_MTM.Where(temp => temp.ID == csid).FirstOrDefault().CourseID;
            string cname = db.Courses.Where(temp => temp.ID == cid).FirstOrDefault().Name;


            int semesterid = db.Timetables.Where(temp => temp.ID == id).FirstOrDefault().SemesterID;
            int batchid = db.Semesters.Where(temp => temp.ID == semesterid).FirstOrDefault().BatchID;

            TimeslotViewModels tsvm = new TimeslotViewModels();
            tsvm.StartEndTime = set;
            tsvm.WorkingDayID = dow;
            tsvm.BatchID = batchid;
            tsvm.SemesterID = semesterid;
            tsvm.TimetableID = id;
            tsvm.EmployeeID = eid;
            tsvm.CourseID = cid;
            tsvm.ID = timeslotID;

            TimeslotDeleteViewModels tsdvm = new TimeslotDeleteViewModels();
            tsdvm.Batch = db.Batches.Where(temp => temp.ID == tsvm.BatchID).FirstOrDefault().Session;
            tsdvm.Semester = db.Semesters.Where(temp => temp.ID == tsvm.SemesterID).FirstOrDefault().Name;
            tsdvm.Course = db.Courses.Where(temp => temp.ID == tsvm.CourseID).FirstOrDefault().Name;
            tsdvm.Employee = db.People.Where(temp => temp.ID == tsvm.EmployeeID).FirstOrDefault().Name;
            tsdvm.WorkingDay = db.WorkingDays.Where(temp => temp.ID == tsvm.WorkingDayID).FirstOrDefault().Name;
            tsdvm.StartTime = db.Timeslots.Where(temp => temp.ID == timeslotID).FirstOrDefault().StartTime.ToString();
            tsdvm.EndTime = db.Timeslots.Where(temp => temp.ID == timeslotID).FirstOrDefault().EndTime.ToString();
            tsdvm.TimetableID = tsvm.TimetableID;
            try
            {
                bool result = TimetableAction.TimeslotDelete(timeslotID, tsvm);
                return RedirectToAction("PreviewIndex", new { id = tsvm.TimetableID });
            }
            catch
            {
                ViewBag.color = "red";
                ViewBag.message = "Exception catched";
                return View(tsdvm);
            }
        }
        // GET: Timetable
        public ActionResult Index()
        {
            return View();
        }

        // GET: Timetable/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Timetable/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Timetable/Create
        [HttpPost]
        public ActionResult Create(TimetableViewModels collection)
        {
            try
            {
                if (TimetableAction.Create(collection))
                {
                    ViewBag.color = "green";
                    ViewBag.message = "Added Successfully";
                    return View();
                }
                else
                {
                    ViewBag.color = "red";
                    ViewBag.message = "Already Exists";
                    return View();
                }
            }
            catch
            {
                ViewBag.color = "red";
                ViewBag.message = "Exception Catched";
                return View();
            }
        }

        // GET: Timetable/Edit/5
        public ActionResult Edit(int id)
        {
            DB11V2Entities db = new DB11V2Entities();

            int semesterid = db.Timetables.Where(temp => temp.ID == id).FirstOrDefault().SemesterID;
            int batchid = db.Semesters.Where(temp => temp.ID == semesterid).FirstOrDefault().BatchID;

            TimetableViewModels ttvm = new TimetableViewModels();
            ttvm.ID = id;
            ttvm.Semester = db.Semesters.Where(temp => temp.ID == semesterid).FirstOrDefault().Name;
            ttvm.Batch = db.Batches.Where(temp => temp.ID == batchid).FirstOrDefault().Session;
            ttvm.isDatesheet = db.Timetables.Where(temp => temp.ID == id).FirstOrDefault().IsDatesheet.ToString();
            ttvm.BatchID = batchid;
            ttvm.SemesterID = semesterid;

            return View(ttvm);
        }

        // POST: Timetable/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TimetableViewModels collection)
        {
            try
            {
                if (TimetableAction.Edit(id, collection))
                {
                    ViewBag.color = "green";
                    ViewBag.message = "Edited Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    DB11V2Entities db = new DB11V2Entities();

                    int semesterid = db.Timetables.Where(temp => temp.ID == id).FirstOrDefault().SemesterID;
                    int batchid = db.Semesters.Where(temp => temp.ID == semesterid).FirstOrDefault().BatchID;

                    TimetableViewModels ttvm = new TimetableViewModels();
                    ttvm.ID = id;
                    ttvm.Semester = db.Semesters.Where(temp => temp.ID == semesterid).FirstOrDefault().Name;
                    ttvm.Batch = db.Batches.Where(temp => temp.ID == batchid).FirstOrDefault().Session;
                    ttvm.isDatesheet = db.Timetables.Where(temp => temp.ID == id).FirstOrDefault().IsDatesheet.ToString();
                    ttvm.BatchID = batchid;
                    ttvm.SemesterID = semesterid;

                    ViewBag.color = "red";
                    ViewBag.message = "Already Exists";
                    return View(ttvm);
                }
            }
            catch
            {
                DB11V2Entities db = new DB11V2Entities();

                int semesterid = db.Timetables.Where(temp => temp.ID == id).FirstOrDefault().SemesterID;
                int batchid = db.Semesters.Where(temp => temp.ID == semesterid).FirstOrDefault().BatchID;

                TimetableViewModels ttvm = new TimetableViewModels();
                ttvm.ID = id;
                ttvm.Semester = db.Semesters.Where(temp => temp.ID == semesterid).FirstOrDefault().Name;
                ttvm.Batch = db.Batches.Where(temp => temp.ID == batchid).FirstOrDefault().Session;
                ttvm.isDatesheet = db.Timetables.Where(temp => temp.ID == id).FirstOrDefault().IsDatesheet.ToString();
                ttvm.BatchID = batchid;
                ttvm.SemesterID = semesterid;

                ViewBag.color = "red";
                ViewBag.message = "Exception Catched";
                return View(ttvm);
            }
        }

        // GET: Timetable/Delete/5
        public ActionResult Delete(int id)
        {
            DB11V2Entities db = new DB11V2Entities();

            int semesterid = db.Timetables.Where(temp=>temp.ID == id).FirstOrDefault().SemesterID;
            int batchid = db.Semesters.Where(temp => temp.ID == semesterid).FirstOrDefault().BatchID;

            TimetableViewModels ttvm = new TimetableViewModels();
            ttvm.ID = id;
            ttvm.Semester = db.Semesters.Where(temp => temp.ID == semesterid).FirstOrDefault().Name;
            ttvm.Batch = db.Batches.Where(temp => temp.ID == batchid).FirstOrDefault().Session;
            ttvm.isDatesheet = db.Timetables.Where(temp => temp.ID == id).FirstOrDefault().IsDatesheet.ToString();

            return View(ttvm);
        }

        // POST: Timetable/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            DB11V2Entities db = new DB11V2Entities();

            int semesterid = db.Timetables.Where(temp => temp.ID == id).FirstOrDefault().SemesterID;
            int batchid = db.Semesters.Where(temp => temp.ID == semesterid).FirstOrDefault().BatchID;

            TimetableViewModels ttvm = new TimetableViewModels();
            ttvm.ID = id;
            ttvm.Semester = db.Semesters.Where(temp => temp.ID == semesterid).FirstOrDefault().Name;
            ttvm.Batch = db.Batches.Where(temp => temp.ID == batchid).FirstOrDefault().Session;
            ttvm.isDatesheet = db.Timetables.Where(temp => temp.ID == id).FirstOrDefault().IsDatesheet.ToString();

            try
            {
                TimetableAction.Delete(id);
                ViewBag.color = "green";
                ViewBag.message = "Deleted Successfully";
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.color = "red";
                ViewBag.message = "Exception Catched";
                return View(ttvm);
            }
        }
    }
}
