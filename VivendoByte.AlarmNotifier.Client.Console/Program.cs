using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VivendoByte.AlarmNotifier.Messages;

namespace VivendoByte.AlarmNotifier.Client.Console
{
    class Program
    {
        static IHubProxy HubProxy { get; set; }
        //static string ServerURI = "http://localhost:8080/signalr";
        static string ServerURI = "http://alarmnotifier.azurewebsites.net/signalr";
        static HubConnection Connection { get; set; }

        static void Main(string[] args)
        {
            Connect();
        }

        static async void Connect()
        {
            Connection = new HubConnection(ServerURI);
            HubProxy = Connection.CreateHubProxy("NotifierHub");

            HubProxy.On<AlarmMessage>("SendNotification", (notification) =>
                {
                    System.Console.WriteLine(notification);
                }
            );

            try
            {
                Connection.Start();
            }
            catch (HttpRequestException)
            {
                return;
            }

            System.Console.WriteLine("Console Client started!!!");
            System.Console.ReadKey();
        }
    }
}