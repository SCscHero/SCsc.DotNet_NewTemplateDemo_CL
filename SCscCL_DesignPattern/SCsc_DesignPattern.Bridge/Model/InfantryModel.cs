using SCsc_DesignPattern.Bridge.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCsc_DesignPattern.Bridge.Model
{
    /// <summary>
    /// 步兵实体
    /// </summary>
    public class InfantryModel : BaseUnit
    {
        public override void ShowAttackWay()
        {
            Console.WriteLine("铁剑攻击！");
        }

        public override void ShowDeathEffect()
        {
            Console.WriteLine("呃——！————！");
        }
    }
}
