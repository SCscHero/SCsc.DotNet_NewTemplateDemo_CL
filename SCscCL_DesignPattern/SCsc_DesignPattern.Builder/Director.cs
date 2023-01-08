using System;
using System.Collections.Generic;
using System.Text;

namespace SCsc_DesignPattern.Builder
{
    /// <summary>
    /// 导演
    /// </summary>
    public class Director
    {
        private AbstractTankBuilder _AbstractBuilder = null;
        public Director(AbstractTankBuilder build)
        {
            this._AbstractBuilder = build;
        }

        /// <summary>
        /// 获取坦克
        /// </summary>
        public void GetTank()
        {
            this._AbstractBuilder.ScienceTechnologyLaboratory();
            this._AbstractBuilder.SCV();
            this._AbstractBuilder.HeavyFactory();
            this._AbstractBuilder.Depot();
        }
    }
}
