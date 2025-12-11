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
        public bool check { get; private set; }


        public ChessMatch()
        {
            board = new Board(8, 8);
            turn = 1;
            CurrentPlayer = Color.White;
            endMatch = false;
            check = false;
            PiecesActive = new HashSet<Piece>();
            PiecesCaptured = new HashSet<Piece>();
            PlacePiece();
        }

        //Executa o movimento
        public Piece ExecuteMovement(Position origin, Position destination)
        {
            Piece p = board.RemovePiece(origin);
            p.addMovements();
            Piece capturedPiece = board.RemovePiece(destination);
            board.AddPiece(p, destination);
            if (capturedPiece != null)
            {
                PiecesCaptured.Add(capturedPiece);
            }
            return capturedPiece;
        }

        //Desfaz o movimento feito.
        public void UndoMovement(Position origin, Position destination, Piece capturedPiece)
        {
            Piece p = board.RemovePiece(destination);
            p.DecreaseMovements();
            if (capturedPiece != null)
            {
                board.AddPiece(capturedPiece, destination);
                PiecesCaptured.Remove(capturedPiece);
            }
            board.AddPiece(p, origin);
        }

        //Executa o movimento no tabuleiro
        public void MakeMove(Position origin, Position destination)
        {
            Piece capturedPiece = ExecuteMovement(origin, destination);

            if (KingIsCheck(CurrentPlayer))
            {
                UndoMovement(origin, destination, capturedPiece);
                throw new BoardException("The king cannot be in check");
            }

            if (KingIsCheck(Adversery(CurrentPlayer)))
            {
                check = true;
            }
            else
            {
                check = false;
            }

            if (TestCheckMate(Adversery(CurrentPlayer)))
            {
                endMatch = true;
            }
            else
            {
                turn++;
                ChangePlayer();
            }
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

        //Auxilia na identificcação da peça adversaria.
        private Color Adversery(Color cor)
        {
            if (cor == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }

        //Localiza o Rei no conjunto de peças em jogo.
        private Piece king(Color cor)
        {
            foreach (Piece x in PieceInGame(cor))
            {
                if (x is King)
                {
                    return x;
                }
            }
            return null;
        }

        //Metodo para testar se o rei está em xeque.
        public bool KingIsCheck(Color cor)
        {
            Piece K = king(cor);
            if (K == null)
            {
                throw new BoardException($"There is no king of Color {cor} on the board!");
            }
            foreach (Piece x in PieceInGame(Adversery(cor)))
            {
                bool[,] mat = x.PossibleMovements();
                if (mat[K.position.Line, K.position.Column])
                {
                    return true;
                }
            }
            return false;
        }

        //Lógica para verificar se há xeque mate.
        public bool TestCheckMate(Color cor)
        {
            if (!KingIsCheck(cor))
            {
                return false;
            }
            foreach (Piece x in PieceInGame(cor))
            {
                bool[,] mat = x.PossibleMovements();
                for (int i = 0; i < board.Lines; i++)
                {
                    for (int j = 0; j < board.Columns; j++)
                    {
                        if (mat[i, j])
                        {
                            Position origin = x.position;
                            Position destination = new Position(i, j);
                            Piece pieceCaptured = ExecuteMovement(origin, destination);
                            bool TestCheck = KingIsCheck(cor);
                            UndoMovement(origin, destination, pieceCaptured);
                            if (!TestCheck)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
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
