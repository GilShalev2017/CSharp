// See https://aka.ms/new-console-template for more information
using Sandbox.LINQ;
using System;
using System.Runtime.InteropServices;

class Solution
{
    static Node? Head;

    class Singelton
    {
        private static Singelton? _instance;
        private static readonly object _syncObject = new();

        private Singelton() {}

        public static Singelton SingeltonInstacne
        {
            get
            {
                lock (_syncObject)
                {
                    if (_instance == null)
                    {
                        lock (_syncObject)
                        {
                            _instance = new Singelton();
                        }
                    }
                }
                return _instance;
            }
        }       

        public void SayHello()
        {
            Console.WriteLine("Say Hello");
        }
    }

    public static int[] BubbleSort(int[] arr)
    {
        bool needSwap = true;

        for (int i = 0; i < arr.Length && needSwap; i++)
        {
            needSwap = false;

            for (int j = 0; j < arr.Length -1 -i; j++)
            {
                if(arr[j] > arr[j+1])
                {
                    needSwap = true;
                    int ez = arr[j];
                    arr[j]= arr[j+1]; 
                    arr[j+1]= ez;
                }
            }
        }

        return arr;
    }

    public class Node
    {
        public int Data { get; set; }
        public Node? Next { get; set; }
        public Node(int data)
        {
            Data = data;
        }
    }

    public class TreeNode
    {
        public int Data { get; set; }
        public TreeNode? Left { get; set; }
        public TreeNode? Right { get; set; }
        public TreeNode(int data)
        {
            Data= data;
        }
    }

    public static void PrintList(Node? node)
    {
        while (node != null)
        {
            Console.WriteLine(node.Data);
            node = node.Next;
        }
    }
    public static Node Reverse(Node node)
    {
        Node tmp = node;
        Node? ptr = node.Next;

        if (ptr == null)
        {
            Head = tmp;
            return tmp;
        }

        return Reverse(ptr).Next = tmp;
    }
    
    public static void PrintInOrder(TreeNode? node)
    {
        if(node == null)
        {
            return; 
        }
        PrintInOrder(node.Left);
        Console.WriteLine(node.Data);
        PrintInOrder(node.Right);
    }

    public static void PrintPreOrder(TreeNode? node)
    {
        if (node == null)
        {
            return;
        }
        Console.WriteLine(node.Data);
        PrintPreOrder(node.Left);
        PrintPreOrder(node.Right);
    }

    public static void PrintPostOrder(TreeNode? node)
    {
        if (node == null)
        {
            return;
        }
        PrintPostOrder(node.Left);
        PrintPostOrder(node.Right);
        Console.WriteLine(node.Data);
    }

    public static int Fibonacci(int index)
    {
        if(index == 1 || index ==2)
        {
            return 1;
        }

        return Fibonacci(index-1) + Fibonacci(index-2);
    }
    public static int FindMaxSubArray(int[] arr)
    {
       int max = 0;
       int current = 0;

       for (int i=0; i<arr.Length; i++)
       {
            if(current >  max)
            {
                max = current;
            }
           
            current += arr[i];
       
            if(current < 0)
            {
                current = 0;
            }
       }
       if(current > max)
            return current;

       return max;
    }

    public static void Main()
    {
        //1). Singelton
        var singelton = Singelton.SingeltonInstacne;
        singelton.SayHello();
        //2).Bubble Sort
        int[] arr = { 10,2,30,5,6,80,4,11,3,2};
        Console.WriteLine("Unsorted");
        for (int i = 0; i < arr.Length; i++)
        {
            Console.WriteLine(arr[i]);
        }
        var sortedArr = BubbleSort(arr);
        for (int i = 0; i < arr.Length; i++)
        {
            Console.WriteLine(arr[i]);
        }
        Console.WriteLine("Sorted");
        //3). Reverse Linked List
        Node node1 = new (1);
        Node node2 = new (2);
        Node node3 = new (3);
        node1.Next = node2;
        node2.Next = node3;
        Head = node1;
        Console.WriteLine("Original List");
        PrintList(Head);
        Reverse(Head).Next = null;
        Console.WriteLine("Reversed List");
        PrintList(Head);
        //4).Print Tree
                 //5
             //3        //10
          //1  //2   //8  //12 //Head
        TreeNode tn1 = new (5);
        TreeNode tn2 = new (3);
        TreeNode tn3 = new (10);
        TreeNode tn4 = new (1);
        TreeNode tn5 = new (4);
        TreeNode tn6 = new (8);
        TreeNode tn7 = new (12);
        tn1.Left = tn2;
        tn1.Right = tn3;
        tn2.Left = tn4;
        tn2.Right = tn5;
        tn3.Left = tn6;
        tn3.Right = tn7;
        Console.WriteLine("Print InOrder");
        PrintInOrder(tn1);
        Console.WriteLine("Print PostOrder");
        PrintPostOrder(tn1);
        Console.WriteLine("Print PreOrder");
        PrintPreOrder(tn1);
        //5).Fibonacci
        var fibNumber = Fibonacci(8);
        Console.WriteLine($"The Fib number whose index is 8 is {fibNumber}");
        //6).LINQ
        Tester tester = new Tester();
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
        var foundItems = tester.FindAllItemsWithPriceBiggerThan10();
        items = tester.FindGreaterThan10UsingWhere();
        tester.PrintAllItems(items);
        items = tester.SortByPriceAndTake2MostExpensive();
        tester.PrintAllItems(items);
        items = tester.SortByPriceAndSkipFirst2MostExpensive();
        tester.PrintAllItems(items);
        var mergedItems = tester.JoinItemsAndOrders();
        //itemNames = tester.FindEntertainmentAndFoodItems();
        tester.PrintStrings(itemNames);
        //items = tester.SortByCategoryAndPrice();
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
        items = tester.ItemsWithIdBiggerThan5();
        tester.PrintAllItems(items);
        var res = tester.ConvertToDictionary();
        var doubles = tester.FiletrOnlyDoubles();
        var found = tester.FindItemByName("War of the worlds DVD");
        found = tester.Find3rdMostExpensive();
        found = tester.Find16thElement();
        var sequence = tester.CreateASequencePoweredBy2();
        var exist = tester.FindIfHasPriceBiggerThan400();
        tester.PrintItemsByCategory();
        var count = tester.CounteItemsByCategory("Food");
        var sum = tester.CalcPriceOfAllItems(); //calculate the merchendize value
        var cheepest = tester.FindCheapestPrice();
        items = tester.FindCheapestThan50NIS();
        tester.PrintAllItems(items);
        //7).Data Strcture Quizes
        int[] array = { 1, 3, -5, 20, -40, 100, 5, 8, 10, -2, 12 };
        Console.WriteLine("max sum is = " + FindMaxSubArray(array));

    }
}