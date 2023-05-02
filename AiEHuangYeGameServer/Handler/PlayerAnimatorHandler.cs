using AiEHuangYeGameServer.MyClient;
using Common.Model;
using Common.Util;
using Common;
using Photon.SocketServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiEHuangYeGameServer.Handler
{
    /// <summary>
    /// 用户动画处理
    /// </summary>
    public class PlayerAnimatorHandler : BaseHandler
    {
        public PlayerAnimatorHandler()
        {
            code = OperationCode.PlayerAnimation;
        }
        public override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters, Client peer)
        {
            // 通知其他用户位置
            Dictionary<byte, object> obj = operationRequest.Parameters;
            string text = DictUtils.GetStringValue<byte, object>(obj, (byte)ParameterCode.JsonData);
            Player player = MyJsonUtils.GetObject<Player>(text);
            peer.Player = player;

            foreach (Client other in MyGameServer.loginClients)
            {
                if (player.Id != other.Player.Id)
                {
                    // 通知
                    EventData eventData = new EventData((byte)EventCode.PlayerAnimator);
                    Dictionary<byte, object> data = new Dictionary<byte, object>();
                    data.Add((byte)ParameterCode.JsonData, ToGson.Success(player));
                    eventData.SetParameters(data);
                    other.SendEvent(eventData, new SendParameters());
                }
            }
        }
    }
}
