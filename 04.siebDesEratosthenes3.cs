using System;

class Program
{
    static bool[] SiebDesEratosthenes(int maxZahl)
    {
        bool[] istPrim = new bool[maxZahl + 1];
        for (int i = 2; i <= maxZahl; i++) istPrim[i] = true;

        int maxPrüfung = (int)Math.Sqrt(maxZahl);
        for (int i = 2; i <= maxPrüfung; i++)
        {
            if (istPrim[i])
            {
                for (int multiplikator = 2; (multiplikator * i) <= maxZahl; multiplikator++)
                {
                    istPrim[multiplikator * i] = false;
                }
            }
        }
        return istPrim;
    }

    static void Main()
    {
        Console.Write("Bis zu welcher Zahl wollen Sie Primzahlen ausgeben? ");
        int zahl = int.Parse(Console.ReadLine());

        Console.WriteLine($"\nPrimzahlen von 1 - {zahl}:");

        bool[] primzahlen = SiebDesEratosthenes(zahl);
        for (int i = 2; i <= zahl; i++)
        {
            if (primzahlen[i])
                Console.WriteLine(i);
        }

        Console.WriteLine("\n<Eingabetaste für ENDE>");
        Console.ReadLine();
    }
}
