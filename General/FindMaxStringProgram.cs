using System;
using System.Collections.Generic;
using System.Linq;

namespace General
{
    //ctrl + k + f // to indent
    
    internal class FindMaxStringProgram
    {
        public static int without_repeated_chars_longest_substring(string str1)
        {
            if (string.IsNullOrEmpty(str1)) 
                return 0;

            var map_str = new Dictionary<char,int>();
      
            var max_len = 0;
        
            var last_repeat_pos = -1;
         
            for (int i = 0; i < str1.Length; i++)
            {
                if (map_str.ContainsKey(str1[i]) && last_repeat_pos < map_str[str1[i]])
                    last_repeat_pos = map_str[str1[i]];
               
                if (max_len < i - last_repeat_pos)
                    max_len = i - last_repeat_pos;
                
                map_str[str1[i]] = i;
            }
          
            return max_len;
        }

        public static int my_without_repeated_chars_longest_substring(string str1)
        {
            if (string.IsNullOrEmpty(str1))
                return 0;

            var map_str = new Dictionary<char, int>();

            var max_len = 0;

            var subFirstIndex = -1;

            for (int index = 0; index < str1.Length; index++)
            {
                var key = str1[index]; // the char

                if (map_str.ContainsKey(key))
                {
                    var charLatetsIndex = map_str[key]; // the char index latest index.  if it's repeated the latest repeat index that could mark a new substring

                    if (subFirstIndex < charLatetsIndex)
                    {
                        subFirstIndex = charLatetsIndex;
                    }
                }
                if (max_len < index - subFirstIndex)
                    max_len = index - subFirstIndex;

                map_str[key] = index; //in any case keep the char latest index
            }

            return max_len;
        }

        static int FindMaxSubStringLength(string input)
        {
            int maxLength = 0;

            for (int i = 0; i < (input.Length - 1); i++)
            {
                List<char> distinctList = new List<char>();

                int counter = 0;

                for (int j = i; j < input.Length; j++)
                {
                    if (!distinctList.Contains(input[j]))
                    {
                        counter++;
                      
                        distinctList.Add(input[j]);
                       
                        if (counter > maxLength)
                        {
                            maxLength = counter;
                        }
                    }
                    else
                    {
                        if (counter > maxLength)
                        {
                            maxLength = counter;
                        }
                        break;
                    }
                }
            }

            return maxLength;
        }

        static int ChatFindMaxSubStringLength(string input)
        {
            if (string.IsNullOrEmpty(input)) return 0;

            HashSet<char> set = new HashSet<char>();
            int maxLength = 0, left = 0;

            for (int right = 0; right < input.Length; right++)
            {
                // If duplicate found, remove characters from the left
                while (set.Contains(input[right]))
                {
                    set.Remove(input[left]);
                    left++;
                }

                // Add the current character and update max length
                set.Add(input[right]);
                maxLength = Math.Max(maxLength, right - left + 1);
            }

            return maxLength;
        }
        /*
        static void Main(string[] args)
        {
            int ress = without_repeated_chars_longest_substring("abcabbd");// pickoutthelongestsubstring");
            int myRes = my_without_repeated_chars_longest_substring("pickoutthelongestsubstring");
            int res5 = FindMaxSubStringLength("pwwkew");//3 pickoutthelongestsubstring");// 8
            int res0 = FindMaxSubStringLength("abc");// 3
            int res1 = FindMaxSubStringLength("abcabcbb"); //3
            int res2 = FindMaxSubStringLength("bbbbb");//1
            int res3 = FindMaxSubStringLength("pwwkew");//3
            int res4 = FindMaxSubStringLength("abcad");//4

            int res55 = ChatFindMaxSubStringLength("pwwkew");//3 pickoutthelongestsubstring");// 8
            int res00 = ChatFindMaxSubStringLength("abc");// 3
            int res11 = ChatFindMaxSubStringLength("abcabcbb"); //3
            int res22 = ChatFindMaxSubStringLength("bbbbb");//1
            int res33 = ChatFindMaxSubStringLength("pwwkew");//3
            int res44 = ChatFindMaxSubStringLength("abcad");//4
        }
        */
    }
}
