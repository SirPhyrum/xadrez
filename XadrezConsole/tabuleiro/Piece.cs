using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xadrez;

namespace Tabuleiro
{

    abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int Moviments { get; protected set; }
        public Board Board { get; protected set; }

        public Piece(Color color, Board board)
        {
            Position = null;
            Color = color;
            Board = board;
            Moviments = 0;
        }

        public void AddMoving()
        {
            Moviments++;
        }

        public void DelMoving()
        {
            Moviments--;
        }

        public bool AnyPossibleMoviments()
        {
            bool[,] moviments = PossibleMoviments();

            for (int i = 0; i < Board.Lines; i++)
            {
                for (int j = 0; j < Board.Columns; j++)
                {
                    if (moviments[i, j])
                        return true;
                }
            }
            return false;
        }
        public virtual bool[,] PossibleMoviments()
        {
            return new bool[0, 0];
        }

        public virtual bool CanMove(Position pos)
        {
            Piece p = Board.Piece(pos);
            return p == null || p.Color != Color;
        }

    }
}
