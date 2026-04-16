// See https://aka.ms/new-console-template for more information
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Net;
using System.Net.WebSockets;
using System.Reflection;
using System.Xml.Linq;

//COMMENTS:
//foreah vs ForEach
//array initialization
//Int64 / long vs simple int
//caclualtions of floats - casting or the value themselves should be floats!
//String.Format("{0:0.000000}" of decimal digits

//PAY ATTENTION TO HINTS !!!

internal class Program
{
    private static void Main(string[] args)
    {
        int[] nums = { -4, 3, -9, 0, 4, 1 };
        List<int> arr = nums.ToList();

        PlusMinus(arr);

        int[] nums2 = { 1, 2, 3, 4, 5 };
        List<int> arr2 = nums2.ToList();

        MiniMaxSum(arr2);

        var res = TimeConversion("12:40:22AM");
        var res2 = TimeConversion("06:40:03AM");
        Console.WriteLine(res);
        Console.WriteLine(res2);

        //int[][] jaggedArray = new int[][]
        //{
        //new int[] { 3 },
        //new int[] {  11, 2, 4 },
        //new int[] { 4, 5, 6 },
        //new int[] { 10, 8, -12 },
        //};

        //int[][] matrix = { {3}, { 11, 2, 4 }, { 4, 5, 6 }, { 10, 8, -12 } };

        var listOfLists = new List<List<int>>();
        int[] arr11 = { 3 };
        int[] arr22 = { 11, 2, 4 };
        int[] arr33 = { 4, 5, 6 };
        int[] arr44 = { 10, 8, -12 };

        listOfLists.Add(arr11.ToList());
        listOfLists.Add(arr22.ToList());
        listOfLists.Add(arr33.ToList());
        listOfLists.Add(arr44.ToList());

        var resJagged = diagonalDifference(listOfLists);

        var towerRes = towerBreakers(2, 2);
        towerRes = towerBreakers(1, 4);
        //towerRes = towerBreakers(304311, 611791);

        var resCaesar = caesarCipher("middle-Outz", 2);
        resCaesar = caesarCipher("www.abc.xy", 87);
        resCaesar = caesarCipher("Ciphering.", 26);

        var pal = palindromeIndex("aaab");
        pal = palindromeIndex("baa");
        pal = palindromeIndex("aaa");

        int[] arrZigZag = { 1, 2, 3, 4, 5, 6, 7 };
        FindZigZagSequence(arrZigZag, 7);

        //List<string> list = new List<string> { "abc", "ade", "efg" };
        //List<string> list = new List<string> { "abc", "ade", "efb" };
        //List<string> list = new List<string> { "hcd", "awc", "shm" };
        //List<string> list = new List<string> { "sur", "eyy", "gxy" };
        //List<string> list = new List<string> { "nyx", "ynx", "xyt" };
        //List<string> list = new List<string> { "vpvv", "pvvv", "vzzp", "zzyy" };
        List<string> list = new List<string> { "abc", "lmp", "qrt" };
        Console.WriteLine(GridChallenge(list));

        //var resDigit = SuperDigit("9875", 4);
        var resDigit = SuperDigit("148", 3);
        Console.WriteLine("Super Digit is {0}", resDigit);

        var super = FindSuperDigit("9875", 4);

        //int[] queue = { 2, 1, 5, 3, 4 };
        //int[] queue = { 5, 1, 2, 3, 7, 8, 6, 4 };
        int[] queue = { 1, 2, 5, 3, 7, 8, 6, 4 };
        minimumBribes(queue.ToList());

        MinimumBribes(queue);

        int[] queue2 = { 2, 1, 5, 3, 4 };
        MinimumBribes(queue2); // Output: 3
        /*
        In the above example, the queue is [2, 1, 5, 3, 4], so the function first checks 
        if any person has moved more than two positions forward. Since no person has moved more 
        than two positions forward, the function counts the number of bribes that took place.
        Person 1 bribed person 2 to move forward, person 2 did not bribe anyone, person 5 bribed person 4
        to move forward, and person 4 bribed person 3 to move forward, so the total number of bribes is 3.
        The function then prints the number of bribes, which is 3.
        */

        SinglyLinkedList sl1 = new SinglyLinkedList();
        //sl1.InsertNode(1);
        //sl1.InsertNode(3);
        //sl1.InsertNode(7);
        sl1.InsertNode(8);
        sl1.InsertNode(11);
        sl1.InsertNode(17);
        sl1.InsertNode(20);
        sl1.InsertNode(20);
        sl1.InsertNode(42);
        sl1.InsertNode(83);
        sl1.InsertNode(94);
        sl1.InsertNode(95);

        SinglyLinkedList sl2 = new SinglyLinkedList();
        sl2.InsertNode(1);
      
        var newHead = mergeLists(sl1.head, sl2.head);

        /*
        int queries = Convert.ToInt32(Console.ReadLine());

        var myQueue = new QueueOf2Stacks();
                
        for (int query = 0; query < queries; query++)
        {

            string paramsLine = Console.ReadLine().ToString();

            int queryType = 0;
            string[] splits = paramsLine.Split(" ");
            if (splits.Length == 2)
            {
                queryType = 1;
                int valueToEnqueue = Convert.ToInt32(splits[1]);
                myQueue.Enqueue(valueToEnqueue);
            }
            else
            {
                queryType = Convert.ToInt32(paramsLine);

                if (queryType == 2)
                {
                    var dequeued = myQueue.Dequeue();
                }
                else if (queryType == 3)
                {
                    var front = myQueue.Print();
                    Console.WriteLine(front);
                }
            }
        }

        int operations = Convert.ToInt32(Console.ReadLine());

        var textEditor = new TextEditor();

        for (int op = 0; op < operations; op++)
        {
            string paramsLine = Console.ReadLine().ToString();

            string[] splits = paramsLine.Split(" ");

            var opType = splits[0];

            switch (opType)
            {
                case "1":
                    textEditor.Append(splits[1]);
                    break;
                case "2":
                    textEditor.Delete(Convert.ToInt32(splits[1]));
                    break;
                case "3":
                    textEditor.Print(Convert.ToInt32(splits[1]));
                    break;
                case "4":
                    textEditor.Undo();
                    break;
            }
        }
        */

        var lego1 = legoBlocks(2, 2);
        var lego2 = legoBlocks(3, 2);
        var lego3 = legoBlocks(2, 3);
        var lego4 = legoBlocks(4, 4);

        //int[] cookies = { 1, 2, 3, 9, 10, 12 };
        //int[] cookies = { 2,7,3,6,4 };
        //int[] cookies = { 1, 1, 1 };
        int[] cookies = { 6214, 8543, 9266, 1150, 7498, 7209, 9398, 1529, 1032, 7384, 6784, 34, 1449, 7598, 8795, 756, 7803, 4112, 298, 4967, 1261, 1724, 4272, 1100, 9373 };
        var cookiesRes = Cookies(3581, cookies);

        //List<string> listDup = new List<string> { "aab","defgab","abcde","aabcde","cedaaa","bbbbbbbbbb","jabjjjad"};
        //List<string> listDup = new List<string> { "aab","aac","aacghgh","aabghgh"};
        List<string> listDup = new List<string> { "dfbacgjecgfjcaejghacjdhcchj", "jjffdbeeejiehjdidbbdgidcaeejjdeiicibjfjgjjchedci", "jhjfbjbhijbcgefgbbgdjbihcehfbgdeaie", "jjddfcjaebdfbeaehaecibdbdcibebjbfgjidijhbjche", "eiejiajeiefadghfffdh", "gfdcdfjhiebfgicgfcghgicbabbaadbaj", "gdjfbbhgieabiejajaefdfjdiadbieheiddeegie", "hffedadc", "g" };
        noPrefix(listDup);
        noPrefixOptimized(listDup);
        Console.ReadLine();
    }

    static void PlusMinus(List<int> arr)
    {
        float positive = 0;
        float negative = 0;
        float zeros = 0;
        int total = arr.Count;

        arr.ForEach(item =>
        {
            if (item == 0)
            {
                zeros++;
            }
            else if (item < 0)
            {
                negative++;
            }
            else
            {
                positive++;
            }
        });
        float potRatio = (float)(positive / total);
        float negRatio = (float)(negative / total);
        float zeroRatio = (float)(zeros / total);
        Console.WriteLine(string.Format("{0:0.000000}", potRatio));
        Console.WriteLine(string.Format("{0:0.000000}", negRatio));
        Console.WriteLine(string.Format("{0:0.000000}", zeroRatio));
    }

    static bool IsPalindrome(string str)
    {
        char[] charArray = str.ToCharArray();
        Array.Reverse(charArray);
        string reversedStr = new string(charArray);

        return str == reversedStr;
    }

    static int palindromeIndex(string s)
    {
        if (IsPalindrome(s))
            return -1;

        for (int i = 0; i < s.Length; i++)
        {
            var newString = s.Remove(i, 1);
            if (IsPalindrome(newString))
                return i;
        }

        return -2;
    }

    static int getOtherPlayer(int turn)
    {
        if (turn == 1)
        {
            return 2;
        }
        else
        {
            return 1;
        }
    }

    static string caesarCipher(string s, int k)
    {
        Dictionary<char, char> lowerDic = new Dictionary<char, char>();
        Dictionary<char, char> upperDic = new Dictionary<char, char>();

        string lowerAlphabet = "abcdefghijklmnopqrstuvwxyz";
        string upperAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        foreach (var curChar in lowerAlphabet)
        {
            var value = (char)(k % 26 + curChar);

            if (value > 'z')
            {
                lowerDic[curChar] = (char)(value - 'z' + 'a' - 1);
            }
            else
            {
                lowerDic.Add(curChar, value);
            }
        }
        foreach (var curChar in upperAlphabet)
        {
            var value = (char)(k % 26 + curChar);

            if (value > 'Z')
            {
                upperDic[curChar] = (char)(value - 'Z' + 'A' - 1);
            }
            else
            {
                upperDic.Add(curChar, value);
            };
        }

        var result = "";

        foreach (var curChar in s)
        {
            if (char.IsUpper(curChar))
            {
                if (upperDic.ContainsKey(curChar))
                {
                    result += upperDic[curChar];
                }
            }
            else if (char.IsLower(curChar))
            {
                if (lowerDic.ContainsKey(curChar))
                {
                    result += lowerDic[curChar];
                }
            }
            else
            {
                result += curChar;
            }

        }

        return result;
    }

    static int towerBreakers(int n, int m)
    {
        int[] towers = new int[n];
        Array.Fill(towers, m);

        int[] towers2 = Enumerable.Repeat(m, n).ToArray();

        int turn = 1;

        bool stillPlaying = true;

        while (stillPlaying)
        {
            //check for loosing
            if (towers.All(tower => tower == 1))
            {
                return getOtherPlayer(turn);
            }

            //Play
            bool sw = true;

            for (int i = 0; i < towers.Count() && sw; i++)
            {
                if (towers[i] == 1)
                {
                    continue;
                }
                for (int j = (int)Math.Floor(Math.Sqrt(towers[i])); j >= 1; j--)
                {
                    if (towers[i] % (towers[i] - j) == 0)
                    {
                        towers[i] = towers[i] - j;
                        sw = false;
                        break;
                    }
                }
            }

            turn = getOtherPlayer(turn);
        }
        return -1;
    }

    static List<int> countingSort(List<int> arr)
    {
        int[] array = new int[100];
        for (int i = 0; i < 100; ++i)
        {
            array[i] = 0;
        }

        for (int i = 0; i < arr.Count(); i++)
        {
            var currentValue = arr[i];
            array[currentValue]++;
        }

        return array.ToList();
    }

    static int diagonalDifference(List<List<int>> arr)
    {
        int size = arr[0][0];
        int leftDiagnoal = 0;
        int rightDiagnoal = 0;
        int colLeft = 0;
        int colRight = size - 1;
        for (int i = 1; i <= size; i++)
        {
            leftDiagnoal += arr[i][colLeft];
            rightDiagnoal += arr[i][colRight];
            colLeft++;
            colRight--;
        }

        return Math.Abs(leftDiagnoal - rightDiagnoal);
    }

    //If only the values arrived!
    static int diagonalDifference2(List<List<int>> arr)
    {
        int size = arr.Count();

        int leftDiagnoal = 0;
        int rightDiagnoal = 0;
        int colLeft = 0;
        int colRight = size - 1;
        for (int i = 0; i < size; i++)
        {
            leftDiagnoal += arr[i][colLeft];
            rightDiagnoal += arr[i][colRight];
            colLeft++;
            colRight--;
        }

        return Math.Abs(leftDiagnoal - rightDiagnoal);

    }

    static int findMedian(List<int> arr)
    {
        arr.Sort();
        var items = arr.Count();
        return arr[items / 2];
    }

    static int lonelyinteger(List<int> a)
    {
        a.Sort();
        for (int i = 0; i < a.Count() - 1; i++)
        {
            if (a[i] != a[i + 1])
            {
                return a[i];
            }
            else
            {
                i++;
            }
        }
        return a[a.Count() - 1];
    }

    static string TimeConversion(string s)
    {
        bool isPM = false;
        if (s.ToLower().Contains("pm"))
        {
            isPM = true;
        }
        var cleanedString = s.Replace("PM", "").Replace("pm", "").Replace("AM", "").Replace("am", "");
        var splits = cleanedString.Split(":");
        string hour = splits[0];
        string minute = splits[1];
        string sec = splits[2];
        int intHour = Convert.ToInt32(hour);

        if (!isPM) //AM
        {
            if (intHour >= 12)
            {
                intHour -= 12;
            }
        }
        else
        { //PM
            if (intHour != 12)
            {
                intHour += 12;
            }
        }

        return string.Format("{0:D2}:{1:D2}:{2:D2}", intHour, minute, sec);
    }

    static void MiniMaxSum(List<int> arr)
    {
        arr.Sort();
        long minSum = 0;
        long maxSum = 0;
        long totalSum = 0;
        foreach (int x in arr)
        {
            totalSum += x;
        }
        minSum = totalSum - arr[arr.Count() - 1];
        maxSum = totalSum - arr[0];

        Console.WriteLine(string.Format("{0} {1}", minSum, maxSum));
    }

    static void FindZigZagSequence(int[] a, int n)
    {
        Array.Sort(a);
        // a.OrderBy(x => x);

        int mid = n / 2; //Change
        int temp = a[mid];
        a[mid] = a[n - 1];
        a[n - 1] = temp;

        int st = mid + 1;
        int ed = n - 2; //change
        while (st <= ed)
        {
            temp = a[st];
            a[st] = a[ed];
            a[ed] = temp;
            st = st + 1;
            ed = ed - 1; //change
        }
        for (int i = 0; i < n; i++)
        {
            if (i > 0)
                Console.Write(" ");
            Console.Write(a[i]);
        }
        Console.WriteLine();
    }

    static string GridChallenge(List<string> grid)
    {
        for (int i = 0; i < grid.Count(); i++)
        {
            char[] charArray = grid[i].ToCharArray();
            Array.Sort(charArray);
            grid[i] = string.Join("", charArray);
        }
        int rowCount = grid.Count();
        int colCount = grid[0].Length;
        for (int col = 0; col < colCount; col++)
        {
            var str = "";
            for (int row = 0; row < rowCount; row++)
            {
                var currentChar = grid[row][col];
                if (row > 0)
                {
                    var prevChar = grid[row - 1][col];
                    if (prevChar > currentChar)
                    {
                        return "NO";
                    }
                }
                str += currentChar;
            }
        }
        return "YES";
    }

    static int SuperDigit(string n, int k) //Recurrsion
    {
        if (k == 1) //תנאי עצירה!
        {
            return Convert.ToInt32(n);
        }
        char[] arr = n.ToCharArray();
        int sum = 0;
        foreach (var charX in arr)
        {
            sum += Convert.ToInt32(charX - 48);
        }
        return SuperDigit(sum.ToString(), sum.ToString().Length);
    }

    static int FindSuperDigit(string number, int k)
    {
        // If the number has only one digit, return that digit
        if (number.Length == 1)
        {
            return int.Parse(number);
        }
        // Calculate the sum of the digits
        int sum = 0;
        foreach (char c in number)
        {
            sum += int.Parse(c.ToString());
        }
        // Recursively call the function with the sum as the input number
        return FindSuperDigit(sum.ToString(), sum.ToString().Length);
    }

    static void minimumBribes(List<int> q)
    {
        int totalBribes = 0;

        for (int i = 0; i < q.Count(); i++)
        {
            var expectedPos = i + 1;
            var actualPos = q[i];
            var diff = actualPos - expectedPos;
            if (diff > 2)
            {
                Console.WriteLine("Too chaotic");
                return;
            }
            else if (diff == 1 || diff == 2)
            {
                totalBribes += diff;
            }
        }
        Console.WriteLine(totalBribes);
    }

    static void MinimumBribes(int[] queue)
    {
        int bribes = 0;

        // Iterate over the queue from the end to the beginning
        for (int i = queue.Length - 1; i >= 0; i--)
        {
            // Check if the person has moved more than two positions forward
            if (queue[i] - (i + 1) > 2)
            {
                Console.WriteLine("Too chaotic");
                return;
            }

            // Count the number of people who have bribed this person
            for (int j = Math.Max(0, queue[i] - 2); j < i; j++)
            {
                if (queue[j] > queue[i])
                {
                    bribes++;
                }
            }
        }

        Console.WriteLine(bribes);
    }

   

    static string IsBalancedChatGPT(string s)
    {
        Stack<char> stack = new Stack<char>();
        foreach (char c in s)
        {
            if (c == '(' || c == '[' || c == '{')
            {
                stack.Push(c);
            }
            else if (c == ')' || c == ']' || c == '}')
            {
                if (stack.Count == 0)
                {
                    return "NO"; // Closing bracket without a matching opening bracket
                }
                char poppedChar = stack.Pop();
                if (c == ')' && poppedChar != '(' ||
                    c == ']' && poppedChar != '[' ||
                    c == '}' && poppedChar != '{')
                {
                    return "NO"; // Mismatched closing bracket
                }
            }
        }
        return stack.Count == 0 ? "YES" : "NO";
    }

    static SinglyLinkedListNode mergeLists(SinglyLinkedListNode head1, SinglyLinkedListNode head2)
    {
        SinglyLinkedList res = new SinglyLinkedList();
        if (head1 == null && head2 == null)
        {
            return res.head;
        }

        while (head1 != null && head2 != null)
        {
            int elm1Cur = head1.data;
            int elm2Cur = head2.data;

            if (elm1Cur < elm2Cur)
            {
                res.InsertNode(elm1Cur);
                head1 = head1.next;
            }
            else if (elm1Cur == elm2Cur)
            {
                res.InsertNode(elm1Cur);
                res.InsertNode(elm2Cur);
                head1 = head1.next;
                head2 = head2.next;
            }
            else if (elm1Cur >= elm2Cur)
            {
                res.InsertNode(elm2Cur);
                head2 = head2.next;
            }
        }
        if (head1 == null && head2 != null)
        {
            res.tail.next = head2;
        }
        else if (head2 == null && head1 != null)
        {
            res.tail.next = head1;
        }

        return res.head;
    }

    static int legoBlocks(int n, int m)
    {
        Dictionary<int, int> dic = new Dictionary<int, int>();
        dic.Add(1, 1);
        dic.Add(2, 2);
        dic.Add(3, 4);
        dic.Add(4, 8);

        Dictionary<int, int> dicBadOptions = new Dictionary<int, int>();
        dicBadOptions.Add(1, 1);
        dicBadOptions.Add(2, 1);
        dicBadOptions.Add(3, 7);
        dicBadOptions.Add(4, 6);

        var rowOptions = dic[m];
        var totaloptions = (int)(Math.Pow(rowOptions, n) - dicBadOptions[m]);

        return totaloptions % (1000000007);
    }

    static int Cookies(int k, List<int> A)
    {
        int counter = 0;
        while (!A.All(x => x >= k))
        {
            var arr = A.OrderBy(x => x).ToArray();
            var smallNums = arr.Take(2).ToArray();
            var smallest = smallNums[0];
            var nextSmallest = smallNums[1];
            var newVal = smallest + 2 * nextSmallest;
            A.Remove(smallest);
            A.Remove(nextSmallest);
            A.Add(newVal);
            counter++;
        }
        return counter;
    }
    static int Cookies(int k, int[] arr)
    {
        int operations = 0;
        List<int> list = new List<int>();
        for (int i = 0; i < arr.Length; i++)
        {
            list.Add(arr[i]);
        }
        list.Sort();
        // Perform operations until the least sweet cookie has sweetness >= k
        while (list.Count > 1 && list[0] < k)
        {
            int cookie1 = list[0];//.Dequeue();
            int cookie2 = list[1];//.Dequeue();
            list.Remove(cookie1);
            list.Remove(cookie2);
            int newCookie = cookie1 + (2 * cookie2);
            list.Add(newCookie);
            list.Sort();
            operations++;
        }
        list.Sort();
        // If all cookies have sweetness >= k, return the number of operations
        // Otherwise, return -1 indicating it's not possible
        return list[0] >= k ? operations : -1;
    }
    //SHOULD BE IMPLEMENTED USING A TRIE!!!
    static void noPrefixOptimized(List<string> words)
    {
        var foundDup = "";
        int indexGap = int.MaxValue;
        SortedDictionary<string,int> sd = new SortedDictionary<string,int>();
        int index = 0;
        foreach (string word in words) 
        {
            sd.Add(word, index);
            index++;
        }
        List<string> list = sd.Keys.ToList<string>();
        bool foundDupSw = false;
        for (int i = 0; i < list.Count()-1; i++)
        {
            var curWord = list[i];
            var nextWord = list[i + 1];
            if (curWord.StartsWith(nextWord) || nextWord.StartsWith(curWord))
            {
                var currentGap = Math.Abs(sd[nextWord] - sd[curWord]);
                if(currentGap < indexGap)
                {
                    indexGap = currentGap;
                    foundDupSw = true;
                    if (sd[curWord]> sd[nextWord])//position
                    {
                        foundDup = curWord;
                    }
                    else
                    {
                        foundDup = nextWord;
                    }
                    i += 1;
                }
            }
        }
        if (foundDupSw)
        {
            Console.WriteLine("BAD SET");
            Console.WriteLine(foundDup);
        }
        else
        {
            Console.WriteLine("GOOD SET");
        }
    }

    static void noPrefix(List<string> words)
    {
        var foundDup = "";
        int foundIndex = int.MaxValue;

        for (int i = 0; i < words.Count(); i++)
        {
            string curWord = words[i];
            for (int j = i+1; j < words.Count(); j++)
            {
                if (words[j].StartsWith(curWord) || curWord.StartsWith(words[j])){
                    if (j < foundIndex)
                    {
                        foundIndex = j;
                        foundDup = words[j];
                    }
                }
            }
        }
        if (foundIndex < int.MaxValue)
        {
            Console.WriteLine("BAD SET");
            Console.WriteLine(foundDup);
        }
        else
        {
            Console.WriteLine("GOOD SET");
        }

    }
}

class SinglyLinkedListNode
{
    public int data;
    public SinglyLinkedListNode next;

    public SinglyLinkedListNode(int nodeData)
    {
        this.data = nodeData;
        this.next = null;
    }
}

class SinglyLinkedList
{
    public SinglyLinkedListNode head;
    public SinglyLinkedListNode tail;

    public SinglyLinkedList()
    {
        this.head = null;
        this.tail = null;
    }

    public void InsertNode(int nodeData)
    {
        SinglyLinkedListNode node = new SinglyLinkedListNode(nodeData);
        if (this.head == null)
        {
            this.head = node;
        }
        else
        {
            this.tail.next = node;
        }
        this.tail = node;
    }
}

class QueueOf2Stacks
{
    private Stack<int> writeQueue = new Stack<int>();
    private Stack<int> readStack = new Stack<int>();
    public void Enqueue(int value)
    {
        writeQueue.Push(value);
    }
    public int Dequeue()
    {
        while (writeQueue.Count() > 0)
        {
            readStack.Push(writeQueue.Pop());
        }
        var value = readStack.Pop();
        while (readStack.Count() > 0)
        {
            writeQueue.Push(readStack.Pop());
        }
        return value;
    }
    public int Print()
    {
        while (writeQueue.Count() > 0)
        {
            readStack.Push(writeQueue.Pop());
        }
        var front = readStack.Peek();
        while (readStack.Count() > 0)
        {
            writeQueue.Push(readStack.Pop());
        }
        return front;
    }
}

class TextEditor
{
    private string text = "";
    private Stack<string> ops = new Stack<string>();
    public void Append(string str)
    {
        ops.Push(text);
        text += str;
    }
    public void Delete(int k)
    {
        ops.Push(text);
        //First option using Substring() !
        //text = text.Substring(0, Math.Max(0, text.Length - k));
        //Second option - using Remove()
        if (text.Length - k < 0)
        {
            text = "";
        }
        else
        {
            text = text.Remove(text.Length - k);
        }
    }
    public void Print(int k)
    {
        if ((k - 1) >= 0 && (k - 1) <= text.Length)
            Console.WriteLine(text[k - 1]);
    }
    public void Undo()
    {
        text = ops.Pop();
    }
}
/*
static SinglyLinkedListNode mergeLists(SinglyLinkedListNode head1, SinglyLinkedListNode head2)
{

    SinglyLinkedListNode res = new SinglyLinkedListNode();

    while (head1 != null || head2 != null)
    {
        int elm1Cur = head1.data;
        int elm2Cur = head2.data;

        if (head1 == null)
        {
            res.Addlast(elm2Cur);
        }
        else if (head2 == null)
        {
            res.Addlast(head1);
        }

        if (elm1Cur < elm2Cur)
        {
            res.AddLast(elm1Cur);
            head1 = head1.next;
        }
        else if (elm1Cur == elm2Cur)
        {
            res.AddLast(elm1Cur);
            res.AddLast(elm2Cur);
            head1 = head1.next;
            head2 = head2.next;
        }
        else if (elm1Cur >= elm2Cur)
        {
            res.AddLast(elm2Cur);
            head2 = head2.next;
        }
    }

    return res;

}
*/