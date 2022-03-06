using System;
using chessboard;

namespace chess
{
    class Bishop : Piece
    {
        public Bishop(Chessboard chessboard, Color color) : base(chessboard, color)
        {
        }

        public override string ToString()
        {
            return "B";
        }

       
        public override bool[,] possibleMovements()
        {
            bool[,] mat = new bool[chessboard.rows, chessboard.columns];

            Position pos = new Position(0, 0);

            //NO
            pos.definePosition(position.row - 1, position.col -1);
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
