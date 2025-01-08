// See https://aka.ms/new-console-template for more information

internal class Program
{
    public class Node
    {
        public Node LeftChild { get; private set; }
        public Node RightChild { get; private set; }

        public Node(Node leftChild, Node rightChild)
        {
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
        }

        public int Height()
        {
            return CalculateHeight(this);
        }

        private int CalculateHeight(Node node)
        {
            if (node == null)
                return 0;

            int leftHeight = CalculateHeight(node.LeftChild);
            int rightHeight = CalculateHeight(node.RightChild);

            return Math.Max(leftHeight, rightHeight) + 1;
        }
    }
    static async Task Main(string[] args)
    {
        /*
         C:/Temp/FolderA/File1;
         C:/Temp/FolderB/File2;
         C:/Temp/FolderB/File3;
         C:/Temp/FolderC/File4;
         C:/Temp/FolderC/File5;
         */
        var fileSystemManager = new GeneralCompany.FileSystemManager();

        fileSystemManager.AddDirectory("C", "temp");
        fileSystemManager.AddDirectory("temp", "folderA");
        fileSystemManager.AddDirectory("temp", "folderB");
        fileSystemManager.AddDirectory("temp", "folderC");
       
        fileSystemManager.AddFile("folderA", "file1", 50);
        fileSystemManager.AddFile("folderB", "file2", 50);
        fileSystemManager.AddFile("folderB", "file3", 150);
        fileSystemManager.AddFile("folderC", "file4", 250);
        fileSystemManager.AddFile("folderC", "file5", 80);

        fileSystemManager.Print("C");

        fileSystemManager.Delete("folderA");

        fileSystemManager.Print("C");
    }

    static List<string> ReadSynonymsFromFiles(string[] files)
    {
        List<string> synonyms = new List<string>();

        foreach (string file in files)
        {
            if (File.Exists(file))
            {
                string[] lines = File.ReadAllLines(file);
                synonyms.AddRange(lines);
            }
            else
            {
                Console.WriteLine($"File '{file}' does not exist.");
            }
        }

        return synonyms;
    }

    static async Task<List<string>> ReadSynonymsFromFilesAsync(string[] files)
    {
        List<Task<string[]>> readTasks = new List<Task<string[]>>();

        foreach (string file in files)
        {
            if (File.Exists(file))
            {
                Task<string[]> readTask = ReadLinesFromFileAsync(file);
              
                readTasks.Add(readTask);
            }
            else
            {
                Console.WriteLine($"File '{file}' does not exist.");
            }
        }

        string[][] results = await Task.WhenAll(readTasks);
      
        List<string> synonyms = results.SelectMany(lines => lines).ToList();

        return synonyms;
    }

    static async Task<string[]> ReadLinesFromFileAsync(string file)
    {
        using (StreamReader reader = new StreamReader(file))
        {
            string content = await reader.ReadToEndAsync();

            return content.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        }
    }
    static List<string> SortSynonyms(List<string> synonyms)
    {
        return synonyms.OrderBy(s => s).ToList();
    }

    static void WriteSynonymsToFile(List<string> synonyms, string outputFile)
    {
        File.WriteAllLines(outputFile, synonyms);
    }

    static async Task WriteSynonymsToFileAsync(List<string> synonyms, string outputFile)
    {
        using (StreamWriter writer = new StreamWriter(outputFile))
        {
            foreach (string synonym in synonyms)
            {
                await writer.WriteLineAsync(synonym);
            }
        }
    }

    static bool IsPalindrome(string str)
    {
        char[] charArray = str.ToCharArray();
        Array.Reverse(charArray);
        string reversedStr = new string(charArray);

        return str == reversedStr;
    }
    

    public class SongShuffler
    {
        private static Random random = new Random();

        public static List<string> ShuffleSongs(List<string> songs)
        {
            int n = songs.Count;
            for (int i = 0; i < n - 1; i++)
            {
                int j = random.Next(i, n);
                Swap(songs, i, j);
            }
            return songs;
        }

        private static void Swap(List<string> songs, int i, int j)
        {
            string temp = songs[i];
            songs[i] = songs[j];
            songs[j] = temp;
        }
    }
}

//Node leaf1 = new Node(null, null);
//Node leaf2 = new Node(null, null);
//Node node = new Node(leaf1, null);
//Node root = new Node(node, leaf2);

//Console.WriteLine(root.Height());
//string[] inputFiles = { "file1.txt", "file2.txt", "file3.txt" };
//string outputFile = "output.txt";

//List<string> synonyms = ReadSynonymsFromFiles(inputFiles);

//List<string> sortedSynonyms = SortSynonyms(synonyms);

//WriteSynonymsToFile(sortedSynonyms, outputFile);

//Console.WriteLine("Synonyms have been written to the output file.");

////In Async:
//List<string> synonyms2 = await ReadSynonymsFromFilesAsync(inputFiles);

//List<string> sortedSynonyms2 = SortSynonyms(synonyms2);


//await WriteSynonymsToFileAsync(sortedSynonyms, outputFile);
