using System;

using chessboard;
using chess;

namespace Console_chess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ChessbordPosition pos = new ChessbordPosition('a', 1);

            Console.WriteLine(pos);
            Console.WriteLine(pos.toPosition());
        }
    }
}
