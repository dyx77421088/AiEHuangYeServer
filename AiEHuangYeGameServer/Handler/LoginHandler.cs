using AiEHuangYeGameServer.Manage;
using AiEHuangYeGameServer.Model;
using AiEHuangYeGameServer.MyClient;
using AiEHuangYeGameServer.Util;
using Common;
using Common.Model;
using Common.Util;
using Photon.SocketServer;
using System;
using System.Collections.Generic;

namespace AiEHuangYeGameServer.Handler
{
    public class LoginHandler : BaseHandler
    {
        public LoginHandler() { code = OperationCode.Login; }

        public override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters, Client peer)
        {
            Dictionary<byte, object> parameters = new Dictionary<byte, object>();
            parameters = operationRequest.Parameters;
            //object username, password;
            //parameters.TryGetValue((byte)ParameterCode.Name, out username);
            //parameters.TryGetValue((byte)ParameterCode.Password, out password);
            string username = DictUtils.GetStringValue<byte, object>(parameters, (byte)ParameterCode.Name);
            string password = DictUtils.GetStringValue<byte, object>(parameters, (byte)ParameterCode.Password);

            MyGameServer.logger.Info("用户("+username+")尝试登录....");
            User user = new UserManage().Login(username, password);
            bool isLogin = user != null;

            // 其它用户的角色的位置信息,,还有自己的
            MyList<Player> otherPlayerList = new MyList<Player>();
            if (isLogin)
            {
                // 保存登录的client
                if (MyGameServer.AddLoginClient(peer, user.Id))
                {
                    peer.Player = MyGameServer.GetPlayerById(user.Id);
                    if (peer.Player == null)
                    {
                        MyGameServer.logger.Info("为空所以我要重新new");
                        peer.Player = new Player(user.Id, user.Name, new Vector3DPosition());
                    }
                    
                    //peer.ClientTread = new ClientTread(peer);
                    // 先不开线程
                    //peer.ClientTread.Start();

                    // 通知其它已在线的用户，
                    foreach (Client temp in MyGameServer.loginClients)
                    {
                        if (temp.Player.Id != peer.Player.Id)
                        {
                            EventData eventData = new EventData((byte)EventCode.NewPlayer);
                            Dictionary<byte, object> data = new Dictionary<byte, object>();
                            data.Add((byte)ParameterCode.JsonData, ToGson.Success(peer.Player));
                            eventData.Parameters = data;
                            temp.SendEvent(eventData, new SendParameters());

                        }
                        // 添加进来
                        otherPlayerList.Add(temp.Player);
                    }

                    //  通知用户初始化地图
                    EventData eData = new EventData((byte)EventCode.InitMap);
                    MyGameServer.logger.Info("服务器中的地图" + MyGameServer.maps);
                    Dictionary<byte, object> d = new Dictionary<byte, object>();
                    d.Add((byte)ParameterCode.JsonData, ToGson.Success(MyGameServer.maps, true));
                    eData.Parameters = d;
                    peer.SendEvent(eData, new SendParameters());
                }
                
            }

            MyServerUtils.SendDataToClient(peer, sendParameters, operationRequest.OperationCode,
                ToGson.Info(isLogin ? 200 : 400, isLogin ? "登录成功" : "用户名或密码错误", otherPlayerList));

            MyGameServer.logger.Info("用户(" + username + ")登录=>" + (isLogin ? "登录成功!" : "用户名或密码错误"));
            MyGameServer.logger.Info("当前在线人数为:" + (otherPlayerList.Count));
        }
    }
}
