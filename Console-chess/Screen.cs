using System;
using System.Collections.Generic;
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
                   printPiece(chess.piece(i, j));                    
                }
                Console.WriteLine();
            }


            Console.WriteLine();
            Console.Write("   ");

            for (int i =0; i < chess.columns; i++)
            {
                int newCol = 'a'+i;
                Console.Write(Convert.ToChar(newCol) + " ");
            }
        }

        public static void printGame (ChessGame game)
        {
            printChessbord(game.chess);
            printCapturedPieces(game);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Turno: " + game.shift);

            if (!game.finished)
            {
                Console.WriteLine("Waiting player: " + game.currentPlayer);
                if (game.check)
                {
                    Console.WriteLine("YOU ARE IN CHECK!");
                }
            }
            else
            {
                Console.WriteLine("CHECKMATE!");
                Console.WriteLine("Winer: " + game.currentPlayer);
            }
        }

        public static void printCapturedPieces(ChessGame game)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("---------------");
            Console.WriteLine("Captured pieces");
            Console.WriteLine("---------------");
            Console.Write("White: ");
            printPiecesSet(game.capturedPieces(Color.White));
            Console.Write("Black: ");
            ConsoleColor temp = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            printPiecesSet(game.capturedPieces(Color.Black));
            Console.ForegroundColor = temp;
            Console.WriteLine("---------------");
        }

        public static void printPiecesSet(HashSet<Piece> set)
        {
            Console.Write("[");
            foreach(Piece x in set)
            {
                Console.Write(x + " ");
            }
            Console.WriteLine("]");
        }
        public static void printChessbord(Chessboard chess, bool[,] possibleMovements)
        {
            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor chandedBackground = ConsoleColor.DarkGray;


            for (int i = 0; i <  chess.rows; i++)
            {
                Console.Write(8 - i + "  ");
                for (int j = 0; j < chess.columns; j++)
                {
                    Console.BackgroundColor = (possibleMovements[i, j]) ? chandedBackground : originalBackground;
                    printPiece(chess.piece(i, j));                    
                }
                Console.WriteLine();
                Console.BackgroundColor = originalBackground;
            }

            Console.Write("   ");


            for (int i =0; i < chess.columns; i++)
            {
                int newCol = 'a'+i;
                Console.Write(Convert.ToChar(newCol) + " ");
            }
            Console.BackgroundColor =  originalBackground;
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
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
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
                Console.Write(" ");
            }
        }
    }
}
