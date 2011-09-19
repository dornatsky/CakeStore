using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.Composition;
using System.Web.Mvc;

namespace CakeStore.Utils
{
    [Export(typeof(ISession))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class Session : ISession
    {
        private const string _userCookieName = "User";
        private string _user;

        public void SetUser(string user, Controller controller)
        {
            HttpCookie cookie = new HttpCookie(_userCookieName);
            cookie.Value = user;
            cookie.Expires = DateTime.Now.AddDays(1);
            controller.ControllerContext.HttpContext.Response.Cookies.Add(cookie);

            _user = user;
        }

        public string GetCurrentUser(Controller controller)
        {
            var result = controller.HttpContext.Request.Cookies[_userCookieName];
            string value = result.Value;
            return value ?? _user;
        }
    }
}