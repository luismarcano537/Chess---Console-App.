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
            PositionChess Pos = new PositionChess('c', 7);

            Console.WriteLine(Pos);

            Console.WriteLine(Pos.ToPosition());

            Console.ReadLine();
        }
    }
}