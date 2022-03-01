using System;
using System.Collections.Generic;
using chessboard;

namespace chess
{
    class ChessGame
    {
        public Chessboard chess { get; private set; }
        public int shift { get; private set; }
        public Color currentPlayer { get; private set; }
        public bool finished { get; private set; }

        HashSet<Piece> piecesSet;
        HashSet<Piece> capturedSet;


        public ChessGame()
        {
            this.chess = new Chessboard(8,8);
            this.shift = 1;
            this.currentPlayer = Color.White;
            finished = false;
            piecesSet = new HashSet<Piece>();
            capturedSet = new HashSet<Piece>();
            putPieces();            
        }

        public void executeMovement (Position origin, Position destination)
        {
            Piece p = chess.removePiece(origin);
            p.incMovementsAmout();
            Piece capturedPiece = chess.removePiece(destination);
            chess.putPiece(p, destination);
            if (capturedPiece != null)
            {
                capturedSet.Add(capturedPiece);
            }
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

        public  HashSet<Piece> capturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            
            foreach(Piece x in capturedSet)
            {
                if (x.color == color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }


        public HashSet<Piece> inGamePieces(Color color) 
        {
            HashSet<Piece> aux = new HashSet<Piece>();

            foreach (Piece x in piecesSet)
            {
                if (x.color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(capturedPieces(color));
            return aux;
        }
        public void putNewPiece (Piece piece, char col, int row)
        {
            chess.putPiece(piece, new ChessbordPosition(col, row).toPosition());
            piecesSet.Add(piece);
        }

        private void putPieces()
        {
            putNewPiece(new Tower(chess, Color.White), 'a', 1);
            putNewPiece(new Tower(chess, Color.White), 'h', 1);
            putNewPiece(new Tower(chess, Color.White), 'e', 2);
            putNewPiece(new Tower(chess, Color.White), 'f', 2);
            putNewPiece(new Tower(chess, Color.White), 'd', 2);
            putNewPiece(new Tower(chess, Color.White), 'd', 1);
            putNewPiece(new Tower(chess, Color.White), 'f', 1);
            putNewPiece(new King(chess, Color.White), 'e', 1);

            putNewPiece(new Tower(chess, Color.Black), 'a', 8);
            putNewPiece(new Tower(chess, Color.Black), 'h', 8);
            putNewPiece(new King(chess, Color.Black), 'd', 8);
        }
    }
}
