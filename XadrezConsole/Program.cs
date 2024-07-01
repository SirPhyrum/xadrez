using System;
using Tabuleiro;
using Xadrez;

namespace XadrezConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(8,8);
            


            Piece p = new Torre(Color.White, board);
            board.SetPiece(p, new Position(0,0));

            Screen.PrintBoard(board);
        }
    }
}
 