using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using IbmAdmissions2019.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace IbmAdmissions2019.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class UserManagementController : Controller
    {
        IbmAdmissions2019Entities db = new IbmAdmissions2019Entities();

        
        private List<SelectListItem> getRoles()
        {
            return db.AspNetRoles.Where(c=>!c.Name.Equals("Candidate")).Select(b => new SelectListItem()
            {
                Text = b.Name,
                Value = b.Name
            }).ToList();
        }

        // GET: UserManagement
        public ActionResult Index()
        {
            return View();
        }

        // GET: UserManagement/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserManagement/Create
        public ActionResult Create()
        {
            ViewBag.Roles = getRoles();
            return View();
        }

        // POST: UserManagement/Create
        [HttpPost]
        public async  Task<ActionResult> Create(UserViewModel obj)
        {
            try
            {
                ApplicationUserManager userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
                // TODO: Add insert logic here
                var user = new ApplicationUser { UserName = obj.UserName, Email = obj.Email };
                var result = await userManager.CreateAsync(user, obj.Password);

                var roleResult = userManager.AddToRoles(user.Id, obj.RollName);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Roles = getRoles();
                    return View();
                }
                   
            }
            catch
            {
                ViewBag.Roles = getRoles();
                return View();
            }
        }

        // GET: UserManagement/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserManagement/Edit/5
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

        // GET: UserManagement/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserManagement/Delete/5
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
