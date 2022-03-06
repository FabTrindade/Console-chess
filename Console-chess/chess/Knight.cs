using System;
using chessboard;

namespace chess
{
    class Knight : Piece
    {
        public Knight(Chessboard chessboard, Color color) : base(chessboard, color)
        {
        }

        public override string ToString()
        {
            return "N";
        }

       
        public override bool[,] possibleMovements()
        {
            bool[,] mat = new bool[chessboard.rows, chessboard.columns];

            Position pos = new Position(0, 0);

            pos.definePosition(position.row - 2, position.col+1);
            if (chessboard.canMove(pos, color))
            {
                mat[pos.row, pos.col] = true;
            }
            pos.definePosition(position.row - 2, position.col-1);
            if (chessboard.canMove(pos, color))
            {
                mat[pos.row, pos.col] = true;
            }
            pos.definePosition(position.row + 2, position.col+1);
            if (chessboard.canMove(pos, color))
            {
                mat[pos.row, pos.col] = true;
            }
            pos.definePosition(position.row + 2, position.col-1);
            if (chessboard.canMove(pos, color))
            {
                mat[pos.row, pos.col] = true;
            }
            return mat;
        }
    }
}
