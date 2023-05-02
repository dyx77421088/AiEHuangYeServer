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

namespace AiEHuangYeGameServer.Handler
{
    /// <summary>
    /// 上传地图
    /// </summary>
    public class UploadMapHandler : BaseHandler
    {
        public UploadMapHandler()
        {
            code = Common.OperationCode.InitMap;
        }
        public override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters, Client peer)
        {
            // 初始化地图
            Dictionary<byte, object> obj = operationRequest.Parameters;
            string text = DictUtils.GetStringValue<byte, object>(obj, (byte)ParameterCode.JsonData);
            MyGameServer.logger.Info("json=" + text);
            MyList<MapResource> mapResources = MyJsonUtils.GetList<MapResource>(text);
            MyGameServer.logger.Info("装欢之后的" + mapResources);
            // 初始化地图
            MyGameServer.maps = mapResources;
        }
    }
}
