using System;
using board;
using screen;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Board board01 = new Board(8, 8);
            Screen.PrintBoard(board01);

            Console.ReadLine();
        }
    }
}