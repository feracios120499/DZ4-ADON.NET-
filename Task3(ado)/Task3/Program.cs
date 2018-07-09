using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int DepId { get; set; }
        public override string ToString()
        {
            return $"FirstName:{FirstName} LastName:{LastName} Age:{Age}";
        }
    }
    class Department
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
    class Program
    {
        static void Main()
        {
            List<Department> departments = new List<Department>()
            {
                new Department(){ Id = 1, Country = "Ukraine", City = "Donetsk" },
                new Department(){ Id = 2, Country = "Ukraine", City = "Kyiv" },
                new Department(){ Id = 3, Country = "France", City = "Paris" },
                new Department(){ Id = 4, Country = "Russia", City = "Moscow" }
                };

            List<Employee> employees = new List<Employee>()
            {
                new Employee()
                { Id = 1, FirstName = "Tamara", LastName = "Ivanova", Age = 22, DepId = 2 },
                new Employee()
                { Id = 2, FirstName = "Nikita", LastName = "Larin", Age = 33, DepId = 1 },
                new Employee()
                { Id = 3, FirstName = "Alica", LastName = "Ivanova", Age = 43, DepId = 3 },
                new Employee()
                { Id = 4, FirstName = "Lida", LastName = "Marusyk", Age = 22, DepId = 2 },
                new Employee()
                { Id = 5, FirstName = "Lida", LastName = "Voron", Age = 36, DepId = 4 },
                new Employee()
                { Id = 6, FirstName = "Ivan", LastName = "Kalyta", Age = 22, DepId = 2 },
                new Employee()
                { Id = 7, FirstName = "Nikita", LastName = " Krotov ", Age = 27,DepId = 4 }
            };
            var list = from empl in employees
                       join dep in departments on empl.DepId equals dep.Id
                       where dep.Country == "Ukraine"
                       orderby empl.FirstName 
                       orderby empl.LastName
                       select empl;
            foreach(var item in list)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            var list2 = from empl in employees
                        orderby empl.Age descending
                        select new { Id = empl.Id, FirstName = empl.FirstName, LastName = empl.LastName, Age = empl.Age };
            foreach(var item in list2)
            {
                Console.WriteLine($"Id:{item.Id} FirstName:{item.FirstName} LastName:{item.LastName} Age:{item.Age}");
            }

            Console.WriteLine();
            var list3 = from empl in employees
                        group empl by empl.Age into g
                        select new { Age = g.Key, Count = g.Count() };
                        
                        
            foreach (var item in list3)
            {
                Console.WriteLine($"Age:{item.Age} Count:{item.Count}");
            }

        }
    }
}
