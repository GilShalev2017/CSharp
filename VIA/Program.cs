// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

//HashSet<int> uniqueEntries = new HashSet<int>();

//var array = new int [10,11,12,10];

//foreach (int entry in array)
//{
//   if(uniqueEntries.Add(entry) == false)
//   {
//        return false;
//   }
//}

//return true;


using System;

class Program
{
    static bool IsUnique(params int[] array)
    {
        HashSet<int> uniqueEntries = new HashSet<int>();

        foreach (int entry in array)
        {
            if (uniqueEntries.Add(entry) == false)
            {
                return false;
            }
        }
        return true;
    }

    static bool CanCompleteRides(int carCapacity, int[][] rides)
    {
        int totalPassengers = 0;

        foreach (int[] ride in rides)
        {
            int startTime = ride[0];
            int endTime = ride[1];
            int passengersCount = ride[2];

            // Check if adding the passengers from this ride exceeds the car capacity
            if (totalPassengers + passengersCount > carCapacity)
            {
                return false;
            }

            // Update the total number of passengers
            totalPassengers += passengersCount;

            // Check if any passengers have completed their ride by the current end time
            if (totalPassengers > 0 && endTime > startTime)
            {
                totalPassengers -= (endTime - startTime);
            }
        }

        // If we reach this point, all rides can be completed without exceeding the car capacity
        return true;
    }

    static bool ContainsDuplicate(int[] nums)
    {
        HashSet<int> set = new HashSet<int>();

        foreach (int num in nums)
        {
            if (set.Contains(num))
            {
                return true; // Duplicate number found
            }

            set.Add(num);
        }

        return false; // No duplicates found
    }

    static bool ContainsDuplicate2(int[] nums)
    {
        Array.Sort(nums);

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] == nums[i - 1])
            {
                return true; // Duplicate number found
            }
        }

        return false; // No duplicates found
    }

    static void Main()
    {
        int[] array = new int[] { 1, 3, 5, 7, 9, 9 };

        var result = IsUnique(array);

        Console.WriteLine(string.Format("Is Array Unique? {0}", result));

        int carCapacity = 5;
        int[][] rides = new int[][] {
            new int[] { 0, 10, 2 },
            new int[] { 5, 15, 3 },
            new int[] { 10, 20, 1 }
        };

        bool canComplete = CanCompleteRides(carCapacity, rides);
        Console.WriteLine(canComplete);

        int[] nums = { 1, 2, 3, 4, 5, 2, 6 };

        bool containsDuplicate = ContainsDuplicate(nums);
        Console.WriteLine(containsDuplicate);

        bool containsDuplicate2 = ContainsDuplicate2(nums);
        Console.WriteLine(containsDuplicate2);
    }
}