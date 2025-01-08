using YOTPO;

internal class Program
{
    static void Main(string[] args)
    {
        /*
         C:/Temp/FolderA/File1;
         C:/Temp/FolderB/File2;
         C:/Temp/FolderB/File3;
         C:/Temp/FolderC/File4;
         C:/Temp/FolderC/File5;
         */
        var fileSystemManager = new FileSystemManager();

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
}