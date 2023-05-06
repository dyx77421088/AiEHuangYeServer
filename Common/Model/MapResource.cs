using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Common.Model
{
    /// <summary>
    /// 地图上的资源
    /// </summary>
    public class MapResource
    {
        private int id;
        private MapResourceType type;
        private int index;
        private Vector3DPosition position;

        /// <summary>
        /// 在地图上的id，每一次更新都不一样
        /// </summary>
        public int Id { get => id; set => id = value; }
        /// <summary>
        /// 类别
        /// </summary>
        public MapResourceType Type { get => type; set => type = value; }
        /// <summary>
        /// 第几个
        /// </summary>
        public int Index { get => index; set => index = value; }
        /// <summary>
        /// 位置
        /// </summary>
        public Vector3DPosition Position { get => position; set => position = value; }
        

        //public override string ToString()
        //{
        //    return "{" +
        //    "\"MapResourceType\": \"" + type + "\"" +
        //        ", \"index\":" + index +
        //        ", \"position\":" + position +
        //        '}' + "\n";
        //}
    }
}
