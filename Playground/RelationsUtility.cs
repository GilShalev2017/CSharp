using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground
{
    public class Person
    {
        public string Name { get; }
        public List<Person> Relatives { get; } 
        public Person(string name)
        {
            Name = name;
            Relatives = new List<Person>();
        }
    }

    public class RelationUtility
    {
        private Dictionary<Person, int> visited;
        private Person[]? People { get; set; }
        public void Init(Person[] people)
        {
            if (people != null)
            {
                People = people!;
              
                visited = new Dictionary<Person, int>();
                
                foreach (var person in people)
                {
                    visited[person] = -1;
                }
            }
            else
            {
                throw new ArgumentNullException("people cannotbe null");
            }
        }
        public void ResetVisited()
        {
            foreach (var person in People!)
            {
                visited[person] = -1;
            }
        }
        public int FindMinRelationLevel(Person personA, Person personB)
        {
            if(personA == personB) 
                return 0;

            Queue<Person> queue = new Queue<Person>();
            visited[personA] = 0;
            queue.Enqueue(personA);

            while (queue.Count > 0)
            {
                var currentPerson = queue.Dequeue();
                var currentLevel = visited[currentPerson];

                foreach (var relative in currentPerson.Relatives)
                {
                    if (visited[relative] == -1)
                    {
                        visited[relative] = currentLevel + 1;
                        queue.Enqueue(relative);
                        if(relative == personB)
                        {
                            return visited[relative];
                        }
                    }
                }
            }
            return -1;
        }
       
    }

    public class Program
    {
        //public static void Main()
        //{
        //    var alice = new Person("alice");
        //    var bob = new Person("bob");
        //    var charlie = new Person("charlie");
        //    var david = new Person("david");
        //    var eve = new Person("eve");
        //    var gil = new Person("gil");
        //    var ed = new Person("ed");

        //    alice.Relatives.AddRange(new[] { bob, charlie });
        //    bob.Relatives.AddRange(new[] { alice, david });
        //    charlie.Relatives.AddRange(new[] { alice, eve });
        //    david.Relatives.AddRange(new[] { bob , gil });
        //    eve.Relatives.AddRange(new[] { charlie ,gil });
        //    gil.Relatives.AddRange(new[] { eve, david});
            
        //    var relationUtility = new RelationUtility();

        //    var people = new Person[] { alice, bob, charlie, david, eve, gil, ed };

        //    relationUtility.Init(people);
            
        //    var minLevel = relationUtility.FindMinRelationLevel(alice, eve);

        //    if (minLevel != -1)
        //    {
        //        Console.WriteLine($"The minimal relation level between Alice and Eve is {minLevel}.");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Alice and Eve are not related.");
        //    }
        //    relationUtility.ResetVisited();
        //    minLevel = relationUtility.FindMinRelationLevel(alice, gil);
        //    relationUtility.ResetVisited();
        //    minLevel = relationUtility.FindMinRelationLevel(alice, david);
        //    relationUtility.ResetVisited();
        //    minLevel = relationUtility.FindMinRelationLevel(alice, david);
        //    relationUtility.ResetVisited();
        //    minLevel = relationUtility.FindMinRelationLevel(alice, ed);
        //}
    }
}
