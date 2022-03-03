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
                    try
                    {
                        Console.Clear();

                        Screen.printGame(game);


                        Console.WriteLine();
                        Console.WriteLine();
                        Console.Write("Origin: ");

                        Position origin = Screen.ReadChessPosition().toPosition();

                        game.originPositionValidate(origin);

                        bool[,] possibleMovements = game.chess.piece(origin).possibleMovements();
                        Console.Clear();
                        Screen.printChessbord(game.chess, possibleMovements);

                        Console.WriteLine();
                        Console.WriteLine();
                        Console.Write("Destination: ");

                        Position destination = Screen.ReadChessPosition().toPosition();

                        game.destinationPositionValidate(origin, destination);

                        game.executePlay(origin, destination);
                    }
                    catch (ChessboradExceptions e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                    Console.Clear();
                    Screen.printGame(game);
                }
            }
            catch (ChessboradExceptions e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
