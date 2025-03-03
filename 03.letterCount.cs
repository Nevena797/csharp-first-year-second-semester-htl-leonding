using System;

class LetterCounter
{
    static void Main()
    {
        Console.WriteLine("Letter-Count");
        Console.Write("Please enter a text: ");
        string input = Console.ReadLine();

        int[] letterCounts = new int[26];
        int otherCount = 0;

        foreach (char c in input)
        {
            if (char.IsLetter(c))
            {
                char upperChar = char.ToUpper(c);
                int index = upperChar - 'A';
                letterCounts[index]++;
            }
            else
            {
                otherCount++;
            }
        }

        PrintLetterCounts(letterCounts, otherCount);
    }

    static void PrintLetterCounts(int[] letterCounts, int otherCount)
    {
        for (int i = 0; i < 26; i += 2)
        {
            char letter1 = (char)('A' + i);
            char letter2 = (char)('A' + i + 1);

            string output = $"{letter1}: {letterCounts[i],-4}";

            if (i + 1 < 26)
            {
                output += $"{letter2}: {letterCounts[i + 1],-4}";
            }

            Console.WriteLine(output);
        }

        Console.WriteLine($"Other: {otherCount}");
    }
}

