using System;
using board;
using screen;
using Chess;
using ChessConsole.Board;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Board board01 = new Board(8, 8);
                board01.AddPiece(new Tower(board01, Color.Black), new Position(0, 0));
                board01.AddPiece(new Tower(board01, Color.Black), new Position(1, 3));
                board01.AddPiece(new King(board01, Color.White), new Position(2, 4));

                Screen.PrintBoard(board01);
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}