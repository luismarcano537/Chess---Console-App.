using System;
using System.Collections.Generic;
using System.Text;

namespace ChessConsole.Board
{
    internal class BoardException : Exception
    {
        public BoardException(string msg) : base(msg) { }
    }
}
