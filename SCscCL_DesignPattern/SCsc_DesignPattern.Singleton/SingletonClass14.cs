using System;
using System.Collections.Generic;
using System.Text;

namespace SCsc_DesignPattern.Singleton
{
    /// <summary>
    /// 双重锁判断
    /// </summary>
    public sealed class SingletonClass14
    {
        private volatile static SingletonClass14 instance = null;//Volatile可以禁止
        private static readonly object _lock = new object();
        SingletonClass14()
        {

        }

        public static SingletonClass14 Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (_lock)
                    {
                        if (instance == null)
                        {
                            instance = new SingletonClass14();
                        }
                    }
                }
                return instance;
            }
        }
    }
}
