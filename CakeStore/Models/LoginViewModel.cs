using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CakeStore.Models
{
    public class LoginViewModel
    {
        public bool IsLoggedIn { get; set; }
        public string UserName { get; set; }
    }
}