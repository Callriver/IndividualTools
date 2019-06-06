using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SupermarketSystem
{
    //超市类
    class SuperMarket
    {
        Cangku cangku = new Cangku();
        //创建超市对象的时候,给仓库的货架上导入商品
        public SuperMarket()
        {
            cangku.JinPros("Acer",10);
            cangku.JinPros("Banana",30);
            cangku.JinPros("SamSung", 101);
            cangku.JinPros("Jiangyou",1000);
        }

        //跟用户交互的过程
        public void AskBuying()
        {
            Console.WriteLine("萨瓦迪卡,请问您需要些什么?");
            Console.WriteLine("我们有Acer,SamSung,Banana,Jiangyou");
            string strType = Console.ReadLine();
            Console.WriteLine("您需要多少?");
            int count = Convert.ToInt32(Console.ReadLine());
            //取出商品
            ProductFather[] pros= cangku.QuPros(strType, count);
            //下面该计算价钱
            double money=GetMoney(pros);
            Console.WriteLine("你总共应付{0}元",money);
            Console.WriteLine("请选择您的打折方式:    1--不打折  2--打九折  3--打八五折 4--满300送50  5--满500送100");
            string input = Console.ReadLine();
            //通过简单工厂的设计模式,根据用户输入来获取一个打折对象
            CallFather cal=GetCal(input);
            double totalMoney=cal.getTotalMoney(money);
            Console.WriteLine("打完折后,你应付{0}元", totalMoney);
        }

        //计算总价钱
        public double GetMoney(ProductFather[] pros)
        {
            double money=0;
            foreach (var item in pros)
            {
                money+=item.Price;
            }
            return money;
        }
        /// <summary>
        /// 根据用户输入返回打折对象
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public CallFather GetCal(string input)
        {
            CallFather cal = null;
            switch (input)
            {
                case "1": cal = new CallNormal();
                    break;
                case "2": cal = new CallRate(0.9);
                    break;
                case "3": cal = new CallRate(0.85);
                    break;
                case "4": cal = new CallMN(300,50);
                    break;
                case "5": cal = new CallMN(500, 100);
                    break;
            }
            return cal;
        }

        public void ShowPros()
        {
            cangku.ShowPros();
        }
    }
}
