// See https://aka.ms/new-console-template for more information
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

internal class Program
{
    static bool ContainsDuplicate(int[] numsArr)
    {
        var uniqueNums = new HashSet<int>();

        foreach (int num in numsArr)
        {
            if (uniqueNums.Contains(num))
                return true;

            uniqueNums.Add(num);
        }
        return false;
    }

    static bool ContainsDuplicateSorted(int[] nums)
    {
        Array.Sort(nums);

        for (int i = 0; i < nums.Length - 1; i++)
        {
            if (nums[i] == nums[i + 1])
                return true;
        }

        return false;
    }

    static int BruteForceLengthOfLongestSubstring(string input)
    {
        int maxString = 0;

        for (int i = 0; i < input.Length; i++)
        {
            var curretnHasSet = new HashSet<char>(input[i]);

            for (int j = 1; j < input.Length - i; j++)
            {
                if (curretnHasSet.Contains(input[j]))
                {
                    if (curretnHasSet.Count > maxString)
                        maxString = curretnHasSet.Count;
                    continue;
                }
                curretnHasSet.Add(input[j]);
            }
        }

        return maxString;
    }
    static int SlidingWindowLengthOfLongestSubstrings2(string s)
    {
        var set = new HashSet<char>();
        int left = 0;
        int maxString = 0;
        for(int right=0; right<s.Length; right++)
        {
            while (set.Contains(s[right]))
            {
                set.Remove(s[left]);
                left++;
            }
            set.Add(s[right]);
            maxString = Math.Max(maxString, set.Count);
        }
        return maxString;
    }

    static int MySlidingWindowLengthOfLongestSubstring(string s)
    {
        var set = new HashSet<char>();
        var maxLength = 0;
        int left = 0;

        for (int right=0; right < s.Length; right++)
        {
            if (!set.Contains(s[right]))
            {
                set.Add(s[right]);
                maxLength = Math.Max(maxLength, set.Count);
            }
            else
            {
                while (set.Contains(s[left]))
                {
                    set.Remove(s[left]);
                    left++;
                }
                set.Add(s[right]);
            }
        }

        return maxLength;
    }
    static int SlidingWindowLengthOfLongestSubstring(string s)
    {
        var set = new HashSet<char>();
        int left = 0;
        int maxLength = 0;

        for (int right = 0; right < s.Length; right++)
        {
            while (set.Contains(s[right]))
            {
                set.Remove(s[left]);
                left++;
            }

            set.Add(s[right]);
            maxLength = Math.Max(maxLength, right - left + 1);
        }

        return maxLength;
    }

    static int AtMost2DistinctCharacters(string input)
    {
        if (string.IsNullOrEmpty(input))
            return 0;

        int maxLength = 0;
        int left = 0;

        var dictionary = new Dictionary<char, int>();

        for (int right = 0; right < input.Length; right++)
        {
            char c = input[right];

            // expand right
            if (!dictionary.ContainsKey(c))
                dictionary[c] = 0;

            dictionary[c]++;

            // shrink until valid
            while (dictionary.Count > 2)
            {
                char leftChar = input[left];

                dictionary[leftChar]--;

                if (dictionary[leftChar] == 0)
                    dictionary.Remove(leftChar);

                left++;
            }

            // update result
            maxLength = Math.Max(maxLength, right - left + 1);
        }

        return maxLength;
    }

    static bool ValidPath(int n, int[][] edges, int source, int destination)
    {
        var graph = new Dictionary<int, List<int>>();

        // build graph
        for (int i = 0; i < n; i++)
            graph[i] = new List<int>();

        foreach (var edge in edges)
        {
            graph[edge[0]].Add(edge[1]);
            graph[edge[1]].Add(edge[0]);
        }

        var visited = new HashSet<int>();
        var queue = new Queue<int>();
        queue.Enqueue(source);

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();

            if (node == destination)
                return true;

            if (visited.Contains(node))
                continue;

            visited.Add(node);

            foreach (var neighbor in graph[node])
            {
                queue.Enqueue(neighbor);
            }
        }

        return false;
    }

    static (int maxClicks, string user) FindMaxUserClicks(object[] userClicks)
    {
        string maxUser = "";
        int maxClicks = 0;

        Dictionary<string, int> clickCounts = new Dictionary<string, int>();

        foreach (dynamic item in userClicks)
        {
            string user = item.user;
            int value = item.value;

            if (item.action != "click")
            {
                continue;
            }

            if (clickCounts.ContainsKey(user))
            {
                clickCounts[user] += value;
            }
            else
            {
                clickCounts[user] = value;
            }
            if (clickCounts[user] > maxClicks)
            {
                maxClicks = clickCounts[user];
                maxUser = user;
            }
        }
        return (maxClicks, maxUser);
    }

    /*
    Given an array of integers nums and an integer k, determine if there are two distinct indices i and j such that:

    nums[i] == nums[j]
    and |i - j| <= k

    Return true if such indices exist, otherwise false.
    */
    static bool SameNumsAtKDistance(int[]nums, int k)
    {
        var dictionary = new Dictionary<int, int>(); //key=num, value=index
       
        for(int i=0; i < nums.Length; i++)
        {
            var currentNum = nums[i];
            
            if(!dictionary.ContainsKey(currentNum))
            {
                dictionary[currentNum] = i;
            }
            else  //exist
            {
                if (Math.Abs(dictionary[currentNum] - i) <= k)
                {
                    return true;
                }
                dictionary[currentNum] = i;
            }
        }
        return false;
    }

    static int KadenAlgorithm(int[] array)
    {
        int maxSum = int.MinValue;
        int currentSum = 0;

        for (int i = 0; i < array.Length; i++)
        {
            currentSum += array[i];
           
            if (currentSum > maxSum)
            {
                maxSum = currentSum;  // ← capture before reset
            }
           
            if (currentSum < 0)
            {
                currentSum = 0;       // ← reset after
            }
        }
        return maxSum;
    }
    /*
    HashSet<int> visited = new HashSet<int>();
    void DFSRecurrsive(int node)
    {

        if (visited.Contains(node))
            return;

        visited.Add(node);

        foreach (var neighbor in graph[node])
        {
            DFSRecurrsive(neighbor);
        }
    }
    void DFSIterative(int node)
    {
        var stack = new Stack<int>();
       
        stack.Push(start);

        var visited = new HashSet<int>();

        while (stack.Count > 0)
        {
            var node = stack.Pop();

            if (visited.Contains(node))
                continue;

            visited.Add(node);

            foreach (var neighbor in graph[node])
            {
                stack.Push(neighbor);
            }
        }
    }
    */

    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        int[] nums = new int[4] { 1, 2, 3, 4 };

        Console.WriteLine("Duplicate Exist=" + ContainsDuplicate(nums).ToString());
        Console.WriteLine("Faster Duplicate Exist=" + ContainsDuplicateSorted(nums).ToString());

        nums = [1, 2, 3, 1];

        Console.WriteLine("Duplicate Exist=" + ContainsDuplicate(nums).ToString());
        Console.WriteLine("Faster Duplicate Exist=" + ContainsDuplicateSorted(nums).ToString());


        Console.WriteLine("Longest Unique String for abcabcbb " + BruteForceLengthOfLongestSubstring("abcabcbb"));

        Console.WriteLine("Longest Substring for \"abcabcbb\" " + SlidingWindowLengthOfLongestSubstring("abcabcbb"));
        Console.WriteLine("Longest Substring for \"bbbbb\" " + SlidingWindowLengthOfLongestSubstring("bbbbb"));
        Console.WriteLine("Longest Substring for \"pwwkew\" " + SlidingWindowLengthOfLongestSubstring("pwwkew"));

        Console.WriteLine("Longest Substring for \"abcabcbb\" " + MySlidingWindowLengthOfLongestSubstring("abcabcbb"));
        Console.WriteLine("Longest Substring for \"bbbbb\" " + MySlidingWindowLengthOfLongestSubstring("bbbbb"));
        Console.WriteLine("Longest Substring for \"pwwkew\" " + MySlidingWindowLengthOfLongestSubstring("pwwkew"));

        Console.WriteLine("Longest Substring for \"abcabcbb\" " + SlidingWindowLengthOfLongestSubstrings2("abcabcbb"));
        Console.WriteLine("Longest Substring for \"bbbbb\" " + SlidingWindowLengthOfLongestSubstrings2("bbbbb"));
        Console.WriteLine("Longest Substring for \"pwwkew\" " + SlidingWindowLengthOfLongestSubstrings2("pwwkew"));

        int n = 3;
        var edges = new int[][] { [0, 1], [1, 2] };
        int source = 0;
        int destination = 2;

        Console.WriteLine(
            "Is Source and Destination Connected = " + ValidPath(n, edges, source, destination)
        );

        edges = new int[][] { [0, 1], [1, 2], [2, 3], [4, 5], [5, 6] };
        n = 7;
        source = 0;
        destination = 6;

        Console.WriteLine(
            "Is Source and Destination Connected = " + ValidPath(n, edges, source, destination)
        );

        int MaxSumOfSubarray(int[] nums)
        {
            int maxSum = int.MinValue;
            int currentSum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                currentSum += nums[i];

                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                }

                if (currentSum < 0)
                {
                    currentSum = 0;
                }
            }

            return maxSum;
        }

        var nums2 = new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
        Console.WriteLine("MaxSumOfSubarray = " + MaxSumOfSubarray(nums2));

        var userClicks = new object[]
        {
            new { user = "A", action = "click", value = 10 },
            new { user = "B", action = "click", value = 20 },
            new { user = "A", action = "view", value = 5 },
            new { user = "A", action = "click", value = 15 },
            new { user = "B", action = "view", value = 100 },
            new { user = "C", action = "click", value = 50 },
        };

        var result = FindMaxUserClicks(userClicks);
        Console.WriteLine($"Max clicks user: {result.user} with {result.maxClicks} clicks");

        Console.WriteLine($"Max String length is " + AtMost2DistinctCharacters("eceba"));
        Console.WriteLine($"Max String length is " + AtMost2DistinctCharacters("ccaabbb"));
        Console.WriteLine($"Max String length is " + AtMost2DistinctCharacters("aaaaaa"));
        Console.WriteLine($"Max String length is " + AtMost2DistinctCharacters("abababab"));
        Console.WriteLine($"Max String length is " + AtMost2DistinctCharacters("abcabcabc"));
        Console.WriteLine($"Max String length is " + AtMost2DistinctCharacters("aabacbebebe"));
        Console.WriteLine($"Max String length is " + AtMost2DistinctCharacters("abcbbbbcccbdddadacb"));
        Console.WriteLine($"Max String length is " + AtMost2DistinctCharacters("a"));
        Console.WriteLine($"Max String length is " + AtMost2DistinctCharacters("ab"));
        Console.WriteLine($"Max String length is " + AtMost2DistinctCharacters(""));
        Console.WriteLine($"Max String length is " + AtMost2DistinctCharacters("ababffzzeee"));

        /*
        left = 0
        for right in range:
            add input[right] to structure

            while invalid_condition:
                remove input[left]
                left++

            update answer
        */
        Console.WriteLine($"For This array is same numbers exist in K distance" + SameNumsAtKDistance([1, 2, 3, 1], 3));
        Console.WriteLine($"For This array is exist in K distance" + SameNumsAtKDistance([1, 2, 3, 1], 2));

        Console.WriteLine("Max Number in array is " + KadenAlgorithm([-2, 1, -3, 4, -1, 2, 1, -5, 4]));
    }
}
