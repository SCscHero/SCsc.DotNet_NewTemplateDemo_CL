using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCsc_DesignPattern.Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            //双判断锁写法
            {
                try
                {
                    Console.WriteLine("开始Start");
                    {
                        Console.WriteLine("***************双判断锁写法****************");
                        List<Task> tasks = new List<Task>();
                        for (int i = 0; i < 3; i++)
                        {
                            //启动线程完成计算，并发执行
                            tasks.Add(Task.Run(() =>
                            {
                                SingletonClass instance = SingletonClass.CreateInstance();
                                instance.Show();
                            }));
                        }
                        Task.WaitAll(tasks.ToArray());//等待全部任务的完成
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadLine();
            }

            //饿汉式单例写法
            {
                Console.WriteLine("****************饿汉式单例写法***************");
                for (int i = 0; i < 3; i++)
                {
                    Task.Run(() => {
                        SingletonClass2 singleton = SingletonClass2.CreateInstance();
                        singleton.Show();
                    });

                }

            }

            //饿汉式写法变招
            {
                Console.WriteLine("****************饿汉式写法变招***************");
                for (int i = 0; i < 3; i++)
                {
                    Task.Run(() => {
                        SingletonClass2 singleton = SingletonClass2.CreateInstance();
                        singleton.Show();
                    });

                }
            }
        }

        private CommonClass instance = new CommonClass();//对象复用

        private static void Show()
        {
            CommonClass instance = new CommonClass();//对象复用
            for (int i = 0; i < 3; i++)
            {
                instance.Show();
            }
        }
    }
}
