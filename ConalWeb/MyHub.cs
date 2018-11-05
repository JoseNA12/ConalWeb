using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace ConalWeb.Hubs
{
    //[HubName("myHub")]
    public class MyHub : Hub
    {
        private static int _count = 0;

        public void SendMessage(string name, string msge, string group)
        {
            var conId = Context.ConnectionId.ToString();
            Clients.Group(group).receive(name, conId, msge);
        }

        public void Join(string group)
        {
            Groups.Add(Context.ConnectionId, group);
        }

        public override System.Threading.Tasks.Task OnConnected()
        {
            var id = Context.ConnectionId;
            _count += 1;
            Clients.All.countno(_count);

            return base.OnConnected();
        }

        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {
            _count -= 1;
            Clients.All.countno(_count);
            return base.OnDisconnected(stopCalled);
        }

        public override System.Threading.Tasks.Task OnReconnected()
        {
            return base.OnReconnected();
        }
    }
    public class Notify
    {
        public static void Say(string message)
        {
            var allContext = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
            allContext.Clients.All.sayClient(message);

        }
    }
}