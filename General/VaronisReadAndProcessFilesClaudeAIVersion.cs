using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

class FileMerger
{
    static async Task Main()
    {
        string[] inputFiles = { "file1.txt", "file2.txt", "file3.txt" };
        string outputFile = "merged_output.txt";

        foreach (string file in inputFiles)
        {
            if (!File.Exists(file))
            {
                Console.Error.WriteLine($"[ERROR] Input file not found: {file}");
                return;
            }
        }

        // ── 1. Ask user for preferences ──────────────────────────────────────
        Console.WriteLine("=== File Merger Configuration ===\n");

        Console.Write("Sort order — enter 'asc' for ascending or 'desc' for descending: ");
        string sortInput = Console.ReadLine()?.Trim().ToLower() ?? "asc";
        bool ascending = sortInput != "desc";
        Console.WriteLine($"  → Sorting: {(ascending ? "Ascending (A → Z)" : "Descending (Z → A)")}");

        Console.Write("\nSpacing character between words (press Enter for a space): ");
        string spacingInput = Console.ReadLine();
        char spacingChar = (spacingInput?.Length > 0) ? spacingInput[0] : ' ';
        Console.WriteLine($"  → Spacing character: '{spacingChar}'");

        // ── 2. Read all 3 files simultaneously using Tasks ────────────────────
        // ConcurrentDictionary lets all reader tasks update word counts
        // without explicit locking.
        var wordCounts = new ConcurrentDictionary<string, int>(StringComparer.OrdinalIgnoreCase);

        Console.WriteLine("\n[INFO] Reading files in parallel...");

        Task[] readTasks = inputFiles
            .Select(path => ReadFileAsync(path, spacingChar, wordCounts))
            .ToArray();

        await Task.WhenAll(readTasks);

        Console.WriteLine($"[INFO] Unique words found: {wordCounts.Count}");

        // ── 3. Process words: sort, find most frequent ────────────────────────
        IEnumerable<string> sorted = wordCounts.Keys
            .OrderBy(w => w, StringComparer.OrdinalIgnoreCase);

        if (!ascending)
            sorted = sorted.Reverse();

        List<string> wordList = sorted.ToList();

        KeyValuePair<string, int> topWord = wordCounts.MaxBy(kv => kv.Value);

        // ── 4. Write output file asynchronously ───────────────────────────────
        Console.WriteLine("[INFO] Writing output file...");
        await WriteFileAsync(outputFile, wordList, spacingChar);

        // ── 5. Print results ──────────────────────────────────────────────────
        Console.WriteLine($"\n[DONE] Output written to '{outputFile}'");
        Console.WriteLine($"       Unique words written : {wordList.Count}");
        Console.WriteLine($"\n[STAT] Most frequent word  : \"{topWord.Key}\"");
        Console.WriteLine($"       Appears             : {topWord.Value} time(s)");
    }

    /// <summary>
    /// Reads a file line-by-line via StreamReader (heap-friendly for large files),
    /// splits each line by the user's spacing char, and accumulates word counts
    /// into the shared ConcurrentDictionary.
    /// </summary>
    private static async Task ReadFileAsync(
        string path,
        char separator,
        ConcurrentDictionary<string, int> wordCounts)
    {
        Console.WriteLine($"  [Task] Starting read: '{path}'");
        int wordsSeen = 0;

        // StreamReader reads one line at a time — only one line lives in memory
        // at once, so even multi-GB files won't blow the heap.
        using var reader = new StreamReader(path);

        while (!reader.EndOfStream)
        {
            string? line = await reader.ReadLineAsync();
            if (string.IsNullOrWhiteSpace(line)) continue;

            foreach (string raw in line.Split(separator, StringSplitOptions.RemoveEmptyEntries))
            {
                string word = raw.ToLower().Trim();
                if (word.Length == 0) continue;

                // AddOrUpdate is atomic — safe to call from multiple tasks.
                wordCounts.AddOrUpdate(word, 1, (_, count) => count + 1);
                wordsSeen++;
            }
        }

        Console.WriteLine($"  [Task] Finished '{path}' — {wordsSeen} total words");
    }

    /// <summary>
    /// Writes the sorted word list via StreamWriter, one word at a time.
    /// Avoids building a giant joined string in memory (important for large word sets).
    /// </summary>
    private static async Task WriteFileAsync(string path, List<string> words, char separator)
    {
        Console.WriteLine($"  [Task] Writing '{path}'");

        // autoFlush: false → writes are buffered and flushed in chunks,
        // which is much faster than flushing after every word.
        using var writer = new StreamWriter(path, append: false);

        for (int i = 0; i < words.Count; i++)
        {
            if (i > 0)
                await writer.WriteAsync(separator);

            await writer.WriteAsync(words[i]);
        }

        // Flush any remaining buffered content before the using block disposes.
        await writer.FlushAsync();
        Console.WriteLine($"  [Task] Write complete");
    }
}