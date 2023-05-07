using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftQuestions
{
    internal class Strings
    {
        private static void Main(string[] args)
        {
            var reversed = ReverseString("ABCED");

            reversed = ReverseStringRecurssion("ABCDE");

            List<string> list = new List<string> { "My", "Name", "is", "Gil" };

            List<string> reversedList = ReverseListOfStrings(list);

            string input = "abc";
            List<string> permutations = FindPermutations(input);
            Console.WriteLine("Permutations of the string \"" + input + "\":");
            foreach (string permutation in permutations)
            {
                Console.WriteLine(permutation);
            }
        }

        public static List<string> ReverseListOfStrings(List<string> list)
        {
            List<string> reversedList = new List<string>();

            foreach (var item in list)
            {
                reversedList.Insert(0, item);
            }

            return reversedList;
        }
        public static string ReverseString(string str)
        {
            var reversedString = string.Join("", str.ToCharArray().Reverse());
            return reversedString;
        }

        public static string ReverseStringRecurssion(string str)
        {
            if (str.Length == 1)
                return str;

            return ReverseStringRecurssion(str.Substring(1)) + str[0];
        }

        static List<string> FindPermutations(string input)
        {
            List<string> permutations = new List<string>();
            FindPermutationsHelper(input.ToCharArray(), 0, permutations);
            return permutations;
        }

        static void FindPermutationsHelper(char[] inputArray, int index, List<string> permutations)//recurrsive method!
        {
            if (index == inputArray.Length - 1) //תנאי עצירה הגענו לתו האחרון
            {
                permutations.Add(new string(inputArray)); //convert the charArray to string!
            }
            else
            {
                for (int i = index; i < inputArray.Length; i++)
                {
                    Swap(inputArray, index, i);
                    FindPermutationsHelper(inputArray, index + 1, permutations);
                    Swap(inputArray, index, i); // backtrack
                }
            }
        }

        static void Swap(char[] array, int i, int j)
        {
            char temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }

}

