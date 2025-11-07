using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Cider
{
    internal class Program
    {
        public static Node root;

        //https://dirask.com/posts/Node-js-get-files-from-directory-recursively-asynchronous-example-DZXGbj
        public class Node
        {
            public Node(string path)
            {
                FilePath = path;
            }
            public string FilePath { get; set; }
            public List<Node> Children { get; set; }
        }

        public static bool IsDirectory(string path)
        {
            if (File.GetAttributes(path).HasFlag(FileAttributes.Directory))
                return true;

            return false;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //root = new Node(@"C:\temp\TEST");
            root = new Node(@"C:\temp");

            BuildTree(root);
        }

        static void BuildTree(Node node)
        {
            var files = Directory.GetFileSystemEntries(node.FilePath).ToList();

            if (files == null)
            {
                return;
            }
            else
            {
                node.Children = new List<Node>();

                //Asynchronized version
                Parallel.ForEach(files, (file) => {
                   
                    Node child = new Node(file);

                    node.Children.Add(child);

                    if (IsDirectory(file))
                    {
                        BuildTree(child);
                    }
                });
            }
        }
    }
}
