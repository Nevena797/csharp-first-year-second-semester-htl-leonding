namespace _02.ArrayStatistic1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ausgabe des Titels
            Console.WriteLine("Array Statistic");
            Console.WriteLine("**********************");

            // Anzahl der Zahlen vom Benutzer einlesen
            Console.Write("Please enter the count of numbers: ");
            int countOfNumbers = int.Parse(Console.ReadLine());

            // Array mit der eingegebenen Größe erstellen
            int[] intNumbers = new int[countOfNumbers];

            // Zahlen vom Benutzer einlesen und im Array speichern
            for (int i = 0; i < countOfNumbers; i++)
            {
                Console.Write($"Please enter {i + 1}. number: ");
                intNumbers[i] = int.Parse(Console.ReadLine());
            }

            // Untere Grenze (minBound) vom Benutzer einlesen
            Console.WriteLine("Please enter lower bound: ");
            int minBound = int.Parse(Console.ReadLine());

            // Obere Grenze (maxBound) vom Benutzer einlesen
            Console.WriteLine("Please enter upper bound: ");
            int maxBound = int.Parse(Console.ReadLine());

            // Zähler für die Zahlen im Bereich initialisieren
            int countInRange = 0;

            // Überprüfung, wie viele Zahlen im Bereich liegen
            for (int i = 0; i < countOfNumbers; i++)
            {
                if (intNumbers[i] >= minBound && intNumbers[i] <= maxBound)
                {
                    countInRange++; // Zähler erhöhen, falls die Zahl im Bereich liegt
                }
            }

            // Überprüfung, ob Zahlen innerhalb des Bereichs gefunden wurden
            if (countInRange > 0)
            {
                Console.WriteLine($"{countInRange} numbers are in the range of [{minBound}..{maxBound}]");
            }
            else
            {
                Console.WriteLine($"No number is in the range of [{minBound}..{maxBound}]");
            }
        }
    }
}
