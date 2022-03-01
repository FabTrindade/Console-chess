using System;
using chess;
using chessboard;

namespace Console_chess
{
    class Screen
    {
        public static void printChessbord(Chessboard chess)
        {
            for (int i = 0; i <  chess.rows; i++)
            {
                Console.Write(8 - i + "  ");
                for (int j = 0; j < chess.columns; j++)
                {
                    if (chess.piece(i,j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        printPiece(chess.piece(i, j));
                        Console.Write(" ");
                    }
                    
                }
                Console.WriteLine();
            }

            Console.Write("   ");


            for (int i =0; i < chess.columns; i++)
            {
                int newCol = 'a'+i;
                Console.Write(Convert.ToChar(newCol) + " ");
            }
        }

        public static ChessbordPosition ReadChessPosition()
        {
            string s = Console.ReadLine();
            char col = s[0];
            int row = int.Parse(s[1]+"");
            return new ChessbordPosition(col, row);
        }
        public static void printPiece (Piece piece)
        {
            if (piece.color == Color.White)
            {
                Console.Write(piece);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;

                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.Write(piece);

                Console.ForegroundColor = aux;
            }
        }
    }
}
