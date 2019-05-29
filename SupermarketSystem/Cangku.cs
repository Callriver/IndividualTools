using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SupermarketSystem
{
    class Cangku
    {
        //存储货物
        List<List<ProductFather>> list = new List<List<ProductFather>>();
        //在创建仓库时，向仓库添加货架
        //list[0]存宏基电脑
        //list[1]存储三星手机
        //list[2]存储香蕉
        //list[3]存储酱油
        public Cangku()
        {
            list.Add(new List<ProductFather>());
            list.Add(new List<ProductFather>());
            list.Add(new List<ProductFather>());
            list.Add(new List<ProductFather>());
        }
        //进货
        public  void JinPros(string strType,int count)
        {
            for(int i=0;i<count;i++){
                switch (strType)
                {
                    case "Acer": list[0].Add(new Acer(Guid.NewGuid().ToString(),1000,"宏基笔记本"));
                    break;
                    case "Banana": list[1].Add(new Banana(Guid.NewGuid().ToString(),10,"大香蕉"));
                    break;
                    case "Jiangyou": list[2].Add(new Jiangyou(Guid.NewGuid().ToString(), 5, "酱油"));
                    break;
                    case "SamSung": list[3].Add(new SamSung(Guid.NewGuid().ToString(), 2000, "三星手机"));
                    break;
                }
            }
        }

        //取货
        public void QuPros(string strType,int count)
        {

        }
    }
}
