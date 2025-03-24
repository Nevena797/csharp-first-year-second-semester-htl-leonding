using System;

class Program
{
    static void Main()
    {
        int[] numbersA = { 1, 3, 5, 7, 9 };
        int[] numbersB = { 0, 1, 2, 3 };

        // Aufruf der Intersect-Methode
        int[] result = IntersectTools.Intersect(numbersA, numbersB);

        // Ausgabe des Ergebnisses
        Console.WriteLine("Gemeinsame Zahlen: " + string.Join(", ", result));
    }
    public static class IntersectTools
    {
        public static int[] Intersect(int[] array1, int[] array2)
        {
            // Entfernt Duplikate und bestimmt die gemeinsamen Elemente zwischen beiden Arrays
            return array1.Distinct().Intersect(array2.Distinct()).ToArray();
        }
    }
}
