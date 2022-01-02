using System;

using chessboard;

namespace Console_chess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Chessboard tab = new Chessboard(8, 8);

            Screen.pritChessbord(tab);
        }
    }
}
