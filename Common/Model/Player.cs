using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Common.Model
{
    /// <summary>
    /// 角色类
    /// </summary>
    public class Player
    {
        private int id;
        private string name;
        private bool isLeft;
        private bool isLast; // 上一个
        private PlayerAnimation animation; // 用户需要进行的动画
        private Vector3DPosition position;

        private int hungerDegreeUpperLimit = 1000; // 饥饿度上限
        private int moistureUpperLimit = 1000; // 水分上限
        private int strengthUpperLimit = 1000; // 体力上限
        private int resistanceUpperLimit = 1000; // 抵抗力上限
        private int hungerDegree = 1000; // 饥饿度
        private int moisture = 1000; // 水分
        private int strength = 1000; // 体力
        private int resistance = 1000; // 抵抗力

        private List<SlotInfo> slots = new List<SlotInfo>();

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public Vector3DPosition Position { get => position; set => position = value; }
        public bool IsLeft { get => isLeft; set => isLeft = value; }
        public bool IsLast { get => isLast; set => isLast = value; }
        public PlayerAnimation Animation { get => animation; set => animation = value; }
        public int HungerDegree { get => hungerDegree; set => hungerDegree = value; }
        public int Moisture { get => moisture; set => moisture = value; }
        public int Strength { get => strength; set => strength = value; }
        public int Resistance { get => resistance; set => resistance = value; }
        /// <summary>
        /// 饥饿度上限
        /// </summary>
        public int HungerDegreeUpperLimit { get => hungerDegreeUpperLimit; set => hungerDegreeUpperLimit = value; }
        /// <summary>
        /// 水分上限
        /// </summary>
        public int MoistureUpperLimit { get => moistureUpperLimit; set => moistureUpperLimit = value; }
        /// <summary>
        /// 体力上限
        /// </summary>
        public int StrengthUpperLimit { get => strengthUpperLimit; set => strengthUpperLimit = value; }
        /// <summary>
        /// 抵抗力上限
        /// </summary>
        public int ResistanceUpperLimit { get => resistanceUpperLimit; set => resistanceUpperLimit = value; }
        /// <summary>
        /// 背包的信息
        /// </summary>
        public List<SlotInfo> Slots { get => slots; set => slots = value; }

        public Player(int id, string name, Vector3DPosition position)
        {
            this.id = id;
            this.name = name;
            this.position = position;
            this.isLeft = false;
        }
        public override string ToString()
        {
            return "{" +
                "\"id\":" + id +
                ", \"name\":\"" + name + '\"' +
                ", \"position\":" + position +
                ", \"isLeft\":" + (isLeft ? "true" : "false") +
                ", \"isLast\":" + (isLast ? "true" : "false") +
                ", \"animation\":\"" + animation + '\"' +
                '}' + "\n";
        }
    }
}
