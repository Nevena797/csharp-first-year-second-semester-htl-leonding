using System;
using System.Linq;

namespace ArrayIntersection
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbersA = { 1, 3, 5, 7, 9 };
            int[] numbersB = { 0, 1, 2, 3 };

            int[] result = IntersectTools.Intersect(numbersA, numbersB);

            Console.WriteLine("Intersection: " + string.Join(", ", result));
        }
    }

    public static class IntersectTools
    {
        public static int[] Intersect(int[] array1, int[] array2)
        {
            return array1.Intersect(array2).ToArray();
        }
    }
}
