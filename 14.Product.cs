namespace UpdateProductCsv
{
    using System;
    using System.Globalization;
    using System.IO;

    public class Product
    {

        public static string ConvertCsvLineToString(string productCode, string description, string taxClass, decimal retail)
        {

            return $"{productCode};{description};{taxClass};{retail.ToString("F2", CultureInfo.InvariantCulture)}";
        }

        public static void ConvertCsvLineToValues(string line, out string productCode, out string description, out string taxClass, out decimal retail)
        {
            string[] columns = line.Split(';');
            productCode = columns[0];
            description = columns[1];
            taxClass = columns[2];
            retail = decimal.Parse(columns[3], CultureInfo.InvariantCulture);
        }
    }

    public class Program
    {
        public static int Main(string[] args)
        {
            string filename;
            decimal percent;


            if (!ValidateArguments(args, out filename, out percent))
            {
                Console.WriteLine("Error: Invalid arguments.");
                Console.WriteLine("Usage: UpdateProductCsv.exe <filename.csv> <percentage>");
                return 1;
            }

            try
            {

                string[] csvLines = File.ReadAllLines(filename);


                string[] updatedCsvLines = UpdatePrices(csvLines, percent);

                SaveUpdatedCsvFile(filename, updatedCsvLines);

                Console.WriteLine($"Successfully updated prices in '{filename}' by {(percent - 1) * 100}%.");
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return 1;
            }
        }

        private static bool ValidateArguments(string[] args, out string filename, out decimal percent)
        {
            filename = string.Empty;
            percent = 0;

            if (args.Length != 2)
            {
                return false;
            }

            filename = args[0];


            if (!File.Exists(filename) || !filename.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }


            decimal percentValue;
            if (!decimal.TryParse(args[1], NumberStyles.Any, CultureInfo.InvariantCulture, out percentValue))
            {
                return false;
            }


            percent = 1 + (percentValue / 100);

            return true;
        }


        private static string[] UpdatePrices(string[] csvLines, decimal percentMultiplier)
        {
            string[] updatedLines = new string[csvLines.Length];

            updatedLines[0] = csvLines[0];

            for (int i = 1; i < csvLines.Length; i++)
            {

                Product.ConvertCsvLineToValues(csvLines[i], out string productCode, out string description,
                                             out string taxClass, out decimal retail);

                decimal updatedPrice = Math.Round(retail * percentMultiplier, 2);

                updatedLines[i] = Product.ConvertCsvLineToString(productCode, description, taxClass, updatedPrice);
            }

            return updatedLines;
        }

        private static void SaveUpdatedCsvFile(string filename, string[] updatedLines)
        {
            string fileWithoutExtension = Path.GetFileNameWithoutExtension(filename);
            string directory = Path.GetDirectoryName(filename);

            string tempFilePath = Path.Combine(directory, fileWithoutExtension + ".$$$");
            string backupFilePath = Path.Combine(directory, fileWithoutExtension + ".bak");
            string finalFilePath = Path.Combine(directory, fileWithoutExtension + ".csv");

            File.WriteAllLines(tempFilePath, updatedLines);

            if (File.Exists(backupFilePath))
            {
                File.Delete(backupFilePath);
            }

            File.Move(filename, backupFilePath);

            File.Move(tempFilePath, finalFilePath);
        }
    }
}