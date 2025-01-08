/*
using System;
using System.Collections.Generic;

class RelationUtility
{
    private Dictionary<Person, List<Person>> relationships;

    public void Init(Person[] people)
    {
        relationships = new Dictionary<Person, List<Person>>();

        foreach (var person in people)
        {
            relationships[person] = new List<Person>();
        }
    }

    public void AddRelation(Person personA, Person personB)
    {
        if (relationships != null && relationships.ContainsKey(personA) && relationships.ContainsKey(personB))
        {
            relationships[personA].Add(personB);
            relationships[personB].Add(personA);
        }
    }

    public int FindMinRelationLevel(Person personA, Person personB)
    {
        if (relationships == null || !relationships.ContainsKey(personA) || !relationships.ContainsKey(personB))
        {
            return -1; // At least one of the persons is not in the initialized list.
        }

        if (personA == personB)
        {
            return 0; // They are the same person.
        }

        Queue<Person> queue = new Queue<Person>();
        Dictionary<Person, int> visited = new Dictionary<Person, int>();

        queue.Enqueue(personA);
        visited[personA] = 0;

        while (queue.Count > 0)
        {
            Person currentPerson = queue.Dequeue();
            int currentLevel = visited[currentPerson];

            foreach (Person relative in relationships[currentPerson])
            {
                if (!visited.ContainsKey(relative))
                {
                    queue.Enqueue(relative);
                    visited[relative] = currentLevel + 1;

                    if (relative == personB)
                    {
                        return visited[relative];
                    }
                }
            }
        }

        return -1; // No direct or indirect relation found.
    }
}

class Person
{
    public string Name { get; set; }

    public Person(string name)
    {
        Name = name;
    }
}

class Program
{
    static void Main()
    {
        Person alice = new Person("Alice");
        Person bob = new Person("Bob");
        Person charlie = new Person("Charlie");
        Person dave = new Person("Dave");
        Person eve = new Person("Eve");

        RelationUtility utility = new RelationUtility();
        utility.Init(new Person[] { alice, bob, charlie, dave, eve });

        // Define relationships
        utility.AddRelation(alice, bob);
        utility.AddRelation(bob, charlie);
        utility.AddRelation(charlie, dave);
        utility.AddRelation(dave, eve);

        int relationLevel1 = utility.FindMinRelationLevel(alice, eve);
        int relationLevel2 = utility.FindMinRelationLevel(alice, dave);

        Console.WriteLine($"Relation level between Alice and Eve: {relationLevel1}");
        Console.WriteLine($"Relation level between Alice and Dave: {relationLevel2}");
    }
}
*/
using System;
using System.Collections.Generic;

class Person
{
    public string Name { get; }
    public List<Person> Relatives { get; }

    public Person(string name)
    {
        Name = name;
        Relatives = new List<Person>();
    }
}

class RelationUtility
{
    private Dictionary<Person, int> visited;

    public void Init(Person[] people)
    {
        visited = new Dictionary<Person, int>();
        foreach (var person in people)
        {
            visited[person] = -1;
        }
    }

    public int FindMinRelationLevel(Person personA, Person personB)
    {
        if (personA == personB)
            return 0;

        Queue<Person> queue = new Queue<Person>();
        visited[personA] = 0;
        queue.Enqueue(personA);

        while (queue.Count > 0)
        {
            var currentPerson = queue.Dequeue();
            int currentLevel = visited[currentPerson];

            foreach (var relative in currentPerson.Relatives)
            {
                if (visited[relative] == -1)
                {
                    visited[relative] = currentLevel + 1;
                    queue.Enqueue(relative);

                    if (relative == personB)
                        return visited[relative];
                }
            }
        }

        return -1; // If no relation is found
    }
}

class Program
{
    static void Main()
    {
        var alice = new Person("Alice");
        var bob = new Person("Bob");
        var charlie = new Person("Charlie");
        var david = new Person("David");
        var eve = new Person("Eve");

        alice.Relatives.AddRange(new[] { bob, charlie });
        bob.Relatives.AddRange(new[] { alice, david });
        charlie.Relatives.AddRange(new[] { alice, eve });
        david.Relatives.AddRange(new[] { bob });
        eve.Relatives.AddRange(new[] { charlie });

        var people = new Person[] { alice, bob, charlie, david, eve };

        RelationUtility utility = new RelationUtility();
        utility.Init(people);

        int minLevel = utility.FindMinRelationLevel(alice, eve);
        if (minLevel != -1)
        {
            Console.WriteLine($"The minimal relation level between Alice and Eve is {minLevel}.");
        }
        else
        {
            Console.WriteLine("Alice and Eve are not related.");
        }
    }
}
