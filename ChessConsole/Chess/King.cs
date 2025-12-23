using System;
using System.Collections.Generic;
using System.Text;
using board;
using screen;

namespace Chess
{
    internal class King : Piece
    {

        private ChessMatch match;
        public King(Board board, Color color, ChessMatch match) : base(board, color)
        {
            this.match = match;
        }

        public override string ToString()
        {
            return "K";
        }

        // Verificação para auxiliar na jogada especial - TestRoqueTower
        private bool TestRoqueTower(Position pos)
        {
            Piece p = board.piece(pos);
            return p != null && p is Tower && p.color == color && p.QttMovements == 0;
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


            // # Jogada especial.
            if (QttMovements == 0)
            {
                Position posT1 = new Position(position.Line, position.Column + 3);
                // Roque pequeno.
                if (TestRoqueTower(posT1))
                {
                    Position p1 = new Position(position.Line, position.Column + 1);
                    Position p2 = new Position(position.Line, position.Column + 2);
                    if (board.piece(p1) == null && board.piece(p2) == null)
                    {
                        mat[position.Line, position.Column + 2] = true;
                    }
                }

                //Roque grande.
                Position posT2 = new Position(position.Line, position.Column - 4);

                if (TestRoqueTower(posT2))
                {
                    Position p1 = new Position(position.Line, position.Column - 1);
                    Position p2 = new Position(position.Line, position.Column - 2);
                    Position p3 = new Position(position.Line, position.Column - 3);

                    if (board.piece(p1) == null && board.piece(p2) == null && board.piece(p3) == null)
                    {
                        mat[position.Line, position.Column - 2] = true;
                    }
                }
            }

            return mat;
        }

    }
}
