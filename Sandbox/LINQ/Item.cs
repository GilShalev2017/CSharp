using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.LINQ
{
    internal class Item
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }

        public string Category { get; set; }

        public decimal UnitPrice { get; set; }

        public int UnitsInStock { get; set; }

        public override string ToString()
        {
            return string.Format("ID={0}, Name={1}, Category={2}, UnitPrice={3}, UnitsInStock={4}", ItemID, ItemName, Category, UnitPrice, UnitsInStock);
        }
    }
}
