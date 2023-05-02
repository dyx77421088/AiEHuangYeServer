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

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public Vector3DPosition Position { get => position; set => position = value; }
        public bool IsLeft { get => isLeft; set => isLeft = value; }
        public bool IsLast { get => isLast; set => isLast = value; }
        public PlayerAnimation Animation { get => animation; set => animation = value; }

        public Player(int id, string name, Vector3DPosition positioin)
        {
            this.id = id;
            this.name = name;
            this.position = positioin;
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
