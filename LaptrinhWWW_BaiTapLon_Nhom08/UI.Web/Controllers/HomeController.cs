using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities;
using Services;
using EntityFrameworks.Model;
using System.Security.Cryptography;

namespace UI.Web.Controllers
{
    public class HomeController : Controller
    {
        MappingService sermap = new MappingService();
        NewspaperService serNews = new NewspaperService();
        TopicService sertop = new TopicService();

        public ActionResult Index()
        {

            ViewBag.Right = serNews.GetAll().Take(4);
            ViewBag.Top = serNews.GetAll().OrderByDescending(x => x.NewsId).Take(1);
            ViewBag.Bot = serNews.GetAll().OrderByDescending(x => x.NewsId).Take(3);
            ViewBag.Topic = sertop.GetAll();
            ViewBag.GetAllBao = serNews.GetAll().OrderByDescending(x => x.NewsId).Take(4);
            return View();
        }

        public JsonResult getNew(int id)
        {

            var query = (from tp in sertop.GetAll()
                         join
map in sermap.GetAll() on tp.TopicId equals map.TopicId
                         join
news in serNews.GetAll() on map.NewsId equals news.NewsId
                         where tp.TopicId == id
                         select new
                         {
                             news.Image,
                             news.Title,
                             tp.TopicName,
                             news.NewsId

                         }).ToList();
            ViewBag.getbaotheoIDTopic = query;

            return Json(query, JsonRequestBehavior.AllowGet);
        }
    }

}
