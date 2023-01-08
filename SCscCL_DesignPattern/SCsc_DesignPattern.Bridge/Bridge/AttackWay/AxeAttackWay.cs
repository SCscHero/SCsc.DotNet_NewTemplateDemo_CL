using SCsc_DesignPattern.Bridge.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCsc_DesignPattern.Bridge.Bridge.AttackWay
{
    public class AxeAttackWay : IAttackWay
    {
        public void ShowAttackWay()
        {
            Console.WriteLine("斧头攻击");
        }
    }
}
