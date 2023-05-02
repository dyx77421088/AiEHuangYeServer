using AiEHuangYeGameServer.MyClient;
using Common;
using Common.Util;
using Photon.SocketServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyGameServer.MyClient
{
    public class ClientTread
    {
        private Thread thread;
        private Client client;

        public ClientTread(Client client)
        {
            this.client = client;
        }
        public void Start()
        {
            thread = new Thread(StartThread);
            thread.Start();
        }

        public void Close()
        {
            thread.Abort();
        }

        private void StartThread()
        {
            Thread.Sleep(2000);
            while (true)
            {
                // 休息400毫秒
                Thread.Sleep(200);
                // 先找出本client的位置
                // 把本client的位置发送给 其它所有在线的用户
                //foreach (Client temp in MyGameServer.loginClients)
                //{
                //    if (temp.Player.Id != client.Player.Id)
                //    {
                //        EventData eventData = new EventData( (byte)EventCode.PlayerPosition );
                //        Dictionary<byte, object> data = new Dictionary<byte, object>();
                //        data.Add((byte)ParameterCode.JsonData, ToGson.Success(client.Player));
                //        eventData.Parameters = data;
                //        temp.SendEvent(eventData, new SendParameters());
                //    }
                //}
            }
        }
    }
}
