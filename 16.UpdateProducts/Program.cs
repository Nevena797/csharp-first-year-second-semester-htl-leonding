using System.Formats.Asn1;
using System.Globalization;

namespace _16.UpdateProducts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filename = "Products.csv";

            if (!File.Exists(filename))
            {
                Console.WriteLine($"Datai {filename} existiert nicht");
                return;
            }

            string[] lines= File.ReadAllLines(filename);
            if (lines.Length <= 1)
            {
                Console.WriteLine("Datei enthält keine Daten.");
                return;
            }

            // Initialize jagged array (one row per product, one inner array per product fields)
            string[][] products= new string[lines.Length-1][];

            for (int i = 0; i < lines.Length; i++)
            {
                string[] cols = lines[i].Split(';');
                products[i - 1] = cols;
            }
            Console.WriteLine("Produkte aus der Datei (mit Jagged Array):");

            foreach (var product in products)
            {
                if (product.Length < 4)
                {
                    Console.WriteLine("Ungültiger Eintrag (zu wenige Spalten).");
                    continue;
                }
                int productCode = int.Parse(product[0]);
                string description = product[1];
                string taxClass = product[2];
                decimal retail = decimal.Parse(product[3], CultureInfo.InvariantCulture);
                decimal exclRetail = CalculateExclRetail(retail);
                Console.WriteLine($"{productCode} {description} {taxClass} {retail:F2} EUR (ohne MwSt.: {exclRetail:F2} EUR)");
            }
        }
        static decimal CalculateExclRetail(decimal retailPrice)
        {
            return retailPrice * 0.8m; // Example: remove 20% VAT
        }
    }
}
    }
}
