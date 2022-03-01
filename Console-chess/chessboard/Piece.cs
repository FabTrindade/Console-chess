using System;
using chessboard;

namespace chessboard
{
    abstract class Piece
    {
        public  Position position { get; set; }
        public Color color { get; protected set;}

        public int movemmentsAmount { get; protected set; }

        public Chessboard chessboard { get; protected set; }

        public Piece(Chessboard chessboard, Color color)
        {
            this.position = null;
            this.color = color;
            this.movemmentsAmount = 0;
            this.chessboard = chessboard;
        }

        public void incMovementsAmout()
        {
            movemmentsAmount++;
        }

        public abstract bool[,] possibleMovements();
    }
}
