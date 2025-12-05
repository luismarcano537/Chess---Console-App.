using System;
using System.Collections.Generic;
using System.Text;
using screen;
using Chess;
using ChessConsole.Board;

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
            Pieces = new Piece[lines, columns];
        }

        public override string ToString()
        {
            return "Board: " + Lines + ", " + Columns;
        }

        public Piece piece(int Line, int Column)
        {
            return Pieces[Line, Column];
        }

        public Piece piece(Position position)
        {
            return Pieces[position.Line, position.Column];
        }

        public bool PieceHere(Position position)
        {
            ValidatePosition(position);
            return piece(position) != null;
        }

        public void AddPiece(Piece p, Position position)
        {
            if (PieceHere(position))
            {
                throw new BoardException("There is already a piece here");
            }
            Pieces[position.Line, position.Column] = p;
            p.position = position;
        }

        public bool ValidPosition(Position position)
        {
            if (position.Line < 0 || position.Line >= Lines || position.Column < 0 || position.Column >= Columns)
            {
                return false;
            }
            return true;
        }

        public void ValidatePosition(Position position)
        {
            if (!ValidPosition(position))
            {
                throw new Exception("Invalid Position");
            }
        }
    }
}
