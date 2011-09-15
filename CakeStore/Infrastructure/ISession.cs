using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CakeStore.Utils
{
    public interface ISession
    {
        string CurrentUser { get; set; }
    }
}
