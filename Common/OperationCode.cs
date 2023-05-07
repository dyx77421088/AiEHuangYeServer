
namespace Common
{
    /// <summary>
    /// 操作代码
    /// </summary>
    public enum OperationCode:byte
    {
        /// <summary>
        /// 默认
        /// </summary>
        Defalut,
        /// <summary>
        /// 登录操作
        /// </summary>
        Login,
        /// <summary>
        /// 注册操作
        /// </summary>
        Register,
        /// <summary>
        /// 用户更新位置的操作
        /// </summary>
        PlayerNewPosition,
        /// <summary>
        /// 用户动画的操作
        /// </summary>
        PlayerAnimation,

        /// <summary>
        /// 第一个用户初始化地图，把这个地图上的资源初始化到服务器
        /// </summary>
        InitMap,
        /// <summary>
        /// 采集物品的操作，需要同步东各个用户
        /// </summary>
        CollectItems,
        /// <summary>
        /// 用户建筑，上传通知各个其它用户
        /// </summary>
        UploadBuild,
    }
}
