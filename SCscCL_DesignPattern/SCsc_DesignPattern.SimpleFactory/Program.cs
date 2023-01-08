using SCsc_DesignPattern.FactoryCorrelation.AbstractFactory;
using SCsc_DesignPattern.FactoryCorrelation.Enum;
using SCsc_DesignPattern.FactoryCorrelation.Interface;
using SCsc_DesignPattern.FactoryCorrelation.Model;
using System;

namespace SCsc_DesignPattern.SimpleFactory
{
    /// <summary>
    /// 1 依赖倒置原则，SimpleFactory
    /// 2 简单工厂+ 配置文件=可配置
    /// 3 简单工厂+ 配置文件+反射=可配置可扩展
    /// 4 简单工厂升级IOC控制反转
    /// 
    /// 备战2019跳槽季，设计模式再来一波
    /// 设计模式：面向对象语言开发过程中，遇到种种的场景和问题，提出解决方案和思路，沉淀下来
    ///           前辈的智慧，是解决问题的套路，学习设计模式就是为了站在前辈的肩膀上
    /// 结构型设计模式(装饰器)：关注类与类之间的关系
    /// 行为型设计模式(责任链)：关注对象和行为的分离
    /// 创建型设计模式(三大工厂)：关注对象的创建         
    /// 学习设计模式的套路：
    ///     场景出发---解决问题---沉淀总结---推广应用(无尽升级)
    /// 
    /// 依赖倒置原则：上层模块不应该依赖于下层模块，二者应该通过抽象来依赖
    ///               依赖抽象，而不是依赖细节
    ///   
    /// GOF23种设计模式是不包含简单工厂
    /// 简单工厂设计模式：包含一组需要创建的对象，通过一个工厂类来实例化对象，
    /// 好处就是去掉上端对细节的依赖，保证上端的稳定
    /// 缺陷：
    ///      没有消除矛盾，只是转移矛盾，甚至还集中了矛盾
    /// 任何设计模式都是解决一类问题的，不是万能的，
    /// 通常在解决一类问题的时候，还会带来新的问题
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("欢迎来到.Net高级班公开课之设计模式特训，今天是Eleven老师为大家带来的简单工厂模式");

                Player player = new Player()
                {
                    Id = 123,
                    Name = "Eleven"
                };
                {
                    Human race = new Human();//1 最原始最习惯的
                }
                {
                    IRace race = new Human();//2 左边换成抽象 依赖倒置原则
                }
                {
                    IRace race = ObjectFactory.CreateInstance(RaceType.Human);
                    //new IRace();//接口不能直接实例化  问题出来了，既不想依赖细节，又需要对象
                    player.Play(race);
                }
                {
                    //可配置
                    Console.WriteLine("*****************Factory+Config***************");
                    IRace race = ObjectFactory.CreateInstanceConfig();
                    player.Play(race);
                }
                {
                    //可配置可扩展
                    Console.WriteLine("*****************Factory+Config+Reflection***************");
                    IRace race = ObjectFactory.CreateInstanceConfigReflection();
                    player.Play(race);
                }


                //{
                //    Human human = new Human();
                //    player.PlayHuman(human);
                //    player.Play(human);
                //}
                //{
                //    Undead undead = new Undead();
                //    player.PlayUndead(undead);
                //    player.Play(undead);
                //}
                //{
                //    ORC oRC = new ORC();
                //    player.Play(oRC);
                //}
                //{
                //    NE nE = new NE();
                //    player.Play(nE);
                //}
                //类库
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();


            //抽象工厂设计模式使用示例
            {
                AbstractFactory abstractFactory = new HumanServiceFactory();
                IManeuverability iManeuverability = abstractFactory.CreateManeuverability();
                iManeuverability.Training("骑兵");
            }
        }
    }
}
