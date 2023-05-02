using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Common.Model
{
    /// <summary>
    /// 位置信息
    /// </summary>
    public class Vector3DPosition
    {
        private float x = 0;
        private float y = 0; 
        private float z = 0;

        public float X { get => x; set => x = value; }
        public float Y { get => y; set => y = value; }
        public float Z { get => z; set => z = value; }

        public override string ToString()
        {
            return "{" +
                "\"x\":" + X +
                ",\"y\":" + Y +
                ",\"z\":" + Z +
                '}';
        }
    }
}
