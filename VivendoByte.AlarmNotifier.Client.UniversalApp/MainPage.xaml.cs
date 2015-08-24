using Microsoft.AspNet.SignalR.Client;
using System;
using System.Net.Http;
using VivendoByte.AlarmNotifier.Messages;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;

namespace VivendoByte.AlarmNotifier.Client.UniversalApp
{
    public sealed partial class MainPage : Page
    {
        public IHubProxy HubProxy { get; set; }
        const string ServerURI = "http://alarmnotifier.azurewebsites.net/signalr";
        public HubConnection Connection { get; set; }
        public MainPage()
        {
            this.InitializeComponent();
            this.Connect();
        }

        private async void Connect()
        {
            Connection = new HubConnection(ServerURI);
            HubProxy = Connection.CreateHubProxy("NotifierHub");

            HubProxy.On<AlarmMessage>("SendNotification", async (notification) =>
                {
                    await this.AlarmsList.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        this.AlarmsList.Items.Add(notification);
                    });
                }
            );

            try
            {
                await Connection.Start();
            }
            catch (HttpRequestException)
            {
                return;
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}