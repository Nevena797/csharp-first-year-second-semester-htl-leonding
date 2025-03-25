namespace Distinct
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Distinct");
            Console.WriteLine("**********************");

            var ar = EnterArray();

            Console.Write($"Input:      {ToString(ar)}");
            if (DistinctTools.IsDistinct(ar))
            {
                Console.WriteLine(" => The array is distinct");
            }
            else
            {
                Console.WriteLine(" => The array is NOT distinct");
            }

            Console.WriteLine($"Distinct:   {ToString(DistinctTools.Distinct(ar))}");
            Console.WriteLine($"Duplicates: {ToString(DistinctTools.Duplicate(ar))}");
        }

        private static int[] EnterArray()
        {
            Console.Write("Please enter the count of numbers: ");

            var countOfNumbers = int.Parse(Console.ReadLine());
            var intNumbers = new int[countOfNumbers];

            for (var i = 0; i < countOfNumbers; i++)
            {
                Console.Write($"Please enter {i + 1}. number: ");
                intNumbers[i] = int.Parse(Console.ReadLine());
            }

            return intNumbers;
        }

        static string ToString(int[] ar)
        {
            var result = string.Empty;
            foreach (var val in ar)
            {
                if (!string.IsNullOrEmpty(result))
                {
                    result += ", ";
                }

                result += val;
            }

            return result;
        }
    }
    //Diese Methode überprüft, ob alle Elemente im Array eindeutig sind.
    public static class DistinctTools
    {
        public static bool IsDistinct(int[] ar)
        {
            for (int i = 0; i < ar.Length; i++)
            {
                for (int j = i + 1; j < ar.Length; j++)
                {
                    if (ar[j] == ar[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        //Diese Methode gibt ein Array mit eindeutigen Werten zurück.
        public static int[] Distinct(int[] ar)
        {
            int[] result = new int[ar.Length];
            int resultLength = 0;

            for (int i = 0; i < ar.Length; i++)
            {
                if (!Contains(result, ar[i], 0, resultLength))
                {
                    result[resultLength++] = ar[i];
                }
            }
            return Copy(result, resultLength);
        }

        //Diese Methode ermittelt alle doppelten Werte im Array und gibt sie zurück.
        public static int[] Duplicate(int[] ar)
        {
            int[] result = new int[ar.Length];
            int resultLength = 0;

            for (int i = 0; i < ar.Length; i++)
            {
                if (!Contains(result, ar[i], 0, resultLength) && Contains(ar, ar[i], i + 1, ar.Length))
                {
                    result[resultLength++] = ar[i];
                }
            }
            return Copy(result, resultLength);
        }

        private static bool Contains(int[] ar, int value, int startIdx, int length)
        {
            for (int i = startIdx; i < length; i++)
            {
                if (value == ar[i])
                {
                    return true;
                }
            }
            return false;
        }

        private static int[] Copy(int[] ar, int length)
        {
            var result = new int[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = ar[i];
            }
            return result;
        }
    }
}