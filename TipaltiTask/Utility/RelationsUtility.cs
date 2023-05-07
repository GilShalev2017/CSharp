using System;
using System.Collections.Generic;
using System.Text;
using TipaltiTask.Model;

namespace TipaltiTask.Utility
{
    class RelationsUtility
    {
        List<Node> roots = new List<Node>();

        Node rootNode;

        public Node FindNodeToConnectTo(Node node, Person person)
        {
            if (node == null)
                return null;

            if (node.Person.Address == person.Address || node.Person.FullName.ToString() == person.FullName.ToString())
            {
                return node;
            }

            foreach (var child in node.Children)
            {
                if (child.Person.Address == person.Address || child.Person.FullName.ToString() == person.FullName.ToString())
                {
                    return child;
                }
                else
                {
                    FindNodeToConnectTo(child, person);
                }
            }

            return null;
        }
        
        public int FindNodeDistanceFromRoot(Node node, Person person, int count)
        {
            if (node == null)
                return -1;

            if (node.Person.FullName.ToString() == person.FullName.ToString() && node.Person.Address == person.Address)
            {
                return count;
            }

            foreach (var child in node.Children)
            {
                if (child.Person.FullName.ToString() == person.FullName.ToString() && child.Person.Address == person.Address)
                {
                    return 1 + count;
                }
                else
                {
                    FindNodeDistanceFromRoot(child, person, count);
                }
            }

            return 0;
        }

        public void CreateNewRoot(Person person)
        {
            var newNode  = new Node(person);
            roots.Add(newNode);
        }

        public void Init(Person[] people)
        {
            rootNode = new Node(people[1]);
            roots.Add(rootNode);

            for (int i=2; i<people.Length; i++)
            {
                Node currentNode = new Node(people[i]);
               
                Node nodeToConnectAfter = FindNodeToConnectTo(rootNode, people[i]);

                if (nodeToConnectAfter == null)
                {
                    roots.Add(currentNode);
                }
                else
                {
                    nodeToConnectAfter.Children.Add(currentNode);
                }
            }
        }
        public int FindMinRelationlevel(Person personA, Person personB)
        {
            int count = 0;
            var distanceA = FindNodeDistanceFromRoot(rootNode, personA, count);

            count = 0;
            var distanceB = FindNodeDistanceFromRoot(rootNode, personB, count);

            return Math.Abs(distanceB - distanceA);
        }
    }
}
