using SCsc_DesignPattern.FactoryCorrelation.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCsc_DesignPattern.FactoryCorrelation.Model
{
    /// <summary>
    /// War3种族之一
    /// </summary>
    public class NE : IRace
    {
        public void ShowKing()
        {
            Console.WriteLine("The King of {0} is {1}", this.GetType().Name, "Moon");
        }
    }
}
