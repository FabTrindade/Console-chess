using System;
using chessboard;

namespace chessboard
{
    class Piece
    {
        public  Position position { get; set; }
        public Color color { get; protected set;}

        public int movemmentsAmount { get; protected set; }

        public Chessboard chessboard { get; protected set; }

        public Piece(Chessboard chesboard, Color color)
        {
            this.position = null;
            this.color = color;
            this.movemmentsAmount = 0;
            this.chessboard = chessboard;
        }
    }
}
