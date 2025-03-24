using System;
using System.Linq;
using System.Collections.Generic;

class LottoSchnellTipp
{
    private const int AnzahlTipps = 10; // Anzahl der generierten Tipps
    private const int ZahlenProTipp = 6; // Anzahl der Zahlen pro Tipp
    private static Random zufall = new Random(); // Globale Random-Instanz

    public static void Main()
    {
        int maxZahl = 45; // Maximale Zahl für das österreichische Lotto

        Console.WriteLine("Lotto-SchnellTipp:");
        Console.WriteLine("******************");

        for (int i = 1; i <= AnzahlTipps; i++)
        {
            int[] tipp = ErzeugeEindeutigeSortierteZahlen(ZahlenProTipp, maxZahl);
            Console.WriteLine($"{i}. Schnell-Tipp: {TippAlsString(tipp)}");
        }
    }

    static int[] ErzeugeEindeutigeSortierteZahlen(int anzahl, int maxZahl)
    {
        HashSet<int> zahlen = new HashSet<int>();

        while (zahlen.Count < anzahl)
        {
            zahlen.Add(zufall.Next(1, maxZahl + 1));
        }

        int[] sortierteZahlen = zahlen.ToArray();
        Array.Sort(sortierteZahlen);
        return sortierteZahlen;
    }

    static string TippAlsString(int[] zahlen)
    {
        return string.Join(", ", zahlen);
    }
}