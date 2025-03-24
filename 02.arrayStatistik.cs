using System;

namespace ArrayStatistic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Array Statistic");
            Console.WriteLine("**********************");

            // 1. Anzahl der Zahlen eingeben
            Console.Write("Please enter the count of numbers: ");
            int count = int.Parse(Console.ReadLine());

            // 2. Array für die Zahlen initialisieren
            int[] numbers = new int[count];

            // 3. Eingabe der Zahlen
            for (int i = 0; i < count; i++)
            {
                Console.Write($"Please enter {i + 1}. number: ");
                numbers[i] = int.Parse(Console.ReadLine());
            }

            // 4. Eingabe der unteren und oberen Grenze
            Console.Write("Please enter lower bound: ");
            int lowerBound = int.Parse(Console.ReadLine());

            Console.Write("Please enter upper bound: ");
            int upperBound = int.Parse(Console.ReadLine());

            // 5. Berechnung der Zahlen im Bereich
            int countInRange = 0;
            foreach (int number in numbers)
            {
                if (number >= lowerBound && number <= upperBound)
                {
                    countInRange++;
                }
            }

            // 6. Ausgabe des Ergebnisses
            Console.WriteLine($"{countInRange} numbers are in the range of [{lowerBound}..{upperBound}]");
            Console.WriteLine("**********************");
        }
    }
}
