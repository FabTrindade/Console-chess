using System;
using chessboard;

namespace chess
{
    class King : Piece
    {
        public King (Chessboard chess, Color color) : base (chess, color)
        {
        }

        public override string ToString()
        {
            return "K";
        }
    }
}
