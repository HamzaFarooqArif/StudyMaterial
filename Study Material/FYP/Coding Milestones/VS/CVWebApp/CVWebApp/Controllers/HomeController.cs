using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CVWebApp.Utilities;
using CVWebApp.Models;

namespace CVWebApp.Controllers
{
    public class HomeController : Controller
    {
        public JsonResult sendImage(String imgString)
        {
            String result = Utilities.Filters.GammaCorrection(imgString);
            return Json(result);
        }

        public JsonResult getChapter()
        {
            CVWebAppEntities db = new CVWebAppEntities();
            List<Chapter> result = db.Chapters.ToList();
            return Json(result.Select(x => new
            {
                ID = x.Id,
                Name = x.Name
            }));
        }
        public JsonResult getTopic(int ItemId)
        {
            CVWebAppEntities db = new CVWebAppEntities();
            List<Topic> result = db.Topics.Where(a=>a.ChapterId == ItemId).ToList();
            return Json(result.Select(x => new
            {
                ID = x.Id,
                Name = x.Name
            }));
        }
        public JsonResult getSubTopic(int ItemId)
        {
            CVWebAppEntities db = new CVWebAppEntities();
            List<SubTopic> result = db.SubTopics.Where(a => a.TopicId == ItemId).ToList();
            return Json(result.Select(x => new
            {
                ID = x.Id,
                Name = x.Name
            }));
        }
        public JsonResult getFilterByTopic(int ItemId)
        {
            CVWebAppEntities db = new CVWebAppEntities();
            List<Filter> result = db.Filters.Where(a => a.TopicId == ItemId).ToList();
            return Json(result.Select(x => new
            {
                ID = x.Id,
                Name = x.Name
            }));
        }
        public JsonResult getFilterBySubTopic(int ItemId)
        {
            CVWebAppEntities db = new CVWebAppEntities();
            List<Filter> result = db.Filters.Where(a => a.SubTopicId == ItemId).ToList();
            return Json(result.Select(x => new
            {
                ID = x.Id,
                Name = x.Name
            }));
        }
        public ActionResult Index()
        {
            

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ApplyFilter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ApplyFilter(HttpPostedFileBase file)
        {
            return View();
        }
    }
}