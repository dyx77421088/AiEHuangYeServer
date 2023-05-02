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
        private MapResourceType type;
        private int index;
        private Vector3DPosition position;

        public MapResourceType Type { get => type; set => type = value; }
        public int Index { get => index; set => index = value; }
        public Vector3DPosition Position { get => position; set => position = value; }

        public override string ToString()
        {
            return "{" +
            "\"MapResourceType\": \"" + type + "\"" +
                ", \"index\":" + index +
                ", \"position\":" + position +
                '}' + "\n";
        }
    }
}
