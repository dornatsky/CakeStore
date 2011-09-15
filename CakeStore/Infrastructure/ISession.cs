using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace CakeStore.Utils
{
    public interface ISession
    {
        string CurrentUser { get; }
        void SetUser(string user, Controller controller);
    }
}
