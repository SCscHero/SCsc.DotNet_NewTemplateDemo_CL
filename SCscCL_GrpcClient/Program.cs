using Grpc.Core;
using Grpc.Net.Client;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SCscCL_GrpcClient
{
    public class Program
    {
        static void Main(string[] args)
        {
            //测试Client和Server通信
            {
                //Console.WriteLine("***************");
                //TestHello().Wait();
            }
            //测试Protobuf与Json长度和序列化速度
            {
                //UnitTest.Show();
            }
            //
            {
                TestTwo().Wait();
            }
        }

        private static async Task TestHello()
        {
            Console.WriteLine("************简单调用************");
            using (var channel = GrpcChannel.ForAddress("https://localhost:5001"))
            {
                var client = new Greeter.GreeterClient(channel);
                var reply = await client.SayHelloAsync(new HelloRequest { Name = "SCscHero" });
                Console.WriteLine("服务端说：" + reply.Message);

            }
        }

        private static async Task TestTwo()
        {
            Console.WriteLine("************客户端流************");

            using (var channel = GrpcChannel.ForAddress("https://localhost:5001"))
            {
                var client = new CustomMath.CustomMathClient(channel);
                //客户端调用的方法。在CustomMathService里面找
                var bathCat = client.SelfIncreaseClient();
                for (int i = 0; i < 10; i++)
                {
                    await bathCat.RequestStream.WriteAsync(new BathTheCatReq() { Id = new Random().Next(0, 20) });
                    await Task.Delay(200);
                    Console.WriteLine($"This is {i} Request {Thread.CurrentThread.ManagedThreadId}");
                }
                Console.WriteLine("***********发送完毕***********");
                //发送完毕
                await bathCat.RequestStream.CompleteAsync();
                Console.WriteLine("客户端已发送完10个id");
                Console.WriteLine("接收结果：");

                foreach (var item in bathCat.ResponseAsync.Result.Number)
                {
                    Console.WriteLine($"This is {item} Result");
                }
                Console.WriteLine("***********");

                //Console.WriteLine("***********服务端流***********");
                //{
                //    IntArrayModel intArrayModel = new IntArrayModel();
                //    for (int i = 0; i < 15; i++)
                //    {
                //        intArrayModel.Number.Add(i);//Number不能直接赋值，
                //    }

                //    CancellationTokenSource cts = new CancellationTokenSource();
                //    cts.CancelAfter(TimeSpan.FromSeconds(2.5)); //指定在2.5s后进行取消操作
                //    var bathCat = client.SelfIncreaseServer(intArrayModel, cancellationToken: cts.Token);

                //    //var bathCat = client.SelfIncreaseServer(intArrayModel);//不带取消
                //    var bathCatRespTask = Task.Run(async () =>
                //    {
                //        await foreach (var resp in bathCat.ResponseStream.ReadAllAsync())
                //        {
                //            Console.WriteLine(resp.Message);
                //            Console.WriteLine($"This is  Response {Thread.CurrentThread.ManagedThreadId}");
                //            Console.WriteLine("**********************************");
                //        }
                //    });
                //    Console.WriteLine("客户端已发送完10个id");
                //    //开始接收响应
                //    await bathCatRespTask;
                //}


                //Console.WriteLine("**************************这是双流呀*****************************");
                //{
                //    var bathCat = client.SelfIncreaseDouble();
                //    var bathCatRespTask = Task.Run(async () =>
                //    {
                //        await foreach (var resp in bathCat.ResponseStream.ReadAllAsync())
                //        {
                //            Console.WriteLine(resp.Message);
                //            Console.WriteLine($"This is  Response {Thread.CurrentThread.ManagedThreadId}");
                //            Console.WriteLine("**********************************");
                //        }
                //    });
                //    for (int i = 0; i < 10; i++)
                //    {
                //        await bathCat.RequestStream.WriteAsync(new BathTheCatReq() { Id = new Random().Next(0, 20) });
                //        await Task.Delay(100);
                //        Console.WriteLine($"This is {i} Request {Thread.CurrentThread.ManagedThreadId}");
                //        Console.WriteLine("**********************************");
                //    }
                //    //发送完毕
                //    await bathCat.RequestStream.CompleteAsync();
                //    Console.WriteLine("客户端已发送完10个id");
                //    Console.WriteLine("接收结果：");
                //    //开始接收响应
                //    await bathCatRespTask;
            }
        }
    }
}
