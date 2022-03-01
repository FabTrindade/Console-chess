using System;
using chessboard;

namespace chess
{
    class ChessGame
    {
        public Chessboard chess { get; private set; }
        public int shift { get; private set; }
        public Color currentPlayer { get; private set; }
        public bool finished { get; private set; }
        public ChessGame()
        {
            this.chess = new Chessboard(8,8);
            this.shift = 1;
            this.currentPlayer = Color.White;
            finished = false;
            putPieces();            
        }

        public void executeMovement (Position origin, Position destination)
        {
            Piece p = chess.removePiece(origin);
            p.incMovementsAmout();
            Piece capturedPiece = chess.removePiece(destination);
            chess.putPiece(p, destination);
        }

        public void executePlay(Position origin, Position destination)
        {
            executeMovement(origin, destination);
            shift++;
            changePlayer();
        }

        private void changePlayer()
        {
            currentPlayer = (currentPlayer == Color.White) ? Color.Black : Color.White;
        }

        public void originPositionValidate(Position pos)
        {
            if (chess.piece(pos) == null)
            {
                throw new ChessboradExceptions("There is not piece in chosen origin position!");
            }
            if(currentPlayer != chess.piece(pos).color)
            {
                throw new ChessboradExceptions("The chosen origin piece is not yours!");
            }
            if (!chess.piece(pos).hasPossibleMovement())
            {
                throw new ChessboradExceptions("There are not possibles movements for chosen piece!");
            }

        }

        public void destinationPositionValidate(Position origin, Position destination)
        {
            if (!chess.piece(origin).canMoveTo(destination))
            {
                throw new ChessboradExceptions("Invalid distination position!");
            }
        }

        private void putPieces()
        {
            chess.putPiece(new Tower(chess, Color.White), new ChessbordPosition('a', 1).toPosition());
            chess.putPiece(new Tower(chess, Color.White), new ChessbordPosition('h', 1).toPosition());
            chess.putPiece(new Tower(chess, Color.White), new ChessbordPosition('e', 2).toPosition());
            chess.putPiece(new Tower(chess, Color.White), new ChessbordPosition('f', 2).toPosition());
            chess.putPiece(new Tower(chess, Color.White), new ChessbordPosition('d', 2).toPosition());
            chess.putPiece(new Tower(chess, Color.White), new ChessbordPosition('d', 1).toPosition());
            chess.putPiece(new Tower(chess, Color.White), new ChessbordPosition('f', 1).toPosition());
            chess.putPiece(new King(chess, Color.White), new ChessbordPosition('e', 1).toPosition());



            chess.putPiece(new Tower(chess, Color.Black), new ChessbordPosition('a', 8).toPosition());
            chess.putPiece(new Tower(chess, Color.Black), new ChessbordPosition('h', 8).toPosition());
            chess.putPiece(new King(chess, Color.Black), new ChessbordPosition('d', 8).toPosition());
        }
    }
}
