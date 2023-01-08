using System;

namespace SCsc_DesignPattern.Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**************Prototype 浅拷贝实例*************");
            InfantryPrototype infantryPrototype1 = InfantryPrototype.CreateInstance();
            InfantryPrototype infantryPrototype2 = InfantryPrototype.CreateInstance();
            InfantryPrototype infantryPrototype3 = InfantryPrototype.CreateInstance();

            infantryPrototype1.Name = "步兵1";
            infantryPrototype2.Name = "步兵2";
            infantryPrototype3.Name = "步兵3";

            string str1 = "str1";
            string str2 = str1;
            string str3 = str2;


            /*
             * 知识点：C#内存分配
             * 进程堆（进程唯一），线程栈（每个线程一个）
             * 引用类型在堆里，值类型在栈上，变量都在栈里
             * 
             * 问题1：引用类型中的值类型，是在堆里面还是栈里面？
             * 答案：堆里面
             * 
             * 问题2：结构体中的string类型，是在堆里面还是栈里面？
             * 答案：堆里面
             * 
             * 问题：如何完成深拷贝？
             * 答案：重新拉一块内存空间，将原来的值重新赋值，完成深拷贝。
             * 
             * 问题：什么是深拷贝？
             * 答案：不仅拷贝值类型，还拷贝引用类型的值，存的是值，不是地址。
             * 
             * 问题：为什么string是引用类型，但是却不互相影响？
             * 答案：因为string类型的赋值符号"="做了运算符重载，等同于new String("CodeMan");开辟新的空间，不影响之前的——实际上string是不可修改的。
             * 
             * 问题：深拷贝（Deepcopy）有没有快速简单的方式？
             * 答案：1、可以直接new。2、若嫌麻烦，则子类型需要提供原型方式，提供自己的实例化方法。3、序列化反序列化
             */



        }
    }
}
