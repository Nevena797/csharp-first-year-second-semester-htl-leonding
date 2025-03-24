using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        int[] numbers = new int[10]; // Initialisierung des Arrays mit 10 Elementen

        // Das Array mit Zahlen füllen
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = (i + 1) * 2; // Jedes Element ist das Doppelte des Index + 1
        }

        // Durchlaufen mit einer for-Schleife
        Console.WriteLine("Array mit for:");
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine(numbers[i]); // Jedes Element ausgeben
        }

        // Durchlaufen mit einer foreach-Schleife
        Console.WriteLine("\nArray mit foreach:");
        foreach (int number in numbers)
        {
            Console.WriteLine(number); // Jedes Element ausgeben
        }

        // Methode aufrufen, um das Array zu modifizieren
        IntArray(ref numbers);

        // Das modifizierte Array ausgeben
        Console.WriteLine("\nModifiziertes Array:");
        foreach (int number in numbers)
        {
            Console.WriteLine(number); // Die neuen Werte ausgeben
        }
    }

    private static void IntArray(ref int[] numbers)
    {
        numbers = new int[20]; // Ein neues Array mit 20 Elementen erstellen

        // Das neue Array mit Werten füllen
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = i * 2; // Jedes Element ist das Doppelte des Index
        }
    }
}
