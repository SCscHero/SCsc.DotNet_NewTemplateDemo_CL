using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SCsc_DesignPattern.Singleton
{
    /// <summary>
    /// 普通类，耗时耗资源
    /// </summary>
    public class CommonClass
    {
        public CommonClass()
        {
            long IResult = 0;
            for (int i = 0; i < 100 - 000 - 000; i++)
            {
                IResult += i;
            }
            Thread.Sleep(2000);
            Console.WriteLine($"{this.GetType().Name}完成构造...");
        }

        public void Show()
        {
            Console.WriteLine($"{this.GetType().Name} Show...");
        }
    }
}
