using System;
using System.Collections.Generic;
using System.Text;

namespace board
{
    abstract class Piece
    {
        public Position? position { get; set; }
        public Color color { get; protected set; }
        public int? QttMovements { get; protected set; }
        public Board board { get; protected set; }

        public Piece(Board board, Color color)
        {
            this.position = null;
            this.board = board;
            this.color = color;
            this.QttMovements = 0;
        }

        public void addMovements()
        {
            QttMovements++;
        }

        //Metodo abstracto para implementar os possiveis movimentos.
        public abstract bool[,] PossibleMovements();
    }
}
