using System;
using TipaltiTask.Model;
using TipaltiTask.Utility;

namespace TipaltiTask
{
    class Program
    {
        //I failed here - didn't know the algorithm!
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            RelationsUtility relationsUtility = new RelationsUtility();

            var person1 = new Person { FullName = new Name{ FirstName = "Grace", LastName = "Hopper" }, Address = "NewYork" };
            var person2 = new Person { FullName = new Name { FirstName = "Alan", LastName = "Turing" }, Address = "Bletchhly Park" };
            var person3 = new Person { FullName = new Name { FirstName = "John", LastName = "Clarke" }, Address = "Bletchhly Park" };
            var person4 = new Person { FullName = new Name { FirstName = "John", LastName = "Clarke" }, Address = "London" };
            var person5 = new Person { FullName = new Name { FirstName = "Alan", LastName = "Turing" }, Address = "Cambridge" };

            Person[] people = { person1, person2, person3, person4, person5 };
        
            relationsUtility.Init(people);

            var relation1To4 = relationsUtility.FindMinRelationlevel(person1, person4);
            var relation2To3 = relationsUtility.FindMinRelationlevel(person2, person3);
            var relation3To4 = relationsUtility.FindMinRelationlevel(person3, person4);
            var relation2To4 = relationsUtility.FindMinRelationlevel(person2, person4);
            var relation2To5 = relationsUtility.FindMinRelationlevel(person2, person5);
            var relation1To5 = relationsUtility.FindMinRelationlevel(person1, person5);

        }
    }
}
