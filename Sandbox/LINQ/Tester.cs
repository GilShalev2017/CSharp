using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
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
                new Order() {OrderID=1, OrderName="John Smith", OrderDate = DateTime.Now, ItemID = 3  },
                new Order() {OrderID=2, OrderName="Professor X", OrderDate = DateTime.Now, ItemID = 6  },
                new Order() {OrderID=3, OrderName="Naomi Campbell", OrderDate = DateTime.Now, ItemID = 1  },
                new Order() {OrderID=4, OrderName="The hulk", OrderDate = DateTime.Now, ItemID = 7  },
                new Order() {OrderID=5, OrderName="Malcolm X", OrderDate = DateTime.Now, ItemID = 9  },
            };
        }

        //In some questions there are several options to solve: for instance collection.Where(), collection.FindAll() and "sql like" select too!!!

        public Tester()
        {
            CreateLists();
        }

        public IEnumerable<Item>? PriceGreaterThan10()
        {
            //return _itemList != null ? _itemList!.FindAll(item => item.UnitPrice > 10) : null;

            return _itemList != null ? _itemList!.Where(item => item.UnitPrice > 10) : null;
        }

        public void PrintAllItems(IEnumerable<Item>? items)
        {
            if (items == null)
                return;

            foreach(var item in items)
            {
                Console.WriteLine(item);
            }
        }
        
        public IEnumerable<Order>? OrdersOfJohn()
        {
           // return _orderList != null ? _orderList!.FindAll(order => order.OrderName == "John Smith") : null;

            return _orderList != null ? _orderList!.Where(order => order.OrderName == "John Smith") : null;
        }

        public void PrintAllOrders(IEnumerable<Order>? orders)
        {
            if (orders == null)
                return;

            foreach (var order in orders)
            {
                Console.WriteLine(order);
            }
        }

        public IEnumerable<string>? FindAllItemNames()
        {
            /*
            List<string> names = new();

            if (_itemList == null)
                return null;

            foreach(var item in _itemList)
            {
                names.Add(item.ItemName);
            }

            return names;*/
            var names = from item in _itemList
                        select item.ItemName;

            return names;
        }

        public void PrintStrings(IEnumerable<string>? strings)
        {
            if(strings == null) return;

            foreach (var item in strings)
            {
                Console.WriteLine($"{item}");
            }
        }

        public IEnumerable<string> FindAllOrderNames()
        {
            var names = from order in _orderList
                        select order.OrderName;
            return names;
        }

        public IEnumerable<Order> FindAllOrders()
        {
            return _orderList ?? Enumerable.Empty<Order>();
        }

        public IEnumerable<Item>? FindAllItemsWithPriceBiggerThan10()
        {
            return _itemList != null ? _itemList!.FindAll(item => item.UnitPrice > 10) : null;
        }
        public IEnumerable<Item>? FindGreaterThan10UsingWhere()
        {
            return _itemList != null ? _itemList!.Where(item => item.UnitPrice > 10) : null;
        }

        public IEnumerable<Item> SortByPriceAndTake2MostExpensive()
        {
            if(_itemList == null)
                return Enumerable.Empty<Item>();

            return _itemList.OrderByDescending(item => item.UnitPrice).Take(2);
        }

        public IEnumerable<Item> SortByPriceAndSkipFirst2MostExpensive()
        {
            if(_itemList == null)
                return Enumerable.Empty<Item>();

            return _itemList.OrderByDescending(order => order.UnitPrice).Skip(2);
        }

        public dynamic JoinItemsAndOrders()
        {
            var merged = from item in _itemList
                         join order in _orderList
                         on item.ItemID equals order.ItemID
                         select new { item.ItemName, order.OrderName };

            Console.WriteLine("");
            foreach (var element in merged)
                Console.WriteLine(element.ItemName + "-" + element.OrderName);

            return merged;
        }

        public IOrderedEnumerable<IGrouping<string, Item>> GroupByCategory()
        {
            var groupByCategory =
                    from item in _itemList
                    group item by item.Category into newGroup
                    orderby newGroup.Key
                    select newGroup;

            //Console.WriteLine("");

            //foreach (var nameGroup in groupByCategory)
            //{
            //    Console.WriteLine(nameGroup.Key);

            //    foreach (var item in nameGroup)
            //    {
            //        Console.WriteLine(item);
            //    }
            //}

            return groupByCategory;
        }

        public IEnumerable<string> ShowAllItemCategories()
        {
            if(_itemList == null || _itemList.Count == 0)
                return Enumerable.Empty<string>();

            var categories = _itemList.Select(item => item.Category).Distinct();            

            return categories;
                             
        }
        public IEnumerable<Item>? FindAllFoodItems()
        {
            return _itemList != null  ?  _itemList!.FindAll(item=>item.Category == "Food") : null;
        }

        public IEnumerable<Item> ItemsWithIdBiggerThan5()
        {
            if (_itemList == null || _itemList.Count == 0)
                return Enumerable.Empty<Item>();

            return _itemList!.Where(item => item.ItemID > 5).Reverse().ToList();
        }

        public Dictionary<int,Item>? ConvertToDictionary()
        {
            return _itemList != null ? _itemList.ToDictionary(item => item.ItemID) : null;
        }

        public IEnumerable<double> FiletrOnlyDoubles()
        {
            object[] numbers = { null, 1.0, "two", 3, 4.0f, 5, "six", 7.0 };
            IEnumerable<double> doubles = numbers.OfType<double>();
            return doubles;
        }
        public Item? FindItemByName(string name)
        {
            return _itemList.FirstOrDefault(item => item.ItemName == name);
        }

        public Item? Find3rdMostExpensive()
        {
            var found = _itemList.OrderByDescending(item => item.UnitPrice).ElementAt(2);
            return found;
            //IEnumerable<Item> items = _itemList.OrderByDescending(item => item.UnitPrice).Skip(2).Take(1);
            //return items.FirstOrDefault();
        }

        public Item? Find16thElement()
        {
            if(_itemList == null)
                return null;
            return _itemList.ElementAtOrDefault(15);
        }

        public double[] CreateASequencePoweredBy2()
        {
            var sequence = Enumerable.Repeat(60, 12).Select(item => Math.Pow(item, 2.0)).ToArray();
            return sequence;
        }

        public bool FindIfHasPriceBiggerThan400()
        {
            if(_itemList == null)
                return false;
            bool bres = _itemList.Any(item => item.UnitPrice > 400);
            return bres;
        }

        public void PrintItemsByCategory()
        {
            var groupByCategory =
                    from item in _itemList
                    group item by item.Category into newGroup
                    orderby newGroup.Key
                    select newGroup;

            Console.WriteLine("");

            foreach (var nameGroup in groupByCategory)
            {
                Console.WriteLine(nameGroup.Key);

                foreach (var item in nameGroup)
                {
                    Console.WriteLine(item);
                }
            }
        }

        public int CounteItemsByCategory(string category)
        {
            if (_itemList == null)
            {
                return 0;
            }
            //return _itemList.FindAll(item => item.Category == category).Count();
            return _itemList.Count(item => item.Category == "Food");
        }

        public decimal CalcPriceOfAllItems()
        {
            if (_itemList == null)
            {
                return 0;
            }
            return _itemList!.Sum(item=>item.UnitPrice*item.UnitsInStock);
        }

        public decimal FindCheapestPrice()
        {
            if (_itemList == null)
            {
                return -1;
            }

            return _itemList!.Min(item=>item.UnitPrice);

            //Or 
            //var cheapestProduct = _itemList.OrderBy(p => p.UnitPrice).First();
        }

        public IEnumerable<Item>? FindCheapestThan50NIS()
        {
            if (_itemList == null)
            {
                return null;
            }

            //return _itemList!.Where(item => item.UnitPrice < 50.0M);

            return _itemList!.FindAll(item => item.UnitPrice < 50.0M);
        }
    }
}
