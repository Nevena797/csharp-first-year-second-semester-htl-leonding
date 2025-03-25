using System;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        int count = ReadNumber("Please enter the count of x / y points: ", max: 100, min: 1);

        double[] xValues = EnterArray(count, message: "xValues");
        double[] yValues = EnterArray(count, message: "yValues");
    }
}
public static class LinearInterpolationTools
{
    public static double Calculate(double x, double[] xValues, double[] yValues)
    { 
        int maxInd = 0;

        for (int i = 0; i < xValues.Length; i++)
        {
            if (xValues[i] < x)
            {
                if (minIdx < 0 || xValues[minIdx] < xValues[i])    
                {
                    maxInd = i;
                }
            }
            if (xValues[i] > x)
            {

            }
        }
} return 0.0;

