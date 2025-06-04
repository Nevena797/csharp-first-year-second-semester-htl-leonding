using System.ComponentModel;
using System.Net.Http.Headers;
using System.Security.Cryptography;

namespace Buckhold
{
    internal class Program
    {
        static void WriteToCSV(Product[] prods, string filename)
        {
            string[] lines = new string[prods.Length + 1]; // +1 because of header
            lines[0] = "ProductCode;Description;TaxClass;Retail"; // Заглавие като string

            for (int i = 0; i < prods.Length; i++)
            {
                Product p = prods[i];
                lines[i + 1] = $"{p.ProductCode};{p.Description};{p.TaxClass};{p.Retail}";
            }

            File.WriteAllLines(filename, lines);
        }
    }

    public class Product
    {
        public int ProductCode { get; set; }
        public string Description { get; set; }
        public string TaxClass { get; set; }
        public decimal Retail { get; set; }
    }
}