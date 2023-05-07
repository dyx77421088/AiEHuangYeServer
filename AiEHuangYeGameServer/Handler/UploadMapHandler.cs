using AiEHuangYeGameServer.MyClient;
using Common.Model;
using Common.Util;
using Common;
using Photon.SocketServer;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

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
            //MyGameServer.logger.Info("用户上传了地图！！！！！！=" + text);
            MyList<MapResource> mapResources = MyJsonUtils.GetMapResourceList(text);

            

            //MyGameServer.logger.Info("第一次装欢" + ToGson.Success(mapResources));
            // 初始化地图
            MyGameServer.maps = mapResources;
            //MyGameServer.logger.Info("第二次转换" + ToGson.Success(MyGameServer.maps));
        }
    }
}
