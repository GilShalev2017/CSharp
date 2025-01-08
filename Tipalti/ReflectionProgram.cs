//using System;
//using System.Reflection;

//public class ObjectPrinter
//{
//    public static void PrintObjectProperties(object obj)
//    {
//        Type objectType = obj.GetType();
//        PropertyInfo[] properties = objectType.GetProperties();

//        Console.WriteLine($"Printing properties of {objectType.Name}:");

//        foreach (var property in properties)
//        {
//            string propertyName = property.Name;
//            object propertyValue = property.GetValue(obj);

//            Console.WriteLine($"{propertyName}: {propertyValue}");
//        }
//    }
//}

//public class Person
//{
//    public string FirstName { get; set; }
//    public string LastName { get; set; }
//    public int Age { get; set; }
//}

//public class ReflectionProgram
//{
//    public static void Main()
//    {
//        Person person = new Person
//        {
//            FirstName = "John",
//            LastName = "Doe",
//            Age = 30
//        };

//        ObjectPrinter.PrintObjectProperties(person);
//    }
//}

///// With indentation
/*
using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;

public class ObjectPrinter
{
    private List<object> visitedObjects;
    private HashSet<Type> simpleTypes;

    public ObjectPrinter()
    {
        visitedObjects = new List<object>();
        // Define a set of simple types to avoid recursion
        simpleTypes = new HashSet<Type>
        {
            typeof(string), typeof(int), typeof(double), typeof(float), typeof(bool),
            typeof(decimal), typeof(char), typeof(byte), typeof(short), typeof(long),
            typeof(ushort), typeof(uint), typeof(ulong)
        };
    }

    public void PrintObjectProperties(object obj, TextWriter output)
    {
        visitedObjects.Clear(); // Clear the list of visited objects before each print operation
        RecursivePrintObjectProperties(obj, output, 0);
    }

    private void RecursivePrintObjectProperties(object obj, TextWriter output, int indentationLevel)
    {
        if (obj == null || visitedObjects.Contains(obj))
        {
            return;
        }

        visitedObjects.Add(obj);

        Type objectType = obj.GetType();
        PropertyInfo[] properties = objectType.GetProperties();

        string indentation = new string(' ', indentationLevel * 2);
        output.WriteLine($"{indentation}Printing properties of {objectType.Name}:");

        foreach (var property in properties)
        {
            string propertyName = property.Name;
            object propertyValue = property.GetValue(obj);

            // Check if the property's type is in the list of simple types
            if (propertyValue != null && !simpleTypes.Contains(propertyValue.GetType()))
            {
                output.WriteLine($"{propertyName}:");
                RecursivePrintObjectProperties(propertyValue, output,indentationLevel + 1);
            }
            else
            {
                output.WriteLine($"{indentation}{propertyName}: {propertyValue}");
            }
        }
    }
}

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public Person Spouse { get; set; }
}

public class Program
{
    public static void Main()
    {
        Person person1 = new Person
        {
            FirstName = "John",
            LastName = "Doe",
            Age = 30
        };

        Person person2 = new Person
        {
            FirstName = "Jane",
            LastName = "Doe",
            Age = 28,
            Spouse = person1
        };

        person1.Spouse = person2;

        ObjectPrinter printer = new ObjectPrinter();

        // Print to the console
        printer.PrintObjectProperties(person1, Console.Out);

        // Print to a file
        using (StreamWriter fileWriter = new StreamWriter("output.txt"))
        {
            printer.PrintObjectProperties(person1, fileWriter);
        }
    }
}
*/