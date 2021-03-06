using System;
using chessboard;

namespace chess
{
    class Tower : Piece
    {
        public Tower(Chessboard chessboard, Color color) : base(chessboard, color)
        {
        }

        public override string ToString()
        {
            return "T";
        }

       
        public override bool[,] possibleMovements()
        {
            bool[,] mat = new bool[chessboard.rows, chessboard.columns];

            Position pos = new Position(0, 0);

            //up
            pos.definePosition(position.row - 1, position.col);
            while (chessboard.canMove(pos, color))
            {
                mat[pos.row, pos.col] = true;
                if ((chessboard.piece(pos) != null) && (chessboard.piece(pos).color != color))
                {
                    break;
                }
                pos.row--;
            }

            //down
            pos.definePosition(position.row + 1, position.col);
            while (chessboard.canMove(pos, color))
            {
                mat[pos.row, pos.col] = true;
                if ((chessboard.piece(pos) != null) && (chessboard.piece(pos).color != color))
                {
                    break;
                }
                pos.row++;
            }

            //right
            pos.definePosition(position.row, position.col + 1);
            while (chessboard.canMove(pos, color))
            {
                mat[pos.row, pos.col] = true;
                if ((chessboard.piece(pos) != null) && (chessboard.piece(pos).color != color))
                {
                    break;
                }
                pos.col++;
            }


            //left
            pos.definePosition(position.row, position.col - 1);
            while (chessboard.canMove(pos, color))
            {
                mat[pos.row, pos.col] = true;
                if ((chessboard.piece(pos) != null) && (chessboard.piece(pos).color != color))
                {
                    break;
                }
                pos.col--;
            }

            //NO
            pos.definePosition(position.row - 1, position.col - 1);
            while (chessboard.canMove(pos, color))
            {
                mat[pos.row, pos.col] = true;
                if ((chessboard.piece(pos) != null) && (chessboard.piece(pos).color != color))
                {
                    break;
                }
                pos.row--;
                pos.col--;
            }

            //NE
            pos.definePosition(position.row - 1, position.col + 1);
            while (chessboard.canMove(pos, color))
            {
                mat[pos.row, pos.col] = true;
                if ((chessboard.piece(pos) != null) && (chessboard.piece(pos).color != color))
                {
                    break;
                }
                pos.row--;
                pos.col++;
            }

            //SE
            pos.definePosition(position.row + 1, position.col + 1);
            while (chessboard.canMove(pos, color))
            {
                mat[pos.row, pos.col] = true;
                if ((chessboard.piece(pos) != null) && (chessboard.piece(pos).color != color))
                {
                    break;
                }
                pos.row++;
                pos.col++;
            }


            //SO
            pos.definePosition(position.row + 1, position.col - 1);
            while (chessboard.canMove(pos, color))
            {
                mat[pos.row, pos.col] = true;
                if ((chessboard.piece(pos) != null) && (chessboard.piece(pos).color != color))
                {
                    break;
                }
                pos.row++;
                pos.col--;
            }
            return mat;
        }
    }
}
