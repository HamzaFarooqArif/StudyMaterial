using IbmAdmissions2019.Models;
using IbmAdmissions2019.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IbmAdmissions2019.Controllers
{
    [Authorize(Roles ="SuperAdmin")]
    public class TestCenterController : Controller
    {
        // GET: TestCenter
        public ActionResult Index(int blockId)
        {
            ViewBag.BlockId = blockId;
            var list = TestCenterUtility.getInstance().getList(blockId);
            return View(list);
        }

        // GET: TestCenter/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TestCenter/Create
        public ActionResult Create(int blockId)
        {
            ViewBag.BlockId = blockId;
            return View();
        }

        // POST: TestCenter/Create
        [HttpPost]
        public ActionResult Create(TestCenterViewModel obj)
        {
            try
            {
                // TODO: Add insert logic here
                bool flag = TestCenterUtility.getInstance().addTestCenter(obj);
                return RedirectToAction("Index",new { blockId=obj.BlockId});
            }
            catch
            {
                return View();
            }
        }

        // GET: TestCenter/Edit/5
        public ActionResult Edit(int id)
        {
            return View(TestCenterUtility.getInstance().EditTestCenter(id));
        }

        // POST: TestCenter/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TestCenterViewModel obj)
        {
            try
            {
                TestCenterUtility.getInstance().updateTestCenter(id, obj);
                // TODO: Add update logic here
                //TestCenterUtility.getInstance().addTestCenter(obj);
                return RedirectToAction("Index","Block");
            }
            catch
            {
                return View();
            }
        }

        // GET: TestCenter/Delete/5
        public ActionResult Delete(int id)
        {
            TestCenterViewModel model =  TestCenterUtility.getInstance().EditTestCenter(id);
            return View(model);
        }

        // POST: TestCenter/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, TestCenterViewModel obj)
        {
            try
            {
                // TODO: Add delete logic here
                TestCenterUtility.getInstance().deleteTestCenter(id, obj);
                return RedirectToAction("Index","Block");
            }
            catch ( Exception ex )
            {
                throw (ex);
               
            }
        }
    }
}
