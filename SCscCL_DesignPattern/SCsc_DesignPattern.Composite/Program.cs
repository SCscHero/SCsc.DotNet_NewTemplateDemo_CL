using System;

namespace SCsc_DesignPattern.Composite
{

    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("****************组合模式****************");
            //递归，寻找该目录下有多少文件夹
            var list = Recursion.GetDirectoryList(@"D:\00004.星际争霸2");


            try
            {

                double total = 1000000;
                //Domain domain = BuildTree();

                //domain.Commission(total);

                //公司交税5个点   95%公司收入  成本45%  利润50%   董事会  80%   
                //其余20%   CEO 30%  。。。。。。。。。。。

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();

        }
    }
}
