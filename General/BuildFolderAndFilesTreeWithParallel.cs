using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace General
{
    //ctrl + k + f // to indent
    
    internal class BuildFolderAndFilesTreeWithParallel
    {
        public enum FileType
        {
            Folder,
            File,
        }
        public class Node
        {
            public string Path { get; set; }
            public List<Node> Children { get; set; }
            //public Node Parent { get; set; }
            public FileType FileType { get; set; }
        }

        static void BuildNodes(Node node)
        {
            var files = Directory.GetFileSystemEntries(node.Path);

            foreach (var file in files)
            {
                if (Directory.Exists(file)) //this is a folder
                {
                    if(node.Children == null)
                    {
                        node.Children = new List<Node>();
                    }
                    
                    Node newNode = new Node { Path = file, FileType = FileType.Folder };
                   
                    node.Children.Add(newNode);

                    BuildNodes(newNode);

                }
                else if(File.Exists(file)) //this is a file
                {
                    Node newNode = new Node { Path = file, FileType = FileType.File };

                   // node.Children.Add(newNode);
                }
            }
        }

        static void ParalellBuildNodes(Node node)
        {
            var files = Directory.GetFileSystemEntries(node.Path);

            Parallel.ForEach(files, (file) =>
            {

                if (Directory.Exists(file)) //this is a folder
                {
                    if (node.Children == null)
                    {
                        node.Children = new List<Node>();
                    }

                    Node newNode = new Node { Path = file, FileType = FileType.Folder };

                    node.Children.Add(newNode);

                    BuildNodes(newNode);

                }
                else if (File.Exists(file)) //this is a file
                {
                    Node newNode = new Node { Path = file, FileType = FileType.File };

                    node.Children.Add(newNode);
                }
            });
        }
         /*
        static void Main(string[] args)
        {
            string path = @"C:\temp";

            Node root = new Node { Path = path, FileType = FileType.Folder};

            BuildNodes(root);

            PrintTree(root);

            ParalellBuildNodes(root);

            PrintTree(root);
        }
        */
        static void PrintTree(Node node)
        {
            if (node == null)
                return;

            //Console.WriteLine("path={0} FileType={1}", node.Path, node.FileType);

            if (node.Children != null)
            {
                foreach (var child in node.Children)
                {
                    Console.WriteLine("path={0} FileType={1}", child.Path, child.FileType);

                    if (child.FileType == FileType.Folder)
                    {
                        PrintTree(child);
                    }
                }
            }
        }

        static void ParallelPrintTree(Node node)
        {
            if (node == null)
                return;

            if (node.Children != null)
            {
                Parallel.ForEach(node.Children, (child) => 
                {
                    Console.WriteLine("path={0} FileType={1}", child.Path, child.FileType);

                    if (child.FileType == FileType.Folder)
                    {
                        PrintTree(child);
                    }
                });
            }
        }
    }
}
