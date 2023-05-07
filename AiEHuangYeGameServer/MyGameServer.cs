using AiEHuangYeGameServer.Handler;
using AiEHuangYeGameServer.Manage;
using AiEHuangYeGameServer.MyClient;
using Common;
using Common.Model;
using ExitGames.Logging;
using ExitGames.Logging.Log4Net;
using log4net.Config;
using Photon.SocketServer;
using System.Collections.Generic;
using System.IO;

namespace AiEHuangYeGameServer
{
    class MyGameServer : ApplicationBase
    {
        public static readonly ILogger logger = LogManager.GetCurrentClassLogger();
        public static List<Client> clients = new List<Client>();
        public static List<Client> loginClients = new List<Client>();
        public static MyList<MapResource> maps = new MyList<MapResource>();
        public static new MyGameServer Instance
        {
            get;
            private set;
        }
        // 存放操作的字典
        public Dictionary<OperationCode, BaseHandler> handlerDict = new Dictionary<OperationCode, BaseHandler> ();
        private void initDict()
        {
            handlerDict.Clear();

            // 默认操作
            DefaultHandler defaultHandler = new DefaultHandler();
            handlerDict.Add(defaultHandler.code, defaultHandler);
 
            // 登录操作
            LoginHandler loginHandler = new LoginHandler();
            handlerDict.Add(loginHandler.code, loginHandler);

            // 注册操作
            RegisterHandler registerHandler = new RegisterHandler();
            handlerDict.Add(registerHandler.code, registerHandler);

            // 更新位置操作
            PlayerNewPositionHandler playerNewPositionHandler = new PlayerNewPositionHandler();
            handlerDict.Add(playerNewPositionHandler.code, playerNewPositionHandler);

            // 用户动画
            PlayerAnimatorHandler playerAnimatorHandler = new PlayerAnimatorHandler();
            handlerDict.Add(playerAnimatorHandler.code, playerAnimatorHandler);

            // 初始化地图
            UploadMapHandler uploadMapHandler = new UploadMapHandler();
            handlerDict.Add(uploadMapHandler.code, uploadMapHandler);

            // 采集
            PlayerCollectItemsHandler playerCollectItemsHandler = new PlayerCollectItemsHandler();
            handlerDict.Add(playerCollectItemsHandler.code, playerCollectItemsHandler);

            // 上传建筑
            UploadBuildHandler uploadBuildHandler = new UploadBuildHandler();
            handlerDict.Add(uploadBuildHandler.code, uploadBuildHandler);
        }
        #region 重写的父类，处理一些初始化
        protected override PeerBase CreatePeer(InitRequest initRequest)
        {
            logger.Info("一个客户端连接过来了");
            Client client = new Client(initRequest);
            // 把客户端添加到clients中
            clients.Add(client);
            return client;
        }

        protected override void Setup()
        {
            // 日志的初始化
            log4net.GlobalContext.Properties["Photon:ApplicationLogPath"] = Path.Combine(this.ApplicationRootPath, "log");
            log4net.GlobalContext.Properties["LogFileName"] = "挨饿荒野的log";
            FileInfo file = new FileInfo(Path.Combine(this.BinaryPath, "log4net.config"));
            if (file.Exists )
            {
                // 使用哪个日志插件
                LogManager.SetLoggerFactory(Log4NetLoggerFactory.Instance);
                // log4net读取配置文件
                XmlConfigurator.ConfigureAndWatch(file);
            }

            logger.Info("初始化完成");


            // 单例
            Instance = this;
            initDict();

            //new UserManage().Add(new Model.User() { Name="我是测i", Password="111"});
        }

        protected override void TearDown()
        {
            logger.Info("(MyGameServer)断开连接了");
        }
        #endregion


        public void UpdateMapById(MapResource map)
        {
            for (int i = 0; i < maps.Count; i++) 
            {
                if (maps[i].Id == map.Id)
                {
                    maps[i] = map;
                    return;
                }
            }
        }

        public void DeleteMapById(int id)
        {
            maps.ForEach(map => { 
                if (map.Id == id) maps.Remove(map);
            });
        }

        public static bool AddLoginClient(Client client, int id)
        {
            // 先判断登录是否已经有client了
            foreach (Client client1 in loginClients)
            {
                if (id == client1.Player.Id)
                {
                    client = client1;
                    return false;
                }
            }
            loginClients.Add(client);
            return true;
        }

        public static Player GetPlayerById(int id)
        {
            foreach(Client client in clients)
            {
                if (client.Player != null && id == client.Player.Id)
                    return client.Player;
            }
            return null;
        }

        public static bool UpdateClient(Client client)
        {
            foreach (Client client1 in clients)
            {
                if (client.Player.Id == client1.Player.Id)
                {
                    client1.Player = client.Player; // 更新player
                    return true;
                }
            }
            clients.Add(client);
            return false;
        }
    }
}
