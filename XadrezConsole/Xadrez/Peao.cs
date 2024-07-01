using System;
using Tabuleiro;

namespace Xadrez
{
    class Peao : Piece
    {
        public Peao(Color color, Board board) : base(color, board)
        {
        }

        public override string ToString()
        {
            return "P";
        }
    }
}
