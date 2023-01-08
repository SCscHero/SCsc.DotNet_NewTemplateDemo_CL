using System;

namespace SCsc_DesignPattern.Builder
{
    /// <summary>
    /// 执行类
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("建造者设计模式");
            {
                AbstractTankBuilder builder = new BuilderSC2Tank();
                builder.Depot();
                builder.HeavyFactory();
                builder.SCV();
                builder.ScienceTechnologyLaboratory();
                builder.Tank();
            }


            Console.WriteLine("Director设计类");
            {
                AbstractTankBuilder builder = new BuilderSC2Tank();
                Director director = new Director(builder);
                director.GetTank();
            }

        }
    }
}
