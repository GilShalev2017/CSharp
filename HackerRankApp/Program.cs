namespace Solution
{
    public class Solution
    {
        public static Dictionary<string, int> GooglAIAverageAgeForEachCompany(List<Employee> employees)
        {
            Dictionary<string, int> averageAges = (Dictionary<string, int>)employees
                .GroupBy(e => e.Company)
                .Select(group => new
                {
                    Company = group.Key,
                    AverageAge = (int)(group.Average(e => e.Age))
                });
            return averageAges;
        }
        public static Dictionary<string, int> GooglAICountOfEmployeesForEachCompany(List<Employee> employees)
        {
            Dictionary<string, int> employeeCounts = (Dictionary<string, int>)employees
               .GroupBy(e => e.Company)
               .Select(group => new
               {
                   Company = group.Key,
                   Count = group.Count()
               });
            return employeeCounts;
        }

        public static Dictionary<string, Employee> GooglAIOldestAgeForEachCompany(List<Employee> employees)
        {
            Dictionary<string, Employee> oldestAges = employees
           .GroupBy(e => e.Company)
           .Select(group => group.OrderByDescending(e => e.Age).FirstOrDefault()) // Select the single oldest employee from each group
           .Where(e => e != null) // Filter out any potential nulls if groups were empty (though unlikely here)
           .ToDictionary(e => e.Company, e => e); // Convert the result list into a Dictionary

            return oldestAges;
        }

        public static Dictionary<string, int> AverageAgeForEachCompany(List<Employee> employees)
        {
            var groupedByCompany = employees.GroupBy(emp => emp.Company);
           
            var dicResult = new Dictionary<string, int>();

            foreach (var group in groupedByCompany)
            {
                // Sum ages and divide by count (integer division)
                int totalAge = group.Sum(emp => emp.Age);

                dicResult.Add(group.Key, totalAge / group.Count());
            }

            return dicResult;
        }

        public static Dictionary<string, int> CountOfEmployeesForEachCompany(List<Employee> employees)
        {
            var groupedByCompany = employees.GroupBy(emp => emp.Company);
          
            var dicResult = new Dictionary<string, int>();

            foreach (var group in groupedByCompany)
            {
                dicResult.Add(group.Key, group.Count());
            }

            return dicResult;
        }

        public static Dictionary<string, Employee> OldestAgeForEachCompany(List<Employee> employees)
        {
            var groupedByCompany = employees.GroupBy(emp => emp.Company);
            var dicResult = new Dictionary<string, Employee>();

            foreach (var group in groupedByCompany)
            {
                // Find the employee with max age
                var oldestEmp = group.OrderByDescending(emp => emp.Age).First();
            
                dicResult.Add(group.Key, oldestEmp);
            }

            return dicResult;
        }

        public static void Main()
        {
            int countOfEmployees = int.Parse(Console.ReadLine());

            var employees = new List<Employee>();

            for (int i = 0; i < countOfEmployees; i++)
            {
                string str = Console.ReadLine();
                string[] strArr = str.Split(' ');
                employees.Add(new Employee
                {
                    FirstName = strArr[0],
                    LastName = strArr[1],
                    Company = strArr[2],
                    Age = int.Parse(strArr[3])
                });
            }

            foreach (var emp in AverageAgeForEachCompany(employees))
            {
                Console.WriteLine($"The average age for company {emp.Key} is {emp.Value}");
            }

            foreach (var emp in CountOfEmployeesForEachCompany(employees))
            {
                Console.WriteLine($"The count of employees for company {emp.Key} is {emp.Value}");
            }

            foreach (var emp in OldestAgeForEachCompany(employees))
            {
                Console.WriteLine($"The oldest employee of company {emp.Key} is {emp.Value.FirstName} {emp.Value.LastName} having age {emp.Value.Age}");
            }

            foreach (var emp in GooglAIOldestAgeForEachCompany(employees))
            {
                Console.WriteLine($"The oldest employee of company {emp.Key} is {emp.Value.FirstName} {emp.Value.LastName} having age {emp.Value.Age}");
            }
            
        }
    }

    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Company { get; set; }
    }
}