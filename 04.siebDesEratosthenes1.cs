namespace PrimeSieb
{
    using System;
    class Sieb
    {
        public static void Main(string[] args)
        {
            // Maximale Anzahl von Zeilen, die auf einmal ausgegeben werden, bevor eine Pause erfolgt
            const int MAXLINES = 22;

            // Benutzer nach der Obergrenze für Primzahlen fragen
            Console.Write("Bis zu welcher Zahl wollen Sie Primzahlen ausgeben? ");
            int maxNumber = Convert.ToInt32(Console.ReadLine());

            // Eingabevalidierung: Sicherstellen, dass die Zahl größer als 1 ist
            while ((maxNumber <= 0))
            {
                Console.WriteLine("Die größte Zahl muss größer als 1 sein!");
                Console.Write("Bis zu welcher Zahl wollen Sie Primzahlen ausgeben:");
                maxNumber = int.Parse(Console.ReadLine());
            }

            // Berechnung der Primzahlen mit dem Sieb des Eratosthenes
            var isPrime = CalcIsPrime(maxNumber);

            // Ausgabe der Überschrift
            Console.WriteLine("Primzahlen von 1 - " + maxNumber + ":");

            // Zählvariable für Zeilenumbrüche
            int lineCounter = 1;

            // Durchlaufen aller Zahlen von 2 bis zur Obergrenze
            for (int i = 2; i <= maxNumber; i++)
            {
                // Wenn die Zahl als Primzahl markiert ist, ausgeben
                if (isPrime[i])
                {
                    Console.WriteLine(i);
                    lineCounter++;

                    // Nach MAXLINES Zeilen Pause und Bestätigung des Benutzers
                    if (lineCounter == MAXLINES)
                    {
                        Console.WriteLine("<Eingabetaste für weiter>");
                        Console.ReadLine();
                        lineCounter = 0;
                    }
                }
            }
        }

        // Methode zur Berechnung der Primzahlen mit dem Sieb des Eratosthenes
        private static bool[] CalcIsPrime(int maxNumber)
        {
            // Erstellen eines Boolean-Arrays zur Markierung der Primzahlen
            var isPrime = new bool[maxNumber + 1];

            // 0 und 1 sind keine Primzahlen
            isPrime[0] = false;
            isPrime[1] = false;

            // Zunächst alle Zahlen als potenziell prim markieren
            for (int i = 2; i <= maxNumber; i++)
            {
                isPrime[i] = true;
            }

            // Nur bis zur Quadratwurzel der Obergrenze überprüfen
            int maxCheck = (int)(Math.Sqrt(maxNumber));

            // Durchlaufen der Zahlen von 2 bis zur Quadratwurzel
            for (int i = 2; i <= maxCheck; i++)
            {
                // Wenn die aktuelle Zahl eine Primzahl ist
                if (isPrime[i])
                {
                    // Alle Vielfachen dieser Zahl als nicht prim markieren
                    for (int multiplicator = 2; (multiplicator * i) <= maxNumber; multiplicator++)
                    {
                        isPrime[multiplicator * i] = false;
                    }
                }
            }

            // Array mit markierten Primzahlen zurückgeben
            return isPrime;
        }
    }
}
