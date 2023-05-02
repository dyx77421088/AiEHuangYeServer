using Common;
using Photon.SocketServer.Rpc;
using Photon.SocketServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiEHuangYeGameServer.Util
{
    public class MyServerUtils
    {
        /// <summary>
        /// 向用户返回一条消息
        /// </summary>
        /// <param name="peer"></param>
        /// <param name="sendParameters"></param>
        /// <param name="message"></param>
        public static void SendMessageToClient(ClientPeer peer, SendParameters sendParameters, byte code,string message)
        {
            // 返回注册信息
            OperationResponse resp = new OperationResponse(code);
            Dictionary<byte, object> respDict = new Dictionary<byte, object>();
            respDict.Add((byte)ParameterCode.Message, message);
            resp.SetParameters(respDict);
            peer.SendOperationResponse(resp, sendParameters);
        }
        /// <summary>
        /// 放回消息并携带status=200
        /// </summary>
        /// <param name="peer"></param>
        /// <param name="sendParameters"></param>
        /// <param name="code"></param>
        /// <param name="message"></param>
        public static void SendSucessMessageToClient(ClientPeer peer, SendParameters sendParameters, byte code, string message)
        {
            // 返回注册信息
            OperationResponse resp = new OperationResponse(code);
            Dictionary<byte, object> respDict = new Dictionary<byte, object>();
            respDict.Add((byte)ParameterCode.Message, message);
            respDict.Add((byte)ParameterCode.Status, 200);
            resp.SetParameters(respDict);
            peer.SendOperationResponse(resp, sendParameters);
        }

        /// <summary>
        /// 返回消息并携带status
        /// </summary>
        /// <param name="peer"></param>
        /// <param name="sendParameters"></param>
        /// <param name="code"></param>
        /// <param name="status"></param>
        /// <param name="message"></param>
        public static void SendStatusMessageToClient(ClientPeer peer, SendParameters sendParameters, byte code, int status, string message)
        {
            // 返回注册信息
            OperationResponse resp = new OperationResponse(code);
            Dictionary<byte, object> respDict = new Dictionary<byte, object>();
            respDict.Add((byte)ParameterCode.Message, message);
            respDict.Add((byte)ParameterCode.Status, status);
            resp.SetParameters(respDict);
            peer.SendOperationResponse(resp, sendParameters);
        }

        /// <summary>
        /// 返回data数据
        /// </summary>
        public static void SendDataToClient(ClientPeer peer, SendParameters sendParameters, byte code, string jsonData)
        {
            // 返回注册信息
            OperationResponse resp = new OperationResponse(code);
            Dictionary<byte, object> respDict = new Dictionary<byte, object>();
            respDict.Add((byte)ParameterCode.JsonData, jsonData);
            resp.SetParameters(respDict);
            peer.SendOperationResponse(resp, sendParameters);
        }
    }
}
