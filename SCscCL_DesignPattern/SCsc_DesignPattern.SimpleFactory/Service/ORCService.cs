using SCsc_DesignPattern.FactoryCorrelation.Interface;
using SCsc_DesignPattern.FactoryCorrelation.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCsc_DesignPattern.FactoryCorrelation.Service
{
    public class ORCService : IManeuverability
    {


        public void AttackFormation()
        {
            Console.WriteLine($"{typeof(ORC).Name}进攻！");
        }

        public void DefenseFormation()
        {
            Console.WriteLine($"{typeof(ORC).Name}防御！");
        }
        public void Training<T>(T unit)
        {
            Console.WriteLine(unit.ToString());
        }
    }
}
