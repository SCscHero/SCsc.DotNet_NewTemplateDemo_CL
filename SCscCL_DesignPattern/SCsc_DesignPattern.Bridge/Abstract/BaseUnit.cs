using SCsc_DesignPattern.Bridge.Bridge;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCsc_DesignPattern.Bridge.Abstract
{
    /// <summary>
    /// 单位抽象父类
    /// </summary>
    public abstract class BaseUnit
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

        /// <summary>
        /// 展示攻击方式
        /// </summary>
        public abstract void ShowAttackWay();

        /// <summary>
        /// 展示死亡效果
        /// </summary>
        public abstract void ShowDeathEffect();
    }
}
