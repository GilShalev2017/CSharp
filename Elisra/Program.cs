// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Xml.Linq;

internal class Program
{
    public interface IDataStructure
    {
        void SetValue(int index, int value);
        int GetValue(int index);
        void ResetToDefaultValue();
    }
    public class DataStructure : IDataStructure
    {
        Dictionary<int, int> _dic = new Dictionary<int, int>();
        int _size= 0;
        int _defaultValue;
        public DataStructure(int size, int defaultValue)
        {
            _size = size;
            _defaultValue = defaultValue;
        }
        public int GetValue(int index)
        {
            if(index >= _size || index <0)
            {
                throw new IndexOutOfRangeException();
            }
            if (!_dic.ContainsKey(index))
            {
                return _defaultValue;
            }
            return _dic[index];
        }
        public void ResetToDefaultValue()
        {
            _dic.Clear();
        }
        public void SetValue(int index, int value)
        {
            if (index >= _size || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            _dic[index] = value;
        }
    }

    public class ListNode
    {
        public int Value { get; set; }
        public ListNode Next { get; set; }
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
    public class PhoneCall
    {
        public int StartTime;
        public int EndTime;
        public PhoneCall(int startTime, int endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }
    }
    private static int PeakCalls(List<PhoneCall> phoneCalls)
    {
        int res = 0;
        int counter = 0;

        phoneCalls = phoneCalls.OrderBy(x => x.StartTime).ToList();
        
        for(int i=0; i<phoneCalls.Count-1; i++) 
        {
            var p1 = phoneCalls[i];
            var p2 = phoneCalls[i+1];
            bool isOverLapped = p1.StartTime < p2.EndTime && p2.StartTime < p1.EndTime;

            if(isOverLapped) 
            {
                counter++;
            }
            else
            {
                if(counter > res)
                {
                    res = counter;
                    counter = 0;
                }
            }
        }
        if(counter > res )
        {
            res = counter;
        }

        return (res + 1);
    }

    public static bool AreAnagrams(string str1, string str2)
    {
        // Step 1: Handle null or empty strings and different lengths
        if (string.IsNullOrEmpty(str1) || string.IsNullOrEmpty(str2))
        {
            return false; // Or handle as per specific requirements (e.g., two empty strings are anagrams)
        }

        if (str1.Length != str2.Length)
        {
            return false;
        }

        // Step 2: Convert strings to character arrays and sort them
        char[] charArray1 = str1.ToLower().ToCharArray(); // Convert to lowercase for case-insensitivity
        char[] charArray2 = str2.ToLower().ToCharArray();

        Array.Sort(charArray1);
        Array.Sort(charArray2);

        // Step 3: Compare the sorted character arrays
        return new string(charArray1).Equals(new string(charArray2));
    }

    private static bool Rearranged(string str1, string str2)
    {
        if (string.IsNullOrEmpty(str1) || string.IsNullOrEmpty(str2))
        {
            return false; 
        }

        if (str1.Length != str2.Length)
        {
            return false;
        }

        var str1Ordered = str1.ToLower().OrderBy(x => x).ToList();
        var str2Ordered = str2.ToLower().OrderBy(x => x).ToList();

        if (new string(str1Ordered.ToArray()) == new string(str2Ordered.ToArray()))
            return true;
        return false;
    }

    private static void Main(string[] args)
    {
        Console.WriteLine("Welcome To Elisra");

        var ds = new DataStructure(100,0);
        ds.SetValue(10,5);
        ds.SetValue(20, 8);
        var var1 = ds.GetValue(1);
        var var2 = ds.GetValue(10);
        var var3 = ds.GetValue(20);
        ds.ResetToDefaultValue();
        var var4 = ds.GetValue(1);
        var var5 = ds.GetValue(10);
        var var6 = ds.GetValue(20);

        var phoneCall1 = new PhoneCall(10,20);
        var phoneCall2 = new PhoneCall(15, 25);
        var phoneCall3 = new PhoneCall(18, 30);
        var phoneCall4 = new PhoneCall(33, 40);
        var phoneCall5 = new PhoneCall(39, 42);
        var phoneCall6 = new PhoneCall(44, 50);

        List<PhoneCall> list = new List<PhoneCall>();
        list.Add( phoneCall1);
        list.Add(phoneCall2);
        list.Add(phoneCall3);
        list.Add(phoneCall4);
        list.Add(phoneCall5);
        list.Add(phoneCall6);

        var res = PeakCalls(list);

        ListNode nodeA = new ListNode();
        ListNode nodeB = new ListNode();
        ListNode nodeC = new ListNode();
        ListNode nodeD = new ListNode();
        nodeA.Next = nodeB;
        nodeB.Next = nodeC;
        nodeC.Next = nodeD;
        nodeD.Next = nodeA;
        
        var isCircular = IsCircular(nodeA);

        nodeC.Next = null;
        
        isCircular = IsCircular(nodeA);

        var str1 = "Hello";
        var str2 = "Loleh";
        var isAnagram = Rearranged(str1, str2);

        str1 = "Helo";
        str2 = "Hello";
        isAnagram = Rearranged(str1, str2);

        str1 = "Listen";
        str2 = "Silent";
        isAnagram = Rearranged(str1, str2);

        Console.ReadLine();
    }
}
//1. Find if strings are anagrams
//2. Find if linked list is circular
//3. Find Overlapping ranges (pay attention that we need to order them first)
//4. Implement data strcuture of get(int index)/set(ind index, int value)/ctor(int size, int defaultValue)/resetToDefault() where all are in O(1) where
//get(), set(), setDeafult() don't contain memory allocation

