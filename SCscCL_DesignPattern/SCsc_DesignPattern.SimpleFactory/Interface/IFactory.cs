using SCsc_DesignPattern.SimpleFactory;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SCsc_DesignPattern.FactoryCorrelation.Interface
{
    /// <summary>
    /// 工厂类
    /// </summary>
    public interface IFactory
    {
        IRace CreateInstance();
    }

}
