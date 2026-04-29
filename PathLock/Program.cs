using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Reflection;
using System.Reflection.Emit;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ExceptionServices;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

internal class Program
{
    public class TreeNode
    {
        public int Val;
        public TreeNode? Left = null;
        public TreeNode? Right = null;
        public TreeNode(int val) { Val = val; }
    }

    public class ListNode
    {
        public int Val;
        public ListNode? Next = null;

        public ListNode(int val)
        {
            Val = val;
        }

        public ListNode(int val, ListNode next)  // ← add this
        {
            Val = val;
            Next = next;
        }
    }

    private static void Main(string[] args)
    {
        #region Part 1 — Arrays & Strings

        // Two Sum
        // Find two indices whose values add up to target. Hash map avoids the O(n²) nested loop.
        int[] TwoSum(int[] nums, int target)
        {
            var dic = new Dictionary<int, int>(); //key = number, value = index

            for (int i = 0; i < nums.Length; i++)
            {
                var number = nums[i];

                int complementing = target - number;

                if (dic.ContainsKey(complementing))
                {
                    return new[] { dic[complementing], i };
                }
                dic[number] = i;
            }
            return [];
        }

        int[] nums = { 2, 7, 11, 15 };
        int target = 9;
        var result = TwoSum(nums, target);
        Console.WriteLine($"Indices: [{result[0]}, {result[1]}]");

        nums = [-3, 4, 7];
        target = 1;
        result = TwoSum(nums, target);
        Console.WriteLine($"Indices: [{result[0]}, {result[1]}]");

        nums = [0, 5, 3];
        target = 3;
        result = TwoSum(nums, target);
        Console.WriteLine($"Indices: [{result[0]}, {result[1]}]");

        //Sliding Window — Max Sum of K elements
        //Any time you see "subarray of size k" or "contiguous" — think sliding window.
        int MaxSum(int[] nums, int k)
        {
            int sum = 0;

            for (int i = 0; i < k; i++)
            {
                int number = nums[i];

                sum += number;
            }

            int max = sum;

            //To the initial sum we now add the right number and subtract the left
            //this way we create the sliding window, and we always calculate the maximum sub array value

            //At each step I add the incoming right element and drop the outgoing left element
            //Keeping the window exactly k wide.
            //Math.Max then tracks the highest sum seen across all windows.!
            for (int i = k; i < nums.Length; i++)
            {
                int rightNumber = nums[i];

                int leftNumber = nums[i - k];

                sum += rightNumber - leftNumber;

                max = Math.Max(max, sum);
            }

            return max;
        }

        // Basic case
        int[] arr = { 2, 1, 5, 1, 3, 2 };
        Console.WriteLine(MaxSum(arr, 3)); // 9  →  [5, 1, 3]

        // Maximum is at the start
        int[] arr2 = { 10, 3, 1, 2 };
        Console.WriteLine(MaxSum(arr2, 2)); // 13  →  [10, 3]

        // Maximum is at the end
        int[] arr3 = { 1, 2, 3, 4, 5 };
        Console.WriteLine(MaxSum(arr3, 2)); // 9  →  [4, 5]

        // k equals array length (entire array)
        int[] arr4 = { 4, 6, 2 };
        Console.WriteLine(MaxSum(arr4, 3)); // 12  →  [4, 6, 2]

        // Negative numbers
        int[] arr5 = { -3, 5, -2, 4, -1 };
        Console.WriteLine(MaxSum(arr5, 2)); // 3  →  [4,-1]=3 → 3

        //Reverse an Array In-Place
        //Two pointers moving inward, swapping as they go.
        //Classic pointer manipulation question.

        void Reverse(int[] arr)
        {
            for (int i = 0; i < arr.Length / 2; i++)
            {
                int temp = arr[i];
                arr[i] = arr[arr.Length - 1 - i];
                arr[arr.Length - 1 - i] = temp;
            }
        }
        // Basic case
        int[] arr6 = { 1, 2, 3, 4, 5 };
        Reverse(arr6);
        Console.WriteLine(string.Join(", ", arr6)); // 5, 4, 3, 2, 1

        // Even length
        int[] arr7 = { 1, 2, 3, 4 };
        Reverse(arr7);
        Console.WriteLine(string.Join(", ", arr7)); // 4, 3, 2, 1

        // Single element — no swaps, returns as-is
        int[] arr8 = { 42 };
        Reverse(arr8);
        Console.WriteLine(string.Join(", ", arr8)); // 42

        // Already reversed
        int[] arr9 = { 5, 4, 3, 2, 1 };
        Reverse(arr9);
        Console.WriteLine(string.Join(", ", arr9)); // 1, 2, 3, 4, 5

        #endregion Part 1 — Arrays & Strings

        #region Part 2 — Hash Maps(Dictionary<K, V>)

        //Frequency Counter — Anagram Check
        //Count character occurrences.
        //Core pattern for anagrams, duplicates, most frequent element.

        //Option A:
        //Time :O(nlogn)
        //Space:O(n)
        bool IsAnagramWithSort(string strA, string strB)
        {
            //Sort
            var arrA = strA.ToCharArray();
            Array.Sort(arrA);
            var sortedStrA = string.Join("", arrA);

            var arrB = strB.ToCharArray();
            Array.Sort(arrB);
            var sortedStrB = string.Join("", arrB);

            return sortedStrA == sortedStrB;
        }
        //Option B: with dictionary
        bool IsAnagram(string strA, string strB)
        {
            if (strA.Length != strB.Length)
                return false;

            var dicAChars = new Dictionary<char, int>();

            for (int i = 0; i < strA.Length; i++)
            {
                var charA = strA[i];
                if (!dicAChars.ContainsKey(charA))
                    dicAChars[charA] = 1;
                else
                    dicAChars[charA]++;
            }

            for (int i = 0; i < strB.Length; i++)
            {
                var charB = strB[i];

                if (dicAChars.ContainsKey(charB))
                {
                    dicAChars[charB]--;
                    if (dicAChars[charB] == 0)
                        dicAChars.Remove(charB);
                }
            }
            return dicAChars.Count == 0;
        }

        bool IsAnagramShorterVersion(string s, string t)
        {
            if (s.Length != t.Length) return false;

            var freq = new Dictionary<char, int>();
            foreach (var c in s)
                freq[c] = freq.GetValueOrDefault(c) + 1;

            foreach (var c in t)
            {
                if (!freq.ContainsKey(c) || freq[c] == 0)
                    return false;
                freq[c]--;
            }
            return true;
        }

        // Basic anagram
        Console.WriteLine(IsAnagram("anagram", "nagaram")); // True

        // Not an anagram
        Console.WriteLine(IsAnagram("rat", "car"));          // False

        // Different lengths — early exit
        Console.WriteLine(IsAnagram("hello", "hello!"));     // False

        // Same letters, different counts
        Console.WriteLine(IsAnagram("aab", "bbb"));          // False

        // Single character, matching
        Console.WriteLine(IsAnagram("a", "a"));              // True

        // Single character, not matching
        Console.WriteLine(IsAnagram("a", "b"));              // False


        //Group by Key — Group Anagrams
        //Sort each word → use as dictionary key.
        //All anagrams share the same sorted key.

        IList<IList<string>> GroupAnagrams(string[] words)
        {
            var wordGroups = new Dictionary<string, List<string>>(); //key=sorted word, value - list of words

            foreach (var word in words)
            {
                //Produce Key not using Linq
                var wordCharArr = word.ToCharArray();
                Array.Sort(wordCharArr);
                var sortedWord = string.Join("", wordCharArr);

                //Produce Key  using Linq
                //var sortedWord = new string(word.OrderBy(c => c).ToArray());

                if (wordGroups.ContainsKey(sortedWord))
                {
                    wordGroups[sortedWord].Add(word);
                }
                else
                {
                    wordGroups[sortedWord] = new List<string>() { word };
                }

            }

            var result = new List<IList<string>>();

            foreach (var group in wordGroups.Values)
                result.Add(group);

            return result;
        }

        // Basic case
        string[] words = { "eat", "tea", "tan", "ate", "nat", "bat" };
        var resultX1 = GroupAnagrams(words);
        foreach (var group in resultX1)
            Console.WriteLine($"[{string.Join(", ", group)}]");
        // [eat, tea, ate]
        // [tan, nat]
        // [bat]

        // All the same anagram
        string[] words2 = { "abc", "bca", "cab" };
        var resultX2 = GroupAnagrams(words2);
        foreach (var group in resultX2)
            Console.WriteLine($"[{string.Join(", ", group)}]");
        // [abc, bca, cab]

        // No anagrams — each word is its own group
        string[] words3 = { "dog", "cat", "bird" };
        var resultX3 = GroupAnagrams(words3);
        foreach (var group in resultX3)
            Console.WriteLine($"[{string.Join(", ", group)}]");
        // [dog]
        // [cat]
        // [bird]

        // Single word
        string[] words4 = { "hello" };
        var result4 = GroupAnagrams(words4);
        foreach (var group in result4)
            Console.WriteLine($"[{string.Join(", ", group)}]");
        // [hello]

        // Empty strings
        string[] words5 = { "", "" };
        var result5 = GroupAnagrams(words5);
        foreach (var group in result5)
            Console.WriteLine($"[{string.Join(", ", group)}]");
        // [, ]  → both empty strings group together

        #endregion Part 2 — Hash Maps(Dictionary<K, V>)

        #region Part 3 — Trees

        #region DFS Traversals(In / Pre / Post - order)
        List<int> InOrder(TreeNode? node, List<int>? result = null)
        {
            result ??= [];
            if (node == null) return result;
            InOrder(node.Left, result);
            result.Add(node.Val);
            InOrder(node.Right, result);
            return result;
        }

        List<int> PreOrder(TreeNode? node, List<int>? result = null)
        {
            result ??= [];
            if (node == null)
                return result;
            result.Add(node.Val);
            PreOrder(node.Left, result);
            PreOrder(node.Right, result);
            return result;
        }

        List<int> PostOrder(TreeNode? node, List<int>? result = null)
        {
            result ??= [];
            if (node == null)
                return result;
            PostOrder(node.Left, result);
            PostOrder(node.Right, result);
            result.Add(node.Val);
            return result;
        }

        //       4
        //      / \
        //     2   6
        //    / \ / \
        //   1  3 5  7

        var root = new TreeNode(4)
        {
            Left = new TreeNode(2)
            {
                Left = new TreeNode(1),
                Right = new TreeNode(3)
            },
            Right = new TreeNode(6)
            {
                Left = new TreeNode(5),
                Right = new TreeNode(7)
            }
        };

        // In-order (Left → Visit → Right) → always sorted for a BST
        var inOrder = InOrder(root);
        Console.WriteLine(string.Join(", ", inOrder)); // 1, 2, 3, 4, 5, 6, 7

        // Pre-order (Visit → Left → Right) → root always comes first
        var preOrder = PreOrder(root);
        Console.WriteLine(string.Join(", ", preOrder)); // 4, 2, 1, 3, 6, 5, 7

        // Post-order (Left → Right → Visit) → root always comes last
        var postOrder = PostOrder(root);
        Console.WriteLine(string.Join(", ", postOrder)); // 1, 3, 2, 5, 7, 6, 4

        // Single node
        var single = new TreeNode(42);
        Console.WriteLine(string.Join(", ", InOrder(single))); // 42

        // Null root
        Console.WriteLine(string.Join(", ", InOrder(null))); // (empty)

        #endregion DFS Traversals(In / Pre / Post - order)

        #region BFS — Level - Order Traversal
        //Use a Queue. Process level by level. Great for shortest - path and level - based questions.
        // Full tree — level by level

        List<int> Bfs(TreeNode root)
        {
            var result = new List<int>();

            var queue = new Queue<TreeNode>();

            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                result.Add(node.Val);

                if (node.Left != null)
                    queue.Enqueue(node.Left);

                if (node.Right != null)
                    queue.Enqueue(node.Right);
            }

            return result;
        }

        var result6 = Bfs(root);
        Console.WriteLine(string.Join(", ", result6)); // 4, 2, 6, 1, 3, 5, 7

        // Single node
        var single1 = new TreeNode(42);
        Console.WriteLine(string.Join(", ", Bfs(single1))); // 42

        // Only left children (skewed tree)
        //   1
        //  /
        // 2
        //  /
        // 3
        var skewed = new TreeNode(1) { Left = new TreeNode(2) { Left = new TreeNode(3) } };
        Console.WriteLine(string.Join(", ", Bfs(skewed))); // 1, 2, 3

        #endregion BFS — Level - Order Traversal

        //Max Depth
        //Appears as a sub - problem in half of tree questions. Know it cold.

        int MaxDepth(TreeNode? node)
        {
            if (node == null)
                return 0;

            var leftDepth = MaxDepth(node.Left);
            var rightDepth = MaxDepth(node.Right);

            if (leftDepth >= rightDepth)
                return leftDepth + 1;
            else
                return rightDepth + 1;
        }

        // Balanced tree — depth 3
        Console.WriteLine(MaxDepth(root)); // 3

        // Single node — depth 1
        var single2 = new TreeNode(42);
        Console.WriteLine(MaxDepth(single2)); // 1

        // Null — depth 0
        Console.WriteLine(MaxDepth(null)); // 0

        // Skewed left — depth 4
        //   1
        //  /
        // 2
        //  /
        // 3
        //  /
        // 4
        var skewed1 = new TreeNode(1)
        {
            Left = new TreeNode(2)
            {
                Left = new TreeNode(3)
                {
                    Left = new TreeNode(4)
                }
            }
        };
        Console.WriteLine(MaxDepth(skewed1)); // 4

        // Unbalanced — depth determined by longer branch
        //     1
        //    / \
        //   2   3
        //  /
        // 4
        var unbalanced = new TreeNode(1)
        {
            Left = new TreeNode(2) { Left = new TreeNode(4) },
            Right = new TreeNode(3)
        };
        Console.WriteLine(MaxDepth(unbalanced)); // 3


        //Validate BST
        //Pass min/ max bounds down recursively.Common mistake: only checking parent, not full range.

        // Validates BST by passing down an allowed (min, max) range for each node.
        // Every node must satisfy: min < node.Val < max
        // As we go LEFT  → the current value becomes the new MAX (left must be smaller)
        // As we go RIGHT → the current value becomes the new MIN (right must be larger)
        //
        // Dry run on:
        //       5
        //      / \
        //     4   6
        //        / \
        //       3   7  ← 3 violates the inherited min of 5
        //
        // IsValidBST(5, min=long.Min, max=long.Max)  → 5 in range ✓
        //   IsValidBST(4, min=long.Min, max=5)        → 4 in range ✓
        //     IsValidBST(null) → true
        //     IsValidBST(null) → true
        //   IsValidBST(6, min=5, max=long.Max)        → 6 in range ✓
        //     IsValidBST(3, min=5, max=6)             → 3 <= min(5) ✗ → false!
        //     (short-circuits, never checks 7)
        bool IsValidBST(TreeNode? node, long min = long.MinValue, long max = long.MaxValue)
        {
            if (node == null) return true;

            // Current value must stay strictly within the inherited bounds
            if (node.Val <= min || node.Val >= max)
                return false;

            return
                // Left subtree: inherit the same min, current value is the new max
                IsValidBST(node.Left, min, node.Val)
                // Right subtree: current value is the new min, inherit the same max
                && IsValidBST(node.Right, node.Val, max);
        }

        //       4
        //      / \
        //     2   6
        //    / \ / \
        //   1  3 5  7

        var validBST = new TreeNode(4)
        {
            Left = new TreeNode(2)
            {
                Left = new TreeNode(1),
                Right = new TreeNode(3)
            },
            Right = new TreeNode(6)
            {
                Left = new TreeNode(5),
                Right = new TreeNode(7)
            }
        };
        // Valid BST
        Console.WriteLine(IsValidBST(validBST)); // True

        // Invalid — right child smaller than root
        //     4
        //    / \
        //   2   3  ← 3 is less than 4, invalid
        var invalid1 = new TreeNode(4)
        {
            Left = new TreeNode(2),
            Right = new TreeNode(3)
        };
        Console.WriteLine(IsValidBST(invalid1)); // False

        // Tricky case — locally valid but globally invalid
        //       5
        //      / \
        //     4   6
        //        / \
        //       3   7  ← 3 is less than 5 (the ancestor), invalid
        var invalid2 = new TreeNode(5)
        {
            Left = new TreeNode(4),
            Right = new TreeNode(6)
            {
                Left = new TreeNode(3),
                Right = new TreeNode(7)
            }
        };
        Console.WriteLine(IsValidBST(invalid2)); // False

        // Single node — always valid
        Console.WriteLine(IsValidBST(new TreeNode(42))); // True

        // Null — always valid
        Console.WriteLine(IsValidBST(null)); // True
        #endregion Part 3 — Trees

        #region Part 4 — Linked Lists

        //Detect a Cycle(Floyd's Algorithm)
        //Slow pointer moves 1 step, fast moves 2.If they meet → cycle exists.

        // Helper to create a cycle: links the tail back to the node at cycleIndex
        ListNode CreateCycle(int[] values, int cycleIndex)
        {
            var nodes = values.Select(v => new ListNode(v)).ToArray();
            for (int i = 0; i < nodes.Length - 1; i++)
                nodes[i].Next = nodes[i + 1];
            if (cycleIndex >= 0)
                nodes[nodes.Length - 1].Next = nodes[cycleIndex]; // tail points back into the list
            return nodes[0];
        }

        bool HasCycle(ListNode? node)
        {
            if (node == null)
                return false;

            ListNode? slow = node;
            ListNode? fast = node.Next;

            while (slow != null && fast != null)
            {
                if (slow == fast)
                    return true;

                slow = slow.Next;
                fast = fast.Next?.Next;
            }

            return false;
        }

        // No cycle — straight list: 1 → 2 → 3 → 4 → null
        var noCycle = CreateCycle(new[] { 1, 2, 3, 4 }, cycleIndex: -1);
        Console.WriteLine(HasCycle(noCycle)); // False

        // Cycle at start: tail links back to head
        // 1 → 2 → 3 → 4 ↗ (back to 1)
        var cycleAtStart = CreateCycle(new[] { 1, 2, 3, 4 }, cycleIndex: 0);
        Console.WriteLine(HasCycle(cycleAtStart)); // True

        // Cycle in middle: tail links back to index 1
        // 1 → 2 → 3 → 4 ↗ (back to 2)
        var cycleInMiddle = CreateCycle(new[] { 1, 2, 3, 4 }, cycleIndex: 1);
        Console.WriteLine(HasCycle(cycleInMiddle)); // True

        // Single node, no cycle
        var single3 = new ListNode(1);
        Console.WriteLine(HasCycle(single3)); // False

        // Single node pointing to itself
        var selfLoop = new ListNode(1);
        selfLoop.Next = selfLoop;
        Console.WriteLine(HasCycle(selfLoop)); // True

        // Null head
        Console.WriteLine(HasCycle(null)); // False

        //Reverse a Linked List
        //Three variables: prev, curr, next.
        //Iterative is preferred over recursive in interviews.
        string PrintList(ListNode? head)
        {
            if (head == null)
                return string.Empty;

            var result = new List<string>();

            while (head != null)
            {
                result.Add(head.Val.ToString());

                head = head.Next;
            }
            return string.Join(" → ", result);
        }

        ListNode? ReverseListIterative(ListNode? head)
        {
            ListNode? prev = null;
            ListNode? curr = head;
            ListNode? next = null;

            while (curr != null)
            {
                next = curr.Next;
                curr.Next = prev;
                prev = curr;
                curr = next;
            }
            return prev; // new head
        }

        // Basic case: 1 → 2 → 3 → 4 → 5
        var head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));

        head = ReverseListIterative(head);
        Console.WriteLine(PrintList(head)); // 5 → 4 → 3 → 2 → 1

        // Two nodes: 1 → 2
        var two = new ListNode(1, new ListNode(2));
        Console.WriteLine(PrintList(ReverseListIterative(two))); // 2 → 1

        // Single node — returns as-is
        var single4 = new ListNode(42);
        Console.WriteLine(PrintList(ReverseListIterative(single4))); // 42

        // Null — returns null
        Console.WriteLine(PrintList(ReverseListIterative(null))); // (empty)
        #endregion Part 4 — Linked Lists

        #region Part 5 — Stacks & Queues

        //Valid Parentheses
        //Appears in almost every company.
        //Push opens, pop and check on close.

        bool IsValid(string expression)
        {
            if (string.IsNullOrEmpty(expression))
                return true;

            var stack = new Stack<char>();

            foreach (char c in expression)
            {
                if (c == '(' || c == '[' || c == '{')
                {
                    stack.Push(c);
                }
                else if (c == ')' || c == ']' || c == '}')
                {
                    if (stack.Count == 0)
                        return false;

                    char popped = stack.Pop();
                    if ((c == ')' && popped != '(') ||
                        (c == ']' && popped != '[') ||
                        (c == '}' && popped != '{'))
                    {
                        return false;
                    }
                }
            }
            return stack.Count == 0;
        }

        // Valid — simple pairs
        Console.WriteLine(IsValid("()"));       // True
        Console.WriteLine(IsValid("[]"));       // True
        Console.WriteLine(IsValid("{}"));       // True

        // Valid — nested
        Console.WriteLine(IsValid("()[]{}"));   // True
        Console.WriteLine(IsValid("{[()]}"));   // True

        // Invalid — wrong closing order
        Console.WriteLine(IsValid("(]"));       // False
        Console.WriteLine(IsValid("([)]"));     // False

        // Invalid — unclosed bracket
        Console.WriteLine(IsValid("("));        // False
        Console.WriteLine(IsValid("([]"));      // False

        // Invalid — closing with empty stack
        Console.WriteLine(IsValid(")"));        // False
        Console.WriteLine(IsValid("}{"));       // False

        // Empty string — valid (nothing to mismatch)
        Console.WriteLine(IsValid(""));         // True

        //Min Stack — GetMin in O(1)
        //Maintain a parallel minStack that tracks the running minimum at every level.

        #endregion Part 5 — Stacks & Queues
    }
}
