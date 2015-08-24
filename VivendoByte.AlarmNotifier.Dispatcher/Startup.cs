using Microsoft.Owin.Cors;
using Owin;

namespace VivendoByte.AlarmNotifier.Dispatcher
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR();
        }
    }
}