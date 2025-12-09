using System;
using System.Collections.Generic;
using System.Text;

namespace board
{
    internal class Position
    {
        public int Line { get; set; }
        public int Column { get; set; }

        public Position(int line, int column)
        {
            this.Line = line;
            this.Column = column;
        }


        //Metodo para obter a posição de uma peça no formato de matriz.
        public void SetValues(int line, int column)
        {
            this.Line = line;
            this.Column = column;
        }


        public override string ToString()
        {
            return Line + ", " + Column;
        }
    }
}
