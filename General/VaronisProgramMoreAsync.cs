using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

/*
class Program
{
    static List<string> synonyms = new List<string>();

    static async Task Main() //async main
    {
        string file1 = @"C:\\temp\\input1.txt";
        string file2 = @"C:\\temp\\input2.txt";
        string file3 = @"C:\\temp\\input3.txt";
        string outputFile = @"C:\\temp\\output.txt";

        // Use Task to read each file asynchronously
        Task task1 = ReadSynonymsFileAsync(file1);
        Task task2 = ReadSynonymsFileAsync(file2);
        Task task3 = ReadSynonymsFileAsync(file3);

        // Wait for all tasks to complete
        await Task.WhenAll(task1, task2, task3); //await on a task returned from Task.WhenAll

        // Sort the synonyms
        synonyms.Sort();

        // Write the synonyms to the output file
        await WriteSynonymsFileAsync(synonyms, outputFile);

        Console.WriteLine("Synonyms have been merged and sorted. Output file: " + outputFile);
    }

    static async Task ReadSynonymsFileAsync(string filePath)
    {
        List<string> fileSynonyms = new List<string>();

        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = await reader.ReadLineAsync()) != null) //async method: ReadLineAsync
            {
                fileSynonyms.Add(line);
            }
        }

        // Synchronize access to the shared synonyms list
        lock (synonyms) //synonyms is a mutual resource which is being written by the 3 tasks!
        {
            synonyms.AddRange(fileSynonyms);
        }
    }

    static async Task WriteSynonymsFileAsync(List<string> synonyms, string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (string synonym in synonyms)
            {
                await writer.WriteLineAsync(synonym); //async method: WriteLineAsync
            }
        }
    }
}
*/