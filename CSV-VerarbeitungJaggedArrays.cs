using System;
using System.Formats.Asn1;
using static System.Net.Mime.MediaTypeNames;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

//1.JAGGED ARRAYS(nicht 2D Arrays!) csharp

string[][] csvData;  // Array von Arrays - variable Länge!
// NICHT: string[,] csvData  // 2D Array - fixe Größe
//2. DATEI-OPERATIONEN
//Lesen: File.ReadAllLines()
//Schreiben: File.WriteAllLines()
//Kopieren: File.Copy()
//Umbenennen: File.Move()
//Löschen: File.Delete()

string[] columns = csvLine.Split(';');        // String zu Array
string csvLine = string.Join(";", columns);   // Array zu String

//4. VARIABLE ANZAHL VON SPALTEN
//Jagged Arrays erlauben unterschiedliche Zeilenlängen:

csvData[0] = new string[] { "A", "B", "C" };      // 3 Spalten
csvData[1] = new string[] { "X", "Y" };          // 2 Spalten

//5. LOKALISIERUNG (SEHR WICHTIG!)

// IMMER InvariantCulture für CSV-Dateien verwenden!

decimal.Parse(text, CultureInfo.InvariantCulture);
//price.ToString(CultureInfo.InvariantCulture);

//Warum: Verschiedene Länder verwenden unterschiedliche Dezimaltrennzeichen (. vs ,)
//Lösung: InvariantCulture verwendet immer Punkt(.)


//6. DIVISION mit DOUBLE
double average = sum / count; // Korrekte Gleitkomma-Division

//7. RUNDEN
decimal rounded = Math.Round(value, 2);  // Auf 2 Dezimalstellen

// Debugging: Project Properties → Debug → Command line arguments
// Beispiel: "products.csv 10.5"

//9. SICHERE DATEI-OPERATIONEN
//Backup erstellen
//In temporäre Datei schreiben
//Original löschen
//Temporäre Datei umbenennen

//Das Programm kann so verwendet werden:
//program.exe products.csv 10.5  // Erhöht Preise um 10.5%
