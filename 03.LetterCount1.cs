namespace LetterCounter
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Letter-Count");

            Console.Write("Please enter a text: ");
            var input = Console.ReadLine();
            int noLetterCounts;

            var letterCounts = CountLetters(input, out noLetterCounts);

            PrintCounts(letterCounts, noLetterCounts);
        }

        public static int[] CountLetters(string str, out int noLetterCounts)
        {
            var letterCounts = new int[26];
            noLetterCounts = 0;

            foreach (char ch in str)
            {
                int letterIndex = Char.ToLower(ch) - 'a';
                if (letterIndex >= 0 && letterIndex < letterCounts.Length)
                {
                    letterCounts[letterIndex]++;
                }
                else
                {
                    noLetterCounts++;
                }
            }

            return letterCounts;
        }

        public static void PrintCounts(int[] letterCounts, int noLetterCounts)
        {
            Console.WriteLine();
            for (int i = 0; i < letterCounts.Length / 2; i++)
            {
                Console.Write($"{(char)(i + 'A')}: {letterCounts[i]}\t");
                Console.WriteLine($"{(char)(i + 13 + 'A')}: {letterCounts[i + 13]}\t");
            }
            Console.WriteLine($"Other: {noLetterCounts}");
        }
    }
}