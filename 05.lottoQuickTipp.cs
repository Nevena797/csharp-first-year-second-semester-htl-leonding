using System;
using System.Linq; // System.Linq wird genutzt,
                   // um numbers.Contains(newNumber) zu verwenden (prüft, ob eine Zahl bereits enthalten ist).

class LottoQuickTipp
{
    static Random random = new Random();// ein Zufallszahlen-Objekt random

    static int[] GenerateLottoNumbers(int maxNumber, int count)
    {
        int[] numbers = new int[count];
        int index = 0;

        while (index < count)
        {
            int newNumber = random.Next(1, maxNumber + 1);
            if (!numbers.Contains(newNumber))
            {
                numbers[index++] = newNumber;
            }
        }

        Array.Sort(numbers);
        return numbers;
    }

    static void Main()
    {
        // Konfigurierbare Parameter für verschiedene Lotto-Versionen
        int maxNumber = 45; // Österreich: 45, Deutschland: 49
        int numberCount = 6; // Standard: 6, andere Varianten möglich
        int quickTipCount = 10; // Anzahl der Quick-Tipps

        Console.WriteLine("Lotto-Quicktip:");
        Console.WriteLine("****************");

        for (int i = 1; i <= quickTipCount; i++)
        {
            int[] quickTip = GenerateLottoNumbers(maxNumber, numberCount);
            Console.WriteLine($"{i}. Quick-Tip: {string.Join(",", quickTip)}");
        }

        Console.WriteLine("\n<Eingabetaste für ENDE>");
        Console.ReadLine();
    }
}