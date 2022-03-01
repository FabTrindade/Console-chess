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
                ChessGame game  = new ChessGame();

                while (!game.finished)
                {
                    Console.Clear();
                    Screen.printChessbord(game.chess);

                    Console.WriteLine();
                    Console.WriteLine();
                    Console.Write("Origin: ");
                    
                    Position origin = Screen.ReadChessPosition().toPosition();
                    
                    bool[,] possibleMovements = game.chess.piece(origin).possibleMovements();
                    Console.Clear();
                    Screen.printChessbord(game.chess, possibleMovements);

                    Console.WriteLine();
                    Console.WriteLine();
                    Console.Write("Destination: ");

                    Position destination = Screen.ReadChessPosition().toPosition();

                    game.executeMovement(origin, destination);
                }
            }
            catch (ChessboradExceptions e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
