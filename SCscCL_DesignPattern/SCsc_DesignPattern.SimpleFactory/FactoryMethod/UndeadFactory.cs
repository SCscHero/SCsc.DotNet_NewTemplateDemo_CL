﻿using SCsc_DesignPattern.FactoryCorrelation.Interface;
using SCsc_DesignPattern.FactoryCorrelation.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SCsc_DesignPattern.FactoryCorrelation.FactoryMethod
{
    /// <summary>
    /// 工厂类
    /// </summary>
    public class UndeadFactory : IFactory
    {
        public IRace CreateInstance()
        {
            IRace race = new Undead();
            return race;
        }
    }

}