using System;
using System.Collections.Generic;
using System.Text;

namespace board
{
    internal class Board
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        private Piece[,] Pieces;

        public Board(int lines, int columns)
        {
            this.Lines = lines;
            this.Columns = columns;
            Pieces = new Piece[Lines, columns];
        }

        public override string ToString()
        {
            return "Board: " + Lines + ", " + Columns;
        }
    }
}
