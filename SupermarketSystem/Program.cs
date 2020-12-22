using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SupermarketSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建超市对象
            SuperMarket sm = new SuperMarket();
            sm.ShowPros();
            sm.AskBuying();
            Console.ReadKey();
        }
    }
}
