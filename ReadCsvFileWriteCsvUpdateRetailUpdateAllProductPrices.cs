using System.Globalization;

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

static void WriteCsvFile(string[][] productsData,string fileName)
{
    string[] lines = new string[productsData.Length];
    for (int i = 0; i < lines.Length; i++)
    {
        lines[i] = string.Join(';', productsData[i]);
    }
    File.WriteAllLines(fileName, lines);
}

static void UpdateRetail(string[] productData, double percentage)
{
    decimal retail = decimal.Parse(productData[3],CultureInfo.InvariantCulture);
    retail = (decimal)Math.Round(((double)retail) * percentage,2);
    productData[3]= retail.ToString(CultureInfo.InvariantCulture);
}

static void UpdateAllProductPrices(string[][] productsData, double percentage)
{
    for (int i = 1; i < productsData.Length; i++)
    {
        UpdateRetail(productsData[i], percentage);
    }
}