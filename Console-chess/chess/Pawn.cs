using System;
using chessboard;

namespace chess
{
    class Pawn : Piece
    {
        public Pawn(Chessboard chessboard, Color color) : base(chessboard, color)
        {
        }

        public override string ToString()
        {
            return "P";
        }

        private bool hasEnemy(Position pos)
        {
            Piece p = chessboard.piece(pos);
            return p != null && p.color != color;
        }


        private bool free(Position pos)
        {
            return chessboard.piece(pos) == null;
        }

        public override bool[,] possibleMovements()
        {
            bool[,] mat = new bool[chessboard.rows, chessboard.columns];

            Position pos = new Position(0, 0);

            //up
            
            if (color == Color.White)
            {
                pos.definePosition(position.row - 1, position.col);
                if (chessboard.validPos(pos) && free(pos))
                {
                    mat[pos.row, pos.col] = true;
                }                
                pos.definePosition(position.row - 2, position.col);
                Position p2 = new Position(position.row - 1, position.col);
                if (chessboard.validPos(p2) && free(p2) && chessboard.validPos(pos) && free(pos) && (movemmentsAmount == 0))
                {
                    mat[pos.row, pos.col] = true;
                }
                pos.definePosition(position.row - 1, position.col-1);
                if (chessboard.validPos(pos) && hasEnemy(pos))
                {
                    mat[pos.row, pos.col] = true;
                }
                pos.definePosition(position.row - 1, position.col+1);
                if (chessboard.validPos(pos) && hasEnemy(pos))
                {
                    mat[pos.row, pos.col] = true;
                }
            }
            else
            {
                pos.definePosition(position.row + 1, position.col);
                if (chessboard.validPos(pos) && free(pos))
                {
                    mat[pos.row, pos.col] = true;
                }
                pos.definePosition(position.row + 2, position.col);
                Position p2 = new Position(position.row - 1, position.col);
                if (chessboard.validPos(p2) && free(p2) && chessboard.validPos(pos) && free(pos) && (movemmentsAmount == 0))
                {
                    mat[pos.row, pos.col] = true;
                }
                pos.definePosition(position.row + 1, position.col - 1);
                if (chessboard.validPos(pos) && hasEnemy(pos))
                {
                    mat[pos.row, pos.col] = true;
                }
                pos.definePosition(position.row + 1, position.col + 1);
                if (chessboard.validPos(pos) && hasEnemy(pos))
                {
                    mat[pos.row, pos.col] = true;
                }

            }
            
            return mat;
        }
    }
}
