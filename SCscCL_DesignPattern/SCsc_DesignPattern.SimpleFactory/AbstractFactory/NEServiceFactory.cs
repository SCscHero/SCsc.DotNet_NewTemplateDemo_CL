using SCsc_DesignPattern.FactoryCorrelation.Interface;
using SCsc_DesignPattern.FactoryCorrelation.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCsc_DesignPattern.FactoryCorrelation.AbstractFactory
{
    /// <summary>
    /// 暗夜服务创建工厂
    /// </summary>
    public class NEServiceFactory: AbstractFactory
    {
        /// <summary>
        /// 创建人族服务
        /// </summary>
        /// <returns></returns>
        public override IManeuverability CreateManeuverability()
        {
            return new NEService();
        }
    }
}
