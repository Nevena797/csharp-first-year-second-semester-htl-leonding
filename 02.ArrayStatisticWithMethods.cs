using System;

namespace ArrayStatisticWithMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Display the title
            PrintHeader();

            // Read the count of numbers
            int countOfNumbers = ReadNumber("Please enter the count of numbers: ");

            // Read and store the numbers in an array
            int[] intNumbers = ReadNumbers(countOfNumbers);

            // Read lower and upper bounds
            int minBound = ReadNumber("Please enter lower bound: ");
            int maxBound = ReadNumber("Please enter upper bound: ");

            // Count numbers within the range
            int countInRange = CountNumbersInRange(intNumbers, minBound, maxBound);

            // Print the result
            PrintResult(countInRange, minBound, maxBound);
        }

        /// Prints the program header.
        static void PrintHeader()
        {
            Console.WriteLine("Array Statistic");
            Console.WriteLine("**********************");
        }

        /// Reads an integer from the console with a given prompt.

        static int ReadNumber(string message)
        {
            Console.Write(message);
            return int.Parse(Console.ReadLine());
        }

        /// Reads a set of numbers from the user.

        static int[] ReadNumbers(int count)
        {
            int[] numbers = new int[count];

            for (int i = 0; i < count; i++)
            {
                numbers[i] = ReadNumber($"Please enter {i + 1}. number: ");
            }

            return numbers;
        }

        /// Counts the numbers that fall within the specified range.

        static int CountNumbersInRange(int[] numbers, int minBound, int maxBound)
        {
            int count = 0;

            foreach (int num in numbers)
            {
                if (num >= minBound && num <= maxBound)
                {
                    count++;
                }
            }

            return count;
        }

        /// Prints the result of the count within the specified range.

        static void PrintResult(int count, int minBound, int maxBound)
        {
            if (count > 0)
            {
                Console.WriteLine($"{count} numbers are in the range of [{minBound}..{maxBound}]");
            }
            else
            {
                Console.WriteLine($"No number is in the range of [{minBound}..{maxBound}]");
            }
        }
    }
}
