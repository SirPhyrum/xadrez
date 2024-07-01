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
                Piece p = new Torre(Color.Black, board);
                board.SetPiece(p, new ChessPosition('h', 4).ToPosition());
                Piece pp = new Torre(Color.White, board);
                board.SetPiece(pp, new ChessPosition('g', 4).ToPosition());

                Screen.PrintBoard(board);
            }
            catch (BoardException e) 
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
 