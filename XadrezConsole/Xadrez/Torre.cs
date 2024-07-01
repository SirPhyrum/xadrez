using System;
using Tabuleiro;

namespace Xadrez
{
    class Torre : Piece
    {
        public Torre(Color color, Board board) : base(color, board)
        {
        }

        public override string ToString()
        {
            return "T";
        }
    }
}
