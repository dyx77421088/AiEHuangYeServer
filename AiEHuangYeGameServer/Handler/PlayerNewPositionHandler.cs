using AiEHuangYeGameServer.MyClient;
using Common;
using Common.Model;
using Common.Util;
using Photon.SocketServer;
using System.Collections.Generic;

namespace AiEHuangYeGameServer.Handler
{
    public class PlayerNewPositionHandler : BaseHandler
    {
        public PlayerNewPositionHandler() { code = OperationCode.PlayerNewPosition; }
        public override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters, Client peer)
        {
            // 通知其他用户位置
            Dictionary<byte, object> obj = operationRequest.Parameters;
            string text = DictUtils.GetStringValue<byte, object>(obj, (byte)ParameterCode.JsonData);
            Player player = MyJsonUtils.GetObject<Player>(text);
            peer.Player = player;

            // 进来了
            //MyGameServer.logger.Info("更新位置了" + player.Position.ToString()); 
            foreach(Client other in MyGameServer.loginClients)
            {
                if (player.Id != other.Player.Id)
                {
                    // 通知
                    EventData eventData = new EventData((byte)EventCode.PlayerPosition);
                    Dictionary<byte, object> data = new Dictionary<byte, object>();
                    data.Add((byte)ParameterCode.JsonData, ToGson.Success(player));
                    eventData.SetParameters(data);
                    other.SendEvent(eventData, new SendParameters());
                }
            }
        }
    }
}
