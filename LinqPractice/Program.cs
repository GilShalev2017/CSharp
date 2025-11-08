// See https://aka.ms/new-console-template for more information
using LinqPractice;

Console.WriteLine("Hello, World!");

var tester = new Tester();

var items = tester.PriceGreaterThan10();
tester.PrintAllItems(items);

var orders = tester.OrdersOfJohn();
tester.PrintAllOrders(orders);

var itemNames = tester.FindAllItemNames();
tester.PrintStrings(itemNames);

var orderNames = tester.FindAllOrderNames();
tester.PrintStrings(orderNames);

orders = tester.FindAllOrders();
tester.PrintAllOrders(orders);

var foundItemsDynamic = tester.FindAllItemsWithPriceBiggerThan10_Dynamic();

IEnumerable<(string Name, decimal Price)> foundItemsTuples = tester.FindAllItemsWithPriceBiggerThan10_Tuple();



items = tester.FindGreaterThan10UsingWhere();
tester.PrintAllItems(items);

items = tester.SortByPriceAndTake2MostExpensive();
tester.PrintAllItems(items);

items = tester.SortByPriceAndSkipFirst2MostExpensive();
tester.PrintAllItems(items);

var mergedItems = tester.JoinItemsAndOrders();

itemNames = tester.FindEntertainmentAndFoodItems();
tester.PrintStrings(itemNames);

items = tester.SortByCategoryAndPrice();
tester.PrintAllItems(items);

var groupedItems = tester.GroupByCategory();

foreach (var nameGroup in groupedItems)
{
    Console.WriteLine(nameGroup.Key);

    foreach (var item in nameGroup)
    {
        Console.WriteLine(item);
    }
}

var categories = tester.ShowAllItemCategories();
tester.PrintStrings(categories);

items = tester.FindAllFoodItems();
tester.PrintAllItems(items);

items = tester.ItemWithIdBiggerThan5();
tester.PrintAllItems(items);

var res = tester.ConvertToDictionary();

var doubles = tester.FiletrOnlyDoubles();

var found = tester.FindItemByName();

found = tester.FindItemThatDoesNotExist();

found = tester.Find3rdMostExpensive();

found = tester.Find16thElement();

var sequence = tester.CreateASequencePoweredBy2();

var exist = tester.FindIfHasPriceBiggerThan400();

tester.PrintItemsByCategory();

var count = tester.CounteItemsByCategory();

var sum = tester.CalcPriceOfAllItems();

var cheepest = tester.FindCheapestPrice();

items = tester.FindCheapestThan50NIS();
tester.PrintAllItems(items);

Console.ReadLine();