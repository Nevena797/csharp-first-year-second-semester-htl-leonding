using System;
using System.Runtime.CompilerServices;

namespace Lotto
{
    public class Lotto
    { 
        // Überprüft, ob die Zahl bereits im Tipp enthalten ist
        private static bool Contains(int[] tip, int count, int number)
        {
            for (int i = 0; i < count; i++)
            {
                if (tip[i] == number)
                {
                    return true;//Die Zahl wurde bereits gezogen
                }
            }
            return false; //Die Zahl ist noch nicht enthalten
        }
        // Generiert einen Quick-Tipp mit 6 einzigartigen Zufallszahlen
        public static int[] QuickTip(int maxNo)
        {
            if (maxNo < 6)
            {
                return null; // ungultiger Bereich
            }
            int[] lottoNumbers = new int[6]; // Aray f[r die 6 Lottozahlen

            for (int i = 0; i < lottoNumbers.Length; i++)
            {
                int drawnNumber;
                do
                {
                    drawnNumber = Random.Shared.Next(1,maxNo,+1)// Zufallszahl zwischen 1 und maxNo
                } while (Contains(lottoNumbers, i, drawnNumber)); // Wiederholen, falls die Zahl bereits existiert

                lottoNumbers[i] = drawnNumber; // Die Zahl in das Array speichern
            }

            NormalizeTip(lottoNumbers); // Die Zahlen sortieren
            return lottoNumbers; // Rückgabe des Tipps
        }

        private static void NormalizeTip(int[] tip)
        {
            bool swap;
            do
            {
                swap = false;
                for (int i = 1; i < tip.Length; i++)
                {
                    if (tip[i - 1] > tip[i])
                    {
                        // Vertauschen, falls eine kleinere Zahl links von einer größeren steht
                        int tmp = tip[i - 1];
                        tip[i - 1] = tip[i];
                        tip[i] = tmp;
                        swap = true; // Es wurde getauscht, also weitermachen
                    }
                }
            } while (swap); // Solange wiederholen, bis alles sortiert ist
        }

        // Konvertiert das Zahlenarray in eine lesbare Zeichenkette
        public static string TipToString(int[] tip)
        {
            string output = "";
            bool first = true;

            foreach (int nr in tip)
            {
                if (!first)
                {
                    output += ","; // Komma als Trennzeichen zwischen den Zahlen
                }
                output += nr; // Zahl hinzufügen
                first = false;
            }

            return output; // Rückgabe der Zeichenkette
        }
    }
}
