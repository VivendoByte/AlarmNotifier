using Microsoft.AspNet.SignalR;
using System;
using System.Threading;
using System.Threading.Tasks;
using VivendoByte.AlarmNotifier.Messages;

namespace VivendoByte.AlarmNotifier.Dispatcher
{
    public class NotifierHub : Hub
    {
        public NotifierHub()
        {
            
        }

        public void RaiseAlarm(AlarmMessage notification)
        {
            Clients.All.SendNotification(notification);
        }
        public override Task OnConnected()
        {
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            return base.OnDisconnected(stopCalled);
        }
    }
}