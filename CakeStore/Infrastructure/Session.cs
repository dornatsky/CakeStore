using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.Composition;

namespace CakeStore.Utils
{
    [Export(typeof(ISession))]
    public class Session : ISession
    {
        private const string _userCookieName = "User";

        private HttpCookieCollection _cookies
        {
            get { return HttpContext.Current.Request.Cookies; }
        }


        public string CurrentUser
        {
            get
            {
                return _cookies[_userCookieName].Value;
            }
            set
            {
                _cookies[_userCookieName].Value = value;
            }
        }
    }
}