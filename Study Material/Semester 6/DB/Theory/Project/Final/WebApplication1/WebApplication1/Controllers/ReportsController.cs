using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.CrystalReports;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ReportsController : Controller
    {
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

        public string getBatchByID(int id)
        {
            DB11V2Entities db = new DB11V2Entities();
            return db.Batches.Where(temp => temp.ID == id).FirstOrDefault().Session;
        }

        public string getCourseByID(int id)
        {
            DB11V2Entities db = new DB11V2Entities();
            return db.Courses.Where(temp => temp.ID == id).FirstOrDefault().Name;
        }
        public List<ReportViewModels> getReportList()
        {
            int numberOfReports = 10;
            ReportViewModels[] ReportsList = new ReportViewModels[numberOfReports];

            ReportsList[0] = new ReportViewModels(1, "Batch wise student report");
            ReportsList[1] = new ReportViewModels(2, "Course wise student report");
            ReportsList[2] = new ReportViewModels(3, "Batch wise attendance report");
            ReportsList[3] = new ReportViewModels(4, "Semester wise attendance report");
            ReportsList[4] = new ReportViewModels(5, "Course wise employee report");
            ReportsList[5] = new ReportViewModels(6, "Semester wise employee report");
            ReportsList[6] = new ReportViewModels(7, "Course wise result report");
            ReportsList[7] = new ReportViewModels(8, "Batch wise result report");
            ReportsList[8] = new ReportViewModels(9, "Student Fee report");
            ReportsList[9] = new ReportViewModels(10, "Employee Salary report");

            List<ReportViewModels> resultList = new List<ReportViewModels>();
            for (int i = 0; i < numberOfReports; i++)
            {
                resultList.Add(ReportsList[i]);
            }

            return resultList;
        }
        public ActionResult Index()
        {
            List<ReportViewModels> result = getReportList();

            return View(result);
        }

        public ActionResult Create(int id)
        {
            if (id == 1) return RedirectToAction("CreateBatchWiseStudentReport");
            if (id == 2) return RedirectToAction("CreateCourseWiseStudentReport");
            if (id == 3) return RedirectToAction("CreateBatchWiseAttendaceReport");
            if (id == 4) return RedirectToAction("CreateSemesterWiseAttendaceReport");
            if (id == 5) return RedirectToAction("CreateCourseWiseEmployeeReport");
            if (id == 6) return RedirectToAction("CreateSemesterWiseEmployeeReport");
            if (id == 7) return RedirectToAction("CreateCourseWiseResultReport");
            if (id == 8) return RedirectToAction("CreateBatchWiseResultReport");
            if (id == 9) return RedirectToAction("CreateStudentFeeReport");
            if (id == 10) return RedirectToAction("CreateSalaryReport");
            else
            {
                return RedirectToAction("Index");
            }
        }
        //-----------------------------------------------------------------
        public ActionResult CreateBatchWiseStudentReport()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateBatchWiseStudentReport(ReportViewModels model)
        {
            BatchWiseStudentReport r = new BatchWiseStudentReport();
            r.Load();
            r.SetParameterValue("@Batch", getBatchByID(Int32.Parse(model.param)));
            Stream s = r.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(s, "application/pdf");
        }
        //-----------------------------------------------------------------
        public ActionResult CreateCourseWiseStudentReport()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCourseWiseStudentReport(ReportViewModels model)
        {
            CourseWiseStudentReport r = new CourseWiseStudentReport();
            r.Load();
            r.SetParameterValue("@Course", getCourseByID(Int32.Parse(model.param)));
            Stream s = r.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(s, "application/pdf");
        }
        //-----------------------------------------------------------------
        public ActionResult CreateBatchWiseAttendaceReport()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateBatchWiseAttendaceReport(ReportViewModels model)
        {
            BatchWiseAttendaceReport r = new BatchWiseAttendaceReport();
            r.Load();
            r.SetParameterValue("@Batch", getBatchByID(Int32.Parse(model.param)));
            Stream s = r.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(s, "application/pdf");
        }
        //-----------------------------------------------------------------
        public ActionResult CreateSemesterWiseAttendaceReport()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSemesterWiseAttendaceReport(ReportViewModels model)
        {
            SemesterWiseAttendaceReport r = new SemesterWiseAttendaceReport();
            r.Load();
            r.SetParameterValue("@Semester", model.param);
            Stream s = r.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(s, "application/pdf");
        }
        //-----------------------------------------------------------------
        public ActionResult CreateCourseWiseEmployeeReport()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCourseWiseEmployeeReport(ReportViewModels model)
        {
            CourseWiseEmployeeReport r = new CourseWiseEmployeeReport();
            r.Load();
            r.SetParameterValue("@Course", getCourseByID(Int32.Parse(model.param)));
            Stream s = r.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(s, "application/pdf");
        }
        //-----------------------------------------------------------------
        public ActionResult CreateSemesterWiseEmployeeReport()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSemesterWiseEmployeeReport(ReportViewModels model)
        {
            SemesterWiseEmployeeReport r = new SemesterWiseEmployeeReport();
            r.Load();
            r.SetParameterValue("@Semester", model.param);
            Stream s = r.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(s, "application/pdf");
        }
        //-----------------------------------------------------------------
        public ActionResult CreateCourseWiseResultReport()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCourseWiseResultReport(ReportViewModels model)
        {
            CourseWiseResultReport r = new CourseWiseResultReport();
            r.Load();
            r.SetParameterValue("@Course", getCourseByID(Int32.Parse(model.param)));
            Stream s = r.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(s, "application/pdf");
        }
        //-----------------------------------------------------------------
        public ActionResult CreateBatchWiseResultReport()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateBatchWiseResultReport(ReportViewModels model)
        {
            BatchWiseResultReport r = new BatchWiseResultReport();
            r.Load();
            r.SetParameterValue("@Batch", getBatchByID(Int32.Parse(model.param)));
            Stream s = r.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(s, "application/pdf");
        }
        //-----------------------------------------------------------------
        public ActionResult CreateStudentFeeReport()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateStudentFeeReport(ReportViewModels model)
        {
            StudentFeeReport r = new StudentFeeReport();
            r.Load();
            Stream s = r.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(s, "application/pdf");
        }
        //-----------------------------------------------------------------
        public ActionResult CreateSalaryReport()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateSalaryReport(ReportViewModels model)
        {
            SalaryReport r = new SalaryReport();
            r.Load();
            Stream s = r.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(s, "application/pdf");
        }
        //-----------------------------------------------------------------
    }
}