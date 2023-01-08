using SCsc_DesignPattern.Bridge.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCsc_DesignPattern.Bridge.Bridge
{
    public class BaseUnitBridge
    {
        /// <summary>
        /// 生命值
        /// </summary>
        public int LifeValue { get; set; }

        /// <summary>
        /// 攻击力
        /// </summary>
        public int AttackPower { get; set; }

        /// <summary>
        /// 攻击力
        /// </summary>
        public int DefensiveForce { get; set; }

        public IAttackWay _IAttackWay { set; get; }

        public IDiedEffect _IDiedEffect { set; get; }
    }
}
