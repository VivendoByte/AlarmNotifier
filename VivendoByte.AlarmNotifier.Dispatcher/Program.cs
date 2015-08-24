using Microsoft.Owin.Hosting;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace VivendoByte.AlarmNotifier.Dispatcher
{
    class Program
    {
        private static IDisposable SignalR { get; set; }
        private static string ServerURI = "http://localhost:8080";

        static void Main(string[] args)
        {
            Task.Run(() => StartServer());
            Console.ReadKey();
        }

        private static void StartServer()
        {
            Console.WriteLine("Starting server...");

            try
            {
                SignalR = WebApp.Start(ServerURI);
            }
            catch (TargetInvocationException)
            {
                Console.WriteLine("A server is already running at " + ServerURI);
                return;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.ToString());
                return;
            }

            Console.WriteLine("Server started at " + ServerURI);
        }
    }
}