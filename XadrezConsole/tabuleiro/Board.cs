using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tabuleiro
{
     class Board
    {
        public int Lines { get; set; }
        public int Columns { get; set; }

        public Piece[,] Pieces { get; private set; }

        public Board(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            Pieces = new Piece[Lines,Columns];
        }

        public void SetPiece(Piece p, Position pos)
        {
            Pieces[pos.Line,pos.Column] = p;
            p.Position = pos;
        }
    }
}
