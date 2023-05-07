using AiEHuangYeGameServer.MyClient;
using Common;
using Common.Model;
using Common.Util;
using Photon.SocketServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiEHuangYeGameServer.Handler
{
    public class UploadBuildHandler : BaseHandler
    {
        public UploadBuildHandler()
        {
            code = OperationCode.UploadBuild;
        }
        public override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters, Client peer)
        {
            // 通知其他用户位置
            Dictionary<byte, object> obj = operationRequest.Parameters;
            string text = DictUtils.GetStringValue(obj, (byte)ParameterCode.JsonData);
            int id = DictUtils.GetIntValue<byte, object>(obj, (byte)ParameterCode.UserId);
            UploadBuildModel resource = MyJsonUtils.GetObject<UploadBuildModel>(text);

            MyGameServer.maps.Add(resource);

            // 进来了
            
            MyGameServer.logger.Info("进来了" + text);
            foreach (Client other in MyGameServer.loginClients)
            {
                if (id != other.Player.Id)
                {
                    // 通知
                    EventData eventData = new EventData((byte)EventCode.UploadBuild);
                    Dictionary<byte, object> data = new Dictionary<byte, object>();
                    data.Add((byte)ParameterCode.JsonData, ToGson.Success(resource));
                    eventData.SetParameters(data);
                    other.SendEvent(eventData, new SendParameters());
                }
            }
        }
    }
}
