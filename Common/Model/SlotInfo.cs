using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    /// <summary>
    /// 存放背包的信息
    /// </summary>
    public class SlotInfo
    {
        private int articleId; //物品的id
        private int position; // 在哪个位置
        private int count; // 个数

        public int ArticleId { get => articleId; set => articleId = value; }
        public int Position { get => position; set => position = value; }
        public int Count { get => count; set => count = value; }
    }
}
