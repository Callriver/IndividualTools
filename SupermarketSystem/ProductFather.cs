using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SupermarketSystem
{
    class ProductFather
    {
        public string ID
        {
            get;
            set;
        }

        public double Price
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public ProductFather(string id,double price,string name)
        {
            this.ID = id;
            this.Price = price;
            this.Name = name;
        }
    }
}
