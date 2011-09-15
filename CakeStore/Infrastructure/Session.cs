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

        private HttpCookieCollection _requestCookies
        {
            get { return HttpContext.Current.Request.Cookies; }
        }

        public void SetUser(string user, Controller controller)
        {
            HttpCookie cookie = new HttpCookie(_userCookieName);
            cookie.Value = user;
            controller.ControllerContext.HttpContext.Response.Cookies.Add(cookie);

            _user = user;
        }

        public string CurrentUser
        {
            get
            {
                var result = _requestCookies[_userCookieName];
                if (result != null)
                    return result.Value;
                else
                    return _user;
            }
        }
    }
}