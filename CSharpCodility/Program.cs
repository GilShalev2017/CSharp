using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CSharpCodility
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            /*
            int[] testArray0 = new int[] { 1, 3, 6 }; // use case at the beginning retursn 2
            int res = solution(testArray0);

            int[] testArray1 = new int[] { 1, 3, 6, 4, 1, 2 };
            int res2 = solution(testArray1);

            int[] testArray2 = new int[] { -1, -3 }; //use case of only negatives - returns 1
            int res3 = solution(testArray2);

            int[] testArray3 = new int[] { 1, 3, 2 }; //use case at the end returns 4
            int res4 = solution(testArray3);
            */

            /*
            int res1 = solutionBinaryGap(9);
            int res2 = solutionBinaryGap(529);
            int res3 = solutionBinaryGap(20);
            int res4 = solutionBinaryGap(15);
            int res5 = solutionBinaryGap(32);
            int res6 = solutionBinaryGap(1041);
            int res7 = solutionBinaryGap(1);
            int res8 = solutionBinaryGap(0);
            int res9 = solutionBinaryGap(328);
            int res10 = solutionBinaryGap(2147483647);

            int res11 = solutionBinaryGap(1162);
            int res12 = solutionBinaryGap(51712);
            int res13 = solutionBinaryGap(66561);
            int res14 = solutionBinaryGap(6291457);
            int res15 = solutionBinaryGap(805306373);
            int res16 = solutionBinaryGap(1610612737);
            */
            /*
            int[] arr1 = { 3, 8, 9, 7, 6 };
            int [] result = solutionRotationOfAnArray(arr1, 3);

            int[] arr2 = { 0, 0, 0 };
            int[] result2 = solutionRotationOfAnArray(arr2, 1);

            int[] arr3 = { 1, 2, 3, 4 };
            int[] result3 = solutionRotationOfAnArray(arr3, 4);

            int[] arr4 = { 7,8,9,-100 };
            int[] result4 = solutionRotationOfAnArray(arr4, 0);

            int[] arr5 = { 1 };
            int[] result5 = solutionRotationOfAnArray(arr5, 6);

            int[] arr6 = {  };
            int[] result6 = solutionRotationOfAnArray(arr6, 6);
            */
            /*
            int [] arr123 = {9,3,9,3,9,7,9,201,7,9,9,9,7,7,9,9 };
            int result123 = solutionOddNumbersOfElements(arr123);
            int result124 = solutionOddNumbersOfElements2(arr123);

            int[] arr124 = { 9 };
            int result125 = solutionOddNumbersOfElements(arr124);
            */

            /*
            int frogJumps = solutionFrogJump(10, 85, 30);

            int frogJumps2 = solutionFrogJump(1, 1, 1);

            int frogJumps3 = solutionFrogJump(2, 10, 1);

            int frogJumps4 = solutionFrogJump(2, 10, 1);

            int frogJumps5 = solutionFrogJump(3, 999111321, 7);
            */
            /*
            int[] missingArr = { 2, 1, 4 };
            int missingElement = solutionFindMissing(missingArr);

            int[] missingArr1 = { 1, 4,3 };
            int missingElement1 = solutionFindMissing(missingArr1);

            int[] emptyList = { };
            int missingemptyList = solutionFindMissing(emptyList); //use case: empty list

            int[] singleVar = { 2 };
            int missingVar = solutionFindMissing(singleVar); //use case: single var

            int[] Only2Vars = { 2, 4 };
            int mssingIn2Vars = solutionFindMissing(Only2Vars); //use case: single var
            */
            /*
            int[] arrParts = { 3,1,2,4,3};
            int minDiff = solutionFindParts(arrParts);

            int[] arrParts2 = { -3, 1, 2, -4, 1 };
            int minDiff2 = solutionFindParts(arrParts2);

            int[] arrEmptyArr = {  };
            int minDiff3 = solutionFindParts(arrEmptyArr);

            int[] arrSingleElm = { 2,-2 };
            int minDiff4 = solutionFindParts(arrSingleElm);

            int[] arr2Elms = { 2000, 4000 };
            int minDiff5 = solutionFindParts(arr2Elms);
            */

            /*
            int[] frogLeavesArr = { 1,3,1,4,2,3,5,4 };
            int res = solutionFrogRiverOne(5, frogLeavesArr);

            int[] frogLeavesEmptpyArr = { };
            int res2 = solutionFrogRiverOne(5, frogLeavesEmptpyArr);

            int[] frogLeavesSingle = { 6 };
            int res3 = solutionFrogRiverOne(5, frogLeavesEmptpyArr);

            int[] frogLeaves1 = { 1 };
            int res4 = solutionFrogRiverOne(1, frogLeaves1);
            */
            /*
            int[] permArr = { 4,1,3,2};
            int resPerm = solutionPermCheck(permArr);

            int[] permArr2 = { 4, 1, 3};
            int resPerm2 = solutionPermCheck(permArr2);

            int[] permArr3SingleElm = { 1 };
            int resPerm3 = solutionPermCheck(permArr3SingleElm);

            int[] permArr4SingleElm = { 2 };
            int resPerm4 = solutionPermCheck(permArr4SingleElm);

            int[] permArr5Same = { 3,3,3,3 };
            int resPerm5 = solutionPermCheck(permArr5Same);

            int[] permArrStrange = { 1, 2, 3, 3 };
            int resPerm6 = solutionPermCheck(permArrStrange);
            */
            /*
            int [] cars = { 0,1,0,1,1 };
            int carsPairs = solutionCars(cars);

            int[] cars1 = { 0, 0, 0, 0, 0 };
            int carsPairs1 = solutionCars(cars1);

            int[] cars2 = { 1 };
            int carsPairs2 = solutionCars(cars1);

            int[] cars3 = { 1,1,1,1,0 };
            int carsPairs3 = solutionCars(cars3);

            int[] cars4 = { 1, 1, 1, 1, 0 };
            int carsPairs4 = solutionCars(cars4);

            int[] cars5 = { 0,1, 1, 1, 1 };
            int carsPairs5 = solutionCars(cars5);
            */

            int[] demoArr1 = { 1, 3, 6, 4, 1, 2 };
            int res1 = solutionDemo(demoArr1);

            int[] demoArr2 = { 1, 2, 3 };
            int res2 = solutionDemo(demoArr2);

            int[] demoArr3 = { -1, -3 };
            int res3 = solutionDemo(demoArr3);

            int[] demoArr4= { -1 };
            int res4 = solutionDemo(demoArr4);

            int[] demoArr5 = { 0 };
            int res5 = solutionDemo(demoArr5);

            int[] demoArr6 = { 1 };
            int res6 = solutionDemo(demoArr6);
        }
        public static int solutionDemo(int[] A)
        {
            List<int> list = A.ToList<int>();
            list.Sort(); //sor in ascd order

            int lastElement = list[list.Count - 1];

            if (lastElement <= 0) //for a total negative array
                return 1;

            int prev = list[0];
            int current = 0;

            for (int i=0; i<list.Count; i++)
            {
                current = list[i];

                if (current < 0)
                    continue;

                if ((current - prev) > 1)
                {
                    return prev + 1;
                }

                prev = current;
            }

            return current + 1;
        }
        
        public static int solutionCars(int[] A)
        {

            List<int> east = new List<int>();
            List<int> west = new List<int>();
            int numOfPairs = 0;

            for (int j = 0; j<A.Length; j++)
            {
                if (A[j] == 0)
                {
                    east.Add(j);
                }
                else
                {
                    west.Add(j);
                }
            }

            int eastCounter = east.Count;
            int westCounter = west.Count;

            if (eastCounter == 0 || westCounter == 0)
                return -1;

            for (int i = 0; i < east.Count; i++)
            {
                int index = west.FindIndex(0, x => x > east[i]);

                if(index == -1)
                {
                    continue;
                }
                int countLeft = westCounter - index;

                numOfPairs += countLeft;
            }

            if (numOfPairs > 1000000000)
                return -1;

            return numOfPairs;
        }

        public static int solutionPermCheck(int[] A)
        {
            double pairs = A.Length/2.0;
            int Min = 1;
            int Max = A.Length;
            double expectedSum = pairs * (Min+Max);
            int actualSum = 0;
            foreach(int elm in A)
            {
                actualSum += elm;
            }

            if (actualSum == expectedSum)
                return 1;

            return 0;
        }

        public static int solutionFrogRiverOne(int X, int[] A)
        {
            if (A.Length == 0)
                return -1;

            if (X == A[0])
                return 0;

            Dictionary<int, int> dic = new Dictionary<int, int>();

            for(int i=1; i<=X; i++)
            {
                dic.Add(i,1);
            }

            for(int i=0; i<A.Length; i++)
            {
                if(dic.ContainsKey(A[i]))
                {
                    dic.Remove(A[i]);
                }

                if(dic.Count() == 0)
                {
                    return i;
                }
            }

            return -1;
        }

        public static int solutionFindParts(int[] A)
        {
            int sumLeft = 0;
            int sumRight = 0;
            int minDiff = 0;
            bool isFirstDiff = true;
            int arrSum = 0;

            foreach(int elm in A)
            {
                arrSum += elm;
            }

            sumLeft = 0;

            for (int idx = 0; idx < A.Length; idx++)
            {
                sumLeft += A[idx];

                sumRight = arrSum - sumLeft;

                int diff = Math.Abs(sumLeft - sumRight);

                if (isFirstDiff)
                {
                    minDiff = diff;
                    isFirstDiff = false;
                    continue;
                }

                if (diff < minDiff)
                {
                    minDiff = diff;
                }
            }

            return minDiff;
            //for (int pivot = 1; pivot < A.Length; pivot++)
            //{ 
            //    for (int i = 0; i < pivot; i++)
            //    {
            //        sumLeft += A[i];
            //    }

            //    for (int i = pivot; i < A.Length; i++)
            //    {
            //        sumRight += A[i];
            //    }

            //    int diff = Math.Abs(sumLeft - sumRight);

            //    if(isFirstDiff)
            //    {
            //        minDiff = diff;
            //        isFirstDiff = false;
            //        sumLeft = sumRight = 0;
            //        continue;
            //    }
            //    if (diff < minDiff)
            //    {
            //        minDiff = diff;
            //    }
            //}
            //return minDiff;
        }
        
        public static int solutionFindMissing(int[] A)
        {
            /*
            int l = A.Length + 1;
            int expectedSum = (int)Math.Ceiling(l / 2.0) * (l + (l + 1) % 2),
            sum = 0;
            for (int i = -1; ++i < A.Length;)
                sum += A[i];
            return expectedSum - sum;
            */

            
            if (A.Length == 0)
                return 0;

            Array.Sort(A);
            var min = A[0];
            var max = A[A.Length-1];
            double pairs = (double)(max / 2.0);
            double expctedSum = pairs * (min + max);

            double actualSum = 0;

            foreach(var element in A)
            {
                actualSum += element;
            }

            return (int)(expctedSum - actualSum);
          
        }
        public static int solutionFrogJump(int X, int Y, int D)
        {
            //return (int)Math.Ceiling(((double)Y - X) / D);

            //for(int i=0; i<=Y/D; i+=D)
            int target = Y;
            int distance = X;
            int jumps = 0;

            while(distance< target)
            {
                distance += D;
                jumps++;
                if (distance >= target)
                    return jumps;
            }

            return 0;
        }
        public static int solutionOddNumbersOfElements2(int[] A)
        {
            Array.Sort(A);

            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] == A[i + 1])
                    continue;
                else
                    return A[i+1];
            }

            return -1;
        }
        public static int solutionOddNumbersOfElements(int[] A)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();

            for (int i=0; i<A.Length; i++)
            {
                if (dic.ContainsKey(A[i]))
                {
                    dic[A[i]]++;
                }
                else
                {
                    dic.Add(A[i], 1);
                }
            }

            foreach(var key in dic.Keys)
            {
                if(dic[key]==1)
                {
                    return key;
                }
            }

            return -1;
        }

        public static int[] solutionRotationOfAnArray(int[] arr, int K)
        {
            if (arr.Length == 0)
                return arr;

            LinkedList<int> ll = new LinkedList<int>(arr);

            for(int i=0; i<K; i++)
            {
                LinkedListNode<int> last = ll.Last;
                ll.RemoveLast();
                ll.AddFirst(last);
            }

            return ll.ToArray();
        }
        public static int solutionBinaryGap(int N)
        {
            String numAsString = Convert.ToString(Convert.ToInt32(N.ToString(), 10), 2);
         
            int counter = 0;
            int currentSegLength = 0;
            bool startSeg = false;

            // write your code in C# 6.0 with .NET 4.5 (Mono)
            for (int i=0; i< numAsString.Length; i++)
            {
                if(numAsString[i] == '1' && !startSeg)
                {
                    startSeg = true;
                }
                else if(numAsString[i] == '0' && startSeg)
                {
                    counter++;
                }
                else if(numAsString[i] == '1' && startSeg)
                {
                    if(currentSegLength < counter)
                    {
                        currentSegLength = counter;
                    }
                    counter = 0;
                }
            }

            return currentSegLength;
        }

        public static int solution(int[] arr)
        {
            Array.Sort(arr, 0, arr.Length);

            if (arr[arr.Length - 1] <=0)
            {
                return 1;
            }

            int first = arr[0];
            int current = arr[1];

            //Find Gap
            for (int i = 2; i < arr.Length; i++)
            {
                if (current - first > 1)
                    return first + 1;

                first = current;
                current = arr[i];
            }

            if (current - first > 1)
                return first + 1;
            else
                return arr[arr.Length-1] + 1;
        }
    }
}
