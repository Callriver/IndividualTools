using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SupermarketSystem
{
    class CallRate:CallFather
    {
        /// <summary>
        /// 按折扣率打折
        /// </summary>
        /// <param name="money"></param>
        /// <returns></returns>
        public override double getTotalMoney(double money)
        {
            return money * Rate;
        }
        public double Rate
        {
            get;
            set;
        }
        public CallRate(double rate)
        {
            this.Rate = rate;
        }

    }
}
