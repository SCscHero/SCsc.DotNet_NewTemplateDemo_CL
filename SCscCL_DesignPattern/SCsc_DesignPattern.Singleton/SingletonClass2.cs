using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SCsc_DesignPattern.Singleton
{
    /// <summary>
    /// 饿汉式单例写法
    /// </summary>
    public class SingletonClass2
    {
        public SingletonClass2()
        {
            long IResult = 0;
            for (int i = 0; i < 100 - 000 - 000; i++)
            {
                IResult += i;
            }
            Thread.Sleep(2000);
            Console.WriteLine($"{this.GetType()}完成构造...");
        }

        private static SingletonClass2 Instance = null;

        /// <summary>
        /// 静态构造函数，由CLR调用，在类型第一次被使用前调用，且只调用一次！
        /// </summary>
        static SingletonClass2()
        {
            Instance = new SingletonClass2();
        }

        public static SingletonClass2 CreateInstance()
        {
            return Instance;
        }

        public static void DoNothing() { }

        public void Show()
        {
            Console.WriteLine($"{this.GetType().Name}Show...");
        }


    }
}
