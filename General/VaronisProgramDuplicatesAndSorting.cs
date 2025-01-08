using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
/*
class Program
{
    static void Main()
    {
        string file1 = @"C:\\temp\\input1.txt";
        string file2 = @"C:\\temp\\input2.txt";
        string file3 = @"C:\\temp\\input3.txt";
        string outputFile = @"C:\\temp\\output.txt";

        Console.WriteLine("Enter sorting order (ascending or descending):");
        string sortingOrder = Console.ReadLine();

        Console.WriteLine("Enter spacing character:");
        char spacingChar = Console.ReadLine()[0];

        // Use Task to read each file in a separate thread
        Task<List<string>> task1 = ReadFileAsync(file1);
        Task<List<string>> task2 = ReadFileAsync(file2);
        Task<List<string>> task3 = ReadFileAsync(file3);

        // Wait for all tasks to complete
        Task.WaitAll(task1, task2, task3);

        // Combine words from all files and remove duplicates
        List<string> combinedWords = CombineAndSortWords(task1.Result, task2.Result, task3.Result, sortingOrder);

        // Write the combined and sorted words to the output file
        var distinctList = combinedWords.Distinct().ToList();
        
        WriteWordsToFile(distinctList, outputFile, spacingChar);

        // Find the most frequent word
        string mostFrequentWord = FindMostFrequentWord(combinedWords, out int count);

        Console.WriteLine($"Most frequent word: {mostFrequentWord}, Count: {count}");
    }

    static async Task<List<string>> ReadFileAsync(string filePath)
    {
        List<string> words = new List<string>();

        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = await reader.ReadLineAsync()) != null)
            {
                string[] lineWords = line.Split(' ');
                words.AddRange(lineWords);
            }
        }

        return words;
    }

    static List<string> CombineAndSortWords(List<string> words1, List<string> words2, List<string> words3, string sortingOrder)
    {
        ConcurrentBag<string> combinedWords = new ConcurrentBag<string>();

        Parallel.ForEach(words1.Concat(words2).Concat(words3), word =>
        {
            combinedWords.Add(word.ToLower());
        });

        List<string> sortedWords = sortingOrder.ToLower() == "ascending"
            ? combinedWords.OrderBy(w => w).ToList()
            : combinedWords.OrderByDescending(w => w).ToList();

        return sortedWords.ToList(); //sortedWords.Distinct().ToList();
    }

    static void WriteWordsToFile(List<string> words, string filePath, char spacingChar)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (string word in words)
            {
                writer.WriteLine(word.Replace(' ', spacingChar));
            }
        }
    }

    static string FindMostFrequentWord(List<string> words, out int count)
    {
        var wordCount = new Dictionary<string, int>();

        foreach (string word in words)
        {
            if (wordCount.ContainsKey(word))
            {
                wordCount[word]++;
            }
            else
            {
                wordCount[word] = 1;
            }
        }

        KeyValuePair<string, int> mostFrequentWord = wordCount.OrderByDescending(w => w.Value).FirstOrDefault();
      
        count = mostFrequentWord.Value;

        return mostFrequentWord.Key;
    }
}
*/