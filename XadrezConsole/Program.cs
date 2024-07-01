using System;
using Tabuleiro;
using Xadrez;
using XadrezConsole.Tabuleiro;

namespace XadrezConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Board board = new Board(8, 8);



                Piece p = new Torre(Color.White, board);
                board.SetPiece(p, new Position(0, 0));
                board.SetPiece(p, new Position(0, 10));
                Screen.PrintBoard(board);
            }
            catch (BoardException e) 
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
 