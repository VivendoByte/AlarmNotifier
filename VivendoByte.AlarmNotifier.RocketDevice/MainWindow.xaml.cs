using Microsoft.AspNet.SignalR.Client;
using System.Net.Http;
using System.Windows;
using VivendoByte.AlarmNotifier.Messages;

namespace VivendoByte.AlarmNotifier.RocketDevice
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

            try
            {
                await Connection.Start();
            }
            catch (HttpRequestException)
            {
                return;
            }
        }

        private void SendAlarm_Click(object sender, RoutedEventArgs e)
        {
            AlarmMessage a = new AlarmMessage();
            HubProxy.Invoke("RaiseAlarm", a);
        }
    }
}