using Common.Model;
using Common.Util;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyList<MapResource> list = new MyList<MapResource>();
            list.Add(new MapResource() { Type=Common.MapResourceType.Tree, Index=1, Position=new Vector3DPosition()});
            list.Add(new MapResource() { Type=Common.MapResourceType.Stone, Index=3, Position = new Vector3DPosition() });
            list.Add(new MapResource() { Type=Common.MapResourceType.Grass, Index = 4 });
            list.Add(new MapResource() { Type = Common.MapResourceType.Tree, Index = 2 });
            list.Add(new MapResource() { Type = Common.MapResourceType.Stone, Index = 8 });
            list.Add(new MapResource() { Type = Common.MapResourceType.Grass, Index=11});

            Console.WriteLine(ToGson.Success(list, true));
            string text = ToGson.Success(list, true);

            //Console.WriteLine(json);
            MyList<MapResource> jsonList = MyJsonUtils.GetList<MapResource>(text);
            foreach (MapResource mapResource in jsonList)
            {
                Console.WriteLine(mapResource);
            }
            //JObject j = JObject.Parse(t);
            //MapResource r = j.ToObject<MapResource>();
            //Console.WriteLine(r);

            Console.ReadKey();
        }
    }
}
