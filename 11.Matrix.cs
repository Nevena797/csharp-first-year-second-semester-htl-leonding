using System;

class Matrix
{
    static void Main(string[] args)
    {
        bool neueMatrix = true;

        while (neueMatrix)
        {
            Console.Write("Zeilen? ");
            int zeilen = Convert.ToInt32(Console.ReadLine());

            Console.Write("Spalten? ");
            int spalten = Convert.ToInt32(Console.ReadLine());

            // Matrix erstellen und mit Zufallszahlen füllen
            int[,] matrix = CreateMatrix(zeilen, spalten);

            // Matrix mit farbigen Zahlen und Vergleichsoperatoren ausgeben
            CompareAndPrintMatrix(matrix);

            Console.Write("Neue Matrix? (j/n): ");
            string antwort = Console.ReadLine().ToLower();
            neueMatrix = (antwort == "j");
        }
    }

    /// <summary>
    /// Erzeugt eine Matrix mit der angegebenen Anzahl von Zeilen und Spalten
    /// und füllt sie mit Zufallszahlen zwischen 1 und 9
    /// </summary>
    static int[,] CreateMatrix(int zeilen, int spalten)
    {
        // Neue Matrix mit den angegebenen Dimensionen erstellen
        int[,] matrix = new int[zeilen, spalten];

        // Zufallszahlengenerator initialisieren
        Random random = new Random();

        // Matrix mit Zufallszahlen zwischen 1 und 9 füllen
        for (int i = 0; i < zeilen; i++)
        {
            for (int j = 0; j < spalten; j++)
            {
                matrix[i, j] = random.Next(1, 10); // 1 bis 9
            }
        }

        return matrix;
    }

    /// <summary>
    /// Gibt die Matrix auf der Konsole aus, mit farbigen Zahlen und
    /// roten Vergleichsoperatoren zwischen benachbarten Elementen
    /// </summary>
    static void CompareAndPrintMatrix(int[,] matrix)
    {
        // Anzahl der Zeilen und Spalten bestimmen
        int zeilen = matrix.GetLength(0);
        int spalten = matrix.GetLength(1);

        // Konsole löschen für saubere Ausgabe
        Console.Clear();

        // Matrix mit farbigen Zahlen ausgeben
        for (int i = 0; i < zeilen; i++)
        {
            for (int j = 0; j < spalten; j++)
            {
                // Zufällige Farbe für jede Zahl wählen (wie im Screenshot zu sehen)
                Console.ForegroundColor = GetRandomColor();
                Console.Write(matrix[i, j] + " ");

                // Vergleichsoperator zur nächsten Zahl in der Zeile anzeigen
                if (j < spalten - 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red; // Rote Farbe für Operatoren
                    if (matrix[i, j] < matrix[i, j + 1])
                        Console.Write("< ");
                    else if (matrix[i, j] > matrix[i, j + 1])
                        Console.Write("> ");
                    else
                        Console.Write("= ");
                }
            }
            Console.WriteLine();
        }

        // Standardfarbe wiederherstellen
        Console.ResetColor();
    }

    /// <summary>
    /// Liefert eine zufällige Konsolenfarbe zurück, außer Schwarz (für den Hintergrund)
    /// und Rot (für die Operatoren reserviert)
    /// </summary>
    static ConsoleColor GetRandomColor()
    {
        // Array mit verfügbaren Farben (ohne Schwarz und Rot)
        ConsoleColor[] colors = {
            ConsoleColor.Blue, ConsoleColor.Cyan, ConsoleColor.Green,
            ConsoleColor.Magenta, ConsoleColor.Yellow, ConsoleColor.White,
            ConsoleColor.DarkBlue, ConsoleColor.DarkCyan, ConsoleColor.DarkGreen,
            ConsoleColor.DarkMagenta, ConsoleColor.DarkYellow
        };

        Random random = new Random();
        return colors[random.Next(colors.Length)];
    }
}