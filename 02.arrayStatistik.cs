using System;

namespace ArrayStatistic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Array Statistic");
            Console.WriteLine("**********************");


            Console.Write("Please enter the count of numbers: ");
            int count = int.Parse(Console.ReadLine());


            int[] numbers = new int[count];


            for (int i = 0; i < count; i++)
            {
                Console.Write($"Please enter {i + 1}. number: ");
                numbers[i] = int.Parse(Console.ReadLine());
            }


            Console.Write("Please enter lower bound: ");
            int lowerBound = int.Parse(Console.ReadLine());

            Console.Write("Please enter upper bound: ");
            int upperBound = int.Parse(Console.ReadLine());


            int countInRange = 0;
            foreach (int number in numbers)
            {
                if (number >= lowerBound && number <= upperBound)
                {
                    countInRange++;
                }
            }

            Console.WriteLine($"{countInRange} numbers are in the range of [{lowerBound}..{upperBound}]");
            Console.WriteLine("**********************");
        }
    }
}
