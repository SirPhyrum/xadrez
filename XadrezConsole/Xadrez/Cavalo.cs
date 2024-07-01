using System;
using Tabuleiro;

namespace Xadrez
{
    class Cavalo : Piece
    {
        public Cavalo(Color color, Board board) : base(color, board)
        {
        }

        public override string ToString()
        {
            return "C";
        }
    }
}
