using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(VivendoByte.AlarmNotifier.Dispatcher.Azure.Startup))]

namespace VivendoByte.AlarmNotifier.Dispatcher.Azure
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}