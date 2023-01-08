using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SCsc_DesignPattern.Singleton
{
    /// <summary>
    /// 
    /// </summary>
    public class SingletonClass3
    {
        public SingletonClass3()
        {
            long IResult = 0;
            for (int i = 0; i < 100 - 000 - 000; i++)
            {
                IResult += i;
            }
            Thread.Sleep(2000);
            Console.WriteLine($"{this.GetType()}完成构造...");
        }

        /// <summary>
        /// 静态字段，由CLR调用，在类型第一次被使用前初始化，且只初始化一次！
        /// </summary>
        private static SingletonClass3 Instance = new SingletonClass3();

        /// <summary>
        /// 静态构造函数，由CLR调用，在类型第一次被使用前调用，且只调用一次！
        /// </summary>
        static SingletonClass3()
        {
            Instance = new SingletonClass3();
        }

        public static SingletonClass3 CreateInstance()
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
