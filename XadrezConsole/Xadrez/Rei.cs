using System;
using System.Security.Cryptography.X509Certificates;
using Tabuleiro;
using Xadrez;
using XadrezConsole.Xadrez;

namespace Xadrez
{
    class Rei : Piece
    {
        ChessMatch Partida;

        public Rei(Color color, Board board, ChessMatch partida) : base(color, board)
        {
            Partida = partida;
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

            pos.SetPosition(Position.Line - 1, Position.Column + 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
                mat[pos.Line, pos.Column] = true;

            pos.SetPosition(Position.Line, Position.Column + 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
                mat[pos.Line, pos.Column] = true;

            pos.SetPosition(Position.Line + 1, Position.Column + 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
                mat[pos.Line, pos.Column] = true;

            pos.SetPosition(Position.Line + 1, Position.Column);
            if (Board.ValidPosition(pos) && CanMove(pos))
                mat[pos.Line, pos.Column] = true;

            pos.SetPosition(Position.Line + 1, Position.Column - 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
                mat[pos.Line, pos.Column] = true;

            pos.SetPosition(Position.Line, Position.Column - 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
                mat[pos.Line, pos.Column] = true;

            pos.SetPosition(Position.Line - 1, Position.Column - 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
                mat[pos.Line, pos.Column] = true;

            if (Moviments == 0 && !Partida.Check && Partida.Player == Color)
            {
                Position t1 = new Position(Position.Line, Position.Column + 3);
                if (ValidateT(t1))
                {
                    Position p1 = new Position(Position.Line, Position.Column + 1);
                    Position p2 = new Position(Position.Line, Position.Column + 2);

                    if (Board.Piece(p1) == null && Board.Piece(p2) == null
                      && Safe(p1) && Safe(p2))
                    {
                        mat[p2.Line, p2.Column] = true;
                    }
                }

                Position t2 = new Position(Position.Line, Position.Column - 4);
                if (ValidateT(t1))
                {
                    Position p1 = new Position(Position.Line, Position.Column - 1);
                    Position p2 = new Position(Position.Line, Position.Column - 2);
                    Position p3 = new Position(Position.Line, Position.Column - 3);
                    if (Board.Piece(p1) == null && Board.Piece(p2) == null
                        && Board.Piece(p3) == null && Safe(p1) && Safe(p2))
                    {
                        mat[p2.Line, p2.Column] = true;
                    }
                }
            }
            return mat;
        }

        bool Safe(Position pos)
        {
            List<Piece> pieces = Partida.PiecesInGame(Partida.Opponent(Color));

            foreach (Piece piece in pieces)
            {
                bool[,] warningpositions = piece.PossibleMoviments();
                if (warningpositions[pos.Line, pos.Column])
                {
                    return false;
                }
            }
            return true;
        }



        bool ValidateT(Position pos)
        {
            Piece T = Board.Piece(pos);

            if (T != null && T is Torre && T.Moviments == 0 && T.Color == Color)
                return true;
            else
                return false;
        }
    }
}
