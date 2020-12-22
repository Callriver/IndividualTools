using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SupermarketSystem
{
    /// <summary>
    /// 买M元送N元
    /// </summary>
    class CallMN:CallFather
    {
        public double M
        {
            get;
            set;
        }
        public double N
        {
            get;
            set;
        }
        public CallMN(double m,double n)
        {
            this.M = m;
            this.N = n;
        }

        public override double getTotalMoney(double money)
        {
            if(money>=M){
                return money - (int)(money/M)*this.N;
            }
            else
            {
                return money;
            }
        }
    }
}
