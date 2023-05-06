using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// 地图资源的类型
    /// </summary>
    public enum MapResourceType:byte
    {
        /// <summary>
        /// 树
        /// </summary>
        Tree,
        /// <summary>
        /// 石头
        /// </summary>
        Stone,
        /// <summary>
        /// 花草
        /// </summary>
        Grass,
        /// <summary>
        /// 采集的
        /// </summary>
        Collect,
    }
}
