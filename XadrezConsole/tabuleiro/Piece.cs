﻿using System;
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
        public Color Color {  get; protected set; }
        public int Moviments{ get; protected set; }
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
