using System;
using Tabuleiro;
using XadrezConsole.Xadrez;

namespace Xadrez
{
    class Peao : Piece
    {
        ChessMatch Partida;
        public Peao(Color color, Board board, ChessMatch partida) : base(color, board)
        {
            Partida = partida;
        }

        public override string ToString()
        {
            return "P";
        }

        bool EnPassante(Position pos)
        {
            Piece p;
            if (Board.ValidPosition(pos))
                p = Board.Piece(pos);
            else
                p = null;

            return (p != null && p == Partida.EnPassant && p.Color != Color);
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
                if (p.Color != Color)
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
            {
                x = -1;
            }

            bool[,] mat = new bool[Board.Lines, Board.Columns];

            Position pos = new Position(0, 0);

            if (Partida.Player == Color)
            {
                if ((Color == Color.Brancas && Position.Line == 3)
                    || (Color == Color.Pretas && Position.Line == 4))
                {
                    Position e = new Position(Position.Line, Position.Column - 1);
                    Position d = new Position(Position.Line, Position.Column + 1);

                    if (EnPassante(e))
                    {
                        mat[e.Line + (1 * x), e.Column] = true;
                    }
                    if (EnPassante(d))
                    {
                        mat[d.Line + (1 * x), d.Column] = true;
                    }
                }
            }

            pos.SetPosition(Position.Line + (1 * x), Position.Column + 1);
            if (Board.ValidPosition(pos) && CanMoveDiagonal(pos))
                mat[pos.Line, pos.Column] = true;

            pos.SetPosition(Position.Line + (1 * x), Position.Column - 1);
            if (Board.ValidPosition(pos) && CanMoveDiagonal(pos))
                mat[pos.Line, pos.Column] = true;

            if (Moviments == 0)
            {
                pos.SetPosition(Position.Line + (1 * x), Position.Column);
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
