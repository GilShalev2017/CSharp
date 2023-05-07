using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListAndTrees
{
    class Program
    {
        /*
        static void Main()
        {
            List<string> strings = new List<string> { "abc", "ab", "abcd", "de", "def" };
            bool isGoodSet = IsGoodSet(strings);
            if (isGoodSet)
            {
                Console.WriteLine("GOOD SET");
            }
            else
            {
                Console.WriteLine("BAD SET");
                string prefix = GetPrefix(strings);
                Console.WriteLine(prefix);
            }
        }*/

        static bool IsGoodSet(List<string> strings)
        {
            TrieNode root = new TrieNode();
            foreach (string str in strings)
            {
                if (!Insert(root, str))
                {
                    return false; // If inserting a string fails, it means it is a prefix of another string
                }
            }
            return true;
        }

        static bool Insert(TrieNode root, string str)
        {
            TrieNode current = root;
            bool isNewPrefix = false;
            for (int i = 0; i < str.Length; i++)
            {
                int index = str[i] - 'a';
                if (current.Children[index] == null)
                {
                    current.Children[index] = new TrieNode();
                    isNewPrefix = true;
                }
                else if (current.Children[index].IsEndOfWord)
                {
                    return false; // If the current node is the end of another word, then str is a prefix of another string
                }
                current = current.Children[index];
            }
            current.IsEndOfWord = true;
            return isNewPrefix;
        }

        static string GetPrefix(List<string> strings)
        {
            TrieNode root = new TrieNode();
            foreach (string str in strings)
            {
                if (!Insert(root, str))
                {
                    return str; // If inserting a string fails, it means it is a prefix of another string
                }
            }
            return string.Empty;
        }
    }

    class TrieNode
    {
        public TrieNode[] Children { get; } = new TrieNode[10]; // Since strings only contain lowercase letters from a-j, there are 10 possible characters
        public bool IsEndOfWord { get; set; }
    }

}
