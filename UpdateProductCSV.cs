using System.Globalization;

namespace UpdateProductCSV
{

    using System;
    using System.Globalization;
    using System.IO;

    public class Product
    {
        public static void FromArray(string[] elements,out string productCode,
                                    out string description,out string taxClass,
                                    out decimal retail)
        {
            productCode = elements[0];
            description = elements[1];
            taxClass = elements[2];
            retail =decimal.Parse(elements[3], CultureInfo.InvariantCulture);
        }

        public static string[] ToArray(string productCode, string description,
            string taxClass, decimal retail)
        {
            return new string[]
                {
                    productCode,
                    description,
                    taxClass,
                    retail.ToString(CultureInfo.InvariantCulture)
                };
        }
    }
}
public class UpdateProductCsv
{
    public static int Main(string[] args)
    {
        string fileName;
        double persentage;

        if (!CheckArguments(args, out fileName, out persentage))
        {
            return 1;
        }

        var fullPathName = Path.GetFullPath(fileName);
        var pathName = $"{Path.GetDirectoryName(fullPathName)}\\";
        var bakPathName = $"{pathName}{Path.GetFileNameWithoutExtension(fullPathName)}.bak";
        var tmpPathName = $"{pathName}{Path.GetFileNameWithoutExtension(fullPathName)}.$$$";

        string[][] productsData = ReadCsvFile(fullPathName); //go to ReadCSV
        WriteCsv(productsData, tmpPathName); // go to WriteCsv

        if (File.Exists(bakPathName))
        {
            File.Delete(bakPathName);
        }

        File.Move(fullPathName, bakPathName);
        File.Move(tmpPathName, fullPathName);

        return 0;
    }

    static bool CheckArguments(string[] args, out string fileName, out double persentage)
    {
        fileName = string.Empty;
        persentage = 0;

        if (args.Length != 2)
        {
            Console.WriteLine("usage: UpdateProductCsv CSV-Filename percentage");
            return false;
        }

        fileName = args[0];
        double percent;

        if (!double.TryParse(args[1], CultureInfo.InvariantCulture, out percent))
        {
            Console.WriteLine($"Illegal persentage: {args[1]}");
            return false;
        }

        persentage = 1 + percent / 100.0;

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

    static string[][] ReadCsvFile(string filename)
    {
        string[] lines = File.ReadAllLines(filename);
        string[][] result = new string[lines.Length][];

        for (int i = 0; i < lines.Length; i++)
        {
            result[i] = lines[i].Split(';');
        }
        return result;
    }

    static void WriteCsv(string[][] productsData, string fileName)
    {
        string[] lines = new string[productsData.Length];

        for (int i = 0; i < lines.Length; i++)
        {
            lines[i] = string.Join(";", productsData[i]);
        }

        File.WriteAllLines(fileName, lines);
    }

    static void UpdateRetails(string[] productData, double percentage)
    {
        if (productData.Length >= 4 && decimal.TryParse(productData[3],
            NumberStyles.Any, CultureInfo.InvariantCulture, out decimal retail))
        {
            retail = (decimal)Math.Round(((double)retail) * percentage, 2);
            productData[3]=retail.ToString(CultureInfo.InvariantCulture);
        }
    }
}


