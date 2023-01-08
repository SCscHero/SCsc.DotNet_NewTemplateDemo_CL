using SCsc_DesignPattern.Bridge.Bridge;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCsc_DesignPattern.Bridge.Model
{
    public class InfantryAxeModel : InfantryModel
    {
        public override void ShowAttackWay()
        {
            Console.WriteLine("铁剑攻击！");
        }

    }
}
