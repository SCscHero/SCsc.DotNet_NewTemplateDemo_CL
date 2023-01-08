using SCsc_DesignPattern.Bridge.Abstract;
using SCsc_DesignPattern.Bridge.Bridge;
using SCsc_DesignPattern.Bridge.Bridge.AttackWay;
using SCsc_DesignPattern.Bridge.Bridge.DiedEffect;
using SCsc_DesignPattern.Bridge.Model;
using System;

namespace SCsc_DesignPattern.Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            /*
             * 重建类
             * 缺点：类太多，不够灵活。类数量：M（原模型书）*N（某属性变化数）
             */
            {
                BaseUnit infantry = new InfantryAxeModel();
                infantry.ShowAttackWay();
            }

            /*
             * 桥接模式
             * 优点：哪里变化封装哪里，灵活。类数量：M（原模型书）+N（某属性变化数）
             */
            {
                BaseUnitBridge infantry = new InfantryBridgeModel();
                infantry._IAttackWay = new AxeAttackWay();
                infantry._IAttackWay.ShowAttackWay();
            }
        }
    }
}
