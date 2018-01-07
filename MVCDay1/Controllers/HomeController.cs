using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDay1.Controllers
{
    public class HomeController : Controller
    {
        //在MVC中，访问时，实际访问的是类中的方法
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HtmlTest()
        {
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(int ID,int Age)
        {

            ViewBag.Age = Age;
            ViewBag.ID = ID;
            return View();
        }

        public ActionResult Edit(int ID)
        {
            ViewBag.ID = ID;
            return View();
        }
    }
}