using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    [Serializable]
    public class MapCollectResource:MapResource
    {
        private bool canRegeneration;
        private bool isDestruction;

        /// <summary>
        /// 能否再生
        /// </summary>
        public bool CanRegeneration { get => canRegeneration; set => canRegeneration = value; }
        /// <summary>
        /// 是否已经是销毁状态了
        /// </summary>
        public bool IsDestruction { get => isDestruction; set => isDestruction = value; }
    }
}
