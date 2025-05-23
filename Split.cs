using System;

string input = "apple,banana,orange";
string[] fruits = input.Split(',');

fruits[0] = "apple";
fruits[1] = "banana";
fruits[2] = "orange";


Console.WriteLine(fruits); //System.String[]
Console.WriteLine(fruits[0]); //apple
Console.WriteLine(string.Join(", ", fruits)); //apple, apple, orange

foreach (string fruit in fruits)
{
    Console.WriteLine(fruit);
}
//apple
//banana 
//orange


//string input = "1 2 3 4 5";
//string[] numbers = input.Split(' ');

////["1", "2", "3", "4", "5"]


////Example with multiple separators:
//string input = "one,two;three four";
//string[] parts = input.Split(new char[] { ',', ';', ' ' }); //["one", "two", "three", "four"]

////Example int.Parse:
//string line = "10 20 30";
//string[] parts = line.Split(' ');
//int[] numbers = new int[parts.Length];

//for (int i = 0; i < parts.Length; i++)
//{
//    numbers[i] = int.Parse(parts[i]);
//}