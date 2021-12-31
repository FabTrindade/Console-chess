using System;
using chessboard;

namespace chessboard
{
    class Piece
    {
        public  Position position { get; set; }
        public Color color { get; protected set;}

        public int movemmentsAmount { get; protected set; }

        public Chessboard chesboard { get; protected set; }

        public Piece(Position position, Color color, int movemmentsAmount, Chessboard chesboard)
        {
            this.position = position;
            this.color = color;
            this.movemmentsAmount = movemmentsAmount;
            this.chesboard = chesboard;
        }
    }
}
