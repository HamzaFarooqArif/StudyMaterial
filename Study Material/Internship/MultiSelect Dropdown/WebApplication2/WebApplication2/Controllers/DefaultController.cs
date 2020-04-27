using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {

            return View();
        }

        // GET: Default/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Default/Create
        public ActionResult Create()
        {

            Class1 c = new Class1();
            c.program = new List<CheckBoxListItem>();
            c.samples = new List<SampleItem>();
            c.samples.Add(new SampleItem() { Id=1});
            c.samples.Add(new SampleItem() { Id=2});

            c.Select = new List<SelectListItem>();
            c.Select.Add(new SelectListItem() { Text = "Abc", Value = "1" });
            c.Select.Add(new SelectListItem() { Text = "Xyz", Value = "2" });

            return View(c);
        }

        // POST: Default/Create
        [HttpPost]
        public ActionResult Create(Class1 c, String button)
        {
            try
            {
                // TODO: Add insert logic here

                if (button == null)
                {
                    int max = c.samples.Max(a => a.Id)+1;

                    c.samples.Add(new SampleItem() { Id=max});
                    return View(c);
                }
                else
                if (button.StartsWith("Remove"))
                {
                    String[] tok = button.Split('_');
                    int id = Int32.Parse(tok[1]);
                    SampleItem toREemove = c.samples.Where(a => a.Id == id).FirstOrDefault();
                    c.samples.Remove(toREemove);
                    return View(c);
                }
                //if (c.Ischange)

                //{
                //    c.program = new List<CheckBoxListItem>();
                //    if (c.val == 0)
                //    {
                //        return View(c);

                //    }
                //    if (c.val == 1)
                //    {

                //        c.program.Add(new CheckBoxListItem() { Display = "D", ID = 5, IsChecked = false });
                //        c.program.Add(new CheckBoxListItem() { Display = "E", ID = 6, IsChecked = false });
                //        return View(c);

                //    }
                //    if (c.val == 2)
                //    {

                //        c.program.Add(new CheckBoxListItem() { Display = "F", ID = 1, IsChecked = false });
                //        c.program.Add(new CheckBoxListItem() { Display = "G", ID = 9, IsChecked = false });
                //        c.program.Add(new CheckBoxListItem() { Display = "H", ID = 10, IsChecked = false });
                //        return View(c);

                //    }
                //}
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Default/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Default/Edit/5
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

        // GET: Default/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Default/Delete/5
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
