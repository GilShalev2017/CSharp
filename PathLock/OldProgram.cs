//// See https://aka.ms/new-console-template for more information
////using System.Xml.Linq;

//Console.WriteLine("Hello, World!");
///*
//interface IOperation
//{
//    int Calculate(int num1, int num2);
//}

//class AddOp : IOperation
//{
//    int Calculate(int num1, int num2)
//    {
//        ...

//    }
//}

//class SubtractOp : IOperation
//{
//    int Calculate(int num1, int num2)
//    {
//        ...

//    }
//}

//class MultiplyOp : IOperation
//{
//    int Calculate(int num1, int num2)
//    {
//        ...

//    }
//}

//class DivideOp : IOperation
//{
//    int Calculate(int num1, int num2)
//    {
//        ...

//    }
//}

//class Factory
//{
//    Dictionary<string, IOperation> operations;

//    void Factory()
//    {
//        Init();
//    }
//    Init()
//    {
//        //Read from configuration and create proper feature / operation type
//        //According to the client's license
//        //and add to the operations array
//    }

//    public IOpertaion GetOpProvider(string op)
//    {
//        //validation check. throws exception if not found
//        return operations[opName];
//    }
//}

//User()
//{
//    var factory = new Factory();
//    IOperation opProvider = factory.GetOpProvider("add");
//    int result = opProvider.Calcaulate(3, 5);
//}

//*/

///*
//static int CountWays(int[] coins, int amount)
//{
//    int[] dp = new int[amount + 1];
//    dp[0] = 1;

//    foreach (int coin in coins)
//    {
//        for (int i = coin; i <= amount; i++)
//        {
//            dp[i] += dp[i - coin];
//        }
//    }

//    return dp[amount];
//}
//*/
///*
//static void Main()
//{
//    int[] coins = { 1, 2, 5 };
//    int amount = 3;

//    int result = CountWays(coins, amount);
//    Console.WriteLine(result); // Output: 2
//}
//*/