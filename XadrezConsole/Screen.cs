using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Tabuleiro;
using Xadrez;

namespace XadrezConsole
{
    internal class Screen
    {
        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write((board.Lines - i) + " ");

                for (int j = 0; j < board.Columns; j++)
                {
                    if (board.Pieces[i, j] == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Screen.PrintPiece(board.Pieces[i, j]);
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }

            Console.Write("  ");

            for (int i = 1; i <= board.Columns; i++)
            {
                Console.Write((char)(96+i) + " ");
            }

            Console.WriteLine();
        }

        public static void PrintPiece(Piece piece)
        {
            if(piece.Color == Color.White)
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

        public static ChessPosition ReadPosition ()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int line = int.Parse(s[1] + "");
            return new ChessPosition(column,line);
        }
    }
}
