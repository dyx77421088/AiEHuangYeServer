using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiEHuangYeGameServer.Util
{
    internal class TimeUtils
    {
        /// <summary>
        /// 获得时间戳
        /// </summary>
        /// <param name="isMillisecond">是否为毫秒</param>
        /// <returns></returns>
        public static long GetTimeStamp(bool isMillisecond = false)
        {
            var ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            var timeStamp = isMillisecond ? Convert.ToInt64(ts.TotalMilliseconds) : Convert.ToInt64(ts.TotalSeconds);
            return timeStamp;
        }
    }
}
