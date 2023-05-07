using Common.Model;
using Common.Util;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            MyList<MapResource> list = new MyList<MapResource>();
            list.Add(new MapResource() { Type=Common.MapResourceType.Tree, Index=1, Position=new Vector3DPosition()});
            list.Add(new MapCollectResource() { Type=Common.MapResourceType.Stone, Index=3, Position = new Vector3DPosition(), CanRegeneration=true, IsDestruction=false });

            //Console.WriteLine(ToGson.Success(list, true));
            string text = ToGson.Success(list, true);
            List<MapResource> r = MyJsonUtils.GetList<MapResource>(text);
            List<MapResource> r2 = MyJsonUtils.GetList<MapResource>(text, new string[] { "CanRegeneration" }, new Type[] { typeof(MapCollectResource) });
            Console.WriteLine(JsonConvert.SerializeObject(r));
            Console.WriteLine(JsonConvert.SerializeObject(r2));





            //JObject jo = JObject.Parse(text);

            //JArray ja = JArray.Parse(jo["data"].ToString());
            //foreach (JObject item in ja)
            //{
            //    bool isOk = false;
            //    Console.WriteLine(item.ToString());
            //    if (item["CanRegeneration"] != null)
            //    {
            //        list.Add((MapCollectResource)item.ToObject(typeof(MapCollectResource)));
            //        isOk = true;
            //        Console.WriteLine("添加了一个不一样的");
            //        break;
            //    }
            //    if (!isOk)
            //    {
            //        MapResource p = item.ToObject<MapResource>();
            //        Console.WriteLine(p);
            //    }
            //}



            Console.ReadKey();
        }
    }
}
