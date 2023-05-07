using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LinqPractice
{
    internal class Tester
    {
        private List<Item> _itemList;
        private List<Order> _orderList;
        private int _itemToExamineItems = 1;
        private int _itemToExamineOrders = 1;

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
        public void PrintAllItems(IEnumerable<Item> items)
        {
            Console.WriteLine("");
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }

        public void PrintAllOrders(IEnumerable<Order> orders)
        {
            if (orders == null)
                throw new Exception("list can not be null");

            Console.WriteLine("");
            foreach (var order in orders)
            {
                Console.WriteLine(order);
            }
        }
        public void PrintStrings(IEnumerable<string> items)
        {
            Console.WriteLine("");
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }

        //Find all the items that their price is greater than 10
        //Comment: can be done in several ways:
        //FindAll !!!
        //Select + where statement !!!
        //Use Where !
        public IEnumerable<Item>? PriceGreaterThan10()
        {
            var res = _itemList.FindAll(item => item.UnitPrice > 10.00M);

            return res;
        }

        //Find all the orders that "John Smith" performed
        public IEnumerable<Order>? OrdersOfJohn()
        {
            var res = _orderList.FindAll(order => order.OrderName.ToLower().Contains("john smith"));

            return res;
        }

        //Find all the item names
        //Comment: here we need select because we return only one property
        public IEnumerable<string> FindAllItemNames()
        {
            var res = from item in _itemList
                      select item.ItemName;

            return res;
        }

        //Find all the order names
        public IEnumerable<string> FindAllOrderNames()
        {
            var res = from order in _orderList
                      select order.OrderName;

            return res;
        }

        //Find all the orders
        public IEnumerable<Order> FindAllOrders()
        {
            var res = from order in _orderList
                      select order;

            return res;
        }

        //Find all the items that their price is equall or greater than 10 and display their names and price, convert them to list
        //Comment pay attention that we return an anonymous type, we use dynamic! and also we need to use new in order to decalre
        //that we create new objects!
        public dynamic FindAllItemsWithPriceBiggerThan10()
        {
            dynamic res = _itemList.Where(item => item.UnitPrice >= 10)
                      .Select(item => new { item.ItemName, item.UnitPrice }).ToList();

            foreach (var element in res)
                Console.WriteLine(element.ItemName + "-" + element.UnitPrice);

            return res;
        }

        //Find all the items that their price is greater/equal to 10 using Where
        public IEnumerable<Item> FindGreaterThan10UsingWhere()
        {
            var res = _itemList.Where(item => item.UnitPrice >= 10);
            return res;
        }

        //Sort all the items by their price in DESC order and take the first 2 (meaning the most expensive ones)
        //Comment pay attention the proper term for sorting is Order: OrderBy, OrderByDescending, ThenBy, ThenByDescending !!!
        public IEnumerable<Item> SortByPriceAndTake2MostExpensive()
        {
            var res = _itemList.OrderByDescending(item => item.UnitPrice).Take(2);
            return res;
        }

        //Sort all the items by their price in DESC order and skip the first most expensive one
        public IEnumerable<Item> SortByPriceAndSkipFirst2MostExpensive()
        {
            var res = _itemList.OrderByDescending(item => item.UnitPrice).Skip(2);//or skipo(1)?
            return res;
        }

        //Join/merge items with orders
        //Usage of join !!!
        //but this is artifical since there's no reall reason to join ItemID with OrderId (no reasonable PK->FK relation)
        public dynamic JoinItemsAndOrders()
        {
            var res = from item in _itemList
                      join order in _orderList
                      on item.ItemID equals order.OrderID
                      select new { item.ItemName, order.OrderName };

            Console.WriteLine("");
            foreach (var element in res)
                Console.WriteLine(element.ItemName + "-" + element.OrderName);
            return res;
        }

        //Find all the items that belong to categories "Entertainment" & "Food" and show them only once!
        //Comment: in oredr not to mix the items of the 2 categories we find the 2 lists (and take only ItemName and not the entire Item fields
        //by using a Select) and then we call a Conact between them!
        //Distinct is not really needed here !!!
        public IEnumerable<string> FindEntertainmentAndFoodItems()
        {
            //var res = _itemList.Where(item => item.Category == "Entertainment" || item.Category == "Food");
            var res = _itemList.Where(item => item.Category == "Entertainment").Select(elm => elm.ItemName)
                      .Concat(_itemList.Where(item => item.Category == "Food").Select(elm => elm.ItemName))
                      .Distinct();
            return (IEnumerable<string>)res;

        }

        //Sort the items by their category (first sort) and then by their prices (secondary sort) in DESC order
        //Comment pay attention that if we want 2 sorts than we must use the second one to be ThenBy or ThenByDescending !!!
        public IEnumerable<Item> SortByCategoryAndPrice()
        {
            var res = _itemList.OrderBy(item => item.Category).ThenByDescending(item => item.UnitPrice);

            return res;
        }

        //Group all the items by their categories and display the category and its items
        //Comment pay attention to the special syntax for creating a group by!
        public IOrderedEnumerable<IGrouping<string, Item>> GroupByCategory()
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

            return groupByCategory;
        }

        //Show all the categories: make sure to disaply them distinct
        //Comment - pay attention to the use of Distinct() !!!
        public IEnumerable<string> ShowAllItemCategories()
        {
            var res = _itemList.Select(item => item.Category).Distinct();
            return res;
        }

        //retrun an arry of all the items that belong to "Food" category
        public Item[] FindAllFoodItems()
        {
            var res = _itemList.Where(item => item.Category == "Food").ToArray();
            return res;
        }

        //return all the items that their ID num is bigger than 5 in Reverse order than their original order and return them as a list
        public IList<Item> ItemWithIdBiggerThan5() {
            var res = _itemList.Where(item => item.ItemID > 5).Reverse().ToList();
            return res;
        }

        //create a dictionary of the given array where the key is the ID
        //Comment see the usage of ToDictionary - which expects a field to be served as a key!
        public Dictionary<int, Item> ConvertToDictionary()
        {
            //Dictionary<int, Item> dic = new Dictionary<int, Item>();

            //foreach (var item in _itemList)
            //{
            //    dic.Add(item.ItemID, item);
            //}

            //return dic;

            var dic = _itemList.ToDictionary(item => item.ItemID);
            return dic;
        }
        //return a sequence of all the items of type double
        //Comment see the usages of OfType() to filter the collection items accoring to their types!
        //Also notice that we can create an array that holds all kinds of types, but the element types is object!!!
        public IEnumerable<double> FiletrOnlyDoubles()
        {
            object [] numbers = { null, 1.0, "two", 3, 4.0f, 5, "six", 7.0 };

            var res = numbers.OfType<double>();

            var res2 = numbers.OfType<float>();

            return res;
        }

        //Find the first item that it's name is "War of the worlds DVD";
        //Comment pay attnetion that if we use First and no item is found an exception will be raised
        //If we use FirstOrDefault - if no item will be found a null will be returned! and no exception will be raised!
        public Item FindItemByName()
        {
            return _itemList.FirstOrDefault(item => item.ItemName == "War of the worlds DVD");
        }

        //Find the item that it's name equal to "A non existence Element" or return a default
        public Item FindItemThatDoesNotExist()
        {
            return _itemList.FirstOrDefault(item => item.ItemName == "A non existence Element");
        }

        //Find the 3rd most expensive item
        //Comment - usage of Skip() and Take()
        //or better we can use ElementAt() a certain index!
        public Item Find3rdMostExpensive()
        {
            //return _itemList.OrderByDescending(item => item.UnitPrice).Skip(2).Take(1).FirstOrDefault();

            return _itemList.OrderByDescending(item => item.UnitPrice).ElementAt(2);
        }

        //Retrun the 16th element or deault if it doesn't exist
        //Comment usage of ElementAtOrDefault() !
        public Item Find16thElement()
        {
            return _itemList.ElementAtOrDefault(15);
        }

        //Create a sequence that will conatain 12 times the number 60, then raise them by power 2 and make the sequence into an array
        //Comment usage of Enumerable.Repeat(x, y)
        public double[] CreateASequencePoweredBy2()
        {
            var sequence = Enumerable.Repeat(60, 12).Select(item=>Math.Pow(item,2.0)).ToArray();
            return sequence;
        }

        //Find out if there is an item with a price bigger than 400
        //Comment usage of Any!
        public bool FindIfHasPriceBiggerThan400()
        {
            //return _itemList.Any(item => item.UnitPrice > 400);

            return _itemList.Any(item => item.UnitPrice > 100);
        }

        //Print all the items by their category
        public void PrintItemsByCategory() {
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

        //Find how many items belong to the "Food" category
        //Comment usage of Count() !
        public int CounteItemsByCategory()
        {
            var res = _itemList.Count(item => item.Category == "Food");
            return res;
        }

        //Calc the price of all items together
        //Comment usage of Sum
        public decimal CalcPriceOfAllItems()
        {
            var res = _itemList.Sum(item => item.UnitsInStock * item.UnitPrice);
                      
            return res;
        }

        //Find the cheapest item
        //Comment Usage of Min() !
        public decimal FindCheapestPrice()
        {
            var res = _itemList.Min(item => item.UnitPrice);
            
            var cheapestProduct = _itemList.OrderBy(p => p.UnitPrice).First();

            return res;
        }

        //Find all the items that are cheapper than 50 NIS
        public IEnumerable<Item> FindCheapestThan50NIS()
        {
            var res = _itemList.Where(item => item.UnitPrice < 50);

            return res;
        }

    }
}
