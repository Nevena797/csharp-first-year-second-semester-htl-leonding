using System;
using SVNummerTest;

// Hauptprogramm für die SV-Nummer-Prüfung
Console.WriteLine("Check a SV Number");
Console.WriteLine("**********************");
string svNumber;

// Schleife, die läuft, bis der Benutzer eine leere Eingabe macht
do
{
    // Benutzer zur Eingabe auffordern
    Console.Write("Please enter a SV Number: ");
    svNumber = Console.ReadLine();
    
    // Prüfen, ob eine Eingabe gemacht wurde
    if (!string.IsNullOrEmpty(svNumber))
    {
        // SV-Nummer prüfen und Ergebnis anzeigen
        var result = SVNummer.IsSvNumberValid(svNumber) ? "valid" : "invalid";
        Console.WriteLine($"The SV Number \"{svNumber}\" is {result}");
    }
} while (!string.IsNullOrEmpty(svNumber)); 

namespace SVNummerTest
{
    public class SVNummer
    {
        /// <summary>
        /// Prüft, ob ein String nur aus Ziffern besteht
        /// </summary>
        /// <param name="str">Der zu prüfende String</param>
        /// <returns>True, wenn der String nur Ziffern enthält, sonst False</returns>
        static bool OnlyContainsDigits(string str)
        {
            // Jeden Charakter im String auf Ziffern prüfen
            for (int i = 0; i < str.Length; i++)
            {
                // Wenn der Charakter keine Ziffer ist, false zurückgeben
                // Hier wird geprüft, ob der ASCII-Wert außerhalb des Ziffernbereichs liegt
                if (str[i] < '0' || str[i] > '9')
                {
                    return false;
                }
            }
            // Wenn alle Charaktere Ziffern sind, true zurückgeben
            return true;
        }

        /// <summary>
        /// Wandelt ein Zeichen in seine numerische Ziffer um
        /// </summary>
        /// <param name="ch">Das umzuwandelnde Zeichen</param>
        /// <returns>Der numerische Wert des Zeichens</returns>
        static int CharToDigit(char ch)
        {
            // ASCII-Wert des Zeichens minus ASCII-Wert von '0' (48) ergibt die Ziffer
            // Beispiel: '5' (ASCII 53) - '0' (ASCII 48) = 5
            return ch - '0';
        }

        /// <summary>
        /// Prüft, ob eine SV-Nummer gültig ist
        /// </summary>
        /// <param name="svNumber">Die zu prüfende SV-Nummer</param>
        /// <returns>True, wenn die SV-Nummer gültig ist, sonst False</returns>
        public static bool IsSvNumberValid(string svNumber)
        {
            // Gewichtungsfaktoren für die Prüfsummenberechnung
            int[] weight = { 3, 7, 9, 0, 5, 8, 4, 2, 1, 6 };
            
            // Prüfen, ob die SV-Nummer genau 10 Ziffern hat und nur aus Ziffern besteht
            bool isSvOk = svNumber.Length == 10 && OnlyContainsDigits(svNumber);
            
            if (isSvOk)
            {
                // Prüfsumme berechnen: Jede Ziffer mit ihrem Gewichtungsfaktor multiplizieren und summieren
                int sum = 0;
                for (int i = 0; i < svNumber.Length; i++)
                {
                    sum += weight[i] * CharToDigit(svNumber[i]);
                }
                
                // SV-Nummer ist gültig, wenn die 4. Stelle (Index 3) gleich der Prüfziffer ist
                // Die Prüfziffer ist der Rest der Division der Prüfsumme durch 11
                isSvOk = CharToDigit(svNumber[3]) == sum % 11;
            }
            
            // Ergebnis der Prüfung zurückgeben
            return isSvOk;
        }
    }
}

