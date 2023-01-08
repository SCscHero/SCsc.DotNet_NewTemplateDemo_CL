using System;
using System.Collections.Generic;
using System.Text;

namespace SCsc_DesignPattern.Prototype
{
    /// <summary>
    /// 防御技能模型类
    /// </summary>
    public class DefenseSkillsModel
    {
        /// <summary>
        /// 护甲效果
        /// </summary>
        public double ArmorBuff { set; get; } = 2;
        /// <summary>
        /// 移动速度效果
        /// </summary>
        public double MovingSpeedBuff { set; get; } = -5;
    }
}
