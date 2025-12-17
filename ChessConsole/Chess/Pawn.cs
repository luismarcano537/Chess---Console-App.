using System;
using System.Collections.Generic;
using board;
using screen;

namespace Chess
{
    internal class Pawn : Piece
    {
        private ChessMatch match;
        public Pawn(Board board, Color color, ChessMatch match) : base(board, color)
        {
            match = this.match;
        }

        public override string ToString()
        {
            return "P";
        }

        private bool ExistEnemy(Position pos)
        {
            Piece p = board.piece(pos);
            return p != null && p.color != color;
        }

        private bool Free(Position pos)
        {
            return board.piece(pos) == null;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] mat = new bool[board.Lines, board.Columns];

            Position pos = new Position(0, 0);

            if (color == Color.White)
            {
                pos.SetValues(position.Line - 1, position.Column);

                if (board.ValidPosition(pos) && Free(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.SetValues(position.Line - 2, position.Column);
                Position p2 = new Position(position.Line - 1, position.Column);

                if (board.ValidPosition(p2) && Free(p2) && board.ValidPosition(pos) && Free(pos) && QttMovements == 0)
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.SetValues(position.Line - 1, pos.Column - 1);
                if ((board.ValidPosition(pos) && ExistEnemy(pos)))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.SetValues(position.Line - 1, pos.Column + 1);
                if ((board.ValidPosition(pos) && ExistEnemy(pos)))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                // #Jogada especial en passant.
                if (position.Line == 3)
                {
                    Position left = new Position(position.Line, position.Column - 1);
                    if (board.ValidPosition(left) && ExistEnemy(left) && board.piece(left) == match.VulnerablePassant)
                    {
                        mat[left.Line + 1, left.Column] = true;
                    }

                    Position Right = new Position(position.Line, position.Column + 1);
                    if (board.ValidPosition(Right) && ExistEnemy(Right) && board.piece(Right) == match.VulnerablePassant)
                    {
                        mat[Right.Line + 1, Right.Column] = true;
                    }

                }
            }
            else
            {
                pos.SetValues(position.Line + 1, position.Column);

                if (board.ValidPosition(pos) && Free(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.SetValues(position.Line + 2, position.Column);
                Position p2 = new Position(position.Line + 1, position.Column);
                if (board.ValidPosition(p2) && Free(p2) && board.ValidPosition(pos) && Free(pos) && QttMovements == 0)
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.SetValues(position.Line + 1, position.Column - 1);
                if (board.ValidPosition(pos) && ExistEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.SetValues(position.Line + 1, position.Column + 1);
                if (board.ValidPosition(pos) && ExistEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                // #Jogada especial en passant.
                if (position.Line == 4)
                {
                    Position left = new Position(position.Line, position.Column - 1);
                    if (board.ValidPosition(left) && ExistEnemy(left) && board.piece(left) == match.VulnerablePassant)
                    {
                        mat[left.Line, left.Column] = true;
                    }

                    Position Right = new Position(position.Line, position.Column + 1);
                    if (board.ValidPosition(Right) && ExistEnemy(Right) && board.piece(Right) == match.VulnerablePassant)
                    {
                        mat[Right.Line, Right.Column] = true;
                    }

                }

            }

            return mat;
        }
    }
}
