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
        private HashSet<Piece> PiecesActive;
        private HashSet<Piece> PiecesCaptured;


        public ChessMatch()
        {
            board = new Board(8, 8);
            turn = 1;
            CurrentPlayer = Color.White;
            endMatch = false;
            PiecesActive = new HashSet<Piece>();
            PiecesCaptured = new HashSet<Piece>();
            PlacePiece();
        }

        //Executa o movimento
        public void ExecuteMovement(Position origin, Position destination)
        {
            Piece p = board.RemovePiece(origin);
            p.addMovements();
            Piece capturedPiece = board.RemovePiece(destination);
            board.AddPiece(p, destination);
            if (capturedPiece != null)
            {
                PiecesCaptured.Add(capturedPiece);
            }
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

        //Metodo para auxiliar na separação das peças capturadas pela cor.
        public HashSet<Piece> PieceCaptured(Color cor)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in PiecesCaptured)
            {
                if (x.color == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        //Metodo para auxiliar na separação de peças em jogos das capturadas dada uma cor.
        public HashSet<Piece> PieceInGame(Color cor)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in PiecesActive)
            {
                if (x.color == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(PieceCaptured(cor));
            return aux;
        }

        //Metodo auxiliar para ccolocar peças e adicionar no conjunto.
        public void AddNewPiece(char column, int line, Piece piece)
        {
            board.AddPiece(piece, new PositionChess(column, line).ToPosition());
            PiecesActive.Add(piece);
        }

        //Coloca as peças no tabuleiro
        private void PlacePiece()
        {
            AddNewPiece('c', 1, new Tower(board, Color.White));
            AddNewPiece('c', 2, new Tower(board, Color.White));
            AddNewPiece('d', 2, new Tower(board, Color.White));
            AddNewPiece('e', 2, new Tower(board, Color.White));
            AddNewPiece('e', 1, new Tower(board, Color.White));
            AddNewPiece('d', 1, new King(board, Color.White));

            AddNewPiece('c', 7, new Tower(board, Color.Black));
            AddNewPiece('c', 8, new Tower(board, Color.Black));
            AddNewPiece('d', 7, new Tower(board, Color.Black));
            AddNewPiece('e', 7, new Tower(board, Color.Black));
            AddNewPiece('e', 8, new Tower(board, Color.Black));
            AddNewPiece('d', 8, new King(board, Color.Black));
        }
    }
}
