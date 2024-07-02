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

        public override bool[,] PossibleMoviments()
        {
            bool[,] mat = new bool[Board.Lines, Board.Columns];

            Position pos = new Position(0, 0);

            int a = 1, b = 1;
            bool x = true;

            while (x)
            {

                pos.SetPosition(Position.Line + (1 * a), Position.Column + (2 * b));
                if (Board.ValidPosition(pos) && CanMove(pos))
                    mat[pos.Line, pos.Column] = true;

                pos.SetPosition(Position.Line + (2 * a), Position.Column + (1 * b));
                if (Board.ValidPosition(pos) && CanMove(pos))
                    mat[pos.Line, pos.Column] = true;

                switch (a, b)
                {
                    case (1, 1):
                        b = -1;
                        break;

                    case (1, -1):
                        a = -1;
                        break;

                    case (-1, -1):
                        b = 1;
                        break;

                    case (-1, 1):
                        x = false;
                        break;

                }
            }

            return mat;
        }

    }
}
