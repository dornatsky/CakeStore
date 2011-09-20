using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CakeStore.Utils;
using System.ComponentModel.Composition;
using CakeStore.Models;

namespace CakeStore.Controllers
{
    [Export(typeof(HomeController))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class HomeController : Controller
    {
        private ISession _session;

        [ImportingConstructor]
        public HomeController(ISession session)
        {
            _session = session;
        }

        public ActionResult Index()
        {
            LoginViewModel viewModel = new LoginViewModel();
            string user = _session.GetCurrentUser(this);
            if (user == null)
                viewModel.IsLoggedIn = false;
            else
                viewModel.IsLoggedIn = true;

            return View(viewModel);
        }

        public ActionResult About()
        {
            return View();
        }

        [HttpPost]
        public void StartSession(string userName)
        {
            //_session.SetUser(userName, this);
        }

        [HttpPost]
        public void OrderCake()
        {
        }
    }
}
