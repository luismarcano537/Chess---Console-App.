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
        public int turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool endMatch { get; private set; }


        public ChessMatch()
        {
            board = new Board(8, 8);
            turn = 1;
            CurrentPlayer = Color.White;
            endMatch = false;
            PlacePiece();
        }

        //Executa o movimento
        public void ExecuteMovement(Position origin, Position destination)
        {
            Piece p = board.RemovePiece(origin);
            p.addMovements();
            Piece capturedPiece = board.RemovePiece(destination);
            board.AddPiece(p, destination);
        }

        //Executa o movimento no tabuleiro
        public void MakeMove(Position origin, Position destination)
        {
            ExecuteMovement(origin, destination);
            turn++;
            ChangePlayer();
        }

        //Valida os possiveis movimentos na posição de origem
        public void ValidateHomePosition(Position pos)
        {
            if (board.piece(pos) == null)
            {
                throw new BoardException("There is no part in the especified origin position");
            }
            if (CurrentPlayer != board.piece(pos).color)
            {
                throw new BoardException("The chosen original part is not yours, choose a part: " + CurrentPlayer);
            }
            if (!board.piece(pos).PossibleMoves())
            {
                throw new BoardException("There are no possible moves for the chosen piece!!");
            }
        }

        //Valida os possiveis movimentos na posição de destino
        public void ValidadeDestinationPosition(Position origin, Position destination)
        {
            if (!board.piece(origin).CanMoveTo(destination))
            {
                throw new BoardException("Target position invalid!");
            }
        }


        //Muda o jogador atual
        private void ChangePlayer()
        {
            if (CurrentPlayer == Color.White)
            {
                CurrentPlayer = Color.Black;
            }
            else
            {
                CurrentPlayer = Color.White;
            }
        }

        //Coloca as peças no tabuleiro
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
