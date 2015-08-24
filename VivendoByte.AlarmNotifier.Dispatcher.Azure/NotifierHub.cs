using Microsoft.AspNet.SignalR;
using VivendoByte.AlarmNotifier.Messages;
using System.Threading.Tasks;

namespace VivendoByte.AlarmNotifier.Dispatcher.Azure
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