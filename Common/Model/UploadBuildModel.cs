using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    public class UploadBuildModel:MapResource
    {
        private string spriteUrl;

        /// <summary>
        /// 显示的图片的 地址
        /// </summary>
        public string SpriteUrl { get => spriteUrl; set => spriteUrl = value; }
    }
}
