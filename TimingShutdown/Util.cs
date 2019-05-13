using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimingShutdown
{
    class Util
    {
        public static double txtConvertToInt(string txt)
        {
            double result = 0;
            bool f = double.TryParse(txt, out result);
            return result;
        }
    }
}
