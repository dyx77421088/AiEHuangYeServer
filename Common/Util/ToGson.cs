using Newtonsoft.Json;

namespace Common.Util
{
    public class ToGson
    {
        public static string Info(int status, object info)
        {
            return "{\"status\":" + status + ",\"message\":\"" + info + "\"}";
        }

        public static string Info(int status, string message, object data, bool useSerialize = true)
        {
            return "{\"status\":" + status + ",\"message\":\"" + message + "\" " + ",\"data\":" + 
                   (useSerialize ? JsonConvert.SerializeObject(data) : data) 
                + " }";
        }

        public static string Success(object data, bool useSerialize = true)
        {
            return "{\"status\":" + 200 + ",\"data\":" +
                    (useSerialize ? JsonConvert.SerializeObject(data) : data)
                + "}";
        }
    }
}
