/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 4ACIF
*--------------------------------------------------------------
*              HA Nevena Rogova
*--------------------------------------------------------------
* Description: 18_0 LottoQuickTipp (optional)
*--------------------------------------------------------------
*/


using System;
using System.Linq;

class LottoQuickTip
{
    private const int NumberOfTips = 10; // Anzahl der generierten Tipps
    private const int NumbersPerTip = 6; // Anzahl der Zahlen pro Tipp

    public static void Main()
    {
        int maxNo = 45; // Maximale Zahl für das Lotto

        Console.WriteLine("Lotto-Quicktip:");
        Console.WriteLine("****************");

        for (int i = 1; i <= NumberOfTips; i++)
        {
            int[] tip = GenerateUniqueSortedNumbers(NumbersPerTip, maxNo);
            Console.WriteLine($"{i}. Quick-Tip: {TipToString(tip)}");
        }
    }

    static int[] GenerateUniqueSortedNumbers(int count, int maxNo)
    {
        Random rand = new Random();
        int[] numbers = new int[count];
        int index = 0;

        while (index < count)
        {
            int num = rand.Next(1, maxNo + 1);
            if (!numbers.Contains(num))
            {
                numbers[index] = num;
                index++;
            }
        }

        Array.Sort(numbers);
        return numbers;
    }

    static string TipToString(int[] numbers)
    {
        return string.Join(",", numbers);
    }
}