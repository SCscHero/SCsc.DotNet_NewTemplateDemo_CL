using System;
using System.Collections.Generic;
using System.Text;

namespace SCsc_DesignPattern.Singleton
{
    /// <summary>
    /// 不使用锁实现线程安全，不全是延时初始化
    /// </summary>
    public sealed class SingletonClass12
    {
        private static readonly SingletonClass12 instance = new SingletonClass12();


        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static SingletonClass12()
        {
        }

        private SingletonClass12()
        {
        }

        public static SingletonClass12 Instance
        {
            get
            {
                return instance;
            }
        }
    }
}
