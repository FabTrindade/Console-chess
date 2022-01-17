using System;
using chessboard;

namespace chess
{
    class Tower : Piece
    {
        public Tower (Chessboard chess, Color color) : base(chess, color)
        {
        }

        public override string ToString()
        {
            return "T";
        }
    }
}
