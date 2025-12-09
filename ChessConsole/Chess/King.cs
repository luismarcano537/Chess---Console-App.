using System;
using System.Collections.Generic;
using System.Text;
using board;

namespace Chess
{
    internal class King : Piece
    {
        public King(Board board, Color color) : base(board, color) { }

        public override string ToString()
        {
            return "K";
        }

        //Metodo para verificar um possivel movimento.
        private bool CanMove(Position pos)
        {
            Piece p = board.piece(pos);
            return p == null || p.color != this.color;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] mat = new bool[board.Lines, board.Columns];
            Position pos = new Position(0, 0);

            //Verificar acima.
            pos.SetValues(position.Line - 1, position.Column);
            if (board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            //Verificar nordeste.
            pos.SetValues(position.Line - 1, position.Column + 1);
            if (board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            //Verificar direita.
            pos.SetValues(position.Line, position.Column + 1);
            if (board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            //Verificar sudeste.
            pos.SetValues(position.Line + 1, position.Column + 1);
            if (board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            //Verificar abaixo.
            pos.SetValues(position.Line + 1, position.Column);
            if (board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            //Verificar sudoeste.
            pos.SetValues(position.Line + 1, position.Column - 1);
            if (board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            //Verificar esquerda.
            pos.SetValues(position.Line, position.Column - 1);
            if (board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            //Verificar noroeste.
            pos.SetValues(position.Line - 1, position.Column - 1);
            if (board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            return mat;
        }
    }
}
