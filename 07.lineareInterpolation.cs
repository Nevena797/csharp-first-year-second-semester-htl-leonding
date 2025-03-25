using System;
using System.Linq;
using System.Globalization;

class LinearInterpolation
{
    static double Interpolate(double[] xValues, double[] yValues, double x)
    {
        if (xValues.Length == 0) return 0;

        for (int i = 0; i < xValues.Length - 1; i++)
        {
            if (xValues[i] <= x && x <= xValues[i + 1])
            {
                double x1 = xValues[i], x2 = xValues[i + 1];
                double y1 = yValues[i], y2 = yValues[i + 1];
                return Math.Round(y1 + (x - x1) * (y2 - y1) / (x2 - x1), 2);
            }
        }

        return x < xValues[0] ? yValues[0] : yValues[^1];
    }

    static void Main()
    {
        Console.WriteLine("**********************");
        Console.Write("Please enter the count of x / y points [1..100]: ");
        int count;
        while (!int.TryParse(Console.ReadLine(), out count) || count < 1 || count > 100)
        {
            Console.Write("Invalid input. Please enter a number between 1 and 100: ");
        }

        double[] xValues = new double[count];
        double[] yValues = new double[count];

        for (int i = 0; i < count; i++)
        {
            Console.Write($"X-Values {i + 1}. number: ");
            while (!double.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out xValues[i]))
            {
                Console.Write($"Invalid input. Please enter X-Values {i + 1} again: ");
            }
        }

        for (int i = 0; i < count; i++)
        {
            Console.Write($"Y-Values {i + 1}. number: ");
            while (!double.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out yValues[i]))
            {
                Console.Write($"Invalid input. Please enter Y-Values {i + 1} again: ");
            }
        }

        Array.Sort(xValues, yValues);

        while (true)
        {
            Console.Write("Please enter x to be converted (0 to exit): ");
            if (!double.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out double x) || x == 0)
                break;

            double result = Interpolate(xValues, yValues, x);
            Console.WriteLine($"f({x}) = {result.ToString("F1", CultureInfo.InvariantCulture)}");
        }
    }
}
