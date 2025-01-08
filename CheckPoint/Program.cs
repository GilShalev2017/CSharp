
using System;

public class CoinChange
{
    public static int CoinChangeCount(int[] coins, int sum)
    {
        int[] dp = new int[sum + 1];
        Array.Fill(dp, int.MaxValue - 1);

        dp[0] = 0;

        for (int i = 1; i <= sum; i++)
        {
            foreach (int coin in coins)
            {
                if (coin <= i)
                {
                    dp[i] = Math.Min(dp[i], dp[i - coin] + 1);
                }
            }
        }

        return dp[sum] == int.MaxValue - 1 ? -1 : dp[sum];
    }
    static int MaxFamilies(int rows)
    {
        int maxFamilies = 0;

        // Calculate the maximum number of families for full rows
        maxFamilies += rows * 2;

        // Calculate the maximum number of families for partial rows
        if (rows % 2 == 1)
        {
            maxFamilies += rows / 2;
        }
        else
        {
            maxFamilies += (rows / 2) - 1;
        }

        return maxFamilies;
    }
    static int FindMissingNonNegativeInteger(int[] array)
    {
        HashSet<int> set = new HashSet<int>(array);

        // Check for non-negative integers starting from 0
        for (int i = 0; i <= array.Length; i++)
        {
            if (!set.Contains(i))
            {
                return i;
            }
        }

        // If no missing non-negative integer found, return the next integer
        return array.Length + 1;
    }

    public class Node
    {
        public int data;
        public Node next;

        public Node(int value)
        {
            data = value;
            next = null;
        }
    }

    public class LinkedList
    {
        public Node head;

        public LinkedList()
        {
            head = null;
        }

        // Method to add a node at the end of the list
        public void AddNode(int value)
        {
            Node newNode = new Node(value);

            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node current = head;
                while (current.next != null)
                {
                    current = current.next;
                }
                current.next = newNode;
            }
        }

        // Method to remove a node from the specified position
        public void RemoveNodeAtPosition(int position)
        {
            if (head == null)
            {
                Console.WriteLine("List is empty. No node to remove.");
                return;
            }

            if (position == 0)
            {
                head = head.next;
                return;
            }

            Node current = head;
            Node previous = null;
            int currentPosition = 0;

            while (current != null && currentPosition != position)
            {
                previous = current;
                current = current.next;
                currentPosition++;
            }

            if (current == null)
            {
                Console.WriteLine("Invalid position. No node to remove.");
                return;
            }

            previous.next = current.next;
        }

        // Method to print the linked list
        public void PrintList()
        {
            Node current = head;
            while (current != null)
            {
                Console.Write(current.data + " ");
                current = current.next;
            }
            Console.WriteLine();
        }

        public static bool IsCircular(ListNode head)
        {
            if (head == null || head.Next == null)
            {
                return false; // An empty list or a single node cannot be circular
            }

            ListNode slow = head;
            ListNode fast = head.Next;

            while (fast != null && fast.Next != null)
            {
                if (slow == fast)
                {
                    return true; // The fast pointer caught up to the slow pointer, indicating a cycle
                }

                slow = slow.Next;
                fast = fast.Next.Next;
            }

            return false; // No cycle was found
        }
    }

    public class CSVRow
    {
        public string[] Columns { get; set; }
    }

    public static List<CSVRow> ParseCSV(string csvString)
    {
        List<CSVRow> rows = new List<CSVRow>();

        string[] lines = csvString.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
        if (lines.Length < 2)
        {
            throw new ArgumentException("Invalid CSV string. Expected at least two lines.");
        }

        string[] header = lines[0].Split(',');

        for (int i = 1; i < lines.Length; i++)
        {
            string[] values = lines[i].Split(',');
            if (values.Length != header.Length)
            {
                throw new ArgumentException("Invalid CSV string. Column count mismatch.");
            }

            CSVRow row = new CSVRow();
            row.Columns = values;
            rows.Add(row);
        }

        return rows;
    }

    public static int FindMaxValue(List<CSVRow> rows, int columnIndex)
    {
        if (columnIndex < 0 || columnIndex >= rows[0].Columns.Length)
        {
            throw new IndexOutOfRangeException("Invalid column index.");
        }

        int maxValue = int.MinValue;
        foreach (var row in rows)
        {
            int value;
            if (int.TryParse(row.Columns[columnIndex], out value))
            {
                if (value > maxValue)
                {
                    maxValue = value;
                }
            }
        }

        return maxValue;
    }
    public class ListNode
    {
        public int Value { get; set; }
        public ListNode? Next { get; set; }
        public ListNode(int value)
        {
            this.Value = value;
        }
    }

    public static bool IsCircular(ListNode head)
    {
        if (head == null || head.Next == null)
        {
            return false; // An empty list or a single node cannot be circular
        }

        ListNode slow = head;
        ListNode fast = head.Next;

        while (fast != null && fast.Next != null)
        {
            if (slow == fast)
            {
                return true; // The fast pointer caught up to the slow pointer, indicating a cycle
            }

            slow = slow.Next;
            fast = fast.Next.Next;
        }

        return false; // No cycle was found
    }

    public static int[] TwoSum(int[] nums, int target)
    {
        Dictionary<int, int> complements = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];

            if (complements.ContainsKey(complement))
            {
                return new int[] { complements[complement], i };
            }

            if (!complements.ContainsKey(nums[i]))
            {
                complements.Add(nums[i], i);
            }
        }

        return new int[0]; // No two numbers add up to the target
    }

    public static bool IsValidParentheses(string s)
    {
        Stack<char> stack = new Stack<char>();

        foreach (char c in s)
        {
            if (c == '(' || c == '{' || c == '[')
            {
                stack.Push(c);
            }
            else if (c == ')' || c == '}' || c == ']')
            {
                if (stack.Count == 0)
                {
                    return false; // Unmatched closing parenthesis
                }

                char top = stack.Pop();

                if ((c == ')' && top != '(') || (c == '}' && top != '{') || (c == ']' && top != '['))
                {
                    return false; // Mismatched opening and closing parenthesis
                }
            }
        }

        return stack.Count == 0; // All parentheses are matched
    }


    public static decimal CalculateRefundAmount(List<DateTime> dates, List<decimal> expenses)
    {
        decimal totalExpenses = 0;
        int withdrawalCount = 0;
        decimal withdrawalTotal = 0;

        for (int i = 0; i < dates.Count; i++)
        {
            if (expenses[i] < 0) // Withdrawal
            {
                withdrawalCount++;
                withdrawalTotal += Math.Abs(expenses[i]);
            }

            totalExpenses += expenses[i];
        }

        decimal refundAmount = totalExpenses;

        if (withdrawalCount > 3 && withdrawalTotal >= 100)
        {
            refundAmount -= 0; // No additional fee
        }
        else
        {
            refundAmount -= 5 * withdrawalCount;
        }

        return refundAmount;
    }

    public static int FindSecondHighestNumber(int[] nums)
    {
        if (nums.Length < 2)
        {
            throw new ArgumentException("Array should have at least two elements.");
        }

        Array.Sort(nums);
        return nums[nums.Length - 2];
    }

    public static decimal CalculateBankBalance(List<DateTime> dates, List<decimal> transactions)
    {
        Dictionary<int, int> negativeTransactionsPerMonth = new Dictionary<int, int>();
        decimal balance = 0;

        for (int i = 0; i < dates.Count; i++)
        {
            DateTime date = dates[i];
            decimal transaction = transactions[i];

            // Check if the month has changed
            int month = date.Month;
            if (!negativeTransactionsPerMonth.ContainsKey(month))
            {
                negativeTransactionsPerMonth[month] = 0;
            }

            if (transaction < 0)
            {
                negativeTransactionsPerMonth[month]++;
            }

            balance += transaction;
        }

        decimal fee = 5;
        decimal discount = 0;

        foreach (int count in negativeTransactionsPerMonth.Values)
        {
            if (count >= 3)
            {
                discount += fee;
            }
        }

        balance -= discount;

        return balance;
    }
    public static int Atoi(string str)
    {
        if (string.IsNullOrWhiteSpace(str))
        {
            return 0;
        }

        int index = 0;
        int sign = 1;
        int result = 0;

        // Skip leading whitespace
        while (index < str.Length && str[index] == ' ')
        {
            index++;
        }

        // Handle sign
        if (index < str.Length && (str[index] == '+' || str[index] == '-'))
        {
            sign = str[index] == '-' ? -1 : 1;
            index++;
        }

        // Convert digits to integer
        while (index < str.Length && char.IsDigit(str[index]))
        {
            int digit = str[index] - '0';

            // Check for overflow
            if (result > int.MaxValue / 10 || (result == int.MaxValue / 10 && digit > int.MaxValue % 10))
            {
                return sign == 1 ? int.MaxValue : int.MinValue;
            }

            result = result * 10 + digit;
            index++;
        }

        return result * sign;
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int value)
        {
            val = value;
            left = null;
            right = null;
        }
    }
    public static TreeNode FindSuccessor(TreeNode root, TreeNode node)
    {
        if (root == null || node == null)
        {
            return null;
        }

        TreeNode successor = null;
        TreeNode current = root;

        while (current != null)
        {
            if (current.val > node.val)
            {
                successor = current;
                current = current.left;
            }
            else
            {
                current = current.right;
            }
        }

        return successor;
    }

    public class Singleton
    {
        private static Singleton instance;
        private static readonly object lockObject = new object();

        private Singleton()
        {
            // Private constructor to prevent instantiation from outside the class
        }

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new Singleton();
                        }
                    }
                }
                return instance;
            }
        }

        // Other methods and properties of the Singleton class
    }

    public static bool IsGoodPassword(string password)
    {
        // Minimum password length
        int minLength = 8;

        // Check if the password meets the minimum length requirement
        if (password.Length < minLength)
        {
            return false;
        }

        // Check if the password contains at least one uppercase letter
        if (!password.Any(char.IsUpper))
        {
            return false;
        }

        // Check if the password contains at least one lowercase letter
        if (!password.Any(char.IsLower))
        {
            return false;
        }

        // Check if the password contains at least one digit
        if (!password.Any(char.IsDigit))
        {
            return false;
        }

        // Check if the password contains at least one special character
        if (!password.Any(c => !char.IsLetterOrDigit(c)))
        {
            return false;
        }

        // All checks passed, the password is good
        return true;
    }

    public static List<int> FindPrimeFactors(int number)
    {
        List<int> primeFactors = new List<int>();

        // Find all occurrences of 2 as a factor
        while (number % 2 == 0)
        {
            primeFactors.Add(2);
            number /= 2;
        }

        // Find other prime factors starting from 3
        int factor = 3;
        while (factor * factor <= number)
        {
            if (number % factor == 0)
            {
                primeFactors.Add(factor);
                number /= factor;
            }
            else
            {
                factor += 2; // Increment by 2 to consider only odd factors
            }
        }

        // If the remaining number is greater than 2, it is also a prime factor
        if (number > 2)
        {
            primeFactors.Add(number);
        }

        return primeFactors;
    }

    public class SetAllArray<T>
    {
        private T[] array;
        private bool[] isSet;
        private T setValue;

        public SetAllArray(int length)
        {
            array = new T[length];
            isSet = new bool[length];
        }

        public void SetAll(T value)
        {
            setValue = value;
            Array.Fill(isSet, true);
        }

        public void Set(int index, T value)
        {
            array[index] = value;
            isSet[index] = true;
        }

        public T Get(int index)
        {
            if (isSet[index])
            {
                return array[index];
            }
            else
            {
                return setValue;
            }
        }
    }

    //public class TreeNodeX
    //{
    //    public int Value { get; set; }
    //    public TreeNodeX Left { get; set; }
    //    public TreeNodeX Right { get; set; }

    //    public TreeNodeX(int value)
    //    {
    //        Value = value;
    //        Left = null;
    //        Right = null;
    //    }
    //}

    //public class BinaryTree
    //{
    //    public TreeNodeX Root { get; set; }

    //    public BinaryTree()
    //    {
    //        Root = null;
    //    }

    //    public void PrintZigzag()
    //    {
    //        if (Root == null)
    //        {
    //            Console.WriteLine("Binary tree is empty.");
    //            return;
    //        }

    //        Queue<TreeNode> levelQueue = new Queue<TreeNode>();
    //        Stack<TreeNode> levelStack = new Stack<TreeNode>();
    //        bool leftToRight = true;

    //        levelQueue.Enqueue(Root);

    //        while (levelQueue.Count > 0)
    //        {
    //            int levelSize = levelQueue.Count;

    //            for (int i = 0; i < levelSize; i++)
    //            {
    //                TreeNode currentNode = levelQueue.Dequeue();

    //                if (leftToRight)
    //                {
    //                    Console.Write(currentNode.Value + " ");
    //                }
    //                else
    //                {
    //                    levelStack.Push(currentNode);
    //                }

    //                if (currentNode.Left != null)
    //                {
    //                    levelQueue.Enqueue(currentNode.Left);
    //                }

    //                if (currentNode.Right != null)
    //                {
    //                    levelQueue.Enqueue(currentNode.Right);
    //                }
    //            }

    //            if (!leftToRight)
    //            {
    //                while (levelStack.Count > 0)
    //                {
    //                    TreeNode currentNode = levelStack.Pop();
    //                    Console.Write(currentNode.Value + " ");
    //                }
    //            }

    //            leftToRight = !leftToRight;
    //            Console.WriteLine();
    //        }
    //    }
    //}

    public static int PlaceDigit5(int number)
    {
        string numberString = number.ToString();
        bool isNegative = number < 0;
        int insertIndex = 0;

        // Find the index to insert the digit 5
        if (isNegative)
        {
            insertIndex = 1; // Skip the negative sign
            while (insertIndex < numberString.Length && numberString[insertIndex] - '0' <= 5)
            {
                insertIndex++;
            }
        }
        else
        {
            while (insertIndex < numberString.Length && numberString[insertIndex] - '0' >= 5)
            {
                insertIndex++;
            }
        }

        // Insert the digit 5 at the appropriate index
        string result = numberString.Insert(insertIndex, "5");

        // Parse the resulting string back to an integer
        int maxNumber = int.Parse(result);

        return maxNumber;
    }

    public static void FreeFunction(params int[] numbers)
    {
        Console.WriteLine("Number of arguments: " + numbers.Length);
        Console.WriteLine("Arguments:");

        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
    public static void Main(string[] args)
    {
        int[] coins = { 1, 2, 5 };
        int sum = 11;

        int result = CoinChangeCount(coins, sum);

        Console.WriteLine("Fewest coins required: " + result);

        //Console.Write("Enter the number of rows: ");
        //int rows = int.Parse(Console.ReadLine());

        //int maxFamilies = MaxFamilies(rows);
        //Console.WriteLine("Maximum number of families: " + maxFamilies);

        int[] array = { 1, 3, 0, 5, 2 };
        int missingInteger = FindMissingNonNegativeInteger(array);
        Console.WriteLine("Missing non-negative integer: " + missingInteger);

        LinkedList list = new LinkedList();

        // Add nodes to the list

        list.AddNode(10);
        list.AddNode(20);
        list.AddNode(30);
        list.AddNode(40);
        list.AddNode(50);

        Console.WriteLine("Original List:");
        list.PrintList();

        // Remove node at position 2
        int positionToRemove = 2;
        list.RemoveNodeAtPosition(positionToRemove);

        Console.WriteLine("List after removing node at position " + positionToRemove + ":");
        list.PrintList();

        string csvString = "Name,Age,Score\nJohn,25,80\nJane,30,90\nMark,28,85";

        List<CSVRow> rows = ParseCSV(csvString);

        int columnIndex = 2; // Column index of "Score"

        int maxValue = FindMaxValue(rows, columnIndex);

        Console.WriteLine("Maximum value in column {0}: {1}", columnIndex, maxValue);


        // Create a loop

        ListNode head = new ListNode(60);
        ListNode newNode2 = new ListNode(70);
        ListNode newNode3 = new ListNode(80);
        ListNode newNode4 = new ListNode(90);
        ListNode newNode5 = new ListNode(100);
        head.Next = newNode2;
        newNode2.Next = newNode3;
        newNode3.Next = newNode4;
        newNode4.Next = newNode5;
        Console.WriteLine(IsCircular(head));
        newNode5.Next = head;
        Console.WriteLine(IsCircular(head));

        int[] nums = { 2, 7, 11, 15 };
        int target = 9;

        int[] indices = TwoSum(nums, target);

        Console.WriteLine("Indices of the two numbers: " + indices[0] + ", " + indices[1]);

        string str1 = "()";
        bool isValid1 = IsValidParentheses(str1);
        Console.WriteLine("Is '{0}' valid parentheses? {1}", str1, isValid1);

        string str2 = "()[]{}";
        bool isValid2 = IsValidParentheses(str2);
        Console.WriteLine("Is '{0}' valid parentheses? {1}", str2, isValid2);

        string str3 = "(]";
        bool isValid3 = IsValidParentheses(str3);
        Console.WriteLine("Is '{0}' valid parentheses? {1}", str3, isValid3);

        string str4 = "([)]";
        bool isValid4 = IsValidParentheses(str4);
        Console.WriteLine("Is '{0}' valid parentheses? {1}", str4, isValid4);

        string str5 = "{[]}";
        bool isValid5 = IsValidParentheses(str5);
        Console.WriteLine("Is '{0}' valid parentheses? {1}", str5, isValid5);

        List<DateTime> dates = new List<DateTime>
        {
            new DateTime(2023, 1, 1),
            new DateTime(2023, 2, 1),
            new DateTime(2023, 3, 1),
            new DateTime(2023, 4, 1),
            new DateTime(2023, 5, 1),
            new DateTime(2023, 6, 1)
        };

        List<decimal> expenses = new List<decimal>
        {
            100,   // Income
            -50,   // Withdrawal
            -30,   // Withdrawal
            70,    // Income
            -20,   // Withdrawal
            -10    // Withdrawal
        };

        decimal refundAmount = CalculateRefundAmount(dates, expenses);

        Console.WriteLine("Refund amount: {0}", refundAmount);

        int[] numsArr = { 9, 5, 7, 2, 1, 8, 6, 3, 4 };
        int secondHighest = FindSecondHighestNumber(numsArr);

        dates = new List<DateTime>
        {
            new DateTime(2023, 1, 1),
            new DateTime(2023, 1, 2),
            new DateTime(2023, 1, 3),
            new DateTime(2023, 2, 1),
            new DateTime(2023, 2, 2),
            new DateTime(2023, 2, 3)
        };

        List<decimal> transactions = new List<decimal>
        {
            100,   // Income
            -50,   // Withdrawal
            -30,   // Withdrawal
            70,    // Income
            -20,   // Withdrawal
            -10    // Withdrawal
        };

        decimal bankBalance = CalculateBankBalance(dates, transactions);

        Console.WriteLine("Bank balance: {0}", bankBalance);

        string str11 = "42";
        int num11 = Atoi(str11);
        Console.WriteLine("Result 1: " + num11);

        string str22 = "   -42";
        int num22 = Atoi(str22);
        Console.WriteLine("Result 2: " + num22);

        string str33 = "4193 with words";
        int num33 = Atoi(str33);
        Console.WriteLine("Result 3: " + num33);

        string str44 = "words and 987";
        int num44 = Atoi(str44);
        Console.WriteLine("Result 4: " + num44);

        string str55 = "-91283472332";
        int num55 = Atoi(str55);
        Console.WriteLine("Result 5: " + num55);

        TreeNode root = new TreeNode(4);
        root.left = new TreeNode(2);
        root.right = new TreeNode(6);
        root.left.left = new TreeNode(1);
        root.left.right = new TreeNode(3);
        root.right.left = new TreeNode(5);
        root.right.right = new TreeNode(7);

        TreeNode node = root.left.right; // Node to find successor

        TreeNode successor = FindSuccessor(root, node);

        if (successor != null)
        {
            Console.WriteLine("Successor: " + successor.val);
        }
        else
        {
            Console.WriteLine("No successor found");
        }

        int number = 84;
        List<int> primeFactors = FindPrimeFactors(number);

        Console.WriteLine("Prime factors of " + number + ":");
        foreach (int factor in primeFactors)
        {
            Console.Write(factor + " ");
        }

        //BinaryTree binaryTree = new BinaryTree();
        //binaryTree.Root = new TreeNode(1);
        //binaryTree.Root.Left = new TreeNode(2);
        //binaryTree.Root.Right = new TreeNode(3);
        //binaryTree.Root.Left.Left = new TreeNode(4);
        //binaryTree.Root.Left.Right = new TreeNode(5);
        //binaryTree.Root.Right.Left = new TreeNode(6);
        //binaryTree.Root.Right.Right = new TreeNode(7);

        //Console.WriteLine("Binary Tree in Zigzag order:");
        //binaryTree.PrintZigzag();

        int numberXXX = 630;
        int maxNumber = PlaceDigit5(numberXXX);

        Console.WriteLine("Original number: " + numberXXX);
        Console.WriteLine("Maximum number: " + maxNumber);

        numberXXX = 963;
        maxNumber = PlaceDigit5(numberXXX);

        Console.WriteLine("Original number: " + numberXXX);
        Console.WriteLine("Maximum number: " + maxNumber);

        FreeFunction(1, 2, 3);
        FreeFunction(4, 5, 6, 7, 8);
        FreeFunction(9);
    }
}
