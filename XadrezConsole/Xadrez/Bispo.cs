using System;
using Tabuleiro;

namespace Xadrez
{
    class Bispo : Piece
    {
        public Bispo(Color color, Board board) : base(color, board)
        {
        }

        public override string ToString()
        {
            return "B";
        }
    }
}
