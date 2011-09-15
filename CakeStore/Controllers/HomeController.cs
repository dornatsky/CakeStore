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
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class HomeController : Controller
    {
        [Import]
        private ISession _session;

        public ActionResult Index()
        {
            if (_session.CurrentUser == null)
            {
                _session.SetUser("test", this);

                HttpCookie cookie = this.ControllerContext.HttpContext.Request.Cookies["User"];
                cookie.Expires = DateTime.Now.AddDays(1);
                this.ControllerContext.HttpContext.Response.Cookies.Add(cookie);
            }
            else
            {
                ViewBag.Message = "test";
            }


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
