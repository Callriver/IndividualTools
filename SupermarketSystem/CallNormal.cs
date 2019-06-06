using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SupermarketSystem
{
    class CallNormal:CallFather
    {
        public override double getTotalMoney(double money)
        {
            return money;
        }
    }
}
