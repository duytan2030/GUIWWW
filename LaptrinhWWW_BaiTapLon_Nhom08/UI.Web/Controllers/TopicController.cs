using EntityFrameworks.Model;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Web.Controllers
{
    public class TopicController : Controller
    {
        MappingService sermap = new MappingService();
        NewspaperService serNews = new NewspaperService();
        TopicService sertop = new TopicService();
        // GET: Topic
        public ActionResult Index()
        {
            IEnumerable<Topic> ds = sertop.GetAll();
            return View(ds);
        }
    }
}