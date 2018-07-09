using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
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
    class Department { public int Id { get; set; } public string Country { get; set; } public string City { get; set; } }
    class Program
    {
        static void Main()
        {
            List<Department> departments = new List<Department>()
            {
                new Department() { Id = 1, Country = "Ukraine", City = "Donetsk" },
                new Department() { Id = 2, Country = "Ukraine", City = "Kyiv" },
                new Department() { Id = 3, Country = "France", City = "Paris" },
                new Department() { Id = 4, Country = "Russia", City = "Moscow" } };
            List<Employee> employees = new List<Employee>()
            {
                new Employee() { Id = 1, FirstName = "Tamara", LastName = "Ivanova", Age = 22, DepId = 2 },
                new Employee() { Id = 2, FirstName = "Nikita", LastName = "Larin", Age = 33, DepId = 1 },
                new Employee() { Id = 3, FirstName = "Alica", LastName = "Ivanova", Age = 43, DepId = 3 },
                new Employee() { Id = 4, FirstName = "Lida", LastName = "Marusyk", Age = 22, DepId = 2 },
                new Employee() { Id = 5, FirstName = "Lida", LastName = "Voron", Age = 36, DepId = 4 },
                new Employee() { Id = 6, FirstName = "Ivan", LastName = "Kalyta", Age = 24, DepId = 2 },
                new Employee() { Id = 7, FirstName = "Nikita", LastName = " Krotov ", Age = 27, DepId = 4 } };
            
            var list1 = from empl in employees
                       join dep in departments on empl.DepId equals dep.Id
                       where dep.Country == "Ukraine" && dep.City != "Donetsk"
                       select new { FirstName = empl.FirstName, LastName = empl.LastName };
            Console.WriteLine("1)Выбрать имена и фамилии сотрудников, работающих в Украине, но не в Донецке.");
            foreach(var item in list1)
            {
                Console.WriteLine($"FirstName:{item.FirstName} LastName:{item.LastName}");
            }

            Console.WriteLine();
            Console.WriteLine("2)Вывести список стран без повторений.");
            var list2 = departments.Select(p => p.Country).Distinct();
            foreach(var item in list2)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.WriteLine("3)Выбрать 3-x первых сотрудников, возраст которых превышает 25 лет.");
            var list3 = employees.Where(p => p.Age > 25).Take(3);
            foreach (var item in list3)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.WriteLine("4)Выбрать имена, фамилии и возраст студентов из Киева, возраст которых превышает 23 года");
            var list4 = from empl in employees
                        join dep in departments on empl.DepId equals dep.Id
                        where dep.City=="Kyiv" && empl.Age>23
                        select new { FirstName = empl.FirstName, LastName = empl.LastName,Age=empl.Age};
            foreach (var item in list4)
            {
                Console.WriteLine($"FirstName:{item.FirstName} LastName:{item.LastName} Age:{item.Age}");
            }
        }
    }

}
