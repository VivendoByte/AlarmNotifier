using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using VivendoByte.AlarmNotifier.Messages;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace VivendoByte.AlarmNotifier.Client.WindowsPhone
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