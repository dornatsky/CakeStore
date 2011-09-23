using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SignalR;
using System.Threading.Tasks;
using System.Threading;

namespace CakeStore
{
    public class ProgressConnection:PersistentConnection
    {
        protected override System.Threading.Tasks.Task OnReceivedAsync(string clientId, string data)
        {
            Action<Task> sleep = t => Thread.Sleep(2000);
            Task result = Connection.Broadcast("Processing...")
                .ContinueWith(sleep)
                .ContinueWith(t=>Connection.Broadcast("Order has been placed"))
                .ContinueWith(sleep)
                .ContinueWith(t=>Connection.Broadcast("Cake is on the way"));

            return result;
        }
    }
}