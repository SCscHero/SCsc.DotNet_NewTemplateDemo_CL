using System;
using System.Collections.Generic;
using System.Text;

namespace SCsc_DesignPattern.Singleton
{
    /// <summary>
    /// 线程安全，延时初始化
    /// </summary>
    public sealed class SingletonClass11
    {
        private SingletonClass11()
        {
        }

        public static SingletonClass10 Instance { get { return Nested.instance; } }

        /*
         只有当Nested类的第一个引用调用时，Singleton才会被实例化，也就是调用Instance，是完全的延时初始化
             */
        private class Nested
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested()
            {
            }

            internal static readonly SingletonClass10 instance = new SingletonClass10();
        }
    }
}
