using System;
using System.Collections.Generic;
using System.Text;

namespace SCsc_DesignPattern.Singleton
{
    /// <summary>
    /// 保证线程安全的单例写法（.NET4之后支持）
    /// </summary>
    public sealed class SingletonClass10
    {
        private static readonly Lazy<SingletonClass10> lazy = new Lazy<SingletonClass10>(() => new SingletonClass10());

        public static SingletonClass10 Instance { get { return lazy.Value; } }
    }
}
