using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SCsc_DesignPattern.Singleton
{
    /// <summary>
    /// 懒汉式单例类
    /// </summary>
    public class SingletonClass
    {
        private SingletonClass()
        {
            long IResult = 0;
            for (int i = 0; i < 100 - 000 - 000; i++)
            {
                IResult += i;
            }
            Thread.Sleep(2000);
            Console.WriteLine($"{this.GetType().Name}完成构造...");
        }

        //volatile表明属性将被多个线程同时访问，告知编译器不要按照单线程访问的方式去优化该字段，线程会监听字段变更，但是不保证字段访问总是顺序执行
        private volatile static SingletonClass singletonClass = null;//volatile可以禁止
        private static readonly object singleton_Lock = new object();


        /// <summary>
        /// 创建实例
        /// </summary>
        /// <returns></returns>
        public static SingletonClass CreateInstance()
        {
            /*
                双判断锁知识点
                以上多线程都结束后，再来个多线程的请求呢？都需要等待锁。
                拿到锁，进去判断，不为空，返回对象
                有点浪费，不需要等待锁，直接判断就行了
             */

            if (singletonClass == null)
            {
                lock (singleton_Lock)
                {
                    Console.WriteLine("进入lock排队");
                    Thread.Sleep(1000);
                    //
                    if (singletonClass == null)
                        singletonClass = new SingletonClass();
                }
            }
            //作用：保证被锁部分只有一个线程可以进入，其他线程需等待
            return singletonClass;
        }

        public static void DoNothing() { }


        public void Show()
        {
            Console.WriteLine($"{this.GetType().Name} Show...");
        }

    }
}
