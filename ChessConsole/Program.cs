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

                    try
                    {
                        Console.Clear();

                        Screen.PrintBoard(match.board);
                        Console.WriteLine();
                        Console.WriteLine("Turn of play: " + match.turn);
                        Console.WriteLine("Waiting for player move: " + match.CurrentPlayer);
                        Console.WriteLine();

                        Console.Write("Origin: ");
                        Position Origin = Screen.ReadPosition().ToPosition();
                        match.ValidateHomePosition(Origin);

                        bool[,] PossiblePosition = match.board.piece(Origin).PossibleMovements();

                        Console.Clear();
                        Screen.PrintBoard(match.board, PossiblePosition);

                        Console.WriteLine();
                        Console.Write("Destination: ");
                        Position Destination = Screen.ReadPosition().ToPosition();
                        match.ValidadeDestinationPosition(Origin, Destination);

                        match.MakeMove(Origin, Destination);
                    }
                    catch (BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }

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