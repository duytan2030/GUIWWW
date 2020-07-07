using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities;
using Services;
using EntityFrameworks.AccessModel;
using EntityFrameworks.Model;
namespace UI.Web.Controllers
{

    public class NewsController : Controller
    {
        NewsDBContext dt = new NewsDBContext();
        MappingService sermap = new MappingService();
        NewspaperService serNews = new NewspaperService();
        TopicService sertop = new TopicService();
        // GET: News
        public ActionResult Index(int id)
        {
            //var listbao = serNews.GetAll();
            //var listtopic = sertop.GetAll();
            //var listmap = sermap.GetAll();
            //var query = (from m in listmap
            //             join bao in listbao on m.NewsId equals bao.NewsId
            //             where (m.TopicId.Equals(id))
            //             select new
            //             {

            //                 bao.Description,
            //                 bao.Title,
            //                 bao.Image,
            //             }).ToList();
            //ViewBag.GetTheoTopic = query;
            //return View(query.ToList());
            List<Newspaper> ds = (from n in dt.Mappings
                                         where n.TopicId == id
                                         select n.Newspaper).ToList();
            return View(ds);
        }
        public ActionResult GetView()
        {

            return View();
        }
        //Get
        public ActionResult CreateNews()
        {
            return View();
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult CreateNews(Newspaper news)
        {
            NewspaperService ser = new NewspaperService();
            news.Active = 0;
            news.PublicationDate = DateTime.Now;
            ser.AddNewspaper(news);
            return RedirectToAction("CreateNews");
        }
        [HttpPost]
        public ActionResult GetNewsByTitle(int id)
        {
            return View();
        }
        public ActionResult DetailNews(int id)
        {
            var news = serNews.GetById(id);
            if (news != null)
            {
                ViewBag.Des = HttpUtility.HtmlDecode(news.Description);
            }
            return View(news);
        }
    }
}