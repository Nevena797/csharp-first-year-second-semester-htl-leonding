# csharp-first-year-second-semester-htl-leonding
Programieren_C_sharp

using System;
using System.Globalization;
using System.IO;

namespace UpdateProductCsv
{
    public class Product
    {
        public static void FromCsv(string line, out string productCode, out string description, out string taxClass, out decimal retail)
        {
            var elements = line.Split(';');
            productCode = elements[0];
            description = elements[1];
            taxClass    = elements[2];
            retail      = decimal.Parse(elements[3], CultureInfo.InvariantCulture);
        }
        public static string ToCsvLine(string productCode, string description, string taxClass, decimal retail)
        {
            return $"{productCode};{description};{taxClass};{retail.ToString(CultureInfo.InvariantCulture)}";
        }
    }

    public class UpdateProductCsv
    {
        public static int Main(string[] args)
        {
            string fileName;
            double percentage;
            if (!CheckArguments(args, out fileName, out percentage))
            {
                return 1;
            }
            var fullPathName = Path.GetFullPath(fileName);
            var pathName     = $"{Path.GetDirectoryName(fullPathName)}\\";
            var bakPathName  = $"{pathName}{Path.GetFileNameWithoutExtension(fullPathName)}.bak";
            var tmpPathName  = $"{pathName}{Path.GetFileNameWithoutExtension(fullPathName)}.$$$";
            
            // Файл чете с ReadAllLines
            string[] fileContent = File.ReadAllLines(fullPathName);
            
            // Създава jagged array
            string[][] content = new string[fileContent.Length][];
            
            // Пълни jagged array със split
            for (int i = 0; i < fileContent.Length; i++)
            {
                content[i] = fileContent[i].Split(';');
            }
            
            // Преработва данните с jagged array
            for (int i = 1; i < content.Length; i++)
            {
                // Взимаме цена от колона 3
                decimal retail = decimal.Parse(content[i][3], CultureInfo.InvariantCulture);
                
                // Увеличаваме цената
                retail = (decimal)Math.Round(((double)retail) * percentage, 2);
                
                // Записваме обратно в jagged array
                content[i][3] = retail.ToString(CultureInfo.InvariantCulture);
            }
            
            // Обратно конвертиране към string array с Join
            for (int i = 0; i < content.Length; i++)
            {
                fileContent[i] = string.Join(";", content[i]);
            }
            
            // Запазване
            File.WriteAllLines(tmpPathName, fileContent);
            
            if (File.Exists(bakPathName))
            {
                File.Delete(bakPathName);
            }
            File.Move(fullPathName, bakPathName);
            File.Move(tmpPathName, fullPathName);
            return 0;
        }

        static bool CheckArguments(string[] args, out string fileName, out double percentage)
        {
            fileName   = string.Empty;
            percentage = 0;
            if (args.Length != 2)
            {
                Console.WriteLine("usage: UpdateProductCsv CSV-Filename percentage");
                return false;
            }
            
            fileName   = args[0];
            double percent;
            if (!double.TryParse(args[1], CultureInfo.InvariantCulture, out percent))
            {
                Console.WriteLine($"Illegal percentage: {args[1]}");
                return false;
            }
            percentage = 1 + percent / 100.0;
            if (!File.Exists(fileName))
            {
                Console.WriteLine($"{fileName} does not exist");
                return false;
            }
            if (Path.GetExtension(fileName).ToUpper() != ".CSV")
            {
                Console.WriteLine("File is not of type .csv");
                return false;
            }
            return true;
        }
        
        static string[] ReadCsvFile(string filename)
        {
            return File.ReadAllLines(filename);
        }
        
        static void WriteCsv(string[] products, string fileName)
        {
            File.WriteAllLines(fileName, products);
        }
        
        static void UpdateRetails(string[] products, double percentage)
        {
            for (int i = 1; i < products.Length; i++)
            {
                products[i] = UpdateRetail(products[i], percentage);
            }
        }
        
        static string UpdateRetail(string product, double percentage)
        {
            string  productCode;
            string  description;
            string  taxClass;
            decimal retail;
            Product.FromCsv(product, out productCode, out description, out taxClass, out retail);
            retail = (decimal)Math.Round(((double)retail) * percentage, 2);
            return Product.ToCsvLine(productCode, description, taxClass, retail);
        }
    }
}
