using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VivendoByte.AlarmNotifier.Messages;

namespace VivendoByte.AlarmNotifier.Client.Wpf
{
    public partial class MainWindow : Window
    {
        public IHubProxy HubProxy { get; set; }
        const string ServerURI = "http://alarmnotifier.azurewebsites.net/signalr";
        public HubConnection Connection { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            this.Connect();
        }

        private async void Connect()
        {
            Connection = new HubConnection(ServerURI);
            HubProxy = Connection.CreateHubProxy("NotifierHub");

            HubProxy.On<AlarmMessage>("SendNotification", (notification) =>
                this.Dispatcher.Invoke(() =>
                {
                    this.AlarmsList.Items.Add(notification);
                }
                )
            );

            try
            {
                await Connection.Start();
            }
            catch (HttpRequestException)
            {
                return;
            }
        }
    }
}