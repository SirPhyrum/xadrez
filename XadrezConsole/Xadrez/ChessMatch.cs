using System;
using Tabuleiro;
using Xadrez;

namespace XadrezConsole.Xadrez
{
    class ChessMatch
    {
        public Board Board { get; private set; }
        private int Turn;
        private Color CurrentColor;
        public bool Finish {  get; private set; }

        public ChessMatch()
        {
            Board = new Board(8,8);
            Turn = 1;
            CurrentColor = Color.White;
            Finish = false;
            InsertPieces();
        }

        public void Moving(Position origin, Position target)
        {
            Piece p = Board.DeletePiece(origin);
            p.AddMoving();
            Piece capturedpiece = Board.DeletePiece(target);
            Board.SetPiece(p, target);
        }

        private void InsertPieces()
        {
            for (int i = 1; i <= 8; i++)
            {
                Color color = Color.White;

                if (i == 8 || i == 7)
                {
                    color = Color.Black;
                }

                if (i == 1 || i == 8)
                {
                    Board.SetPiece(new Torre(color, Board), new ChessPosition('a', i).ToPosition());
                    Board.SetPiece(new Torre(color, Board), new ChessPosition('h', i).ToPosition());
                    Board.SetPiece(new Cavalo(color, Board), new ChessPosition('b', i).ToPosition());
                    Board.SetPiece(new Cavalo(color, Board), new ChessPosition('g', i).ToPosition());
                    Board.SetPiece(new Bispo(color, Board), new ChessPosition('c', i).ToPosition());
                    Board.SetPiece(new Bispo(color, Board), new ChessPosition('f', i).ToPosition());
                    Board.SetPiece(new Dama(color, Board), new ChessPosition('d', i).ToPosition());
                    Board.SetPiece(new Rei(color, Board), new ChessPosition('e', i).ToPosition());
                }

                if (i == 7 || i == 2)
                {
                    for (int j = 0; j <= 7; j++)
                    {
                        int k=0;

                        if (i == 2)
                            k = 6;

                        if (i == 7)
                            k = 1;

                        Board.SetPiece(new Peao(color, Board), new Position(k,j));

                    }
                }
            }
        }
    }
}
