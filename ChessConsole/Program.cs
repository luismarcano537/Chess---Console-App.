using System;
using board;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Board board01 = new Board(8, 8);
            Console.WriteLine(board01);
        }
    }
}