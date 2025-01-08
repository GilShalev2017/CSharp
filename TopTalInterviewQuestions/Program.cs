// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

class Program
{
    private static string result;

    //static async Task Main()
    //{
    //    await SaySomething();
    //    Console.WriteLine(result);
    //}

    delegate void Printer();

    class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return this.Name;
        }
    }

    static void Main()
    {
        List<Printer> printers = new List<Printer>();
        int i = 0;
        for (; i < 10; i++)
        {
            printers.Add(delegate { Console.WriteLine(i); });
        }

        foreach (var printer in printers)
        {
            printer();
        }

        object[] array = new object[3];
        array[0] = 101;
        array[1] = "C#";
        Customer c = new Customer();
        c.ID = 55;
        c.Name = "Manish";
        array[2] = c;
        foreach (object obj in array)
        {
            Console.WriteLine(obj);
        }
        Console.ReadLine();


        SaySomething();
        Console.WriteLine(result);
    }

    static async Task<string> SaySomething()
    {
        await Task.Delay(5);
        //Thread.Sleep(5);
        result = "Hello world!";
        return "Something";
    }
}