using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int num;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        do
        {
            Console.Write("Enter number: ");
            num = Convert.ToInt32(Console.ReadLine());
            if (num != 0)
                numbers.Add(num);
        } while (num != 0);

        // Core Requirements
        int sum = numbers.Sum();
        double average = numbers.Average();
        int max = numbers.Max();

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");

        // Stretch Challenge
        List<int> positiveNumbers = numbers.Where(x => x > 0).ToList();
        int smallestPositive = positiveNumbers.Min();

        Console.WriteLine($"The smallest positive number is: {smallestPositive}");

        Console.WriteLine("The sorted list is:");
        numbers.Sort();
        foreach (int n in numbers)
        {
            Console.WriteLine(n);
        }
    }
}
