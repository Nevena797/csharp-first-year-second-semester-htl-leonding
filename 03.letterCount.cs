using System;

class LetterCounter
{
    static void Main()
    {
        // Begrüßungstext ausgeben
        Console.WriteLine("Letter-Count");
        Console.Write("Please enter a text: ");

        // Eingabe des Textes durch den Benutzer
        string input = Console.ReadLine();


        // Array zur Speicherung der Häufigkeit jedes Buchstabens (26 Buchstaben im englischen Alphabet)
        int[] letterCounts = new int[26];
        // Zähler für andere Zeichen (Leerzeichen, Zahlen, Satzzeichen usw.)
        int otherCount = 0;

        // Durchlaufen jedes Zeichens in der Eingabe
        foreach (char c in input)
        {
            // Prüfen, ob das Zeichen ein Buchstabe ist
            if (char.IsLetter(c))
            {
                // Umwandlung des Buchstabens in Großbuchstaben
                char upperChar = char.ToUpper(c);
                // Berechnung des Indexes im Array basierend auf dem ASCII-Wert von 'A'
                int index = upperChar - 'A';
                // Erhöhen des Zählers für diesen Buchstaben
                letterCounts[index]++;
            }
            else
            {
                // Falls kein Buchstabe, erhöhen des Zählers für andere Zeichen
                otherCount++;
            }
        }
        // Aufruf der Methode zur Ausgabe der Buchstabenhäufigkeit
        PrintLetterCounts(letterCounts, otherCount);
    }

    // Methode zur Ausgabe der Häufigkeit der Buchstaben
    static void PrintLetterCounts(int[] letterCounts, int otherCount)
    {
        // Schleife zur Ausgabe der Buchstabenpaare (zwei Buchstaben pro Zeile)
        for (int i = 0; i < 26; i += 2)
        {
            // Berechnung der Buchstaben anhand des Indexes
            char letter1 = (char)('A' + i); // A: 3   B: 0
            char letter2 = (char)('A' + i + 1); // C: 5   D: 2   

            // Erstellen der Ausgabezeile für den ersten Buchstaben
            string output = $"{letter1}: {letterCounts[i],-4}";

            // Falls der zweite Buchstabe noch innerhalb des Alphabets liegt, hinzufügen
            if (i + 1 < 26)
            {
                output += $"{letter2}: {letterCounts[i + 1],-4}";
            }

            // Ausgabe der Zeile
            Console.WriteLine(output);
        }

        // Ausgabe der Anzahl der Nicht-Buchstaben-Zeichen
        Console.WriteLine($"Other: {otherCount}");
    }
}

