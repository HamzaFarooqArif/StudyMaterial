using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IbmAdmissions2019.Controllers
{
    public class HomeController : Controller
    {
        IbmAdmissions2019Entities db = new IbmAdmissions2019Entities();

        public ActionResult Index()
        {
            bool flag = false;
            if(flag)
            {
                return View("AdmissionStart");
            }
            String user = User.Identity.Name;
            String role = "";
            var dbUser =db.AspNetUsers.Where(a => a.UserName.Equals(user)).FirstOrDefault();
            if(dbUser!=null)
            {
                role = dbUser.AspNetRoles.FirstOrDefault().Name;
                if(role.Equals("Candidate"))
                {
                    return RedirectToAction("StudentIndex", "Home");
                }
            }

            return View();
        }
        [Authorize(Roles ="Candidate")]
        public ActionResult StudentIndex()
        {
            ViewBag.Message = TempData["Message"];
            return View();
        }

        public ActionResult Downloads()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult AdmissionStart()
        {

            return View();
        }
    }
}