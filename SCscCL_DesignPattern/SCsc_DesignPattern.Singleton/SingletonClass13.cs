using System;
using System.Collections.Generic;
using System.Text;

namespace SCsc_DesignPattern.Singleton
{
    /// <summary>
    /// 线程安全，避免实例创建和引用赋值混乱
    /// </summary>
    public sealed class SingletonClass13
    {
        private static SingletonClass13 instance = null;
        private static readonly object _lock = new object();

        SingletonClass13()
        {

        }

        public static SingletonClass13 Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (_lock)
                    {
                        if (instance == null)
                        {
                            var tmp = new SingletonClass13();
                            //ensures that the instance is well initialized
                            //and only then,it assigns the static variable.
                            System.Threading.Thread.MemoryBarrier();
                            instance = tmp;
                        }
                    }
                }
                return instance;
            }
        }

    }
}
