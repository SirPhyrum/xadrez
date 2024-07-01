using System;
using Tabuleiro;

namespace Xadrez
{
    class Rei : Piece
    {
        public Rei(Color color, Board board) : base(color, board)
        {

        }

        public override string ToString()
        {
            return "R";
        }
    }
}
