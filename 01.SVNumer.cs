using System;

namespace SVNummerChecker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Check a SV Number");
            Console.WriteLine("**********************");

            while (true)
            {
                Console.Write("Please enter a SV Number: ");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Exiting program. Goodbye!");
                    break;
                }

                if (IsValidSVNumber(input))
                {
                    Console.WriteLine($"The SV Number \"{input}\" is valid.\n");
                }
                else
                {
                    Console.WriteLine($"The SV Number \"{input}\" is invalid.\n");
                }
            }
        }

        static bool IsValidSVNumber(string svNumber)
        {
            if (svNumber.Length != 10 || !IsAllDigits(svNumber))
            {
                return false;
            }

            int[] weights = { 3, 7, 9, 0, 5, 8, 4, 2, 1, 6 };
            int checksum = 0;

            for (int i = 0; i < 10; i++)
            {
                int digit = svNumber[i] - '0'; // Zeichen in Ziffer umwandeln
                checksum += digit * weights[i];
            }

            int expectedCheckDigit = checksum % 11;
            int actualCheckDigit = svNumber[3] - '0';

            return expectedCheckDigit == actualCheckDigit;
        }

        static bool IsAllDigits(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
