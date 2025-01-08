using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YOTPO
{
    public class FileSystemManager
    {
        private Dictionary<string, Node> nodes = new Dictionary<string, Node>();
        public FileSystemManager()
        {
            var rootDirectory = new Directory("C", DateTime.Now, ""); //root

            nodes.Add("C", rootDirectory);
        }

        public void AddFile(string parentDirName, string fileName, int fileSize)
        {
            if (parentDirName == null)
                throw new ArgumentNullException(nameof(parentDirName));

            var newFile = new File(fileName, DateTime.Now, fileSize, parentDirName);

            if (nodes.ContainsKey(parentDirName))
            {
                Directory? directory = nodes[parentDirName] as Directory;
                directory?.Children.Add(newFile);
                nodes.Add(fileName, newFile);
            }
            else
                throw new Exception("No Such Directory");
        }

        public void AddDirectory(string parentDirName, string name)
        {
            var newDirectory = new Directory(name, DateTime.Now, parentDirName);

            if (nodes.ContainsKey(parentDirName))
            {
                Directory? parentDirectory = nodes[parentDirName] as Directory;
                parentDirectory?.Children.Add(newDirectory);
                nodes.Add(name, newDirectory);
            }
            else
                throw new Exception("No Such Parent Directory");
        }

        public void Delete(string fileName)
        {
            if (nodes.ContainsKey(fileName))
            {
                var node = nodes[fileName];

                var parentNode = nodes[node.Parent];

                if (parentNode != null && parentNode is Directory)
                {
                    Directory parentDirectory = (Directory)parentNode;
                    parentDirectory?.Children.Remove(node);
                }
                node.Delete();

                nodes.Remove(fileName);
            }
        }

        public void Print(string fileName)
        {
            if (nodes.ContainsKey(fileName))
            {
                var node = nodes[fileName];
                node.Print();
            }
        }

    }
}
