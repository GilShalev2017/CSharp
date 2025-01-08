using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
/*
class Program
{
    static List<string> synonyms = new List<string>();

    static void Main()
    {
        string file1 = @"C:\\temp\\input1.txt";
        string file2 = @"C:\\temp\\input2.txt";
        string file3 = @"C:\\temp\\input3.txt";
        string outputFile = @"C:\\temp\\output.txt";

  
        // Use Task to read each file in a separate thread
        Task[] tasks = new Task[]
        {
            Task.Run(() => ReadSynonymsFile(file1)),
            Task.Run(() => ReadSynonymsFile(file2)),
            Task.Run(() => ReadSynonymsFile(file3))
        };

        // Wait for all tasks to complete
        Task.WaitAll(tasks);

        // Sort the synonyms
        synonyms.Sort();

        // Write the synonyms to the output file
        WriteSynonymsFile(synonyms, outputFile);

        Console.WriteLine("Synonyms have been merged and sorted. Output file: " + outputFile);
    }

    static void ReadSynonymsFile(string filePath)
    {
        List<string> fileSynonyms = new List<string>();

        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                fileSynonyms.Add(line);
            }
        }

        // Synchronize access to the shared synonyms list
        lock (synonyms)
        {
            synonyms.AddRange(fileSynonyms);
        }
    }

    static void WriteSynonymsFile(List<string> synonyms, string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (string synonym in synonyms)
            {
                writer.WriteLine(synonym);
            }
        }
    }
}
*/