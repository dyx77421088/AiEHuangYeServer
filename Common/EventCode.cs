
namespace Common
{
    public enum EventCode : byte
    {
        /// <summary>
        /// 新的用户添加进来
        /// </summary>
        NewPlayer,
        /// <summary>
        /// 在线用户的位置信息
        /// </summary>
        PlayerPosition,
        /// <summary>
        /// 用户离开了
        /// </summary>
        ClosePlayer,
        /// <summary>
        /// 用户进行的动画的事件
        /// </summary>
        PlayerAnimator,
        /// <summary>
        /// 初始化地图
        /// </summary>
        InitMap,
        /// <summary>
        /// 采集物品，通知各个用户
        /// </summary>
        CollectItems
    }
}
