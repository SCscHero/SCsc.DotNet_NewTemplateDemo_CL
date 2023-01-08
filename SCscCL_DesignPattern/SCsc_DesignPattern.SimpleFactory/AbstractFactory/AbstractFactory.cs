using SCsc_DesignPattern.FactoryCorrelation.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCsc_DesignPattern.FactoryCorrelation.AbstractFactory
{
    /// <summary>
    /// 抽象工厂
    /// </summary>
    public abstract class AbstractFactory
    {
        public abstract IManeuverability CreateManeuverability();

    }
}
