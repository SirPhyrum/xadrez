using System;
using Tabuleiro;

namespace Xadrez
{
    class Dama : Piece
    {
        public Dama(Color color, Board board) : base(color, board)
        {
        }

        public override string ToString()
        {
            return "D";
        }
    }
}
