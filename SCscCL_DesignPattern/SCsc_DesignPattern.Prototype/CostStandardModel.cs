using System;
using System.Collections.Generic;
using System.Text;

namespace SCsc_DesignPattern.Prototype
{
    /// <summary>
    /// 花费模型类
    /// </summary>
    [Serializable]
    public class CostStandardModel
    {
        /// <summary>
        /// 金子
        /// </summary>
        public double Gold { set; get; }
        /// <summary>
        /// 木头
        /// </summary>
        public double Wood { set; get; }
    }
}
