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

        public void decMovementsAmout()
        {
            movemmentsAmount--;
        }
        public bool hasPossibleMovement()
        {
            bool[,] mat = possibleMovements();
            for (int i = 0; i < chessboard.rows; i++)
            {
                for (int j = 0; j < chessboard.columns; j++)
                {
                    if (mat[i,j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool canMoveTo(Position pos)
        {
            return possibleMovements()[pos.row, pos.col];
        }

        public abstract bool[,] possibleMovements();
    }
}
