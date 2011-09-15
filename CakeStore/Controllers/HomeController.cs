using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CakeStore.Utils;
using System.ComponentModel.Composition;

namespace CakeStore.Controllers
{
    [Export(typeof(HomeController))]
    public class HomeController : Controller
    {
        [Import]
        private ISession _session;

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        [HttpPost]
        public void StartSession(string userName)
        {

        }

        [HttpPost]
        public void OrderCake()
        {

        }
    }
}
