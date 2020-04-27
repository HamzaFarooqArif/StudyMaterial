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
    public class BlockController : Controller
    {
        // GET: Block
        public ActionResult Index()
        {
            var list = BlockUtility.getInstance().getList();
            return View(list);
        }

        // GET: Block/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Block/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Block/Create
        [HttpPost]
        public ActionResult Create(BlockViewModel block)
        {
            try
            {
                BlockUtility.getInstance().AddBlock(block);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                throw (ex);
                
            }
        }

        // GET: Block/Edit/5
        public ActionResult Edit(int id)
        {

            return View(BlockUtility.getInstance().editBlock(id));
        }

        // POST: Block/Edit/5
        [HttpPost]
        public ActionResult Edit(BlockViewModel block)
        {
            try
            {
                BlockUtility.getInstance().AddBlock(block);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Block/Delete/5
        public ActionResult Delete(int id)
        {

            return View(BlockUtility.getInstance().editBlock(id));
        }

        // POST: Block/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, BlockViewModel obj)
        {
            try
            {
               BlockUtility.getInstance().DeleteBlock (obj, id);
               return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
