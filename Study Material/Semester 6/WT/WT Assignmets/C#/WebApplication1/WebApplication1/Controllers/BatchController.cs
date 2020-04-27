using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Classes;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BatchController : Controller
    {
        // GET: Batch
        public ActionResult Index()
        {
            DB11V2Entities db = new DB11V2Entities();
            List<Batch> lst = db.Batches.ToList();
            return View(lst);
        }

        // GET: Batch/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Batch/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Batch/Create
        [HttpPost]
        public ActionResult Create(BatchViewModels collection)
        {
            bool result = BatchAction.Create(collection);
            if(result)
            {
                ViewBag.color = "green";
                ViewBag.message = "Batch Added Successfully";
            }
            else
            {
                ViewBag.color = "red";
                ViewBag.message = "Batch Already Exists";
            }
            return View();
        }

        // GET: Batch/Edit/5
        public ActionResult Edit(int id)
        {
            DB11V2Entities db = new DB11V2Entities();
            BatchViewModels bt = new BatchViewModels();
            bt.BatchName = db.Batches.Where(b => b.ID == id).FirstOrDefault().Session;
            
            return View(bt);
        }

        // POST: Batch/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, BatchViewModels collection)
        {
            bool result = BatchAction.Edit(id, collection);
            if(result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.color = "red";
                ViewBag.message = "Batch Already Exists";
                return View();
            }
        }

        // GET: Batch/Delete/5
        public ActionResult Delete(int id)
        {
            DB11V2Entities db = new DB11V2Entities();
            Batch bt = db.Batches.Where(b => b.ID == id).FirstOrDefault();
            return View(bt);
        }

        // POST: Batch/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                BatchAction.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                DB11V2Entities db = new DB11V2Entities();
                Batch bt = db.Batches.Where(b => b.ID == id).FirstOrDefault();

                ViewBag.color = "red";
                ViewBag.message = "Can't Delete";

                return View(bt);
            }
        }
    }
}
