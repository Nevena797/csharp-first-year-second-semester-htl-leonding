using System;
using System.Diagnostics;
using System.Linq;


/// Klasse zur Implementierung des Sieb des Eratosthenes Algorithmus
/// zum Finden von Primzahlen

class SiebDesEratosthenes
{
    /// Hauptmethode zum Ausführen des Primzahl-Programms
 
    static void Main()
    {
        // Benutzereingabe für die Obergrenze der Primzahlensuche
        int obergrenze = HoleGueltigeObergrenze();

        // Stopwatch zur Zeitmessung starten
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        // Primzahlen mit dem Sieb des Eratosthenes finden
        bool[] istPrim = FindePrimzahlen(obergrenze);

        // Stopwatch anhalten
        stopwatch.Stop();

        // Gefundene Primzahlen ausgeben
        ZeigePrimzahlen(obergrenze, istPrim);

        // Programm am Ende anhalten
        WarteAufBenutzerEingabe();
    }


    /// Holt eine gültige Obergrenze von der Konsole
   
    /// <returns>Gültige Obergrenze für Primzahlensuche</returns>
    static int HoleGueltigeObergrenze()
    {
        int obergrenze;
        do
        {
            Console.Write("Bis zu welcher Zahl wollen Sie Primzahlen ausgeben? ");
        } while (!int.TryParse(Console.ReadLine(), out obergrenze) 
        || obergrenze <= 1);

        return obergrenze;
    }


    /// Implementiert das Sieb des Eratosthenes zum Finden von Primzahlen

    /// <param name="obergrenze">Maximale Zahl für Primzahlensuche</param>
    /// <returns>Feld mit Primzahl-Kennzeichnungen</returns>
    static bool[] FindePrimzahlen(int obergrenze)
    {
        // Initialisiere Feld mit Primzahl-Markierungen
        bool[] istPrim = new bool[obergrenze + 1];
        for (int i = 2; i <= obergrenze; i++)
        {
            istPrim[i] = true;
        }

        // Sieb des Eratosthenes Algorithmus
        for (int i = 2; i * i <= obergrenze; i++)
        {
            if (istPrim[i])
            {
                // Alle Vielfachen von i als nicht prim markieren
                for (int j = i * i; j <= obergrenze; j += i)
                {
                    istPrim[j] = false;
                }
            }
        }

        return istPrim;
    }

    /// Zeigt alle Primzahlen in der Konsole an
    /// <param name="obergrenze">Maximale Zahl</param>
    /// <param name="istPrim">Feld mit Primzahl-Kennzeichnungen</param>
    static void ZeigePrimzahlen(int obergrenze, bool[] istPrim)
    {
        Console.WriteLine($"Primzahlen von 1 - {obergrenze}:");
        int anzahl = 0;

        foreach (int i in Enumerable.Range(2, obergrenze - 1))
        {
            if (istPrim[i])
            {
                Console.WriteLine(i);
                anzahl++;
            }
        }

        Console.WriteLine($"Anzahl der Primzahlen: {anzahl}");
    }

    /// <summary>
    /// Wartet auf Benutzereingabe zum Beenden des Programms
    /// </summary>
    static void WarteAufBenutzerEingabe()
    {
        Console.WriteLine("<Eingabetaste für ENDE>");
        Console.ReadLine();
    }
}