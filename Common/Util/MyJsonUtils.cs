﻿using Common.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Common.Util
{
    public class MyJsonUtils
    {
        public static List<T> GetList<T>(string text, out string message, out int status)
        {
            List<T> list = new List<T>();
            JObject jo = JObject.Parse(text);
            message = jo["message"].ToString();
            status = int.Parse(jo["status"].ToString());

            JArray ja = JArray.Parse(jo["data"].ToString());
            foreach (JObject item in ja)
            {
                T p = item.ToObject<T>();
                list.Add(p);
            }
            return list;
        }

        public static MyList<T> GetList<T>(string text)
        {
            MyList<T> list = new MyList<T>();
            JObject jo = JObject.Parse(text);

            JArray ja = JArray.Parse(jo["data"].ToString());
            foreach (JObject item in ja)
            {
                T p = item.ToObject<T>();
                list.Add(p);
            }
            return list;
        }

        public static MyList<T> GetList<T>(string text, string[] pd, Type[] to)
        {
            MyList<T> list = new MyList<T>();
            JObject jo = JObject.Parse(text);

            JArray ja = JArray.Parse(jo["data"].ToString());
            foreach (JObject item in ja)
            {
                bool isOk = false;
                for (int i = 0; i < pd.Length; ++i)
                {
                    if (item[pd[i]] != null)
                    {
                        list.Add((T)item.ToObject(to[i]));
                        isOk = true;
                        break;
                    }
                }
                if (!isOk)
                {
                    T p = item.ToObject<T>();
                    list.Add(p);
                }
            }
            return list;
        }

        public static MyList<MapResource> GetMapResourceList(string text)
        {
            return GetList<MapResource>(text, new string[] { "CanRegeneration" }, new Type[] { typeof(MapCollectResource) });
        }

        public static void GetStatusAndMessage(string text, out string message, out int status)
        {
            JObject jo = JObject.Parse(text);
            message = jo["message"].ToString();
            status = int.Parse(jo["status"].ToString());
        }

        public static T GetObject<T>(string text)
        {
            JObject jo = JObject.Parse(text);
            return jo["data"].ToObject<T>();
        }
    }
}
