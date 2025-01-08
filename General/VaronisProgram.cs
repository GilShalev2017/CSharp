using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace General
{
    //ctrl + k + f // to indent
    /*
    internal class VaronisProgram
    {
        public class ProcessResult
        {
            public int maxOccurence { get; set; }
            public string mostPopular { get; set; }

            public List<string> sortedText { get; set; }
        }

        static ProcessResult ProcessFile(string path, string splitter)
        {
            var allText = File.ReadAllText(path);
            var splits = allText.Split(splitter);
            var dic = new Dictionary<string, int>();

            var mostPopular = "";
            var maxOccurence = 1;

            foreach (var split in splits)
            {
                var lowerCaseSplit = split.ToLower();

                if(dic.ContainsKey(lowerCaseSplit))
                {
                    dic[lowerCaseSplit]++;
                    if(dic[lowerCaseSplit] > maxOccurence)
                    {
                        maxOccurence = dic[lowerCaseSplit];
                        mostPopular = lowerCaseSplit;
                    }
                }
                else
                {
                    dic.Add(lowerCaseSplit, 1);
                }
            }

            var keys_sorted = dic.Keys.ToList();
            keys_sorted.Sort();

            return new ProcessResult { maxOccurence = maxOccurence, mostPopular = mostPopular, sortedText = keys_sorted };
        }
        static void CombineFiles(string path, string splitter)
        {

        }

        static void Main(string[] args)
        {
            //write a program that reads 3 files and combined them into a fourth file.
            //Reading / writing should be with different threads, reading threads should be running simultaneously.
            //All words should be sorted lexicographically lower case, duplicates should only be written once.
            //the program should print the most frequent word in all 3 files and its count.
            //the program should ask the user for sorting order and spacing char. V

            Console.WriteLine("Please Enter Sorting Order: 1- for ASC, 2 - for DESC");
            var sortingOrder = Console.ReadLine();
            Console.WriteLine("Please Enter Spacing char");
            var splitterChar = Console.ReadLine();

            var sortedFile1 = "";
            var sortedFile2 = "";
            var sortedFile3 = "";

            var maxFile1 = "";
            var maxFile2 = "";
            var maxFile3 = "";
            var maxFile1Count = "";
            var maxFile2Count = "";
            var maxFile3Count = "";

            var task1 = Task.Run(() => { ProcessFile(@"C:\temp\input1.txt", splitterChar); });
            task1.Wait();
            
            //var task2 = Task.Run(() => { ProcessFile(@"C:\temp\input2.txt", splitterChar); });
            //var res2 = task2.Wait();
            //var task3 = Task.Run(() => { ProcessFile(@"C:\temp\input3.txt", splitterChar); });
            //var res3 = task3.Wait();

            //Task.WaitAll(task1, task2, task3);

            var task4 = Task.Run(() => { CombineFiles(@"C:\temp\input4.txt", splitterChar); });

        }
    }
    */
}
