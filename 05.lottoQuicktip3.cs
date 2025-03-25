using System;

namespace LottoQuickTip
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Lotto-Quicktip:");
            Console.WriteLine("****************");


            for (int i = 1; i <= 10; i++)
            {
                int[] quickTip = GenerateLottoNumbers(6, 45); 
                Console.WriteLine($"{i}. Quick-Tip: {FormatNumbers(quickTip)}");
            }
        }
        static int[] GenerateLottoNumbers(int count, int maxNumber)
        {
            int[] numbers = new int[count]; 
            Random rand = new Random();

            for (int i = 0; i < count; i++)
            {
                int newNumber;
                bool alreadyExists; 

                do
                {
                    newNumber = rand.Next(1, maxNumber + 1); 
                    alreadyExists = false; 


                    for (int j = 0; j < i; j++)
                    {
                        if (numbers[j] == newNumber)
                        {
                            alreadyExists = true; 
                            break; 
                        }
                    }

                } while (alreadyExists); 

                numbers[i] = newNumber; 
            }

            Array.Sort(numbers); 
            return numbers;
        }

        static string FormatNumbers(int[] numbers)
        {
            return string.Join(",", numbers);
        }
    }
}
