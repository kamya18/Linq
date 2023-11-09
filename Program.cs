// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
using System;
using System.Collections.Generic;
using System.Linq;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Example 1: Filtering using LINQ
            var evenNumbers = numbers.Where(n => n % 2 == 0);
            Console.WriteLine("Even Numbers:");
            foreach (var num in evenNumbers)
            {
                Console.WriteLine(num);
            }

            // Example 2: Mapping using LINQ
            var squaredNumbers = numbers.Select(n => n * n);
            Console.WriteLine("\nSquared Numbers:");
            foreach (var num in squaredNumbers)
            {
                Console.WriteLine(num);
            }

            // Example 3: Aggregation using LINQ
            var sum = numbers.Sum();
            Console.WriteLine($"\nSum of Numbers: {sum}");

            var avg = numbers.Average();
            Console.WriteLine($"\nAverage of Numbers: {avg}");

            var count = numbers.Count();
            Console.WriteLine($"\nNo. of Numbers: {count}");

            var max = numbers.Max();
            Console.WriteLine($"\nMaximum from Numbers: {max}");

            int index = 3;
            if (index >= 0 && index < numbers.Count)
            {
                var element = numbers.ElementAt(index);
                Console.WriteLine($"\nElement at index {index}: {element}");
            }
            else
            {
                Console.WriteLine($"\nInvalid index. Index should be between 0 and {numbers.Count - 1}.");
            }

            // Example 4: Using Single to get the single element that satisfies a condition
            int targetNumber = 7;
            var singleElement = numbers.Single(n => n == targetNumber);

            Console.WriteLine($"\nSingle element equal to {targetNumber}: {singleElement}");
        }
    }
}