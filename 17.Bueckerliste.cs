/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: <4ACIF/T>
 *--------------------------------------------------------------
 *              NEVENA ROGOVA
 *--------------------------------------------------------------
 * Description:
 * File Wizard 
 *--------------------------------------------------------------
*/


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Book
{
    public string Author { get; set; }
    public string Title { get; set; }
    public string Publisher { get; set; }
    public string ISBN { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        var books = ReadCSVFile("books.csv");
        SortBooks(books);
        PrintBooks(books);

        var invalidBooks = GetInvalidBooks(books);
        WriteCSVFile(invalidBooks, "books_invalid.csv");

        var validUniqueBooks = RemoveDuplicates(books);
        WriteCSVFile(validUniqueBooks, "books_valid.csv");
    }

    static Book[] ReadCSVFile(string filename)
    {
        var lines = File.ReadAllLines(filename);
        return lines.Select(line => {
            var parts = line.Split(';');
            return new Book
            {
                ISBN = parts[0],
                Publisher = parts[1],
                Author = parts[2],
                Title = parts[3]
            };
        }).ToArray();
    }

    static void SortBooks(Book[] books)
    {
        Array.Sort(books, (b1, b2) => {
            int pubComp = b1.Publisher.CompareTo(b2.Publisher);
            return pubComp != 0 ? pubComp : b1.Author.CompareTo(b2.Author);
        });
    }

    static void PrintBooks(Book[] books)
    {
        int count = 0;
        foreach (var book in books)
        {
            Console.WriteLine($"{book.ISBN,-12} {book.Publisher,-30} {book.Author,-30} {book.Title}");
            count++;
            if (count % 20 == 0)
            {
                Console.WriteLine("Press any key to continue, 'x' to exit...");
                var key = Console.ReadKey();
                if (key.KeyChar == 'x' || key.KeyChar == 'X') break;
            }
        }
    }

    static bool CheckIsbn(string isbn)
    {
        if (isbn.Length != 10) return false;
        int sum = 0;
        for (int i = 0; i < 10; i++)
        {
            int val;
            if (i == 9 && (isbn[i] == 'X' || isbn[i] == 'x')) val = 10;
            else if (char.IsDigit(isbn[i])) val = isbn[i] - '0';
            else return false;
            sum += val * (10 - i);
        }
        return sum % 11 == 0;
    }

    static Book[] GetInvalidBooks(Book[] books)
    {
        return books.Where(b => !CheckIsbn(b.ISBN)).ToArray();
    }

    static Book[] RemoveDuplicates(Book[] books)
    {
        var seen = new HashSet<string>();
        return books.Where(b => CheckIsbn(b.ISBN) && seen.Add(b.ISBN)).ToArray();
    }

    static void WriteCSVFile(Book[] books, string filename)
    {
        var lines = books.Select(b => $"{b.ISBN};{b.Publisher};{b.Author};{b.Title}");
        File.WriteAllLines(filename, lines);
    }
}
