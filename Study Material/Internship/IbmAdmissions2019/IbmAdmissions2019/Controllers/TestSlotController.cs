using IbmAdmissions2019.Models;
using IbmAdmissions2019.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IbmAdmissions2019.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class TestSlotController : Controller
    {
        // GET: TestSlot
        public ActionResult Index(int centerId)
        {
            ViewBag.CenterId = centerId;
            var list = TestSlotUtility.getInstance().getList(centerId);
            return View(list);
        }

        // GET: TestSlot/Details/5
        public ActionResult RollNumberSlotsCreation()
        {
            TestSlotUtility.getInstance().CreateRollNumberSlots(1);
            return RedirectToAction("Index","Block");
        }

        // GET: TestSlot/Create
        public ActionResult Create(int centerId)
        {
            ViewBag.CenterId = centerId;
            return View();
        }

        // POST: TestSlot/Create
        [HttpPost]
        public ActionResult Create(TestSlotViewModel obj)
        {
            try
            {
                bool flag = TestSlotUtility.getInstance().addTestSlot(obj);
                // TODO: Add insert logic here

                return RedirectToAction("Index", new { centerId = obj.CenterId });
            }
            catch
            {
                return View();
            }
        }

        // GET: TestSlot/Edit/5
        public ActionResult Edit(int id)
        {
            
            return View(TestSlotUtility.getInstance().EditTestSlot(id));
        }

        // POST: TestSlot/Edit/5
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

        // GET: TestSlot/Delete/5
        public ActionResult Delete(int id)
        {
            TestSlotViewModel t = TestSlotUtility.getInstance().EditTestSlot(id);
            return View(t);
        }

        // POST: TestSlot/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, TestSlotViewModel obj)
        {
            try
            {
                TestSlotUtility.getInstance().DeleteTestSlots(id, obj);

                return RedirectToAction("Index", "Block");
            }
            catch
            {
                return View();
            }
        }
    }
}
