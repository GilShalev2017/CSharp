using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Millenium
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            #region Tasks

            // Call an asynchronous method and await the result

            //Here the await returns the result!
            var resultWeb = await GetTodosAsync();

            //Here we don't await/wait on the task but the Result is blocking until we get a result.
            var resultWeb2 = GetTodosAsync().Result;

            Console.WriteLine("Web returned {0} records", resultWeb.Length);

            MyCallerMethod();

            Task<int> task = Task.Run(() =>
            {
                // Perform some asynchronous operation
                return 42; // Return a result of 42
            });

            // Wait for the Task to complete
            task.Wait();

            // Obtain the result using the Result property
            int resultOfTask = task.Result;

            Console.WriteLine("Result: " + resultOfTask); // Output: Result: 42

            #endregion Tasks

            int result = fib(7);
            Console.WriteLine(String.Format("fib(7)={0}", result));

            await Task.Delay(4);

            int[] a = { -35, 32, -24, 0, 27, -10, 0, -19 };
            Console.WriteLine(maxSubArraySum(a, a.Length));
            // size of an array
            //int n = a.Length;
            //Console.WriteLine(maxSum(a, n));

            byte[] input = { 0xFF, 0xFF, 0xFF, 0x00, 0x00, 0xFF, 0xFF, 0x11 };
            byte[] encoded = RunLengthEncode(input).ToArray();
            Console.WriteLine("Encoded data: " + BitConverter.ToString(encoded));

            byte[] input2 = new byte[] { (byte)'a', (byte)'a', (byte)'a', (byte)'a', (byte)'a', (byte)'a',
                                         (byte)'a', (byte)'b', (byte)'b', (byte)'b', (byte)'b',
                                         (byte)'c',(byte)'c',(byte)'c',(byte)'c',(byte)'d',(byte)'d',(byte)'d',
                                         (byte)'d',(byte)'d' };
            byte[] encoded2 = RunLengthEncode(input2).ToArray();
            Console.WriteLine("Encoded data: " + BitConverter.ToString(encoded2));

            byte[] input3 = new byte[] { (byte)'F', (byte)'r', (byte)'o', (byte)'o', (byte)'t', (byte)'L', (byte)'o', (byte)'o', (byte)'p', (byte)'s' };
            IEnumerable<byte> encoded3 = RunLengthEncode(input3);
            string str = Encoding.ASCII.GetString(encoded3.ToArray());
            Console.WriteLine(str);

            //Find-The-N-Maximum-Numbers-In-AnArray
            int[] arr = { 1, 5, 3, 7, 2, 8, 4 };
            int n = 3;
            int[] maxNumbers = FindNMax(arr, n);
            Console.WriteLine("Max numbers: " + string.Join(", ", maxNumbers));

            List<ExamResult> exams = new List<ExamResult>
            {
                new ExamResult { ClassId = "C1", StudentId = "S1", Grade = 100, ExamDate = DateTime.Parse("2023-05-01") },
                new ExamResult { ClassId = "C1", StudentId = "S1", Grade = 60, ExamDate = DateTime.Parse("2023-04-28") },
                new ExamResult { ClassId = "C2", StudentId = "S1", Grade = 100, ExamDate = DateTime.Parse("2023-04-28") },
                new ExamResult { ClassId = "C1", StudentId = "S2", Grade = 100, ExamDate = DateTime.Parse("2023-04-28") },
                new ExamResult { ClassId = "C1", StudentId = "S2", Grade = 100, ExamDate = DateTime.Parse("2023-04-26") },
                new ExamResult { ClassId = "C2", StudentId = "S2", Grade = 98, ExamDate = DateTime.Parse("2023-04-27") }
            };

            IEnumerable<ExamResult> res = GetLatestExamRes(exams);
        }

        public static IEnumerable<ExamResult> GetLatestExamRes(IEnumerable<ExamResult> input)
        {
            Dictionary<string, ExamResult> dic = new Dictionary<string, ExamResult>();

            foreach (ExamResult exam in input)
            {
                string key = exam.ClassId + exam.StudentId;

                if (dic.ContainsKey(key))
                {
                    if (dic[key].ExamDate < exam.ExamDate) //date comparison
                    {
                        dic[key].ExamDate = exam.ExamDate;
                    }
                }
                else
                {
                    dic.Add(key, exam);
                }
            }

            var list = dic.Values.ToArray();
            return list;
        }

        public static int[] FindNMax(int[] arr, int n)
        {
            var sorted = arr.OrderByDescending(num => num);

            return sorted.Take(n).ToArray();
        }

        static int fib(int index)
        {
            if (index == 1 || index == 2)
            {
                return 1;
            }

            return fib(index - 1) + fib(index - 2);
        }

        static int FindMaxSum(int[] arr)
        {
            if (arr == null)
                return 0;

            int max_so_far = int.MinValue;
            int max_ending_here = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                max_ending_here = max_ending_here + arr[i];

                if (max_so_far < max_ending_here)
                {
                    max_so_far = max_ending_here;
                }

                if (max_ending_here < 0)
                {
                    max_ending_here = 0;
                }
            }
            return max_so_far;
        }

        // Function to calculate Maximum Subarray Sum
        // or Kadane's Algorithm
        static int maxSubArraySum(int[] a, int size)
        {
            int max_so_far = int.MinValue, max_ending_here = 0;

            for (int i = 0; i < size; i++)
            {
                max_ending_here = max_ending_here + a[i];
                if (max_so_far < max_ending_here)
                    max_so_far = max_ending_here;

                if (max_ending_here < 0)
                    max_ending_here = 0;
            }
            return max_so_far;
        }

        // Function to find the maximum
        // sum after given operations
        static int maxSum(int[] a, int n)
        {
            // To store sum of all elements
            int S = 0;

            // Maximum sum of a subarray
            int S1 = maxSubArraySum(a, n);

            // Calculate the sum of all elements
            for (int i = 0; i < n; i++)
                S += a[i];

            return (2 * S1 - S);
        }

        public static IEnumerable<byte> RunLengthEncode(IEnumerable<byte> original)
        {
            List<byte> output = new List<byte>();
            byte previousByte = byte.MaxValue; // set to an invalid value to force first byte to be output
            int count = 0;

            foreach (byte b in original)
            {
                if (b != previousByte || count == 255) //255 is the max possible value
                {
                    //we are here since there is a change in segment!
                    if (count > 0)
                    {
                        output.Add((byte)count);
                        output.Add(previousByte);
                        count = 0; //since we are in a new segment!
                    }
                }
                previousByte = b;
                count++;
            }

            if (count > 0)
            {
                output.Add((byte)count);
                output.Add(previousByte);
            }

            return output.ToArray();
        }



        // Enum to strictly define the possible statuses
        public enum TodoStatus
        {
            Pending,
            Completed
        }

        // Class to model a single todo item
        public class TodoItem
        {
            public int Id { get; set; }

            public int UserId { get; set; }

            public string Title { get; set; }
            public DateTimeOffset DueOn { get; set; }

            public TodoStatus Status { get; set; }

            // Optional: Override ToString for easier debugging/display
            public override string ToString()
            {
                return $"Task ID: {Id}, Title: '{Title.Substring(0, Math.Min(Title.Length, 30))}...', Status: {Status}, Due: {DueOn.Date.ToShortDateString()}";
            }
        }


        static async Task<object[][]> GetTodosAsync()
        {
            // Create an instance of HttpClient
            var httpClient = new HttpClient();

            // Call GetStringAsync asynchronously and await the result
            var result = await httpClient.GetAsync("https://gorest.co.in/public/v2/todos");

            var jsonStringified = await result.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<IEnumerable<IDictionary<string, object>>>(jsonStringified);

            var data2 = JsonConvert.DeserializeObject<List<TodoItem>>(jsonStringified);

            var array = data.Select(d => d.Values.ToArray()).ToArray();
            // Return the result
            return array;
        }
        static async Task MyAsyncMethod()
        {
            // Asynchronous operation
            await Task.Delay(1); // Simulating an asynchronous delay of 1 second
                                 // Code after await resumes executing once the asynchronous operation is complete
        }
        static async void MyCallerMethod()
        {
            Console.WriteLine("Before calling MyAsyncMethod");

            await MyAsyncMethod(); // Waiting for MyAsyncMethod to complete

            Console.WriteLine("After calling MyAsyncMethod");
        }
    }
}
