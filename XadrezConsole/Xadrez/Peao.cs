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

        bool CanMoveFront(Position pos)
        {
            Piece p = Board.Piece(pos);
            return p == null;
        }

        bool CanMoveDiagonal(Position pos)
        {
            Piece p = Board.Piece(pos);
            bool x;
            if (p == null)
                x = false;
            else
            {
                if(p.Color != Color)
                    x = true;
                else 
                    x = false;
            }
            return p != null && x == true;
        }
        public override bool[,] PossibleMoviments()
        {
            int x = 1;
            if (Color == Color.Brancas)
                x = -1;

            bool[,] mat = new bool[Board.Lines, Board.Columns];

            Position pos = new Position(0, 0);

            pos.SetPosition(Position.Line + (1 * x), Position.Column+1);
            if (Board.ValidPosition(pos) && CanMoveDiagonal(pos))
                mat[pos.Line, pos.Column] = true;

            pos.SetPosition(Position.Line + (1 * x), Position.Column - 1);
            if (Board.ValidPosition(pos) && CanMoveDiagonal(pos))
                mat[pos.Line, pos.Column] = true;

            if (Moviments == 0)
            {
                pos.SetPosition(Position.Line + (1*x), Position.Column);
                if (Board.ValidPosition(pos) && CanMoveFront(pos))
                    mat[pos.Line, pos.Column] = true;

                pos.SetPosition(Position.Line + (2 * x), Position.Column);
                if (Board.ValidPosition(pos) && CanMoveFront(pos))
                    mat[pos.Line, pos.Column] = true;
            }
            else
            {
                pos.SetPosition(Position.Line + (1 * x), Position.Column);
                if (Board.ValidPosition(pos) && CanMoveFront(pos))
                    mat[pos.Line, pos.Column] = true;
            }

            return mat;
        }


    }
}
