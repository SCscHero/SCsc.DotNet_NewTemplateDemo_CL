using SCsc_DesignPattern.FactoryCorrelation.Enum;
using SCsc_DesignPattern.FactoryCorrelation.Interface;
using SCsc_DesignPattern.FactoryCorrelation.Model;
using SCsc_DesignPattern.SimpleFactory.Helper;
using System;
using System.Reflection;

namespace SCsc_DesignPattern.SimpleFactory
{
    /// <summary>
    /// 简单工厂创建类
    /// </summary>
    public class ObjectFactory
    {
        public static IRace CreateInstance(RaceType raceType)
        {
            IRace race = null;
            switch (raceType)
            {
                case RaceType.Human:
                    race = new Human();
                    break;
                case RaceType.NE:
                    race = new NE();
                    break;
                case RaceType.ORC:
                    race = new ORC();
                    break;
                case RaceType.Undead:
                    race = new Undead();
                    break;
                default:
                    throw new Exception("wrong raceType");
            }
            return race;


        }

        private static string IRaceType = AppSettingHelper.GetConfig("IRaceType");
        public static IRace CreateInstanceConfig()
        {
            RaceType raceType = (RaceType)Enum.Parse(typeof(RaceType), IRaceType);
            return CreateInstance(raceType);
        }

        //真正的把细节依赖给去掉，意味着不能直接new，那怎么获取对象？ 反射

        private static string IRaceTypeReflection = AppSettingHelper.GetConfig("IRaceTypeReflection");
        public static IRace CreateInstanceConfigReflection()
        {
            Assembly assembly = Assembly.Load(IRaceTypeReflection.Split(',')[1]);
            Type type = assembly.GetType(IRaceTypeReflection.Split(',')[0]);
            return (IRace)Activator.CreateInstance(type);
        }

        //1  可配置后，如果一个接口，可能需要不同的实例？
        //2  今天只是创建Race，就需要一个方法；那项目中有N多个接口，难道每个接口都去创建一个工厂方法吗？
        //3  IOC&&DI。。。。

        /*
        今天课程都能听懂，100%      刷个1
                          80%       刷个2
                         低于80%    刷个3
          后面的三个问题我也了解的  刷个4
         */


    }

}
