using System;

using chessboard;
using chess;

namespace Console_chess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Chessboard tab = new Chessboard(8, 8);

                tab.putPiece(new Tower(tab, Color.Black), new Position(0, 0));
                tab.putPiece(new Tower(tab, Color.Black), new Position(1, 3));
                tab.putPiece(new King(tab, Color.Black), new Position(2, 4));
                tab.putPiece(new King(tab, Color.White), new Position(7, 6));
                tab.putPiece(new Tower(tab, Color.White), new Position(6, 5));

                Screen.printChessbord(tab);
            }
            catch (ChessboradExceptions e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
