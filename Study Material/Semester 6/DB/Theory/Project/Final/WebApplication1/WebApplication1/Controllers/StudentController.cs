using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Classes;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class StudentController : Controller
    {

        //static int Bid;
        // GET: Student
        public ActionResult Index()
        {
            DB11V2Entities db = new DB11V2Entities();
            List<StudentViewModels> st = new List<StudentViewModels>();
            foreach (Student s in db.Students)
            {
                foreach (Person p in db.People)
                {
                    if (s.PersonID == p.ID)
                    {
                        StudentViewModels std = new StudentViewModels();
                        std.ID = p.ID;
                        std.Name = p.Name;
                        std.FatherName = p.FatherName;
                        std.CNIC = p.CNIC;
                        std.Contact = p.Contact;
                        std.Address = p.Address;
                        std.RegNo = s.RegNo;
                        std.Fee = s.Fee;
                        std.BatchName = db.Batches.Where(b => b.ID == s.BatchID).SingleOrDefault().Session;
                        std.SemesterNo = db.Semesters.Where(b => b.ID == s.SemesterID).SingleOrDefault().Name;
                        st.Add(std);
                        break;
                    }
                }
            }
            return View(st);
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Student/Create
        public ActionResult Create()
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
            //Bid = item;
            DB11V2Entities db = new DB11V2Entities();
            //IEnumerable<GetProducts_Result> res = db.GetProducts();
            List<Semester> res = db.Semesters.Where(s => s.BatchID == item).ToList();
            return Json(res.Select(x => new
            {
                ID = x.ID,
                Name = x.Name
            }));
        }
        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(StudentViewModels collection)
        {
            try
            {
                if (collection.IsValidRegNumber(collection.RegNo))
                {
                    bool result = StudentAction.Create(collection);
                    if (result)
                    {
                        ViewBag.color = "green";
                        ViewBag.message = "Student Added Successfully";
                        ModelState.Clear();
                    }
                    else
                    {
                        ViewBag.color = "red";
                        ViewBag.message = "Student Already Exists";
                    }

                }
                else
                {
                    ViewBag.color = "red";
                    ViewBag.message = "Enter Valid Registration Number i.e 2016-CS-987";
                }


                return View();

                //return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            DB11V2Entities db = new DB11V2Entities();
            StudentViewModels std = new StudentViewModels();
            foreach (Person p in db.People)
            {
                if (p.ID == id)
                {
                    foreach (Student s in db.Students)
                    {
                        if (s.PersonID == p.ID)
                        {
                            std.Name = p.Name;
                            std.CNIC = p.CNIC;
                            std.Address = p.Address;
                            std.FatherName = p.FatherName;
                            std.Contact = p.Contact;
                            std.Fee = s.Fee;
                            std.RegNo = s.RegNo;
                            std.BatchName = db.Batches.Where(b => b.ID == s.BatchID).SingleOrDefault().Session;
                            std.SemesterNo = db.Semesters.Where(b => b.ID == s.SemesterID).SingleOrDefault().Name;
                            break;
                        }
                    }
                }
            }
            return View(std);
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, StudentViewModels student)
        {
            try
            {
                bool result = StudentAction.Edit(id, student);
                if (result)
                {
                    ViewBag.color = "green";
                    ViewBag.message = "Student Updated Successfully";
                    ModelState.Clear();
                }
                else
                {
                    ViewBag.color = "red";
                    ViewBag.message = "Student Already Exists";
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {

            DB11V2Entities db = new DB11V2Entities();
            foreach (Person p in db.People)
            {
                if (p.ID == id)
                {
                    db.People.Remove(p);
                    //foreach(Person p in db.People)
                    //{
                    //    if(p.ID == id)
                    //    {
                    //        db.People.Remove(p);
                    //    }
                    //}
                }
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: Student/Delete/5
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
