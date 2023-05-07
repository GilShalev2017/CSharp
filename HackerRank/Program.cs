// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

class Solution
{
    public static void Main(string[] args)
    {
        int[] nums = { -4, 3, -9, 0, 4, 1 };
       
        List<int> arr = nums.ToList();

        PlusMinus(arr);
    }

    static void PlusMinus(List<int> arr)
    {
        int positive = 0;
        int negative = 0;
        int zeros = 0;
        int total = arr.Count;

        arr.ForEach(item => {
            if (item == 0)
            {
                zeros++;
            }
            else if (item < 0)
            {
                negative++;
            }
            else
            {
                positive++;
            }
        });
        float potRatio = positive / total;
        float negRatio = negative / total;
        float zeroRatio = zeros / total;
        Console.WriteLine(potRatio);
        Console.WriteLine(negRatio);
        Console.WriteLine(zeroRatio);
    }

}
