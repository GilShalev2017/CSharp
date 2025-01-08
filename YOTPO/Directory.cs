using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YOTPO
{
    public class Directory : Node
    {
        public List<Node> Children { get; }

        public Directory(string name, DateTime created, string parent)
            : base(name, created, parent)
        {
            Children = new List<Node>();
        }

        public override void Delete()
        {
            foreach (Node node in Children)
            {
                node.Delete();
            }

            Children.Clear();
        }

        public override void Print()
        {
            Console.WriteLine(string.Format("  Directory '{0}', created at = {1} and contains the following files:", Name, Created));

            foreach (Node node in Children)
            {
                node.Print();
            }
        }
    }
}
