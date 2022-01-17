using System;

using chessboard;
using chess;

namespace Console_chess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Chessboard tab = new Chessboard(8, 8);

            tab.putPiece(new Tower(tab, Color.Black), new Position(0, 0));
            tab.putPiece(new Tower(tab, Color.Black), new Position(1, 3));
            tab.putPiece(new King(tab, Color.Black), new Position(2, 4));

            Screen.printChessbord(tab);
        }
    }
}
