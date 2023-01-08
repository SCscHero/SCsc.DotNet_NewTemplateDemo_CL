using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SCsc_DesignPattern.Prototype
{
    /// <summary>
    /// 步兵原型类
    /// </summary>
    [Serializable]
    public class InfantryPrototype
    {
        /// <summary>
        /// 单位编号
        /// </summary>
        public int UnitId { get; set; } = 9073;
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 血量
        /// </summary>
        public double BloodVolume { get; set; } = 450;
        /// <summary>
        /// 攻击力
        /// </summary>
        public double AttackPower { get; set; } = 11;
        /// <summary>
        /// 护甲
        /// </summary>
        public double Armor { get; set; } = 3;
        /// <summary>
        /// 移动速度
        /// </summary>
        public double MovingSpeed { set; get; } = 6;


        /// <summary>
        /// 花费金额
        /// </summary>
        public CostStandardModel CostStandardModel { set; get; } = new CostStandardModel
        {
            Gold = 350,
            Wood = 0
        };


        /// <summary>
        /// 构造函数私有化
        /// </summary>
        private InfantryPrototype()
        {
            Thread.Sleep(2000);
            long IResult = 0;
            for (int i = 0; i < 100 - 000 - 000; i++)
            {
                IResult += i;
            }
            Console.WriteLine($"{this.GetType().Name}被构造");
        }

        private static InfantryPrototype _InfantryPrototype = new InfantryPrototype()
        {
            Name = "SCscHeroInfantry"
        };

        public static InfantryPrototype CreateInstance()
        {
            //MemberwiseClone()：内存拷贝，不走构造函数，直接内存copy，所以没有性能损失
            InfantryPrototype infantry = (InfantryPrototype)_InfantryPrototype.MemberwiseClone();
            return _InfantryPrototype;
        }

        public static InfantryPrototype CreateInstanceSerialize()
        {
            return SerializeHelper.DeepClone(_InfantryPrototype);
        }

    }
}
