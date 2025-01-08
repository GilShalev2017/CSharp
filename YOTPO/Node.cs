using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YOTPO
{
    public abstract class Node
    {
        public string Name { get; }
        public DateTime Created { get; }
        public abstract void Delete();
        public abstract void Print();

        public string Parent { get; }

        public Node(string name, DateTime created, string parent)
        {
            Name = name;
            Created = created;
            Parent = parent;
        }
    }
}
