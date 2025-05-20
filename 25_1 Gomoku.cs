
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace Gomoku
{
    class Program
    {
        const int EMPTY = -1;
        const int PLAYER1 = 0;
        const int PLAYER2 = 1;
        const string SAVE_FILE = "gomoku_save.csv";

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Gomoku");
            Console.WriteLine("=========");

            // Spielfeldgröße einlesen
            int boardSize = GetBoardSize();

            // Spielfeld initialisieren
            int[,] field = new int[boardSize, boardSize];
            InitializeBoard(field);

            // Spielablauf
            PlayGame(field);
        }

        static int GetBoardSize()
        {
            int boardSize;
            bool validInput = false;

            do
            {
                Console.Write("Board size [15,17 or 19]: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out boardSize))
                {
                    if (boardSize == 15 || boardSize == 17 || boardSize == 19)
                    {
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid board size. Please enter 15, 17 or 19.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            } while (!validInput);

            return boardSize;
        }

        static void InitializeBoard(int[,] field)
        {
            int rows = field.GetLength(0);
            int cols = field.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    field[i, j] = EMPTY;
                }
            }
        }

        static void PlayGame(int[,] field)
        {
            int currentPlayer = PLAYER1;
            bool gameOver = false;
            int boardSize = field.GetLength(0);
            int totalMoves = 0;
            int maxMoves = boardSize * boardSize;

            // Hauptspielloop
            while (!gameOver)
            {
                DisplayBoard(field);

                Console.WriteLine($"Player {currentPlayer + 1}: ");
                string input = Console.ReadLine();

                // Spezielle Kommandos überprüfen
                if (input == "!")
                {
                    Console.WriteLine($"Player {currentPlayer + 1} resigns. Player {(currentPlayer == PLAYER1 ? 2 : 1)} wins!");
                    gameOver = true;
                }
                else if (input.ToLower() == "s")
                {
                    SaveGame(field, SAVE_FILE);
                    Console.WriteLine("Game saved.");
                }
                else if (input.ToLower() == "l")
                {
                    field = LoadGame(boardSize, SAVE_FILE);
                    Console.WriteLine("Game loaded.");
                    // Aktuellen Spieler nach dem Laden bestimmen
                    int stoneCount = GetStoneCount(field);
                    currentPlayer = stoneCount % 2 == 0 ? PLAYER1 : PLAYER2;
                    totalMoves = stoneCount;
                }
                else
                {
                    // Position parsen
                    string[] coordinates = input.Split(',');

                    if (coordinates.Length != 2 ||
                        !int.TryParse(coordinates[0], out int row) ||
                        !int.TryParse(coordinates[1], out int col))
                    {
                        Console.WriteLine("Illegal input, please try again");
                        continue;
                    }

                    // Überprüfen, ob die Position gültig ist
                    if (row < 0 || row >= boardSize || col < 0 || col >= boardSize)
                    {
                        Console.WriteLine("Position is outside the board. Please try again.");
                        continue;
                    }

                    // Überprüfen, ob das Feld leer ist
                    if (field[row, col] != EMPTY)
                    {
                        Console.WriteLine("This position is already occupied. Please try again.");
                        continue;
                    }

                    // Stein setzen und überprüfen, ob der Spieler gewonnen hat
                    bool isWinner = SetStone(field, row, col, currentPlayer);
                    totalMoves++;

                    if (isWinner)
                    {
                        DisplayBoard(field);
                        Console.WriteLine($"Player {currentPlayer + 1} wins!");
                        gameOver = true;
                    }
                    else if (totalMoves >= maxMoves)
                    {
                        DisplayBoard(field);
                        Console.WriteLine("The game ends in a draw!");
                        gameOver = true;
                    }
                    else
                    {
                        // Spielerwechsel
                        currentPlayer = currentPlayer == PLAYER1 ? PLAYER2 : PLAYER1;
                    }
                }
            }

            Console.WriteLine("Game over. Press any key to exit.");
            Console.ReadKey();
        }

        static void DisplayBoard(int[,] field)
        {
            int rows = field.GetLength(0);
            int cols = field.GetLength(1);

            // Spaltenindizes anzeigen
            Console.Write("  ");
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"{j,2} ");
            }
            Console.WriteLine();

            // Spielfeld anzeigen
            for (int i = 0; i < rows; i++)
            {
                Console.Write($"{i,2} ");
                for (int j = 0; j < cols; j++)
                {
                    if (field[i, j] == EMPTY)
                    {
                        Console.Write(" . ");
                    }
                    else if (field[i, j] == PLAYER1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" X ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(" O ");
                        Console.ResetColor();
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        // Methoden für die Unittests

        public static bool IsWinner(int[,] field, int row, int col)
        {
            int player = field[row, col];
            int boardSize = field.GetLength(0);

            if (player == EMPTY)
                return false;

            // Überprüfe horizontale Richtung
            if (CheckDirection(field, row, col, 0, 1, player) + CheckDirection(field, row, col, 0, -1, player) >= 4)
                return true;

            // Überprüfe vertikale Richtung
            if (CheckDirection(field, row, col, 1, 0, player) + CheckDirection(field, row, col, -1, 0, player) >= 4)
                return true;

            // Überprüfe Diagonale (links oben nach rechts unten)
            if (CheckDirection(field, row, col, 1, 1, player) + CheckDirection(field, row, col, -1, -1, player) >= 4)
                return true;

            // Überprüfe Diagonale (rechts oben nach links unten)
            if (CheckDirection(field, row, col, -1, 1, player) + CheckDirection(field, row, col, 1, -1, player) >= 4)
                return true;

            return false;
        }

        private static int CheckDirection(int[,] field, int row, int col, int rowDir, int colDir, int player)
        {
            int count = 0;
            int boardSize = field.GetLength(0);

            int r = row + rowDir;
            int c = col + colDir;

            while (r >= 0 && r < boardSize && c >= 0 && c < boardSize && field[r, c] == player)
            {
                count++;
                r += rowDir;
                c += colDir;
            }

            return count;
        }

        public static int GetStoneCount(int[,] field)
        {
            int count = 0;
            int rows = field.GetLength(0);
            int cols = field.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (field[i, j] != EMPTY)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        public static bool SetStone(int[,] field, int row, int col, int player)
        {
            if (row < 0 || row >= field.GetLength(0) || col < 0 || col >= field.GetLength(1))
                return false;

            if (field[row, col] != EMPTY)
                return false;

            field[row, col] = player;

            return IsWinner(field, row, col);
        }

        public static void SaveGame(int[,] field, string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine("No;Row;Col;Player");

                int rows = field.GetLength(0);
                int cols = field.GetLength(1);
                int moveNumber = 1;

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (field[i, j] != EMPTY)
                        {
                            writer.WriteLine($"{moveNumber};{i};{j};{field[i, j] + 1}");
                            moveNumber++;
                        }
                    }
                }
            }
        }

        public static int[,] LoadGame(int boardSize, string fileName)
        {
            int[,] field = new int[boardSize, boardSize];
            InitializeBoard(field);

            if (!File.Exists(fileName))
                return field;

            using (StreamReader reader = new StreamReader(fileName))
            {
                // Erste Zeile überspringen (Header)
                string line = reader.ReadLine();

                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(';');
                    if (parts.Length >= 4)
                    {
                        int row = int.Parse(parts[1]);
                        int col = int.Parse(parts[2]);
                        int player = int.Parse(parts[3]) - 1; // Player wird als 1,2 gespeichert, aber als 0,1 verwendet

                        if (row >= 0 && row < boardSize && col >= 0 && col < boardSize)
                        {
                            field[row, col] = player;
                        }
                    }
                }
            }

            return field;
        }
    }
}
