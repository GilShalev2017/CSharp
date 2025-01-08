//using System;
//using System.Collections.Generic;

//class Address
//{
//    public string Street { get; set; }
//    public string City { get; set; }
//    public string State { get; set; }
//    public string ZipCode { get; set; }

//    public Address(string street, string city, string state, string zipCode)
//    {
//        Street = street;
//        City = city;
//        State = state;
//        ZipCode = zipCode;
//    }
//}

//class Name
//{
//    public string FirstName { get; set; }
//    public string LastName { get; set; }

//    public Name(string firstName, string lastName)
//    {
//        FirstName = firstName;
//        LastName = lastName;
//    }
//}

//class Person
//{
//    public Name FullName { get; set; }
//    public Address CurrentAddress { get; set; }

//    public Person(Name name, Address address)
//    {
//        FullName = name;
//        CurrentAddress = address;
//    }
//}

//class RelationshipUtility
//{
//    public static string FindMinimalRelationLevel(Person person1, Person person2)
//    {
//        if (person1.FullName.FirstName == person2.FullName.FirstName && person1.FullName.LastName == person2.FullName.LastName)
//        {
//            return "Same person";
//        }
//        else if (AreSameAddress(person1.CurrentAddress, person2.CurrentAddress))
//        {
//            return "Same address";
//        }
//        else
//        {
//            return "No known relation";
//        }
//    }

//    private static bool AreSameAddress(Address address1, Address address2)
//    {
//        return address1.Street == address2.Street &&
//               address1.City == address2.City &&
//               address1.State == address2.State &&
//               address1.ZipCode == address2.ZipCode;
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        Address address1 = new Address("123 Main St", "Anytown", "CA", "12345");
//        Address address2 = new Address("456 Elm St", "Othertown", "CA", "54321");
//        Name name1 = new Name("John", "Doe");
//        Name name2 = new Name("Jane", "Doe");

//        Person person1 = new Person(name1, address1);
//        Person person2 = new Person(name2, address1);

//        string relationLevel = RelationshipUtility.FindMinimalRelationLevel(person1, person2);
//        Console.WriteLine("Relationship Level: " + relationLevel);
//    }
//}
