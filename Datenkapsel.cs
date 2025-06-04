using System;
using System.IO;
using System.Globalization;

namespace Datenkapsel
{
    internal class Datenkapsel
    {
        static void Main(string[] args)
        {
            string filename = "Products.csv";
            Product[] prods = ReadFromCsv(filename);

            Console.WriteLine("Produkte aus der Datei:");
            foreach (var product in prods)
            {
                Console.WriteLine($"{product.ProductCode} {product.Description} {product.TaxClass} {product.Retail:F2} EUR (ohne MwSt.: {product.ExclRetail:F2} EUR)");
            }
        }

        static Product[] ReadFromCsv(string filename)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine($"Datei {filename} existiert nicht.");
                return Array.Empty<Product>();
            }

            string[] lines = File.ReadAllLines(filename);

            if (lines.Length <= 1)
            {
                Console.WriteLine("Datei enthält keine Daten.");
                return Array.Empty<Product>();
            }

            Product[] products = new Product[lines.Length - 1]; // -1 because first line is header

            for (int i = 1; i < lines.Length; i++)
            {
                string[] cols = lines[i].Split(';');

                if (cols.Length < 4)
                {
                    Console.WriteLine($"Zeile {i + 1} ist ungültig.");
                    continue;
                }

                Product prod = new Product();
                prod.ProductCode = int.Parse(cols[0]);
                prod.Description = cols[1];
                prod.TaxClass = cols[2];
                prod.Retail = decimal.Parse(cols[3], CultureInfo.InvariantCulture);

                products[i - 1] = prod;
            }

            return products;
        }
    }

    public class Product
    {

        private string _description = " ";


        public int ProductCode { get; set; }


        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }


        public string TaxClass { get; set; } = " ";


        public decimal Retail { get; set; }


        public decimal ExclRetail
        {
            get { return Retail * 0.8m; }
        }
    }
}
