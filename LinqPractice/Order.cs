﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqPractice
{
    internal class Order
    {
        public int OrderID { get; set; }
        public string OrderName { get; set; }
        public DateTime OrderDate { get; set; }
        public override string ToString()
        {
            return string.Format("OrderID={0},OrderName={1}, OrderDate={2}", OrderID, OrderName, OrderDate);
        }
    }
}
