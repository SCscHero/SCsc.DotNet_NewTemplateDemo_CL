using SCsc_DesignPattern.FactoryCorrelation.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCsc_DesignPattern.FactoryCorrelation.Model
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void PlayHuman(Human human)
        {
            Console.WriteLine("******************************");
            Console.WriteLine("This is {0} Play War3.{1}", this.Name, human.GetType().Name);
            human.ShowKing();
        }
        public void PlayUndead(Undead undead)
        {
            Console.WriteLine("******************************");
            Console.WriteLine("This is {0} Play War3.{1}", this.Name, undead.GetType().Name);
            undead.ShowKing();
        }
        //一个方法代替多个方法 泛型
        //即使将来种族有新的扩展，都可以使用
        public void Play(IRace iRace)
        {
            Console.WriteLine("******************************");
            Console.WriteLine("This is {0} Play War3.{1}", this.Name, iRace.GetType().Name);
            iRace.ShowKing();
        }
    }
}
