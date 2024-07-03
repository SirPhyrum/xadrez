using System;
using System.Text.RegularExpressions;
using Tabuleiro;
using Xadrez;

namespace XadrezConsole.Xadrez
{
    class ChessMatch
    {
        public Board Board { get; private set; }
        public int Turn { get; private set; }
        public Color Player { get; private set; }
        public bool Finish { get; private set; }
        public List<Piece> CapturedPiecesWhite { get; private set; }
        public List<Piece> CapturedPiecesBlack { get; private set; }

        public ChessMatch()
        {
            CapturedPiecesWhite = new List<Piece>();
            CapturedPiecesBlack = new List<Piece>();
            Board = new Board(8, 8);
            Turn = 1;
            Player = Color.Brancas;
            Finish = false;
            InsertPieces();
        }

        public void Moving(Position origin, Position target)
        {
            Piece p = Board.DeletePiece(origin);
            p.AddMoving();
            Piece capturedpiece = Board.DeletePiece(target);
            if(capturedpiece != null)
                Capture(capturedpiece);
            Board.SetPiece(p, target);
        }

        public void Capture(Piece p)
        {
            Console.WriteLine(p);
            if (p.Color == Color.Brancas)
                CapturedPiecesWhite.Add(p);
            else
                CapturedPiecesBlack.Add(p);
        }

        public void MakePlay(bool[,] possiblepositions, Position origin, ChessMatch partida)
        {
            Position b = new Position();

            bool x = true;

            while (true) //peça tocada é peça jogada
            {
                try
                {
                    x = true;
                    Screen.PrintMatch(possiblepositions, partida);
                    Console.Write("Digite a coordenada de destino da peça ");
                    b = Screen.ReadPosition().ToPosition();
                    ValidTarget(origin, b);
                }
                catch (BoardException e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                    x = false;
                }

                if (x)
                {
                    FinishPlay(origin, b);
                    break;
                }
            }
        }


        public void FinishPlay(Position origin, Position target)
        {
            Moving(origin, target);
            Turn++;
            ChangePlayer();
        }

        public void ValidOrigin(Position origin)
        {
            if (Board.Piece(origin) == null)
                throw new BoardException("Não existe peça no local informado!");
            if (Board.Piece(origin) is Piece && Board.Piece(origin).Color != Player)
                throw new BoardException("A peça selecionada não é sua!");
            if (Board.Piece(origin).AnyPossibleMoviments() == false)
                throw new BoardException("A peça selecionada não pode se movimentar!");
        }

        public void ValidTarget(Position origin, Position target)
        {
            bool[,] validpositions = Board.Piece(origin).PossibleMoviments();
            if (validpositions[target.Line,target.Column] != true)
                throw new BoardException("Movimento inválido!");
        }

        public void ChangePlayer()
        {
            switch (Player)
            {
                case Color.Brancas:
                    Player = Color.Pretas;
                    break;
                case Color.Pretas:
                    Player = Color.Brancas;
                    break;

            }
        }

            private void InsertPieces()
            {
                for (int i = 1; i <= 8; i++)
                {
                    Color color = Color.Brancas;

                    if (i == 8 || i == 7)
                    {
                        color = Color.Pretas;
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
                            int k = 0;

                            if (i == 2)
                                k = 6;

                            if (i == 7)
                                k = 1;

                            Board.SetPiece(new Peao(color, Board), new Position(k, j));

                        }
                    }
                }
            }
        }
    }
