using System;
using System.Collections.Generic;
using board;
using screen;

namespace Chess
{
    internal class Queen : Piece
    {
        public Queen(Board board, Color color) : base(board, color)
        {

        }

        public override string ToString()
        {
            return "Q";
        }

        private bool CanMove(Position pos)
        {
            Piece p = board.piece(pos);
            return p == null || p.color == color;
        }


        public override bool[,] PossibleMovements()
        {
            bool[,] mat = new bool[board.Lines, board.Columns];

            Position pos = new Position(0, 0);

            //Esquerda
            pos.SetValues(position.Line, position.Column - 1);
            while (board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }

                pos.SetValues(pos.Line, pos.Column - 1);
            }

            //Direita
            pos.SetValues(position.Line, position.Column + 1);
            while (board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }

                pos.SetValues(pos.Line, pos.Column + 1);
            }

            //Acima
            pos.SetValues(position.Line - 1, position.Column);
            while (board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }

                pos.SetValues(pos.Line - 1, pos.Column);
            }

            //Abaixo
            pos.SetValues(position.Line + 1, position.Column);
            while (board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }

                pos.SetValues(pos.Line + 1, pos.Column);
            }

            //NO
            pos.SetValues(position.Line - 1, position.Column - 1);
            while (board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }

                pos.SetValues(pos.Line - 1, pos.Column - 1);
            }

            //NE
            pos.SetValues(position.Line - 1, position.Column + 1);
            while (board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }

                pos.SetValues(pos.Line - 1, pos.Column + 1);
            }

            //SE
            pos.SetValues(position.Line + 1, position.Column + 1);
            while (board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }

                pos.SetValues(pos.Line + 1, pos.Column + 1);
            }

            //SO
            pos.SetValues(position.Line + 1, position.Column - 1);
            while (board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }

                pos.SetValues(pos.Line + 1, pos.Column - 1);
            }

            return mat;
        }
    }
}
