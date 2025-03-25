using System;
using System.Linq;
using System.Collections.Generic;

class DistinctChecker
{
    static bool IsDistinct(int[] numbers)
    {
        return numbers.Distinct().Count() == numbers.Length;
    }

    static int[] GetDistinctValues(int[] numbers)
    {
        return numbers.Distinct().ToArray();
    }

    static int[] GetDuplicateValues(int[] numbers)
    {
        return numbers.GroupBy(n => n)
                      .Where(g => g.Count() > 1)
                      .Select(g => g.Key)
                      .ToArray();
    }

    static void Main()
    {
        Console.Write("Please enter the count of numbers: ");
        int count;
        while (!int.TryParse(Console.ReadLine(), out count) || count <= 0)
        {
            Console.Write("Invalid input. Please enter a positive number: ");
        }

        int[] numbers = new int[count];
        for (int i = 0; i < count; i++)
        {
            Console.Write($"Please enter {i + 1}. number: ");
            while (!int.TryParse(Console.ReadLine(), out numbers[i]))
            {
                Console.Write($"Invalid input. Please enter {i + 1}. number again: ");
            }
        }

        Console.WriteLine($"Input: {string.Join(", ", numbers)} => The array is {(IsDistinct(numbers) ? "DISTINCT" : "NOT DISTINCT")}");
        Console.WriteLine($"Distinct: {string.Join(", ", GetDistinctValues(numbers))}");

        int[] duplicates = GetDuplicateValues(numbers);
        Console.WriteLine($"Duplicates: {(duplicates.Length > 0 ? string.Join(", ", duplicates) : "None")}");
    }
}