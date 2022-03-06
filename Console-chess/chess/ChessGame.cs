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

        public bool check { get; private set; }

        HashSet<Piece> piecesSet;
        HashSet<Piece> capturedSet;


        public ChessGame()
        {
            this.chess = new Chessboard(8, 8);
            this.shift = 1;
            this.currentPlayer = Color.White;
            finished = false;
            piecesSet = new HashSet<Piece>();
            capturedSet = new HashSet<Piece>();
            check = false;
            putPieces();
        }

        public Piece executeMovement(Position origin, Position destination)
        {
            Piece p = chess.removePiece(origin);
            p.incMovementsAmout();
            Piece capturedPiece = chess.removePiece(destination);
            chess.putPiece(p, destination);
            if (capturedPiece != null)
            {
                capturedSet.Add(capturedPiece);
            }
            return capturedPiece;
        }


        public void undoMovement(Position origin, Position destination, Piece capturedPiece)
        {
            Piece p = chess.removePiece(destination);
            p.decMovementsAmout();

            if (capturedPiece != null)
            {
                chess.putPiece(capturedPiece, destination);
                capturedSet.Remove(capturedPiece);
            }
            chess.putPiece(p, origin);
        }

        public void executePlay(Position origin, Position destination)
        {
            Piece capturedPiece = executeMovement(origin, destination);

            if (isKingInCheck(currentPlayer))
            {
                undoMovement(origin, destination, capturedPiece);
                throw new ChessboradExceptions("You can't put yourself in check1");
            }

            check = (isKingInCheck(adversaryColor(currentPlayer)));

            if (isKingInCheckmate(adversaryColor(currentPlayer)))
            {
                finished = true;
            }
            else
            {
                shift++;
                changePlayer();
            }
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
            if (currentPlayer != chess.piece(pos).color)
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
            if (!chess.piece(origin).possibleMovement(destination))
            {
                throw new ChessboradExceptions("Invalid distination position!");
            }
        }

        public HashSet<Piece> capturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();

            foreach (Piece x in capturedSet)
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


        private Color adversaryColor(Color color)
        {
            return (color == Color.White) ? Color.Black : Color.White;
        }

        private Piece hasKing(Color color)
        {
            foreach (Piece x in inGamePieces(color))
            {
                if (x is King)
                {
                    return x;
                }
            }
            return null;
        }

        public bool isKingInCheck(Color color)
        {
            Piece k = hasKing(color);

            if (k == null)
            {
                throw new ChessboradExceptions("There is no " + color + " king on chessbord!");
            }

            foreach (Piece x in inGamePieces(adversaryColor(color)))
            {
                bool[,] mat = x.possibleMovements();
                if (mat[k.position.row, k.position.col])
                {
                    return true;
                }
            }
            return false;
        }

        public bool isKingInCheckmate(Color color)
        {
            if (!isKingInCheck(color))
            {
                return false;
            }
            foreach (Piece x in inGamePieces(color))
            {
                bool[,] mat = x.possibleMovements();
                for (int i = 0; i < chess.rows; i++)
                {
                    for (int j = 0; j < chess.columns; j++)
                    {
                        if (mat[i, j])
                        {
                            Position origin = x.position;
                            Position destination = new Position(i, j);
                            Piece capturedPiece = executeMovement(origin, destination);
                            bool testChek = isKingInCheck(color);

                            undoMovement(origin, destination, capturedPiece);

                            if (!testChek)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void putNewPiece(Piece piece, char col, int row)
        {
            chess.putPiece(piece, new ChessbordPosition(col, row).toPosition());
            piecesSet.Add(piece);
        }

        private void putPieces()
        {
            putNewPiece(new Tower(chess, Color.White), 'a', 1);
            putNewPiece(new Knight(chess, Color.White), 'b', 1);
            putNewPiece(new Bishop(chess, Color.White), 'c', 1);
            putNewPiece(new Queen(chess, Color.White), 'd', 1);
            putNewPiece(new King(chess, Color.White), 'e', 1);
            putNewPiece(new Bishop(chess, Color.White), 'f', 1);
            putNewPiece(new Knight(chess, Color.White), 'g', 1);
            putNewPiece(new Tower(chess, Color.White), 'h', 1);
            putNewPiece(new Pawn(chess, Color.White), 'a', 2);
            putNewPiece(new Pawn(chess, Color.White), 'b', 2);
            putNewPiece(new Pawn(chess, Color.White), 'c', 2);
            putNewPiece(new Pawn(chess, Color.White), 'd', 2);
            putNewPiece(new Pawn(chess, Color.White), 'e', 2);
            putNewPiece(new Pawn(chess, Color.White), 'f', 2);
            putNewPiece(new Pawn(chess, Color.White), 'g', 2);
            putNewPiece(new Pawn(chess, Color.White), 'h', 2);


            putNewPiece(new Tower(chess, Color.Black), 'a', 8);
            putNewPiece(new Knight(chess, Color.Black), 'b', 8);
            putNewPiece(new Bishop(chess, Color.Black), 'c', 8);
            putNewPiece(new Queen(chess, Color.Black), 'd', 8);
            putNewPiece(new King(chess, Color.Black), 'e', 8);
            putNewPiece(new Bishop(chess, Color.Black), 'f', 8);
            putNewPiece(new Knight(chess, Color.Black), 'g', 8);
            putNewPiece(new Tower(chess, Color.Black), 'h', 8);
            putNewPiece(new Pawn(chess, Color.Black), 'a', 7);
            putNewPiece(new Pawn(chess, Color.Black), 'b', 7);
            putNewPiece(new Pawn(chess, Color.Black), 'c', 7);
            putNewPiece(new Pawn(chess, Color.Black), 'd', 7);
            putNewPiece(new Pawn(chess, Color.Black), 'e', 7);
            putNewPiece(new Pawn(chess, Color.Black), 'f', 7);
            putNewPiece(new Pawn(chess, Color.Black), 'g', 7);
            putNewPiece(new Pawn(chess, Color.Black), 'h', 7);

        }
    }
}
