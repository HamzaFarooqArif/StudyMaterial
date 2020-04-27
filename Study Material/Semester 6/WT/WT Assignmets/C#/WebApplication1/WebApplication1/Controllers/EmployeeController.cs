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
    public class EmployeeController : Controller
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
        // GET: Employee
        public ActionResult Index()
        {
            DB11V2Entities db = new DB11V2Entities();

            List<Employee> employeeList = db.Employees.ToList();
            List<PersonEmployeeViewModels> personEmployeeList = new List<PersonEmployeeViewModels>();

            foreach (Employee e in employeeList)
            {
                PersonEmployeeViewModels pe = new PersonEmployeeViewModels();
                pe.ID = e.PersonID;
                pe.Designation = e.Designation;
                pe.Salary = e.Salary;

                Person pr = db.People.Where(p => p.ID == e.PersonID).FirstOrDefault();
                pe.Name = pr.Name;
                pe.FatherName = pr.FatherName;
                pe.CNIC = pr.CNIC;
                pe.Address = pr.Address;
                pe.Contact = pr.Contact;

                personEmployeeList.Add(pe);
            }
            return View(personEmployeeList);
        }

        public ActionResult CoursesIndex(int id)
        {
            ViewBag.EmployeeID = id;
            DB11V2Entities db = new DB11V2Entities();
            
            List<EmployeeCourseSemesterViewModels> ecsModelList = new List<EmployeeCourseSemesterViewModels>();

            List<EmployeeCourseSemester_MTM> ecsList = db.EmployeeCourseSemester_MTM.Where(ecsA=> ecsA.EmployeeID==id).ToList();
            foreach(EmployeeCourseSemester_MTM ecs in ecsList)
            {
                EmployeeCourseSemesterViewModels ecsModel = new EmployeeCourseSemesterViewModels();

                int semesterid = db.CourseSemester_MTM.Where(temp => temp.ID == ecs.CourseSemesterID).FirstOrDefault().SemesterID;
                int courseid = db.CourseSemester_MTM.Where(temp => temp.ID == ecs.CourseSemesterID).FirstOrDefault().CourseID;
                int batchid = db.Semesters.Where(temp=>temp.ID == semesterid).FirstOrDefault().BatchID;

                ecsModel.ID = ecs.ID;
                //ecsModel.EmployeeID = id;
                ecsModel.Batch = db.Batches.Where(temp => temp.ID == batchid).FirstOrDefault().Session;
                ecsModel.Semester = db.Semesters.Where(s => s.ID == semesterid).FirstOrDefault().Name;
                ecsModel.Course = db.Courses.Where(s => s.ID == courseid).FirstOrDefault().Name;
                ViewBag.EmployeeName = db.People.Where(temp => temp.ID == id).FirstOrDefault().Name;
                ViewBag.EmployeeDesignation = db.Employees.Where(temp => temp.PersonID == id).FirstOrDefault().Designation;

                ecsModelList.Add(ecsModel);
            }

            return View(ecsModelList);
        }

        public ActionResult CoursesEdit(int id)
        {
            DB11V2Entities db = new DB11V2Entities();

            int csid = db.EmployeeCourseSemester_MTM.Where(e => e.ID == id).FirstOrDefault().CourseSemesterID;
            int semesterid = db.CourseSemester_MTM.Where(e => e.ID == csid).FirstOrDefault().SemesterID;
            int courseid = db.CourseSemester_MTM.Where(e => e.ID == csid).FirstOrDefault().CourseID;

            EmployeeCourseSemesterViewModels ecs = new EmployeeCourseSemesterViewModels();
            ecs.ID = id;
            ecs.EmployeeID = db.EmployeeCourseSemester_MTM.Where(e=>e.ID == id).FirstOrDefault().EmployeeID;
            ecs.Semester = db.Semesters.Where(s => s.ID == semesterid).FirstOrDefault().Name;
            ecs.Course = db.Courses.Where(s => s.ID == courseid).FirstOrDefault().Name;

            ecs.SemesterID = semesterid;
            ecs.BatchID = db.Semesters.Where(temp => temp.ID == semesterid).FirstOrDefault().BatchID;
            ecs.CourseID = courseid;
            ViewBag.EmployeeName = db.People.Where(temp => temp.ID == id).FirstOrDefault().Name;
            ViewBag.EmployeeDesignation = db.Employees.Where(temp => temp.PersonID == id).FirstOrDefault().Designation;

            return View(ecs);
        }

        [HttpPost]
        public ActionResult CoursesEdit(int id, EmployeeCourseSemesterViewModels collection)
        {
            DB11V2Entities db = new DB11V2Entities();

            int csid = db.EmployeeCourseSemester_MTM.Where(e => e.ID == id).FirstOrDefault().CourseSemesterID;
            int semesterid = db.CourseSemester_MTM.Where(e => e.ID == csid).FirstOrDefault().SemesterID;
            int courseid = db.CourseSemester_MTM.Where(e => e.ID == csid).FirstOrDefault().CourseID;

            EmployeeCourseSemesterViewModels ecs = new EmployeeCourseSemesterViewModels();
            ecs.ID = id;
            ecs.EmployeeID = db.EmployeeCourseSemester_MTM.Where(e => e.ID == id).FirstOrDefault().EmployeeID;
            ecs.Semester = db.Semesters.Where(s => s.ID == semesterid).FirstOrDefault().Name;
            ecs.Course = db.Courses.Where(s => s.ID == courseid).FirstOrDefault().Name;

            try
            {
                if(EmployeeCourseSemesterAction.Edit(id, collection))
                {
                    ViewBag.color = "green";
                    ViewBag.message = "Edited Successfully";

                    return View(ecs);
                }
                else
                {
                    ViewBag.color = "red";
                    ViewBag.message = "Already Assigned";

                    return View(ecs);
                }
            }
            catch
            {
                ViewBag.color = "red";
                ViewBag.message = "Exception Catched";

                return View();
            }
        }

        public ActionResult CoursesCreate(int id)
        {
            DB11V2Entities db = new DB11V2Entities();

            EmployeeCourseSemesterViewModels ecs = new EmployeeCourseSemesterViewModels();
            ecs.EmployeeID = id;
            
            return View(ecs);
        }

        [HttpPost]
        public ActionResult CoursesCreate(int id, EmployeeCourseSemesterViewModels collection)
        {
            DB11V2Entities db = new DB11V2Entities();

            EmployeeCourseSemesterViewModels ecs = new EmployeeCourseSemesterViewModels();
            ecs.EmployeeID = id;

            try
            {
                if (EmployeeCourseSemesterAction.Create(id, collection))
                {
                    ViewBag.color = "green";
                    ViewBag.message = "Added Successfully";

                    return View(ecs);
                }
                else
                {
                    ViewBag.color = "red";
                    ViewBag.message = "Already Exists";

                    return View(ecs);
                }
            }
            catch
            {
                ViewBag.color = "red";
                ViewBag.message = "Exception Catched";

                return View(ecs);
            }   
        }

        public ActionResult CoursesDelete(int id)
        {
            DB11V2Entities db = new DB11V2Entities();

            int csid = db.EmployeeCourseSemester_MTM.Where(e => e.ID == id).FirstOrDefault().CourseSemesterID;
            int semesterid = db.CourseSemester_MTM.Where(e => e.ID == csid).FirstOrDefault().SemesterID;
            int courseid = db.CourseSemester_MTM.Where(e => e.ID == csid).FirstOrDefault().CourseID;

            EmployeeCourseSemesterViewModels ecs = new EmployeeCourseSemesterViewModels();
            ecs.ID = id;
            ecs.EmployeeID = db.EmployeeCourseSemester_MTM.Where(e => e.ID == id).FirstOrDefault().EmployeeID;
            ecs.Semester = db.Semesters.Where(s => s.ID == semesterid).FirstOrDefault().Name;
            ecs.Course = db.Courses.Where(s => s.ID == courseid).FirstOrDefault().Name;

            return View(ecs);
        }

        [HttpPost]
        public ActionResult CoursesDelete(int id, FormCollection collection)
        {
            DB11V2Entities db = new DB11V2Entities();

            int csid = db.EmployeeCourseSemester_MTM.Where(e => e.ID == id).FirstOrDefault().CourseSemesterID;
            int semesterid = db.CourseSemester_MTM.Where(e => e.ID == csid).FirstOrDefault().SemesterID;
            int courseid = db.CourseSemester_MTM.Where(e => e.ID == csid).FirstOrDefault().CourseID;

            EmployeeCourseSemesterViewModels ecs = new EmployeeCourseSemesterViewModels();
            ecs.ID = id;
            ecs.EmployeeID = db.EmployeeCourseSemester_MTM.Where(e => e.ID == id).FirstOrDefault().EmployeeID;
            ecs.Semester = db.Semesters.Where(s => s.ID == semesterid).FirstOrDefault().Name;
            ecs.Course = db.Courses.Where(s => s.ID == courseid).FirstOrDefault().Name;

            try
            {
                EmployeeCourseSemesterAction.Delete(id);
                ViewBag.color = "green";
                ViewBag.message = "Deleted Successfully";
                return RedirectToAction("CoursesIndex", new { id = ecs.EmployeeID } );
            }
            catch
            {
                ViewBag.color = "red";
                ViewBag.message = "Can't Delete";
                return View(ecs);
            }
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(PersonEmployeeViewModels collection)
        {
            if (!ModelState.IsValid) return View();
            int result = EmployeeAction.Create(collection);
            if (result == 1)
            {
                return RedirectToAction("Index");
            }
            else if(result == -1)
            {
                ViewBag.color = "red";
                ViewBag.message = "Employee with CNIC Already Exists";
                return View();
            }
            else
            {
                ViewBag.color = "red";
                ViewBag.message = "Student Already Exists";
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            DB11V2Entities db = new DB11V2Entities();
            PersonEmployeeViewModels pe = new PersonEmployeeViewModels();

            Person pr = db.People.Where(p => p.ID == id).FirstOrDefault();
            pe.Name = pr.Name;
            pe.FatherName = pr.FatherName;
            pe.CNIC = pr.CNIC;
            pe.Address = pr.Address;
            pe.Contact = pr.Contact;

            Employee em = db.Employees.Where(e=>e.PersonID == id).FirstOrDefault();
            pe.Designation = em.Designation;
            pe.Salary = em.Salary;

            return View(pe);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PersonEmployeeViewModels collection)
        {
            DB11V2Entities db = new DB11V2Entities();
            PersonEmployeeViewModels pe = new PersonEmployeeViewModels();

            Person pr = db.People.Where(p => p.ID == id).FirstOrDefault();
            pe.Name = pr.Name;
            pe.FatherName = pr.FatherName;
            pe.CNIC = pr.CNIC;
            pe.Address = pr.Address;
            pe.Contact = pr.Contact;

            Employee em = db.Employees.Where(e => e.PersonID == id).FirstOrDefault();
            pe.Designation = em.Designation;
            pe.Salary = em.Salary;

            bool result = EmployeeAction.Edit(id, collection);
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.color = "red";
                ViewBag.message = "Person CNIC Already Exists";
                return View(pe);
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            DB11V2Entities db = new DB11V2Entities();
            PersonEmployeeViewModels pe = new PersonEmployeeViewModels();

            Person pr = db.People.Where(p => p.ID == id).FirstOrDefault();
            pe.Name = pr.Name;
            pe.FatherName = pr.FatherName;
            pe.CNIC = pr.CNIC;
            pe.Address = pr.Address;
            pe.Contact = pr.Contact;

            Employee em = db.Employees.Where(e => e.PersonID == id).FirstOrDefault();
            pe.Designation = em.Designation;
            pe.Salary = em.Salary;

            return View(pe);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            DB11V2Entities db = new DB11V2Entities();
            PersonEmployeeViewModels pe = new PersonEmployeeViewModels();

            Person pr = db.People.Where(p => p.ID == id).FirstOrDefault();
            pe.Name = pr.Name;
            pe.FatherName = pr.FatherName;
            pe.CNIC = pr.CNIC;
            pe.Address = pr.Address;
            pe.Contact = pr.Contact;

            Employee em = db.Employees.Where(e => e.PersonID == id).FirstOrDefault();
            pe.Designation = em.Designation;
            pe.Salary = em.Salary;

            try
            {
                EmployeeAction.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.color = "red";
                ViewBag.message = "Can't Delete";
                return View(pe);
            }
        }
    }
}
