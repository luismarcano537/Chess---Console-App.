using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using board;
using Chess;

namespace screen
{
    internal class Screen
    {
        //Metodo para imprimir dados da partida, dando uma partida como argumento.
        public static void PrintMatch(ChessMatch match)
        {
            Screen.PrintBoard(match.board);
            Console.WriteLine();
            PrintCapturedPieces(match);
            Console.WriteLine();
            Console.WriteLine("Turn of play: " + match.turn);
            Console.WriteLine("Waiting for player move: " + match.CurrentPlayer);
        }

        //Metodo para imprimir as peças capturadas.
        public static void PrintCapturedPieces(ChessMatch match)
        {
            Console.WriteLine("Captured Pieces: ");
            Console.Write("Whites: ");
            PrintSetPieces(match.PieceCaptured(Color.White));
            Console.WriteLine();
            Console.Write("Black: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintSetPieces(match.PieceCaptured(Color.Black));
            Console.ForegroundColor= aux;
            Console.WriteLine();
        }

        //Metodo para imprimir um conjunto.
        public static void PrintSetPieces(HashSet<Piece> set)
        {
            Console.Write("[");
            foreach (Piece x in set)
            {
                Console.Write(x + " ");
            }
            Console.Write("]");
        }

        //Metodo para imprimir o tabuleiro.
        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++)
                {
                    PrintPiece((board.piece(i, j)));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        //Metodo para imprimir o tabuleiro com possiveis posições.
        public static void PrintBoard(Board board, bool[,] possiblePositions)
        {
            ConsoleColor OriginalColor = Console.BackgroundColor;
            ConsoleColor NewColor = ConsoleColor.DarkGray;

            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++)
                {

                    if (possiblePositions[i, j])
                    {
                        Console.BackgroundColor = NewColor;
                    }
                    else
                    {
                        Console.BackgroundColor = OriginalColor;
                    }

                    PrintPiece(board.piece(i, j));
                    Console.BackgroundColor = OriginalColor;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = OriginalColor;
        }

        //Metodo para imprimir as peças conforme a cor do xadrez.
        public static void PrintPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (piece.color == Color.White)
                {
                    Console.Write(piece);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }


        //Metodo para ler a posição de uma peça no tabuleiro, podendo ser origem ou destino.
        public static PositionChess ReadPosition()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int line = int.Parse(s[1] + "");
            return new PositionChess(column, line);
        }
    }
}
