﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SupermarketSystem
{
    class Banana:ProductFather
    {
        public Banana(string id, double price, string name)
            : base(id, price, name)
        {

        }
    }
}
