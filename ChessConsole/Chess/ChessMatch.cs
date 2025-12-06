using System;
using System.Collections.Generic;
using System.Text;
using board;
using screen;

namespace Chess
{
    internal class ChessMatch
    {
        public Board board { get; private set; }
        private int turn;
        private Color CurrentPlayer;

        public ChessMatch()
        {
            board = new Board(8, 8);
            turn = 1;
            CurrentPlayer = Color.White;
            PlacePiece();
        }

        public void ExecuteMovement(Position origin, Position destination)
        {
            Piece p = board.RemovePiece(origin);
            p.addMovements();
            Piece capturedPiece = board.RemovePiece(destination);
            board.AddPiece(p, destination);
        }

        private void PlacePiece()
        {
            board.AddPiece(new Tower(board, Color.White), new PositionChess('c', 1).ToPosition());
            board.AddPiece(new Tower(board, Color.White), new PositionChess('c', 2).ToPosition());
            board.AddPiece(new Tower(board, Color.White), new PositionChess('d', 2).ToPosition());
            board.AddPiece(new Tower(board, Color.White), new PositionChess('e', 2).ToPosition());
            board.AddPiece(new Tower(board, Color.White), new PositionChess('e', 1).ToPosition());
            board.AddPiece(new King(board, Color.White), new PositionChess('d', 1).ToPosition());

            board.AddPiece(new Tower(board, Color.Black), new PositionChess('c', 7).ToPosition());
            board.AddPiece(new Tower(board, Color.Black), new PositionChess('c', 8).ToPosition());
            board.AddPiece(new Tower(board, Color.Black), new PositionChess('d', 7).ToPosition());
            board.AddPiece(new Tower(board, Color.Black), new PositionChess('e', 7).ToPosition());
            board.AddPiece(new Tower(board, Color.Black), new PositionChess('e', 8).ToPosition());
            board.AddPiece(new King(board, Color.Black), new PositionChess('d', 8).ToPosition());
        }
    }
}
