﻿using System;
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

        public override bool[,] PossibleMoviments()
        {
            bool[,] mat = new bool[Board.Lines, Board.Columns];

            Position pos = new Position(0, 0);


            pos.SetPosition(Position.Line - 1, Position.Column);

            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;

                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Line--;

            }


            pos.SetPosition(Position.Line, Position.Column + 1);

            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;

                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Column++;

            }

            pos.SetPosition(Position.Line + 1, Position.Column);

            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;

                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Line++;

            }

            pos.SetPosition(Position.Line, Position.Column - 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;

                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Column--;

            }

            return mat;
        }
    }
}
