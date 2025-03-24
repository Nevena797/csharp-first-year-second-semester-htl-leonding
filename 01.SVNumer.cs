using System;
namespace SVNummerChecker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Begrüßungsnachricht anzeigen
            Console.WriteLine("Check a SV Number");
            Console.WriteLine("**********************");

            // Endlosschleife, die solange läuft, bis der Benutzer eine leere Eingabe macht
            while (true)
            {
                // Benutzer zur Eingabe auffordern
                Console.Write("Please enter a SV Number: ");
                string input = Console.ReadLine();

                // Prüfen, ob die Eingabe leer ist oder nur Leerzeichen enthält
                if (string.IsNullOrWhiteSpace(input))
                {
                    // Programm beenden, wenn die Eingabe leer ist
                    Console.WriteLine("Exiting program. Goodbye!");
                    break;
                }

                // SV-Nummer auf Gültigkeit prüfen und entsprechende Nachricht ausgeben
                if (IsValidSVNumber(input))
                {
                    Console.WriteLine($"The SV Number \"{input}\" is valid.\n");
                }
                else
                {
                    Console.WriteLine($"The SV Number \"{input}\" is invalid.\n");
                }
            }
        }
        /// Prüft, ob eine SV-Nummer gültig ist
        /// <param name="svNumber">Die zu prüfende SV-Nummer</param>
        /// <returns>True, wenn die SV-Nummer gültig ist, sonst False</returns>
        static bool IsValidSVNumber(string svNumber)
        {
            // Prüfen, ob die SV-Nummer genau 10 Ziffern hat und nur aus Ziffern besteht
            if (svNumber.Length != 10 || !IsAllDigits(svNumber))
            {
                return false;
            }

            // Gewichtungsfaktoren für die Prüfsummenberechnung
            int[] weights = { 3, 7, 9, 0, 5, 8, 4, 2, 1, 6 };
            int checksum = 0;

            // Prüfsumme berechnen: Jede Ziffer mit ihrem Gewichtungsfaktor multiplizieren und summieren
            for (int i = 0; i < 10; i++)
            {
                int digit = svNumber[i] - '0'; // Zeichen in Ziffer umwandeln
                // Diese Operation wandelt ein Zeichen (char) in seinen numerischen Wert um.
                // Wenn wir svNumber[i] aufrufen, erhalten wir ein Zeichen wie '5' und nicht die Zahl 5.
                // In der ASCII-Tabelle hat '0' den Wert 48, '1' den Wert 49, '2' den Wert 50, usw.
                // Indem wir den ASCII-Wert von '0' (48) vom ASCII-Wert des Zeichens subtrahieren,
                // erhalten wir den tatsächlichen numerischen Wert.
                // Zum Beispiel: '5' hat den ASCII-Wert 53, also 53 - 48 = 5
                checksum += digit * weights[i]; // Ziffer mit Gewichtungsfaktor multiplizieren und zur Prüfsumme addieren
            }

            // Erwartete Prüfziffer als Modulo 11 der Prüfsumme berechnen
            int expectedCheckDigit = checksum % 11;

            // Tatsächliche Prüfziffer aus der SV-Nummer extrahieren (4. Position, Index 3)
            int actualCheckDigit = svNumber[3] - '0';

            // SV-Nummer ist gültig, wenn die berechnete Prüfziffer mit der tatsächlichen übereinstimmt
            return expectedCheckDigit == actualCheckDigit;
        }

        /// <summary>
        /// Prüft, ob ein String nur aus Ziffern besteht
        /// </summary>
        /// <param name="input">Der zu prüfende String</param>
        /// <returns>True, wenn der String nur Ziffern enthält, sonst False</returns>
        static bool IsAllDigits(string input)
        {
            // Jeden Charakter im String prüfen
            foreach (char c in input)
            {
                // Wenn ein Charakter keine Ziffer ist, false zurückgeben
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            // Wenn alle Charaktere Ziffern sind, true zurückgeben
            return true;
        }
    }
}
