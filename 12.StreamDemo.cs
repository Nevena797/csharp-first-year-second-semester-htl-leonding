using System;
using System.IO;
using System.Text;

string path = @".\test.txt";

if (File.Exists(path))
{
    File.Delete(path);
}

using (StreamWriter sw = new StreamWriter(path, false, Encoding.Default))
{
    sw.WriteLine("This");
    sw.WriteLine("is some text");
    sw.WriteLine("to test");
    sw.WriteLine("reading");
}

using (StreamReader sr = new StreamReader(path, Encoding.Default))
{
    string?line = sr.ReadLine();
    while (line != null)
    {
        Console.WriteLine(line);
        line = sr.ReadLine();
    }
}

string[] lines = File.ReadAllLines(path);

Console.ReadKey();
