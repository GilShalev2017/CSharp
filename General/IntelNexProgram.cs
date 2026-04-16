using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace General
{
    //ctrl + k + f // to indent
    
    internal class IntelNexProgram
    {
        static int FindMaxSubArray(int[] array)
        {
            int maxSum = int.MinValue;
          
            int currentSum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                currentSum += array[i];

                if (currentSum < 0)
                {
                    currentSum = 0;
                }

                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                }
            }

            return maxSum;
        }
        /*
        static void Main(string[] args)
        {
            int[] array = new int[] { 1, 3, -5, 20, -40, 100, 5, 8, 10, -2, 12 };

            Console.WriteLine("max sum is = " + FindMaxSubArray(array));

        }
        */
    }
    
}
