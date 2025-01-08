using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YOTPO
{
    public class File : Node
    {
        public int Size { get; }
        public File(string name, DateTime created, int size, string parent)
            : base(name, created, parent)
        {
            Size = size;
        }
        public override void Delete()
        {
            string message = string.Format("Deleted {0}.", Name);
            Console.WriteLine(message);
        }

        public override void Print()
        {
            Console.WriteLine(string.Format("   File name={0}, File size={1}, file created at = {2}", Name, Size, Created));
        }
    }
}
