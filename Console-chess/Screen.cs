using System;
using chessboard;

namespace Console_chess
{
    class Screen
    {
        public static void pritChessbord(Chessboard chess)
        {
            for (int i = 0; i <  chess.rows; i++)
            {
                for (int j = 0; j < chess.columns; j++)
                {
                    if (chess.piece(i,j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(chess.piece(i, j) + " ");
                    }
                    
                }
                Console.WriteLine();
            }
        }
    }
}
