using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Tabuleiro;
using Xadrez;
using XadrezConsole.Xadrez;

namespace XadrezConsole
{
    internal class Screen
    {
        public static void PrintMatch(ChessMatch partida)
        {
            Console.Clear();
            PrintBoard(partida.Board);
            Console.WriteLine();
            Screen.PrintCapturedPiece(partida);
            Console.WriteLine();
            Console.WriteLine($"Turno {partida.Turn} \r\nVez das peças {partida.Player}");
            Console.WriteLine();
        }

        public static void PrintMatch(bool[,] possiblepositions, ChessMatch partida)
        {
            Console.Clear();
            PrintBoard(partida, possiblepositions);
            Console.WriteLine();
            PrintCapturedPiece(partida);
            Console.WriteLine();
            Console.WriteLine($"Turno {partida.Turn} \r\nVez das peças {partida.Player}");
            Console.WriteLine();
        }
        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write((board.Lines - i) + " ");

                for (int j = 0; j < board.Columns; j++)
                {
                    PrintPiece(board.Pieces[i, j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }

            Console.Write("  ");

            for (int i = 1; i <= board.Columns; i++)
            {
                Console.Write((char)(96 + i) + " ");
            }

            Console.WriteLine();
        }

        public static void PrintBoard(ChessMatch partida, bool[,] possiblepositions)
        {
            ConsoleColor backgroundColor = Console.BackgroundColor;
            ConsoleColor altBackgroundColor = ConsoleColor.DarkGray;

            for (int i = 0; i < partida.Board.Lines; i++)
            {
                Console.Write((partida.Board.Lines - i) + " ");

                for (int j = 0; j < partida.Board.Columns; j++)
                {
                    if (possiblepositions[i, j])
                        Console.BackgroundColor = altBackgroundColor;
                    else
                        Console.BackgroundColor = backgroundColor;

                    PrintPiece(partida.Board.Pieces[i, j]);
                    Console.BackgroundColor = backgroundColor;

                    Console.Write(" ");
                }
                Console.WriteLine();
            }

            Console.Write("  ");

            for (int i = 1; i <= partida.Board.Columns; i++)
            {
                Console.Write((char)(96 + i) + " ");
            }

            Console.WriteLine();
        }


        public static void PrintPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("-");
            }
            else
            {

                if (piece.Color == Color.Brancas)
                {
                    ConsoleColor colorbase = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(piece);
                    Console.ForegroundColor = colorbase;
                }
                else
                {
                    ConsoleColor colorbase = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write(piece);
                    Console.ForegroundColor = colorbase;
                }
            }
        }

        public static ChessPosition ReadPosition()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int line = int.Parse(s[1] + "");
            return new ChessPosition(column, line);
        }

        public static void PrintCapturedPiece(ChessMatch partida)
        {
            Console.Write("Peças brancas capturadas: ");

            ConsoleColor colorbase = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Cyan;

            foreach (Piece piece in partida.CapturedPiecesWhite)
                Console.Write(piece + " ");

            Console.ForegroundColor = colorbase;

            Console.Write("\r\n");

            Console.Write("Peças pretas capturadas: ");

            Console.ForegroundColor = ConsoleColor.DarkBlue;

            foreach (Piece piece in partida.CapturedPiecesBlack)
                Console.Write(piece + " ");

            Console.ForegroundColor = colorbase;

            Console.Write("\r\n");
        }
    }
}
