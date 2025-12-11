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

        public void DecreaseMovements()
        {
            QttMovements--;
        }

        //Metodo para verificar se existe movimentos possives (Se a peça não está trancada)
        public bool PossibleMoves()
        {
            bool[,] mat = PossibleMovements();
            for (int i = 0; i < board.Lines; i++)
            {
                for (int j = 0; j < board.Columns; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CanMoveTo(Position pos)
        {
            return PossibleMovements()[pos.Line, pos.Column];
        }

        //Metodo abstracto para implementar os possiveis movimentos.
        public abstract bool[,] PossibleMovements();
    }
}
