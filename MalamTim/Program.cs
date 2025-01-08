internal class Program
{

    //public static void FillStackB(Stack<int> stackA, Stack<int> stackB)
    //{
    //    int size = stackA.Count;

    //    while (size > 0)
    //    {
    //        int element = stackA.Pop();
    //        size--;

    //        // Move elements from stackB to stackA
    //        while (stackB.Count > size)
    //        {
    //            stackA.Push(stackB.Pop());
    //        }

    //        // Push the current element to stackB
    //        stackB.Push(element);
    //    }
    //}

    /*
    public static void FillStackB(Stack<int> stackA, Stack<int> stackB)
    {
        int ez;

        for(int i = 0; i < stackA.Count-1; i++)
        {

            while (stackA.Count > 0)
            {
                stackB.Push(stackA.Pop());
            }

            ez = stackB.Pop();

            while (stackB.Count > 0)
            {
                stackA.Push(stackB.Pop());
            }

            stackA.Push(ez);
        }

        while (stackA.Count > 0)
        {
            stackB.Push(stackA.Pop());
        }

      
    }*/


    /*
    public static void FillStackB(Stack<int> stackA, Stack<int> stackB)
    {
        Stack<int> tempStack = new Stack<int>();

        while (stackA.Count > 0)
        {
            tempStack.Push(stackA.Pop());
        }

        while (tempStack.Count > 0)
        {
            int element = tempStack.Pop();
            stackB.Push(element);
        }
    }
    */
    /*
    static void Main(string[] args)
    {
        Stack<int> stackA = new Stack<int>();
        stackA.Push(1);
        stackA.Push(2);
        stackA.Push(3);
        stackA.Push(4);
        stackA.Push(5);

        Stack<int> stackB = new Stack<int>();

        FillStackB(stackA, stackB);

        Console.WriteLine("StackA: " + string.Join(", ", stackA));
        Console.WriteLine("StackB: " + string.Join(", ", stackB));
        /*
        Console.WriteLine("Here");
        Stack<int> stackA = new Stack<int>();
        stackA.Push(1);
        stackA.Push(2);
        stackA.Push(3);
        stackA.Push(4);
        stackA.Push(5);

        Stack<int> stackB = new Stack<int>();

        Console.WriteLine("StackA: " + string.Join(", ", stackA));

        FillStackB(stackA, stackB);

      //  Console.WriteLine("StackA: " + string.Join(", ", stackA));
        Console.WriteLine("StackB: " + string.Join(", ", stackB));
        
    }

*/
    public static void FillStackB(Stack<int> stackA, Stack<int> stackB)
    {
        int count = stackA.Count;

        for (int i = 0; i < count; i++)
        {
            int element = stackA.Pop();
            stackB.Push(element);
        }

        for (int i = 0; i < count; i++)
        {
            int element = stackB.Pop();
            stackA.Push(element);
        }
    }

    public static void Main()
    {
        Stack<int> stackA = new Stack<int>();
        stackA.Push(1);
        stackA.Push(2);
        stackA.Push(3);
        stackA.Push(4);
        stackA.Push(5);

        Stack<int> stackB = new Stack<int>();

        FillStackB(stackA, stackB);

        Console.WriteLine("StackA: " + string.Join(", ", stackA));
        Console.WriteLine("StackB: " + string.Join(", ", stackB));
    }

}