using System;
using System.Collections.Generic;
using System.Text;

namespace TipaltiTask.Model
{
    class Node
    {
        public Node(Person person)
        {
            Person = person;
            Children = new List<Node>();    
        }
        public List<Node> Children { get; set; }
        
        public Person Person { get; set; }
    }
}
