using System;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace ConalWeb
{
    //[HubName("myHub")]
    public class ChatHub : Hub
    {
        public void Send(string name, string message)
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage(name, message); // Original de la libreria
        }



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
            var allContext = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
            allContext.Clients.All.sayClient(message);

        }
    }
}