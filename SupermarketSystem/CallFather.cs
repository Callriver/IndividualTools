using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SupermarketSystem
{
    abstract class CallFather
    {
        /// <summary>
        /// 计算打折后应付多少钱
        /// </summary>
        /// <param name="money">打折前的钱</param>
        /// <returns>打折后的钱</returns>
        public abstract double getTotalMoney(double money);
    }
}
