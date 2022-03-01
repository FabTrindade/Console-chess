using System;
using chessboard;

namespace chess
{
    class King : Piece
    {
        public King (Chessboard chessboard, Color color) : base (chessboard, color)
        {
        }

        public override string ToString()
        {
            return "K";
        }
        public override bool[,] possibleMovements()
        {
            bool [,] mat = new bool[chessboard.rows, chessboard.columns];

            Position pos = new Position(0, 0);

            //up
            pos.definePosition(position.row - 1, position.col);
            if (chessboard.canMove(pos, color))
            {
                mat[pos.row, pos.col] = true;
            }

            //up-right
            pos.definePosition(position.row - 1, position.col+1);
            if (chessboard.canMove(pos, color))
            {
                mat[pos.row, pos.col] = true;
            }

            //right
            pos.definePosition(position.row,  position.col+1);
            if (chessboard.canMove(pos, color))
            {
                mat[pos.row, pos.col] = true;
            }

            //down-right
            pos.definePosition(position.row + 1, position.col + 1);
            if (chessboard.canMove(pos, color))
            {
                mat[pos.row, pos.col] = true;
            }

            //down
            pos.definePosition(position.row + 1, position.col);
            if (chessboard.canMove(pos, color))
            {
                mat[pos.row, pos.col] = true;
            }

            //down-left
            pos.definePosition(position.row + 1, position.col - 1);
            if (chessboard.canMove(pos, color))
            {
                mat[pos.row, pos.col] = true;
            }

            //left
            pos.definePosition(position.row, position.col - 1);
            if (chessboard.canMove(pos, color))
            {
                mat[pos.row, pos.col] = true;
            }

            //up-left
            pos.definePosition(position.row  - 1, position.col - 1);
            if (chessboard.canMove(pos, color))
            {
                mat[pos.row, pos.col] = true;
            }

            return mat;
        }
    }
}
