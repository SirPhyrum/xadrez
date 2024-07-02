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

        public override bool[,] PossibleMoviments()
        {
            bool[,] mat = new bool[Board.Lines, Board.Columns];

            Position pos = new Position(0, 0);

            pos.SetPosition(Position.Line - 1, Position.Column);
            if (Board.ValidPosition(pos) && CanMove(pos))
                mat[pos.Line, pos.Column] = true;

            pos.SetPosition(Position.Line - 1, Position.Column+1);
            if (Board.ValidPosition(pos) && CanMove(pos))
                mat[pos.Line, pos.Column] = true;

            pos.SetPosition(Position.Line, Position.Column+1);
            if (Board.ValidPosition(pos) && CanMove(pos))
                mat[pos.Line, pos.Column] = true;

            pos.SetPosition(Position.Line + 1, Position.Column+1);
            if (Board.ValidPosition(pos) && CanMove(pos))
                mat[pos.Line, pos.Column] = true;

            pos.SetPosition(Position.Line + 1, Position.Column);
            if (Board.ValidPosition(pos) && CanMove(pos))
                mat[pos.Line, pos.Column] = true;

            pos.SetPosition(Position.Line + 1, Position.Column-1);
            if (Board.ValidPosition(pos) && CanMove(pos))
                mat[pos.Line, pos.Column] = true;

            pos.SetPosition(Position.Line, Position.Column-1);
            if (Board.ValidPosition(pos) && CanMove(pos))
                mat[pos.Line, pos.Column] = true;

            pos.SetPosition(Position.Line - 1, Position.Column-1);
            if (Board.ValidPosition(pos) && CanMove(pos))
                mat[pos.Line, pos.Column] = true;

            return mat;
        }




    }
}
