using Microsoft.AspNet.SignalR.Client;
using NetWorkLib.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetWork.Net
{
    public class NetWork3J
    {
        private static volatile NetWork3J instance;
        private static HubConnection _conn = null;
        private static IHubProxy _hub;
        private static string counter = String.Empty;

        public NetWork3J(string name, string url)
        {
            var querystringData = new Dictionary<string, string>();
            querystringData.Add("name", name);
            if (_conn == null) { _conn = new HubConnection(url, querystringData); }
            if (_hub == null) { _hub = _conn.CreateHubProxy("CounterHub"); }

            Action<string> Delegate = LocalMethod;
            Action<string> Delegate1 = LocalMethod1;
            _hub.On<string>("UpdateCount", Delegate);
            _hub.On<string>("send", Delegate1);
        }


        public void sendmessageById(string name, string message)
        {
            //var querystringData = new Dictionary<string, string>();
            //querystringData.Add("sendname", name);
            _hub.Invoke("send", name, message);
        }
        public String connection()
        {
            _conn.Start();

            return "Connection started..";

            //_conn = new HubConnection(url, true);
            // _hub = _conn.CreateHubProxy("counterHub");
            //Action<string> Delegate = LocalMethod;
            //_hub.On<string>("UpdateCount", Delegate);
            //_conn.Start().Wait();
        }
        public static void LocalMethod(string counter)
        {

        }
        public void LocalMethod1(string counter)
        {
            AlertBox ale = new AlertBox(counter);
            ale.ShowDialog();
            //MessageBox.Show(counter);
        }
    }
}
