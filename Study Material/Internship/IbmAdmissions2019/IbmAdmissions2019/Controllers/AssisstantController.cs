using IbmAdmissions2019.Models;
using IbmAdmissions2019.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IbmAdmissions2019.Controllers
{
    public class AssisstantController : Controller
    {
        // GET: Assisstant
        public ActionResult Index()
        {
            //ViewBag.flag = false;
            return View();
        }
        public JsonResult LoadTestCenter()
        {
           
            IbmAdmissions2019Entities db = new IbmAdmissions2019Entities();
            List<TestCenter> tstCenter = db.TestCenters.ToList();
            return Json(tstCenter.Select(x => new
            {
                ID = x.CenterId,
                CenterName = x.CenterName
            }));
        }
        public JsonResult LoadTestSlot(int item)
        {
            IbmAdmissions2019Entities db = new IbmAdmissions2019Entities();
            List<TestCenterSlot> slot = db.TestCenterSlots.Where(b => b.CenterId == item).ToList();
            return Json(slot.Select(x => new
            {
                ID = x.SlotId,
                time = x.TestDateTime
            }));
        }

        //public JsonResult TestCenterList()
        //{
        //    int slotID;
        //    IbmAdmissions2019Entities db = new IbmAdmissions2019Entities();
        //    List<StudentTestCenterUtility> lst = new List<StudentTestCenterUtility>();
        //    foreach(StudentTest t in db.StudentTests)
        //    {
        //        StudentTestCenterUtility st = new StudentTestCenterUtility();
        //        if(t.SlotId == slotID)
        //        {
        //            //ViewBag.flag = true;
        //            st.TrackingNumber = t.TrackingNumber;
        //            st.RollNo = (int)t.RollNumber;
        //            int i = t.StudentId;
        //            foreach(Student s in db.Students)
        //            {
        //                if(s.Id == i)
        //                {
        //                    st.CNIC = s.StudentCnic;
        //                    st.Name = s.Name;
        //                }
        //            }
        //        }
        //        lst.Add(st);
        //    }

        //    return Json(lst.Select(x => new
        //    {
        //        CNIC = x.CNIC,
        //        tNo = x.TrackingNumber,
        //        Name = x.Name,
        //        RollNo = x.RollNo

        //    }));
        //}
        public ActionResult TestCenterList()
        {
            return View();
        }
       
        


        

      
        public JsonResult LoadApplicantList(int ID)
        {
           
            IbmAdmissions2019Entities db = new IbmAdmissions2019Entities();
            List<ApplicationListViewModel> lst = AssisstantUtility.getInstance().getAppplicantList(ID);
            return Json(lst.Select(x => new
            {
                ID = x.id,
                Name = x.Name,
                CNIC = x.CNIC,
                Status = x.PaymentStatus,
                TNo = x.TrackingNumber

            }),JsonRequestBehavior.AllowGet);
        }
        public ActionResult ApplicationList()
         {
            return View();
           
        }
        public JsonResult LoadDegree()
        {
          
            IbmAdmissions2019Entities db = new IbmAdmissions2019Entities();
            List<Degree> p = db.Degrees.ToList();
            return Json(p.Select(x => new
            {
                ID = x.DegreeId,
                Name = x.DegreeName
            }));
        }
       

        public ActionResult PrintAdmitCard()
        {
            return View();
        }

        // GET: Assisstant/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Assisstant/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Assisstant/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Assisstant/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Assisstant/Edit/5
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

        // GET: Assisstant/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Assisstant/Delete/5
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
