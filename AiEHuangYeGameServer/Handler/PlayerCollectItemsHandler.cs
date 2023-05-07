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
using System.Diagnostics;
using AiEHuangYeGameServer.Util;

namespace AiEHuangYeGameServer.Handler
{
    /// <summary>
    /// 用户采集处理
    /// </summary>
    public class PlayerCollectItemsHandler : BaseHandler
    {
        public PlayerCollectItemsHandler()
        {
            code = OperationCode.CollectItems;
        }
        public override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters, Client peer)
        {
            // 通知其他用户位置
            Dictionary<byte, object> obj = operationRequest.Parameters;
            string text = DictUtils.GetStringValue<byte, object>(obj, (byte)ParameterCode.JsonData);
            int id = DictUtils.GetIntValue<byte, object>(obj, (byte)ParameterCode.UserId);
            MapCollectResource resource = MyJsonUtils.GetObject<MapCollectResource>(text);

            MyGameServer.logger.Info(text + "   " + resource);
            MyGameServer.logger.Info("用户的id是" + id + "这个resource是" + resource.Id + "  " + resource.Index);
            if(!resource.CanRegeneration && resource.IsDestruction)  // 是否已经是销毁状态且不能再生
            {
                MyGameServer.logger.Info("删除了！！！！");
                MyGameServer.Instance.DeleteMapById(resource.Id);
            }
            else
            {
                MyGameServer.logger.Info(resource.IsDestruction + "修改了！！！！" + resource.CanRegeneration);
                MyGameServer.Instance.UpdateMapById(resource);
            }

            foreach (Client other in MyGameServer.loginClients)
            {
                if (id != other.Player.Id)
                {
                    // 通知
                    EventData eventData = new EventData((byte)EventCode.CollectItems);
                    Dictionary<byte, object> data = new Dictionary<byte, object>
                    {
                        { (byte)ParameterCode.JsonData, ToGson.Success(resource) }
                    };
                    eventData.SetParameters(data);
                    other.SendEvent(eventData, new SendParameters());
                }
            }
        }
    }
}
