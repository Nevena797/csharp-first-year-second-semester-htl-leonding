
using System;
using System.Collections.Generic;
using System.IO;

public class ChessPiece
{
    public int Row { get; set; }
    public int Col { get; set; }
    public int Type { get; set; } // 1=K, 2=Q, 3=R, 4=B, 5=KN, 6=P
    public bool IsBlack { get; set; }
}

class Chess
{
    static void Main(string[] args)
    {
        string fileName = args.Length > 0 ? args[0] : "Chess.csv";
        var pieces = ReadFromCsv(fileName);
        var field = CreateField(pieces);
        if (field == null)
        {
            Console.WriteLine("Ungültiges Spielfeld!");
        }
        else
        {
            Print(field);
        }
    }

    public static ChessPiece[] ReadFromCsv(string fileName)
    {
        var list = new List<ChessPiece>();
        foreach (var line in File.ReadAllLines(fileName))
        {
            var parts = line.Split(';');
            int col = parts[0][0] - 'A';
            int row = int.Parse(parts[0][1].ToString()) - 1;
            string typeStr = parts[1];
            string colorStr = parts[2];

            int type = typeStr switch
            {
                "K" => 1,
                "Q" => 2,
                "R" => 3,
                "B" => 4,
                "KN" => 5,
                "P" => 6,
                _ => throw new Exception("Unbekannter Typ")
            };
            bool isBlack = colorStr == "B";

            list.Add(new ChessPiece { Row = row, Col = col, Type = type, IsBlack = isBlack });
        }
        return list.ToArray();
    }

    public static ChessPiece[,] CreateField(ChessPiece[] pieces)
    {
        ChessPiece[,] board = new ChessPiece[8, 8];
        int whiteKing = 0, blackKing = 0;
        int whiteQueens = 0, blackQueens = 0;
        int whitePawns = 0, blackPawns = 0;

        foreach (var piece in pieces)
        {
            if (board[piece.Row, piece.Col] != null) return null; // no overlap

            if (piece.Type == 1)
            {
                if (piece.IsBlack) blackKing++;
                else whiteKing++;
            }
            if (piece.Type == 2)
            {
                if (piece.IsBlack) blackQueens++;
                else whiteQueens++;
            }
            if (piece.Type == 6)
            {
                if (piece.IsBlack)
                {
                    blackPawns++;
                    if (piece.Row == 7) return null;
                }
                else
                {
                    whitePawns++;
                    if (piece.Row == 0) return null;
                }
            }

            board[piece.Row, piece.Col] = piece;
        }

        if (whiteKing != 1 || blackKing != 1) return null;
        if (whiteQueens > 9 || blackQueens > 9) return null;
        if (whiteQueens == 9 && whitePawns > 0) return null;
        if (blackQueens == 9 && blackPawns > 0) return null;

        return board;
    }

    public static void Print(ChessPiece[,] field)
    {
        Console.WriteLine("    A   B   C   D   E   F   G   H");
        for (int r = 7; r >= 0; r--)
        {
            Console.Write($"{r + 1} |");
            for (int c = 0; c < 8; c++)
            {
                var piece = field[r, c];
                if (piece == null) Console.Write("    ");
                else
                {
                    string symbol = piece.Type switch
                    {
                        1 => "K",
                        2 => "Q",
                        3 => "R",
                        4 => "B",
                        5 => "KN",
                        6 => "P",
                        _ => "?"
                    };
                    symbol += piece.IsBlack ? "b" : "w";
                    Console.Write($" {symbol} ");
                }
                Console.Write("|");
            }
            Console.WriteLine($" {r + 1}");
            Console.WriteLine("  +----+----+----+----+----+----+----+----+");
        }
        Console.WriteLine("    A   B   C   D   E   F   G   H");
    }
}
