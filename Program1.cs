using System;
using System.Collections.Generic;
using System.Linq;

namespace Program1
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Sample list of Person objects
            List<Person> people = new List<Person>
        {
            new Person { Name = "Alice", Age = 25 },
            new Person { Name = "Bob", Age = 30 },
            new Person { Name = "Charlie", Age = 22 },
            new Person { Name = "David", Age = 28 },
            new Person { Name = "Eva", Age = 25 }
        };

            // Example 1: Filtering using LINQ
            var adults = people.Where(person => person.Age >= 18);
            Console.WriteLine("Adults:");
            foreach (var person in adults)
            {
                Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
            }

            // Example 2: Sorting using LINQ
            var sortedByName = people.OrderBy(person => person.Name);
            Console.WriteLine("\nSorted by Name:");
            foreach (var person in sortedByName)
            {
                Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
            }

            // Example 3: Projection using LINQ
            var namesOnly = people.Select(person => person.Name);
            Console.WriteLine("\nNames Only:");
            foreach (var name in namesOnly)
            {
                Console.WriteLine(name);
            }

            //Example 4: Then by
            var thenByResult = people.OrderBy(person => person.Name).ThenBy(person => person.Age);
            Console.WriteLine("\nOrder list:");
            foreach (var std in thenByResult)
            {
                Console.WriteLine("Name: {0}, Age:{1}", std.Name, std.Age);
            }

            // Grouping by Age using LINQ
            var groupedByAge = people.GroupBy(person => person.Age);

            // Displaying groups
            foreach (var group in groupedByAge)
            {
                Console.WriteLine($"People aged {group.Key}:");
                foreach (var person in group)
                {
                    Console.WriteLine($"  Name: {person.Name}");
                }
                Console.WriteLine();
            }

            var ageLookup = people.ToLookup(person => person.Age);

            // Accessing groups using the key
            int targetAge = 25;
            var peopleWithTargetAge = ageLookup[targetAge];

            // Displaying people with the target age
            Console.WriteLine($"People aged {targetAge}:");
            foreach (var person in peopleWithTargetAge)
            {
                Console.WriteLine($"  Name: {person.Name}");
            }
        }
    }
}