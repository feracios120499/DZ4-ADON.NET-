using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string City { get; set; }
            public override string ToString()
            {
                return $"Name:{Name} Age:{Age} City:{City}";
            }
        }
        static List<Person> person = new List<Person>()
        {
            new Person() { Name = "Andrey", Age = 24, City = "Kyiv" },
            new Person() { Name = "Liza", Age = 18, City = "Moscow" },
            new Person() { Name = "Oleg", Age = 15, City = "London" },
            new Person() { Name = "Sergey", Age = 55, City = "Kyiv" },
            new Person() { Name = "Sergey", Age = 32, City = "Kyiv" } };
        public static void Show(List<Person> person)
        {
            foreach(var item in person)
            {
                Console.WriteLine(item);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Все:");
            Show(person);

            Console.WriteLine();
            Console.WriteLine("1)Выбрать людей, старших 25 лет.");
            var list = person.FindAll(p => p.Age > 25);
            Show(list);

            Console.WriteLine();
            Console.WriteLine("2)Выбрать людей, проживающих не в Киеве.");
            list = person.FindAll(p => p.City != "Kyiv");
            Show(list);

            Console.WriteLine();
            Console.WriteLine("3)Выбрать имена людей, проживающих в Киеве.");
            var listName = person.Where(p => p.City == "Kyiv").Select(p => p.Name);
            foreach(var item in listName)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.WriteLine("4)Выбрать людей старших 35 лет с именем Sergey");
            list = person.FindAll(p => p.Age > 35&&p.Name=="Sergey");
            Show(list);

            Console.WriteLine();
            Console.WriteLine("5)Выбрать людей, проживающих в Москве.");
            list = person.FindAll(p => p.City=="Moscow");
            Show(list);
        }
    }
}
