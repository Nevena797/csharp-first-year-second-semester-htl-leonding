using System;
using System.Diagnostics;

class SiebDesEratosthenes
{
    static void Main()
    {
        int upperLimit;
        do
        {
            Console.Write("Bis zu welcher Zahl wollen Sie Primzahlen ausgeben? ");
        } while (!int.TryParse(Console.ReadLine(), out upperLimit) || upperLimit <= 1);

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        bool[] isPrime = new bool[upperLimit + 1];
        for (int i = 2; i <= upperLimit; i++)
        {
            isPrime[i] = true;
        }

        for (int i = 2; i * i <= upperLimit; i++)
        {
            if (isPrime[i])
            {
                for (int j = i * i; j <= upperLimit; j += i)
                {
                    isPrime[j] = false;
                }
            }
        }

        stopwatch.Stop();

        Console.WriteLine($"Primzahlen von 1 - {upperLimit}:");
        int count = 0;
        foreach (int i in Enumerable.Range(2, upperLimit - 1))
        {
            if (isPrime[i])
            {
                Console.WriteLine(i);
                count++;
            }
        }

        Console.WriteLine("<Eingabetaste für ENDE>");
        Console.ReadLine();
    }
}
