using SCsc_DesignPattern.Bridge.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCsc_DesignPattern.Bridge.Bridge.DiedEffect
{
    /// <summary>
    /// 人族死亡效果
    /// </summary>
    public class HumanDiedEffect : IDiedEffect
    {
        public void ShowDeathEffect()
        {
            Console.WriteLine("人族死亡效果！");
        }
    }
}
