using AiEHuangYeGameServer.MyClient;
using Photon.SocketServer;
using System;

namespace AiEHuangYeGameServer.Handler
{
    public class DefaultHandler : BaseHandler
    {
        public DefaultHandler()
        {
            code = Common.OperationCode.Defalut;
        }
        public override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters, Client peer)
        {
            throw new NotImplementedException();
        }
    }
}
