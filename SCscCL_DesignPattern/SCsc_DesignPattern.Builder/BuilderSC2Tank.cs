using System;
using System.Collections.Generic;
using System.Text;

namespace SCsc_DesignPattern.Builder
{
    /// <summary>
    /// 星际2坦克（需要科技实验室、重工厂、SCV、Depot）
    /// </summary>
    public class BuilderSC2Tank : AbstractTankBuilder
    {
        private string _ScienceTechnologyLaboratory = null;
        private string _HeavyFactory = null;
        private string _SCV = null;
        private string _Depot = null;

        public override void ScienceTechnologyLaboratory()
        {
            Console.WriteLine($"{this.GetType().Name} ScienceTechnologyLaboratory Builder");
        }

        public override void HeavyFactory()
        {
            Console.WriteLine($"{this.GetType().Name} HeavyFactory Builder");
        }

        public override void SCV()
        {
            Console.WriteLine($"{this.GetType().Name} SCV Builder");
        }

        public override void Depot()
        {
            Console.WriteLine($"{this.GetType().Name} Depot Builder");
        }

        public override void Tank()
        {
            if (_ScienceTechnologyLaboratory == null)
                Console.WriteLine("缺少科技实验室！");
            if (_HeavyFactory == null)
                Console.WriteLine("缺少重工厂！");
            if (_SCV == null)
                Console.WriteLine("缺少SCV！");
            if (_Depot == null)
                Console.WriteLine("缺少补给站！");
            if (_ScienceTechnologyLaboratory != null && _HeavyFactory != null && _SCV != null && _Depot != null)
                Console.WriteLine("建造完成！");

        }
    }
}
