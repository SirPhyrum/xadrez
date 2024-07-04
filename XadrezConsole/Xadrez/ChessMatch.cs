using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
        public bool Check { get; private set; }
        public List<Piece> CapturedPieces { get; private set; }

        public ChessMatch()
        {
            CapturedPieces = new List<Piece>();
            Board = new Board(8, 8);
            Turn = 1;
            Player = Color.Brancas;
            Finish = false;
            Check = false;
            InsertPieces();
        }

        public bool CheckMate(Color color)
        {
            if (!ValidateCheck(color))
                return false;

            foreach (Piece p in PiecesInGame(color))
            {
                bool[,] m = p.PossibleMoviments();
                for (int i = 0; i < Board.Lines; i++)
                {
                    for (int j = 0; j < Board.Columns; j++)
                    {
                        if (m[i, j])
                        {
                            Position origin = p.Position;
                            Position target = new Position(i, j);
                            Piece captured = Moving(origin, target);
                            bool xeque = ValidateCheck(color);
                            BackMoving(origin, target, captured);

                            if (!xeque)
                                return false;
                        }

                    }
                }
            }
            return true;
        }



        public bool ValidateCheck(Color colorPlayer)
        {

            Piece rei = SearchRei(colorPlayer);

            List<Piece> pieces = PiecesInGame(Opponent(colorPlayer));
            foreach (Piece piece in pieces)
            {
                bool[,] warningpositions = piece.PossibleMoviments();
                if (warningpositions[rei.Position.Line, rei.Position.Column])
                {
                    return true;
                }
            }
            return false;
        }

        private Piece SearchRei(Color colorPlayer)
        {
            Piece p;
            Piece rei = new Rei(colorPlayer, Board, this);
            bool x = false;

            for (int i = 0; i < Board.Lines; i++)
            {
                for (int j = 0; j < Board.Columns; j++)
                {
                    p = Board.Piece(new Position(i, j));

                    if (p != null && p is Rei && p.Color == colorPlayer)
                    {
                        rei = p;
                        x = true;
                        break;
                    }
                }
                if (x)
                    break;
            }

            return rei;
        }

        public Color Opponent(Color color)
        {
            if (color == Color.Brancas)
                return Color.Pretas;
            else
                return Color.Brancas;
        }
        public List<Piece> PiecesInGame(Color color)
        {
            List<Piece> pieces = new List<Piece>();
            Piece p;

            for (int i = 0; i < Board.Lines; i++)
            {
                for (int j = 0; j < Board.Columns; j++)
                {
                    p = Board.Piece(new Position(i, j));

                    if (p != null && p.Color == color)
                        pieces.Add(p);
                }
            }

            return pieces;
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
            Piece p = Moving(origin, target);

            if (ValidateCheck(Player))
            {
                BackMoving(origin, target, p);
                throw new BoardException("Você não pode se colocar em xeque!");
            }
            if (ValidateCheck(Opponent(Player)))
            {
                Check = true;
            }
            else
            {
                Check = false;
            }

            if (CheckMate(Opponent(Player)))
            {
                Finish = true;
            }
            else
            {
                Turn++;
                ChangePlayer();
            }
        }

        private void BackMoving(Position origin, Position target, Piece captured)
        {
            Piece p = Board.DeletePiece(target);
            p.DelMoving();
            Board.SetPiece(p, origin);
            if (captured != null)
            {
                Board.SetPiece(captured, target);
                CapturedPieces.Remove(captured);
            }
        }

        public Piece Moving(Position origin, Position target)
        {
            Piece p = Board.DeletePiece(origin);

            if (p is Rei && p.Moviments == 0 && target.Column == 6 || target.Column == 2)
            {

                if (target.Column == 6)
                {
                    Position torigin = new Position(origin.Line, 7);
                    Position ttarget = new Position(origin.Line, 5);

                    Piece t = Board.DeletePiece(torigin);
                    p.AddMoving();
                    Board.SetPiece(t, ttarget);
                }

                if (target.Column == 2)
                {
                    Position torigin = new Position(origin.Line, 0);
                    Position ttarget = new Position(origin.Line, 3);

                    Piece t = Board.DeletePiece(torigin);
                    p.AddMoving();
                    Board.SetPiece(t, ttarget);

                }
            }


            p.AddMoving();
            Piece capturedpiece = Board.DeletePiece(target);

            if (capturedpiece != null)
                Capture(capturedpiece);

            Board.SetPiece(p, target);




            return capturedpiece;
        }



        public void Capture(Piece p)
        {
            CapturedPieces.Add(p);
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
            if (validpositions[target.Line, target.Column] != true)
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
                    //Board.SetPiece(new Cavalo(color, Board), new ChessPosition('b', i).ToPosition());
                    //Board.SetPiece(new Cavalo(color, Board), new ChessPosition('g', i).ToPosition());
                    //Board.SetPiece(new Bispo(color, Board), new ChessPosition('c', i).ToPosition());
                    //Board.SetPiece(new Bispo(color, Board), new ChessPosition('f', i).ToPosition());
                    //Board.SetPiece(new Dama(color, Board), new ChessPosition('d', i).ToPosition());
                    Board.SetPiece(new Rei(color, Board, this), new ChessPosition('e', i).ToPosition());
                }

                /*if (i == 7 || i == 2)
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
                }*/
            }
        }
    }
}
