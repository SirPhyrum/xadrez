using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tabuleiro;

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
            Pieces = new Piece[Lines, Columns];
        }

        public Piece Piece(Position position)
        {

            return Pieces[position.Line, position.Column];
        }

        public bool ExistPiece(Position pos)
        {
            ValidatePosition(pos);
            return Piece(pos) != null;
        }

        public void SetPiece(Piece p, Position pos)
        {
            if(ExistPiece(pos)) 
                throw new BoardException("Já existe uma peça na posição escolhida!");

            Pieces[pos.Line, pos.Column] = p;
            p.Position = pos;
        }

        public Piece DeletePiece(Position pos)
        {
            if (Piece(pos) == null)
                return null;

            Piece x = Piece(pos);
            x.Position = null;
            Pieces[pos.Line, pos.Column] = null;
            return x;

        }

        public bool ValidPosition(Position pos)
        {
            if(pos.Line < 0 || pos.Line >= Lines || pos.Column < 0 || pos.Column >= Columns)
                return false;
            return true;
        }

        public void ValidatePosition(Position pos)
        {
            if (!ValidPosition(pos))
                throw new BoardException("Posição inválida!");
        }

    }
}

