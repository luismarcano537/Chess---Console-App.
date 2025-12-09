using System;
using board;
using screen;
using Chess;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChessMatch match = new ChessMatch();

                while (!match.endMatch)
                {
                    Console.Clear();
                    
                    Screen.PrintBoard(match.board);
                    Console.WriteLine();
                    Console.Write("Origin: ");
                    Position Origin = Screen.ReadPosition().ToPosition();

                    bool[,] PossiblePosition = match.board.piece(Origin).PossibleMovements();

                    Console.Clear();
                    Screen.PrintBoard(match.board, PossiblePosition);

                    Console.WriteLine();
                    Console.Write("Destination: ");
                    Position Destination = Screen.ReadPosition().ToPosition();

                    match.ExecuteMovement(Origin, Destination);
                }
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}