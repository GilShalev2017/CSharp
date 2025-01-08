using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.LINQ
{
    internal class Tester
    {
        private List<Item>? _itemList;
        private List<Order>? _orderList;
        private void CreateLists()
        {
            _itemList = new List<Item>
            {
                new Item() { ItemID = 1, ItemName = "Enceclopedia", Category = "Knowledege", UnitPrice = 55.99M, UnitsInStock = 39 },
                new Item() { ItemID = 2, ItemName = "Trainers", Category = "Sports", UnitPrice = 75.00M, UnitsInStock = 17 },
                new Item() { ItemID = 3, ItemName = "Box of CDs", Category = "Storage", UnitPrice = 4.99M, UnitsInStock = 13 },
                new Item() { ItemID = 4, ItemName = "Tomatoe Ketchup", Category = "Food", UnitPrice = 0.56M, UnitsInStock = 53 },
                new Item() { ItemID = 5, ItemName = "IPod", Category = "Entertainment", UnitPrice = 200.99M, UnitsInStock = 0 },
                new Item() { ItemID = 6, ItemName = "Rammstein CD", Category = "Entertainment", UnitPrice = 7.99M, UnitsInStock = 120 },
                new Item() { ItemID = 7, ItemName = "War of the worlds DVD", Category = "Entertainment", UnitPrice = 6.99M, UnitsInStock = 15 },
                new Item() { ItemID = 8, ItemName = "Cranberriy sauce", Category = "Food", UnitPrice = 0.89M, UnitsInStock = 6 },
                new Item() { ItemID = 9, ItemName = "Rice steamer", Category = "Food", UnitPrice = 13.00M, UnitsInStock = 29 },
                new Item() { ItemID = 10, ItemName = "Bunch of grapes", Category = "Food", UnitPrice = 1.19M, UnitsInStock = 4 },
            };

            _orderList = new List<Order>
            {
                new Order() {OrderID=1, OrderName="John Smith", OrderDate = DateTime.Now },
                new Order() {OrderID=2, OrderName="Professor X", OrderDate = DateTime.Now },
                new Order() {OrderID=3, OrderName="Naomi Campbell", OrderDate = DateTime.Now },
                new Order() {OrderID=4, OrderName="The hulk", OrderDate = DateTime.Now },
                new Order() {OrderID=5, OrderName="Malcolm X", OrderDate = DateTime.Now },
            };
        }

        //In some questions there are several options to solve: for instance collection.Where(), collection.FindAll() and "sql like" select too!!!

        public Tester()
        {
            CreateLists();
        }
    }
}
