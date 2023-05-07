using System;
using System.Collections.Generic;
using System.Linq;


namespace General
{
    //ctrl + k + f // to indent
    internal class MilleniumProgram
    {
        //Pay attnetion:
        //1 easier working with a List which has IEnumerable!
        //2 byte != char !!! Convert.ToChar() / Convert.ToByte()

        static IEnumerable<byte> Encode(IEnumerable<byte> original)
        {
            List<byte> output = new List<byte>();
            byte prev = byte.MaxValue;
            int count = 0;

            foreach (byte b in original)
            {
                if(b != prev || count == 255) //if we reached 255 which is the max counter
                                              // we need to write it
                {
                    //if a new char has arrived
                    if(count > 0)
                    {
                        output.Add((byte)count);
                        output.Add(prev);
                        count = 0;
                    }
                }
                prev = b;
                count++;
            }

            if(count > 0) //addressing the last charcter!
            {
                output.Add((byte)count);
                output.Add(prev);
            }
            return output.ToArray();
        }

        static IEnumerable<byte> MyEncode(IEnumerable<byte> original)
        {
            if (original == null)
                return null;
            

            //Counter+Letter
            byte counter = 0;
            byte curChar = 0;
            byte nextChar = 0;

            List<byte> listOriginal = original.ToList();
            List<byte> listResult = new List<byte>();

            for(int i=0; i< listOriginal.Count()-1; i++)
            {
                curChar = listOriginal[i];
                nextChar = listOriginal[i + 1];
                counter++;

                if (curChar != nextChar)
                {
                    listResult.Add(counter);
                    listResult.Add(curChar);
                    counter = 0;
                }
            }

            if(curChar != nextChar)
            {
                listResult.Add(1);
                listResult.Add(nextChar);
            }
            else
            {
                listResult[listResult.Count() - 2]++;
            }

            return listResult;
        }

        static int Fib(int elementNumber)
        {
            if (elementNumber == 1 || elementNumber == 2)
            {
                return 1;
            }

            return Fib(elementNumber - 2) + Fib(elementNumber - 1);

        }

        static int IterativeFib(int elementNumber)
        {
            if (elementNumber == 1 || elementNumber == 2)
            {
                if (elementNumber == 1)
                    Console.WriteLine("1");
                else
                    Console.WriteLine("1 1");

                return 1;
            }

            var prev = 1;
            var current = 1;
            var ez = -1;
            for (int i=2; i< elementNumber; i++)
            {
                ez = current;
                current = current + prev;
                Console.WriteLine(current);
                prev = ez;
            }

            return current;
        }

        static int FindMaxSubarraySum(int [] numbers)
        {
            int curSum = 0;
            int maxSum = int.MinValue;

            for(int i=0; i< numbers.Length; i++)
            {
                curSum += numbers[i];

                if(curSum > maxSum)
                {
                    maxSum = curSum;
                }

                if(curSum < 0)
                {
                    curSum = 0;  
                }
            }

            return maxSum;
        }
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Fib of 7 =" + Fib(7).ToString());

        //    Console.WriteLine("Fib of 1 =" + IterativeFib(1).ToString());
        //    Console.WriteLine("Fib of 2 =" + IterativeFib(2).ToString());
        //    Console.WriteLine("Fib of 3 =" + IterativeFib(3).ToString());
        //    Console.WriteLine("Fib of 7 =" + IterativeFib(7).ToString());

        //    int[] numbers = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };

        //    int maxSum = FindMaxSubarraySum(numbers);

        //    Console.WriteLine("The maximum sum of a contiguous subarray is {0}", maxSum);


        //    //byte[] original = new byte[10];//"FrootLoops";
        //    byte[] original = new byte[11];//"FrootLoopss";

        //    int index = 0;
        //    //foreach (var charX in "FrootLoops")
        //    foreach (var charX in "FrootLoopss")
        //    {
        //        original[index] = Convert.ToByte(charX);
        //        index++;
        //    }
        //    var res = MyEncode(original);

        //    char[] result = new char[res.Count()];
        //    index = 0;
        //    foreach (var byteX in res)
        //    {
        //        result[index] = Convert.ToChar(byteX);
        //        index++;
        //    }

        //    Console.WriteLine(string.Join("", result));
        //}
    }
}

