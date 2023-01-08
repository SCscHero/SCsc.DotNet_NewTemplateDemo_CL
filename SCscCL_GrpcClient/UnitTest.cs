using Newtonsoft.Json;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace SCscCL_GrpcClient
{
    public class UnitTest
    {
        public static void Show()
        {
            List<PostInfo> list = new List<PostInfo>();
            for (int i = 0; i < 100; i++)
            {
                PostInfo postInfo = new PostInfo()
                {
                    P_Content = "这是内容",
                    P_ID = i,
                    P_Title = "title"
                };
                list.Add(postInfo);
            }

            byte[] datas;
            using (var stream = new MemoryStream())
            {
                Serializer.Serialize(stream, list);
                datas = stream.ToArray();
            }
            Console.WriteLine($"protobuf长度为：{datas.Length}");
            string tempjson = JsonConvert.SerializeObject(list);
            Console.WriteLine($"json长度为：{UTF8Encoding.UTF8.GetBytes(tempjson).Length}");

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            JsonConvert.SerializeObject(list);
            stopwatch.Stop();
            Console.WriteLine($"json序列化用时：{stopwatch.Elapsed.TotalMilliseconds}");

            stopwatch.Restart();
            using (var stream = new MemoryStream())
            {
                Serializer.Serialize(stream, list);
                datas = stream.ToArray();
            }
            stopwatch.Stop();
            Console.WriteLine($"protobuf序列化用时：{stopwatch.Elapsed.TotalMilliseconds}");


        }
    }
}
