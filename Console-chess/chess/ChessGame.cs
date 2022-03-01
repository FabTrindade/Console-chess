using System;
using chessboard;

namespace chess
{
    class ChessGame
    {
        public Chessboard chess { get; private set; }
        private int shift;
        private Color currentPlayer;
        public bool finished { get; private set; }
        public ChessGame()
        {
            this.chess = new Chessboard(8,8);
            this.shift = 1;
            this.currentPlayer = currentPlayer;
            putPieces();
            finished = false;
        }

        public void executeMovement (Position origin, Position destination)
        {
            Piece p = chess.removePiece(origin);
            p.incMovementsAmout();
            Piece capturedPiece = chess.removePiece(destination);
            chess.putPiece(p, destination);
        }

        private void putPieces()
        {
            chess.putPiece(new Tower(chess, Color.White), new ChessbordPosition('a', 1).toPosition());
            chess.putPiece(new Tower(chess, Color.White), new ChessbordPosition('h', 1).toPosition());
            chess.putPiece(new King(chess, Color.White), new ChessbordPosition('e', 1).toPosition());



            chess.putPiece(new Tower(chess, Color.Black), new ChessbordPosition('a', 8).toPosition());
            chess.putPiece(new Tower(chess, Color.Black), new ChessbordPosition('h', 8).toPosition());
            chess.putPiece(new King(chess, Color.Black), new ChessbordPosition('d', 8).toPosition());
        }
    }
}
