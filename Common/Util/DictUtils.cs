using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Common.Util
{
    /// <summary>
    /// 字典的工具类
    /// </summary>
    public class DictUtils
    {
        public static T2 GetValue<T1, T2>(Dictionary<T1, T2> dict, T1 key)
        {
            T2 value;
            bool isOk = dict.TryGetValue(key, out value);
            if (isOk)
            {
                return value;
            }
            else
            {
                return default(T2);
            }
        }

        public static string GetStringValue<T1, T2>(Dictionary<T1, T2> dict, T1 key)
        {
            return GetValue<T1, T2>(dict, key) as string;
        }
        public static int GetIntValue<T1, T2>(Dictionary<T1, T2> dict, T1 key)
        {
            return int.Parse(GetValue<T1, T2>(dict, key).ToString());
        }
        public static long GetLongValue<T1, T2>(Dictionary<T1, T2> dict, T1 key)
        {
            return long.Parse(GetValue<T1, T2>(dict, key).ToString());
        }
    }
}
