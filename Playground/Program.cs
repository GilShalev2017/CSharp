using System.Net.Sockets;
using System.Reflection;

class Utility
{
    public static char SpaceCharacter = ' ';
    public static HashSet<object> ComplexObjects = new HashSet<object>();
    public static void PrintInstanceProperties(object myObject, int indentation, TextWriter output)
    {
        if(myObject == null)
        {
            return;
        }
        if(!ComplexObjects.Contains(myObject))
        {
            ComplexObjects.Add(myObject);
        }
        Type type = myObject.GetType();

        var indentationString = new string(SpaceCharacter, indentation*5);

        output.WriteLine($"{indentationString}{type.Name} properties:");

        PropertyInfo[] properties = type.GetProperties();

        foreach (PropertyInfo property in properties)
        {
            bool isComplex = IsComplexType(property);
            if (!isComplex)
            {
                output.WriteLine($"{indentationString}{property.Name} = {property.GetValue(myObject)}");
            }
            else
            {
                if (!ComplexObjects.Contains(property.GetValue(myObject)))
                {
                    output.WriteLine($"{property.Name} properties:");
                    PrintInstanceProperties(property.GetValue(myObject), indentation + 1,output);
                }
            }
        }
    }

    public static bool IsComplexType(PropertyInfo property)
    {
        string propertyTypeName = property.PropertyType.Name;
        if (propertyTypeName.ToLower() == "string" || 
            propertyTypeName.ToLower() == "float" ||
            propertyTypeName.ToLower() == "decimal" || 
            propertyTypeName.ToLower() == "int32") 
            return false;
        return true;
    }
    public class Person
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public Person? Partner { get; set; }
        public Person(string  fullName, string address,int age)
        {
            FullName = fullName;
            Address=address; 
            Age = age;
        }
     
    }
    public static void Main()
    {
        Person person1 = new Person("Gil Shalev", "Bialik 74/25 Ramat-Gan", 54);
        Person person2 = new Person("Ed Providel", "Bialik 74/25 Ramat-Gan", 57);

        person1.Partner = person2;
        person2.Partner = person1;

        PrintInstanceProperties(person1,0, Console.Out);

        using (StreamWriter fileWriter = new StreamWriter("output.txt"))
        {
            PrintInstanceProperties(person1, 0, fileWriter);
        };
       
    }
}
