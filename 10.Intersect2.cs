using System;
using System.Collections.Generic;

namespace ArrayIntersection
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbersA = { 1, 3, 5, 7, 9 };
            int[] numbersB = { 0, 1, 2, 3 };

            int[] result = Intersect(numbersA, numbersB);

            Console.WriteLine("Intersection: " + string.Join(", ", result));
        }

        // Implementierung der Intersect-Methode
        public static int[] Intersect(int[] array1, int[] array2)
        {
            // Eine Liste, um die Schnittmengen zu speichern
            List<int> intersection = new List<int>();

            // Durchlaufe jedes Element im ersten Array
            foreach (var item in array1)
            {
                // Überprüfe, ob das Element im zweiten Array existiert
                if (Array.Exists(array2, element => element == item))
                {
                    // Füge das Element zur Liste hinzu, wenn es nicht schon dort ist
                    if (!intersection.Contains(item))
                    {
                        intersection.Add(item);
                    }
                }
            }

            // Gib die Schnittmenge als Array zurück
            return intersection.ToArray();
        }
    }
}