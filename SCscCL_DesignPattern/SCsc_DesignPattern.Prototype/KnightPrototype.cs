using System;
using System.Collections.Generic;
using System.Text;

namespace SCsc_DesignPattern.Prototype
{
    /// <summary>
    /// 骑士原型类
    /// </summary>
    public class KnightPrototype
    {
        /// <summary>
        /// 单位编号
        /// </summary>
        public int UnitId { get; set; } = 11430;
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 血量
        /// </summary>
        public double BloodVolume { get; set; } = 980;
        /// <summary>
        /// 攻击力
        /// </summary>
        public double AttackPower { get; set; } = 27;
        /// <summary>
        /// 护甲
        /// </summary>
        public double Armor { get; set; } = 6;
        /// <summary>
        /// 移动速度
        /// </summary>
        public double MovingSpeed { set; get; } = 15;
        /// <summary>
        /// 花费金额
        /// </summary>
        public CostStandardModel CostStandardModel { set; get; } = new CostStandardModel
        {
            Gold = 550,
            Wood = 110
        };
    }
}
