using SCsc_DesignPattern.FactoryCorrelation.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCsc_DesignPattern.FactoryCorrelation.Service
{
    public class HumanService : IManeuverability
    {
        /// <summary>
        /// 人族服务
        /// </summary>
        public void AttackFormation()
        {
            Console.WriteLine("人族进攻！");
        }

        public void DefenseFormation()
        {
            Console.WriteLine("人族防御！");
        }

        public void MusketeersGruop()
        {
            Console.WriteLine("火枪流速攻！");
        }

        public void Training<T>(T unit)
        {
            Console.WriteLine(unit.ToString());
        }
    }
}
